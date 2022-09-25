using CabInvoiceGenerator;
using System.Linq.Expressions;

namespace CabInvoiceTests
{
    public class Tests
    {
        //Calculate Normal Fare
        [Test]
        public void CalculateTotalNormalFare()
        {
            CalculateInvoice calculateInvoice = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            double distance = 5;
            int time = 20;
            double actualFare = calculateInvoice.CalculateFare(time, distance);
            double expectedFare = 70.00;
            Assert.AreEqual(expectedFare, actualFare);
        }
        //Test for Invalid distance
        [Test]
        public void InvalidDistanceTest()
        {
            try
            {
                CalculateInvoice calculateInvoice = new CalculateInvoice(CalculateInvoice.RideType.Normal);
                double distance = 0;
                int time = 20;
                calculateInvoice.CalculateFare(time, distance);
            }catch(InvoiceCustomException ex)
            {
                string expected = "Invalid distance";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //Test for invalid time
        [Test]
        public void InvalidTimeTest()
        {
            try
            {
                CalculateInvoice calculateInvoice = new CalculateInvoice(CalculateInvoice.RideType.Normal);
                double distance = 20;
                int time = 0;
                calculateInvoice.CalculateFare(time, distance);
            }catch(InvoiceCustomException ex)
            {
                string expected = "Invalid time taken";
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}