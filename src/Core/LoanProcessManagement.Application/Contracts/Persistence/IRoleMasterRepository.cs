using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IRoleMasterRepository : IAsyncRepository<LpmUserRoleMaster>
    {
        #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will call RoleMasterRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="RoleMasterRepository">RoleMasterRepository</param>
        /// <returns>RoleMasterRepository</returns>
        /// 

        
        Task <LpmUserRoleMaster> GetRoleMasterByIdAsync(long id);
        Task <UpdateRoleMasterDto>UpdateRoleMaster(long id,UpdateRoleMasterCommand request);
        Task GetByRoleName(string RoleName);
    }
    #endregion
}
