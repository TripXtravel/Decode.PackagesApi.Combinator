using Cmp.Services.Accommodation.V2;
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

    public AccommodationSearchResponse Search(PackagesSearchRequest request)
    {            
        throw new NotImplementedException();
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

