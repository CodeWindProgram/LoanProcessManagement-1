using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<AgencyRepository> _logger;
        public AgencyRepository(ApplicationDbContext dbContext, ILogger<AgencyRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }
        public async Task<GetAllAgencyDto> GetAllAgency()
        {
            GetAllAgencyDto response = new GetAllAgencyDto();
            var AllAgencyList =  _dbContext.lpmAgencyMasters
             .AsEnumerable()
             .GroupBy(u => u.Agency_type);

            foreach (var agency in AllAgencyList)
            {
                if (agency.Key == 'V')
                {
                    response.ValuerAgency = agency;
                }
                else if(agency.Key == 'F')
                {
                    response.FiAgency = agency;
                }
                else if (agency.Key == 'L')
                {
                    response.LegalAgency = agency;
                }

            }
            return response;
        }


        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        public async Task<GetThirdPartyCheckDetailsByLeadIdDto> GetThirdPartyCheckDetailsByLeadId(string lead_Id)
        {
            var user = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
                .Where(x => x.lead_Id == lead_Id).FirstOrDefaultAsync();

            var thirdPartyDetails = await _dbContext.lpmThirdPartyCheckDetails.Include(x => x.fiAgency).Include(y => y.legalAgency).Include(z => z.ValuerAgency).Where(b => b.lead_Id == user.Id).FirstOrDefaultAsync();
            if(thirdPartyDetails != null)
            {
                return new GetThirdPartyCheckDetailsByLeadIdDto()
                {
                    lead_Id = thirdPartyDetails.lead_Id,
                    valuerAgencyId = thirdPartyDetails.valuerAgencyId,
                    ValuerDocumentOut_Date = thirdPartyDetails.ValuerDocumentOut_Date,
                    ValuerDocumentIn_Date = thirdPartyDetails.ValuerDocumentIn_Date,
                    valuerAgencyComment = thirdPartyDetails.valuerAgencyComment,
                    valuerAgencyDocuments = thirdPartyDetails.valuerAgencyDocuments,
                    valuerAgencyStatus = thirdPartyDetails.valuerAgencyStatus,

                    legalAgencyId = thirdPartyDetails.legalAgencyId,
                    LegalDocumentOut_Date = thirdPartyDetails.LegalDocumentOut_Date,
                    LegalDocumentIn_Date = thirdPartyDetails.LegalDocumentIn_Date,
                    legalAgencyComment = thirdPartyDetails.legalAgencyComment,
                    legalAgencyDocuments = thirdPartyDetails.legalAgencyDocuments,
                    legalAgencyStatus = thirdPartyDetails.legalAgencyStatus,

                    fiAgencyId = thirdPartyDetails.fiAgencyId,
                    fiDocumentOut_Date = thirdPartyDetails.fiDocumentOut_Date,
                    fiDocumentIn_Date = thirdPartyDetails.fiDocumentIn_Date,
                    fiAgencyComment = thirdPartyDetails.fiAgencyComment,
                    fiAgencyDocuments = thirdPartyDetails.fiAgencyDocuments,
                    fiAgencyStatus = thirdPartyDetails.fiAgencyStatus
                };
            }
            else
            {
                return new GetThirdPartyCheckDetailsByLeadIdDto();
            }
            
        }
        #endregion
    }
}
