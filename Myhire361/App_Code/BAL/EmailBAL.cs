using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmailDALTableAdapters;
using System.Data;

public class EmailBAL
{
    EmailTemplateTableAdapter Mail;
    ContactUsTableAdapter Contct;

    private int _EmailTemplateId;
    private string _TriggerPoint;
    private string _ToAddress;
    private string _ToCC;
    private string _ToBCC;
    private string _EmailSubject;
    private string _EmailBody;
    private string _EmailSignature;


    public int EmailTemplateId
    {
        get { return _EmailTemplateId; }
        set { _EmailTemplateId = value; }
    }
    public string TriggerPoint
    {
        get { return _TriggerPoint; }
        set { _TriggerPoint = value; }
    }
    public string ToAddress
    {
        get { return _ToAddress; }
        set { _ToAddress = value; }
    }
    public string ToCC
    {
        get { return _ToCC; }
        set { _ToCC = value; }
    }
    public string ToBCC
    {
        get { return _ToBCC; }
        set { _ToBCC = value; }
    }
    public string EmailSubject
    {
        get { return _EmailSubject; }
        set { _EmailSubject = value; }
    }
    public string EmailBody
    {
        get { return _EmailBody; }
        set { _EmailBody = value; }
    }
    public string EmailSignature
    {
        get { return _EmailSignature; }
        set { _EmailSignature = value; }
    }

    public DataTable GetEmailTemplateByTrigger()
    {
        Mail = new EmailTemplateTableAdapter();
        try
        {
            return Mail.GetEmailTemplateByTrigger(_TriggerPoint);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            Mail = null;
        }
    }



    #region---------------------------Contct--------------------------

    private int _Contact_Us_id;
    private string _Contact_mail;
    private string _Contact_body;
    private string _Contact_Person;
    private string _Source;

    public int Contact_Us_id
    {
        get { return _Contact_Us_id; }
        set { _Contact_Us_id = value; }
    }
    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }
    public string Contact_mail
    {
        get { return _Contact_mail; }
        set { _Contact_mail = value; }
    }
    public string Contact_body
    {
        get { return _Contact_body; }
        set { _Contact_body = value; }
    }
    public string Contact_Person
    {
        get { return _Contact_Person; }
        set { _Contact_Person = value; }
    }

    public int InserContactUs()
    {
        Contct = new ContactUsTableAdapter();
        try
        {
            return Convert.ToInt32(Contct.InserContactUs(_Contact_mail, _Contact_body, _Contact_Person, _Source));
        }
        finally
        {
            Contct = null;
        }
    }

    #endregion

}