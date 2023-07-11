using UrubuDoPix.Domain.Entities.Base;
using UrubuDoPix.Domain.Enum;

namespace UrubuDoPix.Domain.Entities;

public class Deposit : Transaction
{
    public bool IsActive { get; private set; }
    public DepositType Type { get; private set; }

    public Deposit(decimal amount, DepositType type = DepositType.Regular) : base(amount)
    {
        IsActive = true;
        Type = type;
    }

    public override void Execute(User user)
    {
        user.Balance.Increase(CurrentAmount);
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void ApplyInterest(decimal percentage)
    {
        CurrentAmount += CurrentAmount * (percentage / 100);
    }
}