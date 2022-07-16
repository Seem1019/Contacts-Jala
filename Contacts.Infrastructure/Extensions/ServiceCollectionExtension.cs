using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Contacts.Core.CustomEntities;
using Contacts.Core.Interfaces;
using Contacts.Core.Services;
using Contacts.Infrastructure.Data;
using Contacts.Infrastructure.Interfaces;
using Contacts.Infrastructure.Options;
using Contacts.Infrastructure.Repositories;
using Contacts.Infrastructure.Services;


namespace Contacts.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JalaContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultTenant"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

    }
}
