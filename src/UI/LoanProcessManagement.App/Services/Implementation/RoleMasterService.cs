using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.DeleteRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class RoleMasterService : IRoleMasterService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public RoleMasterService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<IEnumerable<RoleMasterListVm>>> RoleListProcess()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.RoleList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<RoleMasterListVm>>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetAllMenuMapsQueryVm>> CreateChecklist(GetAllMenuMapsQuery checklistCreate)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(checklistCreate);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.RoleMap,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<GetAllMenuMapsQueryVm>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<GetTheMenuMapsCommandDto>>> GetCheckList()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllMenuMaps
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetTheMenuMapsCommandDto>>>(jsonString, options);

            return response;
        }

        
        public async Task<Response<DeleteMenuMapByIdCommandDto>> DeleteMenuMapById(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteRoleMapById+ Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteMenuMapByIdCommandDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<CreateRoleMasterCommandDto>> CreateRoleMaster(CreateRoleMasterCommand createRoleMasterCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(createRoleMasterCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.RoleList,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<CreateRoleMasterCommandDto>>(jsonString, options);

            return model;
        }

        
        public GetRoleMasterByIdDto GetRoleMasterByIdAsync(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;
            var _client = clientfact.CreateClient("LoanService");
            var result = new GetRoleMasterByIdDto();
            var uri = BaseUrl + APIEndpoints.Role+id;
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<GetRoleMasterByIdDto>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public async Task<Response<UpdateRoleMasterDto>> UpdateRoleMaster(UpdateRoleMasterCommand lpmUserRoleMaster)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(lpmUserRoleMaster);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.RoleList,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize <Response<UpdateRoleMasterDto>>(jsonString, options);

            return model;
        }

        public async Task<Response<DeleteRoleMasterDto>> DeleteRoleMaster(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.Role + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteRoleMasterDto>>(jsonString, options);

            return response;
        }
    }
}
    

