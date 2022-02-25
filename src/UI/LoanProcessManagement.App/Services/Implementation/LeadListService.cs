using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Commands.AddLead;
using LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class LeadListService : ILeadListService
    {
        
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;
        public LeadListService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region Lead List Service created with inheriring the ILeadListService - Saif Khan - 02/11/2021
        /// <summary>
        /// Lead List Service created with inheriring the ILeadListService  - 02/11/2021
        /// Commented By - Saif Khan
        /// <Return>Model</Return>
        /// </summary>
        public async Task<Response<IEnumerable<LeadListCommandDto>>> LeadListProcess(LeadListCommand leadListCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(leadListCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.LeadList, new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<LeadListCommandDto>>>(jsonString, options);

            return model;
        }
        #endregion

        #region Api Calling For Lead History - Saif Khan - 17/11/2021
        /// <summary>
        /// Api Calling For Lead History - Saif Khan - 17/11/2021
        /// </summary>
        /// <param name="LeadId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<LeadHistoryQueryVm>>> LeadHistory(string LeadId)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.LeadHistory + LeadId
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<LeadHistoryQueryVm>>>(jsonString, options);

            return model;
        } 
        #endregion

        #region This method will call get lead api by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call get lead api
        //	commented by Akshay
        /// </summary>
        /// <param name="leadId">leadId</param>
        /// <returns>response</returns>
        public async Task<Response<GetLeadByLeadIdDto>> GetLeadByLeadId(string leadId)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetLeadByLeadId + leadId
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetLeadByLeadIdDto>>(jsonString, options);

            return response;
        } 
        #endregion

        #region This method will call modify api by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call modify api
        //	commented by Akshay
        /// </summary>
        /// <param name="lead">lead</param>
        /// <returns>response</returns>
        public async Task<Response<UpdateLeadDto>> ModifyLead(ModifyLeadVM lead)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(lead);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                  (
                      BaseUrl + APIEndpoints.ModifyLead, new StringContent(content, Encoding.Default,
                      "application/json")
                  );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateLeadDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This action method will internally call add lead api by - Pratiksha Poshe 10/11/2021
        /// <summary>
        /// This action method will internally call add lead api by - Pratiksha Poshe 10/11/2021
        /// commented by Pratiksha
        /// </summary>
        /// <param name="leadCommandVm"></param>
        /// <returns>response from Api</returns>
        public async Task<Response<AddLeadDto>> AddLead(AddLeadCommandVM leadCommandVm)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(leadCommandVm);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddLead,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<AddLeadDto>>(jsonString, options);

            return response;
        }
        #endregion
        
        public async Task<IEnumerable<GetAllBranchesDto>> AllBranch()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.AllBranches
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetAllBranchesDto>>(jsonString, options);

            return model;
        }
        #region This action method will Internally Call leadStatus API and return InPrincipleSanctionList by - Raj Bhosale - 15/02/2022
        public async Task<List<ProcessModel>> InPrincipleSanctionList(GetInPrincipleSanctionListQuery SanctionList)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");
            var content = JsonConvert.SerializeObject(SanctionList);

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.InPrincipleList,new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<List<ProcessModel>>(jsonString, options);

            return model;
        }
        #endregion

        #region This action method will Internally Call leadStatus API and return InPrincipleSanctionList by - Raj Bhosale - 15/02/2022
        public async Task<List<ProcessModel>> HOSanctionList(GetHOSanctionListQuery SanctionList)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");
            var content = JsonConvert.SerializeObject(SanctionList);

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.HOSanctionList, new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<List<ProcessModel>>(jsonString, options);

            return model;
        }
        #endregion
        public async Task<GetAllBranchesDto> BranchById(long Id)
            {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.BrancheById + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<GetAllBranchesDto>(jsonString, options);

            return model;
        }

        public async Task<IEnumerable<GetLeadStatusQueryVm>> LeadByBranchId(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.LeadByBranchId + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetLeadStatusQueryVm>>(jsonString, options);

            return model;
        }

        public async Task<IEnumerable<GetLeadNameByLgIdQueryVm>> LeadByLgId(string LgId)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.LeadByLgId + LgId
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetLeadNameByLgIdQueryVm>>(jsonString, options);

            return model;
        }

        public async Task<IEnumerable<LeadListByIdModel>> GetLeadListById(GetLeadListByIdQuery leadListByIdQuery)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");
            var content = JsonConvert.SerializeObject(leadListByIdQuery);

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.LeadListById, new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<LeadListByIdModel>>(jsonString, options);

            return model;
        }
        public async Task<bool> VerifyFormNo(string formNo)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.FormNo + formNo
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<bool>(jsonString, options);
            model = !model;
            return model;
        }
    }
}
