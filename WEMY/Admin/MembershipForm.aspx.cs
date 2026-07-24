using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;
using WEMY.Models;

namespace WEMY.Admin
{
    public partial class MembershipForm : System.Web.UI.Page
    {
        private MembershipRepository membershipRepo = new MembershipRepository();
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
                if (Request.QueryString["id"] != null)
                {
                    LoadMembership();
                }
            }
        }

        private void LoadMembership()
        {
            int planID =
                Convert.ToInt32(
                Request.QueryString["id"]);

            MembershipPlan plan =
                membershipRepo.GetByID(planID);

            if (plan == null)
            {
                Response.Redirect("~/Admin/Memberships.aspx");
                return;
            }

            lblTitle.InnerText =
                "Edit Membership";

            txtPlanName.Text =
                plan.PlanName;

            txtPrice.Text =
                plan.Price.ToString();

            txtDuration.Text =
                plan.DurationMonth.ToString();

            txtDescription.Text =
                plan.Description;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MembershipPlan plan =
                new MembershipPlan();

            plan.PlanName =
                txtPlanName.Text.Trim();

            plan.Price =
                Convert.ToDecimal(txtPrice.Text);

            plan.DurationMonth =
                Convert.ToInt32(txtDuration.Text);

            plan.Description =
                txtDescription.Text.Trim();

            if (Request.QueryString["id"] == null)
            {
                membershipRepo.Create(plan);
            }
            else
            {
                plan.PlanID =
                    Convert.ToInt32(
                    Request.QueryString["id"]);

                membershipRepo.Update(plan);
            }

            Response.Redirect("~/Admin/Membership.aspx");
        }
    }
}