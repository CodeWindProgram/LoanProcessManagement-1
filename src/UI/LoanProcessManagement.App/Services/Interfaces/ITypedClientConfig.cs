using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ITypedClientConfig
    {
        public Uri BaseUrl { get; set; }

        public int Timeout { get; set; }
    }
}
