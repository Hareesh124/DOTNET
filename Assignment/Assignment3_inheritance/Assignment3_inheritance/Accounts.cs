using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_inheritance
{
    class Accounts
    {
        public int AccountNo { get;  set; }
        public string CustomerName { get;  set; }
        public string AccountType { get;  set; }
        public string TransactionType { get;  set; }
        public int Balance { get;  set; }

        public Accounts(int accountNo, string customerName, string accountType, int initialBalance)
        {
            AccountNo = accountNo;
            CustomerName = customerName;
            AccountType = accountType;
            Balance = initialBalance;
        }

        public void Credit(int amount)
        {
            Balance += amount;
            Console.WriteLine("Amount Deposited: " + amount);
        }

        public void Debit(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Amount Withdrawn: " + amount);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void UpdateBalance(string transactionType, int amount)
        {
            TransactionType = transactionType;
            if (transactionType == "D")
            {
                Credit(amount);
            }
            else if (transactionType == "W")
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type");
            }
        }

        public void ShowData()
        {
            Console.WriteLine("Account No: " + AccountNo);
            Console.WriteLine("Customer Name: " + CustomerName);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Balance: " + Balance);
        }

        static void Main()
        {
            Console.Write("Enter Account Number: ");
            int accountNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Account Type (e.g., Savings, Current): ");
            string accountType = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            int initialBalance = int.Parse(Console.ReadLine());

            Accounts account = new Accounts(accountNo, customerName, accountType, initialBalance);

            Console.Write("Enter Transaction Type (D for Deposit, W for Withdrawal): ");
            string transactionType = Console.ReadLine().ToUpper();

            Console.Write("Enter Amount: ");
            int amount = int.Parse(Console.ReadLine());

            account.UpdateBalance(transactionType, amount);

            account.ShowData();
            Console.Read();
        }
    }

}
