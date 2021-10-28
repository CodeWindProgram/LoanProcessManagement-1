using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Query;
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
    #region Menu Service Created While Inheriting the Interface for MenuServices - Saif Khan - 28/10/2021
    public class MenuService : IMenuService
    {
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;


        public MenuService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region Declaring the Methods & Maintaining the EndPoints - Saif Khan - 28/10/2021
        /// <summary>
        /// 28/10/2021 - Declaring the Methods & Maintaining the EndPoints
        /// Commented by Saif Khan
        /// </summary>
        /// <EndPoints>BaseUrl + APIEndPoints</EndPoints>
        /// <param name="menuProcess"></param>
        /// <returns>Model</returns>
        public async Task<Response<IEnumerable<GetMenuMasterServicesVm>>> MenuProcess(GetMenuMasterServicesQuery menuProcess)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(menuProcess);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.MenuProcess, 
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetMenuMasterServicesVm>>>(jsonString, options);

            return model;
        } 
        #endregion
    } 
    #endregion
}
