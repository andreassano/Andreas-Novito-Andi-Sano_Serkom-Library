Imports System.Data.Odbc
Public Class buku_data

    Private Sub buku_data_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        Call gridBuku()

        TextBox1.Text = "Cari Judul Buku,.."
        TextBox1.ForeColor = Color.Gray
    End Sub

    Public Sub gridBuku()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from buku", Conn)
        ds = New DataSet
        cmd = New OdbcCommand("buku", Conn)
        da.Fill(ds, "buku")
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
        kolom1.DataPropertyName = "id_buku" ' Sesuaikan dengan nama kolom di database
        kolom1.HeaderText = "No" ' Header yang Anda inginkann
        kolom1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom1.HeaderCell.Style.Alignment = Font.Bold

        Dim kolom2 As New DataGridViewTextBoxColumn()
        kolom2.DataPropertyName = "judul_buku" ' Sesuaikan dengan nama kolom di database
        kolom2.HeaderText = "Judul Buku" ' Header yang Anda inginkann
        kolom2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom3 As New DataGridViewTextBoxColumn()
        kolom3.DataPropertyName = "pengarang" ' Sesuaikan dengan nama kolom di database
        kolom3.HeaderText = "Pengarang" ' Header yang Anda inginkann
        kolom3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom4 As New DataGridViewTextBoxColumn()
        kolom4.DataPropertyName = "penerbit" ' Sesuaikan dengan nama kolom di database
        kolom4.HeaderText = "Penerbit" ' Header yang Anda inginkann
        kolom4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom5 As New DataGridViewTextBoxColumn()
        kolom5.DataPropertyName = "thn_terbit" ' Sesuaikan dengan nama kolom di database
        kolom5.HeaderText = "Tahun Terbit" ' Header yang Anda inginkann
        kolom5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom6 As New DataGridViewTextBoxColumn()
        kolom6.DataPropertyName = "jml_buku" ' Sesuaikan dengan nama kolom di database
        kolom6.HeaderText = "Jumlah" ' Header yang Anda inginkann
        kolom6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom7 As New DataGridViewTextBoxColumn()
        kolom7.DataPropertyName = "tgl_input" ' Sesuaikan dengan nama kolom di database
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
        DataGridView1.Columns(1).Width = 160 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(2).Width = 160 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(3).Width = 160 ' Mengatur lebar kolom pertama menjadi 100 piksel
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
        buku_input.TopLevel = False
        home_page.Panel3.Controls.Add(buku_input)
        buku_input.Show()
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Cari Judul Buku,.." Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Cari Judul Buku,.."
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If String.IsNullOrEmpty(TextBox1.Text) Then
            Call gridBuku()
        Else
            Call Koneksi()
            cmd = New OdbcCommand("SELECT * FROM buku WHERE judul_buku LIKE '%" & TextBox1.Text & "%' OR thn_terbit LIKE '%" & TextBox1.Text & "%' ORDER BY id_buku ASC", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Call Koneksi()
                da = New OdbcDataAdapter("SELECT * FROM buku WHERE judul_buku LIKE '%" & TextBox1.Text & "%' OR thn_terbit LIKE '%" & TextBox1.Text & "%' ORDER BY id_buku ASC", Conn)
                ds = New DataSet
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                DataGridView1.ReadOnly = True
            Else
                Call gridBuku()
            End If
        End If
    End Sub
End Class