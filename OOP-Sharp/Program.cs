using System;
using System.Collections.Generic;
using System.Linq;

namespace JobMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            JobService jobService = new JobService();
            Console.WriteLine("Welcome to the Job Market!");

            Category itCategory = new("IT");
            Category designCategory = new("Design");
            Category managementCategory = new("Management");

            jobService.AddCategory(itCategory);
            jobService.AddCategory(designCategory);
            jobService.AddCategory(managementCategory);
            jobService.AddCategory(itCategory);

            Company techCorp = new("TechCorp", "contact@techcorp.com");
            Company designHub = new("DesignHub", "info@designhub.com");
            jobService.AddCompany(techCorp);
            jobService.AddCompany(designHub);

            jobService.AddVacancy(new Vacancy("Developer", itCategory, 10000, techCorp));
            jobService.AddVacancy(new Vacancy("Designer", designCategory, 8000, designHub));
            jobService.AddVacancy(new Vacancy("Manager", managementCategory, 12000, techCorp));

            jobService.AddUnemployed(new Unemployed("John", "Doe", "john.doe@example.com", "1234567890", new Resume("Junior Developer, 1 year experience")));
            jobService.AddUnemployed(new Unemployed("Jane", "Doe", "jane.doe@example.com", "0987654321", new Resume("Middle Developer, 5 years experience")));
            jobService.AddUnemployed(new Unemployed("Jim", "Beam", "jim.beam@example.com", "5555555555", new Resume("Senior Developer, 10 years experience")));

            Console.WriteLine("\n=== Testing ===");
            Console.WriteLine("\n1. All data:");
            jobService.GetAllData();

            Console.WriteLine("\n2. Sort vacancies by category and salary:");
            jobService.SortVacancies();

            Console.WriteLine("\n3. Search vacancies by keyword 'Dev':");
            jobService.SearchVacancies("Dev");

            Console.WriteLine("\n4. Search unemployed by keyword 'Doe':");
            jobService.SearchUnemployeds("Doe");

            Console.WriteLine("\n5. Sort unemployed by last name:");
            jobService.SortUnemployedsByLastName();

            Console.WriteLine("\n6. Get all companies:");
            jobService.GetAllCompanies();
        }
    }

    class Vacancy
    {
        public string Title { get; set; }
        public double Salary { get; set; }
        public Category Category { get; set; }
        public Company Company { get; set; }

        public Vacancy(string title, Category category, double salary, Company company)
        {
            Title = title;
            Category = category;
            Salary = salary;
            Company = company;
        }

        public void Get()
        {
            Console.WriteLine($"Vacancy: {Title}, Category: {Category.Title}, Salary: {Salary}, Company: {Company.Name}");
        }
    }

    class Category
    {
        public string Title { get; private set; }

        public Category(string title)
        {
            Title = title;
        }
    }

    class Resume
    {
        public string Description { get; set; }

        public Resume(string description)
        {
            Description = description;
        }
    }

    class Unemployed
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Resume Resume { get; set; }

        public Unemployed(string firstName, string lastName, string email, string phone, Resume resume)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Resume = resume;
        }

        public void Get()
        {
            Console.WriteLine($"Unemployed: {FirstName} {LastName}, Email: {Email}, Phone: {Phone}, Resume: {Resume.Description}");
        }
    }

    class Company
    {
        public string Name { get; set; }
        public string Contact { get; set; }

        public Company(string name, string contact)
        {
            Name = name;
            Contact = contact;
        }

        public void Get()
        {
            Console.WriteLine($"Company: {Name}, Contact: {Contact}");
        }
    }

    class JobService
    {
        private List<Vacancy> Vacancies { get; } = new();
        private List<Unemployed> Unemployeds { get; } = new();
        private List<Category> Categories { get; } = new();
        private List<Company> Companies { get; } = new();

        public void AddVacancy(Vacancy vacancy)
        {
            Vacancies.Add(vacancy);
        }

        public void UpdateVacancy(Vacancy oldVacancy, Vacancy newVacancy)
        {
            int index = Vacancies.IndexOf(oldVacancy);
            if (index != -1)
            {
                Vacancies[index] = newVacancy;
            }
            else
            {
                Console.WriteLine("Vacancy not found.");
            }
        }

        public void RemoveVacancy(Vacancy vacancy)
        {
            Vacancies.Remove(vacancy);
        }

        public void SortVacancies()
        {
            Vacancies.OrderBy(v => v.Category.Title).ThenByDescending(v => v.Salary).ToList().ForEach(v => v.Get());
        }

        public void GetVacancy(string title)
        {
            Vacancies.Where(v => v.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(v => v.Get());
        }

        public void AddCategory(Category category)
        {
            if (!Categories.Any(c => c.Title == category.Title))
            {
                Categories.Add(category);
            }
            else
            {
                Console.WriteLine($"Category '{category.Title}' already exists.");
            }
        }

        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }

        public void AddUnemployed(Unemployed unemployed)
        {
            Unemployeds.Add(unemployed);
        }

        public void UpdateUnemployed(Unemployed oldUnemployed, Unemployed newUnemployed)
        {
            int index = Unemployeds.IndexOf(oldUnemployed);
            if (index != -1)
            {
                Unemployeds[index] = newUnemployed;
            }
            else
            {
                Console.WriteLine("Unemployed not found.");
            }
        }

        public void RemoveUnemployed(Unemployed unemployed)
        {
            Unemployeds.Remove(unemployed);
        }

        public void GetUnemployed(string name)
        {
            Unemployeds.Where(u => u.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || u.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(u => u.Get());
        }

        public void GetAllUnemployeds()
        {
            Unemployeds.ForEach(u => u.Get());
        }

        public void SortUnemployedsByName()
        {
            Unemployeds.OrderBy(u => u.FirstName).ToList().ForEach(u => u.Get());
        }

        public void SortUnemployedsByLastName()
        {
            Unemployeds.OrderBy(u => u.LastName).ToList().ForEach(u => u.Get());
        }

        public void AddCompany(Company company)
        {
            Companies.Add(company);
        }

        public void UpdateCompany(Company oldCompany, Company newCompany)
        {
            int index = Companies.IndexOf(oldCompany);
            if (index != -1)
            {
                Companies[index] = newCompany;
            }
            else
            {
                Console.WriteLine("Company not found.");
            }
        }

        public void RemoveCompany(Company company)
        {
            Companies.Remove(company);
        }

        public void GetCompany(string name)
        {
            Companies.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(c => c.Get());
        }

        public void GetAllCompanies()
        {
            Companies.ForEach(c => c.Get());
        }

        public void SortCompaniesByName()
        {
            Companies.OrderBy(c => c.Name).ToList().ForEach(c => c.Get());
        }

        public void SearchVacancies(string keyword)
        {
            Vacancies.Where(v => v.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(v => v.Get());
        }

        public void SearchUnemployeds(string keyword)
        {
            Unemployeds.Where(u => u.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                  u.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                  u.Resume.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(u => u.Get());
        }

        public void GetAllData()
        {
            Console.WriteLine("\n--- Vacancies ---");
            Vacancies.ForEach(v => v.Get());

            Console.WriteLine("\n--- Unemployeds ---");
            Unemployeds.ForEach(u => u.Get());

            Console.WriteLine("\n--- Companies ---");
            Companies.ForEach(c => c.Get());

            Console.WriteLine("\n--- Categories ---");
            Categories.ForEach(c => Console.WriteLine($"Category: {c.Title}"));
        }
    }
}