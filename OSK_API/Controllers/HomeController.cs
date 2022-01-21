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
        public IActionResult CheckLoginData(LoginData l) {

            if(l.val == 1) {
                var student = context.students.Where(q => q.User.UserName == l.login && q.User.HashPassword == l.password).FirstOrDefault();

                if (student != null) {
                    return Json(new { result = true });
                }
                else {
                    return Json(new { result = false });
                }
            }
            else{
                var employee = context.employees.Where(q => q.User.UserName == l.login && q.User.HashPassword == l.password && q.Role.ID == 2).FirstOrDefault();
                
                if (employee != null) {
                    return Json(new { result = true });
                }
                else {
                    return Json(new { result = false });
                }

            }


        }
    }
}
