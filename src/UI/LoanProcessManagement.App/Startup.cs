using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            app.UseRouting();
            app.UseAuthentication();

=========
            //app.UseMvc();

>>>>>>>>> Temporary merge branch 2

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
>>>>>>>>> Temporary merge branch 2
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //    //endpoints.MapControllerRoute(
            //    //    name: "default",
            //    //    pattern: "{controller=Login}/{action=Index}/{id?}");
            //    endpoints.MapRazorPages();
            //});
                //endpoints.MapRazorPages();
>>>>>>>>> Temporary merge branch 2
>>>>>>>>> Temporary merge branch 2
            app.UseAuthorization();
<<<<<<<<< Temporary merge branch 1
                endpoints.MapRazorPages();
=========
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //       name: "default",
                //       pattern: "{controller=Login}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
                //endpoints.MapRazorPages();
>>>>>>>>> Temporary merge branch 2
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //       name: "default",
                //       pattern: "{controller=Login}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
                //endpoints.MapRazorPages();
>>>>>>>>> Temporary merge branch 2
                //       name: "default",
                //       pattern: "{controller=Login}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
                //endpoints.MapRazorPages();
>>>>>>>>> Temporary merge branch 2
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //    //endpoints.MapControllerRoute(
            //    //    name: "default",
            //    //    pattern: "{controller=Login}/{action=Index}/{id?}");
            //    endpoints.MapRazorPages();
            //});
        }
    }
}
