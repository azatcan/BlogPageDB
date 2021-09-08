using BlogPageDB.Models;
using BlogPageDB.src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Users> userlist;
            using (var context = new MyContext())

            {
                userlist = context.Users.FromSqlRaw("select * from Users").ToList();

            }

            return View(userlist);
        }

        public IActionResult Delete(int Id)
        {
            using (var context = new MyContext())
            {
                var sql = $@"DELETE FROM Users where Id = {Id};
                             DELETE FROM CV where UserId = {Id};
                             DELETE FROM Contact where UserId = {Id};";
                context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Save(string Name, string LastName ,string Mail,string UserName)
        {
            using (var context = new MyContext())
            {
                var sql = $@"insert into Users(Name,LastName,Mail,UserName) values ('{Name}','{LastName}','{Mail}','{UserName}')";
                context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Users users)
        {
            using (var context = new MyContext())
            {
                var sql = $"UPDATE Users SET Name='{users.Name}' where Id = {users.Id}";
                var resultCount = context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            Users user;
            using (var context = new MyContext())
            {
                user = context.Users.FromSqlRaw($"select * from Users where Id = {Id}").FirstOrDefault();
            }
            return View(user);
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
