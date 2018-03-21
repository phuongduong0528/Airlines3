using Airlines.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Airlines.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookFlightService" in both code and config file together.
    [ServiceContract]
    public interface IBookFlightService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/Seats/{scheduleid}",
            ResponseFormat = WebMessageFormat.Json)]
        int TotalSeats(string scheduleid);

        [OperationContract]
        [WebGet(
            UriTemplate = "/AvalibleSeats/{scheduleid}/{cabintype}",
            ResponseFormat = WebMessageFormat.Json)]
        int AvalibleSeats(string scheduleid, string cabintype);

        [OperationContract]
        [WebGet(
            UriTemplate = "/BookedSeats/{scheduleid}",
            ResponseFormat = WebMessageFormat.Json)]
        int BookedSeats(string scheduleid);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Flights",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<BookFlightDto> FindFlight(string from, string to, string date, string cabintype);

        [OperationContract]
        [WebGet(
            UriTemplate = "/Airports",
            ResponseFormat = WebMessageFormat.Json)]
        List<string> ListAirport();
    }
}
