using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID
{
    public class GetMenuByIdQueryVm
    {
        public long Id { get; set; }
        [Required]
        public string MenuName { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public int? Position { get; set; }
        public bool IsActive { get; set; }
    }
}
