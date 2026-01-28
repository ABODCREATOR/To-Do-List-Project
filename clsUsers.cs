using System;
using System.Data;
using System.Data.SqlClient;

namespace To_Do_List_Project
{
    public class clsUsers : clsPerson
    {

        public bool LoginUser(string username, string password)
        {
            // That Query Finds User By Both Fields Username and Password
            string query = "SELECT UserID FROM TblUsers WHERE UserName = @u AND Password = @p";
            
            // That Inherited Fuunction Performs Login Check It.
            base.PerformLogin(query, username, password);

            return base.IsLogin;
        }

      
    }
}