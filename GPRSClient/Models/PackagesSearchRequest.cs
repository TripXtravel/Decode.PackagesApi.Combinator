using Cmp.Services.Accommodation.V2;

namespace GPRSClient.Models
{
    public class PackagesSearchRequest
    {
        public IEnumerable<AccommodationSearchRequest> Accomodation { get; set; }
        public IEnumerable<Cmp.Services.Transport.V2.TransportSearchRequest> Transport { get; set; }

    }
}
