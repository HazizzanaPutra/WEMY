using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Helpers;
using WEMY.Database;

namespace WEMY.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private DashboardRepository dashboardRepo =new DashboardRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionHelper.IsLogin())
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            if (!SessionHelper.IsAdmin())
            {
                Response.Redirect("~/MemberPages/Dashboard.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }
        protected void btnPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Payments.aspx");
        }

        private void LoadStatistics()
        {
            DataRow row =
                dashboardRepo.GetStatistics();

            lblTotalMember.InnerText =
                row["TotalMembers"].ToString();

            lblActiveMember.InnerText =
                row["ActiveMembers"].ToString();

            lblWaiting.InnerText =
                row["WaitingVerification"].ToString();

            decimal revenue =
                Convert.ToDecimal(row["TotalRevenue"]);

            lblRevenue.InnerText =
                "Rp " + revenue.ToString("N0");
        }
    }
}