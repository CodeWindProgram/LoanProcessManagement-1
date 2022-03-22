using LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
   public  interface IQualificationRepository
    {
        Task<IEnumerable<LpmQualification>> GetAllQualification();
       Task<QualificationDto> CreateQualificationCommand(LpmQualification request);
        Task<DeleteQualificationDto> DeleteQualification(long id);
        Task<UpdateQualificationDto> UpdateQualification(LpmQualification req);

        Task<LpmQualification> GetQualificationById(long id);
    }
}
