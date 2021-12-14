using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands
{
    public class CreateMenuCommand : IRequest<Response<CreateMenuCommandDto>>
    {
        [DisplayName("Menu Name")]
        [Required]
        public string MenuName { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public int? Position { get; set; }
        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }
        public int ParentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsParent { get; set; }
    }
}
