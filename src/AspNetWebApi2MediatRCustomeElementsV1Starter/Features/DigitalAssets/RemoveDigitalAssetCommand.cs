using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using System.Threading.Tasks;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.DigitalAssets
{
    public class RemoveDigitalAssetCommand
    {
        public class RemoveDigitalAssetRequest : IRequest<RemoveDigitalAssetResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveDigitalAssetResponse { }

        public class RemoveDigitalAssetHandler : IAsyncRequestHandler<RemoveDigitalAssetRequest, RemoveDigitalAssetResponse>
        {
            public RemoveDigitalAssetHandler(IAspNetWebApi2MediatRCustomeElementsV1StarterContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveDigitalAssetResponse> Handle(RemoveDigitalAssetRequest request)
            {
                var digitalAsset = await _context.DigitalAssets.FindAsync(request.Id);
                digitalAsset.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveDigitalAssetResponse();
            }

            private readonly IAspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private readonly ICache _cache;
        }
    }
}
