using AspNetWebApi2MediatRCustomeElementsV1Starter.Security;
using System;
using System.Linq;
using System.Data.Entity;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data.Model;
using System.Collections.Generic;
using System.Security.Claims;
using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using System.Threading.Tasks;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Security
{
    public class AuthenticateCommand
    {
        public class AuthenticateRequest : IRequest<AuthenticateResponse>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class AuthenticateResponse
        {
            public bool IsAuthenticated { get; set; }
        }

        public class AuthenticateHandler : IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>
        {
            public AuthenticateHandler(IAspNetWebApi2MediatRCustomeElementsV1StarterContext context, IEncryptionService encryptionService)
            {
                _encryptionService = encryptionService;
                _context = context;
            }

            public bool ValidateUser(User user, string transformedPassword)
            {
                if (user == null || transformedPassword == null)
                    return false;

                return user.Password == transformedPassword;
            }

            public async Task<AuthenticateResponse> Handle(AuthenticateRequest message)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Username.ToLower() == message.Username.ToLower() && !x.IsDeleted);

                return new AuthenticateResponse()
                {
                    IsAuthenticated = ValidateUser(user, _encryptionService.TransformPassword(message.Password))
                };
            }


            protected readonly IAspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private IEncryptionService _encryptionService { get; set; }
        }

    }

}
