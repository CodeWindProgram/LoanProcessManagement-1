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

namespace LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList
{
    public class DSACornerListHandler : IRequestHandler<DSACornerListQuery, Response<IEnumerable<DSACornerListVm>>>
    {
        private readonly IDSACornerRepository _dsaCornerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DSACornerListHandler(IMapper mapper, IDSACornerRepository dsaCornerRepository)
        {
            _mapper = mapper;
            _dsaCornerRepository = dsaCornerRepository;
        }
        #region added handler to get all dsa corner list - Ramya Guduru - 25-11-2021
        public async Task<Response<IEnumerable<DSACornerListVm>>> Handle(DSACornerListQuery request, CancellationToken cancellationToken)
        {
            
            var dsaCornerList = await _dsaCornerRepository.GetDSACornerList(request.ParentId);
            var dsaCornerDto = _mapper.Map<IEnumerable<DSACornerListVm>>(dsaCornerList);
            var response = new Response<IEnumerable<DSACornerListVm>>(dsaCornerDto);
            return response;
        }
        #endregion
    }
}
