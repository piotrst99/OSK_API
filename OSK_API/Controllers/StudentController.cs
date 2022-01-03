using Microsoft.AspNetCore.Mvc;
using OSK_API.DbContexts;
using OSK_API.Models;
using OSK_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSK_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly ApplicationContext context;

        public StudentController(ApplicationContext context) {
            this.context = context;
        }

        [HttpPost]
        //[Route("GetStudentName/{userName}")]
        [Route("GetStudentName")]
        //public IActionResult GetStudentName(string userName) {
        public UserName GetStudentName(LoginData l) {
            var user = context.users.Where(q => q.UserName == l.login).FirstOrDefault();
            //var user = context.students.Where(q => q.User.UserName == l.login && q.User.Password == l.password).FirstOrDefault();
            //var user = context.users.Where(q => q.UserName == userName).FirstOrDefault();

            UserName userName = new UserName() {
                userID = user.ID,
                FirstName = user.FirstName,
                Surname = user.Surname
            };

            return userName;
        }

        [HttpPost]
        [Route("GetStudentData")]
        public UserData GetStudentData(UserName u) {
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
        [Route("GetStudentCourses")]
        public List<StudentCourseData> GetStudentCourses(UserName u) {
            List<StudentCourseData> studentCourseDatas = new List<StudentCourseData>();
            
            var studentCourses = context.studentCourses.Where(q => q.StudentID == u.userID).ToList();

            foreach (var sCourse in studentCourses) {
                var course = context.courses.Where(q => q.ID == sCourse.CourseID).FirstOrDefault();
                var category = context.categories.Where(q => q.ID == course.CategoryID).FirstOrDefault();

                StudentCourseData studentCourse = new StudentCourseData() {
                    ID = sCourse.ID,
                    CourseName = course.Name,
                    StartDate = sCourse.StartDate,
                    EndDate = sCourse.EndDate,
                    ExtraHours = sCourse.ExtraHours,
                    SumOfPayments = sCourse.SumOfPayment,
                    StudentCourseStatus = sCourse.StudentStatus,
                    Category = category.Symbol
                };

                studentCourseDatas.Add(studentCourse);

            }

            /*StudentCourseData studentCourseData = new StudentCourseData() {
                ID = 
            }*/
            

            return studentCourseDatas;
        }

    }
}
