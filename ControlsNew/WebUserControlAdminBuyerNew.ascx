<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminBuyerNew.ascx.vb" Inherits="WebUserControlAdminBuyerNew" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminPossibleDuplicates.ascx" TagName="AdminPossibleDuplicates" TagPrefix="ucAdminPossibleDuplicates" %>
<asp:UpdatePanel ID="UpdatePanelAdminBuyer" runat="server" UpdateMode="Conditional">

    <ContentTemplate>

        <h1>
            <asp:Label ID="LabelBuyer" runat="server" Text="Client"></asp:Label><asp:Button ID="btnAction" runat="server" Text="ACTION" Style="margin-left: 49px;" Visible="false" CssClass="btn green" PostBackUrl="~/AdminNew/BuyerActionAgenda.aspx" />
            <asp:Button ID="btnClintHistory" runat="server" Text="CLIENT HISTORY" Style="margin-left: 49px;" CssClass="btn green" PostBackUrl="~/AdminNew/ClientHistory.aspx" Visible="false" />
        </h1>

       
               <div class="form-body" ID="TableBuyer" runat="server" >
                                <h3 class="form-section"></h3>
                      <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Forename:</label>
                                            <div class="col-md-9">
 <asp:TextBox ID="TextBoxForename" runat="server" MaxLength="30"  CssClass="form-control"   disabled="true" ></asp:TextBox>                                         </div>
                                        </div>
                                    </div>
                          <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> </label>
                                            <div class="col-md-9">
   <asp:Button ID="ButtonCreateTour" runat="server" Text="Create Tour" Visible="false" CssClass="btn green" disabled="true" />                                        </div>
                                        </div>
                                    </div>
                          </div>
              <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Surname:</label>
                                            <div class="col-md-9">
  <asp:TextBox ID="TextBoxSurname" runat="server" MaxLength="30"  CssClass="form-control" disabled="true"></asp:TextBox>                                        </div>
                                        </div>
                                    </div>
                  </div>

           <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Passport No.:</label>
                                            <div class="col-md-9">
   <asp:TextBox ID="TextBoxPassportNo" runat="server" MaxLength="10" CssClass="form-control"  disabled="true"></asp:TextBox>                                      </div>
                                        </div>
                                    </div>
                  </div>

                    <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Address:</label>
                                            <div class="col-md-9">
 <asp:TextBox ID="TextBoxAddress" runat="server" MaxLength="250"  Rows="3" TextMode="MultiLine" CssClass="form-control" disabled="true"></asp:TextBox>                                  </div>
                                        </div>
                                    </div>
                  </div>
          

                     <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Contact Name:</label>
                                            <div class="col-md-9">
  <asp:TextBox ID="TextBoxContactName" runat="server" MaxLength="30" CssClass="form-control" disabled="true" ></asp:TextBox>                                  </div>
                                        </div>
                                    </div>
                  </div>
          
            

             <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Telephone:</label>
                                            <div class="col-md-9">
   <asp:TextBox ID="TextBoxTelephone" runat="server" MaxLength="15"  CssClass="form-control" disabled="true"></asp:TextBox>                                  </div>
                                        </div>
                                    </div>
                  </div>

       
                     <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Email:</label>
                                            <div class="col-md-9">
    <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="30"  CssClass="form-control"  disabled="true"></asp:TextBox>                                </div>
                                        </div>
                                    </div>
                  </div>

              <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Notes:</label>
                                            <div class="col-md-9">
      <asp:TextBox ID="TextBoxNotes" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="10" CssClass="form-control" disabled="true" ></asp:TextBox>                              </div>
                                        </div>
                                    </div>
                  </div>


                     <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">  Partner:</label>
                                            <div class="col-md-9">
   <asp:DropDownList ID="DropDownListPartner" runat="server" AutoPostBack="true" Enabled="false" CssClass="form-control" disabled="true"></asp:DropDownList>                            </div>
                                        </div>
                                    </div>
                  </div>
           

          
                   <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Agent:</label>
                                            <div class="col-md-9">
      <asp:DropDownList ID="DropDownListAgent" runat="server" CssClass="form-control" disabled="true"></asp:DropDownList>                           </div>
                                        </div>
                                    </div>
                  </div>

         

                   
                   <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Language:</label>
                                            <div class="col-md-9">
      <asp:DropDownList ID="DropDownListLanguage" runat="server" CssClass="form-control" disabled="true"></asp:DropDownList>                         </div>
                                        </div>
                                    </div>
                  </div>

         

           <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Budget:</label>
                                            <div class="col-md-9">
  <asp:TextBox ID="TextBoxBudget" runat="server"  MaxLength="7" CssClass="form-control" disabled="true"></asp:TextBox> €                    </div>
                                        </div>
                                    </div>
                  </div>

           
                        <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">  Source:</label>
                                            <div class="col-md-9">
   <asp:DropDownList ID="DropDownListSource" runat="server" AutoPostBack="true" CssClass="form-control" disabled="true"></asp:DropDownList>                  </div>
                                        </div>
                                    </div>
                  </div>
           
                    <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"> Status:</label>
                                            <div class="col-md-9">
    <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true" CssClass="form-control" disabled="true"></asp:DropDownList>                </div>
                                        </div>
                                    </div>
                  </div>

             <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Archived:</label>
                                            <div class="col-md-9"> 
    <asp:CheckBox ID="CheckBoxArchived" runat="server" AutoPostBack="true" disabled="true"  />               </div>
                                        </div>
                                    </div>
                  </div>

            <div class="row" ID="TableRowPossibleDuplicates" runat="server" Visible="false">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Did you perhaps mean...</label>
                                            <div class="col-md-9">
 <ucAdminPossibleDuplicates:AdminPossibleDuplicates ID="AdminPossibleDuplicates" runat="server" />            </div>
                                        </div>
                                    </div>
                  </div>

           <div class="form-actions" ID="TableRowSave" runat="server">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-offset-3 col-md-9">
                                           
                                                <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="btn green" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6" ID="TableRowSaved" runat="server" Visible="false">
                                      <strong>   <asp:Label ID="LabelSaved" runat="server" Text="Buyer Successfully Saved"></asp:Label></strong>
                                    </div>
                                </div>
                            </div>

           
      </div>
    </ContentTemplate>

</asp:UpdatePanel>
