using System;

class Program
{
    static void Main()
    {
        //Question1
        Console.Write("Provide your age: ");

        int age = int.Parse(Console.ReadLine());

        int presentYear = DateTime.Now.Year;
        int birthYear = presentYear - age;
        Console.WriteLine($"Your year of birth is: {birthYear}");

        //Question 2
        Console.WriteLine("Enter the values for the polynomial:");
        Console.Write("Enter a(int): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter b(int): ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter c(int): ");
        int c = int.Parse(Console.ReadLine());

        Console.Write("Enter x(double): ");
        double x = Convert.ToDouble(Console.ReadLine());

        double expression1 = ((a + b) / 2.0) * Math.Pow(x, 3);
        double expression2 = Math.Pow(a + b, 2) * Math.Pow(x, 2);
        double expression3 = a + b + c;
        double result = expression1 + expression2 + expression3;
        Console.WriteLine($"The Value of polynomial is {result}");

        //Question 3
        Console.Write("Enter x:");
        double var1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y:");
        double var2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Before swapping: x = {var1}, y = {var2}");

        double temp = var1;
        var1 = var2;
        var2 = temp;

        Console.WriteLine($"After swapping: x = {var1}, y = {var2}");

        //Question 4
        Console.WriteLine("How much did you receive money ($)?");
        int receivedAmount = int.Parse(Console.ReadLine());

        double amountBookAndSupplies = receivedAmount * 0.75;
        double remaining = receivedAmount - amountBookAndSupplies;
        double equalDivide = remaining / 3;
        double countCoffee = Math.Floor(equalDivide / 2);
        double countFlashDrive = Math.Floor(equalDivide / 4);
        double countSubwayTicket = Math.Floor(equalDivide / 3);

        double flowerBouquet = receivedAmount - amountBookAndSupplies - (2 * countCoffee) - (4 * countFlashDrive) - (3 * countSubwayTicket);

        Console.WriteLine($"Book and Supplies: {amountBookAndSupplies}$");
        Console.WriteLine($"You can then buy:");
        Console.WriteLine($"{countCoffee} coffees");
        Console.WriteLine($"{countFlashDrive} Flash Computer Numbers");
        Console.WriteLine($"{countSubwayTicket} subway Tickets");
        Console.WriteLine($"and you will have {flowerBouquet} dollars for the white roses.");
    }
}
