﻿using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.DeleteBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public BranchRepository(ApplicationDbContext dbContext, ILogger<BranchRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<CreateBranchDto> CreateBranch(LpmBranchMaster request)
        {
            CreateBranchDto res = new CreateBranchDto();
            var result=await _dbContext.LpmBranchMasters.FirstOrDefaultAsync(x => x.branchname == request.branchname);
            if (result == null)
            {
                request.IsActive = true;
                await _dbContext.LpmBranchMasters.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.BranchName = request.branchname;
                res.Message = "New branch added successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.BranchName = request.branchname;
                res.Message = $"Branch {request.branchname} already exists.";
                res.Succeeded = false;

            }
            return res;
        }

        public async Task<DeleteBranchDto> DeleteBranch(long id)
        {
            DeleteBranchDto res = new DeleteBranchDto();
            var result = await _dbContext.LpmBranchMasters.FirstOrDefaultAsync(x => x.Id==id);
            if (result != null)
            {
                result.IsActive = false;
                 //_dbContext.LpmBranchMasters.Remove(result);
                await _dbContext.SaveChangesAsync();
                res.Message = $"Brnach {result.branchname} removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }

        public async  Task<UpdateBranchDto> UpdateBranch(LpmBranchMaster req)
        {
            UpdateBranchDto response = new UpdateBranchDto();
            var result = await _dbContext.LpmBranchMasters.FirstOrDefaultAsync(x => x.branchname == req.branchname && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Branch name already exists.";
                response.Succeeded = false;
                return response;

            }
            var branchToUpdate= await _dbContext.LpmBranchMasters.FirstOrDefaultAsync(x =>x.Id == req.Id);

            if (branchToUpdate != null)
            {
                branchToUpdate.branchname = req.branchname;
                branchToUpdate.IsActive = req.IsActive;
                await _dbContext.SaveChangesAsync();
                response.Message = "Branch details updated successfully.";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "Invalid Id.";
                response.Succeeded = true;
                return response;
            }
    

        }
    }
}