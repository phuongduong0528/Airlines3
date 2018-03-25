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
        private Session3Entities _sessionDbContext = new Session3Entities();
        private int _totalNodes;                  //TOTAL NUMBER OF NODE
        private DateTime _searchStartTime;            // SEARCH START DATE
        private DateTime _searchEndTime;        // SEARCH END DATE
        private List<int> _currentPath;         //LIST OF CHECKED PATH
        private List<int> _tempResultPath;        //SAVE CORRECT PATH. Temporary path. A path is a list of airport ids.
        private List<List<int>> _resultPaths;       //A list of result paths. Each path is a list of airport ids.

        //MAIN
        private List<DateTime>[,] _startTimes;        //STime[i,j]                ->    LIST OF START TIME BETWEEN i, j (USE TO GET SCHEDULE ID)
        private List<DateTime>[,] _finishTimes;        //FTime[i,j]                ->    LIST OF FINISH TIME BETWEEN i, j
        private int[] _airportIds;                     //name[i] = j               ->    j IS THE AIRPORT ID
        private int[] trace;                    //trace[i] = j              ->    THE NODE BEFORE i IS j
        private List<DateTime>[,] traceFinishTimes;        //trace_fdate[i,j]          ->    THE FINISH TIME OF THE ROUTE BEFORE ROUTE i,j 
        private List<DateTime>[,] traceStartTimes;        //trace_sdate[i,j]          ->    THE START TIME OF THE ROUTE BEFORE ROUTE i,j 
        private bool[] path;                    //path[i] = (true or false) ->    i IS VISITED OR NOT


        public FindRoute()
        {
            _sessionDbContext = new Session3Entities();
            _totalNodes = _sessionDbContext.Airports.Count();
            _currentPath = new List<int>();
            _tempResultPath = new List<int>();
            _resultPaths = new List<List<int>>();
            trace = new int[_totalNodes];
            traceFinishTimes = new List<DateTime>[_totalNodes, _totalNodes];
            traceStartTimes = new List<DateTime>[_totalNodes,_totalNodes];

            for (int i = 0; i < _totalNodes; i++)
            {
                for (int j = 0; j < _totalNodes; j++)
                {
                    traceFinishTimes[i, j] = new List<DateTime>();
                    traceStartTimes[i, j] = new List<DateTime>();
                }
            }
            path = new bool[_totalNodes];
        }

        #region Helper
        bool IsConnected(int airportIdDept, int airportIdArr)
        {
            int routeCount = _sessionDbContext.Routes.Where(
                r => r.Airport.ID == airportIdDept
                && r.Airport1.ID == airportIdArr
            ).Count();

            return routeCount > 0;
        }

        List<DateTime> GetListStartTimeBetweenTwoAirports(int airportIdDept, int airportIdArr)
        {
            List<DateTime> startTimes = new List<DateTime>();
            foreach (Schedule schedule in
                _sessionDbContext.Schedules.Where(
                    s => s.Route.Airport.ID == airportIdDept
                    && s.Route.Airport1.ID == airportIdArr))
            {
                DateTime startTime = new DateTime(
                    schedule.Date.Year,
                    schedule.Date.Month,
                    schedule.Date.Day,
                    schedule.Time.Hours,
                    schedule.Time.Minutes,
                    schedule.Time.Seconds);
                startTimes.Add(startTime);
            }
            return startTimes;
        }

        List<DateTime> GetListFinishTimeBetweenTwoAirports(int airportIdDept, int airportIdArr)
        {
            List<DateTime> finishTimes = new List<DateTime>();
            foreach (Schedule schedule in
                _sessionDbContext.Schedules.Where(
                    s => s.Route.Airport.ID == airportIdDept
                    && s.Route.Airport1.ID == airportIdArr))
            {
                DateTime finishTime = new DateTime(
                    schedule.Date.Year,
                    schedule.Date.Month,
                    schedule.Date.Day,
                    schedule.Time.Hours,
                    schedule.Time.Minutes,
                    schedule.Time.Seconds).Add(new TimeSpan(0, schedule.Route.FlightTime, 0));
                finishTimes.Add(finishTime);
            }
            return finishTimes;
        }

        List<int> GetScheduleIds(int airportIdDept, int airportIdArr, DateTime startTime)
        {
            return _sessionDbContext.Schedules.Where(
                s => s.Route.Airport.ID == airportIdDept &&
                s.Route.Airport1.ID == airportIdArr &&
                s.Date.Equals(startTime.Date) &&
                s.Time.Equals(startTime.TimeOfDay)
            ).Select(s => s.ID).ToList();
        }
        #endregion

        /// <summary>
        /// Initial start times, finish times & airport Ids list.
        /// </summary>
        public void InitialData()
        {
            _startTimes = new List<DateTime>[_totalNodes, _totalNodes];
            _finishTimes = new List<DateTime>[_totalNodes, _totalNodes];
            _airportIds = 
                 _sessionDbContext.Airports.Select(a => a.ID).ToArray();

            for (int i = 0; i < _totalNodes; i++)
            {
                for (int j = 0; j < _totalNodes; j++)
                {
                    if (IsConnected(_airportIds[i], _airportIds[j]))
                    {
                        _startTimes[i, j] = GetListStartTimeBetweenTwoAirports(_airportIds[i], _airportIds[j]);
                        _finishTimes[i, j] = GetListFinishTimeBetweenTwoAirports(_airportIds[i], _airportIds[j]);
                    }
                }
            }
        }

        bool CheckPath(int i, int j)
        {
            int index;
            if (trace[i] == -1 && _startTimes[i, j] != null && !path[j])
            {
                trace[j] = i;
                index = 0;
                foreach (DateTime startTime in _startTimes[i, j])
                {
                    if (_searchStartTime <= startTime && startTime <= _searchEndTime)
                    {
                        traceStartTimes[i, j].Add(startTime);
                        traceFinishTimes[i, j].Add(_finishTimes[i, j][index]);
                        return true;
                    }
                    index++;
                }

                return false;
                //if (traceStartTimes[i, j].Count > 0)
                //{
                //    return true;
                //}

                //return false;
            }

            if (_startTimes[i, j] != null && !path[j])
            {
                index = 0;
                trace[j] = i;
                foreach (DateTime startTime in _startTimes[i, j])
                {
                    for (int traceIndex = 0; traceIndex < traceStartTimes[trace[i], i].Count; traceIndex++)
                    {
                        if (traceFinishTimes[trace[i], i][traceIndex] < startTime.AddHours(23).AddMinutes(59).AddSeconds(59) &&
                            traceFinishTimes[trace[i], i][traceIndex] != DateTime.MinValue)
                        {
                            traceStartTimes[i, j].Add(startTime);
                            traceFinishTimes[i, j].Add(_finishTimes[i, j][index]);
                            return true;
                        }
                    }
                    index++;
                }

                //if (traceStartTimes[i, j].Count > 0)
                //{
                //    return true;
                //}
            }

            return false;
        }

        public void FindFlightRoute(int checkingNode, int finishNode)
        {
            if (!path[checkingNode])
            {
                if (checkingNode == finishNode)
                {
                    _currentPath.Add(checkingNode);
                    SaveResult();
                    path[checkingNode] = false;
                    _currentPath.RemoveAt(_currentPath.Count() - 1);
                    return;
                }
                path[checkingNode] = true;
                _currentPath.Add(checkingNode);
                for (int i = 0; i < _totalNodes; i++)
                {
                    if (CheckPath(checkingNode,i))
                    {
                        FindFlightRoute(i, finishNode);
                    }
                }
                path[checkingNode] = false;
                _currentPath.RemoveAt(_currentPath.Count()-1);
            }
        }

        private void SaveResult()
        {
            for (int i = 0; i < _currentPath.Count - 1; i++)
            {
                foreach (DateTime traceStartTime in traceStartTimes[_currentPath[i], _currentPath[i + 1]])
                {
                    _tempResultPath.AddRange(
                        GetScheduleIds(
                            _airportIds[_currentPath[i]], 
                            _airportIds[_currentPath[i + 1]],
                            traceStartTime
                        )
                    );
                }

            }
            _resultPaths.Add(new List<int>(_tempResultPath));
            _tempResultPath.Clear();
        }

        // ===================== GET RESULT ============================
        public void CalculatePath(int airportFromId, int airportToId, DateTime searchStartDate, DateTime searchEndDate)
        {
            int _aiportFromIndex = 0;
            int _airportToIndex = 0;
            _searchStartTime = searchStartDate;
            _searchEndTime = searchEndDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            InitialData();

            for (int i = 0; i < _airportIds.Length; i++)
            {
                if (_airportIds[i] == airportFromId)
                    _aiportFromIndex = i;
                if (_airportIds[i] == airportToId)
                    _airportToIndex = i;
            }

            trace[_aiportFromIndex] = -1;
            FindFlightRoute(_aiportFromIndex, _airportToIndex);
        }

        public List<List<int>> GetResultPaths(int airportFromId, int airportToId, DateTime searchStartDate, DateTime searchEndDate)
        {
            CalculatePath(airportFromId, airportToId, searchStartDate, searchEndDate);
            return _resultPaths;
        }
    }
}
