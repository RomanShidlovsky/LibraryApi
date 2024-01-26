using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Commands.ReturnBook;

public sealed record ReturnBookCommand(int BookId) : IRequest<Response>;
