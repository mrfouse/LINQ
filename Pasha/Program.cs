using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library("Central Library");

        Department fiction = new Department("Fiction");
        Department nonFiction = new Department("Non-Fiction");

        Book book1 = new Book
        {
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            Year = 1960,
            Summary = "A novel about racial injustice in the American South."
        };
        Book book2 = new Book
        {
            Title = "1984",
            Author = "George Orwell",
            Year = 1949,
            Summary = "A dystopian novel about totalitarianism."
        };
        Book book3 = new Book
        {
            Title = "Sapiens: A Brief History of Humankind",
            Author = "Yuval Noah Harari",
            Year = 2011,
            Summary = "A book exploring the history of Homo sapiens."
        };
        Book book4 = new Book
        {
            Title = "The Hitchhiker's Guide to the Galaxy",
            Author = "Douglas Adams",
            Year = 1979,
            Summary = "A comic science fiction series."
        };

        fiction.Editions.Add(book1);
        fiction.Editions.Add(book2);
        nonFiction.Editions.Add(book3);
        fiction.Editions.Add(book4);

        library.Departments.Add(fiction);
        library.Departments.Add(nonFiction);

        Console.WriteLine("Would you like to search the library? (y/n)");
        string response = Console.ReadLine();

        if (response.ToLower() == "y")
        {
            Console.WriteLine("Enter the genre you want to search for:");
            string genre = Console.ReadLine();

            Department department = null;

            foreach (var dept in library.Departments)
            {
                if (dept.Genre.ToLower() == genre.ToLower())
                {
                    department = dept;
                    break;
                }
            }

            if (department != null)
            {
                Console.WriteLine($"Found department for genre: {department.Genre}");
                Console.WriteLine($"Number of editions in this department: {department.NumberOfEditions}");

                foreach (var edition in department.Editions)
                {
                    edition.Describe();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No department found for genre: {genre}");
            }
        }
        else
        {
            Console.WriteLine("Exiting program.");
        }
    }
}

class Library
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; }

    public Library(string name)
    {
        Name = name;
        Departments = new List<Department>();
    }
}

class Department
{
    public string Genre { get; set; }
    public int NumberOfEditions => Editions.Count;
    public List<Edition> Editions { get; set; }

    public Department(string genre)
    {
        Genre = genre;
        Editions = new List<Edition>();
    }
}

class Edition
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public virtual void Describe()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Year: {Year}");
    }
}

class Book : Edition
{
    public string Summary { get; set; }

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine($"Summary: {Summary}");
    }
}
