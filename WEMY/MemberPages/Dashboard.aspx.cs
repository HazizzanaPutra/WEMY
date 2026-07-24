using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WEMY.Database;
using WEMY.Helpers;

namespace WEMY.MemberPages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private MemberRepository memberRepo = new MemberRepository();
        private OrderRepository orderRepo = new OrderRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionHelper.IsLogin())
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            memberRepo.CheckExpired(SessionHelper.GetUserID());

            if (!IsPostBack)
            {
                lblFullName.Text = SessionHelper.GetFullName();

                LoadDashboard();
                LoadLatestOrders();
            }
        }
        private void LoadDashboard()
        {
            DataRow row =memberRepo.GetDashboardInfo(SessionHelper.GetUserID());

            if (row == null)
            {
                lblStatus.InnerText = "Belum Aktif";
                return;
            }

            if (row["Status"].ToString() == "Active")
            {
                lblStatus.InnerText =
                    "🟢 Membership Aktif";

                lblStatus.Attributes["class"] =
                    "status-active";
            }
            else
            {
                lblStatus.InnerText =
                    "🟠 Membership Belum Aktif";

                lblStatus.Attributes["class"] =
                    "status-inactive";
            }

            lblPlan.InnerText =
                row["PlanName"].ToString();

            if (row["JoinDate"] != DBNull.Value)
            {
                DateTime joinDate =
                    Convert.ToDateTime(row["JoinDate"]);

                lblJoinDate.InnerText =
                    joinDate.ToString("dd MMMM yyyy");
            }

            if (row["EndDate"] != DBNull.Value)
            {
                DateTime endDate =
                    Convert.ToDateTime(row["EndDate"]);

                lblEndDate.InnerText =
                    endDate.ToString("dd MMMM yyyy");

                TimeSpan sisa =
                    endDate.Date - DateTime.Today;

                if (sisa.Days > 0)
                {
                    lblRemaining.InnerText =
                        sisa.Days + " Hari";
                }
                else
                {
                    lblRemaining.InnerText =
                        "Expired";
                }
            }

            lblMemberStatus.InnerText = row["Status"].ToString();

            btnBuyMembership.Visible =
                row["Status"].ToString() != "Active";
        }

        private void LoadLatestOrders()
        {
            gvHistory.DataSource =
        orderRepo.GetLatestOrders(SessionHelper.GetUserID());

            gvHistory.DataBind();
        }

        protected void gvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl =
                    (Label)e.Row.FindControl("lblStatus");

                switch (lbl.Text)
                {
                    case "Paid":

                        lbl.Text = "Disetujui";

                        lbl.CssClass =
                            "badge bg-success";

                        break;

                    case "Waiting Verification":

                        lbl.Text = "Menunggu Verifikasi";

                        lbl.CssClass =
                            "badge bg-warning text-dark";

                        break;

                    case "Rejected":

                        lbl.Text = "Ditolak";

                        lbl.CssClass =
                            "badge bg-danger";

                        break;

                    case "Expired":

                        lbl.Text = "Berakhir";

                        lbl.CssClass =
                            "badge bg-secondary";

                        break;
                }
            }
        }
    }
}