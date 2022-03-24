using LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification;
using LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationById;
using LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IQualificationService
    {
        #region added service to call Qualification api added by - Dipti Pandhram - 23/03/2022

        Task<Response<QualificationDto>> AddQualification(CreateQualificationCommand req);
        Task<Response<DeleteQualificationDto>> DeleteQualification(long id);
        Task<Response<GetQualificationByIdDto>> GetQualificationById(long id);
        Task<Response<UpdateQualificationDto>> UpdateQualification(UpdateQualificationCommand req);
        Task<Response<IEnumerable<GetQualificationListDto>>> GetAllQualification();
       
        #endregion

    }
}
