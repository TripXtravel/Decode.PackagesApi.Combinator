using Cmp.Services.Accommodation.V2;
using Grpc.Net.Client;

namespace GPRSClient
{
    public class PingTest
    {
        public async Task<string> Main()
        {
            // Create a channel (replace 'localhost:50051' with the server address)
            using var channel = GrpcChannel.ForAddress("https://0x1b6c39dc2b8fb73b0ab20c711dd5e5d2d3a5163c:messenger.chain4travel.com:9090");

            // Create a client using the generated client stub
            
            var client = new Cmp.Services.Ping.V1.PingService.PingServiceClient(channel);

            // Create a request
            var request = new Cmp.Services.Ping.V1.PingRequest();

            // Call the remote method and get the response
            var response = await client.PingAsync(request);

            return "Response from server: " + response.PingMessage;
        }
    }
}
