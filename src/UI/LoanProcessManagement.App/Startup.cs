using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Implementation;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Http;

namespace LoanProcessManagement.App
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
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<ITypedClientConfig, TypedClientConfig>();

            services.AddHttpClient<IAccountService, AccountService>()
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var clientConfig = serviceProvider.GetRequiredService<ITypedClientConfig>();
                    httpClient.BaseAddress = clientConfig.BaseUrl;
                    httpClient.Timeout = TimeSpan.FromSeconds(clientConfig.Timeout);
                    //httpClient.DefaultRequestHeaders.Add("User-Agent", "BlahAgent");
                    //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))    // Default is 2 mins
                .ConfigurePrimaryHttpMessageHandler(x =>
                    new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                        UseCookies = false,
                        AllowAutoRedirect = false,
                        UseDefaultCredentials = true,
                    });
            #region Service Added for Menu in the Startup - Saif Khan - 28/10/2021
            services.AddHttpClient<IMenuService, MenuService>()
                    .ConfigureHttpClient((serviceProvider, httpClient) =>
                    {
                        var clientConfig = serviceProvider.GetRequiredService<ITypedClientConfig>();
                        httpClient.BaseAddress = clientConfig.BaseUrl;
                        httpClient.Timeout = TimeSpan.FromSeconds(clientConfig.Timeout);
                    })
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5))    // Default is 2 mins
                    .ConfigurePrimaryHttpMessageHandler(x =>
                        new HttpClientHandler
                        {
                            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                            UseCookies = false,
                            AllowAutoRedirect = false,
                            UseDefaultCredentials = true,
                        });
            #endregion

            //services.AddHttpClient();
            //services.AddScoped<IAccountService, AccountService>();
            services.Configure<APIConfiguration>(Configuration.GetSection("APIConfiguration"));
            services.AddSession();
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
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           


            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
            });



            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //    //endpoints.MapControllerRoute(
            //    //    name: "default",
            //    //    pattern: "{controller=Login}/{action=Index}/{id?}");
            //    endpoints.MapRazorPages();
            //});
            //endpoints.MapRazorPages();        

        }
    }
}
