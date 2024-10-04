// Smith Nielson
// 10735328

using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
       
       // property to get and set the value of a ContactsContext object
        private ContactContext context { get; set; }

        // constructor that receives an object of the Context class
        // and assigns it to the context object using a lambda expression
        // via the MovieContext property declared previously
        public HomeController(ContactContext ctx) => context = ctx;

        public IActionResult Index()
        {
            // calls the OrderBy method to sort by Name using a lambda
            // expression and then converts to a list using ToList() method
            // and assigns it to the movies variable

            var contacts = context.Contacts
                .Include(c => c.Category)
                .OrderBy(m => m.First).ToList();

            // returns the value of the movies variable to the View (
            return View(contacts);
        }
    }
    }

