namespace MoonStat
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Controller controller = new Controller();
            controller.IniciarPrograma();
        }
    }
}