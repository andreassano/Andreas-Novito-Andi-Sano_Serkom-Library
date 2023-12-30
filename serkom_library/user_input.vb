Imports System.Data.Odbc
Public Class user_input

    Public Sub comboRole()
        ComboBox1.Items.Add("admin")
        ComboBox1.Items.Add("user")
    End Sub

    Private Sub user_input_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        Call comboRole()
    End Sub

    Public Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        user_data.TopLevel = False
        home_page.Panel3.Controls.Add(user_data)
        user_data.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Silahkan Isi Semua Data")
        Else
            Call Koneksi()
            Dim simpan As String = "insert into user values ('""','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')"
            cmd = New OdbcCommand(simpan, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Input Data Berhasil")
            Call clear()
            Call user_data.gridUsers()

            home_page.Panel3.Controls.Clear()
            user_data.TopLevel = False
            home_page.Panel3.Controls.Add(user_data)
            user_data.Show()
        End If
    End Sub
End Class