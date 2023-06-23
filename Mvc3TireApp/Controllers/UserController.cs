using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using System.Data;

namespace Mvc3TireApp.Controllers
{
    public class UserController : Controller
    {
        #region Object References
        Users Obj_User = new Users();
        #endregion

        #region Index

        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Details

        public ActionResult Details()
        {
            BL_User BlUsers = new BL_User();
            List<Users> UserLi = BlUsers.UserList.ToList();
            return View(UserLi);
        }

        #endregion

        #region Create_Get
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        #endregion

        #region Create_Post
        
        
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Users Usr)
        {
            //Users Usr = new Users();
            TryUpdateModel(Usr);
            if (ModelState.IsValid)
            {

                if (Usr.AddUsers())
                {
                    return RedirectToAction("Details");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        
        //[HttpPost]
        //public ActionResult Create(FormCollection frmColls)
        //{
        //    Users Usr = new Users();
        //    Usr.UserName = frmColls["UserName"];
        //    Usr.Name = frmColls["Name"];
        //    Usr.Password = frmColls["Password"];
        //    Usr.MailId = frmColls["MailId"];
        //    if(Usr.AddUsers())
        //    {
        //        return RedirectToAction("Details");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //    //return View();
        //}
        #endregion

        #region Edit_Get
        [HttpGet]
        public ActionResult Edit(String UserName)
        {
            BL_User BlUsers = new BL_User();
            Obj_User.UserName = UserName;
            Users SingleUser = BlUsers.UserList.Single(Usr => Usr.UserName == UserName);
            return View(SingleUser);
        }
        #endregion

        #region Edit_Post
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(String UserName)
        {
            BL_User BlUsers = new BL_User();
            Obj_User.UserName = UserName;
            Users Usr = BlUsers.UserList.Single(Usrr => Usrr.UserName == UserName);
            TryUpdateModel(Usr, new String[] { "UserName", "Password", "Name", "MailId" });
            if (ModelState.IsValid)
            {

                if (Usr.EditUsers())
                {
                    return RedirectToAction("Details");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        
        //public ActionResult Edit(Users Usr)
        //{
        //    TryUpdateModel(Usr);
        //    if (ModelState.IsValid)
        //    {

        //        if (Usr.EditUsers())
        //        {
        //            return RedirectToAction("Details");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    return View();
        //}
        #endregion

        [HttpPost]
        public ActionResult Delete(String UserName)
        {
            Obj_User.UserName = UserName;
            if (Obj_User.DeleteUsers())
            {
                return RedirectToAction("Details");
            }
            else
            {
                return View();
            }
        }
    }
}
