using LoanProcessManagement.Application.Contracts.Persistence;
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
using LoanProcessManagement.Application.Features.LeadList.Commands.AddLead;
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

            var leadQuery = await _dbContext.LpmLeadQuerys.Include(x => x.lead).Where(x => x.lead_Id == user.Id)
                .OrderByDescending(x => x.Id).FirstOrDefaultAsync();
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
                    IPSResponseType5=leadQuery.IPSResponseType5,
                    Id=userProcessCycle.lead.Id
                    

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
                    IPSResponseType5 = leadQuery.IPSResponseType5,
                    Id=user.Id

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
                if (request.CurrentStatus > user.CurrentStatus)
                {
                    var requestedStatus = await _dbContext.LpmLeadStatusMasters.Where(x => x.Id == request.CurrentStatus).FirstOrDefaultAsync();
                    var prevStatus = await _dbContext.LpmLeadStatusMasters.Where(x => x.Id == (request.CurrentStatus - 1)).FirstOrDefaultAsync();
                    response.Message = $"Submitting for {requestedStatus.StatusDescription} can be done only after {prevStatus.StatusDescription}.";
                }
                else
                {
                    response.Message = "Status cannot go backwards.";
                }
                response.Succeeded = false;
                response.Lead_Id = request.lead_Id;
                return response;
            }

            if (user.CurrentStatus == 3)
            {
                if (request.UserRoleId == 2 || request.UserRoleId==3)
                {
                    var leadQuery = await _dbContext.LpmLeadQuerys.Include(x => x.lead)
                        .Where(x => x.lead_Id == user.Id).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                    if (leadQuery != null && request.UserRoleId==3 && leadQuery.Query_Status=='Q' && request.QueryStatus=='R')
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

                    }
                    else
                    {
                        if(request.UserRoleId == 3 && request.QueryStatus == 'Q')
                        {
                            response.Message = "Can't Process";
                            response.Lead_Id = request.lead_Id;
                            response.Succeeded = false;
                            return response;

                        }

                        if ((leadQuery==null) || request.UserRoleId == 2 && leadQuery.Query_Status == 'R' && request.CurrentStatus==user.CurrentStatus)
                        {
                            if (request.QueryStatus=='R' && leadQuery.Query_Status == 'Q')
                            {
                                response.Message = "Can't Process";
                                response.Lead_Id = request.lead_Id;
                                response.Succeeded = false;
                                return response;
                            }
                            else if (request.QueryStatus == 'Q')
                            {
                                var newLeadQueryEntry = new LpmLeadQuery()
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
                                await _dbContext.LpmLeadQuerys.AddAsync(newLeadQueryEntry);


                            }


                        }

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
                userProcessCycle.LastModifiedDate = DateTime.Today;
                userProcessCycle.LastModifiedBy = request.LgId;
                await _dbContext.SaveChangesAsync();
                response.Message = "Lead Data Has Been Updated Successfully !!";
                response.Succeeded = true;
                response.Lead_Id = request.lead_Id;
                return response;

            }
            else
            {
                var leadQ= await _dbContext.LpmLeadQuerys.Include(x => x.lead).
                    Where(x => x.lead_Id == user.Id).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
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
                    Comment=request.Comments,
                    CreatedDate=DateTime.Today,
                    CreatedBy=request.LgId
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


        #region This method will add new lead to the db by - Pratiksha - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will add new lead to the db
        /// Commented by Pratiksha
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AddLeadDto> AddLeadAsync(LpmLeadMaster request)
        {
            _logger.LogInformation("Add Lead Initiated");

            var result = await _dbContext.LpmLeadMasters.Include(x => x.Branch).Include(x => x.LoanSchemes).Include(x => x.Product).Include(x => x.PropertyTypes).Include(x => x.SanctionedPlans)
                .Where(x => x.FormNo == request.FormNo).FirstOrDefaultAsync();

            AddLeadDto response = new AddLeadDto();

            if (result != null)
            {
                response.Message = "Form number is already exists. Please enter correct form number.";
                response.Succeeded = false;
                return response;
            }

            response.CreatedBy = request.CreatedBy;
            //response.CreatedDate = request.CreatedDate;
            response.FormNo = request.FormNo;
            response.FirstName = request.FirstName;
            response.MiddleName = request.MiddleName;
            response.LastName = request.LastName;
            response.CustomerResidenceaddress = request.CustomerResidenceaddress;
            response.CustomerResidencePincode = request.CustomerResidencePincode;
            response.CustomerOfficeaddress = request.CustomerOfficeaddress;
            response.CustomerOfficePincode = request.CustomerOfficePincode;
            response.CustomerPhone = request.CustomerPhone;
            response.CustomerPhone_Alternate = request.CustomerPhone_Alternate;
            response.CustomerEmail = request.CustomerEmail;
            response.EmploymentType = request.EmploymentType;
            response.ProductID = request.ProductID;
            request.CurrentStatus = 1;
            response.CustomerType = request.CustomerType;
            response.BranchID = request.BranchID;
            response.Lead_assignee_Id = request.Lead_assignee_Id;
            request.Appointment_Date = DateTime.Now;
            request.Conversion_date = DateTime.Now;
            response.NationalityType = request.NationalityType;
            response.IsPropertyIdentified = request.IsPropertyIdentified;
            response.PropertyPincode = request.PropertyPincode;
            response.PropertyUnderConstruction = request.PropertyUnderConstruction;
            response.ProjectName = request.ProjectName;
            response.UnitName = request.UnitName;
            response.ProjectAddress = request.ProjectAddress;
            request.CustomerType = "Individual";
            response.LastModifiedBy = request.LastModifiedBy;
            request.LastModifiedDate = DateTime.Now;
            response.Lead_assignee_Id = request.Lead_assignee_Id;
            response.IsSanctionedPlanReceivedID = request.IsSanctionedPlanReceivedID;
            response.PropertyID = request.PropertyID;
            response.AnnualTurnOverInLastFy = request.AnnualTurnOverInLastFy;
            response.IsApplicantExemptedFromGst = request.IsApplicantExemptedFromGst;
            response.ExemptedCategory = request.ExemptedCategory;
            response.TypeOfFirms = request.TypeOfFirms;
            response.Comment = request.Comment;
            request.IsActive = true;
            response.SchemeID = request.SchemeID;
            await _dbContext.LpmLeadMasters.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            request.lead_Id = "Lead_" + request.Id;
            await _dbContext.SaveChangesAsync();

            LpmLeadProcessCycle lpmLeadProcessCycle = new LpmLeadProcessCycle();
            lpmLeadProcessCycle.lead_Id = request.Id;
            lpmLeadProcessCycle.Comment = request.Comment;
            lpmLeadProcessCycle.CreatedBy = request.CreatedBy;
            lpmLeadProcessCycle.CurrentStatus = request.CurrentStatus;
            lpmLeadProcessCycle.LoanProductID = request.ProductID;
            lpmLeadProcessCycle.DateOfAction = DateTime.Now;
            lpmLeadProcessCycle.LastModifiedBy = request.CreatedBy;
            lpmLeadProcessCycle.LastModifiedDate = DateTime.Now;
            await _dbContext.LpmLeadProcessCycles.AddAsync(lpmLeadProcessCycle);
            await _dbContext.SaveChangesAsync();

            LpmLeadApplicantsDetails lpmLeadApplicantsDetails = new LpmLeadApplicantsDetails();
            lpmLeadApplicantsDetails.lead_Id = request.Id;
            lpmLeadApplicantsDetails.FormNo = request.FormNo;
            lpmLeadApplicantsDetails.FirstName = request.FirstName;
            lpmLeadApplicantsDetails.MiddleName = request.MiddleName;
            lpmLeadApplicantsDetails.LastName = request.LastName;
            lpmLeadApplicantsDetails.CustomerPhone = request.CustomerPhone;
            lpmLeadApplicantsDetails.EmploymentType = request.EmploymentType;
            lpmLeadApplicantsDetails.IsActive = request.IsActive;
            await _dbContext.LpmLeadApplicantsDetails.AddAsync(lpmLeadApplicantsDetails);
            await _dbContext.SaveChangesAsync();

            response.Message = "Lead added successfully .";
            response.Succeeded = true;

            _logger.LogInformation("Add Lead succeeded");
            return response;
        }

        #endregion
    }
    #endregion
}
