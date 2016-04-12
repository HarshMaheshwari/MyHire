 <%@ WebHandler Language="C#" Class="FileUploadHandler" %>
 
using System;
using System.Web;
 
public class FileUploadHandler : IHttpHandler{

    int Result;
    RecruitmentBAL RecBAL;
    string FileName = string.Empty;
    public void ProcessRequest (HttpContext context) {
        if (context.Request.Files.Count > 0)
        {
            RecBAL = new RecruitmentBAL();
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                FileName = file.FileName;
              string fname = context.Server.MapPath("~/uploads/" + file.FileName);
              RecBAL.Resume_Path = "uploads/" + file.FileName;
              Result = Convert.ToInt32(RecBAL.UploadCandidate());
                file.SaveAs(fname);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(FileName + " Uploaded Successfully!");
        }
 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
 
}

