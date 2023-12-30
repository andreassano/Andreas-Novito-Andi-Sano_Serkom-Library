Imports System.Data.Odbc
Public Class login

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Sub Login()
        Koneksi()
        cmd = New OdbcCommand("select * from user where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            If rd("hak_akses") = "admin" Then
                MsgBox("Selamat Datang Admin")
                home_page.Show()
                Me.Hide()
                buku_data.Button1.Enabled = True
                user_data.Button1.Enabled = True
                anggota_data.Button1.Enabled = True
                transaksi_data.Button1.Enabled = True
            End If
            If rd("hak_akses") = "user" Then
                MsgBox("Selamat Datang User")
                home_page.Show()
                Me.Hide()
                buku_data.Button1.Enabled = False
                user_data.Button1.Enabled = False
                anggota_data.Button1.Enabled = False
                transaksi_data.Button1.Enabled = False
            End If
        Else
            MsgBox("Username atau Password salah")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Login()
        Call clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        TextBox1.Focus()
    End Sub
End Class