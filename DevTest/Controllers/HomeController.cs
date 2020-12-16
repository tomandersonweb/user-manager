using DevTest.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = userService.GetAllUsers().Take(10).ToList();
            
            return View("Index", users);
        }

        [HttpGet]
        public PartialViewResult GetPage(int page = 0)
        {
            var users = userService.GetAllUsers().Skip((page-1) * 10).Take(10).ToList();

            return PartialView("GetPage", users);
        }

        [HttpPost]
        public JsonResult Bookmark(string userId)
        {
            userService.BookmarkUser(Guid.Parse(userId));
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { userId });
        }
    }
}