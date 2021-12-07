using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
using LoanProcessManagement.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LoanProcessManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IChangePasswordRepository, ChangePasswordRepository>();
            services.AddScoped<IForgotPasswordRepository, ForgotPasswordRepository>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IUnlockUserAccountRepository,UnlockUserAccountRepository>();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IUserListRepository, UserListRepository>();
            services.AddScoped<ILeadListRepository, LeadListRepository>();
            services.AddScoped<ILeadStatusRepository, LeadStatusRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IIncomeAssesmentRepository, IncomeAssesmentRepository>();
            services.AddScoped<IDSACornerRepository, DSACornerRepository>();
            services.AddScoped<IApplicantDetailsRepository, ApplicantDetailsRepository>();
            services.AddScoped<IReportsLeadListRepository, ReportsLeadListRepository>();
            services.AddScoped<IQueryHistoryRepository, QueryHistoryRepository>();


            services.AddScoped<IRoleMasterRepository, RoleMasterRepository>();
            services.AddScoped<IPropertyDetailsRepository,PropertyDetailsRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IGSTLeadListRepository, GSTLeadListRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });
            return services;
        }
    }
}
