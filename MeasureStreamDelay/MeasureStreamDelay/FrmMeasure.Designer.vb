<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeasure
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
        Me.BtnSetRegion = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.bgwCapture = New System.ComponentModel.BackgroundWorker()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnSetRegion
        '
        Me.BtnSetRegion.Location = New System.Drawing.Point(12, 12)
        Me.BtnSetRegion.Name = "BtnSetRegion"
        Me.BtnSetRegion.Size = New System.Drawing.Size(112, 30)
        Me.BtnSetRegion.TabIndex = 0
        Me.BtnSetRegion.Text = "Set Stream Region"
        Me.BtnSetRegion.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(130, 12)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(112, 30)
        Me.BtnStart.TabIndex = 1
        Me.BtnStart.Text = "Start Testing Delay"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(248, 12)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(120, 30)
        Me.BtnStop.TabIndex = 2
        Me.BtnStop.Text = "Stop Testing Delay"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'bgwCapture
        '
        '
        'lblDelay
        '
        Me.lblDelay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelay.Location = New System.Drawing.Point(12, 45)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(356, 315)
        Me.lblDelay.TabIndex = 3
        Me.lblDelay.Text = "Delay: Not recorded"
        Me.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMeasure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 369)
        Me.Controls.Add(Me.lblDelay)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.BtnSetRegion)
        Me.Name = "FrmMeasure"
        Me.Text = "Measure Stream Delay"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSetRegion As System.Windows.Forms.Button
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents BtnStop As System.Windows.Forms.Button
    Friend WithEvents bgwCapture As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblDelay As System.Windows.Forms.Label

End Class
