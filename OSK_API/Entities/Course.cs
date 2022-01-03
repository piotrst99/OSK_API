using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OSK_App.Entities
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int AmountTheoretical { get; set; }
        public int AmountPractical { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public decimal CourseCost { get; set; }
        public int? ExtraPracticalCost { get; set; }
        public int CountOfStudents { get; set; }

        public virtual Category Category { get; set; }
    }
}
