using System.Collections.Generic;
using System.Reflection;

namespace Creating_A_Generic_Search
{
    class Location
    {
        public string Address { get; set; }
    }
    class Person
    {
        public string Name { get; set; }
        public Location Location { get; set; }
    }
    class Program
    {
        static IEnumerable<dynamic> Find(dynamic pattern, IEnumerable<dynamic> source)
        {
            var found = new List<dynamic>();

            foreach (var obj in source)
            {
                foreach (PropertyInfo property in obj.GetType().GetProperties())
                {
                    if (property.PropertyType != pattern.GetType()) continue;

                    if (pattern == property.GetValue(obj, null))
                        found.Add(obj);
                }
            }

            return found;
        }
        static void Main(string[] args)
        {
            var filip =
                new Person
                {
                    Name = "Filip",
                    Location = new Location { Address = "Earth" }
                };

            var sofie =
                new Person
                {
                    Name = "Sofie",
                    Location = new Location { Address = "Earth" }
                };

            var toLookup = new List<dynamic> { filip, sofie };

            var found = Find(new Location { Address = "Earth" }, toLookup);
        }
    }
}
