using System.ComponentModel;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus
{
    public class GetAllMenusQueryVm
    {
        public long Id { get; set; }

        [DisplayName("Menu Name")]
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }
        public int ParentId { get; set; }
    }
}