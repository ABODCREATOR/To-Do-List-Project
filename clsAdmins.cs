using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List_Project.Properties
{
    public class clsAdmins : clsPerson
    {

        public bool LoginAdmin(string username, string password)
        {
            // That Query Finds User By Both Fields Username and Password
            string query = "SELECT AdminID FROM TblAdmins WHERE UserName = @u AND Password = @p";

            // That Inherited Fuunction Performs Login Check It.
            base.PerformLogin(query, username, password);

            return base.IsLogin;
        }

    }
}
