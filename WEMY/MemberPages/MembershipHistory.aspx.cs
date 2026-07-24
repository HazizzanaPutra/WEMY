using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Helpers;

namespace WEMY.MemberPages
{
    public partial class MembershipHistory : System.Web.UI.Page
    {
        private OrderRepository orderRepo =new OrderRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadHistory();
            }
        }

        private void LoadHistory()
        {
            gvHistory.DataSource =
                orderRepo.GetHistoryByUserID(
                    SessionHelper.GetUserID());

            gvHistory.DataBind();
        }
    }
}