namespace Forms
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
            Application.Run(new MainForm());
            //Application.Run(new ApplicationContext());

            // TODO: fix everything later: https://stackoverflow.com/questions/26617159/hook-detect-windows-language-change-even-when-app-not-focused
        }
    }
}