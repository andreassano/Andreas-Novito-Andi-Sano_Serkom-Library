Imports System.Data.Odbc
Public Class transaksi_input


    Private Sub transaksi_input_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Set properti Format DateTimePicker ke Custom
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.Value = DateTime.Now.AddDays(3)

        ' Set properti CustomFormat untuk menampilkan tahun saja (format yyyy)
        DateTimePicker1.CustomFormat = "dd MMMM yyyy"
        DateTimePicker2.CustomFormat = "dd MMMM yyyy"

        Call Koneksi()
        Call tampilNamaAnggota()
        Call tampilJudulBuku()
    End Sub

    Sub Clear()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Sub tampilNamaAnggota()
        Call Koneksi()
        cmd = New OdbcCommand("select nama_anggota from anggota", Conn)
        rd = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item("nama_anggota"))
        Loop
    End Sub

    Sub tampilJudulBuku()
        Call Koneksi()
        cmd = New OdbcCommand("select judul_buku from buku", Conn)
        rd = cmd.ExecuteReader
        ComboBox2.Items.Clear()
        Do While rd.Read
            ComboBox2.Items.Add(rd.Item("judul_buku"))
        Loop
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        transaksi_data.TopLevel = False
        home_page.Panel3.Controls.Add(transaksi_data)
        transaksi_data.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Silahkan Isi Semua Data")
        Else
            Call Koneksi()
            Dim simpan As String = "insert into transaksi values ('""','" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "','Dipinjam')"
            cmd = New OdbcCommand(simpan, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Input Data Berhasil")
            Dim simpan2 As String = "UPDATE buku SET jml_buku = jml_buku - '1' WHERE judul_buku = '" & ComboBox2.Text & "'"
            cmd = New OdbcCommand(simpan2, Conn)
            cmd.ExecuteNonQuery()
            Call transaksi_data.gridTransaksi()
            Call Clear()

            home_page.Panel3.Controls.Clear()
            transaksi_data.TopLevel = False
            home_page.Panel3.Controls.Add(transaksi_data)
            transaksi_data.Show()
        End If
    End Sub
End Class