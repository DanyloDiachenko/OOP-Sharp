class JobManagementSystem
{
    private List<Category> Categories = new List<Category>();
    private List<JobSeeker> JobSeekers = new List<JobSeeker>();
    private List<Company> Companies = new List<Company>();

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

    public void AddVacancyToCategory(string categoryName, Vacancy vacancy)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        category?.Vacancies.Add(vacancy);
    }

    public void RemoveVacancyFromCategory(string categoryName, Vacancy vacancy)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        category?.Vacancies.Remove(vacancy);
    }

    public void UpdateVacancy(Vacancy vacancy, string title, string description, Company employer)
    {
        vacancy.Title = title;
        vacancy.Description = description;
        vacancy.Employer = employer;
    }

    public Vacancy GetVacancy(string title)
    {
        return Categories.SelectMany(c => c.Vacancies).FirstOrDefault(v => v.Title == title);
    }

    public List<Vacancy> GetSortedVacancies()
    {
        return Categories.SelectMany(c => c.Vacancies).OrderBy(v => v.Title).ToList();
    }

    public void AddResumeToCategory(string categoryName, Resume resume)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        category?.Resumes.Add(resume);
    }

    public void RemoveResumeFromCategory(string categoryName, Resume resume)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        category?.Resumes.Remove(resume);
    }

    public void UpdateResume(Resume resume, string name, string skills, JobSeeker jobSeeker)
    {
        resume.Name = name;
        resume.Skills = skills;
        resume.JobSeeker = jobSeeker;
    }

    public Resume GetResume(string name)
    {
        return Categories.SelectMany(c => c.Resumes).FirstOrDefault(r => r.Name == name);
    }

    public List<Resume> GetSortedResumes()
    {
        return Categories.SelectMany(c => c.Resumes).OrderBy(r => r.Name).ToList();
    }

    public void AddJobSeeker(JobSeeker seeker)
    {
        JobSeekers.Add(seeker);
    }

    public void RemoveJobSeeker(JobSeeker seeker)
    {
        JobSeekers.Remove(seeker);
    }

    public void UpdateJobSeeker(JobSeeker seeker, string firstName, string lastName, string contactInfo)
    {
        seeker.FirstName = firstName;
        seeker.LastName = lastName;
        seeker.ContactInfo = contactInfo;
    }

    public JobSeeker GetJobSeeker(string firstName, string lastName)
    {
        return JobSeekers.FirstOrDefault(js => js.FirstName == firstName && js.LastName == lastName);
    }

    public List<JobSeeker> GetAllJobSeekers()
    {
        return JobSeekers.ToList();
    }

    public List<JobSeeker> GetSortedJobSeekersByName()
    {
        return JobSeekers.OrderBy(js => js.FirstName).ToList();
    }

    public List<JobSeeker> GetSortedJobSeekersByLastName()
    {
        return JobSeekers.OrderBy(js => js.LastName).ToList();
    }

    public void AddCompany(Company company)
    {
        Companies.Add(company);
    }

    public void RemoveCompany(Company company)
    {
        Companies.Remove(company);
    }

    public void UpdateCompany(Company company, string name, string contactInfo)
    {
        company.Name = name;
        company.ContactInfo = contactInfo;
    }

    public Company GetCompany(string name)
    {
        return Companies.FirstOrDefault(c => c.Name == name);
    }

    public List<Company> GetAllCompanies()
    {
        return Companies.ToList();
    }

    public List<Company> GetSortedCompaniesByName()
    {
        return Companies.OrderBy(c => c.Name).ToList();
    }

    public List<Vacancy> SearchVacancies(string keyword)
    {
        return Categories.SelectMany(c => c.Vacancies)
            .Where(v => v.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        v.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<JobSeeker> SearchJobSeekers(string keyword)
    {
        return JobSeekers.Where(js => js.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                      js.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                      js.ContactInfo.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                         .ToList();
    }
}