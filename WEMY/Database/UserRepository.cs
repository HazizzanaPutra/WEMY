using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEMY.Models;

namespace WEMY.Database
{
    public class UserRepository
    {
        public void Register(User user)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Users
                            (
                                FullName,
                                Email,
                                Password,
                                CreatedDate,
                                RoleID
                            )
                            VALUES
                            (
                                @Nama,
                                @Email,
                                @Password,
                                GETDATE(),
                                2
                            )";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nama", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cmd.ExecuteNonQuery();
            }
        }

        public bool EmailExists(string email)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM Users WHERE Email=@Email";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Email", email);

                int jumlah = (int)cmd.ExecuteScalar();

                return jumlah > 0;
            }
        }

        public User Login(string email, string password)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT
                                U.UserID,
                                U.FullName,
                                U.Email,
                                U.RoleID,
                                R.RoleName
                            FROM Users U
                            INNER JOIN Roles R
                                ON U.RoleID = R.RoleID
                            WHERE U.Email = @Email
                            AND U.Password = @Password";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    User user = new User();

                    user.UserID = Convert.ToInt32(dr["UserID"]);
                    user.FullName = dr["FullName"].ToString();
                    user.Email = dr["Email"].ToString();

                    user.RoleID = Convert.ToInt32(dr["RoleID"]);
                    user.RoleName = dr["RoleName"].ToString();

                    return user;
                }

                return null;
            }
        }
    }
}