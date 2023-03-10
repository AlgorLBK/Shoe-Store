using Assignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Security.Claims;

namespace Assignment1.Controllers
{
    public class RegistrationController : Controller
    {
        private RegisterContext context { get; set; }

        public RegistrationController(RegisterContext ctx)
        {
            context = ctx;        
        }

        [HttpGet]
        private bool isValid(string username,string password)
        {
            bool isv = false;
            using (context)
            {
                var algor = context.Registers.SingleOrDefault(u => u.username == username && u.password == password); 
                if (algor != null)
                {
                    isv = true;
                }
            }
            return isv;
             

        }

        public async Task<IActionResult> Login(string username, string password,string returnUrl = null)
        {
            
            ViewBag.Error = "";
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                if (isValid(username, password))
                {
                    ViewBag.Error = "Logged in !";
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                    ViewBag.Error = "The username or password is incorrect. Please try again.";
                }
            }
            return View();
        }
        public IActionResult Register(string username, string type, string password)
        {
            if (ModelState.IsValid)
            {
            Registration user = new Registration {username = username, type = type, password = password};
            context.Registers.Add(user);
            context.SaveChanges();
            }
            return View();
           
        }
    }
}
