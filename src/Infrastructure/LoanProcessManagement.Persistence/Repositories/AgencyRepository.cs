using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
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
    }
}
