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
}