using Cmp.Services.Accommodation.V2;

namespace GPRSClient.Services.Interfaces
{
    public interface IAccomodationService
    {
        public AccommodationSearchRequest CreateAccommodationSearchRequest();
        public AccommodationProductInfoResponse Search(AccommodationProductInfoRequest request);

    }
}
