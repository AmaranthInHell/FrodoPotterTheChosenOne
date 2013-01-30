Imports System.Drawing

Public Class Form1
    Dim G As Graphics
    Dim BBG As Graphics
    Dim sRect As Rectangle
    Dim dRect As Rectangle
    Dim bmp As Bitmap
    Dim BB As Bitmap

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(Dementorister.Image)
    End Sub
End Class
