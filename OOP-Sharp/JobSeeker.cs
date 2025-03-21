class JobSeeker : Human
{
    public string ContactInfo { get; set; }

    public JobSeeker(string firstName, string lastName, string contactInfo)
        : base(firstName, lastName)
    {
        ContactInfo = contactInfo;
    }
}