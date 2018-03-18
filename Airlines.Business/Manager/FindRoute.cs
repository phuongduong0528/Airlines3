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
        int counter;

        List<DateTime>[,] STime;
        List<DateTime>[,] FTime;
        string[] name;
        int[] trace;
        List<DateTime>[] trace_d;
        string[] path;

        public FindRoute()
        {
            session3 = new Session3Entities();
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

        List<DateTime> getListStart(string name1,string name2)
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

        List<DateTime> getListFinish(string name1, string name2)
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
        #endregion

        public void Inputdata()
        {
            int countnode = session3.Airports.Count();
            STime = new List<DateTime>[countnode, countnode];
            FTime = new List<DateTime>[countnode, countnode];
            name = new string[countnode];
            
            counter = 0;
            foreach (Airport a in session3.Airports)
            {
                name[counter] = a.IATACode;
                counter++;
            }
            
            for (int i = 0; i < countnode; i++)
            {
                for(int j = 0; j < countnode; j++)
                {
                    if (Is_Connected(name[i], name[j]))
                    {
                        STime[i, j] = getListStart(name[i], name[j]);
                        FTime[i, j] = getListFinish(name[i], name[j]);
                    }
                }
            }
            

        }

        //bool tryRoute(int i)
        //{

        //}


    }
}
