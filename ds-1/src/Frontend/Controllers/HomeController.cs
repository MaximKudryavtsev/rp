using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            ViewBag.Result = new List<string>() { "123" };
            return View();
        }

        private async Task<string> GetResponseString(string url, string data)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            data = ("=" + data);
            var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
            
            var response = await httpClient.PostAsync(url, content);
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }

        [HttpPost]
        public IActionResult Upload(string data)
        {   //HttpContent content = new StringContent(data);
            //TODO: send data in POST request to backend and read returned id value from response
            string url = "http://127.0.0.1:5000/api/values";
            string result = GetResponseString(url, data).Result;

            ViewData["key"] = result;
            ViewData["value"] = data;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
