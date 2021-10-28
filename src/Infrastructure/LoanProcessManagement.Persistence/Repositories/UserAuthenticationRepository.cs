using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UserAuthenticationRepository> _logger;
        private readonly JwtSettings _jwtSettings;
        public UserAuthenticationRepository(IMapper mapper,
            ApplicationDbContext dbContext,
            IOptions<JwtSettings> jwtSettings,
            ILogger<UserAuthenticationRepository> logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
            _jwtSettings = jwtSettings.Value;
            ;
        }

        #region Authenticating user and Generating jwt By - Akshay Pawar - 28/10/2021
        /// <summary>
        /// 2021/10/28 - User Authentication functionality
        //	commented by Akshay
        /// </summary>
        /// <param name="request">User object which will contain (EmployeeId and Password)</param>
        /// <returns>Response</returns>
        public async Task<UserAuthenticationResponse> AuthenticateUserAsync(UserAuthenticationRequest request)
        {
            _logger.LogInformation("User Authentication Initiated");
            var user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
                .Where(x => x.EmployeeId == request.EmployeeId).FirstOrDefaultAsync();
            UserAuthenticationResponse response = new UserAuthenticationResponse();
            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = "User does not exist .";
                _logger.LogInformation("User Authentication failed");
                return response;
            }
            string encryptedPwd = EncryptionDecryption.EncryptString(request.Password);

            var result = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
                .Where(x => x.EmployeeId == request.EmployeeId && x.Password == encryptedPwd).FirstOrDefaultAsync();
            if (result == null)
            {
                user.WrongLoginAttempt = user.WrongLoginAttempt + 1;
                if (user.WrongLoginAttempt >= 5)
                {
                    user.IsLocked = true;
                    user.IsActive = false;
                }
                await _dbContext.SaveChangesAsync();
                response.IsAuthenticated = false;
                response.Message = "Invalid credentials .";
                _logger.LogInformation("User Authentication failed");

                return response;
            }
            if (result.IsLocked)
            {
                response.IsAuthenticated = false;
                response.Message = "This account has been locked .";
                _logger.LogInformation("User Authentication failed");
                return response;
            }
            JwtSecurityToken jwtSecurityToken = GenerateToken(result);
            //var userRole = await _dbContext.LpmUserMasters.Where(x => x.Id == result.UserRoleId).FirstOrDefaultAsync();
            response.IsAuthenticated = true;
            response.Message = "Success";
            response.Id = result.EmployeeId;
            response.Lg_id = result.LgId;
            response.Email = result.Email;
            response.Role = result.UserRole.Rolename;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            result.WrongLoginAttempt = 0;
            result.LastLogin = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("User Authentication succeeded");
            return response;
        }
        #endregion

        #region Generating jwtSecurityToken which will be used to generate jwt token By - Akshay Pawar - 28/10/2021
        /// <summary>
        /// 2021/10/28 - Using this method to generate jwtSecurityToken which we will
        /// use in AuthenticateUserAsync method to generate jwt token.
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User from DB</param>
        /// <returns>JwtSecurityToken object</returns>
        private JwtSecurityToken GenerateToken(Domain.Entities.LpmUserMaster user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim("emp_id", user.EmployeeId),
            };

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: credentials);

            return jwtSecurityToken;
        } 
        #endregion
    }
}
