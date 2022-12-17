using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [Route("validate")]
        [HttpPost]
        public IHttpActionResult Validate([FromBody] User data)
        {
            string value = data.UserName;
            Debug.WriteLine("Failed to parse val = " + value);

            if (data.Password.Equals("ISEC3004"))
            {
                Debug.WriteLine("Logged in: " + value);
                return Ok();
            }
            else
            {
                Debug.WriteLine("Access Denied: " + value);
                return BadRequest();
            }
        }

        [Route("numbers/{id}")]
        [Route("numbers")]
        [HttpGet]
        public IHttpActionResult Numbers(string id)
        {
            //string cleaned = id.Replace("\n", "").Replace("\r", "");

            try
            {
                int number = Int32.Parse(id);
                number = number * number;
                Debug.WriteLine("Valid input: " + id);
                return Ok(number);

            }
            catch(FormatException error)
            {
                Debug.WriteLine("Invalid input: " + id);
                return BadRequest();
            }
        }
    }
}
