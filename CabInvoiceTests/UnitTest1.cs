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
        //UC2 Test for aggregate for normal Ride
        [Test]
        public void TestAggrigateNormalRide()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            Ride[] ride =
            {
                new Ride(3, 5.0),
                new Ride(6,7.0)
            };
            double actual = calculate.CalculateAggregateFare(ride);
            double expected = 129;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestMethodToCheckInvoiceSummayForPremiumRides()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            string actual = calculate.InvoiceSummary(ride);
            string expected = "\nNo of rides: 2 \nTotal Fare: 198 \nAverage Fare: 99";
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void SearchForInvalidUserID()
        {
            RideRepository ride = new RideRepository();
            Ride[] rides123 = { new Ride(3, 5.0), new Ride(6, 7.0) };
            Ride[] rides124 = { new Ride(4, 6.0), new Ride(7, 8.0) };
            ride.AddToDictionary("123", rides123);
            ride.AddToDictionary("124", rides124);
            string actual = ride.Search("125");
            string expected = "Not found";
            Assert.AreEqual(actual, expected);

        }
        [Test]
        public void CalculateTotalFareForPremiumRide()
        {
            CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
            double distance = 4.8;
            int time = 20;
            double fare = cabInvoiceCalculate.CalculateFare(time, distance);
            double expected = 112.0;
            Assert.AreEqual(expected, fare);

        }
        [Test]
        public void InvalidDistanceCalculateTotalFareForPremiumRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
                double distance = 0;
                int time = 12;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Invalid distance";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [Test]
        public void InvalidTimeCalculateTotalFareForPremiumRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
                double distance = 12;
                int time = 0;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Invalid time taken";
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}