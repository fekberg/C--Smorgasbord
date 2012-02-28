using System;

namespace Rossbot.Windows.Service.Test
{
    static class App
    {

        [STAThread]
        static void Main()
        {
            CommandServer.Start();

            Console.Read();
        }
    }
}
