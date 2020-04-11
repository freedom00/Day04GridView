using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04GridView
{
    internal class Person
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 150 || value.Contains(";"))
                {
                    throw new ArgumentOutOfRangeException("Name must be 1-150, and must not contain ';'.");
                }
                name = value;
            }
        }

        private int age;

        public int Age
        {
            get => age;
            set
            {
                if (value < 1 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age must be 1-150.");
                }
                age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}; Age: {1}", Name, Age);
        }
    }
}