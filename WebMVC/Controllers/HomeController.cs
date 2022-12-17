using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using System.IO;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private static RestClient client = new RestClient("http://localhost:54011/");
        public IActionResult Index()
        {
            ViewBag.title = "Home";
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] User data)
        {
            RestRequest request = new RestRequest("api/Login/validate", Method.Post);
            request.AddJsonBody(data);
            RestResponse resp = client.Execute(request);

            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Login(string data)
        {
            RestRequest request = new RestRequest("api/Login/validate", Method.Post);
            request.AddJsonBody(data);
            RestResponse resp = client.Execute(request);

            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(resp.Content);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
