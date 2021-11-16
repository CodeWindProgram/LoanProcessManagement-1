using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList
{
    public class RoleMasterListQueryHandler : IRequestHandler<RoleMasterListQuery, Response<IEnumerable<RoleMasterListVm>>>
    {
        private readonly IAsyncRepository<LpmUserRoleMaster> _RoleMasterRepository;
        private readonly IMapper _mapper;

        public RoleMasterListQueryHandler(IMapper mapper, IAsyncRepository<LpmUserRoleMaster> RoleMasterRepository)
        {
            _mapper = mapper;
            _RoleMasterRepository = RoleMasterRepository;
        }

        #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will call RoleMasterRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="RoleMasterRepository">RoleMasterRepository</param>
        /// <returns>RoleMasterRepository</returns>

        public async Task<Response<IEnumerable<RoleMasterListVm>>> Handle(RoleMasterListQuery request, CancellationToken cancellationToken)
        {
            // throw new NotImplementedException();
            var allEvents = (await _RoleMasterRepository.ListAllAsync()).OrderBy(x => x.Id);
            var eventList = _mapper.Map<List<RoleMasterListVm>>(allEvents);
            var response = new Response<IEnumerable<RoleMasterListVm>>(eventList);
            return response;
        }
        #endregion
    }
}
