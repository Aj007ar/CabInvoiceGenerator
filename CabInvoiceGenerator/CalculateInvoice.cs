using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CalculateInvoice
    {
        double costPerKm;
        double minmumFare;
        int costPerMin;
        private byte minimumFare;

        public enum RideType
        {
            Premium,Normal
        }
        public CalculateInvoice(RideType rideType)
        {
            if (rideType.Equals(RideType.Normal))
            {
                costPerKm = 10;
                costPerMin = 1;
                minimumFare = 5;
            }
        }
        public double CalculateFare(int time,double distance)
        {
            double totalFare = 0;
            if (distance <= 0)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
            }
            if (time <= 0)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ExceptionType.INVALID_TIME, "Invalid time taken");
            }
            totalFare = distance * costPerKm + time * costPerMin;
            return Math.Max(minimumFare, totalFare);
        }
    }
}
