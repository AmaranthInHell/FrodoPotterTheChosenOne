Public Class Form1

    Private Sub Form1_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 97 Then
            PictureBox1.Left = PictureBox1.Left - 15
        ElseIf Asc(e.KeyChar) = 100 Then
            PictureBox1.Left = PictureBox1.Left + 15
        ElseIf Asc(e.KeyChar) = 119 Then
            PictureBox1.Top = PictureBox1.Top - 15
        ElseIf Asc(e.KeyChar) = 115 Then
            PictureBox1.Top = PictureBox1.Top + 15
            If Asc(e.KeyChar) = 32 Then
                Timer1.Enabled = False
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.Left = PictureBox1.Left + 5
    End Sub
End Class