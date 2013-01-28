Public Class Form1

    Private Sub Form1_KeyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 97 Then
            PictureBox1.Left = PictureBox1.Left - 30
        ElseIf Asc(e.KeyChar) = 100 Then
            PictureBox1.Left = PictureBox1.Left + 30
        ElseIf Asc(e.KeyChar) = 119 Then
            PictureBox1.Top = PictureBox1.Top - 30
        ElseIf Asc(e.KeyChar) = 115 Then
            PictureBox1.Top = PictureBox1.Top + 30
            If Asc(e.KeyChar) = 32 Then
                Timer1.Enabled = False
            End If
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        PictureBox1.Left = PictureBox1.Left + 5
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        PictureBox3.Left += 20
        PictureBox3.Left += 20
        PictureBox3.Left += 20
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer2.Enabled = True

    End Sub
End Class