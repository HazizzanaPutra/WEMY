using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEMY.Database;
using WEMY.Models;
using WEMY.Helpers;

namespace WEMY
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMenu();
                if (SessionHelper.IsLogin())
                {
                    lblUser.Text = "Halo, " + SessionHelper.GetFullName();

                    lblUser.Visible = true;
                    btnLogout.Visible = true;
                    btnSignIn.Visible = false;
                }
                else
                {
                    lblUser.Visible = false;
                    btnLogout.Visible = false;
                    btnSignIn.Visible = true;
                }
            }
        }
        private void ShowMenu()
        {
            menuGuest.Visible = false;
            menuMember.Visible = false;
            menuAdmin.Visible = false;

            panelGuest.Visible = false;
            panelLogin.Visible = false;

            if (!SessionHelper.IsLogin())
            {
                menuGuest.Visible = true;
                panelGuest.Visible = true;
                return;
            }

            panelLogin.Visible = true;

            lblUser.Text = SessionHelper.GetFullName();

            if (SessionHelper.GetRoleName() == "Admin")
            {
                menuAdmin.Visible = true;
            }
            else
            {
                menuMember.Visible = true;
            }
        }

        protected void btnTrial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Membership.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserRepository repo = new UserRepository();

            User user = repo.Login(
                txtLoginEmail.Text,
                txtLoginPassword.Text);

            if (user != null)
            {
                SessionHelper.Login(user);

                MemberRepository memberRepo = new MemberRepository();

                memberRepo.CheckExpired(user.UserID);

                if (user.RoleID == 1)
                {
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("~/MemberPages/Dashboard.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "login",
                    "alert('Email atau Password salah!');",
                    true);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionHelper.Logout();

            Response.Redirect("~/Default.aspx");
        }

    }
}