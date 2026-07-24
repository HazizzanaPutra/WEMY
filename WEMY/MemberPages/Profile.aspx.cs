using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;

namespace WEMY.MemberPages
{
    public partial class Profile : System.Web.UI.Page
    {
        MemberRepository memberRepo = new MemberRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionHelper.IsLogin())
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            int userID = Convert.ToInt32(Session["UserID"]);

            DataRow row = memberRepo.GetProfile(userID);

            if (row == null)
                return;

            lblName.Text = row["FullName"].ToString();

            lblEmail.Text = row["Email"].ToString();

            lblPlan.Text = row["PlanName"].ToString();

            lblPlan2.Text = row["PlanName"].ToString();

            lblStatus.Text = row["Status"].ToString();

            if (row["JoinDate"] != DBNull.Value)
            {
                lblJoin.Text = Convert.ToDateTime(row["JoinDate"])
                    .ToString("dd MMMM yyyy");
            }
            else
            {
                lblJoin.Text = "-";
            }

            lblRole.Text = "Member";

            if (lblStatus.Text == "Active")
            {
                lblStatus.CssClass = "badge bg-success";
            }
            else
            {
                lblStatus.CssClass = "badge bg-secondary";
            }
        }
    }
}