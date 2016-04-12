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


public partial class RecMgmt_UploadRRCandidate : BaseClass
{
    DataTable dt = new DataTable();
    RecruitmentBAL RecBAL;
    int RequestId, UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Request.QueryString["Id"]);
        Session["ReqstID"] = RequestId;
        lblRid.Text = RequestId.ToString();
        if (!Page.IsPostBack)
        {
            try
            {
               
            
            }
            catch (Exception ex)
            {
            }
            BindRequest();
            btn_Save.Visible = false;
        }
    }

    private void BindRequest()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            RecBAL.Request_Id = Convert.ToInt32(Session["ReqstID"]);
            dt = RecBAL.GetRequestById();
            lblRid.Text = dt.Rows[0]["Request_Id"].ToString();
            lblRRNumber.Text = dt.Rows[0]["RRNumber"].ToString();
            lblClient.Text = dt.Rows[0]["Client_Name"].ToString();         
            lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
            lblLocation.Text = dt.Rows[0]["City_Name"].ToString();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            RecBAL = null;
        }
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            HttpFileCollection uploads = HttpContext.Current.Request.Files;
            for (int i = 0; i < uploads.Count; i++)
            {
                HttpPostedFile upload = uploads[i];
                if (upload.ContentLength == 0)
                    continue;
                string c = System.IO.Path.GetFileName(upload.FileName);
                try
                {
                    upload.SaveAs(Server.MapPath("Files\\") + c);
                }
                catch (Exception Exp)
                {
                    throw (Exp);
                }
            }
            if (FileUpload1.PostedFile != null)
            {
                HttpPostedFile attFile = FileUpload1.PostedFile;
                int attachFileLength = attFile.ContentLength;
                if (attachFileLength > 0)
                {
                    if (FileUpload1.PostedFile.ContentLength > 0)
                    {
                        string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                        if (Extension == ".xls")
                        {

                            string inFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                            string pathDataSource = Server.MapPath("Files\\") + inFileName;
                            string conStr = "";
                            if (Extension == ".xls" || Extension == ".xlsx")
                            {
                                switch (Extension)
                                {
                                    case ".xls": //Excel 1997-2003   Provider=Microsoft.Jet.OLEDB.4.0;
                                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathDataSource + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                                        break;

                                    case ".xlsx": //Excel 2007  Provider=Microsoft.ACE.OLEDB.12.0;
                                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathDataSource + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                                        break;

                                    default:
                                        break;
                                }
                                try
                                {
                                    OleDbConnection connExcel = new OleDbConnection(conStr.ToString());
                                    OleDbCommand cmdExcel = new OleDbCommand();
                                    OleDbDataAdapter oda = new OleDbDataAdapter();
                                    connExcel.Open();
                                    DataTable dtExcelschema;

                                    dtExcelschema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    string SheetName = dtExcelschema.Rows[0]["Table_NAME"].ToString();

                                    DataSet ds = new DataSet();
                                    //Selecting Values from the first sheet 
                                    //Sheet name must be as Sheet1
                                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "]", conStr.ToString());
                                    da.Fill(ds);
                                    GridView1.DataSource = ds;
                                    GridView1.DataBind();
                                    Session["Table1"] = ds.Tables[0];
                                    if (GridView1.Columns.Count > 0)
                                    {
                                    }
                                    connExcel.Close();
                                    if (File.Exists(pathDataSource))
                                    {
                                        File.Delete(pathDataSource);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    lblmsg.Text = "Please rename the Excel sheet to Sheet1";
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Only excel sheet can be uploaded.";
                            }
                            //
                        }
                        else
                        {
                            lblmsg.Text = "Save the File in .xls";
                        }
                    }
                    else
                    {
                        FileUpload1.Focus();
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                    if (GridView1.Rows.Count > 0)
                    {
                        btn_Save.Visible = true;
                        btn_Upload.Visible = false;
                    }
                    else
                    {
                       lblmsg.Text = "Please Upload Again";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            RecBAL = new RecruitmentBAL();
            try
            {
               
                if (ddlFileForm.SelectedIndex == 1)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        string abc = GridView1.Rows[i].Cells[1].Text;
                        abc = abc.Replace("&nbsp;", "");
                        if (abc != "")
                        {
                            RecBAL.CandidateName = GridView1.Rows[i].Cells[1].Text;
                            RecBAL.ResumerId = GridView1.Rows[i].Cells[2].Text;
                            RecBAL.Address = GridView1.Rows[i].Cells[3].Text;
                            RecBAL.Telephone = GridView1.Rows[i].Cells[4].Text;
                            RecBAL.MobileNo = GridView1.Rows[i].Cells[5].Text;
                            RecBAL.Dob = GridView1.Rows[i].Cells[6].Text;
                            RecBAL.Email = GridView1.Rows[i].Cells[7].Text;
                            RecBAL.WorkExp = GridView1.Rows[i].Cells[8].Text;
                            RecBAL.Test = GridView1.Rows[i].Cells[9].Text;
                            RecBAL.ResumeTitle = GridView1.Rows[i].Cells[10].Text;
                            RecBAL.CurrentLocation = GridView1.Rows[i].Cells[11].Text;
                            RecBAL.PrefferedLocation = GridView1.Rows[i].Cells[12].Text;
                            RecBAL.CurrentEmployer = GridView1.Rows[i].Cells[13].Text;
                            RecBAL.CurrentDesignation = GridView1.Rows[i].Cells[14].Text;
                            RecBAL.AnnualSalary = GridView1.Rows[i].Cells[15].Text;
                            RecBAL.UgCourse = GridView1.Rows[i].Cells[16].Text;
                            RecBAL.PgCourse = GridView1.Rows[i].Cells[17].Text;
                            RecBAL.PostPgCourse = GridView1.Rows[i].Cells[18].Text;
                            RecBAL.LastActivationDate = GridView1.Rows[i].Cells[19].Text;
                            RecBAL.LoggedBy = UserId;
                            RecBAL.Request_Id = Convert.ToInt32(lblRid.Text);
                            RecBAL.Source = "naukri.com";
                            RecBAL.ConsultantId = UserId;
                            int Result = Convert.ToInt32(RecBAL.UploadCandidate());
                            //RecBAL.Refered=
                           // RecBAL.UpdateRRJobs_RefPoint(); 
                            if (Result == 1)
                            {

                                lblmsg.Text = "Uploaded Successfully..!";
                                dt.Clear();
                            }
                        }
                    }
                }
                // Upload file from Timesjob
                else if(ddlFileForm.SelectedIndex==2)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        string abc = GridView1.Rows[i].Cells[1].Text;
                        abc = abc.Replace("&nbsp;", "");
                        if (abc != "")
                        {
                            RecBAL.CandidateName = GridView1.Rows[i].Cells[0].Text;
                            RecBAL.Email = GridView1.Rows[i].Cells[1].Text;
                            RecBAL.Telephone = GridView1.Rows[i].Cells[2].Text;
                            RecBAL.Dob = GridView1.Rows[i].Cells[3].Text;
                            RecBAL.MobileNo = GridView1.Rows[i].Cells[4].Text;
                            RecBAL.Functional_Area = GridView1.Rows[i].Cells[5].Text;
                            RecBAL.Specialization_Area = GridView1.Rows[i].Cells[6].Text;
                            RecBAL.Industry = GridView1.Rows[i].Cells[7].Text;
                            RecBAL.ResumeTitle = GridView1.Rows[i].Cells[8].Text;
                            RecBAL.Key_Skills = GridView1.Rows[i].Cells[9].Text;
                            RecBAL.WorkExp = GridView1.Rows[i].Cells[10].Text;
                            RecBAL.CurrentEmployer = GridView1.Rows[i].Cells[11].Text;
                            RecBAL.Previous_Employer = GridView1.Rows[i].Cells[12].Text;
                            RecBAL.AnnualSalary = GridView1.Rows[i].Cells[13].Text;
                            RecBAL.Emp_Level = GridView1.Rows[i].Cells[14].Text;
                            RecBAL.CurrentLocation = GridView1.Rows[i].Cells[15].Text;
                            RecBAL.PrefferedLocation = GridView1.Rows[i].Cells[16].Text;
                            RecBAL.PgCourse = GridView1.Rows[i].Cells[17].Text;
                            RecBAL.Specialization_Education1 = GridView1.Rows[i].Cells[18].Text;
                            RecBAL.PG_Institute = GridView1.Rows[i].Cells[19].Text;
                            RecBAL.UgCourse = GridView1.Rows[i].Cells[20].Text;
                            RecBAL.Specialization_Education2 = GridView1.Rows[i].Cells[21].Text;
                            RecBAL.UG_Institute = GridView1.Rows[i].Cells[22].Text;
                            RecBAL.LastActivationDate = GridView1.Rows[i].Cells[23].Text;
                            RecBAL.Gender = GridView1.Rows[i].Cells[24].Text;
                            RecBAL.Age = GridView1.Rows[i].Cells[25].Text;
                            RecBAL.Address = GridView1.Rows[i].Cells[26].Text;
                            RecBAL.ResumerId = GridView1.Rows[i].Cells[27].Text;
                            RecBAL.CurrentDesignation = GridView1.Rows[i].Cells[28].Text;
                            RecBAL.LoggedBy = UserId;
                            RecBAL.Source = "timesjob.com";
                            RecBAL.Request_Id = Convert.ToInt32(Session["ReqstID"]);
                            RecBAL.ConsultantId = UserId;
                            int Result = Convert.ToInt32(RecBAL.UploadCandidate());
                            if (Result == 1)
                            {
                                lblmsg.Text = "Uploaded Successfully..!";
                                dt.Clear();
                            }
                        }
                    }
                }
                Session["Rid"] = RequestId;
                Response.Redirect("CandidateList.aspx");
            }
            
            finally
            {
                RecBAL = null;
            }
        }
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        if (Session["Flag"].ToString() == "0")
        {
            Response.Redirect("MyPosition.aspx");
        }
        else if (Session["Flag"].ToString() == "1")
        {
            Response.Redirect("RRList.aspx");
        }
    }
}
