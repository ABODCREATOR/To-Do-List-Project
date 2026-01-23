using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace To_Do_List_Project
{
    public partial class ToDoList : Form
    {
        string connectionString = @"Data Source=DESKTOP-L0P3865;
        Initial Catalog=ToDoListDB;Integrated Security=True";
        public class TaskItem { 
        public string TaskName { get; set; } 
        public DateTime Date { get; set; } 
        }
        BindingList<TaskItem> dataGrids = new BindingList <TaskItem>();

        public ToDoList()
        {
            InitializeComponent();
        }
        private void LoadAllTasks()
        {
            // That Query Find The Tasks Of The Current User After You've Logged In in The Data Base
            string query = "SELECT * FROM TblTasks WHERE UserID = @uid";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uid", UserSession.CurrentUserID); // The Number Of User In DataBase

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt); // That Table Would Fill The Records In The Table In Server

                    // Initalizing DataGrid View Control With Tasks In DataBase In Tasks Table
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtadd.Text))
            {
                MessageBox.Show("Please Write Any Task :-(", "Info"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGrids.Add(new TaskItem
            {
                TaskName = txtadd.Text,
                Date = dateTimePicker1.Value.Date
            });


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO TblTasks (TaskName, UserID, TaskDate) VALUES (@name, @uid, @date)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtadd.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);

                    // That Class Will Used To Add New User With That Current Value That Stored Auto Increment In DataBase
                    cmd.Parameters.AddWithValue("@uid", UserSession.CurrentUserID);

                    cmd.ExecuteNonQuery(); // That Command Executes Query in a DataBase
                }
            }

            txtadd.Clear();
            txtadd.Focus();

            LoadAllTasks();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGrids;
            LoadAllTasks();
            dataGridView1.Columns[0].Width = 600;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Cascadia Code", 16, FontStyle.Bold);
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Navy;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["UserID"].ReadOnly = true; dataGridView1.Columns["TaskID"].ReadOnly = true;


            dataGridView1.Columns[1].DefaultCellStyle.Font = new Font("Cascadia Code", 16, FontStyle.Bold);
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.Navy;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Cascadia Code", 16, FontStyle.Bold);
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.Navy;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Cascadia Code", 12, FontStyle.Bold);
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.Navy;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.RowTemplate.Height = 80;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure That you want to clear all tasks 😲", "Warning !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dataGrids.Clear();
                // That Query Deletes The Whole Tasks Of the Current User In a DataBase
                string query = "DELETE FROM TblTasks WHERE UserID = @uid"; 

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", UserSession.CurrentUserID); // The Number Of Current User
                        cmd.ExecuteNonQuery();
                    }
                }

                // You Should Load All Your Tasks to Update Changes In DataBase
                LoadAllTasks();
                MessageBox.Show("Cleared All Successfully 🗑️");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && !dataGridView1.CurrentRow.IsNewRow)
            {
                // Confirm Message Box
                DialogResult result = MessageBox.Show("Are You Sure That You Want To Delete That Task ?", "Confirm !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Initate Variable That Storage Index Of Task with it's TaskID
                    int rowIndex = dataGridView1.CurrentRow.Index;
                    dataGrids.RemoveAt(rowIndex);
                    int idTaskToDelete = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TaskID"].Value);
                    
                    string query = "DELETE FROM TblTasks WHERE TaskID = @tid";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@tid", idTaskToDelete);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // You Should Load Your Whole Tasks After Delete To Update Changes In a DataBase
                    LoadAllTasks();
                }
             
            }
            else
            {
                MessageBox.Show("Choose any Task to Delete First :-(", "Info"
                ,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
