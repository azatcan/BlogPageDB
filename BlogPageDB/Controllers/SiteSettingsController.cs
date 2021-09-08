using BlogPageDB.Models;
using BlogPageDB.src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Controllers
{
    public class SiteSettingsController : Controller
    {
        public IActionResult Index()
        {
            List<SiteSettings> SiteSettingslist;
            using (var context = new MyContext())
            {
                SiteSettingslist =  context.SiteSettings.FromSqlRaw("select * from SiteSettings").ToList();
            }
            return View(SiteSettingslist);
        }
        public IActionResult Delete(int Id)
        {
            using (var context = new MyContext())
            {
                var sql = $@"delete from SiteSettings where Id= {Id}";
                context.Database.ExecuteSqlRaw(sql);

            }
            return RedirectToAction("index");
        }
        [HttpPost]

        public IActionResult Save(bool Maintenance, string Title,string Description,string Keywords,bool IsDarkMode, string Facebook, string Twitter, string Instagram, string Youtube)
        {
            using (var context = new MyContext())
            {
                var sql = $@"insert into SiteSettings(Maintenance,Title,Description,Keywords,IsDarkMode,Facebook,Twitter,Instagram,Youtube) values ('{Maintenance}','{Title}','{Description}','{Keywords}','{IsDarkMode}','{Facebook}','{Twitter}','{Instagram}','{Youtube}')";
                context.Database.ExecuteSqlRaw(sql);
            }return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(SiteSettings siteSettings)
        {
            using (var context = new MyContext())
            {
                var sql = $"UPDATE SiteSettings SET Facebook='{siteSettings.Facebook}',Title = '{siteSettings.Title}',Description = '{siteSettings.Description}',Keywords = '{siteSettings.Keywords}' where Id = {siteSettings.Id}";
                var resultCount = context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            SiteSettings siteSettings;
            using (var context = new MyContext())
            {
                siteSettings = context.SiteSettings.FromSqlRaw($"select * from SiteSettings where Id = {Id}").FirstOrDefault();
            }
            return View(siteSettings);
        }


    }
}
