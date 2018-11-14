using Gighub.Core.Dtos;
using Gighub.Core.Models;
using Gighub.Persistance;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;
       // private readonly IUnitOfWork _unitOfWork;

        public AttendancesController()
        {

            //_unitOfWork = unitOfWork;
            _context = new ApplicationDbContext();
        }
 
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (AttendanceAny(dto, userId))
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            //_unitOfWork.Attendances.Add(attendance);
            //_unitOfWork.Complete();
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

        private bool AttendanceAny(AttendanceDto dto, string userId)
        {
            return _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
        }

        //When you click the going button with no question mark
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            //get attendance of currently logged in user
            var attendance = AttendanceSingleOrDefault(id, userId);
            
            //Check to see if the attendance is not null
            if (attendance == null)
                return NotFound();

            //Remove the attendance from the database
           // _unitOfWork.Attendances.Remove(attendance);
            //_unitOfWork.Complete();
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return Ok(id);
        }

        private Attendance AttendanceSingleOrDefault(int id, string userId)
        {
            return _context.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == id);
        }
    }
}
