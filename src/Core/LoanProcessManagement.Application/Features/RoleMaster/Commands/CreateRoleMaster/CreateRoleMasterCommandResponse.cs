using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster
{
    #region added response to create role- Ramya Guduru-10-11-2021
    public class CreateRoleMasterCommandResponse
    {
        public CreateRoleMasterCommandResponse()
        {

        }

        public CreateRoleMasterCommandDto roleMaster { get; set; }
    }
    #endregion
}
