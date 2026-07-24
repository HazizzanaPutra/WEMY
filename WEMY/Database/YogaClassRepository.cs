using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WEMY.Models;

namespace WEMY.Database
{
    public class YogaClassRepository
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                SELECT *
                FROM YogaClasses
                ORDER BY ClassDate, StartTime";

                SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public YogaClass GetByID(int id)
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql =
                    "SELECT * FROM YogaClasses WHERE ClassID=@ID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                YogaClass yoga = new YogaClass();

                yoga.ClassID =
                    Convert.ToInt32(reader["ClassID"]);

                yoga.ClassTitle =
                    reader["ClassTitle"].ToString();

                yoga.Theme =
                    reader["Theme"].ToString();

                yoga.Difficulty =
                    reader["Difficulty"].ToString();

                yoga.ClassDate =
                    Convert.ToDateTime(reader["ClassDate"]);

                yoga.StartTime =
                    (TimeSpan)reader["StartTime"];

                yoga.EndTime =
                    (TimeSpan)reader["EndTime"];

                yoga.Teacher =
                    reader["Teacher"].ToString();

                yoga.MaxParticipant =
                    Convert.ToInt32(reader["MaxParticipant"]);

                return yoga;
            }
        }

        public void Create(YogaClass yoga)
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            INSERT INTO YogaClasses
                            (
                                ClassTitle,
                                Theme,
                                Difficulty,
                                ClassDate,
                                StartTime,
                                EndTime,
                                Teacher,
                                MaxParticipant
                            )
                            VALUES
                            (
                                @ClassTitle,
                                @Theme,
                                @Difficulty,
                                @ClassDate,
                                @StartTime,
                                @EndTime,
                                @Teacher,
                                @MaxParticipant
                            )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ClassTitle", yoga.ClassTitle);
                cmd.Parameters.AddWithValue("@Theme", yoga.Theme);
                cmd.Parameters.AddWithValue("@Difficulty", yoga.Difficulty);
                cmd.Parameters.AddWithValue("@ClassDate", yoga.ClassDate);
                cmd.Parameters.AddWithValue("@StartTime", yoga.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", yoga.EndTime);
                cmd.Parameters.AddWithValue("@Teacher", yoga.Teacher);
                cmd.Parameters.AddWithValue("@MaxParticipant", yoga.MaxParticipant);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(YogaClass yoga)
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            UPDATE YogaClasses
                            SET
                                ClassTitle = @ClassTitle,
                                Theme = @Theme,
                                Difficulty = @Difficulty,
                                ClassDate = @ClassDate,
                                StartTime = @StartTime,
                                EndTime = @EndTime,
                                Teacher = @Teacher,
                                MaxParticipant = @MaxParticipant
                            WHERE ClassID = @ClassID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ClassID", yoga.ClassID);
                cmd.Parameters.AddWithValue("@ClassTitle", yoga.ClassTitle);
                cmd.Parameters.AddWithValue("@Theme", yoga.Theme);
                cmd.Parameters.AddWithValue("@Difficulty", yoga.Difficulty);
                cmd.Parameters.AddWithValue("@ClassDate", yoga.ClassDate);
                cmd.Parameters.AddWithValue("@StartTime", yoga.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", yoga.EndTime);
                cmd.Parameters.AddWithValue("@Teacher", yoga.Teacher);
                cmd.Parameters.AddWithValue("@MaxParticipant", yoga.MaxParticipant);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int classID)
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql =
                    "DELETE FROM YogaClasses WHERE ClassID=@ClassID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ClassID", classID);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetUpcomingClasses()
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT *
                            FROM YogaClasses
                            WHERE ClassDate >= CAST(GETDATE() AS DATE)
                            ORDER BY ClassDate, StartTime";

                SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetAllClasses()
        {
            return GetAll();
        }

        public DataTable GetClassesByPlan(string plan)
        {
            using (SqlConnection conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = "";

                if (plan == "Basic")
                {
                    sql = @"
                        SELECT *
                        FROM YogaClasses
                        WHERE Difficulty IN
                        (
                        'Beginner',
                        'All Level'
                        )
                        ORDER BY ClassDate";
                }
                else if (plan == "Premium")
                {
                    sql = @"
                        SELECT *
                        FROM YogaClasses
                        WHERE Difficulty IN
                        (
                        'Beginner',
                        'Intermediate',
                        'All Level'
                        )
                        ORDER BY ClassDate";
                }
                else
                {
                    sql = @"
                        SELECT *
                        FROM YogaClasses
                        ORDER BY ClassDate";
                }

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