using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSK_API.Models
{
    public class UserData{
        /// PERSONAL DATA
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }

        /// ADDRESS DATA
        public string Street { get; set; }
        public string NrHome { get; set; }
        public string NrLocal { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Post { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        /// INSTRUCTOR
        public string NrInstructor { get; set; }
    }
}
