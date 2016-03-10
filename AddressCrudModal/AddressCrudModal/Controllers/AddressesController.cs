using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AddressCrudModal.Models;

namespace AddressCrudModal.Controllers
{
    public class AddressesController : Controller
    {
        private DataDb db = new DataDb();


        // GET: Addresses
        public ActionResult Index()
        {
            return View("Index");
        }
        
        // GET: Addresses List
        public ActionResult IndexList()
        {
            return PartialView("IndexPartial", db.Addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return PartialView("DetailsPartial", address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return PartialView("CreatePartial");

        }

        // POST: Addresses/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,City,Street,Phone")] Address address)
        {
            if (ModelState.IsValid)
            {
                string url = string.Empty;

                try
                {
                    db.Addresses.Add(address);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    url = Url.Action("Error", "Addresses");
                    return Json(new { success = false, url = url, error = ex.Message }); 
                }

                url = Url.Action("IndexList", "Addresses");
                return Json(new { success = true, url = url });
            }

            return PartialView("CreatePartial", address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return PartialView("EditPartial", address);
        }

        // POST: Addresses/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,City,Street,Phone")] Address address)
        {
            if (ModelState.IsValid)
            {
                string url = string.Empty;

                try
                {
                    db.Entry(address).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    url = Url.Action("Error", "Addresses");
                    return Json(new { success = false, url = url, error = ex.Message }); 
                    
                }

                url = Url.Action("IndexList", "Addresses");
                return Json(new { success = true, url = url });
            }
            return PartialView("EditPartial", address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return PartialView("DeletePartial", address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            string url = string.Empty;
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                url = Url.Action("Error", "Addresses");
                return Json(new { success = false, url = url, error = ex.Message }); 
            }
            url = Url.Action("IndexList", "Addresses");
            return Json(new { success = true, url = url }); 
        }

        // GET: Addresses/Error
        public ActionResult Error()
        {
            return PartialView("ErrorPartial");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
