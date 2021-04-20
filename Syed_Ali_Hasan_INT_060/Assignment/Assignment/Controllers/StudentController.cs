using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        public string testAction()
        {
            return "Test successful";
        }        

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(@"E:\NET PRACTICE\Assignment\Assignment\Resource\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.Where(x => x.Id == id).FirstOrDefault();
            return ans;
        }

        // GET: api/Student/5
        [HttpGet]
        [Route("/api/Student/GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents(int id)
        {
            StreamReader r = new StreamReader(@"E:\NET PRACTICE\Assignment\Assignment\Resource\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items;
        }

        //POST: api/Student
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var filePath = @"E:\NET PRACTICE\Assignment\Assignment\Resource\Student.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = @"E:\NET PRACTICE\Assignment\Assignment\Resource\Student.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            for(int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == id)
                {
                    studentList.RemoveAt(i);
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }
    }
}
