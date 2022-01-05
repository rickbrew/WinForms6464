using System;
using System.Windows.Forms;

namespace WinForms6464
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Set up conditions for the bug...
            BaseForm.EnableOpacityGlobally = false;

            Application.Run(new MainForm());
        }
    }
}