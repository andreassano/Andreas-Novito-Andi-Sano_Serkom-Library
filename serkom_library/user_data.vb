Imports System.Data.Odbc
Public Class user_data

    Private Sub user_data_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Koneksi()
        Call gridUsers()
        TextBox1.Text = "Cari Username, Role"
        TextBox1.ForeColor = Color.Gray
    End Sub

    Public Sub gridUsers()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from user", Conn)
        ds = New DataSet
        cmd = New OdbcCommand("user", Conn)
        da.Fill(ds, "user")
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
        kolom1.DataPropertyName = "id_user" ' Sesuaikan dengan nama kolom di database
        kolom1.HeaderText = "No" ' Header yang Anda inginkann
        kolom1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        kolom1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom2 As New DataGridViewTextBoxColumn()
        kolom2.DataPropertyName = "username" ' Sesuaikan dengan nama kolom di database
        kolom2.HeaderText = "Username" ' Header yang Anda inginkann
        kolom2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim kolom3 As New DataGridViewTextBoxColumn()
        kolom3.DataPropertyName = "password" ' Sesuaikan dengan nama kolom di database
        kolom3.HeaderText = "Password" ' Header yang Anda inginkann
        kolom3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom4 As New DataGridViewTextBoxColumn()
        kolom4.DataPropertyName = "email" ' Sesuaikan dengan nama kolom di database
        kolom4.HeaderText = "Email" ' Header yang Anda inginkann
        kolom4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim kolom5 As New DataGridViewTextBoxColumn()
        kolom5.DataPropertyName = "hak_akses" ' Sesuaikan dengan nama kolom di database
        kolom5.HeaderText = "Role" ' Header yang Anda inginkann
        kolom5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        kolom5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        kolom5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Menambahkan kolom-kolom ke DataGridView
        DataGridView1.Columns.Add(kolom1)
        DataGridView1.Columns.Add(kolom2)
        DataGridView1.Columns.Add(kolom3)
        DataGridView1.Columns.Add(kolom4)
        DataGridView1.Columns.Add(kolom5)

        DataGridView1.Columns(0).Width = 80 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(1).Width = 160 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(2).Width = 120 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(3).Width = 280 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(4).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        'DataGridView1.Columns(5).Width = 140 ' Mengatur lebar kolom pertama menjadi 100 piksel
        DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home_page.Panel3.Controls.Clear()
        user_input.TopLevel = False
        home_page.Panel3.Controls.Add(user_input)
        user_input.Show()
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Cari Username, Role" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Cari Username, Role"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If String.IsNullOrEmpty(TextBox1.Text) Then
                Call gridUsers()
            Else
                Call Koneksi()
                cmd = New OdbcCommand("SELECT * FROM user WHERE username LIKE '%" & TextBox1.Text & "%' OR email LIKE '%" & TextBox1.Text & "%' OR hak_akses LIKE '%" & TextBox1.Text & "%' ORDER BY username ASC", Conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    Call Koneksi()
                    da = New OdbcDataAdapter("SELECT * FROM user WHERE username LIKE '%" & TextBox1.Text & "%' OR email LIKE '%" & TextBox1.Text & "%' OR hak_akses LIKE '%" & TextBox1.Text & "%' ORDER BY username ASC", Conn)
                    ds = New DataSet
                    da.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    DataGridView1.ReadOnly = True
                Else
                    Call gridUsers()
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If String.IsNullOrEmpty(TextBox1.Text) Then
            Call gridUsers()
        Else
            Call Koneksi()
            cmd = New OdbcCommand("SELECT * FROM user WHERE username LIKE '%" & TextBox1.Text & "%' OR hak_akses LIKE '%" & TextBox1.Text & "%' ORDER BY id_user ASC", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Call Koneksi()
                da = New OdbcDataAdapter("SELECT * FROM user WHERE username LIKE '%" & TextBox1.Text & "%' OR hak_akses LIKE '%" & TextBox1.Text & "%' ORDER BY id_user ASC", Conn)
                ds = New DataSet
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                DataGridView1.ReadOnly = True
            Else
                Call gridUsers()
            End If
        End If
    End Sub
End Class