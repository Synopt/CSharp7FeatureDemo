using System;

namespace CSharp7FeatureDemo
{
    class Person
    {
        string _name;
        string Name
        {
            get => _name;
            set => _name = value;
        }

        public Person(string name) => Name = name;
        ~Person() => Console.WriteLine("Boom");

        public Person GetPerson(string name) => new Person(name); // Existing
    }
}
