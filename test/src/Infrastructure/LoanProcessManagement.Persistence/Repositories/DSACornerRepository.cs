using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.DSACorner.Query.CircularList;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    class DSACornerRepository : BaseRepository<LpmMenuMaster>, IDSACornerRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        public DSACornerRepository(ApplicationDbContext dbContext, ILogger<LpmMenuMaster> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region DSA corner List - Ramya Guduru - 25 -11 -2021
        /// <summary>
        ///  Dsa Corner List - Ramya Guduru - 25 -11 -2021
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public async Task<List<CircularListVm>> CircularList(long ParentId)
        {
            var result = await(from A in _dbContext.LpmUserRoleMenuMaps
                               join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                               where B.ParentId == ParentId && A.IsActive == true && A.UserRoleId==4
                               orderby B.Position
                               select new CircularListVm
                               {
                                   Position = B.Position,
                                   Icon = B.Icon,
                                   Link = B.Link,
                                   CircularName = B.MenuName,
                               }).ToListAsync();
            return result;
        }

        public async Task<List<DSACornerListVm>> GetDSACornerList(long ParentId)
        {
            
            var result = await(from A in _dbContext.LpmUserRoleMenuMaps
                               join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                               where B.ParentId== ParentId && A.IsActive == true && A.UserRoleId == 4
                               orderby B.Position
                               select new DSACornerListVm
                               {
                                   Position = B.Position,
                                   Icon = B.Icon,
                                   Link = B.Link,
                                   DSAName = B.MenuName,
                               }).ToListAsync();
            return result;
        }

        public async Task<List<TrainingVideosListVm>> TrainingVideosList(long ParentId)
        {
            var result = await (from A in _dbContext.LpmUserRoleMenuMaps
                                join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                                where B.ParentId == ParentId && A.IsActive == true && A.UserRoleId == 4
                                orderby B.Position
                                select new TrainingVideosListVm
                                {
                                    Position = B.Position,
                                    Icon = B.Icon,
                                    Link = B.Link,
                                    TrainingVideoName = B.MenuName,
                                }).ToListAsync();
            return result;

            //var result2 = await (from B in _dbContext.LpmMenuMasters 
            //                     where B.ParentId == ParentId 
            //                     orderby B.Position
            //                     select new TrainingVideosListVm
            //                     {
            //                         Position = B.Position,
            //                         Icon = B.Icon,
            //                         Link = B.Link,
            //                         TrainingVideoName = B.MenuName,
            //                     }).ToListAsync();

            //return result2;
        }

        #endregion
    }
}
