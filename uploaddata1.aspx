<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="uploaddata1.aspx.vb" Inherits="uploaddata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:FileUpload ID="FlUploadcsv" runat="server" />
        <asp:Button ID="btnsubmit" runat="server" class="btn btn-default" Text="Upload" OnClick="btnsubmit_Click"  />
</asp:Content>

