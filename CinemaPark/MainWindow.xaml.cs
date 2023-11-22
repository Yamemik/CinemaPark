using System;
using System.Windows;
using System.Data;
using System.Data.OleDb;

namespace CinemaPark
{
    public partial class MainWindow : Window
    {
        OleDbConnection con;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();

            //Connect your access database
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + 
                AppDomain.CurrentDomain.BaseDirectory + "\\cinemaDB.mdb";
            BindGrid();

            OleDbCommand cmd = new OleDbCommand("select * from Должности",con);
            cbSpecial.ItemsSource = cmd.ExecuteReader();
        }

        //Display records in grid
        private void BindGrid()
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Сотрудники";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gvData.ItemsSource = dt.AsDataView();

            if (dt.Rows.Count > 0)
            {
                lblCount.Visibility = Visibility.Hidden;
                gvData.Visibility = Visibility.Visible;
            }
            else
            {
                lblCount.Visibility = Visibility.Visible;
                gvData.Visibility = Visibility.Hidden;
            }

        }

        //Add records in grid
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;

            if (txtId.Text != "")
            {
                if (txtId.IsEnabled == true)
                {
                    if (cbSpecial.Text != "cbSpecial")
                    {
                        cmd.CommandText = "insert into Сотрудники(Код,Фамилия,Имя,Отчество,Телефон,Должность)" +
                            "Values(" + txtId.Text + ",'"+ txtFamily.Text +"','" + txtName.Text + "','" + txtPutr.Text + "'," +
                            "" + txtContact.Text + "," + cbSpecial.Text + ")";
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        MessageBox.Show("Employee Added Successfully...");
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Special Option....");
                    }
                }
                else
                {
                    cmd.CommandText = "update Сотрудники set Фамилия='" + txtFamily.Text + "',Имя='" + txtName.Text + "'," +
                        "Отчество='" + txtPutr.Text + "',Телефон='" + txtContact.Text + "',Должность="+ cbSpecial.Text +" " +
                        "where Код=" + txtId.Text;
                    cmd.ExecuteNonQuery();
                    BindGrid();
                    MessageBox.Show("Employee Details Updated Succesffully...");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please Add Employee Id.......");
            }
        }

        //Clear all records from controls
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtId.Text = "";
            txtFamily.Text = "";
            txtName.Text = "";
            txtPutr.Text = "";
            txtContact.Text = "";
            btnAdd.Content = "Добавить";
            cbSpecial.SelectedIndex = 0;
            txtId.IsEnabled = true;
        }

        //Edit records
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (gvData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvData.SelectedItems[0];
                txtId.Text = row["Код"].ToString();
                txtFamily.Text = row["Фамилия"].ToString();
                txtName.Text = row["Имя"].ToString();
                txtPutr.Text = row["Отчество"].ToString();
                txtContact.Text = row["Телефон"].ToString();
                cbSpecial.Text = row["Должность"].ToString();
                txtId.IsEnabled = false;
                btnAdd.Content = "Сохранить";
            }
            else
            {
                MessageBox.Show("Please Select Any Employee From List...");
            }
        }

        //Delete records from grid
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gvData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvData.SelectedItems[0];

                OleDbCommand cmd = new OleDbCommand();
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Сотрудники where Код=" + row["Код"].ToString();
                cmd.ExecuteNonQuery();
                BindGrid();
                MessageBox.Show("Employee Deleted Successfully...");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Please Select Any Employee From List...");
            }
        }

        //Exit
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
