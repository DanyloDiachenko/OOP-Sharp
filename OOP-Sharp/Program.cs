namespace OOP_Sharp
{
    class Program
    {
        public static List<Unemployed> unemployeds = [];
        public static List<Agency> agencies = [];
        public static List<Vacancy> vacancies = [];
        public static List<Resume> resumes = [];
        public static List<Category> categories = [];

        public void SortVacancies()
        {
            vacancies.Sort((a, b) => a.Category.Title.CompareTo(b.Category.Title));
        }

        public void SortResumes()
        {
            resumes.Sort((a, b) => a.Description.CompareTo(b.Description));
        }

        public void GetVacancies()
        {
            foreach (Vacancy vacancy in vacancies)
            {
                vacancy.Get();
            }
        }

        public void GetVacanciesByTitle(string title)
        {
            foreach (Vacancy vacancy in vacancies)
            {
                if (vacancy.Title.ToLower().Contains(title.ToLower()))
                {
                    vacancy.Get();
                }
            }
        }

        public void GetUnemployedsByFirstName(string firstName)
        {
            foreach (Unemployed unemployed in unemployeds)
            {
                if (unemployed.FirstName.ToLower().Contains(firstName.ToLower()))
                {
                    unemployed.Get();
                }
            }
        }

        public void GetResumes()
        {
            foreach (Resume resume in resumes)
            {
                resume.Get();
            }
        }

        public void DeleteUnemployed(Unemployed unemployed)
        {
            unemployeds.Remove(unemployed);
        }

        public void GetUnemployeds()
        {
            foreach (Unemployed unemployed in unemployeds)
            {
                unemployed.Get();
            }
        }

        public void SortUnemployeds(string sortBy)
        {
            switch (sortBy)
            {
                case "firstName":
                    unemployeds.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                    break;
                case "lastName":
                    unemployeds.Sort((a, b) => a.LastName.CompareTo(b.LastName));
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Category itCategory = new Category("IT");
            Category designCategory = new Category("Design");
            Category managementCategory = new Category("Management");

            Vacancy developerVacancy = new Vacancy("Developer", itCategory);
            Vacancy designerVacancy = new Vacancy("Designer", designCategory);
            Vacancy managerVacancy = new Vacancy("Manager", managementCategory);

            Resume developerResume1 = new Resume("Junior Developer with 1 year of experience");
            Unemployed developerUnemployed1 = new Unemployed("John", "Doe", "john.doe@example.com", "1234567890", developerResume1);
            Resume developerResume2 = new Resume("Middle Developer with 5 years of experience");
            Unemployed developerUnemployed2 = new Unemployed("Jane", "Doe", "jane.doe@example.com", "1234567890", developerResume2);
            Resume developerResume3 = new Resume("Senior Developer with 10 years of experience");
            Unemployed developerUnemployed3 = new Unemployed("Jim", "Beam", "jim.beam@example.com", "1234567890", developerResume3);

            Resume designerResume1 = new Resume("Junior Designer with 1 year of experience");
            Unemployed designerUnemployed1 = new Unemployed("John", "Doe", "john.doe@example.com", "1234567890", designerResume1);
            Resume designerResume2 = new Resume("Middle Designer with 5 years of experience");
            Unemployed designerUnemployed2 = new Unemployed("Jane", "Doe", "jane.doe@example.com", "1234567890", designerResume2);
            Resume designerResume3 = new Resume("Senior Designer with 10 years of experience");
            Unemployed designerUnemployed3 = new Unemployed("Jim", "Beam", "jim.beam@example.com", "1234567890", designerResume3);

            Resume managerResume1 = new Resume("Junior Manager with 1 year of experience");
            Unemployed managerUnemployed1 = new Unemployed("John", "Doe", "john.doe@example.com", "1234567890", managerResume1);
            Resume managerResume2 = new Resume("Middle Manager with 5 years of experience");
            Unemployed managerUnemployed2 = new Unemployed("Jane", "Doe", "jane.doe@example.com", "1234567890", managerResume2);
            Resume managerResume3 = new Resume("Senior Manager with 10 years of experience");
            Unemployed managerUnemployed3 = new Unemployed("Jim", "Beam", "jim.beam@example.com", "1234567890", managerResume3);

            categories.Add(itCategory);
            categories.Add(designCategory);
            categories.Add(managementCategory);

            resumes.Add(developerResume1);
            resumes.Add(developerResume2);
            resumes.Add(developerResume3);
            resumes.Add(designerResume1);
            resumes.Add(designerResume2);
            resumes.Add(designerResume3);
            resumes.Add(managerResume1);
            resumes.Add(managerResume2);
            resumes.Add(managerResume3);

            unemployeds.Add(developerUnemployed1);
            unemployeds.Add(developerUnemployed2);
            unemployeds.Add(developerUnemployed3);
            unemployeds.Add(designerUnemployed1);
            unemployeds.Add(designerUnemployed2);
            unemployeds.Add(designerUnemployed3);
            unemployeds.Add(managerUnemployed1);
            unemployeds.Add(managerUnemployed2);
            unemployeds.Add(managerUnemployed3);

            vacancies.Add(developerVacancy);
            vacancies.Add(designerVacancy);
            vacancies.Add(managerVacancy);
        }
    }

    class Vacancy
    {
        public string Title { get; set; }
        public Category Category { get; private set; }

        public Vacancy(string title, Category category)
        {
            this.Title = title;
            this.Category = category;
        }

        public void Update(string newTitle, Category newCategory)
        {
            this.Title = newTitle;
            this.Category = newCategory;
        }

        public void Get()
        {
            Console.WriteLine($"Vacancy: {this.Title}, Category: {this.Category.Title}");
        }
    }

    class Category
    {
        public string Title { get; set; }

        public Category(string title)
        {
            this.Title = title;
        }
    }

    class Resume
    {
        public string Description { get; set; }

        public Resume(string description)
        {
            this.Description = description;
        }

        public void Update(string newDescription)
        {
            this.Description = newDescription;
        }

        public void Get()
        {
            Console.WriteLine($"Resume: {this.Description}");
        }
    }

    class Unemployed
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Resume Resume { get; set; }

        public Unemployed(string firstName, string lastName, string email, string phone, Resume resume)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Resume = resume;
        }

        public void Update(string newFirstName, string newLastName, string newEmail, string newPhone, Resume newResume)
        {
            this.FirstName = newFirstName;
            this.LastName = newLastName;
            this.Email = newEmail;
            this.Phone = newPhone;
            this.Resume = newResume;
        }

        public void Get()
        {
            Console.WriteLine($"Unemployed: {this.FirstName} {this.LastName}, Email: {this.Email}, Phone: {this.Phone}, Resume: {this.Resume.Description}");
        }

    }

    class Agency
    {
        public string Title { get; set; }
        public Vacancy? Vacancy { get; set; }

        public Agency(string title, Vacancy vacancy)
        {
            this.Title = title;
            this.Vacancy = vacancy;
        }

        public void CreateVacancy(Vacancy vacancy)
        {
            this.Vacancy = vacancy;
        }

        public void DeleteVacancy(Vacancy vacancy)
        {
            this.Vacancy = null;
        }
    }
}

