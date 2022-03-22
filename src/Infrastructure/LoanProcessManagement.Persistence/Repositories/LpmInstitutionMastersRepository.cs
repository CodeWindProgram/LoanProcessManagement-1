using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class LpmInstitutionMastersRepository : ILpmInstitutionMastersRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LpmInstitutionMastersRepository(ApplicationDbContext dbContext, ILogger<LpmInstitutionMastersRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #region Repository methods for CRUD of InstitutionMaster - Dipti Pandhram
        /// <summary>
        ///  Repository method to Get All Institution Master  - 17/03/2022
        /// commented by Dipti
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LpmLeadInstitutionMaster>> GetAllInstitutionMasters()
        {
            return await _dbContext.lpmLeadInstitutionMasters.ToListAsync();
        }

        /// <summary>
        ///  Repository method to Create Institution Master  - 17/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<InstitutionMastersDto> CreateInstitutionMastersCommand(LpmLeadInstitutionMaster request)
        {
            InstitutionMastersDto res = new InstitutionMastersDto();
            var result = await _dbContext.lpmLeadInstitutionMasters.FirstOrDefaultAsync(x => x.Institution_Name == request.Institution_Name && x.Institution_Type == request.Institution_Type);
            if (result == null)
            {
                request.IsActive = true;
                await _dbContext.lpmLeadInstitutionMasters.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.Id = request.Id;
                res.Message = "New InstitutionMasters added successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Id = request.Id;
                res.Message = $"InstitutionMasters {request.Id} already exists.";
                res.Succeeded = false;

            }
            return res;
        }

        /// <summary>
        ///  Repository method to Delete Institution Master  - 17/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DeleteInstitutionMastersDto> DeleteInstitutionMasters(long id)
        {
            DeleteInstitutionMastersDto res = new DeleteInstitutionMastersDto();
            var result = await _dbContext.lpmLeadInstitutionMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                await _dbContext.SaveChangesAsync();
                res.Message = $"Institution Masters {result.Id} removed successfully.";
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
        ///  Repository method to Update  Institution Master  - 17/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<UpdateInstitutionMastersDto> UpdateInstitutionMasters(LpmLeadInstitutionMaster req)
        {
            UpdateInstitutionMastersDto response = new UpdateInstitutionMastersDto();
            var result = await _dbContext.lpmLeadInstitutionMasters.FirstOrDefaultAsync(x => x.Institution_Name == req.Institution_Name && x.Institution_Type == req.Institution_Type && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Institution Masters name already exists.";
                response.Succeeded = false;
                return response;

            }
            var instiToUpdate = await _dbContext.lpmLeadInstitutionMasters.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (instiToUpdate != null)
            {
                instiToUpdate.Institution_Name = req.Institution_Name;
                instiToUpdate.Institution_Type = req.Institution_Type;
                instiToUpdate.IsActive = req.IsActive;
                await _dbContext.SaveChangesAsync();
                response.Message = "Institution Masters details updated successfully.";
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

        /// <summary>
        ///  Repository method to Get  Institution Master By Id- 17/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LpmLeadInstitutionMaster> GetInstitutionMastersByIdAsync(long id)
        {
            return await _dbContext.lpmLeadInstitutionMasters.FirstOrDefaultAsync(x => x.Id == id);
        } 
        #endregion
    }
}
