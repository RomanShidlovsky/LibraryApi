namespace Application.Exceptions;

public class NotFoundException(int id, Type entityType)
    : Exception($"Entity {entityType.Name} with id: {id} not found.")
{
    public int Id { get; init; } = id;
    public Type EntityType { get; init; } = entityType;
}