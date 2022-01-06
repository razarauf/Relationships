using Relationships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Relationships.Controllers
{
    public class HomeController : Controller
    {

        ProjectContext _context;

        public HomeController()
        {
            _context = new ProjectContext();
        }

        public ActionResult Index()
        {
            var grades = _context.Grades.Include(x => x.Students).Where(x => x.Name.Contains("Math")).ToList();
            string str = "";

            foreach (var eachGrade in grades)
            {
                foreach (var eachStud in eachGrade.Students)
                {
                    str += eachStud.Name + ", ";
                }
            }

            var jim = _context.Students.Where(x => x.Name == "Jimothy").FirstOrDefault();

            grades[0].Students.Add(jim);
            _context.SaveChanges();

            return View();
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
    }
}