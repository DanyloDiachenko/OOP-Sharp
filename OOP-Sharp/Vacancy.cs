class Vacancy
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Company Employer { get; set; }

    public Vacancy(string title, string description, Company employer)
    {
        Title = title;
        Description = description;
        Employer = employer;
    }
}