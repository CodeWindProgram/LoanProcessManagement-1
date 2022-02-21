using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand.AlterMenuStatus;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IMenuRepository By - Saif Khan - on - 28/10/2021
    /// <summary>
    /// 28/10/2021-IMenuRepository
    /// Commented by Saif Khan
    /// </summary>
    /// Menu Repository Inherits Asynchronous Repository 
    /// entity name = LpmMenuMaster
    public interface IMenuRepository : IAsyncRepository<LpmMenuMaster>
    {
        Task<List<LpmMenuMaster>> GetMenuMasterService(long UserRoleId);

        Task<LpmMenuMaster> CreateMenu(LpmMenuMaster request);

        Task<DeleteMenuCommandDto> DeleteMenu( long Id);

        Task<UpdateMenuCommandDto> UpdateMenu(long Id, UpdateMenuCommand request);

        Task<List<LpmMenuMaster>> GetMenuList(long UserRoleId);

        Task<LpmUserRoleMenuMap> DeleteMenumapById(long Id);
        Task<IEnumerable<MenuListQueryVm>> GetChildMenuyById(long ParentId,long UserRoleId);

        AlterMenuStatusCommandDTO AlterStatus(int id, string LgId);
    }
    #endregion
}