using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Mail;


public partial class NewClient : BaseClass
{
    ClientBAL clientbal;
    AddressBAL addressbal;
    LoginBAL Userbal;
     int ClientId, UserId ;
     WS_References WSR;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        ClientId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            try
            {
             
                clientbal=new ClientBAL();
                txtCode.Text = "CC0"+(clientbal.GetClientNo()).ToString();
                txtCode.Enabled = false;
               
            }
            catch (Exception ex)
            {
                ClientId = 0;
            }
            BindLocation();
            BindConsultant();
            if (ClientId > 0)
            {
                BindClient();
                btnSave.Text = "Update";
                lblHdr.Text = "Update";
            }
            else
            {
                lblHdr.Text = "New";
            }
        }
    }

    private void BindLocation()
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
            addressbal = null;
        }
    }

    private void BindConsultant()
    {
        Userbal = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select","0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(lis);
            ddlConsultant.DataSource = Userbal.FillUser();
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();
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
            DataTable dt = new DataTable();
            clientbal.ClientId = ClientId;
            dt = clientbal.GetClientById();
            txtCode.Text = dt.Rows[0]["Client_Code"].ToString();
            txtClient.Text = dt.Rows[0]["Client_Name"].ToString();
            txtCntct.Text = dt.Rows[0]["Person_Name"].ToString();
            txtEmail.Text = dt.Rows[0]["Person_Email"].ToString();
            txtDob.Text = dt.Rows[0]["Person_Dob"].ToString();
            txtPhn.Text = dt.Rows[0]["Person_Contact"].ToString();
            ddlConsultant.SelectedValue = dt.Rows[0]["Usr_ID"].ToString();
            txtDoa.Text = dt.Rows[0]["Person_Anniversary"].ToString();
            txtWebsite.Text = dt.Rows[0]["Client_Website"].ToString();
            ddlLocation.SelectedValue = dt.Rows[0]["Client_City"].ToString();
            rbtnEmail.SelectedValue = dt.Rows[0]["Email_Alert"].ToString();
            rbtnSMS.SelectedValue = dt.Rows[0]["SMS_Alert"].ToString();
            txtClientSource.Text = dt.Rows[0]["ClientSource"].ToString();
            ViewState["Contact_PersonId"] = dt.Rows[0]["Contact_PersonId"].ToString();
            string PicPath =dt.Rows[0]["ClientHdrImg"].ToString();
            if (PicPath != "")
            {
                imgpic.ImageUrl = PicPath;
            }
            else
            {
                imgpic.ImageUrl = "~/Image/NoPreview.png";
            }
           string IHPicPath = dt.Rows[0]["IndiaHiringLogo"].ToString();
            if (IHPicPath != "")
            {
                ImgIHPick.ImageUrl = IHPicPath;
            }
            else
            {
                ImgIHPick.ImageUrl = "~/Image/NoPreview.png";
            }
         
        }
        finally
        {
            clientbal = null;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        clientbal = new ClientBAL();
        SendMail mail = new SendMail();
        WSR = new WS_References();
        try
        {
            clientbal.ClientId = ClientId;
            clientbal.Code = txtCode.Text;
            clientbal.Name = txtClient.Text;
            clientbal.PersonName = txtCntct.Text;
            clientbal.PersonEmail = txtEmail.Text;
            clientbal.PersonDob = txtDob.Text;
            clientbal.PersonContact = txtPhn.Text;
            clientbal.UserId = Convert.ToInt32(ddlConsultant.SelectedValue);
            clientbal.PersonAnnvrsry = txtDoa.Text;
            clientbal.Website = txtWebsite.Text;
            clientbal.CityId = Convert.ToInt32(ddlLocation.SelectedValue);
            clientbal.EmailAlert = Convert.ToInt32(rbtnEmail.SelectedValue);
            clientbal.SmsAlert = Convert.ToInt32(rbtnSMS.SelectedValue);
            clientbal.LoggedBy = UserId;
            clientbal.ClientSource = txtClientSource.Text.Trim();
           int result = clientbal.InsertUpdateClient();
            if (result > 0)
            {
               // WSR.WS_InsertUpdateClient(clientbal.ClientId, clientbal.Name, clientbal.Code, clientbal.CityId, clientbal.Website, clientbal.SmsAlert, clientbal.EmailAlert, clientbal.UserId, clientbal.ClientSource, UserId);
                DataTable dt = new DataTable();
                clientbal.ClientId = result;
               
                if (ClientLogo.PostedFile.FileName != "")
                {
                    string directoryPath = Server.MapPath("~/clientlogo");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    string filename = Path.GetFileName(ClientLogo.PostedFile.FileName);
                    clientbal.ClientHdrImg = "~/clientlogo" + "/" + result + "_" + filename;
                    ClientLogo.SaveAs(Server.MapPath("~/clientlogo" + "/" + result + "_" + filename));
                   
                }
                if (FUIndHiring.PostedFile.FileName != "")
                {
                    string directoryPath = Server.MapPath("~/ClientLogo");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    string filename = Path.GetFileName(FUIndHiring.PostedFile.FileName);
                    clientbal.IndiaHiringLogo = "~/ClientLogo" + "/" + result + "_IH_" + filename;
                    FUIndHiring.SaveAs(Server.MapPath("~/ClientLogo" + "/" + result + "_IH_" + filename));

                    //String strfile = "/ClientLogo" + "/" + result + "_IH_";
                    //FileInfo fileInf = new FileInfo(filename);
                    //string uri = "ftp://" + "www.indiahiring.org" + strfile + filename;
                    //FtpWebRequest reqFTP;
                    //try
                    //{
                    //    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + "www.indiahiring.org" + strfile + fileInf.Name));

                    //    reqFTP.Credentials = new NetworkCredential("clientlogo", "Tech#321");

                    //    reqFTP.KeepAlive = false;
                    //    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                    //    reqFTP.UseBinary = true;
                    //    FUIndHiring.SaveAs(Server.MapPath("ftp://" + "www.indiahiring.org" + strfile + filename));
                    //}
                    //catch (Exception ex) { }
                    //finally { }
                }
                try
                {
                    clientbal.Upd_ClientLogo();
                }
                catch (Exception EX)
                { }
              
                clientbal.IsAdmin = 1;
                if (btnSave.Text == "Update")
                {
                    clientbal.PersonId = Convert.ToInt32(ViewState["Contact_PersonId"]);
                }
                else
                {
                    clientbal.PersonId = 0;
                }
               
               clientbal.InsertUpdateContactPerson();
          //      WSR.WS_InsertUpdateContactPerson(clientbal.PersonId, clientbal.ClientId, clientbal.PersonName, clientbal.PersonContact, clientbal.PersonEmail, clientbal.PersonDob, clientbal.PersonAnnvrsry, clientbal.IsAdmin, clientbal.LoggedBy);
                dt = clientbal.GetClientEmail();
                string ClientEmail = dt.Rows[0]["ClientEmail"].ToString();
                string Manager = dt.Rows[0]["Manager"].ToString();
                string DirectorEmail = "aseemgupta@skopeindia.com";
                string ClientName = dt.Rows[0]["Client_Name"].ToString();
            //  mail.NewClient(ClientEmail, DirectorEmail, Manager, ClientName);
               Response.Redirect("~/ClientList.aspx");
            }
        }
        finally
        {
            
            mail = null;
            clientbal = null;
        }
    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ClientList.aspx");
    }


  
}