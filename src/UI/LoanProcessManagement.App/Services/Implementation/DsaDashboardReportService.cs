using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
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
    public class DsaDashboardReportService : IDsaDashboardReportService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;
        public DsaDashboardReportService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        public async Task<Response<List<DsaDashboardReportDto>>> DsaDashboardService(DsaDashboardReportQuery dsaDashboard)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");
            var content = JsonConvert.SerializeObject(dsaDashboard);

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.DsaDashboardReport, new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<List<DsaDashboardReportDto>>>(jsonString, options);

            return model;
        }
    }
}
