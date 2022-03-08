using LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.DeleteBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch;
using LoanProcessManagement.Application.Features.Branch.GetBranchNameById;
using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IBranchService
    {
        //Task<IEnumerable<GetAllBranchesDto>> GetAllBranches();

        Task<Response<CreateBranchDto>> AddBranch(CreateBranchCommand req);
        Task<Response<DeleteBranchDto>> DeleteBranch(long id);
        Task<GetBranchNameByIdQueryVm> GetBranchById(long id);
        Task<Response<UpdateBranchDto>> UpdateBranch(UpdateBranchCommand req);




    }
}
