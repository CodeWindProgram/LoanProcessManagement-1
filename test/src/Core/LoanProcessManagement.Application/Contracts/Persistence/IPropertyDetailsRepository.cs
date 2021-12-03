using LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IPropertyDetailsRepository
    {
        #region added method to call propertiesDetails repository- added by Ramya Guduru - 12-11-2021
        Task<UpdatePropertyDetailsDto> UpdatePropertyDetails(string lead_Id, UpdatePropertyDetailsCommand request);
       
        Task<LpmLeadMaster> GetPropertyAsync(string lead_Id);
        #endregion
    }
}
