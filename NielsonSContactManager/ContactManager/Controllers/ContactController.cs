// Smith Nielson
// 10735328

using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;



namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        // context property setter to get and set context
        private ContactContext context { get; set; }
        
        public ContactController(ContactContext ctx) => context = ctx;

        // add and edit both display the edit view 
        [HttpGet]
        public IActionResult Add() // passes an empty Movie object
        {
            ViewBag.Action = "Add"; // setting viewbag action = to add 
            ViewBag.Categories = context.Category.OrderBy(g => g.Name).ToList(); // getting list of categories to display in drop down
            return View("Edit", new Contacts()); // returning view of Edit page 
        }

        // HttpGet to get data from model based on contact id
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit"; // sets action = to Edit
            ViewBag.Categories = context.Category.OrderBy(g => g.Name).ToList(); // getting list of categories to disaly in dropdown

            // creates new variable named contact that will store all the contact 
            // data from the contact that matches the contact id the index page sent 
            var contacts = context.Contacts
                .Include(g => g.Category)
                .FirstOrDefault(m => m.Id == id);

            return View(contacts); // returns view with data saved as contacts 
        }

        //HttpPost to send that data that has been added/edited
        [HttpPost]
        public IActionResult Edit(Contacts contacts) // passes an object of the Contacts class
        {
            // if contact id = 0 then the action is set to Add, else action is set to Edit
            string action = (contacts.Id == 0) ? "Add" : "Edit"; 

            if (ModelState.IsValid) // user entered valid data
            {
                if (action == "Add") // if action = add then it will add a new contact with current date time
                {
                    contacts.DateTime = DateTime.Now; // sets date time = to current date time
                    context.Contacts.Add(contacts); // adds contact to context 
                }
                else
                {
                    // if not equal to 0, it is an existing movie
                    contacts.DateTime = DateTime.Now; // updates current time to now
                    context.Contacts.Update(contacts); // updates current contact based on user input
                }
                context.SaveChanges(); // causes inserting or updating
                return RedirectToAction("Index", "Home"); // sends user back home
            }
            else // user did not enter valid data
            {
                ViewBag.Action = action; // (movie.MovieId == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Category.OrderBy(g => g.Name).ToList(); // creating variable to store all categories
                return View(contacts); // returns view 
            }
        }

        // Delete() method is "overloaded" to handle both GET and POST request
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contacts = context.Contacts.Find(id); // sets contacts = to the data from the contact id
            return View(contacts); // returns view with data
        }

        [HttpPost]
        public IActionResult Delete(Contacts contacts)
        {
            context.Contacts.Remove(contacts); // deletes data from db
            context.SaveChanges(); // saves changes
            return RedirectToAction("Index", "Home"); // sends user back home
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Details"; // sets action = to details
            ViewBag.Category = context.Category.OrderBy(g => g.Name).ToList(); // creating variable to store categories

            var contact = context.Contacts
                .Include(g => g.Category)
                .FirstOrDefault(m => m.Id == id); // returns data based on the id that was passed from previous page

            return View(contact); // returns view with data 
        }
    }
}
