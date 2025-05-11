
using ITTPEx.Application.Interfaces.Repositories;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication.Tokens;
using ITTPEx.Infrastructure.Context;
using ITTPEx.Infrastructure.Repositories;
using ITTPEx.Infrastructure.Repositories.Authentication;
using ITTPEx.Infrastructure.Services.Authentication;
using ITTPEx.Infrastructure.Services.Authentication.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITTPEx.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            services.AddRepositories();
            services.AddDataBaseContext(configuration);
        }

        private static void AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).UseSnakeCaseNamingConvention());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<IPasswordHasherService, PasswordHasherService>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
        }


    }
}
