using AspNetWebApi2MediatRCustomeElementsV1Starter.Data.Model;
using System.Threading.Tasks;
using System.Security.Principal;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using System.Data.Entity;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public UserManager(IAspNetWebApi2MediatRCustomeElementsV1StarterContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _context.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly IAspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
    }
}
