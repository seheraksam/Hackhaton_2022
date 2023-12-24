using Grpc.Net.Client;

namespace Hackathon.WebClient.Services
{
    public static class RecycleCoinCalculatorService
    {
        public static async Task<string> GetRecycleCoinValue(int carbonValue)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:4500/");
            var client = new Service.grpcService.grpcServiceClient(channel);
            var response = await client.getRecycleCoinAsync(new Service.Request { CarbonValue = carbonValue });
            return response.RecycleCoinValue.ToString();
        }
    }
}
