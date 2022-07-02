using CRUD.dbo;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        dummyEntities1 db = new dummyEntities1();
        public ActionResult Index()
        {
            var res =db.Employees.ToList();
            List<empmodel> e = new List<empmodel>();
            foreach (var item in res)
            {
                e.Add(new empmodel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Salary = item.Salary,
                    Email = item.Email,
                    City = item.City,
                    Company = item.Company,
                    Gender = item.Gender


                });
            }
            return View(e);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult delete(int? id)
        {
            var delete=db.Employees.Where(a => a.Id == id).First();
            db.Employees.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult CREATE()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CREATE(empmodel e)
        {
            Employee x = new Employee();
            x.Id = e.Id;
            x.Name = e.Name;
            x.City = e.City;
            x.Company = e.Company;
            x.Email = e.Email;
            x.Salary = e.Salary;
            x.Gender = e.Gender;
            
            if(x.Id==0)
            {
                db.Employees.Add(x);
                db.SaveChanges();
            }
            else
            {
                db.Entry(x).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("index");

        }
        public ActionResult Edit(int? id)
        {
            empmodel d = new empmodel();
            var edit = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            d.Id = edit.Id;
            d.Name = edit.Name;
            d.City = edit.City; 
            d.Company = edit.Company;   
            d.Email = edit.Email;   
            d.Salary = edit.Salary; 
            d.Gender = edit.Gender;
            ViewBag.edit = "edit";
            return View("CREATE", d);


        }

    }


}
