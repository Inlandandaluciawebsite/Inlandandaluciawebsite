Imports System.Data

Partial Class WebUserControlTownGuide
    Inherits System.Web.UI.UserControl

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim alAreaIDs As New ArrayList
        Dim dtDataTable As DataTable

        ' Init Span
        TownGuide.InnerHtml = String.Empty

        ' Init HTML
        TownGuide.InnerHtml &= "<div class=""row"">"

        ' Going through Area by Area - Seville

        ' Init Area IDs - Seville
        alAreaIDs.Add(7)    ' Aguadulce
        alAreaIDs.Add(76)   ' Arahal
        alAreaIDs.Add(109)  ' Badolatosa
        alAreaIDs.Add(216)  ' Carmona
        alAreaIDs.Add(228)  ' Casariche
        alAreaIDs.Add(289)  ' Coripe
        alAreaIDs.Add(322)  ' Ecija
        alAreaIDs.Add(384)  ' El Rubio
        alAreaIDs.Add(385)  ' El Saucejo
        alAreaIDs.Add(415)  ' Estepa
        alAreaIDs.Add(493)  ' Herrera
        alAreaIDs.Add(520)  ' Isla Redonda 
        alAreaIDs.Add(585)  ' La Luisiana
        alAreaIDs.Add(599)  ' La Puebla de Cazalla
        alAreaIDs.Add(606)  ' La Roda de Andalucia
        alAreaIDs.Add(665)  ' Lora de Estepa
        alAreaIDs.Add(726)  ' Marchena
        alAreaIDs.Add(729)  ' Marinaleda
        alAreaIDs.Add(780)  ' Moron de la Frontera
        alAreaIDs.Add(816)  ' Osuna
        alAreaIDs.Add(881)  ' Pruna
        alAreaIDs.Add(964)  ' Seville (city)

        ' Get a List of Regions and Property Counts
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassDataAccess.E_Region.Sevilla, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<div class=""townguidecolumn"">"
            TownGuide.InnerHtml &= "<p><strong><a href=""SevillaInfo.aspx"" target=""_self"" title=""" & GetTranslation("Click here to see information about Seville") & """ style=""text-decoration:underline;"">" & GetTranslation("Seville") & "</a></strong></p>"
            TownGuide.InnerHtml &= "<p>"

            ' Aguadulce
            If Convert.ToInt32(dtDataTable.Rows(0).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""aguadulceLocationInfo.aspx"" title=""Aguadulce"">Aguadulce</a><br />"
            End If

            ' Arahal
            If Convert.ToInt32(dtDataTable.Rows(1).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""arahalLocationInfo.aspx"" title=""Arahal"">Arahal</a><br />"
            End If

            ' Badolatosa
            If Convert.ToInt32(dtDataTable.Rows(2).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=109&sort=price_asc"" title=""Badolatosa"">Badolatosa</a><br />"
            End If

            ' Carmona
            If Convert.ToInt32(dtDataTable.Rows(3).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""CarmonaLocationInfo.aspx"" title=""Carmona"">Carmona</a><br />"
            End If

            ' Casariche
            If Convert.ToInt32(dtDataTable.Rows(4).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=228&sort=price_asc"" title=""Casariche"">Casariche</a><br />"
            End If

            ' Coripe
            If Convert.ToInt32(dtDataTable.Rows(5).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=289&sort=price_asc"" title=""Coripe"">Coripe</a><br />"
            End If

            ' Ecija
            If Convert.ToInt32(dtDataTable.Rows(6).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""EcijaLocationInfo.aspx"" title=""Ecija"">Ecija</a><br />"
            End If

            ' El Rubio
            If Convert.ToInt32(dtDataTable.Rows(7).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=384&sort=price_asc"" title=""El Rubio"">El Rubio</a><br />"
            End If

            ' El Saucejo
            If Convert.ToInt32(dtDataTable.Rows(8).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""SaucejoLocationInfo.aspx"" title=""El Saucejo"">El Saucejo</a><br />"
            End If

            ' Estepa
            If Convert.ToInt32(dtDataTable.Rows(9).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""EstepaLocationInfo.aspx"" title=""Estepa"">Estepa</a><br />"
            End If

            ' Herrera
            If Convert.ToInt32(dtDataTable.Rows(10).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""herreraLocationInfo.aspx"" title=""Herrera"">Herrera</a><br />"
            End If

            ' Isla Redonda 
            If Convert.ToInt32(dtDataTable.Rows(11).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=520&sort=price_asc"" title=""Isla Redonda"">Isla Redonda</a><br />"
            End If

            ' La Luisiana
            If Convert.ToInt32(dtDataTable.Rows(12).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""laluisianaLocationInfo.aspx"" title=""La Luisiana"">La Luisiana</a><br />"
            End If

            ' La Puebla de Cazalla
            If Convert.ToInt32(dtDataTable.Rows(13).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""lapuebladecazallaLocationInfo.aspx"" title=""La Puebla de Cazalla"">La Puebla de Cazalla</a><br />"
            End If

            ' La Roda de Andalucia
            If Convert.ToInt32(dtDataTable.Rows(14).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""LaRodaLocationInfo.aspx"" title=""La Roda de Andalucia"">La Roda de Andalucia</a><br />"
            End If

            ' Lora de Estepa
            If Convert.ToInt32(dtDataTable.Rows(15).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=665&sort=price_asc"" title=""Lora de Estepa"">Lora de Estepa</a><br />"
            End If

            ' Marchena
            If Convert.ToInt32(dtDataTable.Rows(16).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""MarchenaLocationInfo.aspx"" title=""Marchena"">Marchena</a><br />"
            End If

            ' Marinaleda
            If Convert.ToInt32(dtDataTable.Rows(17).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""MarinaledaLocationInfo.aspx"" title=""Marinaleda"">Marinaleda</a><br />"
            End If

            ' Moron de la Frontera
            If Convert.ToInt32(dtDataTable.Rows(18).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""MoronLocationInfo.aspx"" title=""Moron de la Frontera"">Moron de la Frontera</a><br />"
            End If

            ' Osuna
            If Convert.ToInt32(dtDataTable.Rows(19).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""OsunaLocationInfo.aspx"" title=""Osuna"">Osuna</a><br />"
            End If

            ' Pruna
            If Convert.ToInt32(dtDataTable.Rows(20).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=5&areaid=881&sort=price_asc"" title=""Pruna"">Pruna</a><br />"
            End If

            ' Seville (city)
            If Convert.ToInt32(dtDataTable.Rows(21).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""sevillaLocationInfo.aspx"" title=""Sevilla (" & GetTranslation("city") & ")"">Sevilla (" & GetTranslation("city") & ")</a><br />"
            End If

            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</p>"
            TownGuide.InnerHtml &= "<br>"
            TownGuide.InnerHtml &= "</div>"

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Going through Area by Area - Cordoba

        ' Init Area IDs - Cordoba
        alAreaIDs.Add(59)   ' Almedinilla
        alAreaIDs.Add(142)  ' Benameji
        alAreaIDs.Add(211)  ' Carcabuey
        alAreaIDs.Add(233)  ' Castil de Campos
        alAreaIDs.Add(372)  ' El Poleo
        alAreaIDs.Add(402)  ' Encinas Reales
        alAreaIDs.Add(408)  ' Espejo
        alAreaIDs.Add(444)  ' Fuente Tojar
        alAreaIDs.Add(524)  ' Iznajar
        alAreaIDs.Add(535)  ' Jauja
        alAreaIDs.Add(568)  ' La Fuente Grande
        alAreaIDs.Add(708)  ' Lucena
        alAreaIDs.Add(820)  ' Palenciana
        alAreaIDs.Add(880)  ' Priego de Cordoba
        alAreaIDs.Add(887)  ' Puente Genil
        alAreaIDs.Add(920)  ' Rute

        ' Get a List of Regions and Property Counts
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassDataAccess.E_Region.Cordoba, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<div class=""townguidecolumn"">"
            TownGuide.InnerHtml &= "<p><strong><a href=""CordobaInfo.aspx"" target=""_self"" title=""" & GetTranslation("Click here to see information about Cordoba") & """ style=""text-decoration:underline;"">" & GetTranslation("Cordoba") & "</a></strong></p>"
            TownGuide.InnerHtml &= "<p>"

            ' Almedinilla
            If Convert.ToInt32(dtDataTable.Rows(0).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-almedinilla.aspx"" title=""Almedinilla"">Almedinilla</a><br />"
            End If

            ' Benameji
            If Convert.ToInt32(dtDataTable.Rows(1).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""benameji.aspx"" title=""Benameji"">Benameji</a><br />"
            End If

            ' Carcabuey
            If Convert.ToInt32(dtDataTable.Rows(2).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-carcabuey.aspx"" title=""Carcabuey"">Carcabuey</a><br />"
            End If

            ' Castil de Campos
            If Convert.ToInt32(dtDataTable.Rows(3).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""castil-de-campos.aspx"" title=""Castil de Campos"">Castil de Campos</a><br />"
            End If

            ' El Poleo
            If Convert.ToInt32(dtDataTable.Rows(4).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=1&areaid=372&sort=price_asc"" title=""El Poleo"">El Poleo</a><br />"
            End If

            ' Encinas Reales
            If Convert.ToInt32(dtDataTable.Rows(5).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""encinas-reales.aspx"" title=""Encinas Reales"">Encinas Reales</a><br />"
            End If

            ' Espejo
            If Convert.ToInt32(dtDataTable.Rows(6).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""espejo.aspx"" title=""Espejo"">Espejo</a><br />"
            End If

            ' Fuente Tojar
            If Convert.ToInt32(dtDataTable.Rows(7).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""fuente-tojar-cordoba.aspx"" title=""Fuente Tojar"">Fuente Tojar</a><br />"
            End If

            ' Iznajar
            If Convert.ToInt32(dtDataTable.Rows(8).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-iznajar.aspx"" title=""Iznajar"">Iznajar</a><br />"
            End If

            ' Jauja
            If Convert.ToInt32(dtDataTable.Rows(9).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""jauja.aspx"" title=""Jauja"">Jauja</a><br />"
            End If

            ' La Fuente Grande
            If Convert.ToInt32(dtDataTable.Rows(10).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=1&areaid=568&sort=price_asc"" title=""La Fuente Grande"">La Fuente Grande</a><br />"
            End If

            ' Lucena
            If Convert.ToInt32(dtDataTable.Rows(11).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""lucena.aspx"" title=""Lucena"">Lucena</a><br />"
            End If

            ' Palenciana
            If Convert.ToInt32(dtDataTable.Rows(12).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""palenciana.aspx"" title=""Palenciana"">Palenciana</a><br />"
            End If

            ' Priego de Cordoba
            If Convert.ToInt32(dtDataTable.Rows(13).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-priego-of-cordoba.aspx"" title=""Priego de Cordoba"">Priego de Cordoba</a><br />"
            End If

            ' Puente Genil
            If Convert.ToInt32(dtDataTable.Rows(14).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""puente-genil.aspx"" title=""Puente Genil"">Puente Genil</a><br />"
            End If

            ' Rute
            If Convert.ToInt32(dtDataTable.Rows(15).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""rute.aspx"" title=""Rute"">Rute</a><br />"
            End If

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Going through Area by Area - Malaga

        ' Init Area IDs - Malaga
        alAreaIDs.Add(11)   ' Alameda
        alAreaIDs.Add(74)   ' Antequera
        alAreaIDs.Add(79)   ' Archidona        
        alAreaIDs.Add(1111) ' Bobadilla Estacion
        alAreaIDs.Add(182)  ' Campillos
        alAreaIDs.Add(225)  ' Casabermeja
        alAreaIDs.Add(299)  ' Cuevas Bajas
        alAreaIDs.Add(300)  ' Cuevas de San Marcos
        alAreaIDs.Add(437)  ' Fuente de Piedra
        alAreaIDs.Add(514)  ' Humilladero
        alAreaIDs.Add(755)  ' Mollina
        alAreaIDs.Add(787)  ' Nava Hermosa
        alAreaIDs.Add(308)  ' Salinas
        alAreaIDs.Add(966)  ' Sierra de Yeguas
        alAreaIDs.Add(1070) ' Villanueva de Algaidas
        alAreaIDs.Add(1082) ' Villanueva Del Trabuco        

        ' Get a List of Regions and Property Counts
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassDataAccess.E_Region.Malaga, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<p><strong><a href=""MalagaInfo.aspx"" target=""_self"" title=""" & GetTranslation("Click here to see information about Malaga") & """ style=""text-decoration:underline;"">" & GetTranslation("Malaga") & "</a></strong></p>"
            TownGuide.InnerHtml &= "<p>"

            ' Alameda
            If Convert.ToInt32(dtDataTable.Rows(0).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""AlamedaLocationInfo.aspx"" title=""Alameda"">Alameda</a><br />"
            End If

            ' Antequera
            If Convert.ToInt32(dtDataTable.Rows(1).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""AntequeraInfo.aspx"" title=""Antequera"">Antequera</a><br />"
            End If

            ' Archidona
            If Convert.ToInt32(dtDataTable.Rows(2).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""ArchidonaLocationInfo.aspx"" title=""Archidona"">Archidona</a><br />"
            End If

            ' Bobadilla Estacion
            If Convert.ToInt32(dtDataTable.Rows(3).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=1111&sort=price_asc"" title=""Bobadilla Estacion"">Bobadilla Estacion</a><br />"
            End If

            ' Campillos
            If Convert.ToInt32(dtDataTable.Rows(4).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""CampillosLocationInfo.aspx"" title=""Campillos"">Campillos</a><br />"
            End If

            ' Casabermeja
            If Convert.ToInt32(dtDataTable.Rows(5).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=225&sort=price_asc"" title=""Casabermeja"">Casabermeja</a><br />"
            End If

            ' Cuevas Bajas
            If Convert.ToInt32(dtDataTable.Rows(6).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=299&sort=price_asc"" title=""Cuevas Bajas"">Cuevas Bajas</a><br />"
            End If

            ' Cuevas de San Marcos
            If Convert.ToInt32(dtDataTable.Rows(7).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=300&sort=price_asc"" title=""Cuevas de San Marcos"">Cuevas de San Marcos</a><br />"
            End If

            ' Fuente de Piedra
            If Convert.ToInt32(dtDataTable.Rows(8).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""Fuente_de_PiedraLocationInfo.aspx"" title=""Fuente de Piedra"">Fuente de Piedra</a><br />"
            End If

            ' Humilladero
            If Convert.ToInt32(dtDataTable.Rows(9).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""HumilladeroLocationInfo.aspx"" title=""Humilladero"">Humilladero</a><br />"
            End If

            ' Mollina
            If Convert.ToInt32(dtDataTable.Rows(10).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""MollinaLocationInfo.aspx"" title=""Mollina"">Mollina</a><br />"
            End If

            ' Nava Hermosa
            If Convert.ToInt32(dtDataTable.Rows(11).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=787&sort=price_asc"" title=""Nava Hermosa"">Nava Hermosa</a><br />"
            End If

            ' Salinas
            If Convert.ToInt32(dtDataTable.Rows(12).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=308&sort=price_asc"" title=""Salinas"">Salinas</a><br />"
            End If

            ' Sierra de Yeguas
            If Convert.ToInt32(dtDataTable.Rows(13).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""Sierra_de_YeguasLocationInfo.aspx"" title=""Sierra de Yeguas"">Sierra de Yeguas</a><br />"
            End If

            ' Villanueva de Algaidas
            If Convert.ToInt32(dtDataTable.Rows(14).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""Villanueva_de_AlgaidasLocationInfo.aspx"" title=""Villanueva de Algaidas"">Villanueva de Algaidas</a><br />"
            End If

            ' Villanueva Del Trabuco
            If Convert.ToInt32(dtDataTable.Rows(15).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=4&areaid=1082&sort=price_asc"" title=""Villanueva Del Trabuco"">Villanueva Del Trabuco</a><br />"
            End If

            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</p>"
            TownGuide.InnerHtml &= "</div>"

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Going through Area by Area - Granada

        ' Init Area IDs - Granada
        alAreaIDs.Add(18)   ' Albolote
        alAreaIDs.Add(45)   ' Algarinejo
        alAreaIDs.Add(65)   ' Alomartes
        alAreaIDs.Add(120)  ' Baza
        alAreaIDs.Add(424)  ' Fornes
        alAreaIDs.Add(435)  ' Fuente Camacho
        alAreaIDs.Add(510)  ' Huetor Tajar
        alAreaIDs.Add(517)  ' Illora
        alAreaIDs.Add(660)  ' Loja
        alAreaIDs.Add(752)  ' Moclin
        alAreaIDs.Add(765)  ' Montefrio
        alAreaIDs.Add(771)  ' Montillana
        alAreaIDs.Add(926)  ' Salar
        alAreaIDs.Add(1059) ' Ventorros de San Jose
        alAreaIDs.Add(1099) ' Zagra

        ' Get a List of Regions and Property Counts
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassDataAccess.E_Region.Granada, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<div class=""townguidecolumn"">"
            TownGuide.InnerHtml &= "<p><strong><a href=""GranadaInfo.aspx"" target=""_self"" title=""" & GetTranslation("Click here to see information about Granada") & """ style=""text-decoration:underline;"">" & GetTranslation("Granada") & "</a></strong></p>"
            TownGuide.InnerHtml &= "<p>"

            ' Albolote
            If Convert.ToInt32(dtDataTable.Rows(0).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""albolote-granada.aspx"" title=""Albolote"">Albolote</a><br />"
            End If

            ' Algarinejo
            If Convert.ToInt32(dtDataTable.Rows(1).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=45&sort=price_asc"" title=""Algarinejo"">Algarinejo</a><br />"
            End If

            ' Alomartes
            If Convert.ToInt32(dtDataTable.Rows(2).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=65&sort=price_asc"" title=""Alomartes"">Alomartes</a><br />"
            End If

            ' Baza
            If Convert.ToInt32(dtDataTable.Rows(3).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=120&sort=price_asc"" title=""Baza"">Baza</a><br />"
            End If

            ' Fornes
            If Convert.ToInt32(dtDataTable.Rows(4).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=424&sort=price_asc"" title=""Fornes"">Fornes</a><br />"
            End If

            ' Fuente Camacho
            If Convert.ToInt32(dtDataTable.Rows(5).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=435&sort=price_asc"" title=""Fuente Camacho"">Fuente Camacho</a><br />"
            End If

            ' Huetor Tajar
            If Convert.ToInt32(dtDataTable.Rows(6).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=510&sort=price_asc"" title=""Huetor Tajar"">Huetor Tajar</a><br />"
            End If

            ' Illora
            If Convert.ToInt32(dtDataTable.Rows(7).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=517&sort=price_asc"" title=""Illora"">Illora</a><br />"
            End If

            ' Loja
            If Convert.ToInt32(dtDataTable.Rows(8).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=660&sort=price_asc"" title=""Loja"">Loja</a><br />"
            End If

            ' Moclin
            If Convert.ToInt32(dtDataTable.Rows(9).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=752&sort=price_asc"" title=""Moclin"">Moclin</a><br />"
            End If

            ' Montefrio
            If Convert.ToInt32(dtDataTable.Rows(10).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=765&sort=price_asc"" title=""Montefrio"">Montefrio</a><br />"
            End If

            ' Montillana
            If Convert.ToInt32(dtDataTable.Rows(11).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=771&sort=price_asc"" title=""Montillana"">Montillana</a><br />"
            End If

            ' Salar
            If Convert.ToInt32(dtDataTable.Rows(12).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=926&sort=price_asc"" title=""Salar"">Salar</a><br />"
            End If

            ' Ventorros de San Jose
            If Convert.ToInt32(dtDataTable.Rows(13).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=1059&sort=price_asc"" title=""Ventorros de San Jose"">Ventorros de San Jose</a><br />"
            End If

            ' Zagra
            If Convert.ToInt32(dtDataTable.Rows(14).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=2&areaid=1099&sort=price_asc"" title=""Zagra"">Zagra</a><br />"
            End If

            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</div>"

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Going through Area by Area - Jaen

        ' Init Area IDs - Jaen
        alAreaIDs.Add(25)   ' Alcala la Real
        alAreaIDs.Add(28)   ' Alcaudete
        alAreaIDs.Add(242)  ' Castillo de Locubin
        alAreaIDs.Add(260)  ' Charilla
        alAreaIDs.Add(403)  ' Ermita Nueva
        alAreaIDs.Add(425)  ' Frailes
        alAreaIDs.Add(432)  ' Fuensanta de Martos
        alAreaIDs.Add(434)  ' Fuente Alamo
        alAreaIDs.Add(596)  ' La Pedriza
        alAreaIDs.Add(603)  ' La Rabita
        alAreaIDs.Add(628)  ' Las Casillas de Martos
        alAreaIDs.Add(734)  ' Martos
        alAreaIDs.Add(783)  ' Mures
        alAreaIDs.Add(921)  ' Sabariego
        alAreaIDs.Add(935)  ' San Jose de La Rabita
        alAreaIDs.Add(943)  ' Santa Ana
        alAreaIDs.Add(952)  ' Santiago de Calatrava
        alAreaIDs.Add(1028) ' Valdepenas de Jaen
        alAreaIDs.Add(1046) ' Venta de Los Agramaderos

        ' Get a List of Regions and Property Counts
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassDataAccess.E_Region.Jaen, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<div class=""townguidecolumn"">"
            TownGuide.InnerHtml &= "<p><strong><a href=""JaenInfo.aspx"" target=""_self"" title=""" & GetTranslation("Click here to see information about Jaen") & """ style=""text-decoration:underline;"">" & GetTranslation("Jaen") & "</a></strong></p>"
            TownGuide.InnerHtml &= "<p>"

            ' Alcala la Real
            If Convert.ToInt32(dtDataTable.Rows(0).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-alcala-la-real.aspx"" title=""Alcala la Real"">Alcala la Real</a><br />"
            End If

            ' Alcaudete
            If Convert.ToInt32(dtDataTable.Rows(1).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-alcaudete.aspx"" title=""Alcaudete"">Alcaudete</a><br />"
            End If

            ' Castillo de Locubin
            If Convert.ToInt32(dtDataTable.Rows(2).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""castillo-de-locubin.aspx"" title=""Castillo de Locubin"">Castillo de Locubin</a><br />"
            End If

            ' Charilla
            If Convert.ToInt32(dtDataTable.Rows(3).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=260&sort=price_asc"" title=""Charilla"">Charilla</a><br />"
            End If

            ' Ermita Nueva
            If Convert.ToInt32(dtDataTable.Rows(4).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=403&sort=price_asc"" title=""Ermita Nueva"">Ermita Nueva</a><br />"
            End If

            ' Frailes
            If Convert.ToInt32(dtDataTable.Rows(5).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=425&sort=price_asc"" title=""Frailes"">Frailes</a><br />"
            End If

            ' Fuensanta de Martos
            If Convert.ToInt32(dtDataTable.Rows(6).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=432&sort=price_asc"" title=""Fuensanta de Martos"">Fuensanta de Martos</a><br />"
            End If

            ' Fuente Alamo
            If Convert.ToInt32(dtDataTable.Rows(7).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=434&sort=price_asc"" title=""Fuente Alamo"">Fuente Alamo</a><br />"
            End If

            ' La Pedriza
            If Convert.ToInt32(dtDataTable.Rows(8).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=596&sort=price_asc"" title=""La Pedriza"">La Pedriza</a><br />"
            End If

            ' La Rabita
            If Convert.ToInt32(dtDataTable.Rows(9).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=603&sort=price_asc"" title=""La Rabita"">La Rabita</a><br />"
            End If

            ' Las Casillas de Martos
            If Convert.ToInt32(dtDataTable.Rows(10).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=628&sort=price_asc"" title=""Las Casillas de Martos"">Las Casillas de Martos</a><br />"
            End If

            ' Martos
            If Convert.ToInt32(dtDataTable.Rows(11).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""guide-martos.aspx"" title=""Martos"">Martos</a><br />"
            End If

            ' Mures
            If Convert.ToInt32(dtDataTable.Rows(12).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=783&sort=price_asc"" title=""Mures"">Mures</a><br />"
            End If

            ' Sabariego
            If Convert.ToInt32(dtDataTable.Rows(13).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=921&sort=price_asc"" title=""Sabariego"">Sabariego</a><br />"
            End If

            ' San Jose de La Rabita
            If Convert.ToInt32(dtDataTable.Rows(14).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=935&sort=price_asc"" title=""San Jose de La Rabita"">San Jose de La Rabita</a><br />"
            End If

            ' Santa Ana
            If Convert.ToInt32(dtDataTable.Rows(15).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=943&sort=price_asc"" title=""Santa Ana"">Santa Ana</a><br />"
            End If

            ' Santiago de Calatrava
            If Convert.ToInt32(dtDataTable.Rows(16).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=952&sort=price_asc"" title=""Santiago de Calatrava"">Santiago de Calatrava</a><br />"
            End If

            ' Valdepenas de Jaen
            If Convert.ToInt32(dtDataTable.Rows(17).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=1028&sort=price_asc"" title=""Valdepenas de Jaen"">Valdepenas de Jaen</a><br />"
            End If

            ' Venta de Los Agramaderos
            If Convert.ToInt32(dtDataTable.Rows(18).Item("num")) > 0 Then
                TownGuide.InnerHtml &= "<a href=""propsearch.aspx?page=1&regionid=3&areaid=1046&sort=price_asc"" title=""Venta de Los Agramaderos"">Venta de Los Agramaderos</a><br />"
            End If

            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</p>"
            TownGuide.InnerHtml &= "<br>"
            TownGuide.InnerHtml &= "</div>"

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Continue to Init HTML
        TownGuide.InnerHtml &= "</div>"

        ' Tidy
        CDataAccess = Nothing

    End Sub

End Class
