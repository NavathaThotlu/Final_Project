using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using SampleMVcApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVcApp.Controllers
{
    public class QuizController : Controller
    {
        COMPANYEntities db = new COMPANYEntities();

        public IFormatProvider Culture { get; private set; }

        // GET: Quiz
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult AllQuestions()
        {
            var context = new COMPANYEntities();
            var data = db.Database.SqlQuery<Questions>("Allquestions");
            //var context = new COMPANYEntities();
            var model = db.Allquestions().ToList();
            ViewData["list"] = model;
            return View();
        }
        

        public ActionResult tblquestions()
        {
            var context = new COMPANYEntities();
            var model = context.tbl_questions.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add_Category()
        {
            List<tbl_category> catlist = db.tbl_category.OrderByDescending(x => x.car_id).ToList();
            ViewData["list"] = catlist;

            return View();
        }
        [HttpPost]
        public ActionResult Add_Category(tbl_category cat)
        {

            List<tbl_category> catlist = db.tbl_category.OrderByDescending(x => x.car_id).ToList();
            ViewData["list"] = catlist;

            tbl_category c = new tbl_category();
            c.cat_name = cat.cat_name;

            db.tbl_category.Add(c);
            db.SaveChanges();
            return RedirectToAction("Add_Category");
        }
        [HttpGet]
        public ActionResult AddQuestions()
        {
            int sid = Convert.ToInt32(Session["ad_id"]);
            var context = new COMPANYEntities();
            List<tbl_category> catlist = db.tbl_category.OrderByDescending(x => x.car_id).ToList();
            ViewBag.list = new SelectList(catlist, "car_id", "cat_name");
            return View();
        }
        [HttpPost]
        public ActionResult AddQuestions(tbl_questions q)
        {
            //List<tbl_category> catlist = db.tbl_category.OrderByDescending(x => x.car_id).ToList();
            //ViewData["list"] = catlist;
            var context = new COMPANYEntities();
            List<tbl_category> catlist = db.tbl_category.OrderByDescending(x => x.car_id).ToList();
            //ViewData["list"] = catlist;
            ViewBag.list = new SelectList(catlist, "car_id", "cat_name");
            tbl_questions qa = new tbl_questions();
            qa.q_text = q.q_text;
            qa.QA = q.QA;
            qa.QB = q.QB;
            qa.QC = q.QC;
            qa.QD = q.QD;
            qa.QcorrectAns = q.QcorrectAns;
            qa.car_id = q.car_id;
            db.tbl_questions.Add(q);
            db.SaveChanges();
            ViewBag.ms = "Questions Addes successfully";
            return RedirectToAction("AddQuestions");

        }
        public ViewResult ViewRec(string q_id)
        {
            var context = new COMPANYEntities();
            var empId = int.Parse(q_id);
            var model = context.tbl_questions.Where((emp) => emp.q_id == empId).FirstOrDefault();//SELECT * From EmpTable where Id = empId;
            return View(model);
        }

        //Id of the Question
        [HttpPost]
        public ActionResult Updatequestions(tbl_questions postedData)
        {
            //create the context object.
            var context = new COMPANYEntities();
            //Find the matching record
            var model = context.tbl_questions.FirstOrDefault((e) => e.q_id == postedData.q_id);
            if (model == null) throw new Exception("This is not found to update");


            model.q_text = postedData.q_text;
            model.QA = postedData.QA;
            model.QB = postedData.QB;
            model.QC = postedData.QC;
            model.QD = postedData.QD;
            model.QcorrectAns = postedData.QcorrectAns;


            context.SaveChanges();
            //Return to the view.
            return RedirectToAction("tblquestions");//Redirecting to the method called AllRecord
        }


    }
}


   