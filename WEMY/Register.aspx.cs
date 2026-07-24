using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using WEMY.Database;
using WEMY.Models;

namespace WEMY
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirm.Text)
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "alert",
                    "alert('Konfirmasi password tidak sama!');",
                    true);

                return;
            }

            UserRepository repo = new UserRepository();

            if (repo.EmailExists(txtEmail.Text))
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "alert",
                    "alert('Email sudah terdaftar!');",
                    true);

                return;
            }

            User user = new User();

            user.FullName = txtNama.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;

            repo.Register(user);

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "alert",
                "alert('Registrasi berhasil!');window.location='Default.aspx';",
                true);
        }
    }
}