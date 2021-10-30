using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Middleware;
using LoanProcessManagement.App.Services.Implementation;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

            services.AddHttpClient("LoanService", c =>
            {
                c.BaseAddress = new Uri(Configuration["APIConfiguration:LoanProcessAPIUrl"].ToString());
                c.Timeout = TimeSpan.FromSeconds(Configuration["APIConfiguration:Timeout"] != null 
                    ? Convert.ToDouble(Configuration["APIConfiguration:Timeout"]) : 1000);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
            });
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<IUserListService, UserListService>();

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

            //app.Use(async (context, next) =>
            //{
            //    string CurrentUserIDSession = context.Session.GetString("user");
            //    if (!context.Request.Path.Value.Contains("/Account/Login"))
            //    {
            //        if (string.IsNullOrEmpty(CurrentUserIDSession))
            //        {
            //            var path = $"/Account/Login?ReturnUrl={context.Request.Path}";
            //            context.Response.Redirect(path);
            //            return;
            //        }

            //    }
            //    await next();
            //});

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Error?statuscode=404");
            app.UseCustomExceptionHandler();

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
