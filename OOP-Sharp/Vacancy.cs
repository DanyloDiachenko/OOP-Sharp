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