using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using TP_bibliothèque_numérique.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Répertoire courant : {Directory.GetCurrentDirectory()}");
        var booksJson = File.ReadAllText("books.json");
        List<Book> books = JsonConvert.DeserializeObject<List<Book>>(booksJson);

        var xml = XDocument.Load("members.xml");
        List<Member> members = xml.Descendants("Member").Select(m => new Member
        {
            Id = int.Parse(m.Element("Id").Value),
            Name = m.Element("Name").Value,
            Age = int.Parse(m.Element("Age").Value)
        }).ToList();

        while (true)
        {
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Rechercher des livres par auteur");
            Console.WriteLine("2. Rechercher des membres majeurs");
            Console.WriteLine("3. Trier les livres par date de publication");
            Console.WriteLine("4. Trouver les livres empruntés par des membres majeurs");
            Console.WriteLine("0. Quitter");
            Console.Write("Choisissez une option : ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchBooksByAuthor(books);
                    break;
                case "2":
                    SearchMembersAbove18(members);
                    break;
                case "3":
                    SortBooksByPublishedDate(books);
                    break;
                case "4":
                    FindBooksByAdultMembers(books, members);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Option invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    // Méthode pour rechercher des livres par auteur
    static void SearchBooksByAuthor(List<Book> books)
    {
        Console.Write("Entrez le nom de l'auteur : ");
        string authorName = Console.ReadLine();
        var booksByAuthor = books.Where(b => b.Author.Contains(authorName, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine("\nLivres de " + authorName + " :");
        foreach (var book in booksByAuthor)
        {
            Console.WriteLine($"{book.Title} par {book.Author}");
        }
    }

    // Méthode pour rechercher des membres majeurs
    static void SearchMembersAbove18(List<Member> members)
    {
        var membersAbove18 = members.Where(m => m.Age > 18).ToList();

        Console.WriteLine("\nMembres majeurs :");
        foreach (var member in membersAbove18)
        {
            Console.WriteLine($"{member.Name}, Age: {member.Age}");
        }
    }

    // Méthode pour trier les livres par date de publication
    static void SortBooksByPublishedDate(List<Book> books)
    {
        var sortedBooks = books.OrderBy(b => b.PublishedDate).ToList();

        Console.WriteLine("\nLivres triés par date de publication :");
        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"{book.Title} publié le {book.PublishedDate.ToShortDateString()}");
        }
    }

    // Méthode pour trouver les livres empruntés par des membres majeurs
    static void FindBooksByAdultMembers(List<Book> books, List<Member> members)
    {
        var booksByAdultMembers = from book in books
                                  join member in members on book.MemberId equals member.Id
                                  where member.Age > 18
                                  select new { book.Title, book.Author, MemberName = member.Name };

        Console.WriteLine("\nLivres empruntés par des membres majeurs :");
        foreach (var item in booksByAdultMembers)
        {
            Console.WriteLine($"{item.Title} par {item.Author}, emprunté par {item.MemberName}");
        }
    }
}
