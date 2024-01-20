using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class RoleRepository(DataContext context) : BaseRepository<Role>(context), IRoleRepository;