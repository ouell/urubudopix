using UrubuDoPix.Domain.Entities.Base;

namespace UrubuDoPix.Domain.Entities;

public class User : Entity
{
    public string Name { get; protected set; }
    public string LastName { get; protected set; }
    public string Cpf { get; protected set; }
    public bool Active { get; protected set; } = false;
    public DateTime? InactivatedAt { get; protected set; }

    public User(string name, string lastName, string cpf)
    {
        Name = name;
        LastName = lastName;
        Cpf = cpf;
    }

    public void Activate()
    {
        Active = true;
    }

    public void Inactivate()
    {
        Active = false;
        InactivatedAt = DateTime.Now;
    }
}