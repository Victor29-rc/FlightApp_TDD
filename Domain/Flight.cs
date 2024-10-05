
namespace Domain
{
    public class Flight
    {
        List<Booking> _bookingsLists = new();
        public IEnumerable<Booking> BookingList => _bookingsLists;
        public int RemainingNumbersOfSeats { get; set; }
        public Flight(int seatCapacity)
        {
            RemainingNumbersOfSeats = seatCapacity;
        }

        public object? Book(string passengerEmail, int numberOfSeats)
        {
            if (RemainingNumbersOfSeats - numberOfSeats < 0) 
            { 
                return new OverbookingError();
            }

            RemainingNumbersOfSeats -= numberOfSeats;

            _bookingsLists.Add(new Booking(passengerEmail, numberOfSeats));

            return null;
        }

        public object? CancelBooking(string passengerEmail, int numberOfSeats)
        {
            if(!_bookingsLists.Any(booking => booking.Email == passengerEmail))
                return new BookingNotFoundError();
            
            RemainingNumbersOfSeats += numberOfSeats;

            return null;
        }
    }
}
