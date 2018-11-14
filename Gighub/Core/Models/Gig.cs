using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gighub.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }


        public string Venue { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {

            //otherwise set IsCanceled to true
            IsCanceled = true;

            //send notification to all attendees of that gig
            var notification = Notification.GigCanceled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            //here i created a notification which is of type gig updated
           var notification =  Notification.GigUpdated(this, DateTime, Venue);

            //here i am updating the gig with the arguments passed in the method
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            //finally i iterate over the attendees of this gig and notify them
            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);


        }
    }
}