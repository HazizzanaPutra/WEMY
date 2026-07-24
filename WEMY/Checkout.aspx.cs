using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;
using WEMY.Models;
using WEMY.Constants;

namespace WEMY
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionHelper.IsLogin())
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadOrder();
            }
        }

        private void LoadOrder()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            int orderID =
                Convert.ToInt32(
                    Request.QueryString["id"]);

            OrderRepository orderRepo =
                new OrderRepository();

            Order order =
                orderRepo.GetByID(orderID);

            if (order == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            MembershipRepository packageRepo =
                new MembershipRepository();

            MembershipPlan plan =
                packageRepo.GetByID(order.PackageID);

            lblPackage.InnerText =
                plan.PlanName;

            lblPrice.InnerText =
                "Rp " + order.TotalPrice.ToString("N0");
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            if (!fuPayment.HasFile)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "file",
                    "alert('Silakan upload bukti pembayaran.');",
                    true);

                return;
            }

            string extension =System.IO.Path.GetExtension(fuPayment.FileName).ToLower();
            string[] allowedExtension =UploadSettings.AllowedExtensions;

            if (!allowedExtension.Contains(extension))
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "file",
                    "alert('Format file harus JPG, JPEG atau PNG.');",
                    true);

                return;
            }

            if (fuPayment.PostedFile.ContentLength > UploadSettings.MaxFileSize)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "size",
                    "alert('Ukuran file maksimal 2 MB.');",
                    true);

                return;
            }

            int orderID =
            Convert.ToInt32(
                Request.QueryString["id"]);

            OrderRepository orderRepo =
                new OrderRepository();

            Order order =
                orderRepo.GetByID(orderID);

            if (order == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            PaymentRepository paymentRepo = new PaymentRepository();

            if (paymentRepo.Exists(order.OrderID))
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "exist",
                    "alert('Pembayaran untuk pesanan ini sudah pernah dikirim.');",
                    true);

                return;
            }
            string fileName =
                Guid.NewGuid().ToString() + extension;

            string folder =
                Server.MapPath("~/Uploads/Payments/");

            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            fuPayment.SaveAs(folder + fileName);

            Payment payment = new Payment
            {
                OrderID = order.OrderID,
                PaymentDate = DateTime.Now,
                Amount = order.TotalPrice,
                PaymentMethod = ddlPaymentMethod.SelectedValue,
                PaymentProof = fileName,
                Status = PaymentStatus.WaitingVerification
            };

            paymentRepo.Create(payment);
            orderRepo.UpdateStatus(order.OrderID,OrderStatus.WaitingVerification);

            Response.Redirect("~/MemberPages/Dashboard.aspx?success=payment");
        }
    }
}