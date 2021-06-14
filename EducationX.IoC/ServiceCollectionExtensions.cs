using EducationX.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EducationX.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            Assembly infrastructureAssembly = Assembly.Load("EducationX.Infrastructure");
            services.AddMediatR(infrastructureAssembly);
        }

        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EducationXDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("Database")));
        }
    }
}
