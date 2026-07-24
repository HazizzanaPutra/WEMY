using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Database
{
    public class DashboardRepository
    {
        public DataRow GetStatistics()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT

                            (SELECT COUNT(*) FROM Members)
                            AS TotalMembers,

                            (SELECT COUNT(*)
                             FROM Members
                             WHERE Status='Active')
                            AS ActiveMembers,

                            (SELECT COUNT(*)
                             FROM Payments
                             WHERE Status='Waiting Verification')
                            AS WaitingVerification,

                            ISNULL
                            (
                            (
                            SELECT SUM(Amount)
                            FROM Payments
                            WHERE Status='Approved'
                            ),
                            0
                            )
                            AS TotalRevenue,

                            (SELECT COUNT(*)
                             FROM YogaClasses)
                            AS TotalClasses";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt.Rows[0];
            }
        }

        public DataTable GetPaymentReport()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT

                                p.PaymentID,

                                u.FullName,

                                mp.PlanName,

                                p.Amount,

                                p.Status,

                                p.PaymentDate

                            FROM Payments p

                            INNER JOIN Orders o
                            ON p.OrderID = o.OrderID

                            INNER JOIN Members m
                            ON o.MemberID = m.MemberID

                            INNER JOIN Users u
                            ON m.UserID = u.UserID

                            INNER JOIN MembershipPlans mp
                            ON o.PackageID = mp.PlanID

                            ORDER BY p.PaymentDate DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
    }
}