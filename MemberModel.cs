using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GTech_MachineTest
{
    public class MemberModel
    {
        public DataSet GetMemberDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string cs = ConfigurationManager.AppSettings["connectionString"];
                SqlConnection connect = new SqlConnection(cs);
                connect.Open();
                SqlCommand cmd = new SqlCommand("GET_MEMBER_DETAIL", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter _da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                _da.Fill(ds);
                connect.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool AddMember(string name, string phnNumber, string gender, string address, string photo, string photo_path, int is_delete = 0, int p_id = 0)
        {
            try
            {
                string cs = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand command = new SqlCommand("PROC_ADD_MEMBER", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.AddWithValue("@phnNumber", SqlDbType.Int).Value = phnNumber;
                command.Parameters.AddWithValue("@gender", SqlDbType.VarChar).Value = gender;
                command.Parameters.AddWithValue("@address", SqlDbType.Int).Value = address;
                command.Parameters.AddWithValue("@photo", SqlDbType.VarChar).Value = photo;
                command.Parameters.AddWithValue("@photo_path", SqlDbType.VarChar).Value = photo_path;
                command.Parameters.AddWithValue("@p_id", SqlDbType.Int).Value = p_id;
                command.Parameters.AddWithValue("@is_delete", SqlDbType.Int).Value = is_delete;

                command.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}