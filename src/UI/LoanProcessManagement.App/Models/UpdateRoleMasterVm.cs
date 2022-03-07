using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UpdateRoleMasterVm
    {
        public GetRoleMasterByIdDto getRoleMasterByIdQueryVm { get; set; }
        public long Id { get; set; }
        public string RoleName { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
