using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster
{
    #region added Master command to create role. By Ramya Guduru-10-11-2021
    public class CreateRoleMasterCommand: IRequest<Response<CreateRoleMasterCommandDto>>
    {
        public string RoleName { get; set; }
    }
    #endregion
}
