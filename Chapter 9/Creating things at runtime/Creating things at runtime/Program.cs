using System;
using System.Reflection.Emit;

namespace Creating_things_at_runtime
{
    class Program
    {
        delegate double DivideInvoker(int a, int b);
        static void Main(string[] args)
        {
            var division = new DynamicMethod(
                    "Division",
                    typeof(double),  // Return type
                    new[] { 
                        typeof(int), // Parameter: a
                        typeof(int)  // Parameter: b
                    },
                    typeof(Program).Module
                );

            ILGenerator il = division.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Div);
            il.Emit(OpCodes.Ret);

            var result =
                division.Invoke(null, new object[] { 6, 2 });

            Console.WriteLine(result);
            var divideIt =
                (DivideInvoker)division.CreateDelegate(typeof(DivideInvoker));

            var divideItResult = divideIt(4, 0);

            Console.WriteLine(divideItResult);

        }
    }
}
