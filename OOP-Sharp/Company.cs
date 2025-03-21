class Company
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public Company(string name, string contactInfo)
    {
        Name = name;
        ContactInfo = contactInfo;
    }
}