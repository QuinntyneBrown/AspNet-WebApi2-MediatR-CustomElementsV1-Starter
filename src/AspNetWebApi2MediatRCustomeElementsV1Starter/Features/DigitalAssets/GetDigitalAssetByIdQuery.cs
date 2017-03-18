using MediatR;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using System.Threading.Tasks;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.DigitalAssets
{
    public class GetDigitalAssetByIdQuery
    {
        public class GetDigitalAssetByIdRequest : IRequest<GetDigitalAssetByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetDigitalAssetByIdResponse
        {
            public DigitalAssetApiModel DigitalAsset { get; set; } 
		}

        public class GetDigitalAssetByIdHandler : IAsyncRequestHandler<GetDigitalAssetByIdRequest, GetDigitalAssetByIdResponse>
        {
            public GetDigitalAssetByIdHandler(IAspNetWebApi2MediatRCustomeElementsV1StarterContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetDigitalAssetByIdResponse> Handle(GetDigitalAssetByIdRequest request)
            {                
                return new GetDigitalAssetByIdResponse()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _context.DigitalAssets.FindAsync(request.Id))
                };
            }

            private readonly IAspNetWebApi2MediatRCustomeElementsV1StarterContext _context;
            private readonly ICache _cache;
        }
    }
}
