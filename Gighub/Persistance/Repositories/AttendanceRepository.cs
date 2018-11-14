using Gighub.Core.Dtos;
using Gighub.Core.Models;
using Gighub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gighub.Persistance.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private  ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(int gigId, string userId)
        {

            return _context.Attendances
                .SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == userId);

        }

        public bool AttendanceAny(AttendanceDto dto, string userId)
        {
            return _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }

        public Attendance AttendanceSingleOrDefault(int id, string userId)
        {
            return _context.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == id);
        }
    }
}