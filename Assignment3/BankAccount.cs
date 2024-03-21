using System;
//Author : Pranjal(895284)
public class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private string type;

    //constructor for checking account
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
        this.type = "Checking";
    }

    // Constructor for saving account
    public BankAccount(string accountNumber, decimal initialBalance, string type)
    {
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
        this.type = type;
    }

    // Method to Deposit money into the account
    public void Deposit(decimal amount)
    {
        balance = balance + amount;
        Console.WriteLine($"You have deposited {amount} and your new balance is : {balance}");
    }

    //Method to Withdraw money from the account
    public void Withdraw(decimal amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
            Console.WriteLine($"You have withdrawn {amount} and Your new balance is : {balance}");
        }
        else
        {
            Console.WriteLine("Funds are insufficient");
        }
    }

    // overloading Deposit method
    public void Deposit(decimal amount, string category)
    {
        Deposit(amount);
        Console.WriteLine($"Category: {category}");
    }

    // Overloading Withdraw method
    public void Withdraw(decimal amount, string category)
    {
        Withdraw(amount);
        Console.WriteLine($"Category: {category}");
    }

    //getter for balance
    public decimal GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        // Checking Account
        BankAccount checkingAccount = new BankAccount("123456789", 1000);//new object
        Console.WriteLine("A new Checking Account is created.");

        // Invoking deposit and withdraw methods
        checkingAccount.Deposit(100);
        checkingAccount.Withdraw(10);

        // invoking the constructor for Savings account
        BankAccount savingsAccount = new BankAccount("234567890", 2000, "Savings");//new object
        Console.WriteLine("\nA new Savings Account is created.");

        // Invoking overloaded deposit and withdraw ethods
        savingsAccount.Deposit(1000, "CDM Machine");
        savingsAccount.Withdraw(500, "Debit Card");

        //invoking the getter methods for both the objects
        Console.WriteLine("\nBalance of Checking Account: " + checkingAccount.GetBalance());
        Console.WriteLine("Balance of Savings Account" + savingsAccount.GetBalance());
    }
}
