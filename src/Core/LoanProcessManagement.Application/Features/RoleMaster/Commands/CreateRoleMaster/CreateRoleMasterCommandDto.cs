using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster
{
    #region added dto fields to create role - Ramya Guduru-10-11-2021
    public class CreateRoleMasterCommandDto
    {
        public long Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion
}
