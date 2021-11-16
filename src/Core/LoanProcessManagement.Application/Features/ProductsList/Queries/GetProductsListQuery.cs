using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ProductsList.Queries
{
    #region added GetProductsListQuery to get all products list - added by - Ramya Guduru - 15/11/2021
    public class GetProductsListQuery:IRequest<Response<IEnumerable<GetProductsListQueryVm>>>
    {
        public GetProductsListQuery(string lead_Id)
        {
            Lead_Id = lead_Id;
        }
        public string Lead_Id { get; set; }
    }
    #endregion
}
