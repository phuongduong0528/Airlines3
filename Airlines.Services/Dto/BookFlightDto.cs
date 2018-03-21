using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Services.Dto
{
    [DataContract]
    public class BookFlightDto
    {
        [DataMember(Name = "from", Order = 0)]
        [DisplayName("From")]
        public string From { get; set; }

        [DataMember(Name = "to", Order = 1)]
        [DisplayName("To")]
        public string To { get; set; }

        [DataMember(Name = "date", Order = 2)]
        [DisplayName("Date")]
        public string Date { get; set; }

        [DataMember(Name = "time", Order = 3)]
        [DisplayName("Time")]
        public string Time { get; set; }

        [DataMember(Name = "flightnumber", Order = 4)]
        [DisplayName("Flight number(s)")]
        public string FlightNumber { get; set; }

        [DataMember(Name = "cabinprice", Order = 5)]
        [DisplayName("Cabin price")]
        public string CabinPrice { get; set; }

        [DataMember(Name = "numberofstops", Order = 6)]
        [DisplayName("Number of stops")]
        public int NumberOfStops { get; set; }
    }
}
