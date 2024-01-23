namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public int Id { get; init; }
    public Type? EntityType { get; init; }

    public NotFoundException(string message, Type? entityType = null) : base(message)
    {
        EntityType = entityType;
    }

    public NotFoundException(int id, Type entityType) : base($"Entity {entityType.Name} with id: {id} not found.")
    {
        Id = id;
        EntityType = entityType;
    }
}