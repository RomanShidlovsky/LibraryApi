using Application.Interfaces.Commands;

namespace Application.Features.SubscriptionFeatures.Commands.ReturnBook;

public sealed record ReturnBookCommand(int BookId) : IUpdateCommand<bool>;
