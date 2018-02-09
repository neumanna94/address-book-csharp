using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;
using System.Collections.Generic;

namespace Addressbook.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost("/")]
        public ActionResult AddressList()
        {
            //Request.Form for HttpPost Requests
            //Request.Query for HttpGet Requests
            //Use Request. when wanting to get variable information from forms.
            string name = Request.Form["name"];
            string number = Request.Form["number"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            Contact fun = new Contact(name, number, email, address);
            fun.PushToList();
            List<Contact> allContacts = Contact.GetAll();
            return View(allContacts);
        }
        [HttpGet("/")]
        public ActionResult AddressListDisp()
        {
            List<Contact> allContacts = Contact.GetAll();
            return View("addressList", allContacts);

        }
        [HttpGet("/deleteAll")]
        public ActionResult DeleteAll()
        {
            Contact.ClearAll();
            List<Contact> allContacts = Contact.GetAll();
            return View("addressList", allContacts);
        }
        [HttpGet("/form")]
        public ActionResult Form()
        {
            return View();
        }

        [HttpGet("/{id}")]
        public ActionResult addressDetail(int id){
            return View(Contact.Find(id));
        }
    }
}
