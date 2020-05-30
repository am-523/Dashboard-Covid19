Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Now
        CoronaIndonesia()
        CoronaIndonesiaDetail()
        CoronalGlobalDetail()
    End Sub

    Private Sub CoronaIndonesia()
        Dim json As String = (New WebClient).DownloadString("https://api.kawalcorona.com/indonesia/")
        Dim jarr As Linq.JArray = Linq.JArray.Parse(json)
        For Each jtk As JToken In jarr
            lblPositif.Text = jtk.SelectToken("positif")
            lblSembuh.Text = jtk.SelectToken("sembuh")
            lblMeninggal.Text = jtk.SelectToken("meninggal")
        Next
    End Sub

    Private Sub CoronaIndonesiaDetail()
        Dim json As String = (New WebClient).DownloadString("https://api.kawalcorona.com/indonesia/provinsi")
        Dim jarr As Linq.JArray = Linq.JArray.Parse(json)
        Dim sProvinsi, sPositif, sSembuh, sMeninggal As String

        For Each jtk As JToken In jarr
            sProvinsi = jtk.SelectToken("attributes.Provinsi")
            sPositif = jtk.SelectToken("attributes.Kasus_Posi")
            sSembuh = jtk.SelectToken("attributes.Kasus_Semb")
            sMeninggal = jtk.SelectToken("attributes.Kasus_Meni")

            DgvIndo.Rows.Add()
            DgvIndo.Rows(DgvIndo.Rows.Count - 1).Cells("DgvIndoProv").Value = sProvinsi
            DgvIndo.Rows(DgvIndo.Rows.Count - 1).Cells("DgvIndoPositif").Value = Val(sPositif)
            DgvIndo.Rows(DgvIndo.Rows.Count - 1).Cells("DgvIndoSembuh").Value = Val(sSembuh)
            DgvIndo.Rows(DgvIndo.Rows.Count - 1).Cells("DgvIndoMeninggal").Value = Val(sMeninggal)
        Next

    End Sub

    Private Sub CoronalGlobalDetail()
        Dim json As String = (New WebClient).DownloadString("https://api.kawalcorona.com")
        Dim jarr As Linq.JArray = Linq.JArray.Parse(json)
        Dim sNegara, sPositif As String

        For Each jtk As JToken In jarr
            sNegara = jtk.SelectToken("attributes.Country_Region")
            sPositif = jtk.SelectToken("attributes.Confirmed")


            DgvGlobal.Rows.Add()
            DgvGlobal.Rows(DgvGlobal.Rows.Count - 1).Cells("DgvNegara").Value = sNegara
            DgvGlobal.Rows(DgvGlobal.Rows.Count - 1).Cells("DgvConfirmed").Value = Val(sPositif)

        Next

    End Sub







End Class
