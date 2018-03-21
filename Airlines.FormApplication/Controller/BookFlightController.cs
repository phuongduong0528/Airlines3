using Airlines.Services.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.FormApplication.Controller
{
    public class BookFlightController
    {
        private string BaseUrl = "http://localhost:8733/BookFlightService";

        public async Task<List<string>> AirportList()
        {
            RequestHandler<List<string>> request = new RequestHandler<List<string>>();
            request.Url = BaseUrl + "/Airports";
            List<string> result = await request.GetData();
            return result;
        }

        public async Task<List<BookFlightDto>> FindFlight(string _from,string _to, string _date,string _cabintype)
        {
            RequestHandler<List<BookFlightDto>> request = new RequestHandler<List<BookFlightDto>>();
            request.Url = BaseUrl + "/Flights";
            object o = new
            {
                from = _from,
                to = _to,
                date = _date,
                cabintype = _cabintype
            };
            List<BookFlightDto> result = await request.SubmitData(Method.POST, o);
            return result;
        }
    }
}
