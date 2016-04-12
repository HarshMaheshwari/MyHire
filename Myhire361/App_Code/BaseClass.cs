using System;
using System.Collections.Generic;
using System.Web;
using System.IO;


public class BaseClass : System.Web.UI.Page
{
    public BaseClass()
    {

    }
    protected override void OnPreInit(EventArgs e)
    {

        if (Session["UserId"] == null || Session["UserName"] == null || Session["UserRole"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["UserId"] == "0" || Session["UserName"] == "0" || Session["UserRole"] == "0")
        {
            Response.Redirect("~/Default.aspx");
        }
        base.OnPreInit(e);
    }
}
