using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Features.UserList.Query.GetLockedUserList;
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

        #region Declaring the Methods & Maintaining the EndPoints for Locked User List - Pratiksha Poshe - 12/12/2021
        /// <summary>
        /// 12/12/2021 - Declaring the Methods & Maintaining the EndPoints for Locked User List
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <EndPoints>BaseUrl + APIEndPoints</EndPoints>
        /// <param name="userListProcess"></param>
        /// <returns>Model</returns>
        public async Task<Response<IEnumerable<GetLockedUserListQueryVm>>> LockedUserListProcess(GetLockedUserListQuery lockedUserListProcess)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(lockedUserListProcess);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.LockedUserList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetLockedUserListQueryVm>>>(jsonString, options);

            return model;
        }
        #endregion

    }
    #endregion
}