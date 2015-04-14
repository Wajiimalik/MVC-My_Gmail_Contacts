using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Net;
using MVC_My_Gmail_Contacts.Models;

namespace MVC_My_Gmail_Contacts.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string query = "SELECT Contact_ID, Name, Email, DOB FROM My_Gmail_Contacts ORDER BY Contact_ID";

            DataSet ds = My_Contacts.SendDataSet(query);

            List<My_Contacts> My_ContactsList = new List<My_Contacts>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                My_ContactsList.Add(new My_Contacts { Contact_ID = Convert.ToInt32(dr["Contact_ID"]), Name = Convert.ToString(dr["Name"]), Email = Convert.ToString(dr["Email"]), DOB = Convert.ToString(dr["DOB"]) });
            }

            return View(My_ContactsList);
        }

        // GET: Default/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string query = "SELECT Contact_ID, Name, Email, DOB FROM My_Gmail_Contacts WHERE Contact_ID = " + id + ";";
            DataSet ds = My_Contacts.SendDataSet(query);

            if (ds == null)
            {
                return HttpNotFound();
            }

            My_Contacts contact = new My_Contacts();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                contact = new My_Contacts { Contact_ID = Convert.ToInt32(dr["Contact_ID"]), Name = Convert.ToString(dr["Name"]), Email = Convert.ToString(dr["Email"]), DOB = Convert.ToString(dr["DOB"]) };
            }

            return View(contact);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
