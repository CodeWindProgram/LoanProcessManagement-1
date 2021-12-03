using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.PropertyDetails.Queries
{
    #region added GetPropertyDetailsQuery -added by- Ramya Guduru - 15/11/2021
    public class GetPropertyDetailsQuery : IRequest<Response<GetPropertyDetailsDto>>
    {
        public GetPropertyDetailsQuery(string lead_Id)
        {
            Lead_Id = lead_Id;
        }
        public string Lead_Id { get; set; }
    }
    #endregion
}
