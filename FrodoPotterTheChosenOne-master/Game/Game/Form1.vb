Imports System.Threading
Public Class Form1
    Dim T1 As Thread
    Dim x, y As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        T1 = New Thread(AddressOf ThreadProc1)
        T1.Start()
    End Sub
    Sub ThreadProc1()
        x = 800
        While y < Me.Bottom

            PictureBox2.Location = New Point(x, y)
            y = y + 2
            Thread.Sleep(20)
            If y = Me.Bottom Then
                While y > Me.Top
                    PictureBox2.Location = New Point(x, y)
                    y = y - 1
                    Thread.Sleep(20)
                End While
            End If
        End While
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        T1.Abort()
    End Sub
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
        If Asc(e.KeyChar) = 102 Then
            PictureBox3.Left = PictureBox1.Left
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