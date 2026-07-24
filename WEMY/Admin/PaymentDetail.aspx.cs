using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;

namespace WEMY.Admin
{
    public partial class PaymentDetail : System.Web.UI.Page
    {
        private PaymentRepository paymentRepo = new PaymentRepository();
        private OrderRepository orderRepo = new OrderRepository();
        private MemberRepository memberRepo = new MemberRepository();
        MembershipRepository membershipRepo = new MembershipRepository();
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
                LoadDetail();
            }
        }

        private void LoadDetail()
        {
            int paymentID =
                Convert.ToInt32(
                Request.QueryString["id"]);

            DataRow row =
                paymentRepo.GetDetail(paymentID);

            if (row == null)
            {
                Response.Redirect("~/Admin/Payments.aspx");
                return;
            }

            lblName.Text =
                row["FullName"].ToString();

            lblEmail.Text =
                row["Email"].ToString();

            lblPlan.Text =
                row["PlanName"].ToString();

            lblDuration.Text =
                row["DurationMonth"] + " Bulan";

            lblAmount.Text =
                Convert.ToDecimal(
                row["Amount"])
                .ToString("N0");

            lblMethod.Text =
                row["PaymentMethod"].ToString();

            lblStatus.Text =
                row["Status"].ToString();

            imgProof.ImageUrl =
                "~/Uploads/Payments/"
                + row["PaymentProof"];
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int paymentID =Convert.ToInt32(Request.QueryString["id"]);

            DataRow paymentInfo =
                paymentRepo.GetPaymentInfo(paymentID);

            if (paymentInfo == null)
            {
                Response.Redirect("~/Admin/Payments.aspx");
                return;
            }

            int orderID =
                Convert.ToInt32(paymentInfo["OrderID"]);

            int memberID =
                Convert.ToInt32(paymentInfo["MemberID"]);

            int packageID =
                Convert.ToInt32(paymentInfo["PackageID"]);

            int duration = membershipRepo.GetDurationMonth(packageID);

            OrderRepository orderRepo =
                new OrderRepository();

            MemberRepository memberRepo =
                new MemberRepository();

            paymentRepo.Approve(paymentID);

            orderRepo.UpdateStatus(orderID, "Paid");

            memberRepo.Activate(memberID,duration);

            Response.Redirect("~/Admin/Payments.aspx?success=approve");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int paymentID = Convert.ToInt32(Request.QueryString["id"]);

            PaymentRepository paymentRepo =
                new PaymentRepository();

            paymentRepo.Reject(paymentID);

            Response.Redirect("PaymentVerification.aspx");
        }
    }
}