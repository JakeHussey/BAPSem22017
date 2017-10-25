using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlQueryLibrary;
using System.Diagnostics;

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
            //TAB PAGE CONTROL
            tabPage1.Text = "Manage Supplier";
            tabPage2.Text = "Manage Reports";
            tabPage3.Text = "Manage Report Filters";
            tabPage4.Text = "Activity Log";


            //Manage Suppliers Tab
            //-------------------------------------
            manageSuppliersTitle.Text = "Manage Suppliers";

            supplierCodeLabel.Text = "Supplier Code:";
            findSupplierEntry.Text = "";
            findSupplierButton.Text = "Find";


            supplierIDLabel.Text = "Supplier ID:";
            supplierIDNumber.Text = "--";

            supplierTypeLabel.Text = "Supplier Type:";
            supplierTypeLabelA.Text = "--";

            supplierStatusLabel.Text = "Supplier Status:";
            supplierStatusLabelA.Text = "--";

            recievesReportsLabel.Text = "Recieves Report:";
            recievesReportsLabelA.Text = "--";

            reportFrequencyLabel.Text = "Report Frequency:";
            label1.Text = "--";

            reportDayLabel.Text = "Report Day:";

            emailAddressLabel.Text = "Email Address:";

            viewReportHistoryButton.Text = "View Report History";

            updateButton.Text = "Update";

            emailAddressEntry.Text = "";
            //--------------------------------------------



            
            //MANAGE REPORTS TAB
            //---------------------------------------------

            manageReportsTitle.Text = "Manage Reports:";
            reportingStatusLabel.Text = "Reporting Status:";
            reportFrequencyLabelP2.Text = "Default Report Frequency";
            defaultReportDay.Text = "Default Report Day:";
            supplierCodesLabel.Text = "Supplier Code:";
            dateFromLabel.Text = "Date From:";
            dateToLabel.Text = "Date To:";
            listReportsLabel.Text = "List Reports:";
            activeCheckBox.Text = "Active";


            //---------------------------------------------
            //Server=tcp:lowe.database.windows.net,1433;Initial Catalog=GMaster;Persist Security Info=False;User ID=eitadmin;Password=DaSci2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
            var supplierQuery = new SuppliersQuery("Server=tcp:lowe.database.windows.net,1433;Initial Catalog=EIT;Persist Security Info=False;User ID=eitadmin;Password=DaSci2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var suppliers = supplierQuery.GetSuppliers(new List<string>(){"TAYLPR"}); //, "DOMISA", "WEBSHY"   fails with extra supplier codes for the where condition
            Debug.WriteLine("Suppliers Returned: " + suppliers.Count);

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

        private void activeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if (activeCheckBox.CheckedChanged = true)
            //{
            //    activeCheckBox.CheckState = 
            //}
        }
    }
        
}



