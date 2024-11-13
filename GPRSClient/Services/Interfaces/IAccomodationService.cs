using Cmp.Services.Accommodation.V2;
using PackagesApi.Combinator.Models;

namespace GPRSClient.Services.Interfaces
{
    public interface IAccomodationService
    {
        public AccommodationProductInfoResponse Search(AccomodationRequest request);

    }
}
