using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;


public partial class RecMgmt_NewRRequest : BaseClass
{
    RecruitmentBAL ReqBAL;
    ClientBAL clientbal;
    AddressBAL addressbal;
    MasterBAL mstBal;
    static int RequestId, UserId,URole;
    WS_References Sr;
    public string filename;
    public string filename1;
    String fname, fpath;
    String spath;
    string fileExtention;
    static string file;
    static int RrNumber;
    int MyTimeSpan = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        URole = Convert.ToInt32(Session["UserRole"]);
        UserId = Convert.ToInt32(Session["UserId"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!IsPostBack)
        {
            
            BindClient();
            BindUser(UserId);
            BindLoaction();
            BindReportMngr();
            BindFunctionalArea();
            BindPreferdIndustry();
            BindIndustry();
            try
            {
                
                RequestId = Convert.ToInt32(Request.QueryString["Id"]);
                txtReceiveDate.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
               
            }
            catch (Exception ex)
            {
                RequestId = 0;
            }

            if (RequestId > 0)
            {
                BindRequest();
               
                btnsave.Text = "Update";
                lblHdr.Text = "Update";
                
            }
            else
            {
                lblHdr.Text = "New";
                ReqBAL = new RecruitmentBAL();
                try
                {
                   RrNumber = ReqBAL.SelectRRNumber();
                   
                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.ToString();
                }
                finally
                {
                    ReqBAL = null;
                }
            }
        }
    }

    #region  bindddls
    private void BindReportMngr()
    {
        LoginBAL Userbal = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select", "0");
            ddlReportMngr.Items.Clear();
            ddlReportMngr.Items.Add(lis);
            ddlReportMngr.DataSource = Userbal.FillUser();
            ddlReportMngr.DataTextField = "USR_Name";
            ddlReportMngr.DataValueField = "USR_ID";
            ddlReportMngr.DataBind();
        }
        finally
        {
            Userbal = null;
        }
    }
