using AppLabs.EntityFramework.Data;
using AppLabs.EntityFramework.Data.Entities;
using AppLabs.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppLabs.EntityFramework.Web.Demo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IDataAccessConfiguration>(dc =>
              new DataAccessConfiguration($"{Configuration["DataAccessConfiguration:ConnectionString"]}",
                  bool.Parse(Configuration["DataAccessConfiguration:UseSqlite"])));

            services.AddScoped<IDatabaseFactory, DatabaseFactory<BitacoraContext>>();
            services.AddTransient<IUnitOfWork<BitacoraContext>, UnitOfWork<BitacoraContext>>();
            services.AddTransient<IRepository<Proyecto>, Repository<Proyecto>>();
            services.AddTransient<IRepository<Etiqueta>, Repository<Etiqueta>>();
            services.AddTransient<IRepository<Entrada>, Repository<Entrada>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
