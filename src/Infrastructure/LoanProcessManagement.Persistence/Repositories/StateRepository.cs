using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.State.Commands.CreateState;
using LoanProcessManagement.Application.Features.State.Commands.DeleteState;
using LoanProcessManagement.Application.Features.State.Commands.UpdateState;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class StateRepository : IStateRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public StateRepository(ApplicationDbContext dbContext, ILogger<StateRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #region  Repository methods for CRUD of State - Dipti Pandhram
        /// <summary>
        /// Repository method to Create State  - 22/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateStateDto> CreateStateCommand(LpmState request)
        {
            CreateStateDto res = new CreateStateDto();
            var result = await _dbContext.LpmStates.FirstOrDefaultAsync(x => x.StateName== request.StateName);
            if (result == null)
            {
                request.IsActive = true;
                await _dbContext.LpmStates.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.Id = request.Id;
                res.Message = "New State added successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Id = request.Id;
                res.Message = $"State {request.Id} already exists.";
                res.Succeeded = false;

            }
            return res;
        }

        /// <summary>
        ///  Repository method to Delete State  - 22/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DeleteStateDto> DeleteState(long id)
        {
            DeleteStateDto res = new DeleteStateDto();
            var result = await _dbContext.LpmStates.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                await _dbContext.SaveChangesAsync();
                res.Message = $"state {result.Id} removed successfully.";
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
        ///  Repository method to Get All State  - 22/03/2022
        /// commented by Dipti
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LpmState>> GetAllState()
        {
            return await _dbContext.LpmStates.ToListAsync();

        }

        /// <summary>
        ///  Repository method to Get State By Id  - 22/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LpmState> GetStateById(long id)
        {
            return await _dbContext.LpmStates.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<UpdateStateDto> UpdateState(LpmState req)
        {
            UpdateStateDto response = new UpdateStateDto();
            var result = await _dbContext.LpmStates.FirstOrDefaultAsync(x => x.StateName == req.StateName && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "State name already exists.";
                response.Succeeded = false;
                return response;

            }
            var statToUpdate = await _dbContext.LpmStates.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (statToUpdate != null)
            {
                statToUpdate.StateName = req.StateName;
                statToUpdate.IsActive = req.IsActive;

                await _dbContext.SaveChangesAsync();
                response.Message = "State details updated successfully.";
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
