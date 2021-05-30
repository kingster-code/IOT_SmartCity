using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Data.dataInteractors;
using IOT_Data.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitor_Business.business2;
using Monitor_Business.interfaces;
using Syncfusion.Blazor;

namespace Monitor_View
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IInfoGetter, InfoGetter>();
            services.AddScoped<IZoneAtmRegistrator, ZoneAtmRegistrator>();
            services.AddScoped<IZoneRegistrator, ZoneRegistrator>();
            services.AddScoped<IZoneBusiness, ZoneBusiness>();
            services.AddSyncfusionBlazor();
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 65536;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDQ1NTgxQDMxMzkyZTMxMmUzMGxad2M1Y0taekh3R3FkZWkrN2k3d2RvVThOUTgyeVJMQzZ4Q0w2YUJmSTA9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
