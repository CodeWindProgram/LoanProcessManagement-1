using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps
{
    public class GetTheMenuMapsCommandDto
    {
        public long Id { get; set; }
        public long UserRoleId { get; set; }
        public long MenuId { get; set; }
        public bool IsActive { get; set; }
    }
}
