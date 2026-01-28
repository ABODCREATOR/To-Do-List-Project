using System.Drawing;
using System.Windows.Forms; 
namespace To_Do_List_Project
{
    public static class clsUiFormat
    {
        public static void FormatGrid(this DataGridView grid)
        {
            if (grid.Columns.Count == 0) return;

            grid.BackgroundColor = Color.White;
            grid.RowTemplate.Height = 80;
            grid.DefaultCellStyle.Font = new Font("Cascadia Code", 14, FontStyle.Bold);
            grid.DefaultCellStyle.ForeColor = Color.Navy;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            grid.EnableHeadersVisualStyles = false; 

            if (grid.Columns.Contains("TaskID")) grid.Columns["TaskID"].Visible = false;
            if (grid.Columns.Contains("UserID")) grid.Columns["UserID"].Visible = false;
            if (grid.Columns.Contains("ID")) grid.Columns["ID"].Visible = false; 
        }
    }
}