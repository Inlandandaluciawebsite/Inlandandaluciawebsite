Imports System.Data
Imports System.IO

Partial Class WebUserControlWeather
    Inherits System.Web.UI.UserControl

    Private Function GetWeatherHTML(ByVal eRegion As ClassDataAccess.E_Region) As String

        ' Local Vars
        Dim szHTML As String

        ' Add the Weather
        Select Case eRegion

            Case ClassDataAccess.E_Region.Cordoba
                szHTML = "<script type=""text/javascript"" src=""http://weatherandtime.net/m_c1/jquery.min.js""></script><div id=""ww_2""><ul id=""weather02_body_18293""><li id=""weather02_t_18293"" class=""weather02_t""></li><li id=""weather02_city_18293"" class=""weather02_city""><a href=""CordobaInfo.aspx"" title=""Cordoba"">Cordoba</a></li><li id=""weather02_date_18293"" class=""weather02_date""></li><li style=""position: absolute; top: 55px;left:70px;width: 30px;""></li></ul></div><script type=""text/javascript"" src=""http://weatherandtime.net/w_2.js?city=18293&lang=en""></script>"

            Case ClassDataAccess.E_Region.Granada
                szHTML = "<script type=""text/javascript"" src=""http://weatherandtime.net/m_c1/jquery.min.js""></script><div id=""ww_2""><ul id=""weather02_body_18278""><li id=""weather02_t_18278"" class=""weather02_t""></li><li id=""weather02_city_18278"" class=""weather02_city""><a href=""GranadaInfo.aspx"" title=""Granada"">Granada</a></li><li id=""weather02_date_18278"" class=""weather02_date""></li><li style=""position: absolute; top: 55px;left:70px;width: 30px;""></li></ul></div><script type=""text/javascript"" src=""http://weatherandtime.net/w_2.js?city=18278&lang=en""></script>"

            Case ClassDataAccess.E_Region.Jaen
                szHTML = "<script type=""text/javascript"" src=""http://weatherandtime.net/m_c1/jquery.min.js""></script><div id=""ww_2""><ul id=""weather02_body_8470""><li id=""weather02_t_8470"" class=""weather02_t""></li><li id=""weather02_city_8470"" class=""weather02_city""><a href=""JaenInfo.aspx"" title=""Jaen"">Jaen</a></li><li id=""weather02_date_8470"" class=""weather02_date""></li><li style=""position: absolute; top: 55px;left:70px;width: 30px;""></li></ul></div><script type=""text/javascript"" src=""http://weatherandtime.net/w_2.js?city=8470&lang=en""></script>"

            Case ClassDataAccess.E_Region.Malaga
                szHTML = "<script type=""text/javascript"" src=""http://weatherandtime.net/m_c1/jquery.min.js""></script><div id=""ww_2""><ul id=""weather02_body_18258""><li id=""weather02_t_18258"" class=""weather02_t""></li><li id=""weather02_city_18258"" class=""weather02_city""><a href=""MalagaInfo.aspx"" title=""Malaga"">Malaga</a></li><li id=""weather02_date_18258"" class=""weather02_date""></li><li style=""position: absolute; top: 55px;left:70px;width: 30px;""></li></ul></div><script type=""text/javascript"" src=""http://weatherandtime.net/w_2.js?city=18258&lang=en""></script>"

            Case Else   ' Seville
                szHTML = "<script type=""text/javascript"" src=""http://weatherandtime.net/m_c1/jquery.min.js""></script><div id=""ww_2""><ul id=""weather02_body_31487""><li id=""weather02_t_31487"" class=""weather02_t""></li><li id=""weather02_city_31487"" class=""weather02_city""><a href=""SevillaInfo.aspx"" title=""Seville"">Seville</a></li><li id=""weather02_date_31487"" class=""weather02_date""></li><li style=""position: absolute; top: 55px;left:70px;width: 30px;""></li></ul></div><script type=""text/javascript"" src=""http://weatherandtime.net/w_2.js?city=31487&lang=en""></script>"

        End Select

        ' Return the Result
        Return szHTML.Trim

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim nRegionID As Integer
        Dim eRegion As ClassDataAccess.E_Region
        Dim bAllWeather As Boolean = False

        ' Depending on the Refrrer
        Select Case Request.ServerVariables("URL")

            Case "/propsearch.aspx"

                ' If we are Looking at a Specific Property
                If Not Request.QueryString("propertyid") Is Nothing Then

                    ' Alloc Data Access
                    Dim CDataAccess As New ClassDataAccess

                    ' Get the Region in which this Property Resides
                    nRegionID = CDataAccess.GetRegionForProperty(Convert.ToInt32(Request.QueryString("propertyid")))

                    ' Tidy
                    CDataAccess = Nothing

                    ' If this is 0 (Property not Found)
                    If nRegionID < 1 Then

                        ' Show All Weather
                        bAllWeather = True

                    Else

                        ' Set the Region
                        eRegion = CType(nRegionID, ClassDataAccess.E_Region)

                    End If

                Else

                    ' Not Looking at a Property - Process All Weather
                    bAllWeather = True

                End If

            Case "/CordobaInfo.aspx", "/guide-almedinilla.aspx", "/benameji.aspx", "/guide-carcabuey.aspx", "/castil-de-campos.aspx", "/encinas-reales.aspx", "/espejo.aspx", "/guide-iznajar.aspx", "/jauja.aspx", "/lucena.aspx", "/palenciana.aspx", "/guide-priego-of-cordoba.aspx", "/puente-genil.aspx", "/rute.aspx"
                eRegion = ClassDataAccess.E_Region.Cordoba

            Case "/GranadaInfo.aspx"
                eRegion = ClassDataAccess.E_Region.Granada

            Case "/JaenInfo.aspx", "/guide-alcala-la-real.aspx", "/guide-alcaudete.aspx", "/castillo-de-locubin.aspx", "/guide-martos.aspx"
                eRegion = ClassDataAccess.E_Region.Jaen

            Case "/MalagaInfo.aspx", "/AlamedaLocationInfo.aspx", "/AntequeraInfo.aspx", "/ArchidonaLocationInfo.aspx", "/CampillosLocationInfo.aspx", "/Fuente_de_PiedraLocationInfo.aspx", "/HumilladeroLocationInfo.aspx", "/MollinaLocationInfo.aspx", "/Sierra_de_YeguasLocationInfo.aspx", "/Villanueva_de_AlgaidasLocationInfo.aspx"
                eRegion = ClassDataAccess.E_Region.Malaga

            Case "/SevillaInfo.aspx", "/aguadulceLocationInfo.aspx", "/arahalLocationInfo.aspx", "/CarmonaLocationInfo.aspx", "/EcijaLocationInfo.aspx", "/SaucejoLocationInfo.aspx", "/EstepaLocationInfo.aspx", "/herreraLocationInfo.aspx", "/laluisianaLocationInfo.aspx", "/lapuebladecazallaLocationInfo.aspx", "/LaRodaLocationInfo.aspx", "/MarchenaLocationInfo.aspx", "/MarinaledaLocationInfo.aspx", "/MoronLocationInfo.aspx", "/OsunaLocationInfo.aspx", "/sevillaLocationInfo.aspx"
                eRegion = ClassDataAccess.E_Region.Sevilla

            Case Else

                ' Set Flag to Include All Weather
                bAllWeather = True

        End Select

        ' If we need all Weathers
        If bAllWeather Then

            ' Including All Weather

            ' Add Weather Includes
            WeatherIncludes.InnerHtml = _
                "<script src=""../js/featured/mg.js"" type=""text/javascript""></script>" & vbCrLf & _
                "<script src=""../js/featured/jquery.transform.min.js"" type=""text/javascript""></script>" & vbCrLf & _
                "<script src=""../js/featured/jquery.bez.min.js"" type=""text/javascript""></script>"

            ' Add Script
            WeatherScript1.InnerHtml = _
                "<script type=""text/javascript"">" & vbCrLf & _
                    "var bez = $.bez([.19, 1, .22, 1]);" & vbCrLf & _
                    "var bezcss = "".19,1,.22,1"";" & vbCrLf & _
                    "function mg_getProperty(arr0, arr1, arr2) {" & vbCrLf & _
                        "var tmp = document.createElement(""div"");" & vbCrLf & _
                        "for (var i = 0, len = arr0.length; i < len; i++) {" & vbCrLf & _
                            "tmp.style[arr0[i]] = 800;" & vbCrLf & _
                            "if (typeof tmp.style[arr0[i]] == 'string') {" & vbCrLf & _
                                "return {" & vbCrLf & _
                                    "js: arr0[i]," & vbCrLf & _
                                    "css: arr1[i]," & vbCrLf & _
                                    "jsEnd: arr2[i]" & vbCrLf & _
                                "};" & vbCrLf & _
                            "}" & vbCrLf & _
                        "}" & vbCrLf & _
                        "return null;" & vbCrLf & _
                    "}" & vbCrLf & _
                    "function mg_getTransition() {" & vbCrLf & _
                        "var arr0 = [""transition"", ""msTransition"", ""MozTransition"", ""WebkitTransition"", ""OTransition"", ""KhtmlTransition""];" & vbCrLf & _
                        "var arr1 = [""transition"", ""-ms-transition"", ""-moz-transition"", ""-webkit-transition"", ""-o-transition"", ""-khtml-transition""];" & vbCrLf & _
                        "var arr2 = [""transitionend"", ""MSTransitionEnd"", ""transitionend"", ""webkitTransitionEnd"", ""oTransitionEnd"", ""khtmlTransitionEnd""];" & vbCrLf & _
                        "return mg_getProperty(arr0, arr1, arr2);" & vbCrLf & _
                    "}" & vbCrLf & _
                    "function mg_getTransform() {" & vbCrLf & _
                        "var arr0 = [""transform"", ""msTransform"", ""MozTransform"", ""WebkitTransform"", ""OTransform"", ""KhtmlTransform""];" & vbCrLf & _
                        "var arr1 = [""transform"", ""-ms-transform"", ""-moz-transform"", ""-webkit-transform"", ""-o-transform"", ""-khtml-transform""];" & vbCrLf & _
                        "return mg_getProperty(arr0, arr1, []);" & vbCrLf & _
                    "}" & vbCrLf & _
                    "function mg_getPerspective() {" & vbCrLf & _
                        "var arr0 = [""perspective"", ""msPerspective"", ""MozPerspective"", ""WebkitPerspective"", ""OPerspective"", ""KhtmlPerspective""];" & vbCrLf & _
                        "var arr1 = [""perspective"", ""-ms-perspective"", ""-moz-perspective"", ""-webkit-perspective"", ""-o-perspective"", ""-khtml-perspective""];" & vbCrLf & _
                        "return mg_getProperty(arr0, arr1, []);" & vbCrLf & _
                    "}" & vbCrLf & _
                    "var transition = mg_getTransition();" & vbCrLf & _
                    "var transform = mg_getTransform();" & vbCrLf & _
                    "var perspective = mg_getPerspective();" & vbCrLf & _
                "</script>"

            ' Add Script
            WeatherScript2.InnerHtml = _
                "<script type=""text/javascript"">" & vbCrLf & _
                    "$('[id^=""weather1a-item-""]').css(""display"", ""block"").css(""position"", ""absolute"").css(""opacity"", 0).css(""z-index"", ""0"");" & vbCrLf & _
                    "var weather1a = new Mg({" & vbCrLf & _
                        "reference: ""weather1a""," & vbCrLf & _
                        "click: {" & vbCrLf & _
                            "activated: [0]" & vbCrLf & _
                        "}" & vbCrLf & _
                    "});" & vbCrLf & _
                    "weather1a.click.onEvent = function () {" & vbCrLf & _
                        "var path = $(""#"" + this.reference + ""-item-"" + this.deactivated);" & vbCrLf & _
                        "path.css(""z-index"", ""0"");" & vbCrLf & _
                        "path.stop().animate({ opacity: 0 }, { queue: true, duration: 1600, specialEasing: { opacity: bez} });" & vbCrLf & _
                        "var path = $(""#"" + this.reference + ""-item-"" + this.activated);" & vbCrLf & _
                        "path.css(""z-index"", ""2"").css(""opacity"", 0);" & vbCrLf & _
                        "path.stop().animate({ opacity: 1 }, { queue: true, duration: 1600, specialEasing: { opacity: bez} });" & vbCrLf & _
                    "}" & vbCrLf & _
                    "weather1a.init();" & vbCrLf & _
                    "var weather1b = new Mg({" & vbCrLf & _
                        "reference: ""weather1b""," & vbCrLf & _
                        "click: {" & vbCrLf & _
                            "activated: [0]," & vbCrLf & _
                            "interactive: true," & vbCrLf & _
                            "linked: [weather1a.click]," & vbCrLf & _
                            "auto: 8000, autoSlow: 5000" & vbCrLf & _
                        "}" & vbCrLf & _
                    "});" & vbCrLf & _
                    "weather1b.click.onEvent = function () {" & vbCrLf & _
                        "$(""#"" + this.reference + ""-item-"" + this.deactivated).removeClass(""active"");" & vbCrLf & _
                        "$(""#"" + this.reference + ""-item-"" + this.activated).addClass(""active"");" & vbCrLf & _
                    "}" & vbCrLf & _
                    "weather1b.init();" & vbCrLf & _
                "</script>"

            ' Add Remaining Items
            WeatherItems.InnerHtml = _
                "<div id=""weather1b-item-1""></div>" & vbCrLf & _
                "<div id=""weather1b-item-2""></div>" & vbCrLf & _
                "<div id=""weather1b-item-3""></div>" & vbCrLf & _
                "<div id=""weather1b-item-4""></div>"

            ' For each of the 5 Regions
            For nRegionID = 0 To 4

                ' Init HTML
                Weather.InnerHtml &= "<div id=""weather1a-item-" & nRegionID.ToString.Trim & """>"

                ' Add the Opening DIV
                Weather.InnerHtml &= "<div class=""weatheritem"">"

                ' Add the Weather
                Weather.InnerHtml &= GetWeatherHTML(nRegionID + 1)

                ' Continue to Init HTML
                Weather.InnerHtml &= "</div>"
                Weather.InnerHtml &= "</div>"

            Next

        Else

            ' Init HTML
            Weather.InnerHtml &= "<div id=""weather1a-item-0"">"

            ' Add the Opening DIV
            Weather.InnerHtml &= "<div class=""weatheritem"">"

            ' Add the Weather
            Weather.InnerHtml &= GetWeatherHTML(eRegion)

            ' Continue to Init HTML
            Weather.InnerHtml &= "</div>"
            Weather.InnerHtml &= "</div>"

        End If

    End Sub

End Class
