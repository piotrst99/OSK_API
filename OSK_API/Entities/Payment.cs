using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OSK_App.Entities
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        public int Cost { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentTime { get; set; }
        public string ReceiptDate { get; set; }
        
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [ForeignKey("PaymentStatus")]
        public int PaymentStatID { get; set; }

        [ForeignKey("TypePayments")]
        public int TypePaymentID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual TypePayment TypePayment { get; set; }
    }
}
