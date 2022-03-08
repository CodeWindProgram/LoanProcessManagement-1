using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster
{
    public class GetRoleMasterByIdDto
    {
        public long Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        
    }
}