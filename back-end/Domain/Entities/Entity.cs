namespace Domain.Entities;

public class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreationDate { get; protected set; }
    public DateTime UpdateDate { get; protected set; }
}