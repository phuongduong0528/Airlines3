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
        private Session3Entities session3 = new Session3Entities();
        private int totalnode;           //TOTAL NUMBER OF NODE
        private DateTime Start_Date { get; set; }
        private List<int> current_path;
        private string one_result_string;
        private List<int> one_result_id;
        private List<string> ResultString { get; }
        private List<int[]> ResultID { get; }

        //MAIN
        private List<DateTime>[,] STime;
        private List<DateTime>[,] FTime;
        private int[] name;
        private int[] trace;
        private DateTime[,] trace_date;
        private DateTime[,] trace_sdate;
        private bool[] path;


        public FindRoute()
        {
            session3 = new Session3Entities();
            totalnode = session3.Airports.Count();
            current_path = new List<int>();
            one_result_string = "";
            one_result_id = new List<int>();
            ResultString = new List<string>();
            ResultID = new List<int[]>();
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

        int GetScheduleId(int from, int to, DateTime time)
        {
            return session3.Schedules.FirstOrDefault(s => s.Route.Airport.ID == from &&
                                                          s.Route.Airport1.ID == to &&
                                                          s.Date.Equals(time.Date) &&
                                                          s.Time.Equals(time.TimeOfDay)).ID;
        }
        #endregion

        public void Inputdata()
        {
            STime = new List<DateTime>[totalnode, totalnode];
            FTime = new List<DateTime>[totalnode, totalnode];
            name = new int[totalnode];

            int counter = 0;
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
            if (trace[i] == -1 && STime[i, j] != null && !path[j])
            {
                trace[j] = i;
                index = 0;
                foreach (DateTime date in STime[i, j])
                {
                    if (date >= Start_Date)
                    {
                        trace_sdate[i, j] = date;
                        trace_date[i, j] = FTime[i, j][index];
                        return true;
                    }
                    index++;
                }
                return false;
            }
            if (STime[i, j] != null && !path[j])
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
                    current_path.Add(checking);
                    for (int i = 0; i < current_path.Count-1; i++)
                    {
                        one_result_string += $"[" +
                            $"{GetFlightNumber(name[current_path[i]], name[current_path[i+1]], trace_sdate[current_path[i], current_path[i+1]])}" +
                            $"] - ";
                        one_result_id.Add(GetScheduleId(name[current_path[i]], name[current_path[i + 1]], trace_sdate[current_path[i], current_path[i + 1]]));
                    }
                    ResultString.Add(one_result_string.Remove(one_result_string.Length - 3));
                    ResultID.Add(one_result_id.ToArray());
                    one_result_string = "";
                    one_result_id.Clear();
                    path[checking] = false;
                    current_path.RemoveAt(current_path.Count()-1);
                    return;
                }
                path[checking] = true;
                current_path.Add(checking);
                for (int i = 0; i < totalnode; i++)
                {
                    if (CheckPath(checking,i))
                    {
                        FindFlightRoute(i, finish_node);
                    }
                }
                path[checking] = false;
                current_path.RemoveAt(current_path.Count()-1);
            }
        }

        // ===================== GET RESULT ============================
        public void CalculatePath(int from, int to, DateTime date)
        {
            int _from = 0;
            int _to = 0;
            Start_Date = date;
            Inputdata();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == from)
                    _from = i;
                if (name[i] == to)
                    _to = i;
            }
            trace[_from] = -1;
            FindFlightRoute(_from, _to);
        }

        public List<string> GetResult_FN()
        {
            return ResultString;
        }

        public List<int[]> GetResult_SID()
        {
            return ResultID;
        }
    }
}
