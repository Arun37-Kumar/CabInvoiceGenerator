using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator!");
            CabInvoiceGenerater fare = new CabInvoiceGenerater(RideType.NORMAL_RIDE);
            double result = fare.CalculateFare(10,20);
            Console.WriteLine("Fare is : " + result);
            Console.ReadLine();
        }
    }
}
