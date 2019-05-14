﻿using System.Linq;
using Gucci.DataAccessLayer.Context;

namespace Gucci.ServiceLayer.Services
{
    public class CheckInService
    {
        // Check attendees list of current event for current user
        public bool CheckAttendanceList(int eventId, string username)
        {
            using (var ctx = new GreetNGroupContext())
            {
                // Find if username exists within corresponding event attendee table
                var found = ctx.Attendees.Any(events => events.EventId.Equals(eventId) && events.User.UserName.Equals(username));

                return found;
            }
        }

        // Check code inputted by user to id required by the event
        public bool CheckInputCode(int eventId, string input)
        {
            using (var ctx = new GreetNGroupContext())
            {
                // perform search for current event and compares EventCheckInCode with input
                var verified = ctx.Events.First(events => events.EventId.Equals(eventId)).EventCheckinCode
                   .Equals(input);

                return verified;
            }
        }
    }
}
