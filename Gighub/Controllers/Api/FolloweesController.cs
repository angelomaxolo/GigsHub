using Gighub.Core;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Gighub.Controllers.Api
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followees = _unitOfWork.Followings.GetFollowees(userId);

            return View(followees);
        }
    }
}