using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Models;
using System.Diagnostics.Metrics;

namespace Bookstore_WebAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Author.Any())
            {
                SeedAuthors();
            }

            if (!dataContext.Users.Any())
            {
                SeedUsers();
            }

            if (!dataContext.Items.Any())
            {
                SeedItems();
            }

            if (!dataContext.Publishers.Any())
            {
                SeedPublishers();
            }

            if (!dataContext.Translators.Any())
            {
                SeedTranslators();
            }

            if (!dataContext.Genres.Any())
            {
                SeedGenres();
            }

            if (!dataContext.Books.Any())
            {
                SeedBooks();
            }
            dataContext.SaveChanges();
        }
        public void SeedAuthors()
        {
            var authors = new List<Author>
    {
        new Author { FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Biography = Faker.Lorem.Paragraph() },
        new Author { FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Biography = Faker.Lorem.Paragraph() },
        // Add more authors as needed
    };
            dataContext.Author.AddRange(authors);
        }

        public void SeedUsers()
        {
            var users = new List<User>
    {
        new User { Email = Faker.Internet.Email(), PasswordHash = "hashedpassword", FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Phone = Faker.Phone.Number() },
        new User { Email = Faker.Internet.Email(), PasswordHash = "hashedpassword", FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Phone = Faker.Phone.Number() },
        // Add more users as needed
    };
            dataContext.Users.AddRange(users);
        }

        public void SeedItems()
        {
            var items = new List<Item>
    {
        new Item { Name = Faker.Company.Name(), Description = Faker.Lorem.Sentence(), Price = Faker.RandomNumber.Next(150, 1000) },
        new Item { Name = Faker.Company.Name(), Description = Faker.Lorem.Sentence(), Price = Faker.RandomNumber.Next(150, 1000) },
        // Add more items as needed
    };
            dataContext.Items.AddRange(items);
        }

        public void SeedPublishers()
        {
            var publishers = new List<Publisher>
    {
        new Publisher { Name = Faker.Company.Name(), Address = Faker.Address.StreetAddress(), ContactInfo = Faker.Phone.Number() },
        new Publisher { Name = Faker.Company.Name(), Address = Faker.Address.StreetAddress(), ContactInfo = Faker.Phone.Number() },
        // Add more publishers as needed
    };
            dataContext.Publishers.AddRange(publishers);
        }

        public void SeedTranslators()
        {
            var translators = new List<Translator>
    {
        new Translator { FirstName = Faker.Name.First(), LastName = Faker.Name.Last() },
        new Translator { FirstName = Faker.Name.First(), LastName = Faker.Name.Last() },
        // Add more translators as needed
    };
            dataContext.Translators.AddRange(translators);
        }

        public void SeedGenres()
        {
            var genres = new List<Genre>
    {
        new Genre { Id = 1, Name = "Mystery" },
        new Genre { Id = 2, Name = "Science Fiction" },
        // Add more genres as needed
    };
            dataContext.Genres.AddRange(genres);
        }

        public void SeedBooks()
        {
            var books = new List<Book>
    {
        new Book
        {
            GenreId = 1,
            Rating = Faker.RandomNumber.Next(1,5),
            PublicationYear = Faker.RandomNumber.Next(1964,1999),
            PublisherId = 1,
            TranslatorId = 1,
            Language = "eng",
            Pages = Faker.RandomNumber.Next(200, 600)
        },
        new Book
        {
            GenreId = 2,
            Rating = Faker.RandomNumber.Next(1, 5),
            PublicationYear = Faker.RandomNumber.Next(2000,2023),
            PublisherId = 2,
            TranslatorId = 2,
            Language = "eng",
            Pages = Faker.RandomNumber.Next(200, 600)
        },
        // Add more books as needed
    };
            dataContext.Books.AddRange(books);
        }

    }
}

