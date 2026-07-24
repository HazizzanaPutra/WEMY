using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEMY.Models;

namespace WEMY.Database
{
    public class MembershipRepository
    {
        public List<MembershipPlan> GetAll()
        {
            List<MembershipPlan> list = new List<MembershipPlan>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT
                                    PlanID,
                                    PlanName,
                                    Price,
                                    DurationMonth,
                                    Description
                                 FROM MembershipPlans
                                 ORDER BY DurationMonth";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MembershipPlan plan = new MembershipPlan();

                    plan.PlanID = Convert.ToInt32(dr["PlanID"]);
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.Price = Convert.ToDecimal(dr["Price"]);
                    plan.DurationMonth = Convert.ToInt32(dr["DurationMonth"]);
                    plan.Description = dr["Description"].ToString();

                    list.Add(plan);
                }

                dr.Close();
            }

            return list;
        }

        public MembershipPlan GetByID(int planID)
        {
            MembershipPlan plan = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT
                            PlanID,
                            PlanName,
                            Price,
                            DurationMonth,
                            Description
                         FROM MembershipPlans
                         WHERE PlanID=@PlanID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PlanID", planID);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    plan = new MembershipPlan();

                    plan.PlanID = Convert.ToInt32(dr["PlanID"]);
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.Price = Convert.ToDecimal(dr["Price"]);
                    plan.DurationMonth = Convert.ToInt32(dr["DurationMonth"]);
                    plan.Description = dr["Description"].ToString();
                }

                dr.Close();
            }

            return plan;
        }

        public void Create(MembershipPlan plan)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            INSERT INTO MembershipPlans
                            (
                                PlanName,
                                Price,
                                DurationMonth,
                                Description
                            )
                            VALUES
                            (
                                @PlanName,
                                @Price,
                                @DurationMonth,
                                @Description
                            )";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PlanName", plan.PlanName);
                cmd.Parameters.AddWithValue("@Price", plan.Price);
                cmd.Parameters.AddWithValue("@DurationMonth", plan.DurationMonth);
                cmd.Parameters.AddWithValue("@Description", plan.Description);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(MembershipPlan plan)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            UPDATE MembershipPlans
                            SET
                                PlanName = @PlanName,
                                Price = @Price,
                                DurationMonth = @DurationMonth,
                                Description = @Description
                            WHERE PlanID = @PlanID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PlanID", plan.PlanID);
                cmd.Parameters.AddWithValue("@PlanName", plan.PlanName);
                cmd.Parameters.AddWithValue("@Price", plan.Price);
                cmd.Parameters.AddWithValue("@DurationMonth", plan.DurationMonth);
                cmd.Parameters.AddWithValue("@Description", plan.Description);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int planID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql =
                    "DELETE FROM MembershipPlans WHERE PlanID=@PlanID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PlanID", planID);

                cmd.ExecuteNonQuery();
            }
        }

        public int GetDurationMonth(int planID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT DurationMonth
                            FROM MembershipPlans
                            WHERE PlanID = @PlanID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PlanID", planID);

                object result = cmd.ExecuteScalar();

                if (result == null)
                    return 0;

                return Convert.ToInt32(result);
            }
        }
    }
}