using System.ComponentModel;

namespace LoanProcessManagement.Application.Features.Menu.Query
{
    #region VM for the Menu Master Query - Saif Khan - 28/10/2021
    public class GetMenuMasterServicesVm
    {

        [DisplayName("Menu Name")]
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }


        public int? ParentID { get; set; }
    } 
    #endregion
}
