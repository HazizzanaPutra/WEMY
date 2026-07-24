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
    public partial class YogaClassForm : System.Web.UI.Page
    {
        private YogaClassRepository yogaRepo = new YogaClassRepository();
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
                    LoadYogaClass();
                }
            }
        }

        private void LoadYogaClass()
        {
            int id =
                Convert.ToInt32(
                Request.QueryString["id"]);

            YogaClass yoga =
                yogaRepo.GetByID(id);

            if (yoga == null)
            {
                Response.Redirect("~/Admin/YogaClasses.aspx");
                return;
            }

            lblTitle.InnerText =
                "Edit Jadwal Yoga";

            txtClassTitle.Text =
                yoga.ClassTitle;

            ddlTheme.SelectedValue =
                yoga.Theme;

            ddlDifficulty.SelectedValue =
                yoga.Difficulty;

            txtDate.Text =
                yoga.ClassDate.ToString("yyyy-MM-dd");

            txtStartTime.Text =
                yoga.StartTime.ToString(@"hh\:mm");

            txtEndTime.Text =
                yoga.EndTime.ToString(@"hh\:mm");

            txtTeacher.Text =
                yoga.Teacher;

            txtMaxParticipant.Text =
                yoga.MaxParticipant.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            YogaClass yoga = new YogaClass();

            yoga.ClassTitle = txtClassTitle.Text.Trim();
            yoga.Theme = ddlTheme.SelectedValue;
            yoga.Difficulty = ddlDifficulty.SelectedValue;

            yoga.ClassDate =
                Convert.ToDateTime(txtDate.Text);

            yoga.StartTime =
                TimeSpan.Parse(txtStartTime.Text);

            yoga.EndTime =
                TimeSpan.Parse(txtEndTime.Text);

            yoga.Teacher =
                txtTeacher.Text.Trim();

            yoga.MaxParticipant =
                Convert.ToInt32(txtMaxParticipant.Text);

            // Validasi
            if (yoga.EndTime <= yoga.StartTime)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "time",
                    "alert('Jam selesai harus lebih besar dari jam mulai.');",
                    true);
                return;
            }

            if (yoga.MaxParticipant < 1)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "quota",
                    "alert('Kuota peserta minimal 1 orang.');",
                    true);
                return;
            }

            if (Request.QueryString["id"] == null)
            {
                yogaRepo.Create(yoga);
            }
            else
            {
                yoga.ClassID =
                    Convert.ToInt32(
                    Request.QueryString["id"]);

                yogaRepo.Update(yoga);
            }

            Response.Redirect("~/Admin/YogaClasses.aspx");
        }
    }
}