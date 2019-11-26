using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactBook.Models;
using ContactBook.ViewModels;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var viewModel = new ContactListViewModel
            {
                Contacts = read()
            };

            return View(viewModel);
        }

        public List<Contact> read()
        {
            var contactList = new List<Contact> { };

            using (var reader = new StreamReader("D:\\files.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    contactList.Add(new Contact
                    {
                        First_name = csv.GetField("First_name"),
                        Last_name = csv.GetField("Last_name"),
                        Middle_initial = csv.GetField("Middle_initial"),
                        Home_phone = csv.GetField("Home_phone"),
                        Cell_phone = csv.GetField("Cell_phone"),
                        Office_ext = csv.GetField("Office_ext"),
                        IRD = csv.GetField<int>("IRD"),
                        active = csv.GetField<Boolean>("active"),

                    });
                }
            }
            return contactList;
        }
        public ActionResult Delete(Contact contact)
        {
            return View(contact);
        }
        public ActionResult Update(Contact contact)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public IActionResult add()
        {
            Boolean active = false;
            if (Request.Form["Active"] == "on")
            {
                active = true;
            }
            var contactList = new List<Contact> { };
            contactList.Add(new Contact
            {
                First_name = Request.Form["First_name"],
                Last_name = Request.Form["Last_name"],
                Middle_initial = Request.Form["middle_Initial"],
                Home_phone = Request.Form["Home_phone"],
                Cell_phone = Request.Form["Cell_phone"],
                Office_ext = Request.Form["Office_ext"],
                IRD = int.Parse(Request.Form["IRD"]),
                active = active,
            });

            exportToCSV(contactList);
            var viewModel = new ContactListViewModel
            {
                Contacts = read()
            };
            return View("Index", viewModel);
        }
        public void exportToCSV(List<Contact> contactList)
        {
            contactList.AddRange(read());
            using (var writer = new StreamWriter("D:\\files.csv"))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(contactList);
            }

        }

    }
}