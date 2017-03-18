using System.Data.Entity.Migrations;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Data.Model;
using AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Users;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(AspNetWebApi2MediatRCustomeElementsV1StarterContext context) {

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.SYSTEM
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.PRODUCT
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.DEVELOPMENT
            });

            context.SaveChanges();
        }
    }
}
