using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIsSubmitFromGst
{
    public class GetIsSubmitFromGstQuery : IRequest<Response<LpmLeadApplicantsDetails>>
    {
        public GetIsSubmitFromGstQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
