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
            TaskRunning();
            List<string> result = await Program.Instance.Controller.AirportList();
            foreach(string s in result)
            {
                fromCbx.Items.Add(s);
                toCbx.Items.Add(s);
            }
            fromCbx.SelectedIndex = 0;
            toCbx.SelectedIndex = 1;
            TaskEnd();
        }

        async Task RefreshGridView()
        {
            bookFlightDtos_outbound = new List<BookFlightDto>();
            bookFlightDtos_return = new List<BookFlightDto>();
            bookFlightDtos_outbound = await
                Program.Instance.Controller.FindFlight(
                    fromCbx.SelectedItem.ToString(),
                    toCbx.SelectedItem.ToString(),
                    outboundDtp.Value.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    cabintypeCbx.SelectedItem.ToString()
                    );
            if (returnRbt.Checked)
            {
                bookFlightDtos_return = await
                Program.Instance.Controller.FindFlight(
                    toCbx.SelectedItem.ToString(),
                    fromCbx.SelectedItem.ToString(),
                    returnDtp.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    cabintypeCbx.SelectedItem.ToString()
                    );
            }
            //outboundflightDgv.Columns[7].Visible = false;
            //returnflightDgv.Columns[7].Visible = false;
        }

        void LoadGridView()
        {
            if(outboundChk.Checked)
                outboundflightDgv.DataSource = bookFlightDtos_outbound;
            else
                outboundflightDgv.DataSource = bookFlightDtos_outbound
                    .Where(bo=>bo.Date.Equals(outboundDtp.Value.Date.ToString("dd/MM/yyyy"))).ToList();
            if (returnChk.Checked)
                returnflightDgv.DataSource = bookFlightDtos_return;
            else
                returnflightDgv.DataSource = bookFlightDtos_return
                    .Where(bo => bo.Date.Equals(returnDtp.Value.Date.ToString("dd/MM/yyyy"))).ToList();

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
            TaskRunning();
            await RefreshGridView();
            LoadGridView();
            TaskEnd();
        }

        void TaskRunning()
        {
            statusLbl.Visible = true;
            applyBtn.Enabled = false;
            fromCbx.Enabled = false;
            toCbx.Enabled = false;
            cabintypeCbx.Enabled = false;
            onewayRbt.Enabled = false;
            returnRbt.Enabled = false;
            outboundDtp.Enabled = false;
            returnDtp.Enabled = false;
            outboundChk.Enabled = false;
            returnChk.Enabled = false;
        }

        void TaskEnd()
        {
            statusLbl.Visible = false;
            applyBtn.Enabled = true;
            fromCbx.Enabled = true;
            toCbx.Enabled = true;
            cabintypeCbx.Enabled = true;
            onewayRbt.Enabled = true;
            returnRbt.Enabled = true;
            outboundDtp.Enabled = true;
            returnDtp.Enabled = true;
            outboundChk.Enabled = true;
            returnChk.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void returnChk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void outboundChk_CheckedChanged(object sender, EventArgs e)
        {
            TaskRunning();
            LoadGridView();
            TaskEnd();
        }
    }
}
