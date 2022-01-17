Imports Microsoft.VisualBasic

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            ' If the Language is NULL
            If Session("Language") Is Nothing Then

                ' Init to English
                Session("Language") = "English"
            Else
                If Session("Language") = "English" Then
                    Me.Page.Title = "Inland Andalucia | The inland Andalucia Property Specialist"
                    Me.Page.MetaDescription = "Inland Andalucia Ltd is the property specialist for inland Andalucia. All locations, all property types. Discover our bargain properties and apartments, villas, town houses, cortijos, commercial properties in Malaga, Jaen, Seville and Cordoba."
                End If
                If Session("Language") = "Spanish" Then
                    Me.Page.Title = "Inland Andalucia | Inmobiliaria para el interior de Andalucia"
                    Me.Page.MetaDescription = "Bienvenido a su especialista para el interior de Andalucía.  Situado en Mollina y Alcalá la Real, ofrecemos propiedades en las provincias de Málaga, Jaén, Cordoba y Sevilla.."
                End If
                If Session("Language") = "French" Then
                    Me.Page.Title = "Inland Andalucia | Spécialiste de l’immobilier de l’Andalousie"
                    Me.Page.MetaDescription = "Bienvenue au véritable spécialiste de l'immobilier à l’interieur de l’Andalousie. Nous vous offrons la plus grande sélection des appartements, maisons, villas, chalets, terrains, ruines, fincas disponible en Andalousie."
                End If
                If Session("Language") = "German" Then
                    Me.Page.Title = "Inland Andalucia | Immobilien Spezialist Andalusien"
                    Me.Page.MetaDescription = "Willkommen bei ihr Immobilienmakler für das echte Andalusien. Inland Andalucia Ltd ist ein wahre Andalusien Immobilien Spezialist."
                End If
                If Session("Language") = "Dutch" Then
                    Me.Page.Title = "Inland Andalucia | Makelaar voor het binnenland van Andalusië"
                    Me.Page.MetaDescription = "Welkom bij uw makelaar voor het binnenland van Andalusië. Alle locaties en elk type van woning. Villas, cortijos, fincas, dorpshuizen, apartementen… als het om het binnenland van Andalusië gaat, zijn wij uw partner."
                End If

            End If



        End If

    End Sub
End Class
