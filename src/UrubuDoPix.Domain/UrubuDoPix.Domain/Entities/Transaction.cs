using UrubuDoPix.Domain.Entities.Base;

namespace UrubuDoPix.Domain.Entities;

public abstract class Transaction : Entity
{
    public decimal InitialAmount { get; protected set; }
    public decimal CurrentAmount { get; protected set; }
    public int UserId { get; private set; }
    public User User { get; private set; }

    protected Transaction(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive");
        }

        InitialAmount = amount;
        CurrentAmount = amount;
    }

    public abstract void Execute(User user);
}
