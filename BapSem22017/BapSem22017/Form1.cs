using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BapSem22017
{
    public partial class windowText : Form
    {


        public windowText()
        {

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //Initializes and sets all components of the interface
            title.Text = "Manage Suppliers";
            supplierCodeLabel.Text = "Supplier Code:";
            findSupplierEntry.Text = "";
            findSupplierButton.Text = "Find";
            supplierIDLabel.Text = "Supplier ID:";
            supplierTypeLabel.Text = "Supplier Type:";
            supplierStatusLabel.Text = "Supplier Status:";
            recievesReportsLabel.Text = "Recieves Report:";
            reportFrequencyLabel.Text = "Report Frequency:";
            reportDayLabel.Text = "Report Day:";
            emailAddressLabel.Text = "Email Address:";
            viewReportHistoryButton.Text = "View Report History";
            updateButton.Text = "Update";
            emailAddressEntry.Text = "";


        }

        Decimal reportDay;

        private void findSupplierButton_Click(object sender, EventArgs e)
        {
            return;
        }



        private void viewReportHistoryButton_Click(object sender, EventArgs e)
        {
            return;
        }



        private void updateButton_Click(object sender, EventArgs e)
        {
            return;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            reportDay = numericUpDown1.Value;
        }
    }
        
}



