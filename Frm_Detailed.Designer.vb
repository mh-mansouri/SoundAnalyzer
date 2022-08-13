<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Detailed
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Detailed))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.LstBox_Raw_Detailed = New System.Windows.Forms.ListBox
        Me.LstBox_Refined_Details = New System.Windows.Forms.ListBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(285, 368)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(16, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(114, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'LstBox_Raw_Detailed
        '
        Me.LstBox_Raw_Detailed.Font = New System.Drawing.Font("Lucida Bright", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstBox_Raw_Detailed.FormattingEnabled = True
        Me.LstBox_Raw_Detailed.ItemHeight = 15
        Me.LstBox_Raw_Detailed.Location = New System.Drawing.Point(12, 12)
        Me.LstBox_Raw_Detailed.Name = "LstBox_Raw_Detailed"
        Me.LstBox_Raw_Detailed.Size = New System.Drawing.Size(419, 169)
        Me.LstBox_Raw_Detailed.TabIndex = 1
        '
        'LstBox_Refined_Details
        '
        Me.LstBox_Refined_Details.Font = New System.Drawing.Font("Lucida Bright", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstBox_Refined_Details.FormattingEnabled = True
        Me.LstBox_Refined_Details.ItemHeight = 15
        Me.LstBox_Refined_Details.Location = New System.Drawing.Point(12, 187)
        Me.LstBox_Refined_Details.Name = "LstBox_Refined_Details"
        Me.LstBox_Refined_Details.Size = New System.Drawing.Size(419, 169)
        Me.LstBox_Refined_Details.TabIndex = 1
        '
        'Frm_Detailed
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 409)
        Me.Controls.Add(Me.LstBox_Refined_Details)
        Me.Controls.Add(Me.LstBox_Raw_Detailed)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Detailed"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FKR_Detailed Fourier"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents LstBox_Raw_Detailed As System.Windows.Forms.ListBox
    Friend WithEvents LstBox_Refined_Details As System.Windows.Forms.ListBox

End Class
