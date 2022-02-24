using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class LeadListByIdModel
    {
       
        public string lead_Id { get; set; }

        public string FormNo { get; set; }
        public string CustomerName { get; set; }

        
        

        public string CustomerPhone { get; set; }

 

        
        public string Product { get; set; }

        

        public string LeadStatus { get; set; }

        

        public long BranchID { get; set; }


        public DateTime Appointment_Date { get; set; }

        
        
        
    }
}
