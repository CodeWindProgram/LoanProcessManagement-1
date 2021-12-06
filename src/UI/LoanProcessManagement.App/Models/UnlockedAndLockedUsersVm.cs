﻿using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UnlockedAndLockedUsersVm
    {
        public UnlockUserAccountCommand unlockUserAccountCommand { get; set; }
        public IEnumerable<GetAllUsersQueryVm> getAllUsersQueryVm { get; set; }
        public UnlockAndResetPasswordCommand unlockAndResetPasswordCommand { get; set; }
    }
}