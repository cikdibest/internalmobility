using IM.CsvConverter;
using IM.Web.Conversion.Contract;
using IM.Web.Conversion.Imp;
using IM.Web.Database.Context;
using IM.Web.Database.Conversion;
using IM.Web.Database.Repository;
using IM.Web.Database.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IM.Web
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
            services.AddControllers();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<ICsvAssetReader, CsvAssetReader>();
            services.AddScoped<IAssetConverter, AssetConverter>();
            services.AddScoped<IAssetSearchPredicateConverter, AssetSearchPredicateConverter>();

            services.AddScoped<IAssetPropertySetter, AssetPropertySetter>();
            services.AddDbContext<IMDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("IMDatabase")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
