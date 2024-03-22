//Author: Pranjal(C0895284)
using System;

public class Circle
{
    public double Radius { get; set; }
    public double XCoor { get; set; }
    public double YCoor { get; set; }

    //Constructor Circle
    public Circle(double radius, double x, double y)
    {
        Radius = radius;
        XCoor = x;
        YCoor = y;
    }

    //Function to calculate the  Area of the Circle using basic Math functions and Math.Pi
    public double SurfaceAreaCalculation()
    {
        return Math.PI * Radius * Radius;
    }

    //Function to calculate the  Perimeter of the Circle using basic Math functions and Math.Pi
    public double PerimeterCalculation()
    {
        return 2 * Math.PI * Radius;
    }

    //Function which checks if the point is inside the circle
    public bool FlagPointInside(double X, double Y)
    {
        double checkDistance = Math.Sqrt(Math.Pow(X - XCoor, 2) + Math.Pow(Y - YCoor, 2));
        return checkDistance <= Radius;
    }
}


public class Program
{
    //Main function
    public static void Main()
    {
        Console.WriteLine("Enter the number of circles to be created:");
        int circlesNumber = int.Parse(Console.ReadLine());

        Circle[] circles = CircleLoopCreate(circlesNumber);

        DisplayCircle(circles);

        Console.WriteLine("Enter a coordinate/point (x y) to check if it's inside each circle:");
        double X = double.Parse(Console.ReadLine());
        double Y = double.Parse(Console.ReadLine());

        InsideCircleCheckPoints(circles, X, Y);
    }

    //Using loops to prompt for the radius and coordinates of the circle
    public static Circle[] CircleLoopCreate(int count)
    {
        Circle[] circlesArray = new Circle[count];//array of circles
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Enter the radius for circle {i + 1}:");
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the X point for circle {i + 1}:");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the Y point for circle {i + 1}:");
            double y = double.Parse(Console.ReadLine());

            circlesArray[i] = new Circle(radius, x, y);
        }
        return circlesArray;
    }

    //function to display if the point is inside the circle
    public static void InsideCircleCheckPoints(Circle[] circles, double X, double Y)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            bool isInside = circles[i].FlagPointInside(X, Y);
            Console.WriteLine($"Point ({X}, {Y}) {(isInside ? "is" : "is not")} inside Circle {i + 1}.");
        }
    }

    //Displays the circle with the given radius
    public static void DisplayCircle(Circle[] circles)
    {
        foreach (var circle in circles)
        {
            Console.WriteLine($"Circle with radius {circle.Radius}:");
            Console.WriteLine($"Area: {circle.SurfaceAreaCalculation()}");
            Console.WriteLine($"Perimeter: {circle.PerimeterCalculation():F2}");
            Console.WriteLine();
        }
    }

}
