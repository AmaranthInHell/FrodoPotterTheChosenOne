Imports System.Drawing
Public Class Form1
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim image As New Bitmap("PictureBox3")

        ' Draw the image unaltered with its upper-left corner at (0, 0).
        e.Graphics.DrawImage(image, 0, 0)

        ' Make the destination rectangle 30 percent wider and 
        ' 30 percent taller than the original image. 
        ' Put the upper-left corner of the destination 
        ' rectangle at (150, 20). 
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        Dim destinationRect As New RectangleF( _
            150, _
            20, _
            1.3F * width, _
            1.3F * height)

        ' Draw a portion of the image. Scale that portion of the image 
        ' so that it fills the destination rectangle. 
        Dim sourceRect As New RectangleF(0, 0, 0.75F * width, 0.75F * height)
        e.Graphics.DrawImage( _
            image, _
            destinationRect, _
            sourceRect, _
            GraphicsUnit.Pixel)
    End Sub
End Class
