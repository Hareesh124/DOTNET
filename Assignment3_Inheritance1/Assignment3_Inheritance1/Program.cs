using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Inheritance1
{
    internal class Program
    {
        /*  1. Create a class called Accounts which has data members/fields like 
         *  Account no, Customer name, Account type, Transaction type (d/w), amount, balance
            D->Deposit
            W->Withdrawal

        -write a function that updates the balance depending upon the transaction type

	    -If transaction type is deposit call the function credit by 
        passing the amount to be deposited and update the balance

     function  Credit(int amount) 

	    -If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance

     Debit(int amt) function 

        -Pass the other information like Acount no, customer name, acc type through constructor

        -write and call the show data method to display the values.  */
        class accounts
        {
            int accno, amt, bal;
            string name, atype, ttype;

        }
        static void Main(string[] args)
        {

        }
    }
}
