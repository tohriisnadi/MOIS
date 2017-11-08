Imports System.Data
Imports System.Data.Odbc
Imports System
Imports System.IO
Imports System.Net.NetworkInformation

Module ModKoneksi
    Public Koneksi As New OdbcConnection
    Dim KonString As String
    Public kodeOperator As String = "OP0001"
    Public namaOperator As String = "User Test"
    Public FullNameOperator As String = ""
    Public PhoneOperator As String = ""
    Public EmailOperator As String = ""
    Public RoleNameOperator As String = ""

    Public NPWP As String = "XXX/XXX/XXX/XXX"

    Public Akses(100) As String

    Public CompanyName As String = "PT. PIP VALCON"
    Public CompanyAddres1 As String = "Jl. Raya Mangga Dua"
    Public CompanyAddres2 As String = "Komp. Grand Boutique Centre Blok B 50"
    Public CompanyAddres3 As String = "Ancol - Jakarta Utara 13430"
    Public Companytelp As String = "Phone : (62-21) 612 2176 | 6010352 | 6010353 | 6010354"
    Public CompanyEmail As String = "e-mail : info@pipvalcon.com  "

    'Public oDataAksesRule As New DataTable

    Sub BukaKoneksi()
        Koneksi.Close()
        KonString = "DSN=MOIS;UID=sa;PWD=fid123!!;"
        Koneksi.ConnectionString = KonString
        Try
            If Koneksi.State = ConnectionState.Open Then
                Koneksi.Close()
            End If
            Koneksi.Open()
        Catch ex As Exception
            MsgBox("Pesan Error : " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Peringatan !")
        End Try
    End Sub

    Sub TutupKoneksi()
        Try
            Koneksi.Close()
        Catch ex As Exception
            MsgBox("Pesan Error : " & vbCrLf & "Tidak Ada Koneksi Yang Terbuka ! ", MsgBoxStyle.Critical, "Peringatan !")
        End Try
    End Sub

    Function getMacAddress()
        Dim nics() As NetworkInterface =
              NetworkInterface.GetAllNetworkInterfaces
        'MsgBox(nics(0).GetPhysicalAddress.ToString)
        Return nics(0).GetPhysicalAddress.ToString
    End Function
End Module
