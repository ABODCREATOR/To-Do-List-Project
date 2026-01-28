using System;
using System.Data.SqlClient;
namespace To_Do_List_Project
{
    public class clsPerson : clsDataAccess
    {
        public int Id { get; set; }
        public bool IsLogin { get; set; }


        protected void PerformLogin(string query, string user, string pass)
        {
            this.IsLogin = false;
            this.Id = 0;

            try
            {
                // Initialting Parameters To Send It To The Base Class DAL To Store Fields Values
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@u", user);
                p[1] = new SqlParameter("@p", pass);

                // The Index 0 Is Represented By Certain Field also Index 1 Represented By Certain Field
                // The Object Inherit The Result From DAL Class
                object result = ExecuteScalar(query, p);

                if (result != null)
                {
                    this.Id = Convert.ToInt32(result);
                    this.IsLogin = true;
                }
            }
            catch (Exception ex)
            {
                // Handling RunTime Errors
                //MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}