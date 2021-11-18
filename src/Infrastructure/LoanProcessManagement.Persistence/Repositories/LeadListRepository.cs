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

namespace LoanProcessManagement.Persistence.Repositories
{
    #region Repository Created While Inheriting ILeadListRepository - Saif Khan-02/11/2021
    public class LeadListRepository : ILeadListRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LeadListRepository(ApplicationDbContext dbContext, ILogger<LeadListModel> logger)
        {
            _dbContext = dbContext; _logger = logger;
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
    } 
    #endregion
}
