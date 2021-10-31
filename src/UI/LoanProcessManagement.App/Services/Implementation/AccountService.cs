using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Features.User.Commands.RemoveUser;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;

        public AccountService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region This method will call actual api and return response for change Password API - Ramya Guduru - 28/10/2021
        /// <summary>
        /// 2021/10/28 - Change Password API call
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="changePassword">Change Password model parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<ChangePasswordDto>> ChangePassword(ChangePasswordCommand changePassword)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(changePassword);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.ChangePassword, 
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<ChangePasswordDto>>(jsonString, options);

            return model;
        } 
        #endregion

        #region This method will call authenticate api and return response to action method by - Akshay Pawar - 28/10/2021
        /// <summary>
        /// 2021/10/28 - While calling api we have to pass user object 
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object which will contain (EmployeeId and Password)</param>
        /// <returns>Response</returns>
        public async Task<UserAuthenticationResponse> AuthenticateUser(UserAuthenticationRequestVM user)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(user);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AuthenticateUser, 
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<UserAuthenticationResponse>(jsonString, options);

            return response;

        }
        #endregion

        #region This action method will internally call add user api by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call add user api 
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object </param>
        /// <returns>response from api</returns>
        public async Task<Response<CreateUserDto>> RegisterUser(CreateUserCommandVM user)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(user);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.RegisterUser,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<CreateUserDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This action method will internally call add remove api by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call add remove api 
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid </param>
        /// <returns>response from api</returns>
        public async Task<Response<RemoveUserDto>> RemoveUser(string lgid)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.RemoveUser + $"{lgid}",
                    null

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<RemoveUserDto>>(jsonString, options);

            return response;
        } 
        #endregion
    }
}
