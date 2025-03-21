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

        Category itCategory = new Category("IT");
        system.AddCategory(itCategory);

        Company techCorp = new Company("TechCorp", "info@techcorp.com");
        system.AddCompany(techCorp);

        Company designStudio = new Company("DesignStudio", "info@designstudio.com");
        system.AddCompany(designStudio);

        Vacancy developerVacancy = new Vacancy("Розробник", "Розробка ПЗ", techCorp);
        system.AddVacancyToCategory("IT", developerVacancy);

        Vacancy designerVacancy = new Vacancy("Дизайнер", "Розробка UI/UX", designStudio);
        system.AddVacancyToCategory("IT", designerVacancy);

        Resume ivanResume = new Resume("Резюме Івана", "C#, .NET", "Іван", "Петренко", "ivan@example.com");
        system.AddResumeToCategory("IT", ivanResume);

        Resume mariaResume = new Resume("Резюме Марії", "Photoshop, Figma", "Марія", "Іваненко", "maria@example.com");
        system.AddResumeToCategory("IT", mariaResume);

        Console.WriteLine("=== Тестування методів JobManagementSystem ===");

        Console.WriteLine("Додано вакансію 'Розробник' та резюме 'Резюме Івана' до категорії IT.");

        system.RemoveVacancyFromCategory("IT", developerVacancy);
        system.RemoveResumeFromCategory("IT", ivanResume);
        Console.WriteLine("Видалено вакансію 'Розробник' та резюме 'Резюме Івана' з категорії IT.");

        system.UpdateVacancy(developerVacancy, "Старший розробник", "Розробка ПЗ", techCorp);
        system.UpdateResume(ivanResume, "Резюме Івана", "C#, .NET, SQL", ivanResume.JobSeeker);
        Console.WriteLine("Оновлено вакансію до 'Старший розробник' та резюме з новими навичками 'C#, .NET, SQL'.");

        List<Vacancy> sortedVacancies = system.GetSortedVacancies();
        List<Resume> sortedResumes = system.GetSortedResumes();
        system.PrintVacancies(sortedVacancies);
        system.PrintResumes(sortedResumes);

        JobSeeker petro = new JobSeeker("Петро", "Сидоренко", "petro@example.com");
        system.AddJobSeeker(petro);
        system.UpdateJobSeeker(petro, "Петро", "Сидоренко", "petro.updated@example.com");
        system.RemoveJobSeeker(petro);
        Console.WriteLine("Додано шукача 'Петро', оновлено контакт 'Петро', видалено 'Петро'.");

        JobSeeker anton = new JobSeeker("Антон", "Коваленко", "anton@example.com");
        JobSeeker maria = new JobSeeker("Марія", "Коваленко", "maria@example.com");
        system.AddJobSeeker(anton);
        system.AddJobSeeker(maria);
        Console.WriteLine("================================================");
        List<JobSeeker> sortedByName = system.GetSortedJobSeekersByName();
        system.PrintJobSeekers(sortedByName);
        Console.WriteLine("================================================");
        List<JobSeeker> allSeekers = system.GetAllJobSeekers();
        system.PrintJobSeekers(allSeekers);
        Company newCompany = new Company("NewTech", "newtech@example.com");
        system.AddCompany(newCompany);
        system.UpdateCompany(techCorp, "TechCorp Ltd", "contact@techcorp.com");
        system.RemoveCompany(newCompany);
        Console.WriteLine("Додано 'NewTech', оновлено 'TechCorp' до 'TechCorp Ltd', видалено 'NewTech'.");

        Company? foundCompany = system.GetCompany("TechCorp Ltd");
        List<Company> allCompanies = system.GetAllCompanies();
        List<Company> sortedCompanies = system.GetSortedCompaniesByName();
        Console.WriteLine($"Отримано компанію: {foundCompany?.Name}");
        system.PrintCompanies(allCompanies);
        system.PrintCompanies(sortedCompanies);

        List<Vacancy> foundVacancies = system.SearchVacancies("розробник");
        List<JobSeeker> foundSeekers = system.SearchJobSeekers("Іван");
        system.PrintVacancies(foundVacancies);
        system.PrintJobSeekers(foundSeekers);
    }
}
