class Category
{
    public string Name { get; set; }
    public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
    public List<Resume> Resumes { get; set; } = new List<Resume>();
}