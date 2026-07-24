using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WEMY.Helpers
{
    public class AlertHelper
    {
        public static void Success(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(
                page,
                page.GetType(),
                "success",
                $"Swal.fire({{icon:'success',title:'Berhasil',text:'{message}'}});",
                true);
        }

        public static void Error(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(
                page,
                page.GetType(),
                "error",
                $"Swal.fire({{icon:'error',title:'Gagal',text:'{message}'}});",
                true);
        }

        public static void Warning(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(
                page,
                page.GetType(),
                "warning",
                $"Swal.fire({{icon:'warning',title:'Perhatian',text:'{message}'}});",
                true);
        }
    }
}