using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class TypedClientConfig : ITypedClientConfig
    {
        public TypedClientConfig(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            configuration.Bind("TypedClient", this);
        }

        public Uri BaseUrl { get; set; }

        public int Timeout { get; set; }
    }
}
