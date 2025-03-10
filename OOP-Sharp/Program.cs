using System;

namespace OOP_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Vacancy
    {
        public string Title { get; set; }

    }

    class Category
    {
        public string Title { get; set; }
    }

    class Resume
    {
        public string Description { get; set; }
    }

    class Unemployed
    {
        public string FirstName { get; set; }
        /* public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } */

        class Agency
        {
            public string Name { get; set; }
        }
    }
}

