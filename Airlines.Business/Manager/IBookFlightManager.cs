using Airlines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Business.Manager
{
    interface IBookFlightManager
    {
        List<Schedule> FindFlight(string from,string to,string cabintype,DateTime time,bool display);
        int TotalSeats(int scheduleid, string cabintype);
        int AvalibleSeats(int scheduleid, string cabintype);
        int BookedSeats(int scheduleid, string cabintype);
        bool ConfirmTicket();
    }
}
