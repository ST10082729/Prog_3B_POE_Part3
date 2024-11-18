using System;
using System.Windows.Forms;

namespace Prog3BPoe
{
    internal static class Program
    {
        public static ServiceRequestManager RequestManager = new ServiceRequestManager();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
