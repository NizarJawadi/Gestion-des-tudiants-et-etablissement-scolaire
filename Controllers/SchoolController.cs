using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Repositories;

namespace WebApplication3.Controllers
{
   // [Authorize(Roles = "Admin,Manager")]
    public class SchoolController : Controller
    {

         ISchoolRepository schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }
        [AllowAnonymous]
        // GET: SchoolController
        public ActionResult Index()
        {
            var mod = schoolRepository.GetAll();
            return View(mod);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var sch = schoolRepository.GetById(id);
            return View(sch);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            try
            {
                schoolRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var sch = schoolRepository.GetById(id);
            return View(sch);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School s)
        {
            try
            {
                schoolRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var sch = schoolRepository.GetById(id);
            return View(sch);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School s)
        {
            try
            {
                schoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}