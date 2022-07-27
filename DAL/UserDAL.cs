using Ecommerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.DAL
{
    public class UserDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UserDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int UserSignUp(User]------------ user)
        {
            string qry = "insert into Users values(@first,@last,@email,@pass)";
            cmd = new SqlCommandBuilder(qry, con);
            cmd.Parameters.AddWithValue("@first", user.FName);
            cmd.Parameters.AddWithValue("@last", user.LName);
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.Parameters.AddWithValue("pass", user.Password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public User UserLogin(User users)
        {
            User user = new User();
            string qry = "select * from Users where Email=@email";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("email", users.Email);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    user.Id = Convert.ToInt32(dr["Id"]);
                    user.FName = dr["FirstName"].ToString();
                    user.LName = dr["LastName"].ToString();
                    user.Email = dr["Email"].ToString();
                    user.Password = dr["Password"].ToString();
                }
                con.Close();
                return user;

            }
            else
            {
                return user;
            }
        }
    }
}

