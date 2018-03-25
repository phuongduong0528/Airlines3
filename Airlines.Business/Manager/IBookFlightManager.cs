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
        List<string> GetListAirport();
        List<List<int>> FindFlight(string from,string to,DateTime time);
        int TotalSeats(int scheduleid);
        int AvalibleSeats(int scheduleid, string cabintype);
        int BookedSeats(int scheduleid);
    }
}
