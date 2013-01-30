<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Dementorister = New System.Windows.Forms.PictureBox()
        CType(Me.Dementorister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dementorister
        '
        Me.Dementorister.Image = CType(resources.GetObject("Dementorister.Image"), System.Drawing.Image)
        Me.Dementorister.Location = New System.Drawing.Point(292, 12)
        Me.Dementorister.Name = "Dementorister"
        Me.Dementorister.Size = New System.Drawing.Size(510, 393)
        Me.Dementorister.TabIndex = 0
        Me.Dementorister.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 461)
        Me.Controls.Add(Me.Dementorister)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Dementorister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dementorister As System.Windows.Forms.PictureBox

End Class
