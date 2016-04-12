using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
public partial class ClientList : BaseClass
{
    ClientBAL clntBAL;
     int UserId,URole;
    RecruitmentBAL recruitbal;
     FollowUpBAL FollowBal;
     LoginBAL Userbal;
     Search srch;
     DataTable dt = new DataTable();
     public string filename;
     String fname, fpath, fileExtention;
     static string file;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            BindClient();
            BindClientList();
            if (URole > 1)
            {
                btnNew.Visible = false;

            }
            else
            {
                btnNew.Visible = true;
            }

           
        }
    }
  

    private void BindClient()
    {
        clntBAL = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clntBAL.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clntBAL = null;
        }
    }

    private void BindClientList()
    {
        DataView dv = new DataView();
        clntBAL = new ClientBAL();
        try
        {
            if (URole == 1)
            {
               

                dv.Table = clntBAL.GetClient();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClient.DataSource = dv;
                gdvClient.DataBind();
            }
            else
            {
                clntBAL.UserId = UserId;
              
                dv.Table = clntBAL.GetClientByUserId();
                if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClient.DataSource = dv;

                gdvClient.DataBind();
            }
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            clntBAL = null;
        }
    }

    protected void gdvClient_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindClientList();
    }
    protected void gdvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvClient.PageIndex = e.NewPageIndex;
        BindClientList();
    }

    protected void gdvClient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgbtnActive = (ImageButton)e.Row.FindControl("imgbtnActivate");
            ImageButton imgbtnInActive = (ImageButton)e.Row.FindControl("imgbtnInActivate");
          
            Label lbl = (Label)e.Row.FindControl("lblStatus");
     
            ImageButton lbtnEdit = (ImageButton)e.Row.FindControl("lbtnEdit");
            LinkButton lbtnContract = (LinkButton)e.Row.FindControl("lbtnContract");
            if (URole >1)
            {
                lbtnEdit.Visible = false;
                lbtnContract.Visible = false;
                
            }
           
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                lbl.Text = "Active";
                imgbtnInActive.Visible = false;
                imgbtnActive.Visible = true;

            }
            else
            {
                lbl.Text = "Inactive";
                imgbtnInActive.Visible = true;
                imgbtnActive.Visible = false;
            }
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NewClient.aspx");
    }
    
    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        clntBAL = new ClientBAL();
        ImageButton imgbtn = sender as ImageButton;
        GridViewRow row = imgbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvClient.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvClient.Rows[row.RowIndex].FindControl("lblStatus")).Text;
        clntBAL.ClientId = Id;
        clntBAL.LoggedBy = UserId;
        if (Status == "Active")
        {
            clntBAL.Status = 0;
            clntBAL.ChangeClientStatus();
        }
        else
        {
            clntBAL.Status = 1;
            clntBAL.ChangeClientStatus();
        }


        BindClientList();
    }
   
    protected void gdvClient_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "NewClient.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "NewRR")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "~/Recruitment/NewRRequest.aspx";
            Response.Redirect(url);
        }
        else if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "ViewClient.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Contact")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "ClientContact.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Address")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "ClientAddress.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Contract")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "ClientContract.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Documents")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            hdnClientId.Value = ((Label)gvr.FindControl("lblId")).Text;
            GetDocType(ddlDocType);
            BindClientHeaderDoc();
            GetClientDocuments();
            MPEDoc.Show();
        }
        else if (e.CommandName == "Departments")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            hdnClientIdDep.Value = ((Label)gvr.FindControl("lblId")).Text;
            GetClientContact(ddlCLContact);
            BindPortfolio(ddlPortfolio);
            BindTeamLead(ddlTeamLead);
            BindClientHeaderDep();
            GetClientDepartment();
            MPEDep.Show();
        }
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        recruitbal = new RecruitmentBAL();
        DataView dv = new DataView();
        try
        {
            dv.Table = SearchClient();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvClient.DataSource = dv;
            gdvClient.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            recruitbal = null;
        }
    }
    public DataTable SearchClient()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("  SELECT  Cd.Client_Name, Cd.Client_Code, Ctd.City_Code, Ctd.City_Name, Cd.Client_City, ");
        sb.Append("  Cd.Client_Website, ud.USR_Name, Cd.SMS_Alert, Cd.Email_Alert, Cd.Status, Cd.Client_Id ");
        sb.Append("  , Ccp.Person_Name,Ccp.Person_Contact, Ccp.Person_Email, Ccp.Person_Dob, Ccp.Person_Anniversary ,Cd.ClientSource ");
        sb.Append(" FROM ClientDetail As Cd INNER JOIN UserDetail as ud on cd.USR_ID=ud.USR_ID ");
        sb.Append(" left join CityDetail As Ctd ON Cd.Client_City = Ctd.City_Id ");
        sb.Append(" left JOIN ClientContactPerson As Ccp ON Cd.Client_Id = Ccp.Client_Id ");
        sb.Append(" where Ccp.IsAdmin=1 ");
         if (ddlClientName.SelectedIndex > 0)
        {
            sb.Append(" and Cd.Client_Name = '" + ddlClientName.SelectedItem.Text + "'");
        }
         if (txtContactName.Text != "")
         {
             sb.Append("and Ccp.Person_Name like '%" + txtContactName.Text + "%'");
         }
         if (txtMobile.Text != "")
         {
             sb.Append("and Ccp.Person_Contact like '%" + txtMobile.Text + "%'");
         }

        if (txtConsultantAss.Text != "")
        {
            sb.Append("and ud.USR_Name like '%" + txtConsultantAss.Text + "%'");
        }
       
        sb.Append(" order by Cd.Client_Name");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    #region    Client Documents

    protected void BindClientHeaderDoc()
    {
        clntBAL = new ClientBAL();
        try
        {
            DataTable dt = new DataTable();
            int ClientId = Convert.ToInt32(hdnClientId.Value);
            clntBAL.ClientId = ClientId;
            dt = clntBAL.GetClientById();
            if (dt.Rows.Count > 0)
            {
                lblClientNm.Text = dt.Rows[0]["Client_Name"].ToString();
                lblAssignTo.Text = dt.Rows[0]["Usr_Name"].ToString();
                lblContactName.Text = dt.Rows[0]["Person_Name"].ToString();
                lblContactNo.Text = dt.Rows[0]["Person_Contact"].ToString();
            }
        }
        finally
        {
            clntBAL = null;
        }
    }
    private void GetDocType(DropDownList ddlDocType)
    {
        clntBAL = new ClientBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlDocType.Items.Clear();
            ddlDocType.Items.Add(li);
            ddlDocType.DataSource = clntBAL.GetDocType();
            ddlDocType.DataTextField = "DocTypeName";
            ddlDocType.DataValueField = "DocTypeId";
            ddlDocType.DataBind();
        }
        finally
        {
            clntBAL = null;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        clntBAL = new ClientBAL();
        int ClientId = Convert.ToInt32(hdnClientId.Value);
        clntBAL.ClientId = ClientId;
        try
        {
            if (DocFile.PostedFile.FileName != "")
            {
                string directoryPath = Server.MapPath("~/DocFiles" );
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filename = Path.GetFileName(DocFile.PostedFile.FileName);
                string Extension = Path.GetExtension(filename);
                Extension = Extension.ToLower();
                if (Extension == ".doc" || Extension == ".docx" || Extension == ".pdf" || Extension == ".jpg" || Extension == ".jpeg" || Extension == ".xlsx" || Extension == ".txt")
                {
                   
                    clntBAL.DocFile =ClientId+"_"+ filename;
                    clntBAL.DocumentNm = txtDocumentNm.Text;
                    clntBAL.DocTypeId = Convert.ToInt32(ddlDocType.SelectedValue);
                    clntBAL.LoggedBy = UserId;
                   int Result= clntBAL.IU_ClientDocuments();
                   if (Result == 1)
                   {
                       DocFile.SaveAs(Server.MapPath("~/DocFiles" + "/" + ClientId + "_" + filename));
                       GetClientDocuments();
                       lblMsgd.Text = "Record Saved successfully.";
                       lblMsgd.ForeColor = System.Drawing.Color.Green;

                   }
                   else
                   {
                       lblMsgd.Text = "Already Exists.!";
                       lblMsgd.ForeColor = System.Drawing.Color.Red;
                   
                   }

                }
                else
                {
                    lblMsgd.Text = "Invalid file.!";
                    lblMsgd.ForeColor = System.Drawing.Color.Red;
                }
            }
            //else
            //{
            //   clntBAL.DocFile = ViewState["Document_Path"].ToString();
            //}

        }
        catch (Exception ex)
        {
            lblMsgd.Text = ex + "";

        }


        finally
        {
            clntBAL = null;
            txtDocumentNm.Text = "";
            ddlDocType.SelectedIndex = 0;
            MPEDoc.Show();

        }
    }
    
    protected void GetClientDocuments()
    { 
        clntBAL=new ClientBAL();
        int ClientId = Convert.ToInt32(hdnClientId.Value);
        clntBAL.ClientId = ClientId;
        gdvDocs.DataSource = clntBAL.GetClientDocuments();
        gdvDocs.DataBind();
    }

    private void BindPortfolio(DropDownList ddlPortfolio)
    {
        Userbal = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select", "0");
            ddlPortfolio.Items.Clear();
            ddlPortfolio.Items.Add(lis);
            ddlPortfolio.DataSource = Userbal.FillUser();
            ddlPortfolio.DataTextField = "USR_Name";
            ddlPortfolio.DataValueField = "USR_ID";
            ddlPortfolio.DataBind();
        }
        finally
        {
            Userbal = null;
        }
    }
    private void BindTeamLead(DropDownList ddlTeamLead)
    {
        Userbal = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select", "0");
            ddlTeamLead.Items.Clear();
            ddlTeamLead.Items.Add(lis);
            ddlTeamLead.DataSource = Userbal.FillTeamLead();
            ddlTeamLead.DataTextField = "USR_Name";
            ddlTeamLead.DataValueField = "USR_ID";
            ddlTeamLead.DataBind();
        }
        finally
        {
            Userbal = null;
        }
    }

    protected void gdvDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMsgd.Text = "";
        gdvDocs.PageIndex = e.NewPageIndex;
        GetClientDocuments();
        MPEDoc.Show();
    }

    protected void gdvDocs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvDocs.EditIndex = -1;
        GetClientDocuments();
        MPEDoc.Show();
    }

    protected void gdvDocs_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblmsg.Text = "";
        clntBAL = new ClientBAL(); 
        GridViewRow gvr = gdvDocs.Rows[e.RowIndex];
        try
        {
            
            int ClientId = Convert.ToInt32(hdnClientId.Value);
            clntBAL.ClientId = ClientId;
            FileUpload DocFile = ((FileUpload)gvr.FindControl("EDocFile"));

            if (DocFile.PostedFile.FileName != "")
            {
                string directoryPath = Server.MapPath("~/DocFiles");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filename = Path.GetFileName(DocFile.PostedFile.FileName);
                string Extension = Path.GetExtension(filename);
                Extension = Extension.ToLower();
                if (Extension == ".doc" || Extension == ".docx" || Extension == ".pdf" || Extension == ".jpg" || Extension == ".jpeg" || Extension == ".xlsx" || Extension == ".txt")
                {

                    clntBAL.DocFile = ClientId + "_" + filename;
                    clntBAL.DocId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
                    clntBAL.LoggedBy = UserId;
                    clntBAL.DocumentNm = ((TextBox)gvr.FindControl("txtDocNm")).Text;
                    clntBAL.DocTypeId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEDocType")).SelectedValue);

                    int Result = clntBAL.IU_ClientDocuments();
                    if (Result == 1)
                    {
                        DocFile.SaveAs(Server.MapPath("~/DocFiles" + "/" + ClientId + "_" + filename));
                        lblMsgd.Text = "Record Updated successfully.";
                        lblMsgd.ForeColor = System.Drawing.Color.Green;

                    }
                }
                else
                {
                    lblMsgd.Text = "Invalid file.!";
                    lblMsgd.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                clntBAL.DocFile = ((Label)gvr.FindControl("lblEAttachDoc")).Text;
                clntBAL.DocFile = ClientId + "_" + filename;
                clntBAL.DocId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
                clntBAL.LoggedBy = UserId;
                clntBAL.DocumentNm = ((TextBox)gvr.FindControl("txtDocNm")).Text;
                clntBAL.DocTypeId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEDocType")).SelectedValue);
               int Result = clntBAL.IU_ClientDocuments();
                if (Result == 1)
                {
                    DocFile.SaveAs(Server.MapPath("~/DocFiles" + "/" + ClientId + "_" + filename));
                    lblMsgd.Text = "Record Updated successfully.";
                    lblMsgd.ForeColor = System.Drawing.Color.Green;
                }

            }

            gdvDocs.EditIndex = -1;
            GetClientDocuments();
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            clntBAL = null;
            MPEDoc.Show();
        }
    }

    protected void gdvDocs_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvDocs.EditIndex = e.NewEditIndex;
        GetClientDocuments();
        MPEDoc.Show();
    }

    protected void gdvDocs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {

            Label lbl = (Label)e.Row.FindControl("lblDEStatus");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                lbl.Text = "Active";
            }
            else
            {
                lbl.Text = "Inactive";
            }
            Label lblEDocType = ((Label)e.Row.FindControl("lblEDocType"));
            DropDownList ddlEDocType = ((DropDownList)e.Row.FindControl("ddlEDocType"));
            GetDocType(ddlEDocType);
            ddlEDocType.SelectedValue = lblEDocType.Text;

          
        }
      
        else  if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgbtnActive = (ImageButton)e.Row.FindControl("imgbtnDActivate");
            ImageButton imgbtnInActive = (ImageButton)e.Row.FindControl("imgbtnDInActivate");

            Label lbl2 = (Label)e.Row.FindControl("lblDStatus");
            if (Convert.ToInt32(lbl2.Text) == 1)
            {
                lbl2.Text = "Active";
                imgbtnInActive.Visible = false;
                imgbtnActive.Visible = true;

            }
            else
            {
                lbl2.Text = "Inactive";
                imgbtnInActive.Visible = true;
                imgbtnActive.Visible = false;
            }
        }

        MPEDoc.Show();
    }

    protected void imgbtnD_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        clntBAL = new ClientBAL();
        ImageButton imgbtnD_Activate = sender as ImageButton;
        GridViewRow row = imgbtnD_Activate.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvDocs.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvDocs.Rows[row.RowIndex].FindControl("lblDStatus")).Text;
        clntBAL.DocId = Id;
        int ClientId = Convert.ToInt32(hdnClientId.Value);
        clntBAL.ClientId = ClientId;
        clntBAL.LoggedBy = UserId;
        if (Status == "Active")
        {
            clntBAL.Status = 0;
            clntBAL.Change_ClientDocumentsStatus();
        }
        else
        {
            clntBAL.Status = 1;
            clntBAL.Change_ClientDocumentsStatus();
        }
        GetClientDocuments();
        MPEDoc.Show();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MPEDoc.Hide();
    }

    #endregion  


    #region    Client Departments

    protected void BindClientHeaderDep()
    {
        clntBAL = new ClientBAL();
        try
        {
            DataTable dt = new DataTable();
            int ClientId = Convert.ToInt32(hdnClientIdDep.Value);
            clntBAL.ClientId = ClientId;
            dt = clntBAL.GetClientById();
            if (dt.Rows.Count > 0)
            {
                lblClientNm2.Text = dt.Rows[0]["Client_Name"].ToString();
                lblAssignTo2.Text = dt.Rows[0]["Usr_Name"].ToString();
                lblContactName2.Text = dt.Rows[0]["Person_Name"].ToString();
                lblContactNo2.Text = dt.Rows[0]["Person_Contact"].ToString();
            }

        }
        finally
        {
            clntBAL = null;
        }
    }
    private void GetClientContact(DropDownList ddlCLContact)
    {
        clntBAL = new ClientBAL();
        try
        {
            int ClientId = Convert.ToInt32(hdnClientIdDep.Value);
            clntBAL.ClientId = ClientId;
            ListItem li = new ListItem("Select", "0");
            ddlCLContact.Items.Clear();
            ddlCLContact.Items.Add(li);
            ddlCLContact.DataSource = clntBAL.GetClientContactForDDL();
            ddlCLContact.DataTextField = "Person_Name";
            ddlCLContact.DataValueField = "Contact_PersonId";
            ddlCLContact.DataBind();
        }
        finally
        {
            clntBAL = null;
        }
    }

    protected void btnSaveDp_Click(object sender, EventArgs e)
    {
        clntBAL = new ClientBAL();
        int ClientId = Convert.ToInt32(hdnClientIdDep.Value);
        clntBAL.ClientId = ClientId;
        try
        {

            clntBAL.DepartmentCode= txtDepCode.Text;
            clntBAL.DepartmentName = txtDepartNm.Text;
            clntBAL.ContactId = Convert.ToInt32(ddlCLContact.SelectedValue);
            clntBAL.PortfolioMgrId = Convert.ToInt32(ddlPortfolio.SelectedValue);
            clntBAL.TeamLeadMgrId = Convert.ToInt32(ddlTeamLead.SelectedValue);
            clntBAL.LoggedBy = UserId;
            int Result = clntBAL.IU_ClientDepartment();
            if (Result == 1)
            {

                GetClientDepartment();
                lblMsgdp.Text = "Record Saved successfully.";
                lblMsgdp.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblMsgdp.Text = "Already Exists.!";
                lblMsgdp.ForeColor = System.Drawing.Color.Red;

            }

        }
        catch (Exception ex)
        {
            lblMsgdp.Text = ex + "";

        }


        finally
        {
            clntBAL = null;
            txtDepCode.Text = "";
            txtDepartNm.Text = "";
            ddlCLContact.SelectedIndex = 0;
            ddlPortfolio.SelectedIndex = 0;
            ddlTeamLead.SelectedIndex = 0;
            MPEDep.Show();

        }
    }

    protected void GetClientDepartment()
    {
        clntBAL = new ClientBAL();
        int ClientId = Convert.ToInt32(hdnClientIdDep.Value);
        clntBAL.ClientId = ClientId;
        gdvDP.DataSource = clntBAL.GetClientDepartment();
        gdvDP.DataBind();
    }

    protected void gdvDP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMsgdp.Text = "";
        gdvDP.PageIndex = e.NewPageIndex;
        GetClientDepartment();
        MPEDep.Show();
    }

    protected void gdvDP_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblMsgdp.Text = "";
        gdvDP.EditIndex = -1;
        GetClientDepartment();
        MPEDep.Show();
    }

    protected void gdvDP_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblMsgdp.Text = "";
        clntBAL = new ClientBAL();
        GridViewRow gvr = gdvDP.Rows[e.RowIndex];
        try
        {

            int ClientId = Convert.ToInt32(hdnClientIdDep.Value);
            clntBAL.ClientId = ClientId;
            clntBAL.DepId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            clntBAL.DepartmentCode = ((TextBox)gvr.FindControl("txtEDepCode")).Text;
            clntBAL.DepartmentName = ((TextBox)gvr.FindControl("txtEDepNm")).Text;
            clntBAL.ContactId =Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEContactId")).SelectedValue);
            clntBAL.PortfolioMgrId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEPortfolioId")).SelectedValue);
            clntBAL.TeamLeadMgrId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlETeamLeadId")).SelectedValue);
            clntBAL.LoggedBy = UserId;
            int Result = clntBAL.IU_ClientDepartment();
            if (Result == 1)
            {
                GetClientDepartment();
                lblMsgdp.Text = "Record Updated successfully.";
                lblMsgdp.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblMsgdp.Text = "Already Exists.!";
                lblMsgdp.ForeColor = System.Drawing.Color.Red;

            }
           

            

            gdvDP.EditIndex = -1;
            GetClientDepartment();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            clntBAL = null;
            MPEDep.Show();
        }
    }

    protected void gdvDP_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblMsgdp.Text= "";
        gdvDP.EditIndex = e.NewEditIndex;
        GetClientDepartment();
        MPEDep.Show();
    }

    protected void gdvDP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {

            Label lbl = (Label)e.Row.FindControl("lblDPEStatus");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                lbl.Text = "Active";
            }
            else
            {
                lbl.Text = "Inactive";
            }
            Label lblEContactId = ((Label)e.Row.FindControl("lblEContactId"));
            DropDownList ddlEContactId = ((DropDownList)e.Row.FindControl("ddlEContactId"));
            GetClientContact(ddlEContactId);
            ddlEContactId.SelectedValue = lblEContactId.Text;

            Label lblEPortfolioId = ((Label)e.Row.FindControl("lblEPortfolioId"));
            DropDownList ddlEPortfolioId = ((DropDownList)e.Row.FindControl("ddlEPortfolioId"));
            BindPortfolio(ddlEPortfolioId);
            ddlEPortfolioId.SelectedValue = lblEPortfolioId.Text;
            Label lblETeamLeadId = ((Label)e.Row.FindControl("lblETeamLeadId"));
            DropDownList ddlETeamLeadId = ((DropDownList)e.Row.FindControl("ddlETeamLeadId"));
            BindTeamLead(ddlETeamLeadId);
            ddlETeamLeadId.SelectedValue = lblETeamLeadId.Text;

        }

        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgbtnActive = (ImageButton)e.Row.FindControl("imgbtnDActivateDP");
            ImageButton imgbtnInActive = (ImageButton)e.Row.FindControl("imgbtnDInActivateDP");

            Label lbl2 = (Label)e.Row.FindControl("lblDPStatus");
            if (Convert.ToInt32(lbl2.Text) == 1)
            {
                lbl2.Text = "Active";
                imgbtnInActive.Visible = false;
                imgbtnActive.Visible = true;

            }
            else
            {
                lbl2.Text = "Inactive";
                imgbtnInActive.Visible = true;
                imgbtnActive.Visible = false;
            }
        }

        MPEDep.Show();
    }

    protected void imgbtnD_ActivateDP_Click(object sender, EventArgs e)
    {
        lblMsgdp.Text = "";
        clntBAL = new ClientBAL();
        ImageButton imgbtnD_Activate = sender as ImageButton;
        GridViewRow row = imgbtnD_Activate.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvDP.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvDP.Rows[row.RowIndex].FindControl("lblDPStatus")).Text;
        clntBAL.DepId = Id;
        int ClientId = Convert.ToInt32(hdnClientIdDep.Value);
        clntBAL.ClientId = ClientId;
        clntBAL.LoggedBy = UserId;
        if (Status == "Active")
        {
            clntBAL.Status = 0;
            clntBAL.Change_ClientDepartmentStatus();
            lblMsgdp.Text = "Record Deactivated successfully.";
            lblMsgdp.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            clntBAL.Status = 1;
            clntBAL.Change_ClientDepartmentStatus();
            lblMsgdp.Text = "Record Activated successfully.";
            lblMsgdp.ForeColor = System.Drawing.Color.Green;
        }
        GetClientDepartment();
        MPEDep.Show();
    }

    protected void btnCanceldp_Click(object sender, EventArgs e)
    {
        lblMsgdp.Text = "";
        MPEDep.Hide();
        
    }

    #endregion  

}