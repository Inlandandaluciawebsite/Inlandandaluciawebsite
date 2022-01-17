<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="CompanyPrivacyPolicy.aspx.vb" Inherits="CompanyPrivacyPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main Content Area Start -->

    <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- Buyers Guide Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="buyers-guide">
                    <div class="listing-buyer">
                        <%-- <h4>CLÁUSULA INFORMATIVA PARA CLIENTES</h4>
                        <p>
                            En cumplimiento del Reglamento General de Protección de Datos (UE) 2016/679 del Parlamento Europeo y del
Consejo de 27 de abril de 2016 le informamos que los datos por Vd. proporcionados serán objeto de tratamiento por
parte de INLAND CONVEYENCE SERVICE S.L.    con CIF B23719487, con domicilio en  (), C.P. 00000, , con la
finalidad de prestarle el servicio solicitado y/o contratado, realizar la facturación del mismo.
                        </p>

                        <p>
                            La base legal para el tratamiento de sus datos es la ejecución del servicio por usted contratado y/o solicitado. La
oferta prospectiva de productos y servicios está basada en el consentimiento que se le solicita, sin que en ningún
caso la retirada de este consentimiento condicione la ejecución del contrato.
                        </p>
                        <p>
                            Los datos proporcionados se conservarán mientras se mantenga la relación comercial o durante los años necesarios
para cumplir con las obligaciones legales. Los datos no se cederán a terceros salvo en los casos en que exista una
obligación legal.
                        </p>
                        <p>
                            Usted tiene derecho a obtener confirmación sobre si INLAND CONVEYENCE SERVICE S.L.   estamos tratando sus
datos personales y por tanto tiene derecho a ejercer sus derechos de acceso, rectificación, limitación del tratamiento,
portabilidad, oposición al tratamiento y supresión de sus datos así como el derecho a presentar una reclamación ante
la Autoridad de Control mediante escrito dirigido a la dirección postal arriba mencionada o mediante correo
electrónico dirigido a  info@inlandandalucia.com adjuntando copia del DNI en ambos casos.
                        </p>
                        <p>
                            Asimismo le solicitamos su autorización para ofrecerle productos y servicios relacionados con los solicitados,
prestados y/o comercializados por nuestra entidad y poder de esa forma fidelizarle como cliente.
                        </p>

                        <div class="divider mrg-10">
                            <img src="/images/divider.png">
                        </div>--%>
                        <h4>
                            <asp:Literal ID="ltrlCompanyPrivacyPolicyHeader_01" Text="<%$Resources:Resource, CompanyPrivacyPolicyHeader_01%>" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="ltrlCompanyPrivacyPolicy_01" Text="<%$Resources:Resource, CompanyPrivacyPolicy_01%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="ltrlCompanyPrivacyPolicy_02" Text="<%$Resources:Resource, CompanyPrivacyPolicy_02%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="ltrlCompanyPrivacyPolicy_03" Text="<%$Resources:Resource, CompanyPrivacyPolicy_03%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="ltrlCompanyPrivacyPolicy_04" Text="<%$Resources:Resource, CompanyPrivacyPolicy_04%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="ltrlCompanyPrivacyPolicy_05" Text="<%$Resources:Resource, CompanyPrivacyPolicy_05%>" runat="server"></asp:Literal>
                        </p>
                        <div class="divider mrg-10 ">
                            <img src="/images/divider.png">
                        </div>
                        <h4>
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, CompanyPrivacyPolicyHeader_02%>" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="Literal2" Text="<%$Resources:Resource, CompanyPrivacyPolicy_06%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal3" Text="<%$Resources:Resource, CompanyPrivacyPolicy_07%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal4" Text="<%$Resources:Resource, CompanyPrivacyPolicy_08%>" runat="server"></asp:Literal>
                        </p>
                        <div class="divider mrg-10 ">
                            <img src="/images/divider.png">
                        </div>
                        <h4>
                            <asp:Literal ID="Literal5" Text="<%$Resources:Resource, CompanyPrivacyPolicyHeader_03%>" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="Literal6" Text="<%$Resources:Resource, CompanyPrivacyPolicy_09%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal7" Text="<%$Resources:Resource, CompanyPrivacyPolicy_10%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal8" Text="<%$Resources:Resource, CompanyPrivacyPolicy_11%>" runat="server"></asp:Literal>
                        </p>
                        <div class="divider mrg-10 ">
                            <img src="/images/divider.png">
                        </div>
                        <h4>
                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, CompanyPrivacyPolicyHeader_04%>" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="Literal10" Text="<%$Resources:Resource, CompanyPrivacyPolicy_12%>" runat="server"></asp:Literal>
                        </p>
                        <div class="divider mrg-10 ">
                            <img src="/images/divider.png">
                        </div>
                        <h4>
                            <asp:Literal ID="Literal11" Text="<%$Resources:Resource, CompanyPrivacyPolicyHeader_05%>" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="Literal12" Text="<%$Resources:Resource, CompanyPrivacyPolicy_13%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal13" Text="<%$Resources:Resource, CompanyPrivacyPolicy_14%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal14" Text="<%$Resources:Resource, CompanyPrivacyPolicy_15%>" runat="server"></asp:Literal>
                        </p>
                        <div class="divider mrg-10 ">
                            <img src="/images/divider.png">
                        </div>
                        <h4>
                            <asp:Literal ID="Literal15" Text="<%$Resources:Resource, CompanyPrivacyPolicyHeader_06%>" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="Literal16" Text="<%$Resources:Resource, CompanyPrivacyPolicy_16%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal17" Text="<%$Resources:Resource, CompanyPrivacyPolicy_17%>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal18" Text="<%$Resources:Resource, CompanyPrivacyPolicy_18%>" runat="server"></asp:Literal>
                        </p>
                        <div class="divider mrg-10 ">
                            <img src="/images/divider.png">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Buyers Guide End -->


        <!-- Contact Page Start -->
    </div>
    <!-- Left Portion End -->


    <!-- Main Content Area End -->
</asp:Content>

