using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Models;
using WEMY.Helpers;

namespace WEMY
{
    public partial class Membership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionHelper.IsLogin())
            {
                btnOrder.OnClientClick = "openLoginModal(); return false;";
            }
            else
            {
                btnOrder.OnClientClick = null;
            }

            if (!IsPostBack)
            {
                LoadMembership();
            }
        }

        private Member GetOrCreateMember(int userID)
        {
            MemberRepository repo =
        new MemberRepository();

            Member member =
                repo.GetByUserID(userID);

            if (member == null)
            {
                member = new Member();

                member.UserID = userID;

                member.JoinDate = null;

                member.Status = "Inactive";

                member.MemberID =
                    repo.Create(member);
            }

            return member;
        }

        private MembershipPlan GetSelectedPlan()
        {
            int planID =
        Convert.ToInt32(
            Request.QueryString["id"]);

            MembershipRepository repo =
                new MembershipRepository();

            return repo.GetByID(planID);
        }

        private int CreateOrder(Member member, MembershipPlan plan)
        {
            Order order = new Order();

            order.MemberID = member.MemberID;

            order.PackageID = plan.PlanID;

            order.OrderDate = DateTime.Now;

            order.TotalPrice = plan.Price;

            order.Status = "Pending";

            OrderRepository repo =
                new OrderRepository();

            return repo.Create(order);
        }

        private void LoadMembership()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            int planID = Convert.ToInt32(Request.QueryString["id"]);

            MembershipRepository repo = new MembershipRepository();

            MembershipPlan plan = repo.GetByID(planID);

            if (plan == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            lblPlanName.InnerText = plan.PlanName;

            lblPrice.InnerText =
                "Rp " + plan.Price.ToString("N0");

            lblDuration.InnerText =
                plan.DurationMonth + " Bulan";

            lblDescription.InnerText =
                plan.Description;
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (SessionHelper.IsAdmin())
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "admin",
                    "alert('Administrator tidak dapat melakukan pemesanan.');",
                    true);
                return;
            }

            Member member = GetOrCreateMember(SessionHelper.GetUserID());

            MembershipPlan plan = GetSelectedPlan();

            int orderID = CreateOrder(member, plan);

            Response.Redirect("~/Checkout.aspx?id=" + orderID);
        }
    }
}