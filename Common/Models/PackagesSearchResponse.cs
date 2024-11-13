namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesSearchResponse
    {
        public string SearchToken { get; set; }
        public string LanguageCode { get; set; }
        public string Currency { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Flight> Flights { get; set; }
    }

    public class Hotel
    {
        public string Id { get; set; }
        public string ReferenceToken { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }

    public class Room
    {
        public int Adults { get; set; }
        public List<short> Childages { get; set; }
        public List<AvailableOption> AvailableOptions { get; set; }
    }

    public class AvailableOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Board> Boards { get; set; }
    }

    public class Board
    {
        public string ProductToken { get; set; }
        public string BoardCode { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }

    public class Flight
    {
        public string ProductToken { get; set; }
        public List<Leg> Legs { get; set; }
        public Price Prices { get; set; }
    }

    public class Leg
    {
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public int TravelTime { get; set; }
        public bool IsOvernight { get; set; }
        public bool Nonstop { get; set; }
        public string FareClass { get; set; }
        public List<Segment> Segments { get; set; }
        public List<Upgrade> MinimumServices { get; set; }
    }

    public class Segment
    {
        public string Carrier { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int FlightTime { get; set; }
        public string AircraftIataCode { get; set; }
        public List<Upgrade> IncludedServices { get; set; }
    }

    public class Upgrade
    {
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool PerPassenger { get; set; }
        public Weight MaxWeight { get; set; }
        public List<string> AllowedPaxTypes { get; set; }
        public List<int> AllowedPaxAges { get; set; }
    }
}
