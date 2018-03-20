using Airlines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Business.Manager
{
    public class FindRoute
    {
        Session3Entities session3 = new Session3Entities();
        int counter;             //USE FOR IMPLEMENT ARRAY NAME
        int totalnode;           //TOTAL NUMBER OF NODE
        List<string> single_result;
        public List<List<string>> RouteResult { get; }
        public DateTime Start_Date { get; set; }

        //MAIN
        public List<DateTime>[,] STime;
        public List<DateTime>[,] FTime;
        string[] name;
        int[] trace;
        DateTime[,] trace_date;
        bool[] path;


        public FindRoute()
        {
            session3 = new Session3Entities();
            counter = 0;
            totalnode = session3.Airports.Count();
            single_result = new List<string>();
            RouteResult = new List<List<string>>();
        }

        #region Helper
        bool Is_Connected(string name1,string name2)
        {
            int i = session3.Routes.Where(r=>r.Airport.IATACode.Equals(name1)
                                        && r.Airport1.IATACode.Equals(name2)).Count();
            if (i > 0)
                return true;
            return false;
        }

        List<DateTime> GetListStart(string name1,string name2)
        {
            List<DateTime> result = new List<DateTime>();
            foreach (Schedule s in 
                session3.Schedules.Where(s=>s.Route.Airport.IATACode.Equals(name1) 
                && s.Route.Airport1.IATACode.Equals(name2)))
            {
                DateTime start = new DateTime(
                    s.Date.Year,
                    s.Date.Month,
                    s.Date.Day,
                    s.Time.Hours,
                    s.Time.Minutes,
                    s.Time.Seconds);
                result.Add(start);
            }
            return result;
        }

        List<DateTime> GetListFinish(string name1, string name2)
        {
            List<DateTime> result = new List<DateTime>();
            foreach (Schedule s in
                session3.Schedules.Where(s => s.Route.Airport.IATACode.Equals(name1)
                && s.Route.Airport1.IATACode.Equals(name2)))
            {
                DateTime finish = new DateTime(
                    s.Date.Year,
                    s.Date.Month,
                    s.Date.Day,
                    s.Time.Hours,
                    s.Time.Minutes,
                    s.Time.Seconds).Add(new TimeSpan(0, s.Route.FlightTime, 0));
                result.Add(finish);
            }
            return result;
        }

        void GetFlightNumber(string from,string to,DateTime time)
        {

        }
        #endregion

        public void Inputdata()
        {
            STime = new List<DateTime>[totalnode, totalnode];
            FTime = new List<DateTime>[totalnode, totalnode];
            name = new string[totalnode];
            trace = new int[totalnode];
            trace_date = new DateTime[totalnode,totalnode];
            path = new bool[totalnode];

            foreach (Airport a in session3.Airports)    //KHOI TAO MANG NAME
            {
                name[counter] = a.IATACode;
                counter++;
            }
            counter = 0;

            for (int i = 0; i < totalnode; i++)
            {
                for(int j = 0; j < totalnode; j++)
                {
                    if (Is_Connected(name[i], name[j]))
                    {
                        STime[i, j] = GetListStart(name[i], name[j]);
                        FTime[i, j] = GetListFinish(name[i], name[j]);
                    }
                }
            }
        }

        bool CheckPath(int i,int j)
        {
            int index;
            if (counter == 0 && STime[i, j] != null)
            {
                trace[j] = i;
                index = 0;
                foreach (DateTime date in STime[i, j])
                {
                    if (date >= Start_Date)
                    {
                        trace_date[i, j] = FTime[i, j][index];
                        counter++;
                        return true;
                    }
                    index++;
                }
                return false;
            }
            if (STime[i, j] != null)
            {
                index = 0;
                foreach (DateTime date in STime[i, j])
                {
                    if (trace_date[trace[i], i] < date && 
                        trace_date[trace[i], i] != DateTime.MinValue)
                    {
                        trace[j] = i;
                        trace_date[i,j] = FTime[i, j][index];
                        return true;
                    }
                    index++;
                }
            }
            return false;
        }

        public void FindFlightRoute(int checking,int finish_node)
        {
            if (!path[checking])
            {
                if (checking == finish_node)
                {
                    single_result.Add(checking.ToString());
                    RouteResult.Add(new List<string>(single_result));
                    path[checking] = false;
                    single_result.RemoveAt(single_result.Count()-1);
                    return;
                }
                path[checking] = true;
                single_result.Add(checking.ToString());
                for (int i = 0; i < totalnode; i++)
                {
                    if (CheckPath(checking,i))
                    {
                        FindFlightRoute(i, finish_node);
                    }
                }
                path[checking] = false;
                single_result.RemoveAt(single_result.Count()-1);
            }
        }
    }
}
