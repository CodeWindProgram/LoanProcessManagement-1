using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    #region Created the services for user list by inheriting the Interface - Saif Khan - 29/10/2021
    public class UserListService : IUserListService
    {
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;


        public UserListService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region Declaring the Methods & Maintaining the EndPoints - Saif Khan - 29/10/2021
        /// <summary>
        /// 28/10/2021 - Declaring the Methods & Maintaining the EndPoints
        /// Commented by Saif Khan
        /// </summary>
        /// <EndPoints>BaseUrl + APIEndPoints</EndPoints>
        /// <param name="userListProcess"></param>
        /// <returns>Model</returns>
        public async Task<Response<IEnumerable<GetUserListQueryVm>>> UserListProcess(GetUserListQuery userListProcess)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(userListProcess);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.UserList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetUserListQueryVm>>>(jsonString, options);

            return model;
        } 
        #endregion

        
    }
    #endregion
}