using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using GPRSClient.Helpers;
using GPRSClient.Models;
using GPRSClient.Options;
using GPRSClient.Services.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;

namespace GPRSClient.Services.AccomodationService;

public class GRPCAccomodationService : IAccomodationService
{
    private readonly GRPCOptions _options;

    public GRPCAccomodationService(IOptions<GRPCOptions> options)
    {
        _options = options.Value;
    }

    public async Task<AccommodationSearchResponse> Search(PackagesSearchRequest request)
    {
        var accomodationsearchRequest = CreateAccommodationSearchRequest(request.SearchParameters.DepartureDate, request.SearchParameters.ReturnDate);
        using var channel = GrpcChannel.ForAddress(_options.Endpoints.AccomodationSearch);

        var client = new AccommodationSearchService.AccommodationSearchServiceClient(channel);
        PopulateHeaderVersion(accomodationsearchRequest);
        Metadata metadata = PopulateMetadata();
        var response = await client.AccommodationSearchAsync(accomodationsearchRequest, headers: metadata);

        return response;
    }

    public AccommodationSearchRequest CreateAccommodationSearchRequest(DateTime startDate, DateTime endDate)
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
                        Major = -2016257494,
                        Minor = 1569002609,
                        Patch = 1195017755
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
                CreateQuery1(startDate, endDate),
                //CreateQuery2(startDate, endDate),
                //CreateQuery3(startDate, endDate),
                //CreateQuery4(startDate, endDate)
            },
            SearchParametersGeneric = new Cmp.Types.V2.SearchParameters
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



    private AccommodationSearchQuery CreateQuery1(DateTime startDate, DateTime endDate)
    {
        return new AccommodationSearchQuery
        {
            QueryId = 1,
            SearchParametersAccommodation = new AccommodationSearchParameters
            {
                LocationCodes = new LocationCodes
                {
                    Codes =
                    {
                        new LocationCode { Code = "IATA4589", Type = LocationCodeType.IataCode },
                        //new LocationCode { Code = "ad reprehenderit elit tempor", Type = (LocationCodeType)11 },
                        //new LocationCode { Code = "eu eiusmod ullamco in Duis", Type = LocationCodeType.HereId }
                    }
                },
                //LocationCoordinates = new Coordinates { Latitude = -52241880.494714186, Longitude = -1075615.0050410926 },
                //LocationGeoTree = new GeoTree { Country = Country.Sc, Region = "Lorem sunt eu", CityOrResort = "Duis" },
                //MealPlanCodes = { new Cmp.Types.V1.MealPlan { Code = Cmp.Types.V1.MealPlanCode.AiMinus, Description = "irure proident" } },
                //RatePlans =
                //{
                //    new Cmp.Types.V1.RatePlan { RatePlanCode = "ut", RatePlanType = (Cmp.Types.V1.RatePlanType)14, RatePlanDescription = "sit nostrud veniam enim" }
                //}
            },
            TravelPeriod = new Cmp.Types.V1.TravelPeriod()
            {
                StartDate = DateHelper.ToDate(startDate),
                EndDate = DateHelper.ToDate(endDate),
            },
            UnitCount = 1,
            UnitType = UnitType.Unspecified
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

    public async Task<AccommodationSearchResponse> SearchAsync(AccommodationSearchRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_options.Endpoints.AccomodationSearch);

        var client = new AccommodationSearchService.AccommodationSearchServiceClient(channel);
        PopulateHeaderVersion(request);
        Metadata metadata = PopulateMetadata();
        var response = await client.AccommodationSearchAsync(request, headers: metadata);

        return response;
    }

    private static void PopulateHeaderVersion(AccommodationSearchRequest request)
    {
        var major = new Cmp.Types.V1.Version();
        major.Major = new Cmp.Types.V1.Version().Major;
        major.Minor = new Cmp.Types.V1.Version().Minor;
        major.Patch = new Cmp.Types.V1.Version().Patch;

        request.Header.BaseHeader.Version = new Cmp.Types.V1.Version(major);
    }

    private static Metadata PopulateMetadata()
    {
        return new Metadata
        {
            { "recipient", "0x1bba6d75f329022349799d78d87fe9d79fa4c36e" }
        };
    }
}

