using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster
{
    #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
    public class UpdateRoleMasterCommand: IRequest<Response<UpdateRoleMasterDto>>
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public bool IsActive { get; set; }

    }
    #endregion
}
