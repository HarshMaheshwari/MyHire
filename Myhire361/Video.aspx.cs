using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


public partial class Video : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           // BindGrid();
        }
    }

    //private void BindGrid()
    //{
    //    string strConnString = ConfigurationManager.ConnectionStrings["AranyaProjectConnectionString"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(strConnString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.CommandText = "select Video_Id, VideoFile_Name from VideoFile";
    //            cmd.Connection = con;
    //            con.Open();
    //            DataList1.DataSource = cmd.ExecuteReader();
    //            DataList1.DataBind();
    //            con.Close();
    //        }
    //    }
    //}
    protected void btnFileUpld1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile )
        {
            string fileName = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/Files/" + fileName));
 
            using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);

                string strConnString = ConfigurationManager.ConnectionStrings["AranyaProjectConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "insert into VideoFile(VideoFile_Name, ContentType, Data) values (@VideoFile_Name,@ContentType, @Data)";
                        cmd.Parameters.AddWithValue("@VideoFile_Name", Path.GetFileName(FileUpload1.PostedFile.FileName));
                       // cmd.Parameters.AddWithValue("@Question","");
                        cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                       
                       
                      //  Response.Write("Your Video file successfully Uploaded..");
                    }
                }
            }
            lblf1.Visible = true;
            lblf1.Text = "Your Video file successfully Uploaded..";
        }
    }
    protected void btnFileUpld2_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile)
        {
            string fileName = FileUpload2.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/Files/" + fileName));

            using (BinaryReader br = new BinaryReader(FileUpload2.PostedFile.InputStream))
            {
                byte[] bytes = br.ReadBytes((int)FileUpload2.PostedFile.InputStream.Length);

                string strConnString = ConfigurationManager.ConnectionStrings["AranyaProjectConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "insert into VideoFile(VideoFile_Name, ContentType, Data) values (@VideoFile_Name,@ContentType, @Data)";
                        cmd.Parameters.AddWithValue("@VideoFile_Name", Path.GetFileName(FileUpload2.PostedFile.FileName));
                        // cmd.Parameters.AddWithValue("@Question","");
                        cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        //  Response.Write("Your Video file successfully Uploaded..");
                    }
                }
            }
            lblf2.Visible = true;
            lblf2.Text = "Your Video file successfully Uploaded..";
        }

    }
    protected void btnFileUpld3_Click(object sender, EventArgs e)
    {

        if (FileUpload3.HasFile)
        {
            string fileName = FileUpload3.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/Files/" + fileName));

            using (BinaryReader br = new BinaryReader(FileUpload3.PostedFile.InputStream))
            {
                byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);

                string strConnString = ConfigurationManager.ConnectionStrings["AranyaProjectConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "insert into VideoFile(VideoFile_Name, ContentType, Data) values (@VideoFile_Name,@ContentType, @Data)";
                        cmd.Parameters.AddWithValue("@VideoFile_Name", Path.GetFileName(FileUpload3.PostedFile.FileName));
                        // cmd.Parameters.AddWithValue("@Question","");
                        cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        //  Response.Write("Your Video file successfully Uploaded..");
                    }
                }
            }
            lblf0.Visible = true;
            lblf0.Text = "Your Video file successfully Uploaded..";
        }

    }
    protected void btnFileUpld4_Click(object sender, EventArgs e)
    {

        if (FileUpload4.HasFile)
        {
            string fileName = FileUpload4.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/Files/" + fileName));

            using (BinaryReader br = new BinaryReader(FileUpload4.PostedFile.InputStream))
            {
                byte[] bytes = br.ReadBytes((int)FileUpload4.PostedFile.InputStream.Length);

                string strConnString = ConfigurationManager.ConnectionStrings["AranyaProjectConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "insert into VideoFile(VideoFile_Name, ContentType, Data) values (@VideoFile_Name,@ContentType, @Data)";
                        cmd.Parameters.AddWithValue("@VideoFile_Name", Path.GetFileName(FileUpload4.PostedFile.FileName));
                        // cmd.Parameters.AddWithValue("@Question","");
                        cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        //  Response.Write("Your Video file successfully Uploaded..");
                    }
                }
            }
            lblf4.Visible = true;
            lblf4.Text = "Your Video file successfully Uploaded..";
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        lblmsg.Text = "Your Video files successfully Save..";
        Response.Redirect("PlayVideo.aspx");
    }
}