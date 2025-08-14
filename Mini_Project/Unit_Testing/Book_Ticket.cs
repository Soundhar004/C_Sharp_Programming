
using NUnit.Framework;
using Moq;
using System;

namespace Railway_Reservation_System.Data_Infrastructure
{
    public class Book_Ticket
    {
        private Mock<ITrainClassTypeData> _mockTrainClass;
        private Mock<IReservationRepository> _mockRepo;
        private BookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            _mockTrainClass = new Mock<ITrainClassTypeData>();
            _mockRepo = new Mock<IReservationRepository>();
            _bookingService = new BookingService(_mockTrainClass.Object, _mockRepo.Object);
        }

        [Test]
        public void TryBookReservation_ShouldReturnTrue_WhenSeatsAreAvailable()
        {
            // Arrange
            var reservation = new Reservation_Access
            {
                TrainId = 101,
                PassengerName = "Alice",
                FromStation = "A",
                ToStation = "B",
                TravelDate = DateTime.Today.AddDays(1),
                SeatNo = 2,
                SeatType = "seater"
            };

            _mockTrainClass.Setup(t => t.GetAvailability(101, "seater"))
                           .Returns(new Availability { AvailableSeats = 5, CostPerSeat = 100 });

            _mockRepo.Setup(r => r.SaveReservation(It.IsAny<Reservation_Access>())).Returns(true);

            // Act
            var result = _bookingService.TryBookReservation(reservation);

            // Assert
            Assert.IsTrue(result);
            _mockTrainClass.Verify(t => t.UpdateAvailableSeats(101, "seater", 2), Times.Once);
        }

        [Test]
        public void TryBookReservation_ShouldReturnFalse_WhenTravelDateIsPast()
        {
            var reservation = new Reservation_Access
            {
                TrainId = 101,
                PassengerName = "Bob",
                FromStation = "X",
                ToStation = "Y",
                TravelDate = DateTime.Today.AddDays(-1),
                SeatNo = 1,
                SeatType = "seater"
            };

            var result = _bookingService.TryBookReservation(reservation);

            Assert.IsFalse(result);
        }

        [Test]
        public void TryBookReservation_ShouldReturnFalse_WhenNoAvailability()
        {
            var reservation = new Reservation_Access
            {
                TrainId = 102,
                PassengerName = "Charlie",
                FromStation = "C",
                ToStation = "D",
                TravelDate = DateTime.Today.AddDays(2),
                SeatNo = 1,
                SeatType = "seater"
            };

            _mockTrainClass.Setup(t => t.GetAvailability(102, "seater")).Returns((Availability)null);

            var result = _bookingService.TryBookReservation(reservation);

            Assert.IsFalse(result);
        }

        [Test]
        public void TryBookReservation_ShouldReturnFalse_WhenNotEnoughSeats()
        {
            var reservation = new Reservation_Access
            {
                TrainId = 103,
                PassengerName = "Dana",
                FromStation = "E",
                ToStation = "F",
                TravelDate = DateTime.Today.AddDays(3),
                SeatNo = 4,
                SeatType = "seater"
            };

            _mockTrainClass.Setup(t => t.GetAvailability(103, "seater"))
                           .Returns(new Availability { AvailableSeats = 2, CostPerSeat = 150 });

            var result = _bookingService.TryBookReservation(reservation);

            Assert.IsFalse(result);
        }
    }
}
