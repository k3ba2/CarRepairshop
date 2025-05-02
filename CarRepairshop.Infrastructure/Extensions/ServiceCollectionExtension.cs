using CarRepairshop.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarRepairshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarRepairshopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarRepairshopDb")));

            services.AddAuthorization();

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CarRepairshopDbContext>();
        }
    }
}
