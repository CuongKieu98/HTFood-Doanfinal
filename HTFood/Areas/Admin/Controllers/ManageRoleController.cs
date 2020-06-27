using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTFood.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace HTFood.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị viên")]
    public class ManageRoleController : Controller
    {
        // GET: Admin/ManageRole
      
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var model = context.Roles.AsEnumerable();
            return View(model);
        }
        public ViewResult Create()

        {

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(IdentityRole role)

        {

            try

            {

                if (ModelState.IsValid)

                {

                    context.Roles.Add(role);

                    context.SaveChanges();

                }

                return RedirectToAction("Index");

            }

            catch (Exception ex)

            {

                ModelState.AddModelError("", ex.Message);

            }

            return View(role);

        }
        public ActionResult Delete(string Id)

        {

            var model = context.Roles.Find(Id);

            return View(model);

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        [ActionName("Delete")]

        public ActionResult DeleteConfirmed(string Id)

        {

            IdentityRole model = null;

            try

            {

                model = context.Roles.Find(Id);

                context.Roles.Remove(model);

                context.SaveChanges();

                return RedirectToAction("Index");

            }

            catch (Exception ex)

            {

                ModelState.AddModelError("", ex.Message);

            }

            return View(model);

        }
    }
}