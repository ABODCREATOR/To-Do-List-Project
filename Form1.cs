using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace To_Do_List_Project
{
    public partial class Form1 : Form
    {
        int counter = 0, cnt = 0, len = 0; string txt;
        string connectionString = @"Data Source=DESKTOP-L0P3865;
        Initial Catalog=ToDoListDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            if (cnt > len)
            {
                cnt = 0; lblwelcome.Text = "";
            }
            else
                lblwelcome.Text = txt.Substring(0, cnt);
        }

        private void btnadminlogin_Click(object sender, EventArgs e)
        {
            FrmAdmin fm = new FrmAdmin();
            fm.Show();
            this.Hide();
        }

        private void btnuserlogin_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // That Query Selects Table With it's UserName and Password
                    string query = "SELECT UserID FROM TblUsers WHERE UserName = @u AND Password = @p";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", usertxt.Text.Trim()); 
                        cmd.Parameters.AddWithValue("@p", passtxt.Text.Trim());

                        // That Object Variable Store The Query Information As Many DataTypes That Points To Username and Password
                        object result = cmd.ExecuteScalar();

   
                        if (result != null)
                        {
                            // Taking Values From DataBase and Put it In The Session Class
                            UserSession.CurrentUserID = Convert.ToInt32(result);

                            ToDoList frm = new ToDoList();
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username Or Password ❌", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection runtime error: {ex.Message}"
                        ,"Connection Error !", MessageBoxButtons.OK , MessageBoxIcon.Error);
                }

            }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblwelcome.BackColor = Color.Transparent; lbluser.BackColor = Color.Transparent;
            lblpass.BackColor = Color.Transparent; chkpass.BackColor = Color.Transparent;
            txt = lblwelcome.Text;
            len = txt.Length;
            lblwelcome.Text = "";
            timer1.Start();
        }
        private void chkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpass.Checked)passtxt.UseSystemPasswordChar = true;
            else passtxt.UseSystemPasswordChar = false;
        }
    }
}
