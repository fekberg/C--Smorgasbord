using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace How_dynamic_methods_affect_resources
{
    class Program
    {
        public static Func<TParam1, TParam2, TReturn> CreateInvoker<TParam1, TParam2, TReturn>(OpCode operation)
        {
            Type[] methodArguments = { 
        typeof(TParam1), 
        typeof(TParam2)
    };

            var mathOperation = new DynamicMethod(
                    "MathOperation",
                    typeof(TReturn),
                    methodArguments,
                    typeof(Func<TParam1, TParam2, TReturn>).Module);

            ILGenerator il = mathOperation.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(operation);
            il.Emit(OpCodes.Ret);

            return
                (Func<TParam1, TParam2, TReturn>)mathOperation
                .CreateDelegate(typeof(Func<TParam1, TParam2, TReturn>));
        }

        static void Main(string[] args)
        {
            Func
            for (int a = 0; a < 4; a++)
            {
                Console.WriteLine("Run: {0}", (a + 1));

                Console.WriteLine("\tMemory usage before allocations: {0}", GC.GetTotalMemory(true));
                double result = 0;
                for (int i = 0; i < 35000; i++)
                {
                    var multiplier = CreateInvoker<double, double, double>(OpCodes.Mul);
                    result += multiplier(i, 2);
                }
                Console.WriteLine("\tResult from multiplications: {0}", result); Console.WriteLine("\tMemory usage after allocations: {0}", GC.GetTotalMemory(false)); Console.WriteLine("\tMemory usage after collection: {0}", GC.GetTotalMemory(true));
            }
        }
    }
}
