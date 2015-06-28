﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Models
{
    public class Reservation :Entity
    {

        public string RegistrationUserName { get; set; }
        public string RegistrationDate { get; set; }
        public string RegistrationCardNo { get; set; }
        public string Purpose { get; set; }
        public string StartDate { get; set; }
        public string PlannedEndDate { get; set; }
        public string Notes { get; set; }
        public string EndRegistrationUserName { get; set; }
        public string EndRegistrationDate { get; set; }
        public string EndRegistrationCardNo { get; set; }
        public string EndDate { get; set; }
        public string EndReason { get; set; }
        public string EndNotes { get; set; }
        
        public void Finish(string endReason, string endDate, string endNotes, string endRegistrationCardNo)
        {

        }

        


  

  
    }
}
