using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Middleware;
using LoanProcessManagement.App.Services.Implementation;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie("Cookies", options =>
            {
                options.LoginPath = "/";
                options.LogoutPath = "/Login/LogOut";
                options.ReturnUrlParameter = "ReturnUrl";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            var mvcBuilder = services.AddControllersWithViews();
            mvcBuilder.AddRazorRuntimeCompilation();

            services.AddHttpClient("LoanService", c =>
            {
                c.BaseAddress = new Uri(Configuration["APIConfiguration:LoanProcessAPIUrl"].ToString());
                c.Timeout = TimeSpan.FromSeconds(Configuration["APIConfiguration:Timeout"] != null
                    ? Convert.ToDouble(Configuration["APIConfiguration:Timeout"]) : 1000);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
            });
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IRoleMasterService, RoleMasterService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddScoped<ICommonServices, CommonServices>();
            services.AddSingleton<IUserListService, UserListService>();
            services.AddSingleton<ILeadListService, LeadListService>();
            services.AddSingleton<IPropertyDetailsService, PropertyDetailsService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IGSTLeadListService, GSTLeadListService>();
            services.AddSingleton<IIncomeAssesmentService, IncomeAssesmentService>();
            services.AddSingleton<IDSACornerService, DSACornerService>();
            services.AddScoped<IApplicantDetailsService, ApplicantDetailsService>();
            services.AddScoped<IReportsService, ReportsService>();
            services.AddScoped<IQueryHistoryService, QueryHistoryService>();
            services.AddScoped<ILeadITRDetailsService, LeadITRDetailsService>();
            services.AddScoped<ICibilCheckService, CibilCheckService>();
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<ICreditDetailsService, CreditDetailsService>();
            services.AddScoped<ILostLeadReasonMasterService, LostLeadReasonMasterService>();
            services.AddScoped<IRejectLeadReasonMasterService, RejectLeadReasonMasterService>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IQueryTypeService, QueryTypeService>();

            





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
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

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

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.None,
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseStatusCodePagesWithRedirects("/Error?statuscode=404");
            //app.UseCustomExceptionHandler();

            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
            });


            //SET Date culture for date formats
            var supportedCultures = new[] { new CultureInfo("en-GB") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-GB"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");
            //SET Date culture for date formats


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
