using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data;

public partial class UploadCVs : BaseClass
{
    RecruitmentBAL RecBAL;
    AddressBAL addressbal;
    MasterBAL mstBal;
    int UserId, RequestId, Candidate_Id, Result;
    public string filename;
    public string filename1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btn_Save_Click(object sender, EventArgs e)
    {


        RecBAL = new RecruitmentBAL();
        try
        {

            HttpFileCollection fileCollection = Request.Files;
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];
                string fileName = Path.GetFileName(uploadfile.FileName);
                if (uploadfile.ContentLength > 0)
                {
                    uploadfile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    RecBAL.Resume_Path = "Files/" + filename;
                    Result = Convert.ToInt32(RecBAL.UploadCandidate());
                    lblmsg.Text += fileName + " <br>  Saved Successfully<br>";
                }

                else
                {
                    Result = Convert.ToInt32(RecBAL.UploadCandidate());
                }
            }
        }
        catch (Exception ex)
              {
                  lblmsg.Text = ex.Message.ToString();
              }
         finally
              {
                    RecBAL = null;
             }
      
    
    }
    
}