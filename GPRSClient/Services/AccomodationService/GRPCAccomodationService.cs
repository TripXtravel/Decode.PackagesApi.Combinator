using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using Google.Protobuf.WellKnownTypes;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.AccomodationService
{
    public class GRPCAccomodationService : IAccomodationService
    {
        public AccommodationSearchRequest CreateAccommodationSearchRequest()
        {
            throw new NotImplementedException();
        }

        public AccommodationSearchResult CreateAccommodationSearchResult()
        {
            throw new NotImplementedException();
        }

        public AccommodationSearchResponse Search(AccommodationSearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

