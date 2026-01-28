using System;
using System.Data;
using System.Data.SqlClient;

public class clsDataAccess
{
    // Definition The Connection String One Use Time
    private readonly string _connectionString = @"Data Source=DESKTOP-L0P3865;Initial Catalog=ToDoListDB;Integrated Security=True";

    // ---------------------------------------------------------
    // 1. That Function Returns Data Table
    // ---------------------------------------------------------
    public DataTable GetDataTable(string query, SqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Adding Parameters If Existed
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    // That Line Open The Connection String Fills The Table With Data 
                    adapter.Fill(dt);
                }
            }
        }
        return dt;
    }

    // --------------------------------------------------------------------------------
    // 2. That Function Returns Any Results Of Common CRUD Operations and Affected Rows
    // --------------------------------------------------------------------------------
    public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                // Return The Affected Rows
                return cmd.ExecuteNonQuery();
            }
        }
    }

    // ---------------------------------------------------------
    // (Login, Count) Execute Single Values
    // ---------------------------------------------------------
    public object ExecuteScalar(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}