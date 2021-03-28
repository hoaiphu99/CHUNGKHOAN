using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace CHUNGKHOAN
{
    public partial class frmBGTT : DevExpress.XtraEditors.XtraForm
    {
        private int changeCount = 0;
        private const string tableName = "BANGGIATRUCTUYEN";
        private const string statusMessage = "Đã có {0} thay đổi.";

        private SqlConnection connection = null;
        private SqlCommand command = null/* TODO Change to default(_) if this is not a reference type */;
        private DataSet dataToWatch = null/* TODO Change to default(_) if this is not a reference type */;

        private bool CanRequestNotifications()
        {
            // In order to use the callback feature of the
            // SqlDependency, the application must have
            // the SqlClientPermission permission.
            try
            {
                SqlClientPermission perm = new SqlClientPermission(PermissionState.Unrestricted);

                perm.Demand();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public frmBGTT()
        {
            InitializeComponent();
            SqlDependency.Start(GetConnectionString());
        }

        private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrive it from a configuration file.
            // Return "Data Source=THU-PC\TINTIN;Initial Catalog=QLVT;Persist Security Info=True;User ID=sa;Password=kc;Pooling = false"
            return "Data Source=HOAIPHU-PC;Initial Catalog=CHUNGKHOAN;User ID=sa;Password=123";
        }

        private string GetSQL()
        {
            return "select MACP as [Mã CP],DM_GIA3 as [       Giá 3],DM_KL3 as [KL 3]," +
                "DM_GIA2 as [       Giá 2],DM_KL2 as [KL 2]," +
                "DM_GIA1 as [       Giá 1],DM_KL1 as [KL 1]," +
                "KL_GIA as [       Giá],KL_KL as [KL]," +
                "DB_GIA1 as [       Giá 1],DB_KL1 as [KL 1]," +
                "DB_GIA2 as [       Giá 2],DB_KL2 as [KL 2]," +
                "DB_GIA3 as [       Giá 3],DB_KL3 as [KL 3] from dbo.BANGGIATRUCTUYEN";
        }

        private void GetData()
        {
            // Empty the dataset so that there is only
            // one batch worth of data displayed.
            dataToWatch.Clear();

            // Make sure the command object does not already have
            // a notification object associated with it.

            command.Notification = null;

            // Create and bind the SqlDependency object
            // to the command object.

            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += dependency_OnChange;

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataToWatch, tableName);

                this.dataGridView1.DataSource = dataToWatch;
                this.dataGridView1.DataMember = tableName;
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {

            // This event will occur on a thread pool thread.
            // It is illegal to update the UI from a worker thread
            // The following code checks to see if it is safe update the UI.
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;

            // If InvokeRequired returns True, the code is executing on a worker thread.
            if (i.InvokeRequired)
            {
                // Create a delegate to perform the thread switch
                OnChangeEventHandler tempDelegate = new OnChangeEventHandler(dependency_OnChange);

                object[] args = new[] { sender, e };

                // Marshal the data from the worker thread
                // to the UI thread.
                i.BeginInvoke(tempDelegate, args);

                return;
            }

            // Remove the handler since it's only good
            // for a single notification
            SqlDependency dependency = (SqlDependency)sender;

            dependency.OnChange -= dependency_OnChange;

            changeCount += 1;
            this.lblKq1.Text = string.Format(statusMessage, changeCount);

            // At this point, the code is executing on the
            // UI thread, so it is safe to update the UI.


            // Reload the dataset that's bound to the grid.
            GetData();
        }

        private void BatDau()
        {
            changeCount = 0;
            // Remove any existing dependency connection, then create a new one.
            SqlDependency.Stop(GetConnectionString());
            try
            {
                SqlDependency.Start(GetConnectionString());
            }
            catch (Exception ex)
            {
                /*Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation);
                return;*/
            }
            if (connection == null)
            {
                connection = new SqlConnection(GetConnectionString());
                connection.Open();
            }
            if (command == null)
                // GetSQL is a local procedure that returns
                // a paramaterized SQL string. You might want
                // to use a stored procedure in your application.
                command = new SqlCommand(GetSQL(), connection);

            if (dataToWatch == null)
                dataToWatch = new DataSet();
            GetData();
        }

        private void bANGGIATRUCTUYENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBANGGIATRUCTUYEN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsCHUNGKHOAN);

        }

        private void frmBGTT_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dsCHUNGKHOAN.BANGGIATRUCTUYEN' table. You can move, or remove it, as needed.
            if (CanRequestNotifications() == true)
                BatDau();
            else
                MessageBox.Show("Bạn chưa kích hoạt dịch vụ Broker", "ngu", MessageBoxButtons.OK);

        }

        private void frmBGTT_FormClosed(System.Object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            SqlDependency.Stop(GetConnectionString());
            if (connection != null)
                connection.Close();
        }
    }
}
