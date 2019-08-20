using System;
using System.Windows.Forms;

namespace ReportMe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainContainer());

            //                    //string s = GetRuns("44");
            //                    //string[] results = GetTests(s);

        }
    }
}
