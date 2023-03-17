using Bitskraft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitskraft.Controllers
{
    public class BITSKRAFTController : Controller
    {
        // GET: BITSKRAFT
        bitskraftEntities db = new bitskraftEntities();
        public ActionResult AllData()
        {
            var data = db.EmployeeRecords.ToList(); 
            return View(data);
        }

        //createing record to post in database and show the record in ALLdata(LIST)
        [HttpGet]

        public ActionResult createRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createRecord(EmployeeRecord emprec) 
        {
            EmployeeRecord employeeRecord = new EmployeeRecord();
            employeeRecord.FirstName = emprec.FirstName;
            employeeRecord.MiddleName = emprec.MiddleName;
            employeeRecord.LastName = emprec.LastName;
            employeeRecord.Email = emprec.Email;
            employeeRecord.Address = emprec.Address;
            employeeRecord.Number = emprec.Number;
            employeeRecord.Qualification = emprec.Qualification; 
            db.EmployeeRecords.Add(employeeRecord);
            db.SaveChanges();
            ModelState.Clear();
            Response.Write("<script>alert('Data inserted successfully')</script>");
            return RedirectToAction("AllData");
        }

        [HttpGet]
        public ActionResult editRecord(int id) 
        {
            var editemprecord = db.EmployeeRecords.Where(x=>x.id== id).FirstOrDefault();
            return View(editemprecord);
        }
        [HttpPost]
        public ActionResult editRecord(EmployeeRecord emprec)
        {
            var employeeRecord = db.EmployeeRecords.Where(x=>x.id== emprec.id).FirstOrDefault();
            if(employeeRecord!=null)
            {
                employeeRecord.FirstName = emprec.FirstName;
                employeeRecord.MiddleName = emprec.MiddleName;
                employeeRecord.LastName = emprec.LastName;
                employeeRecord.Email = emprec.Email;
                employeeRecord.Address = emprec.Address;
                employeeRecord.Number = emprec.Number;
                employeeRecord.Qualification = emprec.Qualification;
                db.SaveChanges();
                ModelState.Clear(); 
            }
            return RedirectToAction("ALLData");
        }
        [HttpGet]
        public ActionResult detailRecord(int id) 
        { 
            var employDetails = db.EmployeeRecords.Single(x=>x.id== id);
            return View(employDetails);
        }
        [HttpGet]
        public ActionResult deleteRecord(int id)
        {
            var deleteemployrecord = db.EmployeeRecords.Where(x=>x.id== id).FirstOrDefault();
            return View(deleteemployrecord);
        }
        [HttpPost]
        [ActionName("deleteRecord")]
        public ActionResult delete(int id)
        {
            var delemployrecord = db.EmployeeRecords.Where(x=>x.id==id).FirstOrDefault();
            db.EmployeeRecords.Remove(delemployrecord);
            db.SaveChanges();
            return RedirectToAction("ALLData");
        }

    }
}