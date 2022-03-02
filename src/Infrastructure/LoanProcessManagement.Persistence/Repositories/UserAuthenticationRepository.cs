using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Features.User.Commands.RemoveUser;
using LoanProcessManagement.Application.Features.User.Commands.UpdateUser;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Domain.Entities;
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
                response.Message = "Invalid Credentials";
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
                response.Message = "Invalid credentials";
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
            response.Name = result.Name;
            response.BranchID = result.BranchId;
            response.Branch = result.Branch.branchname;
            response.Role = result.UserRole.Rolename;
            response.UserRoleId = result.UserRoleId;
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

        #region This method will add user in db by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This method will add user in db
        //	commented by Akshay
        /// </summary>
        /// <param name="request">User object</param>
        /// <returns>Response</returns>
        public async Task<CreateUserDto> RegisterUserAsync(LpmUserMaster request)
        {
            var user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
                        .Where(x => x.EmployeeId == request.EmployeeId).FirstOrDefaultAsync();
            CreateUserDto response = new CreateUserDto();

            if (user != null)
            {
                response.Message = "Employee id already exists .";
                response.Succeeded = false;
                return response;
            }

            user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
                        .Where(x => x.Email == request.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                response.Message = "Email Already exists .";
                response.Succeeded = false;
                return response;
            }

            user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
            .Where(x => x.PhoneNumber == request.PhoneNumber).FirstOrDefaultAsync();
            if (user != null)
            {
                response.Message = "Phone number already exists .";
                response.Succeeded = false;
                return response;
            }
            var pwd = "Welcome2loan";
            var encryptedPwd = EncryptionDecryption.EncryptString(pwd);
            request.Password = encryptedPwd;
            request.SaltKey = "key";
            request.WrongLoginAttempt = 0;
            request.IsLocked = false;
            request.IsActive = true;
            request.LgId = "LG_";
            await _dbContext.LpmUserMasters.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            request.LgId = request.LgId + request.Id;
            await _dbContext.SaveChangesAsync();
            response.EmpId = request.EmployeeId;
            response.Password = pwd;
            response.Email = request.Email;
            response.Message = "User registered successfully .";
            response.Succeeded = true;
            return response;
        }
        #endregion

        #region This method will remove user from db by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This method will remove user from db
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <returns>Response</returns>
        public async Task<RemoveUserDto> RemoveUserAsync(string lgid)
        {
            var user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
            .Where(x => x.LgId == lgid).FirstOrDefaultAsync();
            RemoveUserDto response = new RemoveUserDto();

            if (user != null)
            {
                user.IsActive = false;
                await _dbContext.SaveChangesAsync();
                response.LgId = lgid;
                response.Message = $"User of id:{lgid} has been removed successfully .";
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.LgId = lgid;
                response.Message = $"User of id:{lgid} does not exists .";
                response.Succeeded = false;
                return response;
            }
        }
        #endregion

        #region This method update user by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method update user
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <param name="request">request</param>
        /// <returns>UpdateUserDto</returns>
        public async Task<UpdateUserDto> UpdateUserAsync(string lgid, UpdateUserCommand request)
        {
            var user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
            .Where(x => x.EmployeeId == request.EmployeeId && x.LgId != lgid).FirstOrDefaultAsync();
            UpdateUserDto response = new UpdateUserDto();

            if (user != null)
            {
                response.Message = "Employee id already exists .";
                response.Succeeded = false;
                return response;
            }

            user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
             .Where(x => x.Email == request.Email && x.LgId != lgid).FirstOrDefaultAsync();
            if (user != null)
            {
                response.Message = "Email Already exists .";
                response.Succeeded = false;
                return response;
            }

            user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
            .Where(x => x.PhoneNumber == request.PhoneNumber && x.LgId != lgid).FirstOrDefaultAsync();
            if (user != null)
            {
                response.Message = "Phone number already exists .";
                response.Succeeded = false;
                return response;
            }
            var userToUpdate = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
            .Where(x => x.LgId == lgid).FirstOrDefaultAsync();

            if (userToUpdate != null)
            {
                userToUpdate.EmployeeId = request.EmployeeId;
                userToUpdate.Email = request.Email;
                userToUpdate.PhoneNumber = request.PhoneNumber;
                userToUpdate.BranchId = request.BranchId;
                userToUpdate.UserRoleId = request.UserRoleId;
                userToUpdate.Name = request.Name;
                await _dbContext.SaveChangesAsync();
                response.Message = "User details Updated Successfully";
                response.Succeeded = true;
                response.EmployeeId = userToUpdate.EmployeeId;
                return response;

            }
            else
            {
                response.Message = "User doesn't exists .";
                response.Succeeded = false;
                response.EmployeeId = userToUpdate.EmployeeId;
                return response;
            }


        }
        #endregion

        #region This method get user by lgid by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method get user by lgid
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <returns>LpmUserMaster</returns>
        public async Task<LpmUserMaster> GetUserAsync(string lgid)
        {
            var user = await _dbContext.LpmUserMasters.Include(x => x.Branch).Include(x => x.UserRole)
            .Where(x => x.LgId == lgid).FirstOrDefaultAsync();
            return user;
        } 
        #endregion
    }
}
