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
    public class ContactController : Controller
    {
        
        public IActionResult Index()
        {
            List<Contact> Contactlist;
            using (var context = new MyContext())

            {
                Contactlist = context.Contact.FromSqlRaw("select * from Contact").ToList();

            }

            return View(Contactlist);
        }

        public IActionResult Delete(int Id)
        {
            using (var context = new MyContext())
            {
                var sql = $@"DELETE FROM Contact where Id = {Id};";
                            
                context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Save(string Address,string PhoneNumber,int UserId)
        {
            using (var context = new MyContext())
            {
                var sql = $@"insert into Contact(Address,PhoneNumber,UserId) values ('{Address}','{PhoneNumber}',{UserId})";
                context.Database.ExecuteSqlRaw(sql);

            }return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            using (var context = new MyContext())
            {
                var sql = $"UPDATE Contact SET Name='{contact.Address}',Name='{contact.PhoneNumber}' where Id = {contact.Id}";
                var resultCount = context.Database.ExecuteSqlRaw(sql);
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Update(int Id)
        {
            Contact contact;
            using (var context = new MyContext())
            {
                contact = context.Contact.FromSqlRaw($"select * from Contact where Id = {Id}").FirstOrDefault();
            }
            return View(contact);
        }


    }
}
