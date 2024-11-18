using System;
using System.Collections.Generic;

namespace Prog3BPoe
{
    public class ServiceRequestManager
    {
        // Internal TreeNode class to represent nodes in the AVL Tree
        private class TreeNode
        {
            public ServiceRequest Request { get; set; } // Service request data stored in the node
            public TreeNode Left { get; set; } // Left child of the current node
            public TreeNode Right { get; set; } // Right child of the current node
            public int Height { get; set; } // Height of the node, used for balancing

            public TreeNode(ServiceRequest request)
            {
                Request = request;
                Height = 1; // Default height for a new node is 1
            }
        }

        private TreeNode Root; // Root of the AVL Tree
        private PriorityQueue<ServiceRequest, DateTime> priorityQueue = new PriorityQueue<ServiceRequest, DateTime>();
        private Dictionary<string, ServiceRequest> graph = new Dictionary<string, ServiceRequest>();
        private Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

        // Adds a new service request to the AVL Tree, Priority Queue, and Graph
        public void AddRequest(ServiceRequest request)
        {
            Root = Insert(Root, request); // Insert request into the AVL Tree
            priorityQueue.Enqueue(request, request.SubmissionDate); // Add request to the Priority Queue
            graph[request.RequestID] = request; // Add request to the graph for quick access

            Console.WriteLine($"Request Added: {request.RequestID}, Location: {request.Location}, Status: {request.Status}");
        }

        // Recursive function to insert a node into the AVL Tree
        private TreeNode Insert(TreeNode node, ServiceRequest request)
        {
            if (node == null)
            {
                Console.WriteLine($"Inserting new node: {request.RequestID}");
                return new TreeNode(request); // Create and return a new node
            }

            // Compare RequestIDs to decide insertion direction
            if (string.Compare(request.RequestID, node.Request.RequestID, StringComparison.Ordinal) < 0)
            {
                Console.WriteLine($"Going left: {request.RequestID} < {node.Request.RequestID}");
                node.Left = Insert(node.Left, request); // Insert into the left subtree
            }
            else if (string.Compare(request.RequestID, node.Request.RequestID, StringComparison.Ordinal) > 0)
            {
                Console.WriteLine($"Going right: {request.RequestID} > {node.Request.RequestID}");
                node.Right = Insert(node.Right, request); // Insert into the right subtree
            }
            else
            {
                // Duplicate RequestIDs are not allowed
                return node;
            }

            // Update the height of the current node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Balance the node and return the balanced node
            return BalanceNode(node);
        }

        // Returns the height of a node, or 0 if the node is null
        private int GetHeight(TreeNode node) => node?.Height ?? 0;

        // Calculates the balance factor of a node
        private int GetBalance(TreeNode node) => node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);

        // Balances the given node if it is unbalanced
        private TreeNode BalanceNode(TreeNode node)
        {
            int balance = GetBalance(node);

            // Left Heavy
            if (balance > 1)
            {
                if (GetBalance(node.Left) < 0)
                {
                    node.Left = RotateLeft(node.Left); // Perform Left Rotation on the left child
                }
                return RotateRight(node); // Perform Right Rotation
            }

            // Right Heavy
            if (balance < -1)
            {
                if (GetBalance(node.Right) > 0)
                {
                    node.Right = RotateRight(node.Right); // Perform Right Rotation on the right child
                }
                return RotateLeft(node); // Perform Left Rotation
            }

            return node; // Node is already balanced
        }

        // Performs a Right Rotation on the given node
        private TreeNode RotateRight(TreeNode y)
        {
            TreeNode x = y.Left;
            TreeNode T = x.Right;

            x.Right = y;
            y.Left = T;

            // Update heights of the rotated nodes
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x; // Return the new root
        }

        // Performs a Left Rotation on the given node
        private TreeNode RotateLeft(TreeNode x)
        {
            TreeNode y = x.Right;
            TreeNode T = y.Left;

            y.Left = x;
            x.Right = T;

            // Update heights of the rotated nodes
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y; // Return the new root
        }

        // Performs an in-order traversal of the AVL Tree to retrieve all service requests
        public List<ServiceRequest> GetAllRequests()
        {
            var requests = new List<ServiceRequest>();
            Console.WriteLine("Calling GetAllRequests...");
            InOrderTraversal(Root, requests); // Traverse the tree in-order
            Console.WriteLine($"GetAllRequests: Retrieved {requests.Count} requests.");
            return requests;
        }

        // Recursive function for in-order traversal
        private void InOrderTraversal(TreeNode node, List<ServiceRequest> requests)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, requests); // Visit the left subtree
            Console.WriteLine($"Visited Node: {node.Request.RequestID}");
            requests.Add(node.Request); // Add the current node to the list
            InOrderTraversal(node.Right, requests); // Visit the right subtree
        }

        // Adds a dependency between two service requests in the graph
        public void AddDependency(string requestId1, string requestId2)
        {
            if (!adjacencyList.ContainsKey(requestId1))
                adjacencyList[requestId1] = new List<string>();
            if (!adjacencyList.ContainsKey(requestId2))
                adjacencyList[requestId2] = new List<string>();

            adjacencyList[requestId1].Add(requestId2); // Add edge from requestId1 to requestId2
            adjacencyList[requestId2].Add(requestId1); // Add edge from requestId2 to requestId1

            Console.WriteLine($"Dependency added between {requestId1} and {requestId2}");
        }

        // Retrieves the list of dependencies for a given request
        public List<string> GetDependencies(string requestId)
        {
            if (adjacencyList.ContainsKey(requestId))
            {
                return adjacencyList[requestId]; // Return the dependencies
            }
            return null; // Return null if no dependencies exist
        }

        // Generates the Minimum Spanning Tree (MST) using Prim's Algorithm
        public List<(string, string)> GenerateMST()
        {
            if (adjacencyList.Count == 0)
            {
                Console.WriteLine("No dependencies to form an MST.");
                return null;
            }

            var visited = new HashSet<string>(); // Tracks visited nodes
            var mstEdges = new List<(string, string)>(); // Stores MST edges

            var startNode = adjacencyList.Keys.GetEnumerator();
            startNode.MoveNext();
            string start = startNode.Current;

            var priorityQueue = new PriorityQueue<(string, string, int), int>();
            visited.Add(start);

            foreach (var neighbor in adjacencyList[start])
            {
                priorityQueue.Enqueue((start, neighbor, 1), 1); // Assuming weight = 1 for simplicity
            }

            while (!priorityQueue.IsEmpty())
            {
                var edge = priorityQueue.Dequeue();
                if (visited.Contains(edge.Item2))
                    continue;

                visited.Add(edge.Item2);
                mstEdges.Add((edge.Item1, edge.Item2)); // Add edge to the MST

                foreach (var neighbor in adjacencyList[edge.Item2])
                {
                    if (!visited.Contains(neighbor))
                    {
                        priorityQueue.Enqueue((edge.Item2, neighbor, 1), 1);
                    }
                }
            }

            Console.WriteLine("Minimum Spanning Tree Edges:");
            foreach (var mstEdge in mstEdges)
            {
                Console.WriteLine($"{mstEdge.Item1} - {mstEdge.Item2}");
            }

            return mstEdges;
        }
    }
}
