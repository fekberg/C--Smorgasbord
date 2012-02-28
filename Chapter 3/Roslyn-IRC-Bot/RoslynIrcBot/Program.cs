using System.Globalization;
using System.Threading;

namespace RoslynIrcBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            var bot = new Bot();

            bot.Start();
        }
    }
}
