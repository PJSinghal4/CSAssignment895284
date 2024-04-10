//Author : Pranjal - 895284
using System;

namespace Post
{// first class mail inherited by other classe
    abstract class Mail
    {// protected variables
        protected double weight;
        protected bool method;
        protected string dest;

        protected Mail(double weight, bool method, string dest)
        {
            this.weight = weight;
            this.method = method;
            this.dest = dest;
        }
        // all methods are abstraact
        public abstract double Calculate();
        //calculating postage according to the class that inherits this
        public virtual bool IsValid()
        {
            return !string.IsNullOrEmpty(dest);
        }
        // display invalid courier
        public virtual void Output()
        {
            Console.WriteLine("invalid courier");
        }
    }
    // class Letter implements Mail
    class Letter : Mail
    {//fomat is new here
        private string format;

        public Letter(double weight, bool method, string dest, string format)
            : base(weight, method, dest)
        {
            this.format = format;
        }
        //calculate postage here
        public override double Calculate()
        {//according to format
            double baseFare = format == "A3" ? 3.50 : 2.50;
            double postage = method ? baseFare * 2 : baseFare;
            return postage + weight / 1000.0;
        }
        //display mehtod
        public override void Output()
        {
            Console.WriteLine("Letter");
            Console.WriteLine($"Weight: {weight} grams");
            Console.WriteLine($"Express: {(method ? "yes" : "no")}");
            Console.WriteLine($"Destination: {(IsValid() ? dest : "")}");
            Console.WriteLine($"Price: ${Calculate()}");
            Console.WriteLine($"Format: {format}");
        }
    }
    //class Parcel extends Mail
    class Parcel : Mail
    {//new addition volume
        private double volume;
        //constructor
        public Parcel(double weight, bool method, string dest, double volume)
            : base(weight, method, dest)
        {
            this.volume = volume;
        }
        //calculating postage here
        public override double Calculate()
        {//according to volume
            double postage = (0.25 * volume) + (weight / 1000.0);
            return method ? postage * 2 : postage;
        }

        //checking valid
        public override bool IsValid()
        {
            return base.IsValid() && volume <= 50;
        }

        //display method for Parcel
        public override void Output()
        {
            Console.WriteLine("Parcel");
            Console.WriteLine($"Weight: {weight} grams");
            Console.WriteLine($"Express: {(method ? "yes" : "no")}");
            Console.WriteLine($"Destination: {(IsValid() ? dest : "")}");
            Console.WriteLine($"Price: ${Calculate()}");
            Console.WriteLine($"Volume: {volume} liters");
        }
    }

    //class Advertisement extends Mail
    class Advertisement : Mail
    {
        //constructorr
        public Advertisement(double weight, bool method, string dest)
            : base(weight, method, dest)
        {
        }
        //calcluating postage here
        public override double Calculate()
        {//according to weight
            double postage = 5 * (weight / 1000.0);
            return method ? postage * 2 : postage;
        }

        //display methodd
        public override void Output()
        {
            Console.WriteLine("Advertisement");
            Console.WriteLine($"Weight: {weight} grams");
            Console.WriteLine($"Express: {(method ? "yes" : "no")}");
            Console.WriteLine($"Destination: {(IsValid() ? dest : "")}");
            Console.WriteLine($"Price: ${Calculate()}");
        }
    }


    class Box
    {

        private Mail[] mails;
        private int c;
        private int maxSize;

        //box here constructor
        public Box(int maxSize)
        {
            this.maxSize = maxSize;
            mails = new Mail[maxSize];
            c = 0;
        }

        public void AddMail(Mail mail)
        {
            if (c < maxSize)
            {
                mails[c++] = mail;
            }
        }
        //. a stamp() method allowing to associate to each mail of the box
        public double Stamp()
        {//using for each loop here
            double t = 0;
            foreach (Mail mail in mails)
            {
                if (mail != null)
                {//addinng all the postage chargers
                    t += mail.Calculate();
                }
            }
            return t;
        }
        // display() method displaying the contents of the mailbox 

        public void Display()
        {//for each loop here
            foreach (Mail mail in mails)
            {
                if (mail != null)
                {
                    mail.Output();
                    if (!mail.IsValid())
                    {// display invalid courier

                        Console.WriteLine("(invalid courier)");
                    }
                }
            }
        }
        //invalidMails() calculating and returning the number of invalid mails 
        public int MailIsInvalid()
        {//checking invalid count
            int iC = 0;
            foreach (Mail mail in mails)
            {
                if (mail != null && !mail.IsValid())
                {
                    iC++;
                }
            }
            return iC;
        }
    }
    //main class
    class Program
    {// this is the driver program that is responsible for running the code
        public static void Main(string[] args)
        {

            Box box = new Box(30);

            Letter l1 = new Letter(150, true, "123 Main Street, Anytown, USA", "A4");
            Letter l2 = new Letter(600, false, "456 Elm Street, Somewhere, USA", "A5");

            Advertisement a1 = new Advertisement(2000, true, "789 Oak Avenue, Anytown, USA");
            Advertisement a2 = new Advertisement(3500, false, "101 Pine Street, Elsewhere, USA");

            Parcel p1 = new Parcel(4000, true, "321 Maple Lane, Anytown, USA", 25);
            Parcel p2 = new Parcel(2500, false, "555 Cedar Street, Somewhere, USA", 60);


            box.AddMail(l1);
            box.AddMail(l2);
            box.AddMail(a1);
            box.AddMail(a2);
            box.AddMail(p1);
            box.AddMail(p2);

            Console.WriteLine("otal postage is " + box.Stamp());
            box.Display();
            Console.WriteLine(" box contains " + box.MailIsInvalid() + " invalid mails");
        }
    }
}
