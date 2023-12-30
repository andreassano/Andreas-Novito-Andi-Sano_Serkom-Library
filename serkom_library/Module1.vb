Imports System.Windows.Forms
Imports System.Data.Odbc
Module Module1

    Public Conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public rd As OdbcDataReader
    Public str As String
    Public dt As DataTable

    'Public currentPage As Integer = 1 ' Halaman saat ini
    'Public rowsPerPage As Integer = 5 ' Jumlah baris per halaman

    Public Sub Koneksi()
        str = "Driver={MySQL ODBC 3.51 Driver}; Database=serkom_library; server=localhost; uid=root"
        Conn = New OdbcConnection(str)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
End Module
