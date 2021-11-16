using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword;
using LoanProcessManagement.Application.Features.ProductsList.Queries;
using LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails;
using LoanProcessManagement.Application.Features.PropertyDetails.Queries;
using LoanProcessManagement.Application.Features.PropertyType.Queries;
using LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount;
using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Features.User.Commands.RemoveUser;
using LoanProcessManagement.Application.Features.User.Commands.UpdateUser;
using LoanProcessManagement.Application.Features.User.Queries;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        #region This method will call actual api and return response for Unlock user account API - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/29 - Unlock user account API call
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="UnlockUserAccount">unlock user account model parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<UnlockUserAccountDto>> UnlockUserAccount(UnlockUserAccountCommand unlockUserAccount)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(unlockUserAccount);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.UnlockUserAccount,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<UnlockUserAccountDto>>(jsonString, options);

            return model;

        }
        #endregion

        #region This method will call actual api and return response for UnlockAndResetPassword account API - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/29 - UnlockAndResetPassword API call
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="UnlockAndResetPassword">UnlockAndResetPassword  model parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<UnlockAndResetPasswordDto>> UnlockAndResetPassword(UnlockAndResetPasswordCommand unlockAndReset)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(unlockAndReset);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.UnlockAndResetPassword,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<UnlockAndResetPasswordDto>>(jsonString, options);

            return model;

        }
        #endregion

        #region This method will call actual api and return response for ActivateUserAccount account API - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/29 - ActivateUserAccountCommand API call
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ActivateUserAccountCommand">ActivateUserAccountCommand  model parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<ActivateUserAccountDto>> ActivateUserAccount(ActivateUserAccountCommand activateUserAccount)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(activateUserAccount);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.ActivateUserAccount,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<ActivateUserAccountDto>>(jsonString, options);

            return model;
        }
        #endregion

        #region This method will call actual api and return response for ForgotPassword  API - Ramya Guduru - 01/11/2021
        /// <summary>
        /// 2021/11/01 - ForgotPassword API call
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ForgotPassword">ForgotPassword  model </param>
        /// <returns>Response</returns>
        public async Task<Response<ForgotPasswordDto>> ForgotPassword(ForgotPasswordCommand forgotPassword)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(forgotPassword);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.ForgotPassword,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<ForgotPasswordDto>>(jsonString, options);

            return model;
        }

        #endregion

        #region This method will call get user api by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call get user api
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <returns>GetUserByLgIdDto</returns>
        public async Task<Response<GetUserByLgIdDto>> GetUser(string lgid)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetUser + lgid
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetUserByLgIdDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This method will call update user api by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call update user api
        //	commented by Akshay
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>UpdateUserDto</returns>
        public async Task<Response<UpdateUserDto>> UpdateUser(CreateUserCommandVM user)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(user);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateUser,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateUserDto>>(jsonString, options);

            return response;
        }
        #endregion


        #region This method will call actual api and return response for getproperty type, sanctioned plans and all property details API - Ramya Guduru - 28/10/2021
        /// <summary>
        /// 2021/10/28 - get property details API call
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="get Property Details">Get Property Details model parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<GetPropertyDetailsDto>> GetProperty(string lead_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetProperty + lead_Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetPropertyDetailsDto>>(jsonString, options);

            return response;
        }

        public async Task<IEnumerable<GetAllpropertyTypeDto>> GetAllPropertyType()
        {
            //throw new NotImplementedException();
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetPropertyType
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetAllpropertyTypeDto>>(jsonString, options);

            return response;
        }

        public async Task<IEnumerable<GetSanctionedPlanDto>> GetSanctionedPlan()
        {
            //throw new NotImplementedException();
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetSanctionedPlan
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetSanctionedPlanDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This method will call update property details api by - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call update property details api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="Property">Property</param>
        /// <returns>UpdatePropertyDetailsDto</returns>
        public async Task<Response<UpdatePropertyDetailsDto>> UpdateProperty(UpdatePropertyDetailsCommand property)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(property);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateProperties,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<UpdatePropertyDetailsDto>>(jsonString, options);

            return model;
        }
        #endregion

    }
}

