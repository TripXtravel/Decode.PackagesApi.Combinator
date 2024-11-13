using Cmp.Services.Transport.V2;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.FlightsService
{
    public class MockFlightsService : IFlightsService
    {
        public TransportSearchResponse Search(TransportSearchRequest transportSearchRequest)
        {
            var result = new TransportSearchResult();
            result.QueryId = 123;
            result.Observations = "asdasd";
            result.OfferId = "offer1";
            result.Bookability = new Cmp.Types.V1.Bookability() { ConfirmationTime = new Cmp.Types.V1.Time() { Hours = 1, Minutes = 10 }, Type = Cmp.Types.V1.BookabilityType.Available };

            var rateRuleNonRef = new Cmp.Types.V1.RateRule() { RateDescription = "desc", RateReference = "123", RateType = Cmp.Types.V1.RateRuleType.NonRefundable };

            result.RateRules.Add(rateRuleNonRef);

            result.ResultId = 1;
            result.TotalPrice = new Cmp.Types.V2.PriceDetail()
            {
                Binding = true,
                Description = "flight1",
                Price = new Cmp.Types.V2.Price()
                {
                    Currency = new Cmp.Types.V2.Currency() { TokenCurrency = new Cmp.Types.V2.TokenCurrency() { ContractAddress = "address" }, IsoCurrency = Cmp.Types.V2.IsoCurrency.Eur },
                    Value = "100"
                },
                Type = new Cmp.Types.V1.PriceBreakdownType() { Code = "type", PriceType = Cmp.Types.V1.PriceType.Rate },
                LocallyPayable = true
            };

            var response = new TransportSearchResponse();
            response.Results.Add(result);

            return response;
        }
    }
}
