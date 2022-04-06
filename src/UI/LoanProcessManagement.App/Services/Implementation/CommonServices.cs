using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LineChart.Queries.GetLoanByCurrentStatus;
using LoanProcessManagement.Application.Features.LoanProducts.Queries;
using LoanProcessManagement.Application.Features.LoanSchemes;
using LoanProcessManagement.Application.Features.LoanSchemes.Queries;
using LoanProcessManagement.Application.Features.Product.Queries;
using LoanProcessManagement.Application.Features.Roles.Queries;
using LoanProcessManagement.Application.Responses;
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
    public class CommonServices : ICommonServices
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public CommonServices(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region This action method will internally call get all roles api by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call get all roles api 
        //	commented by Akshay
        /// </summary>
        /// <returns>response from api</returns>
        public async Task<IEnumerable<GetAllRolesDto>> GetAllRoles()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetRoles
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetAllRolesDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This action method will internally call get all branches api by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call get all branches api 
        //	commented by Akshay
        /// </summary>
        /// <returns>response from api</returns>
        public async Task<IEnumerable<GetAllBranchesDto>> GetAllBranches()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetBranches
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetAllBranchesDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This method will call get status api by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call get status api
        //	commented by Akshay
        /// </summary>
        /// <param name="role">role</param>
        /// <returns>response</returns>
        public async Task<Response<IEnumerable<GetLeadStatusDto>>> GetAllStatus(string role)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetStatus + role
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetLeadStatusDto>>>(jsonString, options);

            return response;
        }

        #endregion
        #region This method will call get loan products api by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call get loan products api
        //	commented by Akshay
        /// </summary>
        /// <returns>response</returns>

        public async Task<Response<IEnumerable<GetLoanProductsDto>>> GetAllLoanProduct()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetLoanProducts
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetLoanProductsDto>>>(jsonString, options);

            return response;
        } 
        #endregion

        #region This method will call get insurance products api by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call get insurance products api
        //	commented by Akshay
        /// </summary>
        /// <returns>response</returns>
        public async Task<Response<IEnumerable<GetInsuranceProductsDto>>> GetAllInsuranceProducts()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetInsuranceProducts
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetInsuranceProductsDto>>>(jsonString, options);

            return response;
        }
        #endregion

        #region This action method will internally call get all Loan Products api by - Pratiksha Poshe 10/11/2021
        /// <summary>
        /// 10/11/2021 - This action method will internally call get all Loan Products api by - Pratiksha Poshe 
        /// Commented by Pratiksha
        /// </summary>
        /// <returns>response from Api</returns>
        public async Task<IEnumerable<GetAllLoanProductsDto>> GetAllLoanProducts()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllLoanProducts
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GetAllLoanProductsDto>>(jsonString, options);

            return response;
        }


        #endregion
        public async Task<Response<GetLeadStatusCountDto>> GetAllStatusCount(GetLeadStatusCountQuery req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.GetStatusCount,
                     new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetLeadStatusCountDto>>(jsonString, options);

            return response;
        }

        #region This action method will internally call get all Loan Scheme api by - Pratiksha Poshe 05/12/2021
        /// <summary>
        /// 05/12/2021 -  This action method will internally call get all Loan Scheme api 
        /// Commented by Pratiksha
        /// </summary>
        /// <returns>response from Api</returns>
        public async Task<Response<IEnumerable<GetAllLoanSchemeDto>>> GetAllLoanScheme()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllLoanSchemes
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetAllLoanSchemeDto>>>(jsonString, options);

            return response;
        }
        #endregion

        #region This action method will internally call get all Loan Scheme by ProductId api by - Pratiksha Poshe 05/12/2021
        /// <summary>
        /// 05/12/2021 -  This action method will internally call get all Loan Scheme by ProductId api
        /// Commented by Pratiksha
        /// </summary>
        /// <returns>response from Api</returns>
        public async Task<Response<IEnumerable<GetLoanSchemesByProductIdDto>>> GetAllLoanSchemeByProductId(long Product_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    //BaseUrl + APIEndpoints.GetAllLoanSchemesByProductId + "/" + Product_Id
                    $"{BaseUrl}{APIEndpoints.GetAllLoanSchemesByProductId}/{Product_Id}"
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetLoanSchemesByProductIdDto>>>(jsonString, options);

            return response;
        }
        #endregion
        //public async Task<List<long?>> GetLoanAmount(GetLoanByCurrentStatusQuery req)
        //{
        //    BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

        //    var content = JsonConvert.SerializeObject(req);

        //    var _client = clientfact.CreateClient("LoanService");

        //    //var httpResponse = await _client.GetAsync
        //    //    (
        //    //        BaseUrl + APIEndpoints.GetLoan + req.LgId + req.
        //    //    );
        //    var httpResponse = await _client.PostAsync
        //        (
        //            BaseUrl + APIEndpoints.GetLoan,
        //             new StringContent(content, Encoding.Default,
        //            "application/json")
        //        );

        //    var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

        //    var options = new JsonSerializerOptions();

        //    var response = System.Text.Json.JsonSerializer.Deserialize<List<long?>>(jsonString, options);

        //    return response;
        //}
    }
}
