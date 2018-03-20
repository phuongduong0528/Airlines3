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
        List<int> sr;
        public List<string> Result { get; }
        public string result_temp;
        public DateTime Start_Date { get; set; }

        //MAIN
        public List<DateTime>[,] STime;
        public List<DateTime>[,] FTime;
        int[] name;
        int[] trace;
        DateTime[,] trace_date;
        DateTime[,] trace_sdate;
        bool[] path;


        public FindRoute()
        {
            session3 = new Session3Entities();
            counter = 0;
            totalnode = session3.Airports.Count();
            sr = new List<int>();
            Result = new List<string>();
            result_temp = "";
            trace = new int[totalnode];
            trace_date = new DateTime[totalnode, totalnode];
            trace_sdate = new DateTime[totalnode,totalnode];
            path = new bool[totalnode];
        }

        #region Helper
        bool Is_Connected(int id1,int id2)
        {
            int i = session3.Routes.Where(r => r.Airport.ID == id1
                                        && r.Airport1.ID == id2).Count();
            if (i > 0)
                return true;
            return false;
        }

        List<DateTime> GetListStart(int id1,int id2)
        {
            List<DateTime> result = new List<DateTime>();
            foreach (Schedule s in
                session3.Schedules.Where(s => s.Route.Airport.ID == id1
                && s.Route.Airport1.ID == id2))
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

        List<DateTime> GetListFinish(int id1, int id2)
        {
            List<DateTime> result = new List<DateTime>();
            foreach (Schedule s in
                session3.Schedules.Where(s => s.Route.Airport.ID == id1
                && s.Route.Airport1.ID == id2))
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

        string GetFlightNumber(int from,int to,DateTime time)
        {
            return session3.Schedules.FirstOrDefault(s => s.Route.Airport.ID == from &&
                                                          s.Route.Airport1.ID == to &&
                                                          s.Date.Equals(time.Date) &&
                                                          s.Time.Equals(time.TimeOfDay)).FlightNumber;
        }
        #endregion

        public void Inputdata()
        {
            STime = new List<DateTime>[totalnode, totalnode];
            FTime = new List<DateTime>[totalnode, totalnode];
            name = new int[totalnode];
            

            foreach (Airport a in session3.Airports)    //KHOI TAO MANG NAME
            {
                name[counter] = a.ID;
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
                        trace_sdate[i, j] = date;
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
                        trace_sdate[i, j] = date;
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
                    sr.Add(checking);
                    for (int i = 0; i < sr.Count-1; i++)
                    {
                        result_temp += $"[" +
                            $"{GetFlightNumber(name[sr[i]], name[sr[i+1]], trace_sdate[sr[i], sr[i+1]])}" +
                            $"] - ";
                    }
                    Result.Add(result_temp.Remove(result_temp.Length - 3));
                    result_temp = "";
                    path[checking] = false;
                    sr.RemoveAt(sr.Count()-1);
                    return;
                }
                path[checking] = true;
                sr.Add(checking);
                for (int i = 0; i < totalnode; i++)
                {
                    if (CheckPath(checking,i))
                    {
                        FindFlightRoute(i, finish_node);
                    }
                }
                path[checking] = false;
                sr.RemoveAt(sr.Count()-1);
            }
        }
    }
}
