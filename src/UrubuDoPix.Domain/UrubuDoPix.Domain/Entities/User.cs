using UrubuDoPix.Domain.Entities.Base;

namespace UrubuDoPix.Domain.Entities;

public class User : Entity
{
    public string Name { get; protected set; }
    public string LastName { get; protected set; }
    public string Cpf { get; protected set; }
    public string Email { get; private set; }
    public bool IsActive { get; protected set; }
    public DateTime? InactivatedAt { get; protected set; }
    
    public Balance Balance { get; private set; }
    public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
        InactivatedAt = DateTime.Now;
    }
    
    public User(string name, string lastName, string cpf, string email, decimal initialBalance)
    {
        Cpf = cpf;
        Name = name;
        Email = email;
        LastName = lastName;
        Balance = new Balance(initialBalance);
    }

    public void AddTransaction(Transaction transaction)
    {
        transaction.Execute(this);
        Transactions.Add(transaction);
    }

    public void ApplyDailyInterest(decimal interest)
    {
        foreach (var deposit in Transactions.OfType<Deposit>().Where(d => d.IsActive))
        {
            deposit.ApplyInterest(interest);
        }
    }
}