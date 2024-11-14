using Cmp.Services.Accommodation.V2;
using Cmp.Services.Transport.V2;

namespace GPRSClient.Models
{
    public class PackagesSearchResponse
    {
        public List<AccommodationSearchResult> Hotels { get; set; }
        public List<TransportSearchResult> Flights { get; set; }
        public List<Packages> Packages { get; set; } = new List<Packages>();
    }

    public class Packages
    {
        public Guid Id { get; set; }
        public int Hotelid { get; set; }
        public int FlightId { get; set; }
    }

}
