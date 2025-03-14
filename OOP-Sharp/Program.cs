using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        TestJobManagementSystem();
    }

    static void TestJobManagementSystem()
    {
        JobManagementSystem system = new JobManagementSystem();

        Category itCategory = new Category { Name = "IT", Vacancies = new List<Vacancy>(), Resumes = new List<Resume>() };
        system.AddCategory(itCategory);

        Company techCorp = new Company { Name = "TechCorp", ContactInfo = "info@techcorp.com" };
        system.AddCompany(techCorp);

        JobSeeker ivan = new JobSeeker { FirstName = "Іван", LastName = "Петренко", ContactInfo = "ivan@example.com" };
        system.AddJobSeeker(ivan);

        Vacancy developerVacancy = new Vacancy { Title = "Розробник", Description = "Розробка ПЗ", Employer = techCorp };
        system.AddVacancyToCategory("IT", developerVacancy);

        Resume ivanResume = new Resume { Name = "Резюме Івана", Skills = "C#, .NET", JobSeeker = ivan };
        system.AddResumeToCategory("IT", ivanResume);

        Company designStudio = new Company { Name = "DesignStudio", ContactInfo = "info@designstudio.com" };
        system.AddCompany(designStudio);

        JobSeeker maria = new JobSeeker { FirstName = "Марія", LastName = "Іваненко", ContactInfo = "maria@example.com" };
        system.AddJobSeeker(maria);

        Vacancy designerVacancy = new Vacancy { Title = "Дизайнер", Description = "Розробка UI/UX", Employer = designStudio };
        system.AddVacancyToCategory("IT", designerVacancy);

        Resume mariaResume = new Resume { Name = "Резюме Марії", Skills = "Photoshop, Figma", JobSeeker = maria };
        system.AddResumeToCategory("IT", mariaResume);

        Console.WriteLine("=== Тестування методів JobManagementSystem ===");

        Console.WriteLine("Додано вакансію 'Розробник' та резюме 'Резюме Івана' до категорії IT.");

        system.RemoveVacancyFromCategory("IT", developerVacancy);
        system.RemoveResumeFromCategory("IT", ivanResume);
        Console.WriteLine("Видалено вакансію 'Розробник' та резюме 'Резюме Івана' з категорії IT.");

        system.UpdateVacancy(developerVacancy, "Старший розробник", "Розробка ПЗ", techCorp);
        system.UpdateResume(ivanResume, "Резюме Івана", "C#, .NET, SQL", ivan);
        Console.WriteLine("Оновлено вакансію до 'Старший розробник' та резюме з новими навичками 'C#, .NET, SQL'.");

        Vacancy vacancy = system.GetVacancy("Старший розробник");
        Resume resume = system.GetResume("Резюме Івана");
        Console.WriteLine($"Отримано вакансію: {vacancy?.Title}, резюме: {resume?.Name}");

        List<Vacancy> sortedVacancies = system.GetSortedVacancies();
        List<Resume> sortedResumes = system.GetSortedResumes();
        Console.WriteLine("Відсортовані вакансії: " + string.Join(", ", sortedVacancies.Select(v => v.Title)));
        Console.WriteLine("Відсортовані резюме: " + string.Join(", ", sortedResumes.Select(r => r.Name)));

        JobSeeker petro = new JobSeeker { FirstName = "Петро", LastName = "Сидоренко", ContactInfo = "petro@example.com" };
        system.AddJobSeeker(petro);
        system.UpdateJobSeeker(ivan, "Іван", "Петренко", "ivan.updated@example.com");
        system.RemoveJobSeeker(petro);
        Console.WriteLine("Додано шукача 'Петро', оновлено контакт Івана, видалено Петра.");

        JobSeeker foundSeeker = system.GetJobSeeker("Марія", "Іваненко");
        List<JobSeeker> allSeekers = system.GetAllJobSeekers();
        List<JobSeeker> sortedByName = system.GetSortedJobSeekersByName();
        Console.WriteLine($"Отримано шукача: {foundSeeker?.FirstName} {foundSeeker?.LastName}");
        Console.WriteLine("Всі шукачі: " + string.Join(", ", allSeekers.Select(s => s.FirstName)));
        Console.WriteLine("Відсортовані за іменем: " + string.Join(", ", sortedByName.Select(s => s.FirstName)));

        Company newCompany = new Company { Name = "NewTech", ContactInfo = "newtech@example.com" };
        system.AddCompany(newCompany);
        system.UpdateCompany(techCorp, "TechCorp Ltd", "contact@techcorp.com");
        system.RemoveCompany(newCompany);
        Console.WriteLine("Додано 'NewTech', оновлено 'TechCorp' до 'TechCorp Ltd', видалено 'NewTech'.");

        Company foundCompany = system.GetCompany("TechCorp Ltd");
        List<Company> allCompanies = system.GetAllCompanies();
        List<Company> sortedCompanies = system.GetSortedCompaniesByName();
        Console.WriteLine($"Отримано компанію: {foundCompany?.Name}");
        Console.WriteLine("Всі компанії: " + string.Join(", ", allCompanies.Select(c => c.Name)));
        Console.WriteLine("Відсортовані компанії: " + string.Join(", ", sortedCompanies.Select(c => c.Name)));

        List<Vacancy> foundVacancies = system.SearchVacancies("розробник");
        List<JobSeeker> foundSeekers = system.SearchJobSeekers("Іван");
        Console.WriteLine("Знайдені вакансії за словом 'розробник': " + string.Join(", ", foundVacancies.Select(v => v.Title)));
        Console.WriteLine("Знайдені шукачі за словом 'Іван': " + string.Join(", ", foundSeekers.Select(s => s.FirstName)));
    }
}