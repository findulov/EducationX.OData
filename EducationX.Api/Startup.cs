using EducationX.Application.Configurations;
using EducationX.Infrastructure.Database.Seed;
using EducationX.IoC;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;

namespace EducationX.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDbContext(Configuration);

            services.AddControllers();
            services.AddOData();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors();

            services.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors(policy =>
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

            // This configuration below should ideally be extracted to an external configuration class.
            // I'm keeping it here for simplicity.
            #region OData configuration

            IEdmModel edmModel = ODataEdmConfiguration.GetEdmModel();

            app.UseMvc(routeBuilder =>
            {
                // Allowing all operations .
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();

                routeBuilder.MapODataServiceRoute("odata", "odata", edmModel);

                routeBuilder.MapRoute(
                   name: "Default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseOData(edmModel);

            #endregion
        }
    }
}
