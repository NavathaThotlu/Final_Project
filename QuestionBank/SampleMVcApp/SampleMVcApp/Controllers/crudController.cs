using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVcApp.Models;

namespace SampleMVcApp.Controllers
{
    public class crudController : Controller
    {
        public ActionResult AllRecords()
        {
            var context = new COMPANYEntities();
            var model = context.Patients.ToList();
            return View(model);
        }
        public ViewResult ViewRec(string id)
        {
            var context = new COMPANYEntities();
            var pid = int.Parse(id);
            var model = context.Patients.Where((p) => p.id == pid).FirstOrDefault();//SELECT * From EmpTable where Id = empId;
            return View(model);
        }
        public ActionResult UpdateRec(Patient postedData)
        {
            //create a context object
            var context = new COMPANYEntities();
            //find matching rec

            var model = context.Patients.Where((p) => p.id == postedData.id).FirstOrDefault();//select * from table Doctor
            if (model == null) throw new Exception("This is not found to Update");
            //set new values to old records
            model.pname = postedData.pname;
            model.pcno = postedData.pcno;
            model.pbill = postedData.pbill;
            model.date = postedData.date;
            model.doctore_id = postedData.doctore_id;
           
            //save the chnages
            context.SaveChanges();
            //return the view
            return RedirectToAction("AllRecords");
        }
        public ActionResult AddNew()
        {
            var newRec = new Patient();//Create a Blank object
            return View(newRec);//Inject it as model to the View...
        }
        [HttpPost]
        public ActionResult AddNew(Patient postedData)
        {
            //Create the Context object..
            var context = new COMPANYEntities();
            //Add the new record to the EmpTables Collecion
            context.Patients.Add(postedData);
            //Save the changes
            context.SaveChanges();
            //Redirect to the AllRecords..
            return RedirectToAction("AllRecords");
        }
        public ActionResult Delete(string id)
        {
            var context = new COMPANYEntities();
            var pid = int.Parse(id);
            var model = context.Patients.Where((p) => p.id == pid).FirstOrDefault();//SELECT * From EmpTable where Id = empId;
            context.Patients.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllRecords");
        }

    }
}