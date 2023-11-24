using Grpc.Core;
using Grpc.Net.Client;
using gRPCClient.Protos;

var channel = GrpcChannel.ForAddress("https://localhost:7230");
var client = new UserProtoService.UserProtoServiceClient(channel);

var request = new GetUserRequest
{
    UserId = "1"
};

try
{
    var user = client.GetUser(request);

    Console.WriteLine(user);
}
catch (RpcException ex)
{
    Console.WriteLine(ex.Message);
}