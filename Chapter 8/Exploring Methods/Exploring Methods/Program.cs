using System;
using System.Linq;
using System.Reflection;

namespace Exploring_Methods
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Yell()
        {
            return "There is no cake!";
        }
        public string Speak()
        {
            return string.Format("Hello, my name is {0}", Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Age = 25, Name = "Filip Ekberg" };
            var type = typeof(Person);

            MethodInfo[] methods = type.GetMethods();

            var firstMethod = methods.FirstOrDefault(x => !x.Name.StartsWith("get_") && !x.Name.StartsWith("set_"));

            if (firstMethod != null)
                Console.WriteLine(firstMethod.Invoke(person, null));
        }
    }
}
