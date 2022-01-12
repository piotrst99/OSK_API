﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSK_API.Models
{
    public class StudentPayment{
        public int ID { get; set; }
        public int Cost { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentTime { get; set; }
        public string Employee { get; set; }
        public string TypePayment { get; set; }
    }
}
