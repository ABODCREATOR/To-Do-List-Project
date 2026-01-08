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
using System.Data.Sql;
namespace To_Do_List_Project
{
    public partial class ToDoList : Form
    {
        BindingList <DataGrid> dataGrids = new BindingList <DataGrid> ();
        public ToDoList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGrids.AddNew();
        }
    }
}
