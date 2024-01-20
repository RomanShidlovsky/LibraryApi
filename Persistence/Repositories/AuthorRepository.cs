using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class AuthorRepository(DataContext context) : BaseRepository<Author>(context), IAuthorRepository;