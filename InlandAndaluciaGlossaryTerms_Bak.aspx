<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="InlandAndaluciaGlossaryTerms_Bak.aspx.vb" Inherits="InlandAndaluciaGlossaryTerms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main Content Area Start -->

    <!-- Left Portion Start -->
    <div class="col-md-8 col-sm-7">
        <!-- View trip listing Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="view-trip-listing">
                    <a name="top"></a>
                    <h1>   <asp:Literal ID="Literal1" Text="<%$Resources:Resource, InlandAndaluciaGlossaryTermsBuying%>" runat="server"></asp:Literal>
</h1>


                    <div class="glossary-of-terms">

                        <p>
                            <br>
                             <asp:Literal ID="Literal2" Text="<%$Resources:Resource, InlandAndaluciaGlossaryTermsselection%>" runat="server"></asp:Literal> <br>
                        </p>
                        <div class="linking-shrt">
                            <ul class="pagination">
<%--                                 <li>
      <a href="#" aria-label="Previous">
        <span aria-hidden="true">&laquo;</span>
      </a>
    </li>--%>
                                <li><a href="#a" title="a">a</a></li>
                                <li><a href="#b" title="b">b</a></li>
                                <li><a href="#c" title="c">c</a></li>
                                <li><a href="#d" title="d">d</a></li>
                                <li><a href="#e" title="e">e</a></li>
                                <li><a href="#f" title="f">f</a></li>
                                <li><a href="#g" title="g">g</a></li>
                                <li><a href="#h" title="c">h</a></li>
                                <li><a href="#i" title="d">i</a></li>
                                <li><a href="#j" title="j">j</a></li>
                                <li><a href="#k" title="k">k</a></li>
                                <li><a href="#l" title="l">l</a></li>
                                <li><a href="#m" title="m">m</a></li>
                                <li><a href="#n" title="n">n</a></li>
                                <li><a href="#o" title="o">o</a></li>
                                <li><a href="#p" title="p">p</a></li>
                                <li><a href="#q" title="q">q</a></li>
                                <li><a href="#r" title="r">r</a></li>
                                <li><a href="#s" title="s">s</a></li>
                                <li><a href="#t" title="t">t</a></li>
                                <li><a href="#u" title="u">u</a></li>
                                <li><a href="#v" title="v">v</a></li>
                                <li><a href="#w" title="w">w</a></li>
                                <li><a href="#x" title="x">x</a></li>
                                <li><a href="#y" title="y">y</a></li>
                                <li><a href="#z" title="z">z</a></li>
                             
                              <%--  <li>
      <a href="#" aria-label="Next">
        <span aria-hidden="true">&raquo;</span>
      </a>
    </li>--%>
                            </ul>
                        </div>
                        <asp:Literal ID="Literal13" Text="<%$Resources:Resource, InlandAndaluciaGlossaryTermsDesc%>" runat="server"></asp:Literal>
                      
                    </div>





                </div>
                <!-- glossary end -->




            </div>
        </div>
    </div>

    <!-- Main Content Area End -->
</asp:Content>

