using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class LeadListModel
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string ProductName { get; set; }
        public string StatusDescription { get; set; }
        public DateTime Appointment_Date { get; set; }
    }
}
