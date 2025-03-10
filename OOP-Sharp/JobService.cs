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
