using Domain.Entities;

namespace Persistence.Seed;

public static class SeedData
{
    public static List<Genre> Genres =>
    [
        new Genre { Id = 1, Name = "Science Fiction" },
        new Genre { Id = 2, Name = "Mystery" },
        new Genre { Id = 3, Name = "Fantasy" },
        new Genre { Id = 4, Name = "Romance" },
        new Genre { Id = 5, Name = "Thriller" }
    ];

    public static List<Author> Authors =>
    [
        new Author { Id = 1, FirstName = "Isaac", LastName = "Asimov", FullName = "Isaac Asimov" },
        new Author { Id = 2, FirstName = "Agatha", LastName = "Christie", FullName = "Agatha Christie" }
    ];

    public static List<Book> Books =>
    [
        new Book
        {
            Id = 1,
            ISBN = "1234567890",
            Title = "Foundation",
            Description = "A classic science fiction novel.",
        },
        new Book
        {
            Id = 2,
            ISBN = "0987654321",
            Title = "Murder on the Orient Express",
            Description = "A famous mystery novel.",
        }
    ];
    
    public static List<Subscription> Subscriptions =>
    [
        new Subscription
        {
            BookId = 1,
            UserId = 1,
            TakenAt = DateTime.UtcNow.AddDays(-7),
            ShouldReturnAt = DateTime.UtcNow.AddDays(14),
            IsActive = false
        },
        new Subscription
        {
            BookId = 2,
            UserId = 1,
            TakenAt = DateTime.UtcNow.AddDays(-10),
            ShouldReturnAt = DateTime.UtcNow.AddDays(21),
            IsActive = true
        },
    ];
}