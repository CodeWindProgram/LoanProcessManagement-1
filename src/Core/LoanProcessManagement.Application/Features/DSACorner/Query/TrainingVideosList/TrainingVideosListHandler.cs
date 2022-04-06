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

namespace LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList
{
    public class TrainingVideosListHandler : IRequestHandler<TrainingVideosListQuery, Response<IEnumerable<TrainingVideosListVm>>>
    {
        private readonly IDSACornerRepository _dsaCornerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TrainingVideosListHandler> _logger;

        public TrainingVideosListHandler(IMapper mapper, IDSACornerRepository dsaCornerRepository, ILogger<TrainingVideosListHandler> logger)
        {
            _mapper = mapper;
            _dsaCornerRepository = dsaCornerRepository;
            _logger = logger;
        }

        #region added handler to get all dsa training videos list - Ramya Guduru - 25-11-2021
        public async Task<Response<IEnumerable<TrainingVideosListVm>>> Handle(TrainingVideosListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initited");
            var trainingVideosList = await _dsaCornerRepository.TrainingVideosList(request.ParentId);
            var trainingVideosrDto = _mapper.Map<IEnumerable<TrainingVideosListVm>>(trainingVideosList);
            var response = new Response<IEnumerable<TrainingVideosListVm>>(trainingVideosrDto);
            _logger.LogInformation("Handle Completed");
            return response;
        }
        #endregion
    }
}
