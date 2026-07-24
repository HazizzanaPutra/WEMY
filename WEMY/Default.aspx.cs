using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;

namespace WEMY
{
    public partial class _Default : Page
    {
        private YogaClassRepository yogaRepo = new YogaClassRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMembership();
                LoadYogaClasses();
            }
        }

        private void LoadMembership()
        {
            MembershipRepository repo = new MembershipRepository();

            rptMembership.DataSource = repo.GetAll();

            rptMembership.DataBind();
        }

        private void LoadYogaClasses()
        {
            rptYoga.DataSource =
                yogaRepo.GetUpcomingClasses();

            rptYoga.DataBind();
        }
    }
}