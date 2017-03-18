using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data.Model;
using System.Threading.Tasks;
using System.Data.Entity;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.DigitalAssets
{
    public class AddOrUpdateDigitalAssetCommand
    {
        public class AddOrUpdateDigitalAssetRequest : IRequest<AddOrUpdateDigitalAssetResponse>
        {
            public DigitalAssetApiModel DigitalAsset { get; set; }
        }

        public class AddOrUpdateDigitalAssetResponse { }

        public class AddOrUpdateDigitalAssetHandler : IAsyncRequestHandler<AddOrUpdateDigitalAssetRequest, AddOrUpdateDigitalAssetResponse>
        {
            public AddOrUpdateDigitalAssetHandler(IAspNetWebApi2MediatRCustomeElementsV1StarterContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateDigitalAssetResponse> Handle(AddOrUpdateDigitalAssetRequest request)
            {
                var entity = await _context.DigitalAssets
                    .SingleOrDefaultAsync(x => x.Id == request.DigitalAsset.Id && x.IsDeleted == false);
                if (entity == null) _context.DigitalAssets.Add(entity = new DigitalAsset());
                entity.Name = request.DigitalAsset.Name;
                entity.Folder = request.DigitalAsset.Folder;
                await _context.SaveChangesAsync();

                return new AddOrUpdateDigitalAssetResponse() { };
            }

            private readonly IAspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private readonly ICache _cache;
        }
    }
}
