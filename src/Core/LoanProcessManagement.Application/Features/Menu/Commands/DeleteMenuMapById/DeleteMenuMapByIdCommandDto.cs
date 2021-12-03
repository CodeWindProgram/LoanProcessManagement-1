using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById
{
    public class DeleteMenuMapByIdCommandDto
    {
        public long Id { get; set; }
        public long UserRoleId { get; set; }
        public LpmUserRoleMaster UserRole { get; set; }
        public long MenuId { get; set; }
        public LpmMenuMaster MenuName { get; set; }
        public bool IsActive { get; set; }
    }
}
