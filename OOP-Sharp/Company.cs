class Company
{
    public string Name { get; set; }
    public string Contact { get; set; }

    public Company(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public void Get()
    {
        Console.WriteLine($"Company: {Name}, Contact: {Contact}");
    }
}