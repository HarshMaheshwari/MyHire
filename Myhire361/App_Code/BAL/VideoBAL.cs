using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VideoDALTableAdapters;

public class VideoBAL
{
    CandidateVideoTableAdapter Video;

    private int _CandidateVideo_Id;
    private int _Candidate_Id;
    private int _RRCandidate_Id;
    private string _Video_Name;
    private int _Status;
    private int _LoggedBy;

    public int CandidateVideo_Id
    {
        get { return _CandidateVideo_Id; }
        set { _CandidateVideo_Id = value; }
    }
    public int Candidate_Id
    {
        get { return _Candidate_Id; }
        set { _Candidate_Id = value; }
    }
    public int RRCandidate_Id
    {
        get { return _RRCandidate_Id; }
        set { _RRCandidate_Id = value; }
    }
    public string Video_Name
    {
        get { return _Video_Name; }
        set { _Video_Name = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }

    public int InsertCandidateVideo()
    {
        Video = new CandidateVideoTableAdapter();
        try
        {
            return Convert.ToInt32(Video.InsertCandidateVideo(_CandidateVideo_Id, _Candidate_Id, _RRCandidate_Id, _Video_Name, _LoggedBy));
        }
        finally
        {
            Video = null;
        }
    }

    public DataTable GetVideoByCandidateId()
    {
        Video = new CandidateVideoTableAdapter();
        try
        {
            return Video.GetVideoByCandidateId(_Candidate_Id);
        }
        finally
        {
            Video = null;
        }
    }

    public DataTable GetVideoByRRCandidateId()
    {
        Video = new CandidateVideoTableAdapter();
        try
        {
            return Video.GetVideoByRRCandidateId(_Candidate_Id, _RRCandidate_Id);
        }
        finally
        {
            Video = null;
        }
    }
	public VideoBAL()
	{
		
	}
}