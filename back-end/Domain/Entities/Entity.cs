namespace Domain.Entities;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
    public DateTime CreateDate { get; protected set; }
    public DateTime UpdateDate { get; protected set; }
}