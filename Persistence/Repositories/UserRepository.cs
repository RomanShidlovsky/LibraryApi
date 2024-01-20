using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserRepository(DataContext context) : BaseRepository<User>(context), IUserRepository;