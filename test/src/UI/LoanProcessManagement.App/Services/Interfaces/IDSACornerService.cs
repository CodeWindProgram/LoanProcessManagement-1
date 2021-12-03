using LoanProcessManagement.Application.Features.DSACorner.Query.CircularList;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Created DSA Corner Service - Ramya Guduru - 25/11/2021
    public interface IDSACornerService
    {
        public Task<Response<IEnumerable<DSACornerListVm>>> DSACornerList(long ParentId);
        public Task<Response<IEnumerable<TrainingVideosListVm>>> TrainingVideosList(long ParentId);
        public Task<Response<IEnumerable<CircularListVm>>> CircularList(long ParentId);
    }
    #endregion
}
