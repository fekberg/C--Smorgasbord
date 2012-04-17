using System;
using System.Reflection;

namespace Setting_Values_with_Reflection
{
    class Computer
    {
        public string Name { get; set; }
        public double Ghz { get; set; }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Computer[] Computers { get; set; }

        public Computer this[int index]
        {
            get
            {
                return Computers[index];
            }
            set
            {
                Computers[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Age = 25 };

            Type personType = typeof(Person);
            PropertyInfo nameProperty = personType.GetProperty("Name");

            nameProperty.SetValue(person, "Filip", null);

            PropertyInfo computersProperty = personType.GetProperty("Computers");
            computersProperty.SetValue(person, new Computer[2], null);

            var computers = (Computer[])computersProperty.GetValue(person, null);
            computers[0] = new Computer { Name = "SuperComputer 1", Ghz = 6.0 };

PropertyInfo indexProperty = personType.GetProperty("Item");
indexProperty.SetValue(person, 
    new Computer
        {
            Name = "SuperComputer 2", 
            Ghz = 8.0
        }, new object[] { 1 });
        }
    }
}
