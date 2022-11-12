using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autofac;
using BurlingServer;

namespace BurlingtonTest.Controllers
{
    public class UsersController : Controller
    {
        IContainer container;

        public UsersController()
        {
            try
            {
                //init dependency injection
                var builder = new ContainerBuilder();
                builder.RegisterType<UserService>().As<IUserService>();
                container = builder.Build();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            try
            {
                return View(container.Resolve<IUserService>().GetAllUsers());
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return RedirectToAction("Index","Home");
        }

        /// <summary>
        /// Get users list as Partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult _UserTable()
        {
            try
            {
                return PartialView(container.Resolve<IUserService>().GetAllUsers());
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }
        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">user to add</param>
        /// <returns></returns>
        public ActionResult AddUser(User user)
        {
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                {
                    container.Resolve<IUserService>().AddUser(user.FirstName, user.LastName);
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return Json("failed", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Edit user data
        /// </summary>
        /// <param name="user">user to edit</param>
        /// <returns></returns>
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                {
                    container.Resolve<IUserService>().EditUser(user);
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return Json("failed", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id">user id to delete</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                container.Resolve<IUserService>().DeleteUser(id);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return Json("failed", JsonRequestBehavior.AllowGet);
        }

    }
}
