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
        private HttpClient _client;
        IOptions<APIConfiguration> _apiDetails;

        public MenuService(HttpClient client, IOptions<APIConfiguration> apiDetails)
        {
            _client = client;
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

            var model = new Response<IEnumerable<GetMenuMasterServicesVm>>();

            var content = JsonConvert.SerializeObject(menuProcess);

            var httpResponse = await _client.PostAsync(BaseUrl + APIEndpoints.MenuProcess, new StringContent(content, Encoding.Default,
                "application/json"));

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;


            var options = new JsonSerializerOptions();
            model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetMenuMasterServicesVm>>>(jsonString, options);

            return model;
        } 
        #endregion
    } 
    #endregion
}
