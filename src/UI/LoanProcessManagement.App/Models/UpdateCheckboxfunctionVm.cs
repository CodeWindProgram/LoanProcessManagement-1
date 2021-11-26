using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UpdateCheckboxfunctionVm
    {
        public IEnumerable<RoleMasterListVm> lpmUserRoleMaster { get; set; }
        public GetMenuByIdQueryVm getMenuByIdQueryVm { get; set; }
    }
}
