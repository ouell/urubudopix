namespace UrubuDoPix.Domain.Entities.Base;

public abstract class Entity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
}