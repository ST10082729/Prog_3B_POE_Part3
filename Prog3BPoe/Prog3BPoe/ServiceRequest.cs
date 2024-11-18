using System;
using System.Collections.Generic;

namespace Prog3BPoe
{
    public class ServiceRequest
    {
        public string RequestID { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}