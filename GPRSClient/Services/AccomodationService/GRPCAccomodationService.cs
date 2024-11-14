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
                    }
                },                
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

