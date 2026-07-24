using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;

namespace WEMY.MemberPages
{
    public partial class YogaSchedule : System.Web.UI.Page
    {
        YogaClassRepository yogaRepo = new YogaClassRepository();
        private MemberRepository memberRepo = new MemberRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionHelper.IsLogin())
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadYogaClasses();
            }
        }

        private void LoadYogaClasses()
        {
            int userID =Convert.ToInt32(Session["UserID"]);

            DataRow info =
                memberRepo.GetDashboardInfo(userID);

            if (info == null)
            {
                lblPlan.Text = "Belum Aktif";

                rptYoga.DataSource = null;
                rptYoga.DataBind();

                return;
            }

            string plan =
                info["PlanName"].ToString().Trim();

            lblPlan.Text = plan;

            rptYoga.DataSource =
                yogaRepo.GetClassesByPlan(plan);

            rptYoga.DataBind();
        }

    }
}