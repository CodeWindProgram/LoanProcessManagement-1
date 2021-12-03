﻿using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.DeleteRoleMaster
{
    #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
    public class DeleteRoleMasterCommand:IRequest<Response<DeleteRoleMasterDto>>
    {
        public long Id { get; set; }
    }
    #endregion
}
