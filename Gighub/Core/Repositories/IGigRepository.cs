using Gighub.Core.Models;
using System.Collections.Generic;

namespace Gighub.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetAllUpcomingGigs();
        IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
        Gig GetUserGig(int gigId);
        Gig GetGigwithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        void Add(Gig gig);
    }
}