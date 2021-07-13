using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMangmentSystem.Data;
using UserMangmentSystem.Models;
namespace UserMangmentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        [TempData]
        public string Message { get; set; }

        private readonly AplicationDbContext _db;

        public DepartmentController(AplicationDbContext db)
        {
            this._db = db;
        }

        // This  To Get All Departments 
        public IActionResult Index()
        {
            IEnumerable<Department> DepartemntsList = _db.Departments;
            return View(DepartemntsList);
        }

        // This To Show One Department Details Page 
        public IActionResult Details(int? id)
        {
             
            if (id == null || id == 0)
                return NotFound();

            var department = _db.Departments.Find(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // This Methode To Display The Form 

        public IActionResult Add()
        {


            return View("Add_Department");
        }



         // This Methode Is To Bind  The Dep 

        public IActionResult BindDep(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var department = _db.Departments.Find(id);
            if (department == null)
                return NotFound();

            ViewBag.Action = "Update Department  ";


            return View("Add_Department",department);
        }



        // Add Department
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(Department dep)
        {
            if (ModelState.IsValid)
            {
                if (dep.IdDepartment == 0)
                {
                    _db.Departments.Add(dep);

                    // Add  Show Message 
                    Message = "Department Is Added Whith Sucess ";
                }else
                {
                    _db.Departments.Update(dep);
                    Message = "Department Is Updated Whith Sucess ";
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Add_Department", dep);
        }

        // This Methode Is To Delete A Department
       
         public IActionResult DelDepartment(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var dep = _db.Departments.Find(id);

            if (dep == null)
                return NotFound();
            
            // Logic To Remove On Cascade 
            var users =_db.Users.Where(u => u.IdDepartment == id).ToList();
             
            foreach(var user in users)
            {
                _db.Users.Remove(user);
            }



            _db.Departments.Remove(dep);
            _db.SaveChanges();


            // Add To Display  A  Message 
            Message = "Department Is Deleted  Whith Sucess ";


            return RedirectToAction("Index");
        }


    }
}
