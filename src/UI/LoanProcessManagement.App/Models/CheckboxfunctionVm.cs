using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using System.Collections.Generic;

namespace LoanProcessManagement.App.Models
{
    public class CheckboxfunctionVm
    {
        public CreateMenuCommand createMenuCommand { get; set; }
        public IEnumerable<RoleMasterListVm> lpmUserRoleMaster { get; set; }
        public List<MenuCheckListVm> ListVms { get; set; }
        public List<long> Childlist { get; set; }
        public List<GetAllMenusQueryVm> getWithParentId { get; set; }
    }
}