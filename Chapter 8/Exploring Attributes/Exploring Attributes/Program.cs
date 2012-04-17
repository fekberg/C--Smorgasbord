using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exploring_Attributes
{
    [Serializable]
    class Person
    {
        [XmlElement("PersonName")]
        public string Name { get; set; }
        [XmlElement("Age")]
        public int Age { get; set; }
    }
    class Program
    {
        static void Print(IEnumerable<Attribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute.ToString());
            }
        }
        static void Main(string[] args)
        {
            var personType = typeof(Person);
            var classAttributes = Attribute.GetCustomAttributes(personType);
            
            Print(classAttributes);

            foreach (var property in personType.GetProperties())
            {
                var propertyAttributes = Attribute.GetCustomAttributes(property);
                Print(propertyAttributes);
            }
        }
    }
}
