using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class PropertyDetailsRepository : IPropertyDetailsRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PropertyDetailsRepository> _logger;
        public PropertyDetailsRepository(
            ApplicationDbContext dbContext,
            ILogger<PropertyDetailsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;            
        }
        #region This method will send response to IPropertyDetailsRepository methods. by - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 10/11/2021 - This method will send response IPropertyDetailsRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="IPropertyDetailsRepository">IPropertyDetailsRepository</param>
        /// <returns>IPropertyDetailsRepository</returns>
        public async Task<UpdatePropertyDetailsDto> UpdatePropertyDetails(string lead_Id, UpdatePropertyDetailsCommand request)
        {
            _logger.LogInformation("GetPropertyAsync With Events Initiated");
            var user = await _dbContext.LpmLeadMasters.Where( x=>x.lead_Id == lead_Id).FirstOrDefaultAsync();

            UpdatePropertyDetailsDto response = new UpdatePropertyDetailsDto();


            if (user != null)
            {
                user.IsSanctionedPlanReceivedID = request.IsSanctionedPlanReceivedID;
                user.PropertyID = request.PropertyID;
                user.PropertyUnderConstruction = request.PropertyUnderConstruction;
                user.PropertyPincode = request.PropertyPincode;
                user.ProjectName = request.ProjectName;
                user.ProjectAddress = request.ProjectAddress;
                user.UnitName = request.UnitName;
                await _dbContext.SaveChangesAsync();
                response.Message = "Property details Updated Successfully";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "property doesn't exists .";
                response.Succeeded = false;
                
                return response;
            }

        }

        public async Task<LpmLeadMaster> GetPropertyAsync(string lead_Id)
        {
            _logger.LogInformation("GetPropertyAsync With Events Initiated");
            var user = await _dbContext.LpmLeadMasters.Where(x => x.lead_Id == lead_Id).FirstOrDefaultAsync();
            _logger.LogInformation("GetPropertyAsync With Events completed");
            return user;
        }
        #endregion
    }
}
