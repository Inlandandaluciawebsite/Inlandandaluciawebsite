<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminClientTour.ascx.vb" Inherits="WebUserControlAdminClientTour" %>
<asp:UpdatePanel ID="UpdatePanelAdminClientTour" runat="server" updatemode="Conditional">
    <ContentTemplate>     

        <asp:Table ID="TableTourHeader" runat="server" Width="100%" BorderStyle="None" 
            GridLines="Both" style="font-family: Calibri; font-weight: 700">

            <asp:TableRow>

                <asp:TableCell RowSpan="7" ColumnSpan="2" style="border:none">
                    <asp:Image ID="ImageIALogo" runat="server" ImageUrl="~/Images/Main/inlandandalucia.png" Width="177" Height="85" />
                </asp:TableCell>

                <asp:TableCell RowSpan="2">
                    Client Name(s)
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList ID="DropDownListBuyer" runat="server" AutoPostBack="true" Width="100%"></asp:DropDownList>
                </asp:TableCell>

                <asp:TableCell>
                    Viewing Date
                </asp:TableCell>

                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListViewDateDay" runat="server" AutoPostBack="true"></asp:DropDownList>
                    /
                    <asp:DropDownList ID="DropDownListViewDateMonth" runat="server" AutoPostBack="true"></asp:DropDownList>
                    /
                    <asp:DropDownList ID="DropDownListViewDateYear" runat="server" AutoPostBack="true"></asp:DropDownList>            
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow>
    
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="LabelClientName" runat="server"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    Meeting Time
                </asp:TableCell>

                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListMeetingTimeHour" runat="server" OnSelectedIndexChanged="MakeDirty"></asp:DropDownList>
                    :
                    <asp:DropDownList ID="DropDownListMeetingTimeMinute" runat="server" OnSelectedIndexChanged="MakeDirty"></asp:DropDownList>
                </asp:TableCell>
    
            </asp:TableRow>

            <asp:TableRow>
    
                <asp:TableCell RowSpan="2">
                    Sign Here
                </asp:TableCell>

                <asp:TableCell RowSpan="2" ColumnSpan="2">

                </asp:TableCell>

                <asp:TableCell>
                    Viewing Reference
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="LabelViewingReference" runat="server"></asp:Label>
                </asp:TableCell>
    
            </asp:TableRow>

            <asp:TableRow>

                <asp:TableCell>
                    Client Reference
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="LabelClientReference" runat="server"></asp:Label>
                </asp:TableCell>
    
            </asp:TableRow>


            <asp:TableRow>
    
                <asp:TableCell>
                    Contact Tel / Email
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                    <asp:Label ID="LabelContactTelEmail" runat="server"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    Number of Properties
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="LabelNoOfProperties" runat="server"></asp:Label>
                </asp:TableCell>
        
            </asp:TableRow>

            <asp:TableRow>

                <asp:TableCell>
                    Toured With
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList ID="DropDownListTouredWith" runat="server" Width="100%"></asp:DropDownList>
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2"></asp:TableCell>

            </asp:TableRow>

        </asp:Table>

        <br>

           <br />

        <asp:Table ID="TableTourBody" runat="server" Width="100%" BorderStyle="None" 
            GridLines="Both" style="font-family: Calibri; font-weight: 700">

            <asp:TableRow>
            
                <asp:TableCell HorizontalAlign="Center">
                    Ref.
                </asp:TableCell>
                 <asp:TableCell HorizontalAlign="Center">
                   Partner Ref.
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Center">
                    Name
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Center">
                    Address
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Center">
                    Town
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Center">
                    Contact No.
                </asp:TableCell>
            
                <asp:TableCell Width="70px" HorizontalAlign="Center">
                    Price
                </asp:TableCell>
            
                <asp:TableCell Width="100px" HorizontalAlign="Center">
                    Time
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Center">
                    Key
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference1" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner1" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName1" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress1" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown1" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo1" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice1" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour1" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator1" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute1" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>     
                    <asp:Label ID="LabelKey1" runat="server"></asp:Label> 
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference2" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
             <asp:TableCell>
                    <asp:Label ID="Labelpatner2" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                       
                    <asp:Label ID="LabelName2" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress2" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown2" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo2" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice2" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour2" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator2" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute2" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell> 
                    <asp:Label ID="LabelKey2" runat="server"></asp:Label>                    
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference3" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner3" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName3" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress3" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown3" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo3" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice3" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour3" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator3" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute3" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>          
                    <asp:Label ID="LabelKey3" runat="server"></asp:Label>           
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference4" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
               <asp:TableCell>
                    <asp:Label ID="Labelpatner4" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                     
                    <asp:Label ID="LabelName4" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress4" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown4" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo4" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice4" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour4" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator4" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute4" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>             
                    <asp:Label ID="LabelKey4" runat="server"></asp:Label>                  
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference5" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner5" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName5" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress5" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown5" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo5" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice5" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour5" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator5" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute5" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>      
                    <asp:Label ID="LabelKey5" runat="server"></asp:Label>                         
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference6" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner6" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName6" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress6" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown6" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo6" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice6" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour6" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator6" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute6" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>        
                    <asp:Label ID="LabelKey6" runat="server"></asp:Label>                       
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference7" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner7" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName7" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress7" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown7" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo7" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice7" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour7" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator7" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute7" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>      
                    <asp:Label ID="LabelKey7" runat="server"></asp:Label>                         
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference8" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner8" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName8" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress8" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown8" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo8" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice8" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour8" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator8" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute8" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>     
                    <asp:Label ID="LabelKey8" runat="server"></asp:Label>                          
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference9" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner9" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName9" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress9" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown9" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo9" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice9" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour9" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator9" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute9" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>        
                    <asp:Label ID="LabelKey9" runat="server"></asp:Label>                       
                </asp:TableCell>
            
            </asp:TableRow>

            <asp:TableRow>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListReference10" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Labelpatner10" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelName10" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelAddress10" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelTown10" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:Label ID="LabelContactNo10" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPrice10" runat="server"></asp:Label>
                </asp:TableCell>
            
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListTimeHour10" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                    <asp:Label ID="LabelTimeSeparator10" runat="server" Text=":" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DropDownListTimeMinute10" runat="server" Visible="false" OnSelectedIndexChanged="MakeDirty" Style="padding: 1px;"></asp:DropDownList>
                </asp:TableCell>
            
                <asp:TableCell>     
                    <asp:Label ID="LabelKey10" runat="server"></asp:Label>                          
                </asp:TableCell>
            
            </asp:TableRow>
        
        </asp:Table>

        <asp:Table ID="TableOptions" runat="server" Width="100%">
        
            <asp:TableRow>

                <asp:TableCell Width="70%"></asp:TableCell>

                <asp:TableCell Width="10%" HorizontalAlign="Right">
                    <asp:Button ID="ButtonFeedback" runat="server" Text="Feedback" Visible="false" CssClass="default-button"/>
                </asp:TableCell>

                <asp:TableCell Width="10%" HorizontalAlign="Right">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>
                </asp:TableCell>

                <asp:TableCell Width="10%" HorizontalAlign="Right">
                    <asp:Button ID="ButtonPrint" Text="Print" runat="server" Visible="false" OnClientClick="return redirectToPage('ClientTour.aspx');" CssClass="default-button"/>
                </asp:TableCell>
        
            </asp:TableRow>

            <asp:TableRow ID="TableRowSaved" runat="server" Visible="false">

                <asp:TableCell ColumnSpan="3" HorizontalAlign="Right">
                    <strong><asp:Label ID="LabelTourSaved" runat="server" Text="The Client Tour has been successfully Saved"></asp:Label></strong>
                </asp:TableCell>
        
            </asp:TableRow>
        
        </asp:Table>

    </ContentTemplate>

</asp:UpdatePanel>
