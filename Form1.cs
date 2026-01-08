using System;
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
            ToDoList td = new ToDoList();
            td.Show();
            this.Hide();
        }

        private void btnuserlogin_Click(object sender, EventArgs e)
        {
            ToDoList td = new ToDoList();
            td.Show();
            this.Hide();
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
