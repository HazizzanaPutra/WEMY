using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEMY.Models;

namespace WEMY.Database
{
    public class MemberRepository
    {

        public Member GetByUserID(int userID)
        {
            Member member = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT
                                MemberID,
                                UserID,
                                JoinDate,
                                EndDate,
                                Status
                            FROM Members
                            WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    member = new Member();

                    member.MemberID = Convert.ToInt32(dr["MemberID"]);

                    member.UserID = Convert.ToInt32(dr["UserID"]);

                    if (dr["JoinDate"] != DBNull.Value)
                        member.JoinDate = Convert.ToDateTime(dr["JoinDate"]);

                    if (dr["EndDate"] != DBNull.Value)
                        member.EndDate = Convert.ToDateTime(dr["EndDate"]);

                    member.Status = dr["Status"].ToString();
                }

                dr.Close();
            }

            return member;
        }

        public int Create(Member member)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
            INSERT INTO Members
            (
                UserID,
                JoinDate,
                Status
            )

            VALUES

            (
                @UserID,
                @JoinDate,
                @Status
            );

            SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UserID", member.UserID);

                if (member.JoinDate == null)
                    cmd.Parameters.AddWithValue("@JoinDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@JoinDate", member.JoinDate);

                cmd.Parameters.AddWithValue("@Status", member.Status);

                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Activate(int memberID, int durationMonth)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddMonths(durationMonth);

                string sql = @"
                            UPDATE Members
                            SET
                                JoinDate = @JoinDate,
                                EndDate = @EndDate,
                                Status = @Status
                            WHERE MemberID = @MemberID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@JoinDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Status", "Active");
                cmd.Parameters.AddWithValue("@MemberID", memberID);

                cmd.ExecuteNonQuery();
            }
        }

        public DataRow GetDashboardInfo(int userID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT TOP 1
                            m.Status,
                            m.JoinDate,
                            m.EndDate,
                            mp.PlanName

                        FROM Members m

                        INNER JOIN Orders o
                            ON m.MemberID = o.MemberID

                        INNER JOIN MembershipPlans mp
                            ON o.PackageID = mp.PlanID

                        WHERE
                            m.UserID = @UserID
                            AND m.Status = 'Active'
                            AND o.Status = 'Paid'

                        ORDER BY o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                    return null;

                return dt.Rows[0];
            }
        }

        public DataRow GetProfile(int userID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT TOP 1

                                u.FullName,
                                u.Email,
                                r.RoleName,
                                m.Status,
                                m.JoinDate,
                                mp.PlanName

                            FROM Users u

                            LEFT JOIN Roles r
                                ON u.RoleID = r.RoleID

                            LEFT JOIN Members m
                                ON u.UserID = m.UserID

                            LEFT JOIN Orders o
                                ON m.MemberID = o.MemberID

                            LEFT JOIN MembershipPlans mp
                                ON o.PackageID = mp.PlanID

                            WHERE u.UserID = @UserID

                            ORDER BY o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                    return null;

                return dt.Rows[0];
            }
        }

        public DataTable GetAllMembers(string keyword = "")
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"

                            SELECT

                            m.MemberID,

                            u.FullName,

                            u.Email,

                            mp.PlanName,

                            m.Status,

                            m.JoinDate

                            FROM Members m

                            INNER JOIN Users u
                            ON m.UserID=u.UserID

                            LEFT JOIN Orders o
                            ON m.MemberID=o.MemberID

                            LEFT JOIN MembershipPlans mp
                            ON o.PackageID=mp.PlanID

                            WHERE
                                o.Status = 'Paid'
                            AND
                                m.Status = 'Active'

                            ORDER BY
                            u.FullName";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetMemberById(int memberID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT TOP 1

                                m.MemberID,
                                u.FullName,
                                u.Email,
                                m.JoinDate,
                                m.Status,
                                mp.PlanName

                            FROM Members m

                            INNER JOIN Users u
                                ON m.UserID = u.UserID

                            LEFT JOIN Orders o
                                ON m.MemberID = o.MemberID

                            LEFT JOIN MembershipPlans mp
                                ON o.PackageID = mp.PlanID

                            WHERE
                                m.MemberID = @MemberID

                            ORDER BY
                                o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MemberID", memberID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public void CheckExpired(int userID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            UPDATE Members
                            SET Status = 'Expired'
                            WHERE UserID = @UserID
                            AND Status = 'Active'
                            AND EndDate IS NOT NULL
                            AND EndDate < GETDATE()";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", userID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}