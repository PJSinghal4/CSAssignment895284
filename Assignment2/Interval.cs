
class Interval
{
    static void Main()
    {   //infinte loop so that we prompt user again and again until he types exit
        while (true)
        {
            Console.WriteLine("Enter a real number (or type 'exit' to quit): ");

            string userInput = Console.ReadLine();

            if (userInput == "exit")
            {//to break the loop
                break;
            }
            //double input conversion
            double x = Convert.ToDouble(userInput);

            // Defining intervals using bool
            bool interval1 = x >= 2 && x < 3;
            bool interval2 = x > 0 && x <= 1;
            bool interval3 = x >= -10 && x <= -2;

            //using it as flag
            bool inI = (interval1 || interval2) || interval3;

            if (inI)
            {
                Console.WriteLine($"x belongs to I");
            }
            else
            {
                Console.WriteLine($"x does not belong to I");
            }
        }

    }
}

