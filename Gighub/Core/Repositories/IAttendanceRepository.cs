using Gighub.Core.Dtos;
using Gighub.Core.Models;
using System.Collections.Generic;

namespace Gighub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int gigId, string userId);
        bool AttendanceAny(AttendanceDto dto, string userId);
        void Add(Attendance attendance);
        Attendance AttendanceSingleOrDefault(int id, string userId);
        void Remove(Attendance attendance);
    }
}