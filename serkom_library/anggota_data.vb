Imports System.Data.Odbc
Public Class anggota_data

    Private Sub anggota_data_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        Call gridAnggota()

        TextBox1.Text = "Cari Nama, Jenis.."
        TextBox1.ForeColor = Color.Gray
    End Sub

    Public Sub gridAnggota()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from anggota", Conn)
        ds = New DataSet
        cmd = New OdbcCommand("anggota", Conn)
        da.Fill(ds, "anggota")
        Conn.Close()
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
        Conn.Open()

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next

        ' Mengatur AutoGenerateColumns menjadi False
        DataGridView1.AutoGenerateColumns = False

        ' Membersihkan kolom-kolom yang ada (jika ada)
        DataGridView1.Columns.Clear()

        ' Menambahkan kolom-kolom baru dengan header yang Anda tentukan
        Dim kolom1 As New DataGridViewTextBoxColumn()
        kolom1.DataPropertyName = "id_anggota" ' Sesuaikan dengan nama kolom di database
        kolom1.HeaderText = "No" ' Header yang Anda inginkann
        kolom1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom2 As New DataGridViewTextBoxColumn()
        kolom2.DataPropertyName = "nama_anggota" ' Sesuaikan dengan nama kolom di database
        kolom2.HeaderText = "Nama" ' Header yang Anda inginkann
        kolom2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom3 As New DataGridViewTextBoxColumn()
        kolom3.DataPropertyName = "tempat_lahir" ' Sesuaikan dengan nama kolom di database
        kolom3.HeaderText = "Tempat Lahir" ' Header yang Anda inginkann
        kolom3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom4 As New DataGridViewTextBoxColumn()
        kolom4.DataPropertyName = "tgl_lahir" ' Sesuaikan dengan nama kolom di database
        kolom4.HeaderText = "Tanggal Lahir" ' Header yang Anda inginkann
        kolom4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom5 As New DataGridViewTextBoxColumn()
        kolom5.DataPropertyName = "jenis_kelamin" ' Sesuaikan dengan nama kolom di database
        kolom5.HeaderText = "Jenis Kelamin" ' Header yang Anda inginkann
        kolom5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom6 As New DataGridViewTextBoxColumn()
        kolom6.DataPropertyName = "alamat" ' Sesuaikan dengan nama kolom di database
        kolom6.HeaderText = "Alamat" ' Header yang Anda inginkann
        kolom6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom7 As New DataGridViewTextBoxColumn()
        kolom7.DataPropertyName = "tgl_masuk" ' Sesuaikan dengan nama kolom di database
        kolom7.HeaderText = "Tanggal Masuk" ' Header yang Anda inginkann
        kolom7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Menambahkan kolom-kolom ke DataGridView
        DataGridView1.Columns.Add(kolom1)
        DataGridView1.Columns.Add(kolom2)
        DataGridView1.Columns.Add(kolom3)
        DataGridView1.Columns.Add(kolom4)
        DataGridView1.Columns.Add(kolom5)
        DataGridView1.Columns.Add(kolom6)
        DataGridView1.Columns.Add(kolom7)

        DataGridView1.Columns(0).Width = 80 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(1).Width = 120 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(2).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(3).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(4).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(5).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(6).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel

        DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        anggota_input.TopLevel = False
        home_page.Panel3.Controls.Add(anggota_input)
        anggota_input.Show()
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Cari Nama, Jenis.." Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Cari Nama, Jenis.."
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If String.IsNullOrEmpty(TextBox1.Text) Then
            Call gridAnggota()
        Else
            Call Koneksi()
            cmd = New OdbcCommand("SELECT * FROM anggota WHERE nama_anggota LIKE '%" & TextBox1.Text & "%' OR jenis_kelamin LIKE '%" & TextBox1.Text & "%' ORDER BY id_anggota ASC", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Call Koneksi()
                da = New OdbcDataAdapter("SELECT * FROM anggota WHERE nama_anggota LIKE '%" & TextBox1.Text & "%' OR jenis_kelamin LIKE '%" & TextBox1.Text & "%' ORDER BY id_anggota ASC", Conn)
                ds = New DataSet
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                DataGridView1.ReadOnly = True
            Else
                Call gridAnggota()
            End If
        End If
    End Sub
End Class