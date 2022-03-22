using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
   public  class QualificationRepository : IQualificationRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public QualificationRepository(ApplicationDbContext dbContext, ILogger<QualificationRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #region Repository methods for CRUD of Qualification - Dipti Pandhram
        /// <summary>
        ///  Repository method to Create Qualification  - 21/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<QualificationDto> CreateQualificationCommand(LpmQualification request)
        {
            QualificationDto res = new QualificationDto();
            var result = await _dbContext.LpmQualifications.FirstOrDefaultAsync(x => x.QualificationName == request.QualificationName);
            if (result == null)
            {
                request.IsActive = true;
                await _dbContext.LpmQualifications.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.Id = request.Id;
                res.Message = "New Qualification added successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Id = request.Id;
                res.Message = $"Qualification {request.Id} already exists.";
                res.Succeeded = false;

            }
            return res;
        }

        /// <summary>
        ///  Repository method to Delete Qualification  - 21/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DeleteQualificationDto> DeleteQualification(long id)
        {
            DeleteQualificationDto res = new DeleteQualificationDto();
            var result = await _dbContext.LpmQualifications.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                await _dbContext.SaveChangesAsync();
                res.Message = $"Qualification {result.Id} removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }

        /// <summary>
        /// Repository method to Get All Qualification  - 21/03/2022
        /// commented by Dipti
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LpmQualification>> GetAllQualification()
        {
            return await _dbContext.LpmQualifications.ToListAsync();


        }


        /// <summary>
        /// Repository method to Get Qualification  By Id - 21/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LpmQualification> GetQualificationById(long id)
        {
            return await _dbContext.LpmQualifications.FirstOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// Repository method to Update Qualification  - 21/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<UpdateQualificationDto> UpdateQualification(LpmQualification req)
        {
            UpdateQualificationDto response = new UpdateQualificationDto();
            var result = await _dbContext.LpmQualifications.FirstOrDefaultAsync(x => x.QualificationName == req.QualificationName && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Qualification name already exists.";
                response.Succeeded = false;
                return response;

            }
            var qualToUpdate = await _dbContext.LpmQualifications.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (qualToUpdate != null)
            {
                qualToUpdate.QualificationName = req.QualificationName;
                qualToUpdate.IsActive = req.IsActive;

                await _dbContext.SaveChangesAsync();
                response.Message = "Qualification details updated successfully.";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "Invalid Id.";
                response.Succeeded = false;
                return response;
            }


        } 
        #endregion

    }
}
