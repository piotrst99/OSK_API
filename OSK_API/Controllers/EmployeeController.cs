using Microsoft.AspNetCore.Mvc;
using OSK_API.DbContexts;
using OSK_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSK_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context) {
            this.context = context;
        }

        [HttpPost]
        [Route("GetEmployeeName")]
        public UserName GetEmployeeName(LoginData l) {
            var user = context.users.Where(q => q.UserName == l.login).FirstOrDefault();

            UserName userName = new UserName() {
                userID = user.ID,
                FirstName = user.FirstName,
                Surname = user.Surname
            };

            return userName;
        }

        [HttpPost]
        [Route("GetEmployeeData")]
        public UserData GetEmployeeData(UserName u){
            var user = context.users.Where(q => q.ID == u.userID).FirstOrDefault();
            var address = context.addresses.Where(q => q.ID == user.AddressID).FirstOrDefault();

            UserData userData = new UserData() {
                UserName = user.UserName,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Surname = user.Surname,
                PESEL = user.PESEL,

                Street = address.Street,
                NrHome = address.NrHome,
                NrLocal = address.NrLocal,
                Town = address.Town,
                PostCode = address.PostCode,
                Post = address.Post,
                PhoneNumber = address.PhoneNumber,
                Email = address.Email
            };

            return userData;
        }
    }
}
