using System;
using Business;
using IronPython.Hosting;

namespace IronPython_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var runtime = Python.CreateRuntime();
            dynamic source = runtime.UseFile("MathLib.py");

            dynamic math = source.MathLib();
            var result = math.add(1, 2);

            Console.WriteLine(result);

            var powResult = math.pow(2, 32);
            Console.WriteLine(powResult);

            dynamic personSource = runtime.UseFile("PersonLib.py");
            dynamic personLib = personSource.PersonLib();
            Person person = personLib.getPerson();
            Console.WriteLine(person.Name);
        }
    }
}