using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList
{
    #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
    public class RoleMasterListVm
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
    #endregion
}
