using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
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

        #region Calling API for Create Menu - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling API for Create Menu - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="menuCreate"></param>
        /// <returns></returns>
        public async Task<Response<CreateMenuCommandDto>> CreateMenu(CreateMenuCommand menuCreate)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(menuCreate);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.MenuCreate,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<CreateMenuCommandDto>>(jsonString, options);

            return model;
        }
        #endregion

        #region Calling API for Update Menu - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling API for Create Menu - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="menuUpdate"></param>
        /// <returns></returns>
        public async Task<Response<UpdateMenuCommandDto>> UpdateMenu(UpdateMenuCommand menuUpdate)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(menuUpdate);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.MenuUpdate,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateMenuCommandDto>>(jsonString, options);

            return model;
        }
        #endregion

        #region Calling API for Delete Menu - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling API for Create Menu - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<DeleteMenuCommandDto>> DeleteMenu(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.MenuDelete + Id,null
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteMenuCommandDto>>(jsonString, options);

            return model;
        }
        #endregion

        #region Calling Menu for Listing Menus - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling Menu for Listing Menus - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="UserRoleId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<MenuListQueryVm>>> MenuList(long UserRoleId)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.MenuList + UserRoleId
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<MenuListQueryVm>>>(jsonString, options);

            return response;
        }
        #endregion

        #region Calling Api for getting Menu By ID - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling Api fro etting Menu By ID - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<GetMenuByIdQueryVm>> MenuById(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.MenuById + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetMenuByIdQueryVm>>(jsonString, options);

            return response;
        }
        #endregion

        public async Task<Response<List<GetAllMenusQueryVm>>> ParentList()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.ParentMenu
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<List<GetAllMenusQueryVm>>>(jsonString, options);

            return response;
        }

        public async Task<Response<IEnumerable<GetMenuMasterServicesVm>>> GetChildMenuById(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.ChildMenu + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetMenuMasterServicesVm>>>(jsonString, options);

            return response;
        }
    }
    #endregion
}