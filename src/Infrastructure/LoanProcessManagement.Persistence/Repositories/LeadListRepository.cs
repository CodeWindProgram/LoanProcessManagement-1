﻿using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LoanProcessManagement.Domain.Entities;
using LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using System.Text.RegularExpressions;
using System;
using System;

namespace LoanProcessManagement.Persistence.Repositories
{
    #region Repository Created While Inheriting ILeadListRepository - Saif Khan-02/11/2021
    public class LeadListRepository : ILeadListRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LeadListRepository(ApplicationDbContext dbContext, ILogger<LeadListModel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #region Method for the Lead List - Saif Khan - 02/11/2021
        /// <summary>
        /// Method for the Lead List - 02/11/2021
        /// Commented by - Saif Khan 
        /// </summary>
        /// <returns>result</returns>
        public async Task<IEnumerable<LeadListModel>> GetAllLeadList()
        {
            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmLoanProductMasters on A.ProductID equals B.Id
                                join C in _dbContext.LpmLeadStatusMasters on A.CurrentStatus equals C.Id
                                select new LeadListModel
                                {
                                    FormNo = A.FormNo,
                                    CustomerName = A.FirstName + " " + A.LastName,
                                    CustomerPhone = A.CustomerPhone,
                                    Product = B.ProductName,
                                    Appointment_Date = A.Appointment_Date,
                                    LeadStatus = C.StatusDescription,
                                    lead_Id=A.lead_Id

                                }).ToListAsync();
            return result;
        }

        #endregion

        public async Task<GetLeadByLeadIdDto> GetLeadByLeadId(string lead_id)
        {
            var user = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z=>z.Branch)
            .Where(x => x.lead_Id==lead_id).FirstOrDefaultAsync();

            var userProcessCycle = await _dbContext.LpmLeadProcessCycles.Include(x => x.lead).Include(x => x.LeadStatus)
                .Include(x => x.LoanProduct).Include(x => x.InsuranceProduct)
                .Where(x => x.lead_Id == user.Id && x.CurrentStatus == user.CurrentStatus).FirstOrDefaultAsync();

            var leadQuery= await _dbContext.LpmLeadQuerys.Include(x => x.lead).Where(x => x.lead_Id==user.Id).FirstOrDefaultAsync();
            if (leadQuery == null)
            {
                leadQuery = new LpmLeadQuery();
            }

