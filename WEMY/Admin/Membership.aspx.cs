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
    public partial class Membership : System.Web.UI.Page
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
                LoadMemberships();
            }
        }

        private void LoadMemberships()
        {
            gvMembership.DataSource =
                membershipRepo.GetAll();

            gvMembership.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MembershipForm.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn =
                (Button)sender;

            Response.Redirect(
                "~/Admin/MembershipForm.aspx?id="
                + btn.CommandArgument);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn =
                (Button)sender;

            membershipRepo.Delete(
                Convert.ToInt32(btn.CommandArgument));

            LoadMemberships();
        }
    }
}