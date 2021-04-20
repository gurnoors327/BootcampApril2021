using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using APIAssignment.Models;

namespace APIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public int Id { get; private set; }

        
        // GET api/values/  
        [HttpGet]
        public ActionResult<string> GetTestValue()
        {
            StreamReader r = new StreamReader(@"C:\Users\mayank.aggarwal\source\repos\APIAssignment\APIAssignment\Students\CStudents.json");

            string json = r.ReadToEnd();
            List<Students> items = JsonConvert.DeserializeObject<List<Students>>(json);
            var y=items.Where(x => x.Id==5).FirstOrDefault().Name;
            return y;
        }


        // GET api/values/id
        [HttpGet("{Id}")]
        public ActionResult<Students> GetStudentsById(int Id)
        {
            StreamReader r = new StreamReader(@"C:\Users\mayank.aggarwal\source\repos\APIAssignment\APIAssignment\Students\CStudents.json");

            string json = r.ReadToEnd();
            List<Students> items = JsonConvert.DeserializeObject<List<Students>>(json);
            return items.Where(x => x.Id == Id).FirstOrDefault();
        }
        //POST: api/Values
        [HttpPost]
        public void Post([FromBody] Students student)
        {
            var filePath = @"C:\Users\mayank.aggarwal\source\repos\APIAssignment\APIAssignment\Students\CStudents.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Students>>(jsonData)
                                  ?? new List<Students>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }
        // PUT api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Students student)
        {
            var filePath = @"C:\Users\mayank.aggarwal\source\repos\APIAssignment\APIAssignment\Students\CStudents.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Students>>(jsonData)
                                  ?? new List<Students>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == id)
                {
                    studentList[i].Id = student.Id;
                    studentList[i].Name = student.Name;
                    studentList[i].Department = student.Department;
                    studentList[i].Age = student.Age;
                    studentList[i].College = student.College;
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = @"C:\Users\mayank.aggarwal\source\repos\APIAssignment\APIAssignment\Students\CStudents.json";

            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Students>>(jsonData)
                                  ?? new List<Students>();

            for (int i = 0; i < studentList.Capacity; i++)
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

    class JavaScriptSerializer
    {
        public JavaScriptSerializer()
        {
        }
    }
}