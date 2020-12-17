using DevTest.Core.Abstract;
using DevTest.Models;
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
        private readonly IMembershipService membershipService;
        private readonly List<MembershipGroup> membershipGroups;

        public HomeController(IUserService userService, IMembershipService membershipService)
        {
            this.userService = userService;
            this.membershipService = membershipService;
            membershipGroups = this.membershipService.GetMembershipGroups();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = userService.GetAllUsers().Take(10)
                .Select(x => new UserModel()
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    LastName = x.LastName,
                    Title = x.Title,
                    MembershipGroups = membershipGroups
                });
            
            return View("Index", users);
        }

        [HttpGet]
        public PartialViewResult GetPage(int page = 0)
        {
            var users = userService.GetAllUsers().Skip((page-1) * 10).Take(10)
                .Select(x => new UserModel()
                {
                     UserId = x.UserId, 
                     UserName = x.UserName, 
                     LastName = x.LastName, 
                     Title = x.Title,
                     MembershipGroups = membershipGroups
                });

            return PartialView("GetPage", users);
        }

        [HttpPost]
        public JsonResult Bookmark(string userId)
        {
            try
            {
                userService.BookmarkUser(Guid.Parse(userId));
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { userId });
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("There was an error saving");
            }
        }

        [HttpPost]
        public JsonResult AddMembership(string userId, string groupId)
        {
            try
            {
                membershipService.SetMembership(Guid.Parse(userId), Guid.Parse(groupId));
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { userId, groupId });
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("There was an error saving");
            }
            
        }
    }
}