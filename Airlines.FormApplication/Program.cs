using Airlines.FormApplication.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines.FormApplication
{
    public class Program
    {
        private BookFlightController _controller;
        public BookFlightController Controller => _controller ??
            (_controller = new BookFlightController());

        public static Program Instance { get; set; }

        public Program()
        {
            _controller = new BookFlightController();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Instance = new Program();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
