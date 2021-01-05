using System;

namespace RendererEngine
{
    public static class Debug
    {
        public static void Log(string text)
        {
            Console.WriteLine(text);
        }

        public static void WarningLog(string text)
        {
            Console.WriteLine("[Warning!] " + text);
        }

        public static void ErrorLog(string text)
        {
            Console.WriteLine("[ERROR!] " + text);
        }

    }
}
