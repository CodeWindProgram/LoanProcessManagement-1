using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Created Menu Service - Saif Khan - 28/10/2021

    public interface IMenuService
    {
        public Task<Response<IEnumerable<GetMenuMasterServicesVm>>> MenuProcess(GetMenuMasterServicesQuery menuProcess);

        public Task<Response<CreateMenuCommandDto>> CreateMenu(CreateMenuCommand menuCreate);

        public Task<Response<UpdateMenuCommandDto>> UpdateMenu(UpdateMenuCommand menuUpdate);

        public Task<Response<DeleteMenuCommandDto>> DeleteMenu(long Id);

        public Task<Response<IEnumerable<MenuListQueryVm>>> MenuList(long UserRoleId);

        public Task<Response<GetMenuByIdQueryVm>> MenuById(long Id);

    } 
    #endregion
}