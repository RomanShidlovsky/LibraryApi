namespace Domain.Common;

public interface INamedEntity : IBaseEntity
{
    public string Name { get; set; }
}