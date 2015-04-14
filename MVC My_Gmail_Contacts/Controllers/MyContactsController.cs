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
    public class MyContactsController : Controller
    {
        // GET: MyContacts
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


        // GET: My_Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //string query = "SELECT Contact_ID, Name, Email, DOB FROM My_Gmail_Contacts WHERE Contact_ID = " + id + ";";
             Dictionary<string, object> data=new Dictionary<string,object>();
             data.Add("id",id);

            DataSet ds = My_Contacts.SendDataSet("Details_Contact",data);

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


        // GET: My_Contacts/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: My_Contacts/Create
        [HttpPost]
        public ActionResult Create(My_Contacts My_Contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //string query = "INSERT INTO My_Gmail_Contacts(Name,DOB,Email) VALUES('" + My_Contacts.Name + "','" + My_Contacts.DOB + "','" + My_Contacts.Email + "')";
                    Dictionary<string, object> data=new Dictionary<string,object>();
                    data.Add("Name",My_Contacts.Name);
                    data.Add("DOB",My_Contacts.DOB);
                    data.Add("Email",My_Contacts.Email);
                  
                    My_Contacts.ExecuteCommand("Add_Contact", data);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: My_Contacts/Edit/5
        public ActionResult Edit(int? id)
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


        // POST: My_Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "Contact_ID,Name,Email,DOB")] My_Contacts contact)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    string query = "UPDATE My_Gmail_Contacts SET Name = '" + contact.Name + "', Email= '" + contact.Email + "', DOB = '" + contact.DOB + "' WHERE Contact_ID = " + id + ";";
                    My_Contacts.ExecuteCommand(query);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(contact);
            }
            return View(id);
        }


        // GET: My_Contacts/Delete/5
        public ActionResult Delete(int? id)
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


        // POST: My_Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                //Movie movie = db.Movies.Find(id);
                string query = "DELETE FROM My_Gmail_Contacts WHERE Contact_ID = " + id + ";";
                My_Contacts.ExecuteCommand(query);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
