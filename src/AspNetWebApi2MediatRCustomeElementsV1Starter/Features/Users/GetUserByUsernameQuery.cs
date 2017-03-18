using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Users
{
    public class GetUserByUsernameQuery
    {
        public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
        {
            public string Username { get; set; }
            public int? TenantId { get; set; }
        }

        public class GetUserByUsernameResponse
        {
            public UserApiModel User { get; set; }
        }

        public class GetUserByUsernameHandler : IAsyncRequestHandler<GetUserByUsernameRequest, GetUserByUsernameResponse>
        {
            public GetUserByUsernameHandler(IAspNetWebApi2MediatRCustomeElementsV1StarterContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetUserByUsernameResponse> Handle(GetUserByUsernameRequest request)
            {
                return new GetUserByUsernameResponse()
                {
                    User = UserApiModel.FromUser(await _context.Users.SingleAsync(x=>x.Username == request.Username && x.TenantId == request.TenantId))
                };
            }

            private readonly IAspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private readonly ICache _cache;
        }
    }
}