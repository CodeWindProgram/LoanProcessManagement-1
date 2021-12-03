using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.DSACorner.Query.CircularList
{
    public class CircularListHandler : IRequestHandler<CircularListQuery, Response<IEnumerable<CircularListVm>>>
    {
        private readonly IDSACornerRepository _dsaCornerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CircularListHandler(IMapper mapper, IDSACornerRepository dsaCornerRepository)
        {
            _mapper = mapper;
            _dsaCornerRepository = dsaCornerRepository;
        }
        #region added handler to get all dsa circular list - Ramya Guduru - 25-11-2021
        public async Task<Response<IEnumerable<CircularListVm>>> Handle(CircularListQuery request, CancellationToken cancellationToken)
        {
            var circularList = await _dsaCornerRepository.CircularList(request.ParentId);
            var circularDto = _mapper.Map<IEnumerable<CircularListVm>>(circularList);
            var response = new Response<IEnumerable<CircularListVm>>(circularDto);
            return response;
        }
        #endregion
    }
}
