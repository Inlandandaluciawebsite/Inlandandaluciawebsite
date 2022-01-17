Imports System.Data
Partial Class Controls_WebUserControlTownGuid
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim CDataAccess As New ClassUtilities
        Dim alAreaIDs As New ArrayList
        Dim dtDataTable As DataTable

        ' Init Span
        TownGuide.InnerHtml = String.Empty

        ' Init HTML


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
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassUtilities.E_Region.Sevilla, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<div class='col-md-4 col-sm-4'><div class='list-town-g'>"


           

            TownGuide.InnerHtml &= "<h5><a href=""SevillaInfo.aspx"" target=""_self"" title=""" & ("Click here to see information about Seville") & """ style=""text-decoration:underline;"">" & ("Seville") & "</a></h5>  "
            TownGuide.InnerHtml &= "<ul>"
            For index As Integer = 0 To dtDataTable.Rows.Count - 1
             

                ' Aguadulce
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Aguadulce" Then
                    TownGuide.InnerHtml &= "<li><a href=""aguadulceLocationInfo.aspx"" title=""Aguadulce"">Aguadulce</a></li>"
                End If

                ' Arahal
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Arahal" Then
                    TownGuide.InnerHtml &= "<li><a href=""arahalLocationInfo.aspx"" title=""Arahal"">Arahal</a></li>"
                End If

                ' Badolatosa
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Badolatosa" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=109&sort=price_asc"" title=""Badolatosa"">Badolatosa</a></li>"
                End If

                ' Carmona
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Carmona" Then
                    TownGuide.InnerHtml &= "<li><a href=""CarmonaLocationInfo.aspx"" title=""Carmona"">Carmona</a></li>"
                End If

                ' Casariche
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Casariche" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=228&sort=price_asc"" title=""Casariche"">Casariche</a></li>"
                End If

                ' Coripe
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Coripe" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=289&sort=price_asc"" title=""Coripe"">Coripe</a></li>"
                End If

                ' Ecija
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Ecija" Then
                    TownGuide.InnerHtml &= "<li><a href=""EcijaLocationInfo.aspx"" title=""Ecija"">Ecija</a></li>"
                End If

                ' El Rubio
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "El Rubio" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=384&sort=price_asc"" title=""El Rubio"">El Rubio</a></li>"
                End If

                ' El Saucejo
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "El Saucejo" Then
                    TownGuide.InnerHtml &= "<li><a href=""SaucejoLocationInfo.aspx"" title=""El Saucejo"">El Saucejo</a></li>"
                End If

                ' Estepa
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Estepa" Then
                    TownGuide.InnerHtml &= "<li><a href=""EstepaLocationInfo.aspx"" title=""Estepa"">Estepa</a></li>"
                End If

                ' Herrera
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Herrera" Then
                    TownGuide.InnerHtml &= "<li><a href=""herreraLocationInfo.aspx"" title=""Herrera"">Herrera</a></li>"
                End If

                ' Isla Redonda 
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Isla Redonda" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=520&sort=price_asc"" title=""Isla Redonda"">Isla Redonda</a></li>"
                End If

                ' La Luisiana
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "La Luisiana" Then
                    TownGuide.InnerHtml &= "<li><a href=""laluisianaLocationInfo.aspx"" title=""La Luisiana"">La Luisiana</a></li>"
                End If

                ' La Puebla de Cazalla
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "La Puebla de Cazalla" Then
                    TownGuide.InnerHtml &= "<li><a href=""lapuebladecazallaLocationInfo.aspx"" title=""La Puebla de Cazalla"">La Puebla de Cazalla</a></li>"
                End If

                ' La Roda de Andalucia
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "La Roda de Andalucia" Then
                    TownGuide.InnerHtml &= "<li><a href=""LaRodaLocationInfo.aspx"" title=""La Roda de Andalucia"">La Roda de Andalucia</a></li>"
                End If

                ' Lora de Estepa
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Lora de Estepa" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=665&sort=price_asc"" title=""Lora de Estepa"">Lora de Estepa</a></li>"
                End If

                ' Marchena
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Marchena" Then
                    TownGuide.InnerHtml &= "<li><a href=""MarchenaLocationInfo.aspx"" title=""Marchena"">Marchena</a></li>"
                End If

                ' Marinaleda
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Marinaleda" Then
                    TownGuide.InnerHtml &= "<li><a href=""MarinaledaLocationInfo.aspx"" title=""Marinaleda"">Marinaleda</a></li>"
                End If

                ' Moron de la Frontera
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Moron de la Frontera" Then
                    TownGuide.InnerHtml &= "<li><a href=""MoronLocationInfo.aspx"" title=""Moron de la Frontera"">Moron de la Frontera</a></li>"
                End If

                ' Osuna
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Osuna" Then
                    TownGuide.InnerHtml &= "<li><a href=""OsunaLocationInfo.aspx"" title=""Osuna"">Osuna</a></li>"
                End If

                ' Pruna
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Pruna" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=5&areaid=881&sort=price_asc"" title=""Pruna"">Pruna</a></li>"
                End If

                ' Seville (city)
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Seville (city)" Then
                    TownGuide.InnerHtml &= "<li><a href=""sevillaLocationInfo.aspx"" title=""Sevilla (" & ("city") & ")"">Sevilla (" & ("city") & ")</a></li>"
                End If
            Next
            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</ul>"
            TownGuide.InnerHtml &= "</div>"
            TownGuide.InnerHtml &= "</div>"

        End If


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
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassUtilities.E_Region.Cordoba, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<div class='col-md-4 col-sm-4'> <div class='list-town-g'>"
            TownGuide.InnerHtml &= " <h5><a href=""CordobaInfo.aspx"" target=""_self"" title=""" & ("Click here to see information about Cordoba") & """ style=""text-decoration:underline;"">" & ("Cordoba") & "</a></h5>  "
            TownGuide.InnerHtml &= "<ul>"
            For index As Integer = 0 To dtDataTable.Rows.Count - 1
                ' Almedinilla
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Almedinilla" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-almedinilla.aspx"" title=""Almedinilla"">Almedinilla</a></li>"
                End If

                ' Benameji
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Benameji" Then
                    TownGuide.InnerHtml &= "<li><a href=""benameji.aspx"" title=""Benameji"">Benameji</a></li>"
                End If

                ' Carcabuey
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Carcabuey" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-carcabuey.aspx"" title=""Carcabuey"">Carcabuey</a></li>"
                End If

                ' Castil de Campos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Castil de Campos" Then
                    TownGuide.InnerHtml &= "<li><a href=""castil-de-campos.aspx"" title=""Castil de Campos"">Castil de Campos</a></li>"
                End If

                ' El Poleo
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "El Poleo" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=1&areaid=372&sort=price_asc"" title=""El Poleo"">El Poleo</a></li>"
                End If

                ' Encinas Reales
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Encinas Reales" Then
                    TownGuide.InnerHtml &= "<li><a href=""encinas-reales.aspx"" title=""Encinas Reales"">Encinas Reales</a></li>"
                End If

                ' Espejo
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Espejo" Then
                    TownGuide.InnerHtml &= "<li><a href=""espejo.aspx"" title=""Espejo"">Espejo</a></li>"
                End If

                ' Fuente Tojar
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Fuente Tojar" Then
                    TownGuide.InnerHtml &= "<li><a href=""fuente-tojar-cordoba.aspx"" title=""Fuente Tojar"">Fuente Tojar</a></li>"
                End If

                ' Iznajar
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Iznajar" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-iznajar.aspx"" title=""Iznajar"">Iznajar</a></li>"
                End If

                ' Jauja
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Jauja" Then
                    TownGuide.InnerHtml &= "<li><a href=""jauja.aspx"" title=""Jauja"">Jauja</a></li>"
                End If

                ' La Fuente Grande
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "La Fuente Grande" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=1&areaid=568&sort=price_asc"" title=""La Fuente Grande"">La Fuente Grande</a></li>"
                End If

                ' Lucena
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Lucena" Then
                    TownGuide.InnerHtml &= "<li><a href=""lucena.aspx"" title=""Lucena"">Lucena</a></li>"
                End If

                ' Palenciana
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Palenciana" Then
                    TownGuide.InnerHtml &= "<li><a href=""palenciana.aspx"" title=""Palenciana"">Palenciana</a></li>"
                End If

                ' Priego de Cordoba
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Priego de Cordoba" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-priego-of-cordoba.aspx"" title=""Priego de Cordoba"">Priego de Cordoba</a></li>"
                End If

                ' Puente Genil
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Puente Genil" Then
                    TownGuide.InnerHtml &= "<li><a href=""puente-genil.aspx"" title=""Puente Genil"">Puente Genil</a></li>"
                End If

                ' Rute
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Rute" Then
                    TownGuide.InnerHtml &= "<li><a href=""rute.aspx"" title=""Rute"">Rute</a></li>"
                End If
            Next
            TownGuide.InnerHtml &= "</ul>"
        End If


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
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassUtilities.E_Region.Malaga, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column
            TownGuide.InnerHtml &= "<h5><a href=""MalagaInfo.aspx"" target=""_self"" title=""" & ("Click here to see information about Malaga") & """ style=""text-decoration:underline;"">" & ("Malaga") & "</a></h5>"
            TownGuide.InnerHtml &= "<ul>"


            For index As Integer = 0 To dtDataTable.Rows.Count - 1
                ' Alameda
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Alameda" Then
                    TownGuide.InnerHtml &= "<li><a href=""AlamedaLocationInfo.aspx"" title=""Alameda"">Alameda</a></li>"
                End If

                ' Antequera
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Antequera" Then
                    TownGuide.InnerHtml &= "<li><a href=""AntequeraInfo.aspx"" title=""Antequera"">Antequera</a></li>"
                End If

                ' Archidona
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Archidona" Then
                    TownGuide.InnerHtml &= "<li><a href=""ArchidonaLocationInfo.aspx"" title=""Archidona"">Archidona</a></li>"
                End If

                ' Bobadilla Estacion
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Bobadilla Estacion" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=1111&sort=price_asc"" title=""Bobadilla Estacion"">Bobadilla Estacion</a></li>"
                End If

                ' Campillos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Campillos" Then
                    TownGuide.InnerHtml &= "<li><a href=""CampillosLocationInfo.aspx"" title=""Campillos"">Campillos</a></li>"
                End If

                ' Casabermeja
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Casabermeja" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=225&sort=price_asc"" title=""Casabermeja"">Casabermeja</a></li>"
                End If

                ' Cuevas Bajas
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Cuevas Bajas" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=299&sort=price_asc"" title=""Cuevas Bajas"">Cuevas Bajas</a></li>"
                End If

                ' Cuevas de San Marcos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Cuevas de San Marcos" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=300&sort=price_asc"" title=""Cuevas de San Marcos"">Cuevas de San Marcos</a></li>"
                End If

                ' Fuente de Piedra
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Fuente de Piedra" Then
                    TownGuide.InnerHtml &= "<li><a href=""Fuente_de_PiedraLocationInfo.aspx"" title=""Fuente de Piedra"">Fuente de Piedra</a></li>"
                End If

                ' Humilladero
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Humilladero" Then
                    TownGuide.InnerHtml &= "<li><a href=""HumilladeroLocationInfo.aspx"" title=""Humilladero"">Humilladero</a></li>"
                End If

                ' Mollina
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Mollina" Then
                    TownGuide.InnerHtml &= "<li><a href=""MollinaLocationInfo.aspx"" title=""Mollina"">Mollina</a></li>"
                End If

                ' Nava Hermosa
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Nava Hermosa" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=787&sort=price_asc"" title=""Nava Hermosa"">Nava Hermosa</a></li>"
                End If

                ' Salinas
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Salinas" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=308&sort=price_asc"" title=""Salinas"">Salinas</a></li>"
                End If

                ' Sierra de Yeguas
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Sierra de Yeguas" Then
                    TownGuide.InnerHtml &= "<li><a href=""Sierra_de_YeguasLocationInfo.aspx"" title=""Sierra de Yeguas"">Sierra de Yeguas</a></li>"
                End If

                ' Villanueva de Algaidas
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Villanueva de Algaidas" Then
                    TownGuide.InnerHtml &= "<li><a href=""Villanueva_de_AlgaidasLocationInfo.aspx"" title=""Villanueva de Algaidas"">Villanueva de Algaidas</a></li>"
                End If

                ' Villanueva Del Trabuco
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Villanueva Del Trabuco" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=4&areaid=1082&sort=price_asc"" title=""Villanueva Del Trabuco"">Villanueva Del Trabuco</a></li>"
                End If
            Next
            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</ul>"
            TownGuide.InnerHtml &= "</div>"
            TownGuide.InnerHtml &= "</div>"

        End If



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
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassUtilities.E_Region.Granada, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column


            TownGuide.InnerHtml &= "<div class='col-md-4 col-sm-4'> <div class='list-town-g'>"
            TownGuide.InnerHtml &= " <h5><a href=""GranadaInfo.aspx"" target=""_self"" title=""" & ("Click here to see information about Granada") & """ style=""text-decoration:underline;"">" & ("Granada") & "</a></h5>  "
            TownGuide.InnerHtml &= "<ul>"
            For index As Integer = 0 To dtDataTable.Rows.Count - 1
                ' Albolote
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Albolote" Then
                    TownGuide.InnerHtml &= "<li><a href=""albolote-granada.aspx"" title=""Albolote"">Albolote</a></li>"
                End If

                ' Algarinejo
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Algarinejo" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=45&sort=price_asc"" title=""Algarinejo"">Algarinejo</a></li>"
                End If

                ' Alomartes
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Alomartes" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=65&sort=price_asc"" title=""Alomartes"">Alomartes</a></li>"
                End If

                ' Baza
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Baza" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=120&sort=price_asc"" title=""Baza"">Baza</a></li>"
                End If

                ' Fornes
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Fornes" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=424&sort=price_asc"" title=""Fornes"">Fornes</a></li>"
                End If

                ' Fuente Camacho
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Fuente Camacho" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=435&sort=price_asc"" title=""Fuente Camacho"">Fuente Camacho</a></li>"
                End If

                ' Huetor Tajar
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Huetor Tajar" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=510&sort=price_asc"" title=""Huetor Tajar"">Huetor Tajar</a></li>"
                End If

                ' Illora
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Illora" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=517&sort=price_asc"" title=""Illora"">Illora</a></li>"
                End If

                ' Loja
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Loja" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=660&sort=price_asc"" title=""Loja"">Loja</a></li>"
                End If

                ' Moclin
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Moclin" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=752&sort=price_asc"" title=""Moclin"">Moclin</a></li>"
                End If

                ' Montefrio
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Montefrio" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=765&sort=price_asc"" title=""Montefrio"">Montefrio</a></li>"
                End If

                ' Montillana
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Montillana" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=771&sort=price_asc"" title=""Montillana"">Montillana</a></li>"
                End If

                ' Salar
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Salar" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=926&sort=price_asc"" title=""Salar"">Salar</a></li>"
                End If

                ' Ventorros de San Jose
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Ventorros de San Jose" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=1059&sort=price_asc"" title=""Ventorros de San Jose"">Ventorros de San Jose</a></li>"
                End If

                ' Zagra
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Zagra" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=2&areaid=1099&sort=price_asc"" title=""Zagra"">Zagra</a></li>"
                End If
            Next
            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</ul>"

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
        dtDataTable = CDataAccess.PropertyCountsInAreas(ClassUtilities.E_Region.Jaen, alAreaIDs)

        ' Tidy
        alAreaIDs.Clear()

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Init Column

            TownGuide.InnerHtml &= "<h5><a href=""JaenInfo.aspx"" target=""_self"" title=""" & ("Click here to see information about Jaen") & """ style=""text-decoration:underline;"">" & ("Jaen") & "</a></h5>"
            TownGuide.InnerHtml &= "<ul>"

            For index As Integer = 0 To dtDataTable.Rows.Count - 1
                ' Alcala la Real
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Alcala la Real" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-alcala-la-real.aspx"" title=""Alcala la Real"">Alcala la Real</a></li>"
                End If

                ' Alcaudete
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Alcaudete" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-alcaudete.aspx"" title=""Alcaudete"">Alcaudete</a></li>"
                End If

                ' Castillo de Locubin
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Castillo de Locubin" Then
                    TownGuide.InnerHtml &= "<li><a href=""castillo-de-locubin.aspx"" title=""Castillo de Locubin"">Castillo de Locubin</a></li>"
                End If

                ' Charilla
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Charilla" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=260&sort=price_asc"" title=""Charilla"">Charilla</a></li>"
                End If

                ' Ermita Nueva
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Ermita Nueva" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=403&sort=price_asc"" title=""Ermita Nueva"">Ermita Nueva</a></li>"
                End If

                ' Frailes
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Frailes" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=425&sort=price_asc"" title=""Frailes"">Frailes</a></li>"
                End If

                ' Fuensanta de Martos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Fuensanta de Martos" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=432&sort=price_asc"" title=""Fuensanta de Martos"">Fuensanta de Martos</a></li>"
                End If

                ' Fuente Alamo
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Fuente Alamo" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=434&sort=price_asc"" title=""Fuente Alamo"">Fuente Alamo</a></li>"
                End If

                ' La Pedriza
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "La Pedriza" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=596&sort=price_asc"" title=""La Pedriza"">La Pedriza</a></li>"
                End If

                ' La Rabita
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "La Rabita" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=603&sort=price_asc"" title=""La Rabita"">La Rabita</a></li>"
                End If

                ' Las Casillas de Martos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Las Casillas de Martos" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=628&sort=price_asc"" title=""Las Casillas de Martos"">Las Casillas de Martos</a></li>"
                End If

                ' Martos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Martos" Then
                    TownGuide.InnerHtml &= "<li><a href=""guide-martos.aspx"" title=""Martos"">Martos</a></li>"
                End If

                ' Mures
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Mures" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=783&sort=price_asc"" title=""Mures"">Mures</a></li>"
                End If

                ' Sabariego
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Sabariego" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=921&sort=price_asc"" title=""Sabariego"">Sabariego</a></li>"
                End If

                ' San Jose de La Rabita
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "San Jose de La Rabita" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=935&sort=price_asc"" title=""San Jose de La Rabita"">San Jose de La Rabita</a></li>"
                End If

                ' Santa Ana
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Santa Ana" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=943&sort=price_asc"" title=""Santa Ana"">Santa Ana</a></li>"
                End If

                ' Santiago de Calatrava
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Santiago de Calatrava" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=952&sort=price_asc"" title=""Santiago de Calatrava"">Santiago de Calatrava</a></li>"
                End If

                ' Valdepenas de Jaen
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Valdepenas de Jaen" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=1028&sort=price_asc"" title=""Valdepenas de Jaen"">Valdepenas de Jaen</a></li>"
                End If

                ' Venta de Los Agramaderos
                If Convert.ToString(dtDataTable.Rows(index)("area_name")) = "Venta de Los Agramaderos" Then
                    TownGuide.InnerHtml &= "<li><a href=""propsearch.aspx?page=1&regionid=3&areaid=1046&sort=price_asc"" title=""Venta de Los Agramaderos"">Venta de Los Agramaderos</a></li>"
                End If
            Next
            ' Continue to Init HTML
            TownGuide.InnerHtml &= "</ul>"
            TownGuide.InnerHtml &= "</div>"
            TownGuide.InnerHtml &= "</div>"

        End If

        ' Tidy
        dtDataTable.Dispose()


        ' Tidy
        CDataAccess = Nothing

    End Sub

End Class
