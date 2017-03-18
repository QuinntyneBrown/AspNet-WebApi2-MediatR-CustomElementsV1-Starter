using System.Data.Entity.Migrations;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data.Model;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(AspNetWebApi2MediatRCustomeElementsV1StarterContext context) {

            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default"
            });

            context.SaveChanges();
        }
    }
}
