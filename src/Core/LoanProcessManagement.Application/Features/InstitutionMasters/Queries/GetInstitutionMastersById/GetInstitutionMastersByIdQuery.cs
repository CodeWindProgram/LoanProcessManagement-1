using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMastersById
{
   public  class GetInstitutionMastersByIdQuery :IRequest<Response<GetInstitutionMastersByIdQueryVm>>
    {
        public GetInstitutionMastersByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
