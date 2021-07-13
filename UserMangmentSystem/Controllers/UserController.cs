using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMangmentSystem.Models;
using UserMangmentSystem.Data;
using UserMangmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserMangmentSystem.Controllers
{
    public class UserController : Controller
    {
         // This Is Used To Display The Message During Redirection 
        [TempData]
        public string Message { get; set; }

        // Depndecy Injection 

        private readonly AplicationDbContext _db;

        public UserController(AplicationDbContext _db)
        {
            this._db = _db;
        }


        // This Methode To Show All User And Department 
        public IActionResult Index()
        {
            IEnumerable<User> UserList = _db.Users;
            // Must use Join Or Foreach to load The Department Table
            // Load The 2 Tabels
           
            foreach(var user in UserList)
            {
                user.Department = _db.Departments.FirstOrDefault(dep => dep.IdDepartment == user.IdDepartment);
            }



            return View(UserList);
        }

        // This Is To Show One User Details Page  
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var User = _db.Users.Find(id);

            if (User == null)
                return NotFound();

         
    
                User.Department = _db.Departments.FirstOrDefault(dep => dep.IdDepartment == User.IdDepartment);
          

            return View(User);
        }

        // Remove One User Using The Id

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            
            var User = _db.Users.Find(id);
            
            if (User == null)
                return NotFound();

            _db.Users.Remove(User);
            _db.SaveChanges(); // Must Be Added For Every Submit To Persite Date Like (Flush in Symfony)

            Message = "User Deleted Whith Sucess";
            return RedirectToAction("Index");
        }

        // This Methode To Display The Form 
        public IActionResult AddUser()
        {
            UserViewModel userVm = new UserViewModel()
            {
                user = new User(),
                TypeDropDown = _db.Departments.Select(i => new SelectListItem
                {
                    Text = i.NameDepartemnt,
                    Value = i.IdDepartment.ToString()
                })
            };


            return View(userVm);
        }




        // This Methode To Add User AnD Update 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(UserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.user.Id == 0)
                {
                    _db.Users.Add(obj.user);
                  

                    Message = "User Added Whith Sucess";
                }
                else
                {
                    _db.Users.Update(obj.user);
                    Message = "User Updated Whith Sucess";

                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }


        // This Methode To Bind The User 
         public IActionResult BindUser(int? id )
        {
            // Must Bind The props Of The Curent User To The Object 

            if (id == null || id == 0)
                return NotFound();
            var user = _db.Users.Find(id);

            if (user == null)
                return NotFound();

            UserViewModel userVm = new UserViewModel()
            {
                user = user,
                TypeDropDown = _db.Departments.Select(dep =>new SelectListItem
                {
                  Text= dep.NameDepartemnt,
                  Value = dep.IdDepartment.ToString(),
                })
            };

            ViewBag.Action = "Update User";

            return View("AddUser",userVm);
        }



        // This Methode To Update The User 

        public IActionResult UpdateUser()
        {
            return RedirectToAction("Index");
        }




        // This To Display The About Page
        public IActionResult About()
        {
            return View();
        }


    }
}
