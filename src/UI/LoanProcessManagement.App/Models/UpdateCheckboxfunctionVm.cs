﻿using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UpdateCheckboxfunctionVm
    {
        public IEnumerable<RoleMasterListVm> lpmUserRoleMaster { get; set; }
        public GetMenuByIdQueryVm getMenuByIdQueryVm { get; set; }
        public GetAllMenuMapsQueryVm getAllMenuMapsQueryVm { get; set; }
        public List<MenuCheckListVm> RoleList {get;set;}
        public List<long> Parlist {get;set;}
        public GetTheMenuMapsCommandDto getTheMenuMapsCommandDto { get; set; }
        
        public IFormFile Icons { get; set; }
    }
}