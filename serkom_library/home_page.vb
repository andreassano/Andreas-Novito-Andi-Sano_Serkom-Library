Public Class home_page

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(241, 245, 249) ' Warna latar belakang aktif
        Button1.ForeColor = Color.FromArgb(7, 28, 77)
        Button1.Font = New Font("Poppins", 12)
        'Button1.Image = My.Resources.users2_darkblue_32x32

        Button2.BackColor = Color.Transparent
        Button2.ForeColor = Color.DimGray
        Button2.Font = New Font("Poppins", 11)
        'Button2.Image = My.Resources.mountain_dimgray_24x24

        Button3.BackColor = Color.Transparent
        Button3.ForeColor = Color.DimGray
        Button3.Font = New Font("Poppins", 11)
        'Button3.Image = My.Resources.trail2_dimgray_24x24

        Button4.BackColor = Color.Transparent
        Button4.ForeColor = Color.DimGray
        Button4.Font = New Font("Poppins", 11)
        'Button4.Image = My.Resources.booking_dimgray_24x24

        user_data.gridUsers()

        Panel3.Controls.Clear()
        user_data.TopLevel = False
        Panel3.Controls.Add(user_data)
        user_data.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.FromArgb(241, 245, 249) ' Warna latar belakang aktif
        Button2.ForeColor = Color.FromArgb(7, 28, 77)
        Button2.Font = New Font("Poppins", 12)
        'Button1.Image = My.Resources.users2_darkblue_32x32

        Button1.BackColor = Color.Transparent
        Button1.ForeColor = Color.DimGray
        Button1.Font = New Font("Poppins", 11)
        'Button2.Image = My.Resources.mountain_dimgray_24x24

        Button3.BackColor = Color.Transparent
        Button3.ForeColor = Color.DimGray
        Button3.Font = New Font("Poppins", 11)
        'Button3.Image = My.Resources.trail2_dimgray_24x24

        Button4.BackColor = Color.Transparent
        Button4.ForeColor = Color.DimGray
        Button4.Font = New Font("Poppins", 11)
        'Button4.Image = My.Resources.booking_dimgray_24x24

        buku_data.gridBuku()


        Panel3.Controls.Clear()
        buku_data.TopLevel = False
        Panel3.Controls.Add(buku_data)
        buku_data.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.BackColor = Color.FromArgb(241, 245, 249) ' Warna latar belakang aktif
        Button3.ForeColor = Color.FromArgb(7, 28, 77)
        Button3.Font = New Font("Poppins", 12)
        'Button1.Image = My.Resources.users2_darkblue_32x32

        Button1.BackColor = Color.Transparent
        Button1.ForeColor = Color.DimGray
        Button1.Font = New Font("Poppins", 11)
        'Button2.Image = My.Resources.mountain_dimgray_24x24

        Button2.BackColor = Color.Transparent
        Button2.ForeColor = Color.DimGray
        Button2.Font = New Font("Poppins", 11)
        'Button3.Image = My.Resources.trail2_dimgray_24x24

        Button4.BackColor = Color.Transparent
        Button4.ForeColor = Color.DimGray
        Button4.Font = New Font("Poppins", 11)
        'Button4.Image = My.Resources.booking_dimgray_24x24

        anggota_data.gridAnggota()


        Panel3.Controls.Clear()
        anggota_data.TopLevel = False
        Panel3.Controls.Add(anggota_data)
        anggota_data.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button4.BackColor = Color.FromArgb(241, 245, 249) ' Warna latar belakang aktif
        Button4.ForeColor = Color.FromArgb(7, 28, 77)
        Button4.Font = New Font("Poppins", 12)
        'Button1.Image = My.Resources.users2_darkblue_32x32

        Button1.BackColor = Color.Transparent
        Button1.ForeColor = Color.DimGray
        Button1.Font = New Font("Poppins", 11)
        'Button2.Image = My.Resources.mountain_dimgray_24x24

        Button2.BackColor = Color.Transparent
        Button2.ForeColor = Color.DimGray
        Button2.Font = New Font("Poppins", 11)
        'Button3.Image = My.Resources.trail2_dimgray_24x24

        Button3.BackColor = Color.Transparent
        Button3.ForeColor = Color.DimGray
        Button3.Font = New Font("Poppins", 11)
        'Button3.Image = My.Resources.trail2_dimgray_24x24

        transaksi_data.gridTransaksi()
        'Users_Data.Timer1.Start()
        'Users_Data.Timer1.Start()
        'Jalur_Pendakian.Timer1.Stop()

        login.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.BackColor = Color.FromArgb(241, 245, 249) ' Warna latar belakang aktif
        Button4.ForeColor = Color.FromArgb(7, 28, 77)
        Button4.Font = New Font("Poppins", 12)
        'Button1.Image = My.Resources.users2_darkblue_32x32

        Button1.BackColor = Color.Transparent
        Button1.ForeColor = Color.DimGray
        Button1.Font = New Font("Poppins", 11)
        'Button2.Image = My.Resources.mountain_dimgray_24x24

        Button2.BackColor = Color.Transparent
        Button2.ForeColor = Color.DimGray
        Button2.Font = New Font("Poppins", 11)
        'Button3.Image = My.Resources.trail2_dimgray_24x24

        Button3.BackColor = Color.Transparent
        Button3.ForeColor = Color.DimGray
        Button3.Font = New Font("Poppins", 11)
        'Button4.Image = My.Resources.booking_dimgray_24x24

        anggota_data.gridAnggota()


        Panel3.Controls.Clear()
        transaksi_data.TopLevel = False
        Panel3.Controls.Add(transaksi_data)
        transaksi_data.Show()
    End Sub
End Class