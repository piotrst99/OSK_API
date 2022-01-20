using Microsoft.AspNetCore.Mvc;
using OSK_API.DbContexts;
using OSK_API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        [HttpPost]
        [Route("GetEmoloyeeActivites")]
        public EmployeeActiviteData GetEmoloyeeActivites(EmployeeActiviteData activiteData) {
            var listOfPractical = context.practicals.Where(q => q.EmployeeID == activiteData.UserID).ToList().Where(q =>
                (DateTime.ParseExact(activiteData.BeginDate, "yyyy-MM-dd", CultureInfo.InvariantCulture) <=
                DateTime.ParseExact(q.Data, "yyyy-MM-dd", CultureInfo.InvariantCulture)) &&
                        (DateTime.ParseExact(activiteData.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture) >=
                        DateTime.ParseExact(q.Data, "yyyy-MM-dd", CultureInfo.InvariantCulture))).ToList();

            EmployeeActiviteData data = new EmployeeActiviteData() {
                CountOfPlaned = listOfPractical.Where(q => q.PracticalStatID == 1).Count(),
                CountOfDone = listOfPractical.Where(q => q.PracticalStatID == 3).Count(),
                CountOfCancel = listOfPractical.Where(q => q.PracticalStatID == 3).Count()
            };
            
            return data;
        }
    }
}
