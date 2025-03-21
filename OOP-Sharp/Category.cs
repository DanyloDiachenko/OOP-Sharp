class Category
{
    public string Name { get; set; }
    public List<Vacancy> Vacancies { get; set; }
    public List<Resume> Resumes { get; set; }

    public Category(string name)
    {
        Name = name;
        Vacancies = new List<Vacancy>();
        Resumes = new List<Resume>();
    }
}