Imports System.Data.Odbc
Public Class buku_input

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        buku_data.TopLevel = False
        home_page.Panel3.Controls.Add(buku_data)
        buku_data.Show()
    End Sub

    Public Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        DateTimePicker1.Text = ""
    End Sub

    Private Sub buku_input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set properti Format DateTimePicker ke Custom
        DateTimePicker1.Format = DateTimePickerFormat.Custom

        ' Set properti CustomFormat untuk menampilkan tahun saja (format yyyy)
        DateTimePicker1.CustomFormat = "dd MMMM yyyy"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Silahkan Isi Semua Data")
        Else
            Call Koneksi()
            Dim simpan As String = "INSERT INTO buku VALUES ('""','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox6.Text & "','" & TextBox5.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
            cmd = New OdbcCommand(simpan, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Input Data Berhasil")
            Call clear()
            Call buku_data.gridBuku()

            home_page.Panel3.Controls.Clear()
            buku_data.TopLevel = False
            home_page.Panel3.Controls.Add(buku_data)
            buku_data.Show()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        ' Memeriksa apakah karakter yang dimasukkan adalah angka atau karakter khusus lainnya
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Mengabaikan karakter yang bukan angka
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        
    End Sub
End Class