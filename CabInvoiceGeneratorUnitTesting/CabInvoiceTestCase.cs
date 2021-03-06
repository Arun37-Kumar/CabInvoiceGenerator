using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorUnitTesting
{
    [TestClass]
    public class CabInvoiceTestCase
    {
        public CabInvoiceGenrater generateNormalFare;

        [TestInitialize]
        public void SetUp()
        {
            generateNormalFare = new CabInvoiceGenrater(RideType.NORMAL_RIDE);
        }

        // TC1.1 Positive Testcase
        [TestMethod]
        [TestCategory("Calculate Fare")]
        [DataRow(1, 1.0, 11)]
        [DataRow(10, 15, 160)]
        public void GivenDistanceAndTimeReturnTotalFare(int time, double distance, double expected)
        {
            double actual = generateNormalFare.CalculateFare(time, distance);
            Assert.AreEqual(actual, expected);
        }

        // TC 1.2 Given Invalid Time And Distance Return Custom Exception
        [TestMethod]
        [TestCategory("Calculate Fare")]
        public void GivenInvalidTimeAndDistanceReturnCustomException()
        {
            var invalidTimeException = Assert.ThrowsException<CabInvoiceException>(() => generateNormalFare.CalculateFare(0, 5));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_TIME, invalidTimeException.exceptionType);
            var invalidDistanceException = Assert.ThrowsException<CabInvoiceException>(() => generateNormalFare.CalculateFare(12, -1));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_DISTANCE, invalidDistanceException.exceptionType);
        }

        // TC2.1 - Given multiple rides should return aggregate fare
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenMultipleRidesReturnAggregateFare()
        {
            //Arrange
            double actual, expected = 320;
            Ride[] cabRides = { new Ride(10, 15), new Ride(10, 15) };
            //Act
            actual = generateNormalFare.CalculateMultipleRides(cabRides);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        // TC2.2 - given no rides return custom exception
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenNoRidesReturnCustomException()
        {
            Ride[] cabRides = { };
            var nullRidesException = Assert.ThrowsException<CabInvoiceException>(() => generateNormalFare.CalculateMultipleRides(cabRides));
            Assert.AreEqual(CabInvoiceException.ExceptionType.NULL_RIDES, nullRidesException.exceptionType);
        }
    }
}
