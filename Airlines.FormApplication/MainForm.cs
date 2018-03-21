using Airlines.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines.FormApplication
{
    public partial class MainForm : Form
    {
        List<BookFlightDto> bookFlightDtos_outbound;
        List<BookFlightDto> bookFlightDtos_return;
        public MainForm()
        {
            InitializeComponent();
        }

        async Task LoadCombobox()
        {
            List<string> result = await Program.Instance.Controller.AirportList();
            foreach(string s in result)
            {
                fromCbx.Items.Add(s);
                toCbx.Items.Add(s);
            }
            fromCbx.SelectedIndex = 0;
            toCbx.SelectedIndex = 1;
        }

        async Task RefreshGridView()
        {
            bookFlightDtos_outbound = await
                Program.Instance.Controller.FindFlight(
                    fromCbx.SelectedItem.ToString(),
                    toCbx.SelectedItem.ToString(),
                    outboundDtp.Value.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    cabintypeCbx.SelectedItem.ToString());
            if (returnRbt.Checked)
            {
                bookFlightDtos_return = await
                Program.Instance.Controller.FindFlight(
                    toCbx.SelectedItem.ToString(),
                    fromCbx.SelectedItem.ToString(),
                    returnDtp.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    cabintypeCbx.SelectedItem.ToString());
            }
        }

        void LoadGridView()
        {
            outboundflightDgv.DataSource = bookFlightDtos_outbound;
            returnflightDgv.DataSource = bookFlightDtos_return;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            bookFlightDtos_outbound = new List<BookFlightDto>();
            bookFlightDtos_return = new List<BookFlightDto>();
            cabintypeCbx.SelectedIndex = 0;
            await LoadCombobox();
            applyBtn.Enabled = true;
            onewayRbt.Checked = true;
        }

        private async void applyBtn_Click(object sender, EventArgs e)
        {
            await RefreshGridView();
            LoadGridView();
        }
    }
}
