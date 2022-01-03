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
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;
        public HomeController(ApplicationContext context) {
            this.context = context;
        }

        [HttpPost]
        [Route("CheckLoginData")]
        //[Route("CheckLoginData/login={login}/password={password}/val={val}")]
        //public IEnumerable<bool> CheckLoginData(string login, string password, int val) {
        //public IActionResult CheckLoginData(string login, string password, int val) {
        public IActionResult CheckLoginData(LoginData l) {

            bool b = false;

            List<bool> bo = new List<bool>();
            //string l = login;
            //if(val == 1) {
            if(l.val == 1) {
                //var student = context.students.Where(q => q.User.UserName == login && q.User.Password == password).FirstOrDefault();
                var student = context.students.Where(q => q.User.UserName == l.login && q.User.Password == l.password).FirstOrDefault();

                if (student != null) {
                    //return true;
                    return Json(new { result = true });
                    //b = true;
                }
                else {
                    //return false;
                    return Json(new { result = false });
                    //b = false;
                }
            }
            else{
                //var employee = context.employees.Where(q => q.User.UserName == login && q.User.Password == password && q.Role.ID == 2).FirstOrDefault();
                var employee = context.employees.Where(q => q.User.UserName == l.login && q.User.Password == l.password && q.Role.ID == 2).FirstOrDefault();
                
                if (employee != null) {
                    //return true;
                    return Json(new { result = true });
                    //b = false;
                }
                else {
                    //return false;
                    return Json(new { result = false });
                    //b = true;
                }

            }

            //bo.Add(b);

            //return bo.ToArray();

            

        }
    }
}
