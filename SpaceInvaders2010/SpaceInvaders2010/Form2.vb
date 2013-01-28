Public Class Form2

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static count As Integer
        Label1.Text = xstuff
        count = count + 1
        If count = 40 Then
            Form1.Refresh()
            Me.Close()
        End If
    End Sub
End Class