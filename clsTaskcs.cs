using System;
using System.Data;
using System.Data.SqlClient;

namespace To_Do_List_Project
{
    public class clsTask : clsDataAccess 
    {
        public DataTable GetAllTasks(int userId)
        {
            // That Query Returns All Tasks Of Certain User By It's ID
            string query = "SELECT * FROM TblTasks WHERE UserID = @uid";

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@uid", userId);

            // That Function Will returns a DataTable That I Can Use It in The DataGridView To Show All My Tasks In UI
            return base.GetDataTable(query, p);
        }
        public bool AddNewTask(string title, DateTime date, int userId)
        {
            string query = @"INSERT INTO TblTasks (TaskName, UserID, TaskDate, IsDone) 
                 VALUES (@tn, @uid, @td, 0)";
            // Initializaing Parameters That Storaged Affected Rows
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@tn", title);
            p[1] = new SqlParameter("@uid", userId);
            p[2] = new SqlParameter("@td", date);

            // That Function Returns The Number Of Rows Affected After Adding New Task
            int rowsAffected = base.ExecuteNonQuery(query, p);

            // If Number Is More Than Zero The Function Returns True Because Any Integer Value Not Equal To Zero is True
            return (rowsAffected > 0);
        }

        // ===========================================
        // That Function Delete Certain Task Selected
        // ===========================================
        public bool DeleteTask(int taskId)
        {
            string query = "DELETE FROM TblTasks WHERE TaskID = @tid";

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@tid", taskId);

            return base.ExecuteNonQuery(query, p) > 0;
        }

        // ============================
        // (Edit / Mark as Done)
        // ============================
        public bool UpdateTaskStatus(int taskId, bool isDone)
        {
            string query = "UPDATE TblTasks SET IsDone = @done WHERE TaskID = @tid";

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@tid", taskId);
            p[1] = new SqlParameter("@done", isDone);

            return base.ExecuteNonQuery(query, p) > 0;
        }
        public bool ClearAllTasks(int userId)
        {
            // That Query Deletes All The Tasks Of Certain User By It's User ID
            string query = "DELETE FROM TblTasks WHERE UserID = @uid";

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@uid", userId);

            return base.ExecuteNonQuery(query, p) > 0;
        }
    }
}