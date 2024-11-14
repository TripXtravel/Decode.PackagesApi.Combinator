using Cmp.Services.Transport.V2;
using GPRSClient.Models;

namespace GPRSClient.Services.Interfaces
{
    public interface IFlightsService
    {
        public TransportSearchResponse Search(PackagesSearchRequest transportSearchRequest);
    }
}
