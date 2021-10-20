using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.App.Services.Services.Interfaces
{
    public interface ITypedClientConfig
    {
        public Uri BaseUrl { get; set; }

        public int Timeout { get; set; }
    }
}
