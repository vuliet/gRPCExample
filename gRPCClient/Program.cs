using Grpc.Core;
using Grpc.Net.Client;
using gRPCClient.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5229");
var client = new UserProtoService.UserProtoServiceClient(channel);

var request = new GetUserRequest
{
    UserId = "1"
};

try
{
    var user = await client.GetUserAsync(request);

    Console.WriteLine(user);
}
catch (RpcException ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();