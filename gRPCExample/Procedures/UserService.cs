using Grpc.Core;
using gRPCServer.Protos;
using static gRPCServer.Protos.UserProtoService;

namespace gRPCServer.Procedures
{
    public class UserService : UserProtoServiceBase
    {
        public override Task<UserResponse> GetUser(GetUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserResponse { UserId = request.UserId, UserName = "ThaiVu" });
        }
    }
}
