using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment
{
    class AddIncomeAssessmentDetailsCommandHandler : IRequestHandler<AddIncomeAssessmentDetailsCommand, Response<AddIncomeAssessmentDetailsDto>>
    {
        private readonly ILogger<AddIncomeAssessmentDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
        public AddIncomeAssessmentDetailsCommandHandler(ILogger<AddIncomeAssessmentDetailsCommandHandler> logger, IMapper mapper, IIncomeAssesmentRepository incomeAssesmentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _incomeAssesmentRepository = incomeAssesmentRepository;
        }

        #region Add Income Assessment Handler Method - Pratiksha Poshe - 15-02-2022
        /// <summary>
        /// 15-02-2021 - Add Income Assessment Handler Method
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<AddIncomeAssessmentDetailsDto>> Handle(AddIncomeAssessmentDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var incomeAssessmentDetailsCommandResponse = new Response<AddIncomeAssessmentDetailsDto>();
            var incomeDetails = new IncomeAssessmentDetailsModel()
            {

                FormNo = request.FormNo,
                ApplicantType = request.ApplicantType,
                CreatedBy = request.CreatedBy,
                LastModifiedBy = request.LastModifiedBy,
                lead_Id = request.lead_Id,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                EmployerName1 = request.EmployerName1,
                EmployerName2 = request.EmployerName2,
                EmployerName3 = request.EmployerName3,
                EmployerName4 = request.EmployerName4,
                EmployerName5 = request.EmployerName5,
                FileType = request.FileType,
                Institution_Id = request.Institution_Id,
                DocumentType = request.DocumentType,
                FilePassword = request.FilePassword,
                PdfFileName = request.PdfFileName,
            };
            var incomeDetailsDto = await _incomeAssesmentRepository.AddIncomeAssessmentDetailsAsync(incomeDetails);

            _logger.LogInformation("Handle Completed");

            if (incomeDetailsDto.Succeeded)
            {
                incomeAssessmentDetailsCommandResponse.Data = _mapper.Map<AddIncomeAssessmentDetailsDto>(incomeDetailsDto);
                incomeAssessmentDetailsCommandResponse.Succeeded = true;
                incomeAssessmentDetailsCommandResponse.Message = incomeDetailsDto.Message;
            }
            else
            {
                incomeAssessmentDetailsCommandResponse.Succeeded = false;
                incomeAssessmentDetailsCommandResponse.Message = incomeDetailsDto.Message;
            }
            return incomeAssessmentDetailsCommandResponse;
        } 
        #endregion
    }
}
