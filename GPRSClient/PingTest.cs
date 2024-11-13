using Cmp.Services.Accommodation.V2;
using Grpc.Core;
using Grpc.Net.Client;

namespace GPRSClient
{
    public class PingTest
    {
        public async Task<string> Main()
        {
            // Create a channel (replace 'localhost:50051' with the server address)
            using var channel = GrpcChannel.ForAddress("http://localhost:9090");

            // Create a client using the generated client stub

            var client = new Cmp.Services.Accommodation.V2.AccommodationSearchService.AccommodationSearchServiceClient(channel);

            // Create a request
            var request = new Cmp.Services.Accommodation.V2.AccommodationSearchRequest();
            request.Header = new Cmp.Types.V1.RequestHeader();
            request.Header.BaseHeader = new Cmp.Types.V1.Header();
            request.Header.BaseHeader.EndUserWalletAddress = "nulla non nostrud sit irure";
            var query = new AccommodationSearchQuery();
            query.QueryId = -2017305311;
            var searchParametersAccomodation = new AccommodationSearchParameters();
            var locationCodes = new Cmp.Types.V2.LocationCodes();
            var codes = new Google.Protobuf.Collections.RepeatedField<Cmp.Types.V2.LocationCode>();
            var locationCode = new Cmp.Types.V2.LocationCode();
            locationCode.Code = "asddas";
            locationCode.Type = Cmp.Types.V2.LocationCodeType.IataCode''
            codes.Add()
            locationCodes.Codes = 

            searchParametersAccomodation.LocationCodes = locationCodes;
            query.SearchParametersAccommodation = searchParametersAccomodation;
            var queries = new Google.Protobuf.Collections.RepeatedField<AccommodationSearchQuery>();
            
            request.Queries = ;
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

            return "Response from server: " + response;
        }
    }
}
