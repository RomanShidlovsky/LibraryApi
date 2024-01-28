using System.Reflection;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Seed;

namespace Persistence.Context;

public class DataContext(
    DbContextOptions<DataContext> options,
    IServiceProvider serviceProvider) 
    : IdentityDbContext<User, Role, int>(options)
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        AddSeedData(modelBuilder);
    }

    private async void AddSeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(SeedData.Genres);
        modelBuilder.Entity<Author>().HasData(SeedData.Authors);
        modelBuilder.Entity<Book>().HasData(SeedData.Books);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity(j =>
                j.HasData([
                    new { AuthorsId = 1, BooksId = 1 },
                    new { AuthorsId = 2, BooksId = 2 }
                ]));

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity(j =>
                j.HasData([
                    new { GenresId = 1, BooksId = 1 },
                    new { GenresId = 2, BooksId = 2 },
                    new { GenresId = 3, BooksId = 2 }
                ]));
    }
}