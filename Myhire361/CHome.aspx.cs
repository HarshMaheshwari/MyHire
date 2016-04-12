using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CHome : BaseClass
{
    DashboardBAL dshBAL;
    static int Client_Id, User_Id,PollId,EmpId;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["ClientID"]) == 1004)
        {
            myflsh.Attributes["src"] = "slideshow.swf";


            img1.ImageUrl = "~/Gallery/Kamaayurveda1.png";
            img2.ImageUrl = "~/Gallery/Kamaayurveda2.png";
            img3.ImageUrl = "~/Gallery/Kamaayurveda3.png";
            img4.ImageUrl = "~/Gallery/Kamaayurveda4.png";
            img5.ImageUrl = "~/Gallery/Kamaayurveda5.png";
            img6.ImageUrl = "~/Gallery/Kamaayurveda6.png";
        }
        
        else if (Convert.ToInt32(Session["ClientID"]) == 1006)
        {
            myflsh.Attributes["src"] = "Reclineresslideshow.swf";

            
            img2.ImageUrl = "~/Gallery/recliner2.png";
            img3.ImageUrl = "~/Gallery/recliner3.png";
            img4.ImageUrl = "~/Gallery/recliners5.png";
           
           
        }
        else if (Convert.ToInt32(Session["ClientID"]) == 1003)
        {
            myflsh.Attributes["src"] = "tirupatimarketing.swf";
            img1.ImageUrl = "~/Gallery/tm1.png";
            img2.ImageUrl = "~/Gallery/tm2.png";
            img5.ImageUrl = "~/Gallery/tm5.png";
            img1.ImageUrl = "~/Gallery/tm1.png";
            img5.ImageUrl = "~/Gallery/tm5.png";
            img6.ImageUrl = "~/Gallery/tm6.png";
        }
        else if (Convert.ToInt32(Session["ClientID"]) == 1005)
        {

            img1.ImageUrl = "~/Gallery/ALK1.JPG";
            img2.ImageUrl = "~/Gallery/ALK2.JPG";
            img3.ImageUrl = "~/Gallery/ALK3.JPG";
            img4.ImageUrl = "~/Gallery/ALK4.JPG";
            img5.ImageUrl = "~/Gallery/ALK8.JPG";
            img6.ImageUrl = "~/Gallery/ALK7.JPG";
        }
        Client_Id = Convert.ToInt32(Session["ClientID"]);
        User_Id = Convert.ToInt32(Session["UsrId"]);
        if (Convert.ToInt32(Session["UsrRoles"]) != 1 || Convert.ToInt32(Session["UsrRoles"]) != 2)
        {
            EmpId = Convert.ToInt32(Session["EmpId"]);
        }
        if (!IsPostBack)
        {

            BindNews();
            // BindImportantDate();
            // BindTodaysBirthday();
            BindNewJoining();
            //BindPollQuestion();
            BindEmpSpeaks();
            BindChairmanMsg();
        }
        if (Convert.ToInt32(Session["ClientID"]) == 1004)
        {
            lblclientname.Text = "Kama Ayurveda";

            string a = "<span style='color:#948345', 'font-size: 15px','font-weight: bolder'>Kama Ayurveda</span> was started in 2002 in India. Four individuals who believed in" +
                " the virtues of a holistic life came together to promote the message of authentic Ayurveda," +
                " universally. Today, Kama’s high quality, authentic, beautifully packaged, beauty and wellness " +
                " products are sold globally and used by some of the world’s leading spas. Kama has received" +
                " extensive coverage and recognition in various international publications including US Vogue, French Vogue," +
                " Japan Vogue, Harpers Bazaar and Tatler. <br><br>";

            a = a + "Our philosophy emphasizes the harmony between the physical, mental and spiritual realms, the whole being."+
                    " According to Ayurveda, literally translated as the Knowledge of Life, the energies affecting the universe also operate on human physiology."+
                    "Broken links between the mind and the body must be restored and balanced in order to achieve health, contentment and peace. <br><br>";
              a=a+"<a href='https://www.kamaayurveda.com/'><span style='color: #7F6E30', 'weight:bold', 'text-decoration: none', 'font-family:Verdana,Geneva,sans-serif'> Read More..</span></a>";

            Lblsummary.Text = a;
        }
        //else if (Convert.ToInt32(Session["ClientID"]) == 1004)
        //{
        //    lblclientname.Text = "Skope";
        //    string a = " SK<span style='color: #DE0C0B'>O</span>PE</span> Offers specialist HR Services, Training & Development Programs and Affinity "+
        //    " Marketing solutions.Within these three business lines, SKOPE offers a range of services including recruitment, retention, HR outsourcing,"+
        //    " training and leadership development, and business development opportunities for companies through an affinity marketing model. <br><br> ";

        //    a = a + " SK<span style='color: #DE0C0B'>O</span>PE</span> is driven by the vision of its founders and the passion of its people to deliver to its clients," +
        //               " partners and people a differentiated experience. In this effort it is guided by" +
        //               " the values of PRIDE…<br><br>";
        //    a = a + "<a href='http://skopeindia.com/'><span style='color:#D71C25'>Read More..<img alt='' border='0' height='10' src='HomeImage/ReadMore.jpg' style='margin: 0px'" +
        //                         "'padding: 0px' width='15' /></span></span></a>";
        //    Lblsummary.Text = a;
        //}
        else if (Convert.ToInt32(Session["ClientID"]) == 1000)
        {
            lblclientname.Text = "Skope";
            string a = " SK<span style='color: #DE0C0B'>O</span>PE</span> Offers specialist HR Services, Training & Development Programs and Affinity " +
            " Marketing solutions.Within these three business lines, SKOPE offers a range of services including recruitment, retention, HR outsourcing," +
            " training and leadership development, and business development opportunities for companies through an affinity marketing model. <br><br> ";

            a = a + " SK<span style='color: #DE0C0B'>O</span>PE</span> is driven by the vision of its founders and the passion of its people to deliver to its clients,"+
                       " partners and people a differentiated experience. In this effort it is guided by" +
                       " the values of PRIDE… <br><br>";
            a = a + "<a href='http://skopeindia.com/'><span style='color:#D71C25'>Read More..<img alt='' border='0' height='10' src='HomeImage/ReadMore.jpg' style='margin: 0px'" +
                            "'padding: 0px' width='15' /></span></span></a>";
            Lblsummary.Text = a;

        }
        else if (Convert.ToInt32(Session["ClientID"]) == 1001)
        {
            lblclientname.Text = "Skope";
            string a = " SK<span style='color: #DE0C0B'>O</span>PE</span> Offers specialist HR Services, Training & Development Programs and Affinity " +
            " Marketing solutions.Within these three business lines, SKOPE offers a range of services including recruitment, retention, HR outsourcing," +
            " training and leadership development, and business development opportunities for companies through an affinity marketing model. <br><br> ";

            a = a + " SK<span style='color: #DE0C0B'>O</span>PE</span> is driven by the vision of its founders and the passion of its people to deliver to its clients," +
                       " partners and people a differentiated experience. In this effort it is guided by" +
                       " the values of PRIDE… <br><br>";
            a = a + "<a href='http://skopeindia.com/'><span style='color:#D71C25'>Read More..<img alt='' border='0' height='10' src='HomeImage/ReadMore.jpg' style='margin: 0px'" +
                                        "'padding: 0px' width='15' /></span></span></a>";
            Lblsummary.Text = a;
            

        }
         else if (Convert.ToInt32(Session["ClientID"])==1002)
        {
            lblclientname.Text = "Skope";
            string a = " SK<span style='color: #DE0C0B'>O</span>PE</span> Offers specialist HR Services, Training & Development Programs and Affinity " +
            " Marketing solutions.Within these three business lines, SKOPE offers a range of services including recruitment, retention, HR outsourcing," +
            " training and leadership development, and business development opportunities for companies through an affinity marketing model. <br><br> ";

            a = a + " SK<span style='color: #DE0C0B'>O</span>PE</span> is driven by the vision of its founders and the passion of its people to deliver to its clients," +
                       " partners and people a differentiated experience. In this effort it is guided by" +
                       " the values of PRIDE…<br><br>";
            a = a + "<a href='http://skopeindia.com/'><span style='color:#D71C25'>Read More..<img alt='' border='0' height='10' src='HomeImage/ReadMore.jpg' style='margin: 0px'" +
                            "'padding: 0px' width='15' /></span></span></a>";
            Lblsummary.Text = a;

        }
        else if (Convert.ToInt32(Session["ClientID"]) == 1003)
        {

            lblclientname.Text = "Tirupati Marketing";

            string a = "Established in the year 1998, we “Tirupati Marketing” are recognized among the affluent manufacturers," +
            "traders and suppliers of an assorted gamut of Supreme Crates & Bins, Supreme Injection Moulded Plastic Pallets," +
            "Custom Built, Plastic Crates and trading of Godrej Storage Solutions, Fami Shop Floor Solutions, Unoair Tools," +
                "Tirupati Make Pneumatic Accessories, Hydraulic Hoses, PP Stackable Crates, Alkon Plastic Products, " +
            "Alkon Office Products & OTTO Mobile Garbage Bins.<br><br>";

            a = a + "Our highly experienced and skilled professionals manufacture this entire product" +
            "range using optimum quality raw material, cutting-edge tools and advanced technology." +
            "At our production facility manufacturing processes of these products are carried out " +
            "in compliance with the international standards to ensure that the finished products are" +
            "flawless. Apart from this, our industry experts also hold specialization in customizing " +
                "these products as per the need of our clients. <br><br>";
            a = a + "<a href='http://www.tirupatimarketing.com/'><span style='color: #323131', 'weight:bold', 'text-decoration: none'> Read More..</span></a>";

            Lblsummary.Text = a;
        }
         else if (Convert.ToInt32(Session["ClientID"]) == 1005)
        {
            lblclientname.Text = "SKOPE India";
            string a = " SKOPE India Offers specialist HR Services, Training & Development Programs and Affinity " +
            " Marketing solutions.Within these three business lines, Alkemist offers a range of services including recruitment, retention, HR outsourcing," +
            " training and leadership development, and business development opportunities for companies through an affinity marketing model. <br><br> ";

            a = a + " SKOPE India is driven by the vision of its founders and the passion of its people to deliver to its clients," +
                       " partners and people a differentiated experience. In this effort it is guided by" +
                       " the values of PRIDE… <br><br>";
            a = a + "<a href='http://www.alkemist.org/'><span style='color:#b11018'>Read More..<img alt='' border='0' height='10' src='HomeImage/ReadMore.jpg' style='margin: 0px'" +
                            "'padding: 0px' width='15' /></span></span></a>";
            Lblsummary.Text = a;

        }

        else if (Convert.ToInt32(Session["ClientID"]) == 1006)
         {
            lblclientname.Text = "RECLINERS INDIA";
            string a = "We at Recliners India strive to achieve not just customer satisfaction but customer delight through our products."+ 
            "Our company aims to reach design standards previously unavailable in recliner chairs and provide our customers with a differentiated product."+
            "We do things differently! <br><br>"+
            "Every recliner we design is unique in itself. Look through our various designs to find that one recliner than makes you feel comfortable and at home!<br><br> ";

            a = a + "<a href='http://www.reclinersindia.com/'><span style='color: #444444','text-align: right', 'font-size: 12px', 'weight:bold','font-family:Helvetica,Arial,sans-serif'> Read More..</span></a>";
            Lblsummary.Text = a;

        }
        
       
    }

    private void BindChairmanMsg()
    {
        dshBAL = new DashboardBAL();
        dt = new DataTable();
        try
        {
            dshBAL.ClientId = Client_Id;
            string ChrManMsg = "";
            dt = dshBAL.GetCahirmanMsg();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChrManMsg = ChrManMsg + ("<p>"+dt.Rows[i]["ChrMessage"].ToString() +"</p>"+ "<BR>");
            }
            //lblMsg1.Text = ChrManMsg;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    private void BindEmpSpeaks()
    {
        dshBAL = new DashboardBAL();
        dt = new DataTable();
        try
        {
            dshBAL.ClientId = Client_Id;
           
            dt = dshBAL.GetEmployeeSpeaks();
            string EmpSpk = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                EmpSpk =EmpSpk+"<br/>" + "<p>" + dt.Rows[i]["Emp_Comment"].ToString() + "<br/><a>" + dt.Rows[i]["EmpName"].ToString() + "</a></p>";
                
               
               
            }
            lblEmpSpk.Text = EmpSpk;
            
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    //private void BindPollQuestion()
    //{
    //    dshBAL = new DashboardBAL();
    //    dt = new DataTable();
    //    try
    //    {
    //        dshBAL.ClientId = Client_Id;
    //        dt = dshBAL.GetPollQuestion();
    //        PollId = Convert.ToInt32(dt.Rows[0]["Poll_Id"]);
    //        lblPollQstn.Text = dt.Rows[0]["Poll_Question"].ToString();
    //        tbtnOption.Items.Add(dt.Rows[0]["Option_A"].ToString());
    //        tbtnOption.Items.Add(dt.Rows[0]["Option_B"].ToString());
    //        tbtnOption.Items.Add(dt.Rows[0]["Option_C"].ToString());
    //        tbtnOption.Items.Add(dt.Rows[0]["Option_D"].ToString());
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        dshBAL = null;
    //    }
    //}

    private void BindNewJoining()
    {
        dshBAL = new DashboardBAL();
        dt = new DataTable();
        try
        {
            dshBAL.ClientId = Client_Id;
            string NewJoin = "";
            dt = dshBAL.GetLatest5Joinings();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NewJoin =NewJoin+ ("<p><b>"+dt.Rows[i]["EmpName"].ToString()+"</b>"+ " joined on " + dt.Rows[i]["Emp_DOJ"].ToString() + " as " + dt.Rows[i]["Depart_Name"].ToString() + " in " + dt.Rows[i]["Desig_Name"].ToString() + "</p><BR>");
            }
            //lblNewJoining.Text = NewJoin;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    private void BindTodaysBirthday()
    {
        //dshBAL = new DashboardBAL();
        //dt = new DataTable();
        //try
        //{
        //    dshBAL.ClientId = Client_Id;
        //    string ImprtDate = "";
        //    dt = dshBAL.GetImportantDates();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ImprtDate = ImprtDate + (dt.Rows[i]["Emp_Comment"].ToString() + "<i>" + dt.Rows[i]["EmpName"].ToString() + "</i>" + "<BR>");
        //    }
        //    lblImpDate.Text = ImprtDate;
        //}
        //catch (Exception ex)
        //{

        //}
        //finally
        //{
        //    dshBAL = null;
        //}
    }

    private void BindImportantDate()
    {
        dshBAL = new DashboardBAL();
        dt = new DataTable();
        try
        {
            dshBAL.ClientId = Client_Id;
            string ImprtDate = "";
            dt = dshBAL.GetImportantDates();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ImprtDate = ImprtDate + ("<b>"+dt.Rows[i]["DOB"].ToString()+"</b>" + "   <i>" + dt.Rows[i]["EmpName"].ToString() + "</i>" + "<BR><BR>");
            }
            Label lblBirth = (Label)this.Master.FindControl("lblBirth");
            lblBirth.Text = ImprtDate;

        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    private void BindNews()
    {
        dshBAL = new DashboardBAL();
        dt = new DataTable();
        try
        {
            dshBAL.ClientId = Client_Id;
            string News = "";
            dt = dshBAL.GetImportantDates();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                News = News + (dt.Rows[i]["Emp_Comment"].ToString() + "<i>" + dt.Rows[i]["EmpName"].ToString() + "</i>" + "<BR>");
            }
           // lblNews.Text = News;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    
}