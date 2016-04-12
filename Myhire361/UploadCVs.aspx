<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadCVs.aspx.cs" Inherits="UploadCVs" %>
<script runat="server">

   
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
       
    <style>
        #container {
            width: 720px;
            margin: 0 auto;
            padding: 15px;
        }

        #dragandrop {
            border: 2px dashed #92AAB0;
            width: 720px;
            height: 100px;
            color: #92AAB0;
            text-align: center;
            vertical-align: middle;
            padding: 10px 0px 10px 10px;
            font-size: 200%;
            display: table-cell;
        }

        .progressBar {
            width: 200px;
            height: 22px;
            border: 1px solid #ddd;
            border-radius: 5px;
            overflow: hidden;
            display: inline-block;
            margin: 0px 10px 5px 5px;
            vertical-align: top;
        }

            .progressBar div {
                height: 100%;
                color: #fff;
                text-align: center;
                line-height: 22px; /* same as #progressBar height if we want text middle aligned */
                width: 0;
                background-color: #0ba1b5;
                border-radius: 3px;
            }

        .statusbar {
            border-top: 1px solid #A9CCD1;
            min-height: 25px;
            width: 700px;
            padding: 10px 10px 0px 10px;
            vertical-align: top;
        }

            .statusbar:nth-child(odd) {
                background: #EBEFF0;
            }

        .filename {
            display: inline-block;
            vertical-align: top;
            width: 250px;
        }

        .filesize {
            display: inline-block;
            vertical-align: top;
            color: #30693D;
            width: 100px;
            margin-left: 10px;
            margin-right: 5px;
        }

        .cancel {
            background-color: #A8352F;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            display: inline-block;
            color: #fff;
            font-family: arial;
            font-size: 13px;
            font-weight: normal;
            padding: 4px 15px;
            cursor: pointer;
            vertical-align: top;
        }

        .status {
            display: none;
            padding: 5px;
            background: #F47063;
            width: 100%;
            color: white;
            margin: 8px 0;
        }
        .auto-style1 {
            width: 374px;
        }
    </style>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
        function sendFileToServer(formData, status) {
            var uploadURL = "FileUploadHandler.ashx"; //Upload URL
            var extraData = {}; //Extra Data.
            var jqXHR = $.ajax({
                xhr: function () {
                    var xhrobj = $.ajaxSettings.xhr();
                    if (xhrobj.upload) {
                        xhrobj.upload.addEventListener('progress', function (event) {
                            var percent = 0;
                            var position = event.loaded || event.position;
                            var total = event.total;
                            if (event.lengthComputable) {
                                percent = Math.ceil(position / total * 100);
                            }
                            //Set progress
                            status.setProgress(percent);
                        }, false);
                    }
                    return xhrobj;
                },
                url: uploadURL,
                type: "POST",
                contentType: false,
                processData: false,
                cache: false,
                data: formData,
                success: function (data, textStatus, jqXHR) {
                    status.setProgress(100);

                },
                complete: function (data, textStatus, jqXHR) {
                    $('.status').html(data.responseText).fadeIn().fadeOut(1600);

                }
            });

            status.setAbort(jqXHR);
        }

        var rowCount = 0;
        function createStatusbar(obj) {
            rowCount++;
            var row = "odd";
            if (rowCount % 2 == 0) row = "even";
            this.statusbar = $("<div class='statusbar " + row + "'></div>");
            this.filename = $("<div class='filename'></div>").appendTo(this.statusbar);
            this.size = $("<div class='filesize'></div>").appendTo(this.statusbar);
            this.progressBar = $("<div class='progressBar'><div></div></div>").appendTo(this.statusbar);
            this.abort = $("<div class='cancel'>cancel</div>").appendTo(this.statusbar);
            obj.after(this.statusbar);

            this.setFileNameSize = function (name, size) {
                var sizeStr = "";
                var sizeKB = size / 1024;
                if (parseInt(sizeKB) > 1024) {
                    var sizeMB = sizeKB / 1024;
                    sizeStr = sizeMB.toFixed(2) + " MB";
                }
                else {
                    sizeStr = sizeKB.toFixed(2) + " KB";
                }

                this.filename.html(name);
                this.size.html(sizeStr);
            }
            this.setProgress = function (progress) {
                var progressBarWidth = progress * this.progressBar.width() / 100;
                this.progressBar.find('div').animate({ width: progressBarWidth }, 10).html(progress + "%&nbsp;");
                if (parseInt(progress) >= 100) {
                    this.abort.hide();
                }
            }
            this.setAbort = function (jqxhr) {
                var sb = this.statusbar;
                this.abort.click(function () {
                    jqxhr.abort();
                    sb.hide();
                });
            }
        }
        function handleFileUpload(files, obj) {
            for (var i = 0; i < files.length; i++) {
                var fd = new FormData();
                fd.append('file', files[i]);

                var status = new createStatusbar(obj); //Using this we can set progress.
                status.setFileNameSize(files[i].name, files[i].size);
                sendFileToServer(fd, status);

            }
        }
        $(document).ready(function () {
            var obj = $("#dragandrop");
            obj.on('dragenter', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $(this).css('border', '2px solid #0B85A1');

            });
            obj.on('dragover', function (e) {
                e.stopPropagation();
                e.preventDefault();
            });
            obj.on('drop', function (e) {

                $(this).css('border', '2px dotted #0B85A1');
                e.preventDefault();
                var files = e.originalEvent.dataTransfer.files;

                //We need to send dropped files to Server
                handleFileUpload(files, obj);
            });
            $(document).on('dragenter', function (e) {
                e.stopPropagation();
                e.preventDefault();
            });
            $(document).on('dragover', function (e) {
                e.stopPropagation();
                e.preventDefault();
                obj.css('border', '2px dotted #0B85A1');
            });
            $(document).on('drop', function (e) {
                e.stopPropagation();
                e.preventDefault();
            });

        });
    </script>
    <script type="text/javascript" src="https://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js"></script>
			<script type="text/javascript">
			    $(document).ready(function () {
			        $("#Name").blur(function () {
			            alert("Focus lost");
			        });
			    });
			</script>



    <script runat="server">

   
