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
        

        public ToDoList()
        {
            InitializeComponent();
        }
        private void LoadAllTasks()
        {
            clsTask task = new clsTask();          
            dataGridView1.DataSource = task.GetAllTasks(UserSession.CurrentUserID);
            dataGridView1.Columns["TaskID"].Visible = false;
            dataGridView1.Columns["UserID"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtadd.Text))
            {
                MessageBox.Show("Please Write Any Task :-(", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsTask task = new clsTask();

        
            //DateTime taskDate = DateTime.Now;
            DateTime taskDate = dateTimePicker1.Value; 

            if (task.AddNewTask(txtadd.Text, taskDate, UserSession.CurrentUserID))
            {
                LoadAllTasks();
                txtadd.Clear();
                txtadd.Focus();
                System.Media.SystemSounds.Beep.Play(); 
            }
            else
            {
                // Error Connection In DataBase :-(
                MessageBox.Show("Error Adding Task ❌", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            LoadAllTasks();
            clsUiFormat.FormatGrid(dataGridView1);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (MessageBox.Show("Warning! ⚠️ are you sure that you want to delete all your tasks!", "Clear all",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clsTask task = new clsTask();

                   
                    if (task.ClearAllTasks(UserSession.CurrentUserID))
                    {
                        LoadAllTasks();

                        MessageBox.Show("Cleared all successfully🧹");
                    }
                    else
                    {
                        MessageBox.Show("Problem In Delete ❌");
                    }
                }
            }
            else
            {
                MessageBox.Show("The Task List is default empty 😂");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are You Sure That You Want to Delete That Task ? ", "Confirm Delete !", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        int taskId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            
                        clsTask task = new clsTask();
                        
                        if (task.DeleteTask(taskId))
                        {
                            LoadAllTasks();
                        }
                        else
                            MessageBox.Show("Error Through Deletion :-(" , "Error" , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
                    }

            }
            else
                MessageBox.Show("Please Choos a Task To Delete First !" , "Notice"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
