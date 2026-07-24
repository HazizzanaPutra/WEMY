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
    public partial class ManageMembers : System.Web.UI.Page
    {
        MemberRepository memberRepo = new MemberRepository();
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
                LoadMembers();
            }
        }

        private void LoadMembers(string keyword = "")
        {
            DataTable dt = memberRepo.GetAllMembers(keyword);

            gvMember.DataSource = dt;

            gvMember.DataBind();

            lblTotalMember.Text = dt.Rows.Count.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembers(txtSearch.Text.Trim());
        }
    }
}