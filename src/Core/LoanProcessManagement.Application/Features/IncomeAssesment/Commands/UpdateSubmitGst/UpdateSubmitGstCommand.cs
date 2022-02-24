using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst
{
    public class UpdateSubmitGstCommand : IRequest<Response<UpdateSubmitGstCommandDto>>
    {
        public long Id { get; set; }
        public bool IsSubmit { get; set; }
    }
}
