using System.IO;
namespace Creating_a_lot_of_methods_on_disk
{
    class Program
    {
        static void Main(string[] args)
        {
var mainBody = "";
var methods = "";
for (var i = 0; i < 35000; i++)
{
    mainBody += string.Format("result += Mul_{0}({0}, 2);", i);
    methods += "public static double Mul_" + i + "(double a, double b) { return a * b; }";
}

var output = @" using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Reflection.Emit;
                using System.Text;

                class Program { " + methods + @"
                static void Main() {";

output += "for (int a = 0; a < 4; a++) { ";
output += "Console.WriteLine(\"Run: {0}\", (a + 1));";
output += "Console.WriteLine(\"\tMemory usage before allocations: {0}\", GC.GetTotalMemory(true));";
output += "double result = 0;";
output += mainBody;
output += "Console.WriteLine(\"\tResult from multiplications: {0}\", result);";
output += "Console.WriteLine(\"\tMemory usage after allocations: {0}\", GC.GetTotalMemory(false));";
output += "Console.WriteLine(\"\tMemory usage after collection: {0}\", GC.GetTotalMemory(true)); } } }";

File.WriteAllText("Main.cs", output);
        }
    }
}
