using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.GSTLeadList.Queries
{
    public class GetGSTLeadListQueryHandler : IRequestHandler<GetGSTLeadListQuery, Response<IEnumerable<GetGSTLeadListQueryVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IGSTLeadListRepository _GSTLeadListRepository;
        public GetGSTLeadListQueryHandler(IMapper mapper, IGSTLeadListRepository GSTLeadListRepository)
        {
            _GSTLeadListRepository = GSTLeadListRepository;
            _mapper = mapper;
        }

        #region handler For the GSTLeadListRepository handler - Ramya Guduru - 16/11/2021
        /// <summary>
        /// 16/10/2021 - Logger For the GSTLeadListRepository handler
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetGSTLeadListQueryVm>>> Handle(GetGSTLeadListQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var leadList = await _GSTLeadListRepository.GetGSTLeadList(request.BranchID);

            var productsList = _mapper.Map<IEnumerable<GetGSTLeadListQueryVm>>(leadList);

            return new Response<IEnumerable<GetGSTLeadListQueryVm>>(productsList, "success Message");
        }
        #endregion
    }
}
