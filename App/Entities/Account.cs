using App.Entities.Exceptions;

namespace App.Entities
{
    internal class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; } = string.Empty;
        public double Balance { get; private set; }
        public double WithDrawLimit { get; private set; }

        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if (amount > WithDrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if (Balance == 0 || amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }

            Balance -= amount;
        }
    }
}
