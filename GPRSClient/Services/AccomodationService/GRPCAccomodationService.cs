using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using Google.Protobuf.WellKnownTypes;
using GPRSClient.Services.Interfaces;

namespace GPRSClient.Services.AccomodationService
{
    public class GRPCAccomodationService : IAccomodationService
    {
        public AccommodationProductInfoResponse Search(AccommodationSearchRequest request)
        {
            return new AccommodationProductInfoResponse();
        }

        public AccommodationSearchRequest CreateAccommodationSearchRequest()
        {
            var requestId = new Cmp.Types.V1.UUID();
            requestId.Value = Helpers.RandomStringHelper.GenerateRandomString(5);


            var request = new Cmp.Services.Accommodation.V2.AccommodationSearchRequest
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
                Metadata = new Cmp.Types.V2.SearchRequestMetadata()
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
                SearchParametersGeneric = new Cmp.Types.V2.SearchParameters
                {
                    BrandCodes = { "et", "enim irure Ut", "veniam amet", "ex laboris nostrud mollit labore", "consectetur ad Lorem" },
                    Currency = new Cmp.Types.V2.Currency
                    {
                        IsoCurrency = Cmp.Types.V2.IsoCurrency.Cdf,
                        TokenCurrency = new Cmp.Types.V2.TokenCurrency
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
                    Market = Cmp.Types.V2.Country.Nc,
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
                    LocationCodes = new Cmp.Types.V2.LocationCodes
                    {
                        Codes =
                        {
                            new LocationCode { Code = "sit quis Ut nulla", Type = Cmp.Types.V2.LocationCodeType._3AlphaCode },
                            new LocationCode { Code = "ad reprehenderit elit tempor", Type = (Cmp.Types.V2.LocationCodeType)11 },
                            new LocationCode { Code = "eu eiusmod ullamco in Duis", Type = Cmp.Types.V2.LocationCodeType.HereId }
                        }
                    },
                    LocationCoordinates = new Cmp.Types.V2.Coordinates { Latitude = -52241880.494714186, Longitude = -1075615.0050410926 },
                    LocationGeoTree = new Cmp.Types.V2.GeoTree { Country = Cmp.Types.V2.Country.Sc, Region = "Lorem sunt eu", CityOrResort = "Duis" },
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
                    LocationCodes = new Cmp.Types.V2.LocationCodes
                    {
                        Codes = { new Cmp.Types.V2.LocationCode { Code = "et non cupidatat cillum", Type = Cmp.Types.V2.LocationCodeType.ProviderCode } }
                    },
                    LocationCoordinates = new Cmp.Types.V2.Coordinates { Latitude = 99298836.4953902, Longitude = 64718032.39222962 },
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
                    LocationCodes = new Cmp.Types.V2.LocationCodes
                    {
                        Codes = { new Cmp.Types.V2.LocationCode { Code = "eiusmod ex occaecat", Type = (Cmp.Types.V2.LocationCodeType)6 } }
                    },
                    LocationCoordinates = new Cmp.Types.V2.Coordinates { Latitude = 3420395.826354608, Longitude = 16885397.05836156 },
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
                    LocationCodes = new Cmp.Types.V2.LocationCodes
                    {
                        Codes = { new Cmp.Types.V2.LocationCode { Code = "culpa occaecat", Type = Cmp.Types.V2.LocationCodeType.Unspecified } }
                    },
                    LocationCoordinates = new Cmp.Types.V2.Coordinates { Latitude = 33272033.83711499, Longitude = 32878192.071919754 },
                    MealPlanCodes =
                    {
                        new Cmp.Types.V1.MealPlan { Code = (Cmp.Types.V1.MealPlanCode)7, Description = "cupidatat eu" }
                    }
                }
            };
        }


        public AccommodationSearchResult CreateAccommodationSearchResult()
        {
            var result = new AccommodationSearchResult
            {
                ResultId = 1,
                QueryId = -1473264676,
                Units = { CreateUnit(), CreateUnit() },
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
                CancelPolicy = new Cmp.Types.V2.CancelPolicy
                {
                    FreeCancellationUpto = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(2)),
                },
                Remarks = "No pets allowed",
                Bookability = new Cmp.Types.V1.Bookability
                {
                    Type = Cmp.Types.V1.BookabilityType.Available
                }
            };

            return result;
        }

        private static Unit CreateUnit()
        {
            var services = new Google.Protobuf.Collections.RepeatedField<ServiceFact>();
            services.Add(new ServiceFact() { Description = "A comfortable standard room with modern amenities.", Code = "MockCode", Quantity = 2 });
            return new Unit
            {
                TravellerIds = { 123, 231 },
                Type = UnitType.HolidayHome,
                //Services = services                
            };
        }

        private static Cmp.Types.V2.PriceDetail CreatePriceDetail()
        {
            return new Cmp.Types.V2.PriceDetail
            {
                Price = CreatePrice(),
                Binding = true,
                Description = "Total price for 2 nights",
                LocallyPayable = false,
                Type = new Cmp.Types.V1.PriceBreakdownType { Code = "asds", FeeCode = Cmp.Types.V1.FeeCode.AdditionalDistance },
                Breakdowns =
        {
            new Cmp.Types.V2.PriceDetail
            {
                Price = new Price { Value = "200", Decimals = 2, Currency = new Currency { IsoCurrency = Cmp.Types.V2.IsoCurrency.Usd } },
                Binding = false,
                Description = "Breakfast included",
                LocallyPayable = false,
                Type = new Cmp.Types.V1.PriceBreakdownType { Code = "asds", FeeCode = Cmp.Types.V1.FeeCode.AdditionalDrive },
            },
            new Cmp.Types.V2.PriceDetail
            {
                Price = new Price { Value = "50", Decimals = 2, Currency = new Currency { IsoCurrency = Cmp.Types.V2.IsoCurrency.Usd } },
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
                    IsoCurrency = Cmp.Types.V2.IsoCurrency.Usd
                }
            };
        }
    }
}

