<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayCandidateVideo.aspx.cs" Inherits="Recruitment_PlayCandidateVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Record Candidate Video</title>
    <meta name="description" content="" />
    <script src="Flash/js/swfobject.js"></script>
    <style>
        html, body
        {
            height: 480px;
            width:800px;
            overflow: hidden;
            margin: auto;
        }
    </style>
</head>
<body>
    <div style="height: 100%">
        <div id="altContent">
            <h1>
                Record Video</h1>
            <p>
                <a href="http://www.adobe.com/go/getflashplayer">Get Adobe Flash player</a></p>
        </div>
      
    </div>
    <script>

        var flashvars = {};



        if (swfobject.getQueryParamValue("videoname")) {

            flashvars.videoname = swfobject.getQueryParamValue("videoname");

        }



       


    





        var params = {

            menu: "false",

            scale: "noScale",

            allowFullscreen: "true",

            allowScriptAccess: "always",

            bgcolor: "",

            wmode: "window" // can cause issues with FP settings & webcam

        };

        var attributes = {

            id: "OXStudent"

        };

        swfobject.embedSWF(

                                                "Flash/OXSmartHireVideoPlay_v02.swf",

                                                "altContent", "100%", "100%", "11.0.0",

                                                "Flash/expressInstall.swf",

                                                flashvars, params, attributes);

        swfobject.createCSS("#altContent", "display:block;text-align:left;");

    </script>
</body>
</html>
