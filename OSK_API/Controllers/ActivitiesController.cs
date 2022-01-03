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
    public class ActivitiesController : Controller
    {
        private readonly ApplicationContext context;

        public ActivitiesController(ApplicationContext context) {
            this.context = context;
        }

        [HttpPost]
        [Route("GetDriveActivities")]
        public List<PracticalData> GetDriveActivities(CallendarData c) {

            List<PracticalData> practicalDatas = new List<PracticalData>();
            List<Practical> practicals = new List<Practical>();

            if (c.TypeData == 1) {
                //practicals = context.practicals.Where(q => q.Data == c.Date).OrderBy(x=>x.ID).ThenByDescending(x=>x.StartTime).ToList();
                practicals = context.practicals.Where(q => q.Data == c.Date).OrderBy(x => x.StartTime).ToList();
            }
            else if(c.TypeData == 2) {
                practicals = context.practicals.Where(q => q.Data == c.Date && q.EmployeeID == c.UserID).OrderBy(x => x.StartTime).ToList();
            }
            else if (!String.IsNullOrEmpty(c.Date)){ 
                practicals = context.practicals.Where(q => (q.StudentID == c.UserID || q.EmployeeID == c.UserID) && q.Data == c.Date).ToList();
            }
            else {
                practicals = context.practicals.Where(q => q.StudentID == c.UserID || q.EmployeeID == c.UserID).ToList();
            }


            foreach (var p in practicals) {
                var student = context.users.Where(q => q.ID == p.StudentID).FirstOrDefault();
                var studentAddress = context.addresses.Where(q => q.ID == student.AddressID).FirstOrDefault();
                var employee = context.users.Where(q => q.ID == p.EmployeeID).FirstOrDefault();
                var vehicle = context.vehicles.Where(q => q.ID == p.VehicleID).FirstOrDefault();
                var status = context.practicalStatuses.Where(q => q.ID == p.PracticalStatID).FirstOrDefault();

                PracticalData practicalData = new PracticalData() {
                    ID = p.ID,
                    Student = student.FirstName + " " + student.Surname,
                    Employee = employee.FirstName + " " + employee.Surname,
                    Vehicle = vehicle != null ? vehicle.Mark + " " + vehicle.Model : null,
                    Data = p.Data,
                    StartTime = p.StartTime,
                    EndTime = p.EndTime,
                    Course = p.Course,
                    Status = status.Name,
                    Category = p.Category,
                    IsCancel = p.IsCancel,
                    StudentPhone = student.Address.PhoneNumber
                };

                practicalDatas.Add(practicalData);

            }

            return practicalDatas;
        }

        [HttpPost]
        [Route("CancelPracticalRequest")]
        public void CancelPracticalRequest(PracticalData p) {
            var practical = context.practicals.Where(q => q.ID == p.ID).FirstOrDefault();

            practical.IsCancel = p.IsCancel;
            context.SaveChanges();
        }

    }
}
