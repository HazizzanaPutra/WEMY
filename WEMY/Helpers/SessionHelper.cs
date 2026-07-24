using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEMY.Models;

namespace WEMY.Helpers
{
    public class SessionHelper
    {
        public static void Login(User user)
        {
            HttpContext.Current.Session["UserID"] = user.UserID;
            HttpContext.Current.Session["FullName"] = user.FullName;
            HttpContext.Current.Session["Email"] = user.Email;

            HttpContext.Current.Session["RoleID"] = user.RoleID;
            HttpContext.Current.Session["RoleName"] = user.RoleName;
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }

        public static bool IsLogin()
        {
            return HttpContext.Current.Session["UserID"] != null;
        }

        public static string GetFullName()
        {
            if (HttpContext.Current.Session["FullName"] == null)
                return "";

            return HttpContext.Current.Session["FullName"].ToString();
        }

        public static int GetUserID()
        {
            if (HttpContext.Current.Session["UserID"] == null)
                return 0;

            return (int)HttpContext.Current.Session["UserID"];
        }

        public static string GetEmail()
        {
            if (HttpContext.Current.Session["Email"] == null)
                return "";

            return HttpContext.Current.Session["Email"].ToString();
        }

        public static int GetRoleID()
        {
            if (HttpContext.Current.Session["RoleID"] == null)
                return 0;

            return (int)HttpContext.Current.Session["RoleID"];
        }

        public static string GetRoleName()
        {
            if (HttpContext.Current.Session["RoleName"] == null)
                return "";

            return HttpContext.Current.Session["RoleName"].ToString();
        }

        public static bool IsAdmin()
        {
            return GetRoleID() == 1;
        }

        public static bool IsUser()
        {
            return GetRoleID() == 2;
        }

    }
}