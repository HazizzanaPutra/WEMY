using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;

namespace WEMY.Admin
{
    public partial class Payments : System.Web.UI.Page
    {
        PaymentRepository paymentRepo =
            new PaymentRepository();
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

            if (Request.QueryString["success"] == "approve")
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "approve",
                    "alert('Pembayaran berhasil diverifikasi. Membership telah aktif.');",
                    true);
            }

            if (!IsPostBack)
            {
                LoadPayments();
            }
        }

        private void LoadPayments()
        {
            gvPayments.DataSource =
                paymentRepo.GetWaitingPayments();

            gvPayments.DataBind();
        }
    }
}