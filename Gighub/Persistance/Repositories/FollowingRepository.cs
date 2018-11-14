using Gighub.Core.Dtos;
using Gighub.Core.Models;
using Gighub.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gighub.Persistance.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private  ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }

        public bool GetAny(FollowingDto dto, string userId)
        {
            return _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId);
        }

        public Following GetAnySingleOrDefaultDFollowing(string id, string userId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);
        }

        public List<Following> GetFollowees(string userId)
        {
            return _context.Followings
                .Where(a => a.FollowerId == userId)
                .Include(a => a.Followee)
                .ToList();
        }
    }
}