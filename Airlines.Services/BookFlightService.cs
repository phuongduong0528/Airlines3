using Airlines.Business.Manager;
using Airlines.Services.Adaptor;
using Airlines.Services.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Airlines.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookFlightService" in both code and config file together.
    public class BookFlightService : IBookFlightService
    {
        private BookFlightAdaptor bookFlightAdaptor = new BookFlightAdaptor();

        private BookFlightManager _bookFlightManager;

        public BookFlightManager BookFlightManager => _bookFlightManager ??
            (_bookFlightManager = new BookFlightManager());

        public int AvalibleSeats(string scheduleid, string cabintype)
        {
            int i;
            if (Int32.TryParse(scheduleid, out i))
            {
                i = BookFlightManager.AvalibleSeats(i, cabintype);
                return i;
            }
            else
                return 0;
        }

        public int BookedSeats(string scheduleid)
        {
            int i;
            if (Int32.TryParse(scheduleid, out i))
            {
                i = BookFlightManager.BookedSeats(i);
                return i;
            }
            else
                return 0;
        }

        public List<BookFlightDto> FindFlight(string from, string to, string date, string cabintype)
        {
            DateTime d;
            if(DateTime.TryParseExact(date,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out d))
            {
                return bookFlightAdaptor.GetListBookFlightDto(
                BookFlightManager.FindFlight(from, to, d),cabintype);
            }
            else
            {
                return null;
            }
        }

        public List<string> ListAirport()
        {
            return BookFlightManager.GetListAirport();
        }

        public int TotalSeats(string scheduleid)
        {
            int i;
            if (Int32.TryParse(scheduleid, out i))
            {
                i = BookFlightManager.TotalSeats(i);
                return i;
            }
            else
                return 0;
        }
    }
}
