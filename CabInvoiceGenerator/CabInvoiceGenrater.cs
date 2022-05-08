using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceGenrater
    {
        public readonly int MINIMUM_FARE;
        public readonly int COST_PER_KM;
        public readonly int COST_PER_MINUTE;

        public CabInvoiceGenrater(RideType rideType)
        {
            if (rideType.Equals(RideType.NORMAL_RIDE))
            {
                MINIMUM_FARE = 5;
                COST_PER_KM = 10;
                COST_PER_MINUTE = 1;
            }
        }

        //UC2 Calculate fare for single ride
        public double CalculateFare(int time,double distance)
        {
            double totalFare = 0;
            try
            {
                if (time <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                if (distance <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");

                //Total Fare for single ride
                totalFare = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
                return Math.Max(totalFare,MINIMUM_FARE);
            }
            catch(CabInvoiceException ex)
            {
                throw ex;
            }
        }

        // UC2 - Method to calculate aggregate fare for multiple rides
        public double CalculateMultipleRides(Ride[] rides)
        {
            double totalFare = 0;
            if (rides.Length == 0)
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "No Rides Found");
            foreach (var ride in rides)
                totalFare += CalculateFare(ride.time, ride.distance);
            double aggregateFare = Math.Max(totalFare, MINIMUM_FARE);
            return aggregateFare;
        }

    }
}
