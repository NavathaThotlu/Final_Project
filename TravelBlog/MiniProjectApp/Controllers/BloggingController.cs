using MiniProjectApp.Models;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;

namespace MiniProjectApp.Controllers
{
    [Authorize]
    public class BloggingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProfileData()
        {
            var data = new Blogt();
            return View(data);
        }
        public ActionResult AddBlogs()
        {
            if (Session["UserData"]==null)
            {
                TempData["ErrorInfo"] = "Please login before adding blogs";
                TempData.Keep();
            }
            var user = Session["UserData"] as UserT;
            var blog = new Blogt();
            blog.Userid = user.User_Id;
            blog.UserT= user; ;
            return View(blog);
        }
        [HttpPost]
        public ActionResult AddBlogs(Blogt blogsTable)
        {
            var context = new COMPANYEntities();
            context.Blogts.Add(blogsTable);
            context.SaveChanges();
            return View("Index");
        }
        public ActionResult DisplayBlogs()
        {
            var context = new COMPANYEntities();
            var data = context.Blogts.ToList();
            return View(data);
        }
        public ActionResult EditBlogs(string Id)
        {
            var context = new COMPANYEntities();
           var BId=int.Parse(Id);
            var selected=context.Blogts.SingleOrDefault(b=>b.BlogId==BId);
            return View(selected);
        }
        [HttpPost]
        public ActionResult UpdateBlogs(Blogt blogsTable)
        {
            var context = new COMPANYEntities();
            var selected = context.Blogts.SingleOrDefault(b => b.BlogId == blogsTable.BlogId);
            if(selected==null)
            {
                throw new System.Exception("Blog is not found");
            }
            selected.Title = blogsTable.Title;
            selected.Userid = blogsTable.Userid;
            selected.Images = blogsTable.Images;
            selected.Details= blogsTable.Details;
            selected.ratings= blogsTable.ratings;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlogs(string Id) 
        {
            var context=new COMPANYEntities();
            var BId = int.Parse(Id);
            var model = context.Blogts.SingleOrDefault(b=>b.BlogId==BId);
            context.Blogts.Remove(model);  
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}