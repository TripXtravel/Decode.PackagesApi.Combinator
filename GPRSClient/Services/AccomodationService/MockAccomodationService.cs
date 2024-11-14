using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.AccomodationService;

public class MockAccomodationService : IAccomodationService
{
    public AccommodationSearchResponse Search(Models.PackagesSearchRequest request)
    {
        var response = new AccommodationSearchResponse();
        for (var i = 1;i<6;i++)
        {
            response.Results.Add(CreateAccommodationSearchResult(i, request.SearchParameters.DepartureDate, request.SearchParameters.ReturnDate));
        }

        return response;
    }

    public AccommodationSearchRequest CreateAccommodationSearchRequest()
    {
        var requestId = new Cmp.Types.V1.UUID();
        requestId.Value = Helpers.RandomStringHelper.GenerateRandomString(5);


        var request = new AccommodationSearchRequest
        {
            Header = new Cmp.Types.V1.RequestHeader
            {
                BaseHeader = new Cmp.Types.V1.Header
                {
                    EndUserWalletAddress = "esse culpa ea cupidatat",
                    Version = new Cmp.Types.V1.Version
                    {
                        Major = 723314657,
                        Minor = -2144637630,
                        Patch = -174160266
                    }
                }
            },
            Metadata = new SearchRequestMetadata()
            {
                ExternalSessionId = Helpers.RandomStringHelper.GenerateRandomString(10),
                RequestId = requestId
            },
            Queries =
            {
                CreateQuery1(),
                CreateQuery2(),
                CreateQuery3(),
                CreateQuery4()
            },
            SearchParametersGeneric = new SearchParameters
            {
                BrandCodes = { "et", "enim irure Ut", "veniam amet", "ex laboris nostrud mollit labore", "consectetur ad Lorem" },
                Currency = new Currency
                {
                    IsoCurrency = IsoCurrency.Cdf,
                    TokenCurrency = new TokenCurrency
                    {
                        ContractAddress = "proident sunt"
                    }
                },
                Filters =
                 {
                     new Cmp.Types.V1.Filter { Code = "Lorem pariatur proident", Description = "exercitation ipsum commodo ut", Type = Cmp.Types.V1.FilterType.ProviderCode, Value = "velit aute veniam non" },
                     new Cmp.Types.V1.Filter { Code = "nostrud in et", Description = "aute", Type = Cmp.Types.V1.FilterType.Unspecified, Value = "amet" }
                 },
                IncludeCombinations = true,
                IncludeOnRequest = true,
                Language = (Cmp.Types.V1.Language)81,
                Market = Country.Nc,
                MaxOptions = -1520182189,
                SearchDescriptionText = "dolore nostrud",
                Sorting = new Cmp.Types.V1.Sorting
                {
                    SortingOrder = Cmp.Types.V1.SortingOrder.Ascending,
                    SortingType = Cmp.Types.V1.SortingType.Price
                }
            }
        };

        return request;
    }

    private AccommodationSearchQuery CreateQuery1()
    {
        return new AccommodationSearchQuery
        {
            QueryId = -1473264676,
            SearchParametersAccommodation = new AccommodationSearchParameters
            {
                LocationCodes = new LocationCodes
                {
                    Codes =
                    {
                        new LocationCode { Code = "sit quis Ut nulla", Type = LocationCodeType._3AlphaCode },
                        new LocationCode { Code = "ad reprehenderit elit tempor", Type = (LocationCodeType)11 },
                        new LocationCode { Code = "eu eiusmod ullamco in Duis", Type = LocationCodeType.HereId }
                    }
                },
                LocationCoordinates = new Coordinates { Latitude = -52241880.494714186, Longitude = -1075615.0050410926 },
                LocationGeoTree = new GeoTree { Country = Country.Sc, Region = "Lorem sunt eu", CityOrResort = "Duis" },
                MealPlanCodes = { new Cmp.Types.V1.MealPlan { Code = Cmp.Types.V1.MealPlanCode.AiMinus, Description = "irure proident" } },
                RatePlans =
                {
                    new Cmp.Types.V1.RatePlan { RatePlanCode = "ut", RatePlanType = (Cmp.Types.V1.RatePlanType)14, RatePlanDescription = "sit nostrud veniam enim" }
                }
            }
        };
    }

    private AccommodationSearchQuery CreateQuery2()
    {
        return new AccommodationSearchQuery
        {
            QueryId = -1406962554,
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
            }
        };
    }

    private AccommodationSearchQuery CreateQuery3()
    {
        return new AccommodationSearchQuery
        {
            QueryId = 625405259,
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
            }
        };
    }

    private AccommodationSearchQuery CreateQuery4()
    {
        return new AccommodationSearchQuery
        {
            QueryId = 1486677580,
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
            }
        };
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
