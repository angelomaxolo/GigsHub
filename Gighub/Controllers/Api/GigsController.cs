using Gighub.Core.Models;
using Gighub.Persistance;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            //find gig with given id
            var userId = User.Identity.GetUserId();
            var gig = GetSingleGig(id, userId);

            //if the gig is canceled return not found
            if (gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId != userId)
                return Unauthorized();

            //otherwise the below method must be executed
            gig.Cancel();

            //finally save changes
            _context.SaveChanges();

            return Ok();
        }

        private Gig GetSingleGig(int id, string userId)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);
        }
    }
}
