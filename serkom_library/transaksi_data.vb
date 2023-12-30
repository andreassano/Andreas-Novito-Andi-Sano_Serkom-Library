Imports System.Data.Odbc
Public Class transaksi_data

    Private Sub transaksi_data_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        Call gridTransaksi()

        TextBox1.Text = "Cari Nama Anggota,.."
        TextBox1.ForeColor = Color.Gray
    End Sub

    Public Sub gridTransaksi()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from transaksi", Conn)
        ds = New DataSet
        cmd = New OdbcCommand("transaksi", Conn)
        da.Fill(ds, "transaksi")
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
        kolom1.DataPropertyName = "id_transaksi" ' Sesuaikan dengan nama kolom di database
        kolom1.HeaderText = "No" ' Header yang Anda inginkann
        kolom1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Dim kolom2 As New DataGridViewTextBoxColumn()
        'kolom2.DataPropertyName = "username" ' Sesuaikan dengan nama kolom di database
        'kolom2.HeaderText = "Nama Petugas" ' Header yang Anda inginkann
        'kolom2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'kolom2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'kolom2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom2 As New DataGridViewTextBoxColumn()
        kolom2.DataPropertyName = "nama_anggota" ' Sesuaikan dengan nama kolom di database
        kolom2.HeaderText = "Nama Aggota" ' Header yang Anda inginkann
        kolom2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom3 As New DataGridViewTextBoxColumn()
        kolom3.DataPropertyName = "judul_buku" ' Sesuaikan dengan nama kolom di database
        kolom3.HeaderText = "Buku Dipinjam" ' Header yang Anda inginkann
        kolom3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom4 As New DataGridViewTextBoxColumn()
        kolom4.DataPropertyName = "tgl_pinjam" ' Sesuaikan dengan nama kolom di database
        kolom4.HeaderText = "Tanggal Pinjam" ' Header yang Anda inginkann
        kolom4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom5 As New DataGridViewTextBoxColumn()
        kolom5.DataPropertyName = "tgl_kembali" ' Sesuaikan dengan nama kolom di database
        kolom5.HeaderText = "Tanggal Kembali" ' Header yang Anda inginkann
        kolom5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom6 As New DataGridViewTextBoxColumn()
        kolom6.DataPropertyName = "status" ' Sesuaikan dengan nama kolom di database
        kolom6.HeaderText = "Status" ' Header yang Anda inginkann
        kolom6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Menambahkan kolom-kolom ke DataGridView
        DataGridView1.Columns.Add(kolom1)
        DataGridView1.Columns.Add(kolom2)
        DataGridView1.Columns.Add(kolom3)
        DataGridView1.Columns.Add(kolom4)
        DataGridView1.Columns.Add(kolom5)
        DataGridView1.Columns.Add(kolom6)

        DataGridView1.Columns(0).Width = 60 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(1).Width = 120 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(2).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(3).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(4).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(5).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel

        DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        transaksi_input.TopLevel = False
        home_page.Panel3.Controls.Add(transaksi_input)
        transaksi_input.Show()
        transaksi_input.tampilNamaAnggota()
        transaksi_input.tampilJudulBuku()
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Cari Nama Anggota,.." Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Cari Nama Anggota,.."
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If String.IsNullOrEmpty(TextBox1.Text) Then
            Call gridTransaksi()
        Else
            Call Koneksi()
            cmd = New OdbcCommand("SELECT * FROM transaksi WHERE nama_anggota LIKE '%" & TextBox1.Text & "%' OR status LIKE '%" & TextBox1.Text & "%' ORDER BY id_transaksi ASC", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Call Koneksi()
                da = New OdbcDataAdapter("SELECT * FROM transaksi WHERE nama_anggota LIKE '%" & TextBox1.Text & "%' OR status LIKE '%" & TextBox1.Text & "%' ORDER BY id_transaksi ASC", Conn)
                ds = New DataSet
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                DataGridView1.ReadOnly = True
            Else
                Call gridTransaksi()
            End If
        End If
    End Sub
End Class