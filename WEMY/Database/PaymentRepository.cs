using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using WEMY.Constants;
using WEMY.Models;

namespace WEMY.Database
{
    public class PaymentRepository
    {
        public int Create(Payment payment)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            INSERT INTO Payments
                            (
                                OrderID,
                                PaymentDate,
                                Amount,
                                PaymentMethod,
                                PaymentProof,
                                Status
                            )
                            VALUES
                            (
                                @OrderID,
                                @PaymentDate,
                                @Amount,
                                @PaymentMethod,
                                @PaymentProof,
                                @Status
                            );

                            SELECT SCOPE_IDENTITY();
                            ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@OrderID", payment.OrderID);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);

                if (string.IsNullOrEmpty(payment.PaymentProof))
                    cmd.Parameters.AddWithValue("@PaymentProof", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PaymentProof", payment.PaymentProof);

                cmd.Parameters.AddWithValue("@Status", payment.Status);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Exists(int orderID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT COUNT(*)
                            FROM Payments
                            WHERE OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@OrderID", orderID);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public DataTable GetWaitingPayments()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT
                            p.PaymentID,
                            p.OrderID,
                            u.FullName,
                            u.Email,
                            mp.PlanName,
                            p.Amount,
                            p.PaymentMethod,
                            p.PaymentDate,
                            p.Status
                        FROM Payments p
                        INNER JOIN Orders o
                            ON p.OrderID = o.OrderID
                        INNER JOIN Members m
                            ON o.MemberID = m.MemberID
                        INNER JOIN Users u
                            ON m.UserID = u.UserID
                        INNER JOIN MembershipPlans mp
                            ON o.PackageID = mp.PlanID
                        WHERE p.Status = @Status
                        ORDER BY p.PaymentDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    PaymentStatus.WaitingVerification);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataRow GetDetail(int paymentID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT
                                p.PaymentID,
                                p.OrderID,
                                u.FullName,
                                u.Email,
                                mp.PlanName,
                                mp.DurationMonth,
                                p.Amount,
                                p.PaymentMethod,
                                p.PaymentProof,
                                p.PaymentDate,
                                p.Status
                            FROM Payments p
                            INNER JOIN Orders o
                                ON p.OrderID = o.OrderID
                            INNER JOIN Members m
                                ON o.MemberID = m.MemberID
                            INNER JOIN Users u
                                ON m.UserID = u.UserID
                            INNER JOIN MembershipPlans mp
                                ON o.PackageID = mp.PlanID
                            WHERE p.PaymentID = @PaymentID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@PaymentID",
                    paymentID);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                    return null;

                return dt.Rows[0];
            }
        }

        public void Approve(int paymentID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            UPDATE Payments
                            SET Status = @Status
                            WHERE PaymentID = @PaymentID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Status", "Approved");
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                cmd.ExecuteNonQuery();
            }
        }

        public DataRow GetPaymentInfo(int paymentID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT
                            p.PaymentID,
                            o.OrderID,
                            o.MemberID,
                            o.PackageID
                        FROM Payments p
                        INNER JOIN Orders o
                            ON p.OrderID = o.OrderID
                        WHERE p.PaymentID = @PaymentID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                    return null;

                return dt.Rows[0];
            }
        }

        public void Reject(int paymentID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            UPDATE Payments
                            SET Status='Rejected'
                            WHERE PaymentID=@PaymentID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Status", "Rejected");
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}