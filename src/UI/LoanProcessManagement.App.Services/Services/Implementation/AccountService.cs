using LoanProcessManagement.App.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LoanProcessManagement.App.Services.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private string BaseUrl = "";
        private HttpClient _client;
        IOptions<APIDetails> _apiDetails;

        public AccountService(HttpClient client, IOptions<APIDetails> apiDetails)
        {
            _client = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<ChangePassword>> ChangePassword(ChangePassword changePassword)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPI;

            var model = new Response<ChangePassword>();

            var content = JsonConvert.SerializeObject(changePassword);

            var httpResponse = await _client.PostAsync(BaseUrl + APIConstant.ChangePassword, new StringContent(content, Encoding.Default,
                "application/json"));

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;


            var options = new JsonSerializerOptions();
            model = System.Text.Json.JsonSerializer.Deserialize<Response<ChangePassword>>(jsonString, options);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //getStatusResponseModel = js.Deserialize<EMandateGetStatusResponseModel>(Finalresult);
            //model = JsonSerializer.Deserialize<ChangePasswordDto>(jsonString);
            //model = jsonString.DeserializeJsonObject<ChangePasswordDto>();

            return model;
        }
    }
