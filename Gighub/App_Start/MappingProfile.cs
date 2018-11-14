using AutoMapper;
using Gighub.Core.Dtos;
using Gighub.Core.Models;

namespace Gighub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<Attendance, AttendanceDto>();
            Mapper.CreateMap<Following, FollowingDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}