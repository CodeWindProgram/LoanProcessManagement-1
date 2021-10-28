using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
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
        private HttpClient _client;
        IOptions<APIConfiguration> _apiDetails;

        public AccountService(HttpClient client, IOptions<APIConfiguration> apiDetails)
        {
            _client = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<ChangePasswordDto>> ChangePassword(ChangePasswordDto changePassword)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var model = new Response<ChangePasswordDto>();

            var content = JsonConvert.SerializeObject(changePassword);

            var httpResponse = await _client.PostAsync(BaseUrl + APIEndpoints.ChangePassword, new StringContent(content, Encoding.Default,
                "application/json"));

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;


            var options = new JsonSerializerOptions();
            model = System.Text.Json.JsonSerializer.Deserialize<Response<ChangePasswordDto>>(jsonString, options);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //getStatusResponseModel = js.Deserialize<EMandateGetStatusResponseModel>(Finalresult);
            //model = JsonSerializer.Deserialize<ChangePasswordDto>(jsonString);
            //model = jsonString.DeserializeJsonObject<ChangePasswordDto>();

            return model;
        }

        #region This method will call actual api and return response to action method by - Akshay Pawar - 28/10/2021
        /// <summary>
        /// 2021/10/28 - While calling api we have to pass user object 
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object which will contain (EmployeeId and Password)</param>
        /// <returns>Response</returns>
        public async Task<UserAuthenticationResponse> AuthenticateUser(UserAuthenticationRequestVM user)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;
            var response = new UserAuthenticationResponse();
            var content = JsonConvert.SerializeObject(user);
            var httpResponse = await _client.PostAsync(BaseUrl + APIEndpoints.AuthenticateUser, new StringContent(content, Encoding.Default,
               "application/json"));
            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions();
            response = System.Text.Json.JsonSerializer.Deserialize<UserAuthenticationResponse>(jsonString, options);
            return response;

        } 
        #endregion
    }
}
