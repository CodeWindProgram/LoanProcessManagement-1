using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using System.Collections.Generic;

namespace LoanProcessManagement.App.Models
{
    public class CheckboxfunctionVm
    {
        public CreateMenuCommand createMenuCommand { get; set; }
        public IEnumerable<RoleMasterListVm> lpmUserRoleMaster { get; set; }
    }
}
