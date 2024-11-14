using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using GPRSClient.Helpers;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.AccomodationService;

public class MockAccomodationService : IAccomodationService
{
    public async Task<AccommodationSearchResponse> Search(Models.PackagesSearchRequest request)
    {
        var response = new AccommodationSearchResponse();
        for (var i = 1; i < 6; i++)
        {
            response.Results.Add(CreateAccommodationSearchResult(i, request.SearchParameters.DepartureDate, request.SearchParameters.ReturnDate));
        }

        return response;
    }    

    public AccommodationSearchResult CreateAccommodationSearchResult(int hotelId, DateTime fromDate, DateTime toDate)
    {
        var result = new AccommodationSearchResult
        {
            ResultId = hotelId,
            QueryId = -1473264676,
            Units = { CreateUnit(fromDate, toDate), CreateUnit(fromDate, toDate) },
            TotalPriceDetail = CreatePriceDetail(),
            RateRules =
            {
                new Cmp.Types.V1.RateRule
                {
                    RateType = Cmp.Types.V1.RateRuleType.Flexible,
                    RateDescription = "Fully refundable",
                    RateReference = "refundable_policy"
                }
            },
            Remarks = "No pets allowed",
            Bookability = new Cmp.Types.V1.Bookability
            {
                Type = Cmp.Types.V1.BookabilityType.Available
            }
        };

        return result;
    }

    private static Unit CreateUnit(DateTime fromDate, DateTime toDate)
    {
        var endDate = new Cmp.Types.V1.Date();
        endDate.Day = toDate.Day;
        endDate.Month = toDate.Month;
        endDate.Year = toDate.Year;

        var startDate = new Cmp.Types.V1.Date();
        endDate.Day = toDate.Day;
        endDate.Month = toDate.Month;
        endDate.Year = toDate.Year;

        var travelPeriod = new Cmp.Types.V1.TravelPeriod();
        travelPeriod.StartDate = startDate;
        travelPeriod.EndDate = new Cmp.Types.V1.Date();

        return new Unit
        {
            TravellerIds = { 123, 231 },
            Type = UnitType.HolidayHome,
            TravelPeriod = travelPeriod
        };
    }

    private static PriceDetail CreatePriceDetail()
    {
        return new PriceDetail
        {
            Price = CreatePrice(),
            Binding = true,
            Description = "Total price for 2 nights",
            LocallyPayable = false,
            Type = new Cmp.Types.V1.PriceBreakdownType { Code = "asds", FeeCode = Cmp.Types.V1.FeeCode.AdditionalDistance },
            Breakdowns =
            {
                new PriceDetail
                {
                    Price = new Price { Value = "200", Decimals = 2, Currency = new Currency { IsoCurrency = IsoCurrency.Usd } },
                    Binding = false,
                    Description = "Breakfast included",
                    LocallyPayable = false,
                    Type = new Cmp.Types.V1.PriceBreakdownType { Code = "asds", FeeCode = Cmp.Types.V1.FeeCode.AdditionalDrive },
                },
                new PriceDetail
                {
                    Price = new Price { Value = "50", Decimals = 2, Currency = new Currency { IsoCurrency = IsoCurrency.Usd } },
                    Binding = true,
                    Description = "Tourism tax",
                    LocallyPayable = true,
                    Type = new Cmp.Types.V1.PriceBreakdownType { Code = "asds", FeeCode = Cmp.Types.V1.FeeCode.AdditionalWeek },
                }
            }
        };
    }

    private static Price CreatePrice()
    {
        return new Price
        {
            Value = "250",
            Decimals = 2,
            Currency = new Currency
            {
                IsoCurrency = IsoCurrency.Usd
            }
        };
    }
}
