using LoanProcessManagement.Application.Features.DSACorner.Query.CircularList;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IDSACornerRepository By - Ramya Guduru - on - 25/11/2021
    /// <summary>
    /// 28/10/2021-IDSACornerRepository
    /// Commented by Ramya Guduru
    /// </summary>
    /// DSA Repository Inherits Asynchronous Repository 
    /// entity name = LpmMenuMaster
    public interface IDSACornerRepository : IAsyncRepository<LpmMenuMaster>
    {
        Task<List<DSACornerListVm>> GetDSACornerList(long ParentId);
        Task<List<TrainingVideosListVm>> TrainingVideosList(long ParentId);
        Task<List<CircularListVm>> CircularList(long ParentId);
    }
    #endregion
}
