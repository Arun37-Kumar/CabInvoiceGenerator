using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public int time;
        public double distance;

        /// <summary>
        /// Creating the parameterized Constructor of Ride Class
        /// </summary>
        /// <param name="time"></param>
        /// <param name="distance"></param>
        public Ride(int time, double distance)
        {
            this.time = time;
            this.distance = distance;
        }
    }
}
