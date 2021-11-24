using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID
{
    public class GetMenuByIdQueryVm
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }
        public bool IsActive { get; set; }
    }
}
