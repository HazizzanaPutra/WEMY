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
    public partial class Reports : System.Web.UI.Page
    {
        private DashboardRepository dashboardRepo = new DashboardRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatistics();
                LoadPayments();
            }
        }

        private void LoadStatistics()
        {
            DataRow row =
                dashboardRepo.GetStatistics();

            lblMember.Text =
                row["ActiveMembers"].ToString();

            lblWaiting.Text =
                row["WaitingVerification"].ToString();

            lblRevenue.Text =
                "Rp " +
                Convert.ToDecimal(
                    row["TotalRevenue"])
                .ToString("N0");

            lblClass.Text =
                row["TotalClasses"].ToString();
        }

        private void LoadPayments()
        {
            gvPayment.DataSource =
                dashboardRepo.GetPaymentReport();

            gvPayment.DataBind();
        }

        protected void gvPayment_RowDataBound(object sender,GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Label lbl =
                (Label)e.Row.FindControl("lblStatus");

            switch (lbl.Text)
            {
                case "Approved":

                    lbl.CssClass =
                        "badge bg-success";

                    break;

                case "Waiting Verification":

                    lbl.CssClass =
                        "badge bg-warning text-dark";

                    break;

                case "Rejected":

                    lbl.CssClass =
                        "badge bg-danger";

                    break;
            }
        }
    }
}