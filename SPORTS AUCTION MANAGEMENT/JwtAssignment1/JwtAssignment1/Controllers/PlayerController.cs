using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAssignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace JwtAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   //token must be valid to use this contr
               //upar wale global hh sabke liye
    public class PlayerController : Controller
    {
        AuctionDetailsContext _context;





        public PlayerController(AuctionDetailsContext context)
        {
            _context = context;
        }





        // POST: api/UserDB


        [HttpPost]
        public ActionResult AddUser([FromBody] PlayerInfo user)
        {
            PlayerInfo userinfo = new PlayerInfo();
            userinfo.Name = user.Name;
            userinfo.Email = user.Email;
            userinfo.Password = user.Password;
            userinfo.Role = user.Role;
            userinfo.Nationality = user.Nationality;
            userinfo.Pteam = user.Pteam;
            userinfo.Age = user.Age;
            userinfo.Price = user.Price;

            _context.PlayerInfo.Add(userinfo);
            _context.SaveChanges();
            return Ok("User Details Added successfully");
        }



        [HttpGet]
        [Route("{Email}")]
        public ActionResult GetUser(string email)//parameter postman see ayega
        {
            var student = _context.PlayerInfo.FirstOrDefault(stud => stud.Email == email);
            return Ok(student);
        }



        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var studentList = _context.PlayerInfo.ToList();
            return Ok(studentList);
        }
        [HttpDelete("{Email}")]
        public ActionResult DeleteStudent(string email)
        {
            var studentInfo = _context.PlayerInfo.FirstOrDefault(student => student.Email == email);
            _context.PlayerInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{Email}")]
        public ActionResult UpdateStudent(string email, [FromBody] PlayerInfo studentRequest)
        {
            
            PlayerInfo studentInfo = _context.PlayerInfo.FirstOrDefault(student => student.Email == email);
            if (studentInfo != null)
            {
                studentInfo.Name = studentRequest.Name;
                studentInfo.Role = studentRequest.Role;
                studentInfo.Age = studentRequest.Age;
                studentInfo.Nationality = studentRequest.Nationality;
                studentInfo.Pteam = studentRequest.Pteam;
                studentInfo.Price = studentRequest.Price;
                studentInfo.Password = studentRequest.Password;
                _context.PlayerInfo.Update(studentInfo);
                _context.SaveChanges();
                return Ok(studentInfo);
            }
            return NotFound(new PlayerInfo());
        }




    }
}