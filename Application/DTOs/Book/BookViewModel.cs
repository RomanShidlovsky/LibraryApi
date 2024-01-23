using Application.DTOs.Author;
using Application.DTOs.Genre;
using Application.DTOs.Subscription;

namespace Application.DTOs.Book;

public sealed record BookViewModel(
    int Id,
    string ISBN,
    string Title,
    string? Description,
    List<AuthorViewModel> Authors,
    List<GenreViewModel> Genres,
    SubscriptionViewModel? LastSubscription);