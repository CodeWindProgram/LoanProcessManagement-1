﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands
{
    public class CreateMenuCommandDto 
    {
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool Succeeded { get; internal set; }
        public string Message { get; set; }
    }
}
