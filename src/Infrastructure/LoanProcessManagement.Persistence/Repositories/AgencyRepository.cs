using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<AddThirdPartyCheckDetailsDto> SubmitToAgency(AddThirdPartyCheckDetailsCommand req)
        {
            var user = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
                .Where(x => x.Id == req.leadIdLong).FirstOrDefaultAsync();
            var ThirdPartyDetails = await _dbContext.lpmThirdPartyCheckDetails.Include(x => x.ValuerAgency).
                Include(x => x.fiAgency).Include(x => x.legalAgency)
            .Where(x => x.lead_Id == req.leadIdLong).FirstOrDefaultAsync();
            var response = new AddThirdPartyCheckDetailsDto();
            if (ThirdPartyDetails != null)
            {
                if(req.Tab == "Valuer")
                {
                    if (ThirdPartyDetails.valuerAgencyStatus == 0)
                    {
                        ThirdPartyDetails.valuerAgencyId = req.valuerAgencyId;
                        ThirdPartyDetails.ValuerDocumentOut_Date = req.ValuerDocumentOut_Date;
                        ThirdPartyDetails.valuerAgencyDocuments = req.valuerAgencyDocuments;
                        ThirdPartyDetails.valuerAgencyStatus = 1;
                    }
                    else if(ThirdPartyDetails.valuerAgencyStatus == 1)
                    {
                        ThirdPartyDetails.ValuerDocumentIn_Date = req.ValuerDocumentIn_Date;
                        ThirdPartyDetails.valuerAgencyComment = req.valuerAgencyComment;
                        ThirdPartyDetails.valuerAgencyStatus = 2;

                    }
          

                }
                else if (req.Tab == "Fi")
                {
                    if (ThirdPartyDetails.fiAgencyStatus == 0)
                    {
                        ThirdPartyDetails.fiAgencyId = req.fiAgencyId;
                        ThirdPartyDetails.fiDocumentOut_Date = req.fiDocumentOut_Date;
                        ThirdPartyDetails.fiAgencyDocuments = req.fiAgencyDocuments;
                        ThirdPartyDetails.fiAgencyStatus = 1;
                    }
                    else if(ThirdPartyDetails.fiAgencyStatus == 1)
                    {
                        ThirdPartyDetails.fiDocumentIn_Date = req.fiDocumentIn_Date;
                        ThirdPartyDetails.fiAgencyComment = req.fiAgencyComment;
                        ThirdPartyDetails.fiAgencyStatus = 2;

                    }
           
                }
                else if (req.Tab == "Legal")
                {
                    if(ThirdPartyDetails.legalAgencyStatus == 0)
                    {
                        ThirdPartyDetails.legalAgencyId = req.legalAgencyId;
                        ThirdPartyDetails.LegalDocumentOut_Date = req.LegalDocumentOut_Date;
                        ThirdPartyDetails.legalAgencyDocuments = req.legalAgencyDocuments;
                        ThirdPartyDetails.legalAgencyStatus = 1;

                    }
                    else if(ThirdPartyDetails.legalAgencyStatus == 1)
                    {
                        ThirdPartyDetails.LegalDocumentIn_Date = req.LegalDocumentIn_Date;
                        ThirdPartyDetails.legalAgencyComment = req.legalAgencyComment;
                        ThirdPartyDetails.legalAgencyStatus = 2;

                    }

                }
                await _dbContext.SaveChangesAsync();
                response.Message = "Data Has Been Updated Successfully .";
                response.Succeeded = true;
                response.lead_Id = req.leadIdLong;
                return response;


            }
            else
            {
                var thirdPartyEntry = new LpmThirdPartyCheckDetails();
                if (req.Tab == "Valuer")
                {
                    thirdPartyEntry = new LpmThirdPartyCheckDetails()
                    {
                        lead_Id = req.leadIdLong,
                        valuerAgencyId = req.valuerAgencyId,
                        ValuerDocumentOut_Date = req.ValuerDocumentOut_Date,
                        valuerAgencyDocuments = req.valuerAgencyDocuments,
                        valuerAgencyComment = req.valuerAgencyComment,
                        valuerAgencyStatus = 1,
                        CreatedBy = req.LgId,
                        CreatedDate = DateTime.Today

                    };
                }
                else if(req.Tab == "Fi")
                {
                    thirdPartyEntry = new LpmThirdPartyCheckDetails()
                    {
                        lead_Id = req.leadIdLong,
                        fiAgencyId = req.fiAgencyId,
                        fiDocumentOut_Date = req.fiDocumentOut_Date,
                        fiDocumentIn_Date = req.fiDocumentIn_Date,
                        fiAgencyDocuments = req.fiAgencyDocuments,
                        fiAgencyComment = req.fiAgencyComment,
                        fiAgencyStatus = 1,
                        CreatedBy = req.LgId,
                        CreatedDate = DateTime.Today

                    };

                }
                else if(req.Tab == "Legal")
                {
                    thirdPartyEntry = new LpmThirdPartyCheckDetails()
                    {
                        lead_Id = req.leadIdLong,
                        legalAgencyId = req.legalAgencyId,
                        LegalDocumentOut_Date = req.LegalDocumentOut_Date,
                        legalAgencyDocuments = req.legalAgencyDocuments,
                        legalAgencyComment = req.legalAgencyComment,
                        legalAgencyStatus = 1,
                        CreatedBy = req.LgId,
                        CreatedDate = DateTime.Today

                    };

                }
                
                await _dbContext.lpmThirdPartyCheckDetails.AddAsync(thirdPartyEntry);
                await _dbContext.SaveChangesAsync();
                response.Message = "Data has been added successfully .";
                response.Succeeded = true;
                response.lead_Id = req.leadIdLong;
                return response;

            }

        }


        #region Repository method for fetching thirdpartydetails from db - Pratiksha - 24/12/2021
        /// <summary>
        /// 24/12/2021 - Repository method for fetching thirdpartydetails from db
        /// commented by Pratiksha Poshe
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
                    fiAgencyStatus = thirdPartyDetails.fiAgencyStatus,

                    Succeeded = true
                };
            }
            else
            {
                return new GetThirdPartyCheckDetailsByLeadIdDto()
                {
                    Succeeded = false,
                    lead_Id=user.Id
                };
            }
            
        }
        #endregion
    }
}
