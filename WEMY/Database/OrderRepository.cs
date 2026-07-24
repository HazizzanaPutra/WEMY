using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEMY.Models;

namespace WEMY.Database
{
    public class OrderRepository
    {
        public int Create(Order order)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                INSERT INTO Orders
                (
                    MemberID,
                    PackageID,
                    OrderDate,
                    TotalPrice,
                    Status
                )

                VALUES

                (
                    @MemberID,
                    @PackageID,
                    @OrderDate,
                    @TotalPrice,
                    @Status
                );

                SELECT SCOPE_IDENTITY();
                ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MemberID", order.MemberID);
                cmd.Parameters.AddWithValue("@PackageID", order.PackageID);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                cmd.Parameters.AddWithValue("@Status", order.Status);

                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public Order GetByID(int orderID)
        {
            Order order = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT
                            OrderID,
                            MemberID,
                            PackageID,
                            OrderDate,
                            TotalPrice,
                            Status
                         FROM Orders
                         WHERE OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@OrderID", orderID);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    order = new Order();

                    order.OrderID = Convert.ToInt32(dr["OrderID"]);
                    order.MemberID = Convert.ToInt32(dr["MemberID"]);
                    order.PackageID = Convert.ToInt32(dr["PackageID"]);
                    order.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                    order.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                    order.Status = dr["Status"].ToString();
                }

                dr.Close();
            }

            return order;
        }

        public Order GetLatestOrderByMember(int memberID)
        {
            Order order = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
        SELECT TOP 1
            OrderID,
            MemberID,
            PackageID,
            OrderDate,
            TotalPrice,
            Status
        FROM Orders
        WHERE MemberID=@MemberID
        ORDER BY OrderID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MemberID", memberID);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    order = new Order();

                    order.OrderID = Convert.ToInt32(dr["OrderID"]);
                    order.MemberID = Convert.ToInt32(dr["MemberID"]);
                    order.PackageID = Convert.ToInt32(dr["PackageID"]);
                    order.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                    order.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                    order.Status = dr["Status"].ToString();
                }

                dr.Close();
            }

            return order;
        }

        public void UpdateStatus(int orderID, string status)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            UPDATE Orders
                            SET Status = @Status
                            WHERE OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetHistoryByUserID(int userID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT
                                o.OrderDate,
                                mp.PlanName,
                                o.TotalPrice,
                                o.Status
                            FROM Orders o
                            INNER JOIN Members m
                                ON o.MemberID = m.MemberID
                            INNER JOIN MembershipPlans mp
                                ON o.PackageID = mp.PlanID
                            WHERE m.UserID = @UserID
                            ORDER BY o.OrderDate DESC";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataRow GetLatestOrder(int userID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT TOP 1

                                o.OrderDate,
                                mp.PlanName,
                                o.TotalPrice,
                                o.Status

                            FROM Orders o

                            INNER JOIN Members m
                                ON o.MemberID = m.MemberID

                            INNER JOIN MembershipPlans mp
                                ON o.PackageID = mp.PlanID

                            WHERE m.UserID = @UserID

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

        public DataTable GetLatestOrders(int userID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT TOP 3

                                o.OrderDate,
                                mp.PlanName,
                                o.TotalPrice,
                                o.Status

                            FROM Orders o

                            INNER JOIN Members m
                                ON o.MemberID = m.MemberID

                            INNER JOIN MembershipPlans mp
                                ON o.PackageID = mp.PlanID

                            WHERE m.UserID=@UserID

                            ORDER BY o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

    }

}