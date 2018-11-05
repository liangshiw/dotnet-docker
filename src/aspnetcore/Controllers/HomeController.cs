using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using one.Models;
using StackExchange.Redis;

namespace one.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page2.";

            return View();
        }

        public async Task<IActionResult> Monster(string name)
        {
            var client = new HttpClient();
            var redis = ConnectionMultiplexer.Connect("redis");
            var db = redis.GetDatabase();
            
             if(await db.KeyExistsAsync(name))
             {
                byte[] image= await db.StringGetAsync(name);
                 return File(image,"image/png");
             }
            
                 var result= await client.GetAsync($"http://dnmonster:8080/monster/{name}?size=80");
                 await db.StringSetAsync(name,await result.Content.ReadAsByteArrayAsync());
                return File(await result.Content.ReadAsByteArrayAsync(),"image/png");
           
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
