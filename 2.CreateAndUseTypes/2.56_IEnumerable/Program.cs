using System;
using System.Collections;
using System.Collections.Generic;

namespace _2._56_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Person("Kevin", "Durant");
            var b = new Person("Russell", "Westbrook");
            var people = new People(new[] { a, b });

            foreach (var p in people)
                Console.WriteLine(p);

            Console.ReadLine();
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    class People : IEnumerable<Person>
    {
        Person[] people;

        public People(Person[] people)
        {
            this.people = people;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < people.Length; i++)
                yield return people[i]; //yield can only be used in the context of iterators. It tells the compiler to convert this regular code into a state machine
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
