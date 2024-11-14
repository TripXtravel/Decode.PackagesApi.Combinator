using Cmp.Services.Accommodation.V2;
using Cmp.Types.V2;
using Google.Protobuf.WellKnownTypes;
using GPRSClient.Services.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;

namespace GPRSClient.Services.AccomodationService
{
    public class GRPCAccomodationService : IAccomodationService
    {
        public AccommodationSearchRequest CreateAccommodationSearchRequest()
        {
            throw new NotImplementedException();
        }

        public AccommodationSearchResult CreateAccommodationSearchResult()
        {
            throw new NotImplementedException();
        }

        public AccommodationSearchResponse Search(AccommodationSearchRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AccommodationSearchResponse> SearchAsync(AccommodationSearchRequest request)
        {
            // Create a channel (replace 'localhost:50051' with the server address)
            using var channel = GrpcChannel.ForAddress("http://localhost:9090");

            // Create a client using the generated client stub

            var client = new AccommodationSearchService.AccommodationSearchServiceClient(channel);

            var major = new Cmp.Types.V1.Version();
            major.Major = new Cmp.Types.V1.Version().Major;
            major.Minor = new Cmp.Types.V1.Version().Minor;
            major.Patch = new Cmp.Types.V1.Version().Patch;

            request.Header.BaseHeader.Version = new Cmp.Types.V1.Version(major);

            var metadata = new Metadata
            {
                { "recipient", "0x1bba6d75f329022349799d78d87fe9d79fa4c36e" }
            };
            var response = await client.AccommodationSearchAsync(request, headers: metadata);

            return response;
        }
    }
}

