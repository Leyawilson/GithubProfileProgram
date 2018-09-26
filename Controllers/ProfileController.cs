using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProfilePage.Models;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProfilePage.Controllers
{
    public class ProfileController : Controller
    {

        [HttpGet("{name}")]
        public IActionResult Index(string name)
        {

            RestClient client = new RestClient($"https://api.github.com/users/{name}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
              var user =  JsonConvert.DeserializeObject<User>(response.Content);
                ViewBag.User = user;
            }
            else
            {
                ViewBag.error = "User not found";
            }
            
            return View();
        }
}
}