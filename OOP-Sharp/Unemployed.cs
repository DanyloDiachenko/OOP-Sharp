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

