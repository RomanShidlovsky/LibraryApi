using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class GenreRepository(DataContext context) : BaseRepository<Genre>(context), IGenreRepository;