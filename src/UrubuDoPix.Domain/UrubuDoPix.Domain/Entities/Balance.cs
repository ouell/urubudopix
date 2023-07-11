using UrubuDoPix.Domain.Entities.Base;

namespace UrubuDoPix.Domain.Entities;

public class Balance
{
    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }

    public Balance(decimal initialAmount)
    {
        Amount = initialAmount;
    }

    public void Increase(decimal amount)
    {
        Amount += amount;
    }

    public void Decrease(decimal amount)
    {
        if (amount > Amount)
        {
            throw new InvalidOperationException("Insufficient balance");
        }

        Amount -= amount;
    }
}