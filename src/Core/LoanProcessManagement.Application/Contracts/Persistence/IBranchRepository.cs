using LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.DeleteBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IBranchRepository
    {
        Task<CreateBranchDto> CreateBranch(LpmBranchMaster request);
        Task<DeleteBranchDto> DeleteBranch(long id);
        Task<UpdateBranchDto> UpdateBranch(LpmBranchMaster req);


    }
}
