using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DotnetCore2
{
    public class Startup
    {
        // Changes from GITHUB @22.37 PM
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _config       = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = true;
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:60450/",
                                            "http://localhost:4200/");
                    });

                //options.AddPolicy("ApiPolicy", builder =>
                //{
                //    builder.WithOrigins("http://localhost:60450/",
                //                            "http://localhost:4200/");
                //});
            });

            services.AddControllers();
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory


            //services.AddCors(options =>
            //{   
            //    options.AddDefaultPolicy(
            //    builder => builder.SetIsOriginAllowed(_ => true)
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowCredentials());
            //});

            

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync(_config["MyKey"]);
            //     });
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/contact", async context =>
                 {
                     await context.Response.WriteAsync("Welcome , BBX , BBC COX,NEWJERCY-2000202.");
                 });
            });

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                //app.UseCors(builder => builder
                //       .AllowAnyOrigin()
                //       .AllowAnyMethod()
                //       .AllowAnyHeader());

              

                app.UseRouting();

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(0, 1, 0);
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

          
        }
    }
}
