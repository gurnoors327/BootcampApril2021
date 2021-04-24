using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication5.Models;



namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        Database1Context _context;
        public StudentDataController(Database1Context context)
        {
            _context = context;
        }



        [HttpPost]
        public ActionResult AddStudent([FromBody] StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added successfully");
        }



        [HttpGet]
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }



        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentInfo studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }



        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            _context.StudentInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
    }
}