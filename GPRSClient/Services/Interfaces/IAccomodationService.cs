using Cmp.Services.Accommodation.V2;

namespace GPRSClient.Services.Interfaces
{
    public interface IAccomodationService
    {
        public AccommodationSearchRequest CreateAccommodationSearchRequest();
        AccommodationSearchResult CreateAccommodationSearchResult();
        public AccommodationSearchResponse Search(AccommodationSearchRequest request);

    }
}
