using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Recruitment_UploadVideo : System.Web.UI.Page
{
    int CandidateId, RRCandidateId;
    string VideoName;
    VideoBAL VideoBal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CandidateId = Convert.ToInt32(Request.QueryString["CId"].ToString());
            RRCandidateId = Convert.ToInt32(Request.QueryString["RRId"].ToString());
            VideoName = Request.QueryString["videoname"].ToString();
            SaveVideo();
        }
    }
    protected void SaveVideo()
    {
        VideoBal = new VideoBAL();
        try
        {
            VideoBal.Candidate_Id = CandidateId;
            VideoBal.RRCandidate_Id = RRCandidateId;
            VideoBal.Video_Name = VideoName;
            VideoBal.InsertCandidateVideo();
        }
        catch (Exception e)
        {

        }
        finally
        {
            VideoBal = null;
        }
    }
}