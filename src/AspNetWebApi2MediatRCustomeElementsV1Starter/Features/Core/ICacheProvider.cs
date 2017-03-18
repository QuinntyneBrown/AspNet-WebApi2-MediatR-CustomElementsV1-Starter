using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core
{
    public interface ICacheProvider
    {
        ICache GetCache();
    }
}
