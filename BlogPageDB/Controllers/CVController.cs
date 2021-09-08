using BlogPageDB.Models;
using BlogPageDB.src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Controllers
{
    public class CVController : Controller
    {
        private readonly ILogger<CVController> _logger;

        public CVController(ILogger<CVController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CV> CVlist;
            using (var context = new MyContext())

            {
                CVlist = context.CV.FromSqlRaw("select * from CV").ToList();

            }
            return View(CVlist);
        }

        public IActionResult Delete(int Id)
        {
            using(var context = new MyContext())
            {
                var sql = $@"delete from CV where Id ={Id}" ;
                context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Save (string Description, string Summary , int UserId )
        {
            using (var context = new MyContext())
            {
                var sql = $@"insert into CV(Description,Summary,UserId) values ('{Description}','{Summary}',{UserId})";
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
        public IActionResult Update(CV cv)
        {
            using(var context = new MyContext())
            {
                var sql = $@"update CV set Description = '{cv.Description}', Summary = '{cv.Summary}' where Id = '{cv.Id}' " ;
                var resultCount = context.Database.ExecuteSqlRaw(sql); 
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            CV cv;
            using (var context = new MyContext())
            {
                cv = context.CV.FromSqlRaw($"select * from CV where Id = {Id}").FirstOrDefault();
            }
            return View(cv);
        }

        private IActionResult RedirectToAction(Func<IActionResult> ındex)
        {
            throw new NotImplementedException();
        }
    }
}
