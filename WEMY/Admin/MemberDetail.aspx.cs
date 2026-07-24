using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;

namespace WEMY.Admin
{
    public partial class MemberDetail : System.Web.UI.Page
    {
        MemberRepository memberRepo = new MemberRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int memberID =
                        Convert.ToInt32(Request.QueryString["id"]);

                    LoadMember(memberID);
                }
            }
        }

        private void LoadMember(int memberID)
        {
            DataTable dt = memberRepo.GetMemberById(memberID);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                lblName.Text = row["FullName"].ToString();
                lblEmail.Text = row["Email"].ToString();
                lblPlan.Text = row["PlanName"].ToString();
                string status = row["Status"].ToString();

                if (status == "Active")
                {
                    lblStatus.Text =
                        "<span class='badge bg-success'>Active</span>";
                }
                else
                {
                    lblStatus.Text =
                        "<span class='badge bg-danger'>Inactive</span>";
                }

                lblStatus.EnableViewState = false;

                lblJoinDate.Text =
                    Convert.ToDateTime(row["JoinDate"])
                    .ToString("dd MMMM yyyy");
            }
        }
    }
}