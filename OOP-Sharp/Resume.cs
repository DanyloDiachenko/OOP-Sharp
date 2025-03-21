class Resume
{
    public string Name { get; set; }
    public string Skills { get; set; }
    public JobSeeker JobSeeker { get; set; }

    public Resume(string name, string skills, string firstName, string lastName, string contactInfo)
    {
        Name = name;
        Skills = skills;
        JobSeeker = new JobSeeker(firstName, lastName, contactInfo);
    }
}