using App.Entities;
using App.Entities.Exceptions;
using System.Globalization;

namespace App // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine()!);
                Console.Write("Holder: ");
                string holder = Console.ReadLine()!;
                Console.Write("Initial Balance: ");
                double initialBalance = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                Console.Write("Withdraw Limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                Account account = new(number, holder, initialBalance, withdrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                account.WithDraw(amount);
                Console.WriteLine("New balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainException error)
            {
                Console.WriteLine("Withdraw error: " + error.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine("Unexpected error: " + error.Message);
            }
        }
    }
}