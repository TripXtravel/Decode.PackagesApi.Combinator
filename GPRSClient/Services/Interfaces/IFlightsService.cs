using Cmp.Services.Transport.V2;

namespace GPRSClient.Services.Interfaces
{
    public interface IFlightsService
    {
        public TransportSearchResponse Search(TransportSearchRequest transportSearchRequest);
    }
}
