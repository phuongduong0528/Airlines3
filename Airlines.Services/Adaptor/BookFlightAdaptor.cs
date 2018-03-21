using Airlines.Business.Models;
using Airlines.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Services.Adaptor
{
    public class BookFlightAdaptor
    {
        Session3Entities session3;

        public BookFlightAdaptor()
        {
            session3 = new Session3Entities();
        }

        public BookFlightDto GetBookFlightDto(int[] id,string cabintype)
        {
            if (id.Length != 0)
            {
                decimal multiple = 1;
                switch (cabintype)
                {
                    case "Business":
                        multiple = (decimal)1.35;
                        break;
                    case "First class":
                        multiple = (decimal)1.755;
                        break;
                    default:
                        multiple = 1;
                        break;
                }

                string flightnumber = "";
                decimal price = 0;
                int first_id = id[0];
                int last_id = id[id.Length - 1];
                foreach (int i in id)
                {
                    flightnumber += $"[{session3.Schedules.SingleOrDefault(s => s.ID == i).FlightNumber}] -";
                    price += Math.Ceiling(session3.Schedules.SingleOrDefault(s => s.ID == i).EconomyPrice * multiple);
                }
                flightnumber = flightnumber.Remove(flightnumber.Length - 2);
                BookFlightDto bookFlightDto = new BookFlightDto();
                bookFlightDto.From = session3.Schedules.SingleOrDefault(s => s.ID == first_id).Route.Airport.IATACode;
                bookFlightDto.To = session3.Schedules.SingleOrDefault(s => s.ID == last_id).Route.Airport1.IATACode;
                bookFlightDto.Date = session3.Schedules.SingleOrDefault(s => s.ID == first_id).Date.ToString("dd/MM/yyyy");
                bookFlightDto.Time = session3.Schedules.SingleOrDefault(s => s.ID == first_id).Time.ToString();
                bookFlightDto.FlightNumber = flightnumber;
                bookFlightDto.CabinPrice = price.ToString("C1",CultureInfo.CurrentCulture);
                bookFlightDto.NumberOfStops = id.Length - 1;

                return bookFlightDto;
            }
            else
                return null;
        }

        public List<BookFlightDto> GetListBookFlightDto(List<int[]> routevalue, string cabintype)
        {
            try
            {
                List<BookFlightDto> result = new List<BookFlightDto>();
                foreach (int[] i in routevalue)
                {
                    result.Add(GetBookFlightDto(i, cabintype));
                }
                return result.OrderBy(a=>a.Date).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
