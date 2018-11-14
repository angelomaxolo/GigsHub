using Gighub.Core.Dtos;
using Gighub.Core.Models;
using System.Collections.Generic;

namespace Gighub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
        void Add(Following following);
        void Remove(Following following);
        bool GetAny(FollowingDto dto, string userId);
        Following GetAnySingleOrDefaultDFollowing(string id, string userId);
        List<Following> GetFollowees(string userId);
       
    }
}