private void BindClient()
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            if (URole == 1)
            {
                ddlClientName.DataSource = clientbal.FillClient();
            }
            else if (URole == 9)
            {
                ddlClientName.DataSource = clientbal.FillClient();
            }
            else 
            {
                clientbal.UserId = UserId;
                ddlClientName.DataSource = clientbal.FillClientByUserId();
            }
           
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
private void BindLoaction()
    {
        addressbal = new AddressBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlLocation.Items.Clear();
            ddlLocation.Items.Add(li);
            ddlLocation.DataSource = addressbal.FillCity();
            ddlLocation.DataTextField = "City_Name";
            ddlLocation.DataValueField = "City_Id";
            ddlLocation.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
 private void BindUser(Int32 Id)
    {
        clientbal = new ClientBAL();
        try
        {
            clientbal.ClientId = Id;
            ddlRequest.Items.Clear();
            ddlRequest.DataSource = clientbal.FillClientContactById();
            ddlRequest.DataTextField = "Person_Name";
            ddlRequest.DataValueField = "Contact_PersonId";
            ddlRequest.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
    private void BindFunctionalArea()
    {
        mstBal = new MasterBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlFunctionalArea.Items.Clear();
            ddlFunctionalArea.Items.Add(li);
            ddlFunctionalArea.DataSource = mstBal.FillFunctionalArea();
            ddlFunctionalArea.DataTextField = "FunctAreaName";
            ddlFunctionalArea.DataValueField = "FunctAreaId";
            ddlFunctionalArea.DataBind();
        }
        finally
        {
            mstBal = null;
        }
    }
    private void BindPreferdIndustry()
    {
        mstBal = new MasterBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlPreferdIndustry.Items.Clear();
            ddlPreferdIndustry.Items.Add(li);
            ddlPreferdIndustry.DataSource = mstBal.FillIndustry();
            ddlPreferdIndustry.DataTextField = "IndustryName";
            ddlPreferdIndustry.DataValueField = "IndustryId";
            ddlPreferdIndustry.DataBind();
        }
        finally
        {
            mstBal = null;
        }
    }
    private void BindIndustry()
    {
        mstBal = new MasterBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlIndustry.Items.Clear();
            ddlIndustry.Items.Add(li);
            ddlIndustry.DataSource = mstBal.FillIndustry();
            ddlIndustry.DataTextField = "IndustryName";
            ddlIndustry.DataValueField = "IndustryId";
            ddlIndustry.DataBind();
        }
        finally
        {
            mstBal = null;
        }
    }
    #endregion

    protected void btnsave_Click(object sender, EventArgs e)
    {
        ReqBAL = new RecruitmentBAL();
        SendMail mail = new SendMail();

        try
        {
            if (fileUpload.HasFile)
            {

                fname = fileUpload.FileName;
                fpath = Server.MapPath("Files");
                fileExtention = System.IO.Path.GetExtension(fname);
                fpath = fpath + "\\" + fileUpload.FileName;
                string path = "";
                path = Server.MapPath(path);
                path = path.Replace("\\Recruitment", "\\Recruitment\\Files");
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                   

                    path = path + "\\" + (RrNumber) + fileExtention;

                    fileUpload.SaveAs(path);
                    path = path.Substring(path.IndexOf("\\Recruitment"));
                    ReqBAL.JobFile_Path = path;
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                ReqBAL.JobFile_Path = file;
            }

            ReqBAL.Request_Id = RequestId;
            ReqBAL.RRNumber = lblRRNo.Text;
                //RrNumber.ToString();
            ReqBAL.Job_Profile = txtJobProfile.Text;
            ReqBAL.Client_Id = Convert.ToInt32(ddlClientName.SelectedValue);
            ReqBAL.Total_Position = Convert.ToInt32(txtTotalPositions.Text);
            ReqBAL.Request_By = Convert.ToInt32(ddlRequest.SelectedValue);
            ReqBAL.Recieve_Date = txtReceiveDate.Text;
            ReqBAL.Closer_Date = txtTargetClosureDate.Text;
            ReqBAL.RprtingMngrId = Convert.ToInt32(ddlReportMngr.SelectedValue);
            ReqBAL.Criticality = Convert.ToInt32(rbCriticality.SelectedValue);
            ReqBAL.Designation = txtDesignation.Text;
            ReqBAL.Location_Id = Convert.ToInt32(ddlLocation.SelectedValue);
            if (txtMinSalary.Text == "")
            {
                
            }
            else
            {
                ReqBAL.Min_Salary = Convert.ToDouble(txtMinSalary.Text);
            }
            ReqBAL.Max_Salary = Convert.ToDouble(txtMaxSalary.Text);
            ReqBAL.Min_Experience = Convert.ToDouble(txtMinExperience.Text);
            ReqBAL.Max_Experience = Convert.ToDouble(txtMaxExperience.Text);
            ReqBAL.Min_Qualification = txtMinQualification.Text;
          
            ReqBAL.Request_Status = ddlRequestStatus.SelectedItem.Text;
            string requeststatus = ReqBAL.Request_Status;
            if (requeststatus == "Closed" || requeststatus == "Hold")
            {
                Sr = new WS_References();
                DataTable dt = new DataTable();
                ReqBAL.Request_Id = RequestId;
                ReqBAL.LoggedBy = UserId;
              //  ReqBAL.ReferrerPts = Convert.ToDouble(txtReferrerPts.Text.Trim());
                ReqBAL.PublishStatus = 0;
                if (URole == 1)
                {

                    ReqBAL.UpdateRRJobs_RefPoint();
                Sr.WS_H_RRDoNotPublish(ReqBAL.Request_Id, ReqBAL.LoggedBy);
                    //lblmsg.Text = "Sucessfully Un Published.!!";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;
                  
                }
                else if (URole == 9)
                {

                    ReqBAL.UpdateRRJobs_RefPoint();
                    try
                    { 
                    Sr.WS_H_RRDoNotPublish(ReqBAL.Request_Id, ReqBAL.LoggedBy);
                    }
                    catch 
                    { 
                    }
                    //lblmsg.Text = "Sucessfully Un Published.!!";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;

                }
            }
            //else if (requeststatus == "Open")
            //{
            //      ReqBAL.PublishStatus = 0;
            //}
            else
            {
                ReqBAL.PublishStatus = 0;
            }

            ReqBAL.RSkills = txtSkills.Text;
            ReqBAL.PositionType = Convert.ToInt32(ddlPositionType.SelectedValue.ToString());
            ReqBAL.JobDescription = txtJobDescription.Text.Trim();
            ReqBAL.LoggedBy = UserId;
            ReqBAL.FuntionalAreaId = Convert.ToInt32(ddlFunctionalArea.SelectedValue);
            ReqBAL.PIndustryId = Convert.ToInt32(ddlPreferdIndustry.SelectedValue);
            ReqBAL.IndustryId = Convert.ToInt32(ddlIndustry.SelectedValue);
          
            int Result = Convert.ToInt32(ReqBAL.InsertUpdateRRRequest());
            if (Result > 0)
            {
                DataTable dt = new DataTable();
                ReqBAL.Request_Id = Result;

                dt = ReqBAL.GetRREmail();
                if (dt.Rows.Count > 0)
                {
                    string ClientEmail = dt.Rows[0]["ClientEmail"].ToString();
                    string ApprovingEmail = dt.Rows[0]["ApprovingEmail"].ToString();
                    string DirectorEmail = "aseemgupta@skopeindia.com";
                    string Approver = dt.Rows[0]["ApprovingManager"].ToString();
                    string ClientName = dt.Rows[0]["Client_Name"].ToString();
                    string Designation = dt.Rows[0]["Designation"].ToString();
                    string Profile = dt.Rows[0]["Job_Profile"].ToString();
                  // mail.NewRRCreation(ClientEmail, ApprovingEmail, DirectorEmail, Approver, ClientName, Designation, Profile);
                }
                
                lblmsg.Text = "Record Saved successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("RRList.aspx");
            }
            else
            {
                lblmsg.Text = "Sorry! Record already exists.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            mail = null;
            ReqBAL = null;
        }
    }

    protected void btncncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("RRList.aspx");
    }   

    private void BindRequest()
    {
        ReqBAL = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            ReqBAL.Request_Id = RequestId;
            dt = ReqBAL.GetRequestById();
            txtJobProfile.Text = dt.Rows[0]["Job_Profile"].ToString();
            ddlClientName.SelectedValue = dt.Rows[0]["Client_Id"].ToString();
            txtTotalPositions.Text = dt.Rows[0]["Total_Position"].ToString();
            BindUser(Convert.ToInt32(dt.Rows[0]["Client_Id"]));
            ddlRequest.SelectedValue = dt.Rows[0]["Request_By"].ToString();
            txtReceiveDate.Text = dt.Rows[0]["Recieve_Date"].ToString();
            txtTargetClosureDate.Text = dt.Rows[0]["Closer_Date"].ToString();
            ddlReportMngr.SelectedValue = dt.Rows[0]["RRMngr_Id"].ToString();
            rbCriticality.SelectedValue = dt.Rows[0]["Criticality"].ToString();
            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            ddlLocation.SelectedValue = dt.Rows[0]["Location_Id"].ToString();
            txtMinSalary.Text = dt.Rows[0]["Min_Salary"].ToString();
            txtMaxSalary.Text = dt.Rows[0]["Max_Salary"].ToString();
            txtMinExperience.Text = dt.Rows[0]["Min_Experience"].ToString();
            txtMaxExperience.Text = dt.Rows[0]["Max_Experience"].ToString();
            txtMinQualification.Text = dt.Rows[0]["Min_Qualification"].ToString();
            txtSkills.Text = dt.Rows[0]["RSkills"].ToString();
            ddlRequestStatus.Items.FindByText(dt.Rows[0]["Request_Status"].ToString()).Selected = true;
            txtJobDescription.Text = dt.Rows[0]["JobDescription"].ToString();
            ddlPositionType.SelectedValue = dt.Rows[0]["PositionType"].ToString();
            ViewState["vRRNumber"] = dt.Rows[0]["RRNumber"].ToString();
            ddlFunctionalArea.SelectedValue = dt.Rows[0]["FuntionalAreaId"].ToString();
            ddlPreferdIndustry.SelectedValue = dt.Rows[0]["PIndustryId"].ToString();
            ddlIndustry.SelectedValue = dt.Rows[0]["IndustryId"].ToString();
            file = dt.Rows[0]["JobFile_Path"].ToString();
            trRRNo.Visible = true;
            lblRRNo.Text = dt.Rows[0]["RRNumber"].ToString();


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            clientbal = null;
        }
    }

    protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
    {
         clientbal = new ClientBAL();
        try
        {
            clientbal.ClientId = Convert.ToInt32(ddlClientName.SelectedValue);
            ListItem li = new ListItem("Select", "0");
            ddlRequest.Items.Clear();
            ddlRequest.Items.Add(li);
            ddlRequest.DataSource = clientbal.FillClientContactById();
            ddlRequest.DataTextField = "Person_Name";
            ddlRequest.DataValueField = "Contact_PersonId";
            ddlRequest.DataBind();
        }
        finally
        {
            clientbal = null;
        }
  
    }
    protected void chkPublish_CheckedChanged(object sender, EventArgs e)
    {
        

    }
   
}