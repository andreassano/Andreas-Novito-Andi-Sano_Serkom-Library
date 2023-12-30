Imports System.Data.Odbc
Public Class anggota_input

    Dim jenisKelamin As String


    Private Sub anggota_input_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        ' Set properti Format DateTimePicker ke Custom
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker2.Format = DateTimePickerFormat.Custom

        ' Set properti CustomFormat untuk menampilkan tahun saja (format yyyy)
        DateTimePicker1.CustomFormat = "dd MMMM yyyy"
        DateTimePicker2.CustomFormat = "dd MMMM yyyy"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        anggota_data.TopLevel = False
        home_page.Panel3.Controls.Add(anggota_data)
        anggota_data.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            jenisKelamin = "L"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            jenisKelamin = "P"
        End If
    End Sub

    Public Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox6.Text = ""
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not String.IsNullOrEmpty(jenisKelamin) Then
            Dim query As String = "INSERT INTO anggota (nama_anggota, tempat_lahir, tgl_lahir, jenis_kelamin, alamat, tgl_masuk) VALUES (?, ?, ?, ?, ?, ?)"

            Using command As New OdbcCommand(query, Conn)
                command.Parameters.AddWithValue("nama_anggota", TextBox1.Text)
                command.Parameters.AddWithValue("tempat_lahir", TextBox2.Text)
                command.Parameters.AddWithValue("tgl_lahir", Format(DateTimePicker1.Value, "yyyy-MM-dd"))
                command.Parameters.AddWithValue("jenis_kelamin", jenisKelamin)
                command.Parameters.AddWithValue("alamat", TextBox6.Text)
                command.Parameters.AddWithValue("tgl_masuk", Format(DateTimePicker2.Value, "yyyy-MM-dd"))

                command.ExecuteNonQuery()
                MessageBox.Show("Data berhasil disimpan.")
                Call clear()
                Call anggota_data.gridAnggota()

                home_page.Panel3.Controls.Clear()
                anggota_data.TopLevel = False
                home_page.Panel3.Controls.Add(anggota_data)
                anggota_data.Show()
            End Using
        Else
            MessageBox.Show("Pilih jenis kelamin terlebih dahulu.")
        End If
    End Sub
End Class