using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.MenuList
{
    public class MenuListQueryVm
    {

        [DisplayName("Menu Name")]
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }
    }
}
