using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator!");
            CabInvoiceGenrater fare = new CabInvoiceGenrater(RideType.NORMAL_RIDE);
            double result = fare.CalculateFare(10,20);
            Console.WriteLine("Fare is : " + result);

            Ride[] multiRides = { new Ride(10, 15), new Ride(10, 15) };
            double res = fare.CalculateMultipleRides(multiRides);
            Console.WriteLine("The result for multiple ride : "+res);
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
