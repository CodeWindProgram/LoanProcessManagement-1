using AutoMapper;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command
{
    //class AddThirdPartyCheckDetailsCommandHandler : IRequestHandler<AddThirdPartyCheckDetailsCommand, Response<AddThirdPartyCheckDetailsDto>>
    //{
    //    private readonly ILogger<AddThirdPartyCheckDetailsCommandHandler> _logger;
    //    private readonly IMapper _mapper;


    //    public AddThirdPartyCheckDetailsCommandHandler(ILogger<AddThirdPartyCheckDetailsCommandHandler> logger, IMapper mapper)
    //    {
    //        _logger = logger;
    //        _mapper = mapper;
    //    }

    //    public Task<Response<AddThirdPartyCheckDetailsDto>> Handle(AddThirdPartyCheckDetailsCommand request, CancellationToken cancellationToken)
    //    {
    //        _logger.LogInformation("Handle Initiated");
    //        var thirdPartyCheckDetails = _mapper.Map<LpmThirdPartyCheckDetails>(request);
    //        _logger.LogInformation("Handle Completed");
    //    }
    //}
}
