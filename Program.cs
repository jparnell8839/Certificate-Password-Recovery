using System;
using System.Windows.Forms;

namespace CertificatePasswordRecovery
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
            Application.Run(new CertPasswordRecoveryForm());
        }
    }
}
