using Cmp.Services.Accommodation.V2;

namespace GPRSClient.Models
{
    public class PackagesSearchRequest
    {
        public SearchParameters SearchParameters { get; set; }
        public IEnumerable<AccommodationSearchRequest> Accomodation { get; set; }
        public IEnumerable<Cmp.Services.Transport.V2.TransportSearchRequest> Transport { get; set; }
    }

    public class SearchParameters
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
    }
}
