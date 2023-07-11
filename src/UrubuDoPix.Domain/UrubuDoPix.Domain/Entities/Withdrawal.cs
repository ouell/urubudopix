using UrubuDoPix.Domain.Enum;

namespace UrubuDoPix.Domain.Entities;

public class Withdrawal : Transaction
{
    public Withdrawal(decimal amount) : base(amount)
    {
    }

    public override void Execute(User user)
    {
        var amountToWithdraw = CurrentAmount;

        foreach (var deposit in user.Transactions.OfType<Deposit>().Where(d => d.IsActive).OrderBy(d => d.Id))
        {
            if (deposit.CurrentAmount >= amountToWithdraw)
            {
                deposit.Deactivate();
                user.Balance.Decrease(amountToWithdraw);
                var residual = deposit.CurrentAmount - amountToWithdraw;
                if (residual > 0)
                {
                    var residualDeposit = new Deposit(residual, DepositType.Residual);
                    residualDeposit.Execute(user);
                    user.Transactions.Add(residualDeposit);
                }
                return;
            }
            else
            {
                amountToWithdraw -= deposit.CurrentAmount;
                deposit.Deactivate();
                user.Balance.Decrease(deposit.CurrentAmount);
            }
        }

        throw new InvalidOperationException("Insufficient balance");
    }
}