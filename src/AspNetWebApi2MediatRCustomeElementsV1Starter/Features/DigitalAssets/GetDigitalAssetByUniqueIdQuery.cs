using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.DigitalAssets
{
    public class GetDigitalAssetByUniqueIdQuery
    {
        public class GetDigitalAssetByUniqueIdRequest : IRequest<GetDigitalAssetByUniqueIdResponse>
        {
            public string UniqueId { get; set; }
        }

        public class GetDigitalAssetByUniqueIdResponse
        {
            public DigitalAssetApiModel DigitalAsset { get; set; }
        }

        public class GetDigitalAssetByUniqueIdHandler : IAsyncRequestHandler<GetDigitalAssetByUniqueIdRequest, GetDigitalAssetByUniqueIdResponse>
        {
            public GetDigitalAssetByUniqueIdHandler(AspNetWebApi2MediatRCustomeElementsV1StarterContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetDigitalAssetByUniqueIdResponse> Handle(GetDigitalAssetByUniqueIdRequest request)
            {
                return new GetDigitalAssetByUniqueIdResponse()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _context.DigitalAssets.SingleAsync(x=>x.UniqueId.ToString() == request.UniqueId))
                };
            }

            private readonly AspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private readonly ICache _cache;
        }

    }

}