</script>


  <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script src="jquery.MultiFile.js" type="text/javascript"></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
     <div id="page">
        <h2>
            Upload CVs </h2>
        <table width="80%" align="center">
           
          
            <tr>


                 <div style="color: #FF0000">
                     
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We accept resumes in PDF and Word Format We also accept candidates’  profiles from Naukri, XYZ, etc in Excel format
    <div id="container">
    <div class="status"></div>
        <div id="dragandrop">Drag & Drop Files Here </br>OR
       <tr style="width: auto">
    <td>
        </td>
           <td align="right">
               Upload CVs:    </td>
           
            <td align="left">
                <asp:FileUpload ID="file_upload" class="multi" runat="server" Width="272px" />
            
                </td>
                </tr>
            </div>
        
                </div>
               </div>
                 
               
            </tr>
            <tr>
                <td>
                    </td>
                <td>
                    </td>
            </tr> 
            <tr>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
            </tr>
            <tr>
                <td>
                    </td>
                <td>
                    </td>
            </tr> <tr>
                 <td>
                    </td>
                 <td align="center" valign="bottom" colspan="2">
                    <asp:Button ID="btn_Upload" runat="server" CssClass="btnCancel" OnClick="btn_Save_Click"
                        Text="Upload" />
               
                </td>
              
            </tr>
            <tr>
                <td align="center" colspan="4">
                   
                     <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblRid" runat="server" Visible="false"></asp:Label>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" 
                                        AllowPaging="false" Width="100%"  GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                        HeaderStyle-ForeColor="White">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <FooterStyle CssClass="footer" />
                                       <%-- <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No." SortExpression="Mobile_No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Id" SortExpression="Email" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </asp:Panel>
                                </td></tr>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                      
                 
                </td>
            </tr>
        </table>
    </div>


      
</asp:Content>

