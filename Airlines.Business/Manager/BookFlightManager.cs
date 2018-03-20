using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines.Business.Models;

namespace Airlines.Business.Manager
{
    public class BookFlightManager : IBookFlightManager
    {
        Session3Entities session3;

        public BookFlightManager()
        {
            session3 = new Session3Entities();
        }

        public int AvalibleSeats(int scheduleid, string cabintype)
        {
            int result = 0;
            switch (cabintype)
            {
                case "Economy":
                    result = session3.Schedules.Single(s => s.ID == scheduleid).Aircraft.EconomySeats -
                session3.Tickets.Where(t => t.ScheduleID == scheduleid && t.CabinType.Name.Equals("Economy")).Count();
                    break;
                case "Business":
                    result = session3.Schedules.Single(s => s.ID == scheduleid).Aircraft.BusinessSeats -
                session3.Tickets.Where(t => t.ScheduleID == scheduleid && t.CabinType.Name.Equals("Business")).Count();
                    break;
                case "First Class":
                    result = session3.Schedules.Single(s => s.ID == scheduleid).Aircraft.EconomySeats -
                session3.Tickets.Where(t => t.ScheduleID == scheduleid && t.CabinType.Name.Equals("First Class")).Count();
                    break;
            }
                
            return result;
        }

        public int BookedSeats(int scheduleid)
        {
            return session3.Schedules.Single(s => s.ID == scheduleid).Aircraft.TotalSeats -
                session3.Tickets.Where(t => t.ScheduleID == scheduleid).Count();
        }

        public List<string> FindFlight(string from, string to, DateTime time)
        {
            throw new NotImplementedException();
        }

        public int TotalSeats(int scheduleid)
        {
            return session3.Schedules.Single(s => s.ID == scheduleid).Aircraft.TotalSeats;
        }
    }
}
