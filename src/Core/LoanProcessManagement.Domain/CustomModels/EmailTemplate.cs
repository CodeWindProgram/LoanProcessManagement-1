using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class EmailTemplate
    {
        public int TemplateTypeId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
