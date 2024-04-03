using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationSrviceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(opt =>
                {
                    SQLitePCL.Batteries.Init();
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });
           services.AddCors();
           services.AddScoped<ITokenService, TokenService>();
           services.AddScoped<IUserRepository, userRepository>();
           services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

           return services;
        }
    }
}