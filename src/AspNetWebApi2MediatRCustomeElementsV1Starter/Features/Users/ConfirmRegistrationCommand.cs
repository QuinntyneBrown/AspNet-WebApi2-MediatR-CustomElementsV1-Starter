using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core;
using System.Threading.Tasks;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Users
{
    public class ConfirmRegistrationCommand
    {
        public class ConfirmRegistrationRequest : IRequest<ConfirmRegistrationResponse>
        {
            public string Token { get; set; }
        }

        public class ConfirmRegistrationResponse
        {
            public ConfirmRegistrationResponse()
            {

            }
        }

        public class ConfirmRegistrationHandler : IAsyncRequestHandler<ConfirmRegistrationRequest, ConfirmRegistrationResponse>
        {
            public ConfirmRegistrationHandler(AspNetWebApi2MediatRCustomeElementsV1StarterContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<ConfirmRegistrationResponse> Handle(ConfirmRegistrationRequest request)
            {
                throw new System.NotImplementedException();
            }

            private readonly AspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private readonly ICache _cache;
        }

    }

}
