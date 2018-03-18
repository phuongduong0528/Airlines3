using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines.Business.Models;

namespace Airlines.Business.Manager
{
    class BookFlightManager : IBookFlightManager
    {
        Session3Entities session3;

        public BookFlightManager()
        {
            session3 = new Session3Entities();
        }

        public int AvalibleSeats(int scheduleid, string cabintype)
        {
            throw new NotImplementedException();
        }

        public int BookedSeats(int scheduleid, string cabintype)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmTicket()
        {
            throw new NotImplementedException();
        }

        public List<Schedule> FindFlight(string from, string to, string cabintype, DateTime time,bool display)
        {
            throw new NotImplementedException();
        }

        public int TotalSeats(int scheduleid, string cabintype)
        {
            //int result = session3.Schedules.SingleOrDefault(s=>s.ID==scheduleid).Aircraft.
            throw new Exception();
        }
    }
}
