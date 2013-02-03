Public Class Form2

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Timer1.Enabled = True
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Visible = False
        Form1.Visible = True
        If Me.Visible = False Then
            Form1.Visible = True
        End If
    End Sub


End Class