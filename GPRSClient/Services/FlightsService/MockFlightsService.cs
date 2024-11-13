using Cmp.Services.Transport.V2;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.FlightsService
{
    public class MockFlightsService : IFlightsService
    {
        public TransportSearchResponse Search(TransportSearchRequest transportSearchRequest)
        {
            var a = new TransportSearchResponse();

            var t = new TransportSearchResult();
            t.QueryId = 123;
            t.Observations = "asdasd";
            t.OfferId = "offer1";
            t.


            a.Results.Add(t.QueryId = 123);



        }
    }
}
