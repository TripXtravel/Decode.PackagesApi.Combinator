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
            SupplierRoomName = "Double Room Sea View",
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

    private AccommodationSearchQuery CreateQuery2(DateTime startDate, DateTime endDate)
    {
        return new AccommodationSearchQuery
        {
            QueryId = 2,
            SearchParametersAccommodation = new AccommodationSearchParameters
            {
                LocationCodes = new LocationCodes
                {
                    Codes = { new LocationCode { Code = "et non cupidatat cillum", Type = LocationCodeType.ProviderCode } }
                },
                LocationCoordinates = new Coordinates { Latitude = 99298836.4953902, Longitude = 64718032.39222962 },
                MealPlanCodes =
                {
                    new Cmp.Types.V1.MealPlan{ Code = Cmp.Types.V1.MealPlanCode.Do, Description = "nostrud dolor" }
                }
            },
            TravelPeriod = new Cmp.Types.V1.TravelPeriod()
            {
                StartDate = DateHelper.ToDate(startDate),
                EndDate = DateHelper.ToDate(endDate),
            }
        };
    }

    private AccommodationSearchQuery CreateQuery3(DateTime startDate, DateTime endDate)
    {
        return new AccommodationSearchQuery
        {
            QueryId = 3,
            SearchParametersAccommodation = new AccommodationSearchParameters
            {
                LocationCodes = new LocationCodes
                {
                    Codes = { new LocationCode { Code = "eiusmod ex occaecat", Type = (LocationCodeType)6 } }
                },
                LocationCoordinates = new Coordinates { Latitude = 3420395.826354608, Longitude = 16885397.05836156 },
                MealPlanCodes =
                {
                    new Cmp.Types.V1.MealPlan { Code = Cmp.Types.V1.MealPlanCode.Lo, Description = "deserunt" }
                }
            },
            TravelPeriod = new Cmp.Types.V1.TravelPeriod()
            {
                StartDate = DateHelper.ToDate(startDate),
                EndDate = DateHelper.ToDate(endDate),
            }
        };
    }

    private AccommodationSearchQuery CreateQuery4(DateTime startDate, DateTime endDate)
    {
        return new AccommodationSearchQuery
        {
            QueryId = 4,
            SearchParametersAccommodation = new AccommodationSearchParameters
            {
                LocationCodes = new LocationCodes
                {
                    Codes = { new LocationCode { Code = "culpa occaecat", Type = LocationCodeType.Unspecified } }
                },
                LocationCoordinates = new Coordinates { Latitude = 33272033.83711499, Longitude = 32878192.071919754 },
                MealPlanCodes =
                {
                    new Cmp.Types.V1.MealPlan { Code = (Cmp.Types.V1.MealPlanCode)7, Description = "cupidatat eu" }
                }
            },
            TravelPeriod = new Cmp.Types.V1.TravelPeriod()
            {
                StartDate = DateHelper.ToDate(startDate),
                EndDate = DateHelper.ToDate(endDate),
            }
        };
    }
}
