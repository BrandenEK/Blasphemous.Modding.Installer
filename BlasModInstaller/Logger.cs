using System;
using System.Runtime.InteropServices;

namespace BlasModInstaller
{
    public static class Logger
    {
        //private static bool _enabled = false;

        //public static void Show()
        //{
        //    _enabled = true;

        //    AttachConsole(-1);
        //    //Console.Title = "Blasphemous Mod Installer";
        //}

        public static void Info(object message) => Log(message, ConsoleColor.White);

        public static void Warn(object message) => Log(message, ConsoleColor.Yellow);

        public static void Error(object message) => Log(message, ConsoleColor.Red);

        private static void Log(object message, ConsoleColor color)
        {
            //if (!_enabled)
            //    return;

            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        //[DllImport("kernel32.dll")]
        //public static extern Boolean AllocConsole();
        //[DllImport("kernel32.dll")]
        //public static extern Boolean FreeConsole();
        //[DllImport("kernel32.dll")]
        //static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);


        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        readonly static IntPtr handle = GetConsoleWindow();
        [DllImport("kernel32.dll")] static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Hide()
        {
            ShowWindow(handle, SW_HIDE); //hide the console
        }
        public static void Show()
        {
            //ShowWindow(handle, SW_SHOW); //show the console
            if (!AttachConsole(-1))
                AllocConsole();
            Console.WriteLine("consolemode started");
        }
    }
}
