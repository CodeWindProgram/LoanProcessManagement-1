using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class MenuRepository : BaseRepository<LpmMenuMaster> ,IMenuRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        public MenuRepository(ApplicationDbContext dbContext, ILogger<LpmMenuMaster> logger,IEmailService emailService) : base(dbContext, logger,emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region Get Menu by UserRoleId- Saif Khan - 10-10-2021
        /// <summary>
        /// Get Menu  by UserRoleId - Saif Khan - 10-10-2021
        /// </summary>
        /// <param name="userroleid"></param>
        /// <returns></returns>
        public async Task<List<LpmMenuMaster>> GetMenuMasterService(long userroleid)
        {
            var result = await (from A in _dbContext.LpmUserRoleMenuMaps
                                join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                                where A.UserRoleId == userroleid && A.IsActive && 
                                (B.ParentId == null || B.ParentId == 0)
                                orderby B.Position
                                select new LpmMenuMaster
                                {
                                    Id = B.Id,
                                    Position = B.Position,
                                    Icon = B.Icon,
                                    Link = B.Link,
                                    MenuName = B.MenuName,
                                    ParentId = B.ParentId,
                                    IsParent = B.IsParent
                                }).ToListAsync();
            return result;
        }
        #endregion

        #region Menu List - Saif Khan - 10 -11 -2021
        /// <summary>
        ///  Menu List - Saif Khan - 10 -11 -2021
        /// </summary>
        /// <param name="userroleid"></param>
        /// <returns></returns>
        public async Task<List<LpmMenuMaster>> GetMenuList(long UserRoleId)
        {
            var result = await (from A in _dbContext.LpmUserRoleMenuMaps
                                join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                                where A.UserRoleId == UserRoleId && A.IsActive == true
                                orderby B.Position
                                select new LpmMenuMaster
                                {
                                    Id = B.Id,
                                    Position = B.Position,
                                    Icon = B.Icon,
                                    Link = B.Link,
                                    MenuName = B.MenuName,
                                }).ToListAsync();
            return result;
        } 

        #endregion

        #region Create Menu - Saif Khan - 10-11-2021
        /// <summary>
        /// Create Menu - Saif Khan - 10-11-2021
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LpmMenuMaster> CreateMenu(LpmMenuMaster request)
        {
            await _dbContext.LpmMenuMasters.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request;
        } 
        #endregion

        #region Delete Menu By ID - Saif Khan - 10-11-2021
        /// <summary>
        /// Delete Menu By ID - Saif Khan - 10-11-2021
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<DeleteMenuCommandDto> DeleteMenu(long Id)
        {
            var user = await _dbContext.LpmMenuMasters.Where(x => x.Id == Id).FirstOrDefaultAsync();
            DeleteMenuCommandDto response = new DeleteMenuCommandDto();

            if (user != null)
            {
                user.IsActive = false;
                await _dbContext.SaveChangesAsync();
                response.Id = Id;
                response.Message = $"Menu of id:{Id} has been removed successfully .";
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.Id = Id;
                response.Message = $"Menu of id:{Id} does not exists .";
                response.Succeeded = false;
                return response;
            }
        }
        #endregion

        #region Update Menu By Id - Saif Khan - 10/11/2021
        /// <summary>
        /// Update Menu By Id - Saif Khan - 10/11/2021
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateMenuCommandDto> UpdateMenu(long Id, UpdateMenuCommand request)
        {
            UpdateMenuCommandDto response = new UpdateMenuCommandDto();
            var menuToUpdate = await _dbContext.LpmMenuMasters.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (menuToUpdate != null)
            {
                menuToUpdate.MenuName = request.MenuName;
                menuToUpdate.Link = request.Link;
                menuToUpdate.Icon = request.Icon;
                menuToUpdate.Position = request.Position;
                menuToUpdate.IsActive = request.IsActive;
                menuToUpdate.ParentId = request.ParentId;
                menuToUpdate.IsParent = request.IsParent;
                await _dbContext.SaveChangesAsync();
                response.Message = "Menu details Updated Successfully";
                response.Succeeded = true;
                response.Id = menuToUpdate.Id;
                return response;

            }
            else
            {
                response.Message = "Menu doesn't exists .";
                response.Succeeded = false;
                response.Id = menuToUpdate.Id;
                return response;
            }
        }
        #endregion

        #region RoleList - Saif Khan - 19/11/2021
        /// <summary>
        /// RoleList - Saif Khan - 19/11/2021
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<LpmUserRoleMenuMap>> RoleList(LpmUserRoleMenuMap request)
        {
            await _dbContext.LpmUserRoleMenuMaps.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return new Response<LpmUserRoleMenuMap>(request);
        }
        #endregion

        #region Delete Menu By Id - Saif Khan - 19/11/2021
        /// <summary>
        /// Delete Menu By Id - Saif Khan - 19/11/2021
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<LpmUserRoleMenuMap> DeleteMenumapById(long Id)
        {
            var result = _dbContext.LpmUserRoleMenuMaps.FirstOrDefault(e => e.Id == Id);
            if (result != null)
            {
                _dbContext.LpmUserRoleMenuMaps.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        #endregion

        public async Task<IEnumerable<MenuListQueryVm>> GetChildMenuyById(long ParentId ,long UserRoleId)
        {
            var result = await(from A in _dbContext.LpmUserRoleMenuMaps
                               join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                               join C in _dbContext.LpmUserRoleMasters on A.UserRoleId equals C.Id
                               where B.ParentId == ParentId && C.Id == UserRoleId  && A.IsActive
                               orderby B.Position
                               select new MenuListQueryVm
                               {
                                   MenuName=B.MenuName,
                                   Position = B.Position,
                                   Icon = B.Icon,
                                   Link = B.Link
                               }).ToListAsync();
            return result;
        }
    }
}