            if (userProcessCycle != null)
            {
                return new GetLeadByLeadIdDto()
                {
                    FormNo=userProcessCycle.lead.FormNo,
                    CustomerName=userProcessCycle.lead.FirstName+" "+userProcessCycle.lead.LastName,
                    CustomerPhone=userProcessCycle.lead.CustomerPhone,
                    Product=userProcessCycle.LoanProduct.ProductName,
                    Appointment_Date=userProcessCycle.lead.Appointment_Date,
                    LeadStatus=userProcessCycle.LeadStatus.StatusDescription,
                    CurrentStatus=(int)userProcessCycle.CurrentStatus,
                    LoanProductID=userProcessCycle.LoanProductID,
                    InsuranceProductID=userProcessCycle.InsuranceProductID,
                    LoanAmount=userProcessCycle.LoanAmount,
                    InsuranceAmount=userProcessCycle.InsuranceAmount,
                    Comment=userProcessCycle.Comment,
                    ResidentialStatus=userProcessCycle.lead.NationalityType,
                    lead_Id=userProcessCycle.lead.lead_Id,
                    QueryStatus=leadQuery.Query_Status,
                    IPSQueryType1=leadQuery.IPSQueryType1,
                    IPSQueryType2=leadQuery.IPSQueryType2,
                    IPSQueryType3=leadQuery.IPSQueryType3,
                    IPSQueryType4=leadQuery.IPSQueryType4,
                    IPSQueryType5=leadQuery.IPSQueryType5,
                    IPSQueryType_Comment=leadQuery.IPSQueryType_Comment,
                    IPSResponseType1=leadQuery.IPSResponseType1,
                    IPSResponseType2=leadQuery.IPSResponseType2,
                    IPSResponseType3=leadQuery.IPSResponseType3,
                    IPSResponseType4=leadQuery.IPSResponseType4,
                    IPSResponseType5=leadQuery.IPSResponseType5

                };
            }
            else
            {
                return new GetLeadByLeadIdDto()
                {
                    FormNo = user.FormNo,
                    CustomerName = user.FirstName + " " + user.LastName,
                    CustomerPhone = user.CustomerPhone,
                    Product = user.Product.ProductName,
                    Appointment_Date = user.Appointment_Date,
                    LeadStatus = user.LeadStatus.StatusDescription,
                    CurrentStatus = user.CurrentStatus,
                    LoanProductID = user.ProductID,
                    ResidentialStatus = user.NationalityType,
                    lead_Id=user.lead_Id,
                    QueryStatus = leadQuery.Query_Status,
                    IPSQueryType1 = leadQuery.IPSQueryType1,
                    IPSQueryType2 = leadQuery.IPSQueryType2,
                    IPSQueryType3 = leadQuery.IPSQueryType3,
                    IPSQueryType4 = leadQuery.IPSQueryType4,
                    IPSQueryType5 = leadQuery.IPSQueryType5,
                    IPSQueryType_Comment = leadQuery.IPSQueryType_Comment,
                    IPSResponseType1 = leadQuery.IPSResponseType1,
                    IPSResponseType2 = leadQuery.IPSResponseType2,
                    IPSResponseType3 = leadQuery.IPSResponseType3,
                    IPSResponseType4 = leadQuery.IPSResponseType4,
                    IPSResponseType5 = leadQuery.IPSResponseType5

                };

            }
       
        }

        public async Task<UpdateLeadDto> ModifyLead(UpdateLeadCommand request)
        {
            var user = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
           .Where(x => x.lead_Id == request.lead_Id).FirstOrDefaultAsync();

            var userProcessCycle = await _dbContext.LpmLeadProcessCycles.Include(x => x.lead).Include(x => x.LeadStatus)
            .Include(x => x.LoanProduct).Include(x => x.InsuranceProduct)
            .Where(x => x.lead_Id == user.Id && x.CurrentStatus == request.CurrentStatus).FirstOrDefaultAsync();

            var response = new UpdateLeadDto();
            if ((request.CurrentStatus != user.CurrentStatus + 1 && request.CurrentStatus != user.CurrentStatus) &&
                (request.CurrentStatus != 11 && request.CurrentStatus != 8))
            {
                response.Succeeded = false;
                //response.Message = "Submitting for in-principle sanction can be done only after data entry.";
                response.Message = "Can't Process";
                response.Lead_Id = request.lead_Id;
                return response;

            }
            if (user.CurrentStatus == 3)
            {
                if (request.UserRoleId == 2 || request.UserRoleId==3)
                {
                    var leadQuery = await _dbContext.LpmLeadQuerys.Include(x => x.lead).Where(x => x.lead_Id == user.Id)
                        .FirstOrDefaultAsync();
                    if (leadQuery != null && request.UserRoleId==3)
                    {
                        leadQuery.Query_Status = request.QueryStatus;
                        leadQuery.Query_Comment = request.Query_Comment;
                        leadQuery.IPSQueryType1 = request.IPSQueryType1;
                        leadQuery.IPSQueryType2 = request.IPSQueryType2;
                        leadQuery.IPSQueryType3 = request.IPSQueryType3;
                        leadQuery.IPSQueryType4 = request.IPSQueryType4;
                        leadQuery.IPSQueryType5 = request.IPSQueryType5;
                        leadQuery.IPSQueryType_Comment = request.IPSQueryType_Comment;
                        leadQuery.IPSResponseType1 = request.IPSResponseType1;
                        leadQuery.IPSResponseType2 = request.IPSResponseType2;
                        leadQuery.IPSResponseType3 = request.IPSResponseType3;
                        leadQuery.IPSResponseType4 = request.IPSResponseType4;
                        leadQuery.IPSResponseType5 = request.IPSResponseType5;
                        leadQuery.LastModifiedDate = DateTime.Today;
                        leadQuery.LastModifiedBy = request.LgId;
                        //await _dbContext.SaveChangesAsync();

                    }
                    else
                    {
                        if (leadQuery == null)
                        {
                            leadQuery = new LpmLeadQuery()
                            {
                                lead_Id = user.Id,
                                Query_Status = request.QueryStatus,
                                FormNo = request.FormNo,
                                Query_Comment = request.Query_Comment,
                                IPSQueryType1 = request.IPSQueryType1,
                                IPSQueryType2 = request.IPSQueryType2,
                                IPSQueryType3 = request.IPSQueryType3,
                                IPSQueryType4 = request.IPSQueryType4,
                                IPSQueryType5 = request.IPSQueryType5,
                                IPSQueryType_Comment = request.IPSQueryType_Comment,
                                IPSResponseType1 = request.IPSResponseType1,
                                IPSResponseType2 = request.IPSResponseType2,
                                IPSResponseType3 = request.IPSResponseType3,
                                IPSResponseType4 = request.IPSResponseType4,
                                IPSResponseType5 = request.IPSResponseType5,
                                Query_Date = DateTime.Today,
                                CreatedBy = request.LgId
                            };
                            await _dbContext.LpmLeadQuerys.AddAsync(leadQuery);
                        }
                        //await _dbContext.SaveChangesAsync();                       
                    }
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Application can be moved to Branch for Processing only by HO.";
                    response.Lead_Id = request.lead_Id;
                    return response;
                }
            }
            if (userProcessCycle!=null)
            {
                userProcessCycle.InsuranceProductID = request.InsuranceProductID;
                userProcessCycle.LoanAmount = request.loanAmount;
                userProcessCycle.InsuranceAmount = request.insuranceAmount;
                userProcessCycle.DateOfAction = request.DateOfAction;
                userProcessCycle.Comment = request.Comments;
                userProcessCycle.lead.NationalityType = request.ResidentialStatus;
                userProcessCycle.LoanProductID = request.LoanProductID;
                userProcessCycle.lead.ProductID = (int)request.LoanProductID;
                userProcessCycle.lead.CurrentStatus = request.CurrentStatus;
                await _dbContext.SaveChangesAsync();
                response.Message = "Lead Data Has Been Updated Successfully !!";
                response.Succeeded = true;
                response.Lead_Id = request.lead_Id;
                return response;

            }
            else
            {
                var leadQ= await _dbContext.LpmLeadQuerys.Include(x => x.lead).Where(x => x.lead_Id == user.Id)
                   .FirstOrDefaultAsync();
                if (request.CurrentStatus == 4 && (request.UserRoleId != 2 || leadQ.Query_Status=='Q'))
                {
                    if(leadQ.Query_Status == 'Q')
                    {
                        response.Message = "Please wait for the branch to resolve the query before moving to submitted for Branch Processing.";
                    }
                    else
                    {
                        response.Message = "Application can be moved to Branch for Processing only by HO.";
                    }

                    response.Succeeded = false;
                    response.Lead_Id = request.lead_Id;
                    return response;

                }
                var newLeadEntry = new LpmLeadProcessCycle()
                {
                    lead_Id = user.Id,
                    CurrentStatus=request.CurrentStatus,
                    DateOfAction=request.DateOfAction,
                    LoanProductID=request.LoanProductID,
                    InsuranceProductID=request.InsuranceProductID,
                    LoanAmount=request.loanAmount,
                    InsuranceAmount=request.insuranceAmount,
                    Comment=request.Comments
                };
                await _dbContext.LpmLeadProcessCycles.AddAsync(newLeadEntry);
                newLeadEntry.lead.NationalityType = request.ResidentialStatus;
                newLeadEntry.lead.CurrentStatus = request.CurrentStatus;
                newLeadEntry.lead.ProductID = (int)request.LoanProductID;
                await _dbContext.SaveChangesAsync();
                response.Message = "Lead Data Has Been Added Successfully !!";
                response.Succeeded = true;
                response.Lead_Id = request.lead_Id;
                return response;

            }
        }

        #region Lead History - Saif Khan - 12/11/2021
        /// <summary>
        /// Lead History - Saif Khan - 12/11/2021
        /// </summary>
        /// <param name="lead_id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LeadHistoryQueryVm>> GetLeadhistory(string lead_id)
        {
            string input = lead_id;
            int res = 0;
            bool success = int.TryParse(new string(input
                                 .SkipWhile(x => !char.IsDigit(x))
                                 .TakeWhile(x => char.IsDigit(x))
                                 .ToArray()), out res);
            var result = await (from A in _dbContext.LpmLeadProcessCycles
                                join B in _dbContext.LpmLeadStatusMasters on A.CurrentStatus equals B.Id
                                join C in _dbContext.LpmLoanProductMasters on A.LoanProductID equals C.Id
                                join D in _dbContext.LpmLeadMasters on A.LeadStatus equals D.LeadStatus
                                join E in _dbContext.LpmUserMasters on A.CreatedBy equals E.LgId
                                where A.lead_Id == res
                                select new LeadHistoryQueryVm
                                {
                                    Stage = B.StatusDescription,
                                    StartDate = A.CreatedDate,
                                    EndDate = null,
                                    Description = C.ProducDescription,
                                    UpdatedBy = E.Name,
                                    ReasonForReject = D.RejectedLeadComment + " " + D.LostLeadComment,
                                    ProductsSold = C.ProductName
                                }).ToListAsync();
            return result;
        } 
        #endregion
    } 
    #endregion
}
