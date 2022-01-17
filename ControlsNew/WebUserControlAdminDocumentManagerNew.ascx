<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminDocumentManagerNew.ascx.vb" Inherits="WebUserControlAdminDocumentManager" %>
<div ID="TableDocuments" runat="server">
    <div class="row" ID="TableRowFolderOptions" runat="server" >
       <div class="col-md-12" >
                           <div class="d">
                               <div class="f">                                      
                                   <asp:Button ID="ButtonNewFolder" runat="server" Text="New Folder" Enabled="false" CssClass="btn green"/>
</div>
                               <div class="f">
 <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Enabled="false" CssClass="btn green"/>
                               </div>
                                 <div class="f">
 <asp:Button ID="ButtonRename" runat="server" Text="Rename" Enabled="false" CssClass="btn green"/>
                        </div>
                                 <div class="f">
 <asp:Button ID="btnMove" runat="server" Text="Move" Enabled="false" CssClass="btn green"/>                                           

                        </div>
                                 <div class="f sd">
  <asp:FileUpload ID="FileUploadFile" runat="server" Enabled="false"/>
                                           

                        </div>
                               <div class="f">
    <asp:Button ID="ButtonUpload" runat="server" Text="Upload" Enabled="false" CssClass="btn green"/>
                                           

                        </div>
                               <div class="f">
 <asp:Button ID="ButtonDownload" runat="server" Text="Download" Enabled="false" CssClass="btn green"/>
                                           

                        </div>
                               <div class="f">

<asp:Button ID="ButtonEmail" runat="server" Text="Email" Enabled="false" CssClass="btn green"/>

                                           

                        </div>

                               </div>

                         
                           </div>

    </div>
 <div class="row">
                           <div>&nbsp</div>
                       </div>
<div class="row" id="TableRowUpdate" runat="server" Visible="false">
    <div class="col-md-3"> <asp:Label ID="LabelUpdate" runat="server"></asp:Label></div>
    <div class="col-md-3"> <asp:TextBox ID="TextBoxName" CssClass="form-control"  runat="server" AutoCompleteType="None"></asp:TextBox></div>
    <div class="col-md-3"> <asp:Label ID="LabelFileExtension" runat="server"></asp:Label></div>
    <div class="col-md-3">   <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn green"/></div>
</div>
                       <div class="row"  id="TableRowMove" runat="server" Visible="false">
<div class="col-md-6">
    <asp:HiddenField ID="hdsource" runat="server"  Value="0"/>
                    <asp:Label ID="lblsourcefile" runat="server" style="display:none"></asp:Label>
                <asp:Label ID="lblMove" runat="server" Text=""></asp:Label>
</div>
                           <div class="col-md-6"> 
                                <asp:Button ID="ButtonMoveYes" runat="server" Text="Yes" CssClass="btn green"/>
                                <asp:Button ID="ButtonMoveNo" runat="server" Text="No" CssClass="btn green"/>
                           </div>
                         
                       </div>

                        <div class="row"  id="TableRowDelete" runat="server" Visible="false">
<div class="col-md-6">
     <asp:Label ID="LabelDelete" runat="server"></asp:Label>
</div>
                           <div class="col-md-6">  
                               <asp:Button ID="ButtonDeleteYes" runat="server" Text="Yes" CssClass="btn green"/>
                                <asp:Button ID="ButtonDeleteNo" runat="server" Text="No" CssClass="btn green"/>
                           </div>
                           
                       </div>

                        <div class="row">
                           <div>&nbsp</div>
                       </div>
                       <div class="row"  >
                           <div class="col-md-12">
                                               <asp:TreeView ID="TreeViewBrowser" runat="server" Font-Names="Calibri" Font-Size="11" ForeColor="Black" SelectedNodeStyle-BackColor="Silver" BorderColor="Silver" BorderStyle="None">
 </asp:TreeView>
                           </div>
                       </div>
                        <div class="row" id="TableRowEmailSent" runat="server" Visible="false">
                           <div class="col-md-12">
      The email has been sent successfully 
                            
                           </div>
                       </div>
                        <div class="row" id="TableRowFileLimitExceeded" runat="server" Visible="false">
                           <div class="col-md-12">
                                              The file selected exceeds the maximum file size limit of 3MB
                           </div>
                       </div>
</div>


<br />

 <div id="TableEmailDocument" runat="server" Visible="false">
      <div class="form-body" >
                                       
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">To:</label>
                                                    <div class="col-md-9">
                                                      <asp:TextBox ID="TextBoxEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                          
                                        </div>
         
                                        <div class="row" id="TableRowProvideEmailAddress" runat="server">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3"></label>
                                                     <div class="col-md-9">
                                                        <strong >Please provide an email address</strong>
                                                         </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                           
                                            <!--/span-->
                                        </div>
          <div class="row">
                <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Subject: </label>
                                                    <div class="col-md-9">
                                                       <asp:TextBox ID="TextBoxEmailSubject" runat="server"  CssClass="form-control" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
          </div>

           <div class="row">
              <div class="col-md-6">
                  <div class="form-group">
                       <label class="control-label col-md-3"></label>
                      <div class="col-md-9">
                       <asp:TextBox ID="TextBoxEmailMessage" runat="server" CssClass="form-control"  TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
                 </div> </div>
              </div>
               
          </div>
          <div class="row">
               <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Attachment</label><asp:Label ID="LabelAttachment" runat="server"></asp:Label>
                                                    <div class="col-md-9">
                                                         <asp:Label ID="LabelAttachmentFullPath" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
          </div>
                                        <!--/row-->
             <div class="row" id="TableCellEmailFailed" runat="server" Visible="false" >
                                            <div class="col-md-12">
                                              <strong>Email sending failed. Please check the email address is valid.</strong>  
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                    </div>
     <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                           <asp:Button ID="ButtonSend" runat="server" Text="Send" CssClass="btn green"/> 
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn green"/>        </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                            </div>
                                        </div>
                                    </div>
 </div>
