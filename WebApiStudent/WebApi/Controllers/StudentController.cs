using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [RoutePrefix("api/Student")]

    public class StudentController : ApiController
    {
        StudentsDbEntities SE = new StudentsDbEntities();
        [Route("SaveDetails")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveDetails(Student student)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            SE.Students.Add(student);
            if (SE.SaveChanges() == 1)
            {
                dict.Add("Message", "Data Saved Successfully.");
                return Ok(dict);
            }
            else
            {
                dict.Add("Error", "Data Not saved.");
                return Ok(dict);
            }



        }
        [HttpPost]
        [Route("UpdateDetails")]

        public async Task<IHttpActionResult> UpdateDetails(Student student)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var details = SE.Students.Where(x => x.StudentId == student.StudentId).SingleOrDefault();
            if (details != null)
            {
                details.StudentName = student.StudentName;
                details.StudentGroup = student.StudentGroup;
                details.Address = student.Address;
                details.Departament = student.Departament;
                if (SE.SaveChanges() == 1)
                {
                    dict.Add("Message", "Data Updated Successfully.");
                    return Ok(dict);

                }
                else
                {
                    dict.Add("Error", "Data Not saved.");
                    return Ok(dict);

                }

            }
            else
            {
                dict.Add("Error", "Invalid UserId");
                return Ok(dict);

            }





        }
        [Route("getDetails")]
        [HttpGet]
        public IHttpActionResult getDetails()
        {
            List<Student> li = new List<Student>();
            var details = SE.Students.ToList();
            if (details != null)
            {
                return Ok(details);
            }
            else
            {
                return NotFound();

            }

        }
        [Route("DeleteStudent")]
        [HttpPost]
        public IHttpActionResult DeleteStudent(Student estudent)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Student> li = new List<Student>();
            var details = SE.Students.Where(x => x.StudentId == estudent.StudentId).FirstOrDefault();
            bool result = false;
            SE.Students.Remove(details);
            if (SE.SaveChanges() == 1)
            {

                dict.Add("Message", "Student Deleted Successfully.");
                return Ok(dict);
            }
            else
            {
                dict.Add("Message", "Student Not Deleted.");
                return Ok(dict);

            }

        }


    }
}
