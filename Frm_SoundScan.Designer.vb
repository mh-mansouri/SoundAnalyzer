<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SoundScan
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SoundScan))
        Me.Txt_Info = New System.Windows.Forms.TextBox
        Me.Cmd_Start_Stop = New System.Windows.Forms.Button
        Me.Tmr_Runner = New System.Windows.Forms.Timer(Me.components)
        Me.NumUpDown_Resolution = New System.Windows.Forms.NumericUpDown
        Me.Lbl_resolution = New System.Windows.Forms.Label
        Me.Lbl_Samples = New System.Windows.Forms.Label
        Me.Cmb_Samples = New System.Windows.Forms.ComboBox
        Me.NumUpDown_Timing = New System.Windows.Forms.NumericUpDown
        Me.Lbl_Timing = New System.Windows.Forms.Label
        Me.PicBox_Signal = New System.Windows.Forms.PictureBox
        Me.Lbl_Gain = New System.Windows.Forms.Label
        Me.NumUpDown_Gain = New System.Windows.Forms.NumericUpDown
        Me.Lbl_WindowFilter = New System.Windows.Forms.Label
        Me.NumUpDown_WindowFilter = New System.Windows.Forms.NumericUpDown
        Me.PicBox_Fourier = New System.Windows.Forms.PictureBox
        Me.NumUpDown_Removed_Frequency = New System.Windows.Forms.NumericUpDown
        Me.Lbl_Freq_Remover = New System.Windows.Forms.Label
        Me.Lbl_Freq = New System.Windows.Forms.Label
        Me.Cmd_Detailed = New System.Windows.Forms.Button
        Me.NumUpDown_Freq_01 = New System.Windows.Forms.NumericUpDown
        Me.NumUpDown_Freq_02 = New System.Windows.Forms.NumericUpDown
        Me.Lbl_Frreq1 = New System.Windows.Forms.Label
        Me.Lbl_Frreq2 = New System.Windows.Forms.Label
        Me.Lbl_Lower_Bound = New System.Windows.Forms.Label
        Me.NumUpDown_Lower_Bound = New System.Windows.Forms.NumericUpDown
        Me.Lbl_Upper_Bound = New System.Windows.Forms.Label
        Me.NumUpDown_Upper_Bound = New System.Windows.Forms.NumericUpDown
        CType(Me.NumUpDown_Resolution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Timing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox_Signal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Gain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_WindowFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox_Fourier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Removed_Frequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Freq_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Freq_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Lower_Bound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDown_Upper_Bound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_Info
        '
        Me.Txt_Info.Location = New System.Drawing.Point(12, 12)
        Me.Txt_Info.Multiline = True
        Me.Txt_Info.Name = "Txt_Info"
        Me.Txt_Info.ReadOnly = True
        Me.Txt_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Info.Size = New System.Drawing.Size(260, 100)
        Me.Txt_Info.TabIndex = 0
        '
        'Cmd_Start_Stop
        '
        Me.Cmd_Start_Stop.Location = New System.Drawing.Point(150, 324)
        Me.Cmd_Start_Stop.Name = "Cmd_Start_Stop"
        Me.Cmd_Start_Stop.Size = New System.Drawing.Size(121, 30)
        Me.Cmd_Start_Stop.TabIndex = 1
        Me.Cmd_Start_Stop.Text = "Start"
        Me.Cmd_Start_Stop.UseVisualStyleBackColor = True
        '
        'Tmr_Runner
        '
        '
        'NumUpDown_Resolution
        '
        Me.NumUpDown_Resolution.Increment = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumUpDown_Resolution.Location = New System.Drawing.Point(150, 126)
        Me.NumUpDown_Resolution.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.NumUpDown_Resolution.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumUpDown_Resolution.Name = "NumUpDown_Resolution"
        Me.NumUpDown_Resolution.Size = New System.Drawing.Size(121, 20)
        Me.NumUpDown_Resolution.TabIndex = 2
        Me.NumUpDown_Resolution.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'Lbl_resolution
        '
        Me.Lbl_resolution.AutoSize = True
        Me.Lbl_resolution.Location = New System.Drawing.Point(9, 128)
        Me.Lbl_resolution.Name = "Lbl_resolution"
        Me.Lbl_resolution.Size = New System.Drawing.Size(136, 13)
        Me.Lbl_resolution.TabIndex = 3
        Me.Lbl_resolution.Text = "Recording Resolution (Bit) :"
        '
        'Lbl_Samples
        '
        Me.Lbl_Samples.AutoSize = True
        Me.Lbl_Samples.Location = New System.Drawing.Point(9, 155)
        Me.Lbl_Samples.Name = "Lbl_Samples"
        Me.Lbl_Samples.Size = New System.Drawing.Size(105, 13)
        Me.Lbl_Samples.TabIndex = 3
        Me.Lbl_Samples.Text = "Recording Samples :"
        '
        'Cmb_Samples
        '
        Me.Cmb_Samples.FormattingEnabled = True
        Me.Cmb_Samples.Items.AddRange(New Object() {"11KHz", "22KHz", "44KHz"})
        Me.Cmb_Samples.Location = New System.Drawing.Point(150, 153)
        Me.Cmb_Samples.Name = "Cmb_Samples"
        Me.Cmb_Samples.Size = New System.Drawing.Size(121, 21)
        Me.Cmb_Samples.TabIndex = 4
        Me.Cmb_Samples.Text = "Sample Rate"
        '
        'NumUpDown_Timing
        '
        Me.NumUpDown_Timing.Location = New System.Drawing.Point(150, 181)
        Me.NumUpDown_Timing.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumUpDown_Timing.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUpDown_Timing.Name = "NumUpDown_Timing"
        Me.NumUpDown_Timing.Size = New System.Drawing.Size(121, 20)
        Me.NumUpDown_Timing.TabIndex = 2
        Me.NumUpDown_Timing.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Lbl_Timing
        '
        Me.Lbl_Timing.AutoSize = True
        Me.Lbl_Timing.Location = New System.Drawing.Point(9, 182)
        Me.Lbl_Timing.Name = "Lbl_Timing"
        Me.Lbl_Timing.Size = New System.Drawing.Size(129, 13)
        Me.Lbl_Timing.TabIndex = 3
        Me.Lbl_Timing.Text = "Recording Timing(mSec) :"
        '
        'PicBox_Signal
        '
        Me.PicBox_Signal.BackColor = System.Drawing.Color.DarkGreen
        Me.PicBox_Signal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBox_Signal.Location = New System.Drawing.Point(279, 12)
        Me.PicBox_Signal.Name = "PicBox_Signal"
        Me.PicBox_Signal.Size = New System.Drawing.Size(544, 340)
        Me.PicBox_Signal.TabIndex = 5
        Me.PicBox_Signal.TabStop = False
        '
        'Lbl_Gain
        '
        Me.Lbl_Gain.AutoSize = True
        Me.Lbl_Gain.Location = New System.Drawing.Point(9, 236)
        Me.Lbl_Gain.Name = "Lbl_Gain"
        Me.Lbl_Gain.Size = New System.Drawing.Size(84, 13)
        Me.Lbl_Gain.TabIndex = 3
        Me.Lbl_Gain.Text = "Amplitude Gain :"
        '
        'NumUpDown_Gain
        '
        Me.NumUpDown_Gain.DecimalPlaces = 2
        Me.NumUpDown_Gain.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumUpDown_Gain.Location = New System.Drawing.Point(151, 235)
        Me.NumUpDown_Gain.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumUpDown_Gain.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumUpDown_Gain.Name = "NumUpDown_Gain"
        Me.NumUpDown_Gain.Size = New System.Drawing.Size(120, 20)
        Me.NumUpDown_Gain.TabIndex = 6
        Me.NumUpDown_Gain.Value = New Decimal(New Integer() {10, 0, 0, 65536})
        '
        'Lbl_WindowFilter
        '
        Me.Lbl_WindowFilter.AutoSize = True
        Me.Lbl_WindowFilter.Location = New System.Drawing.Point(9, 209)
        Me.Lbl_WindowFilter.Name = "Lbl_WindowFilter"
        Me.Lbl_WindowFilter.Size = New System.Drawing.Size(103, 13)
        Me.Lbl_WindowFilter.TabIndex = 3
        Me.Lbl_WindowFilter.Text = "Window Filter Size : "
        '
        'NumUpDown_WindowFilter
        '
        Me.NumUpDown_WindowFilter.Location = New System.Drawing.Point(151, 208)
        Me.NumUpDown_WindowFilter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUpDown_WindowFilter.Name = "NumUpDown_WindowFilter"
        Me.NumUpDown_WindowFilter.Size = New System.Drawing.Size(120, 20)
        Me.NumUpDown_WindowFilter.TabIndex = 7
        Me.NumUpDown_WindowFilter.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PicBox_Fourier
        '
        Me.PicBox_Fourier.BackColor = System.Drawing.Color.DarkGreen
        Me.PicBox_Fourier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBox_Fourier.Location = New System.Drawing.Point(12, 360)
        Me.PicBox_Fourier.Name = "PicBox_Fourier"
        Me.PicBox_Fourier.Size = New System.Drawing.Size(811, 340)
        Me.PicBox_Fourier.TabIndex = 5
        Me.PicBox_Fourier.TabStop = False
        '
        'NumUpDown_Removed_Frequency
        '
        Me.NumUpDown_Removed_Frequency.Location = New System.Drawing.Point(151, 262)
        Me.NumUpDown_Removed_Frequency.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumUpDown_Removed_Frequency.Name = "NumUpDown_Removed_Frequency"
        Me.NumUpDown_Removed_Frequency.Size = New System.Drawing.Size(120, 20)
        Me.NumUpDown_Removed_Frequency.TabIndex = 9
        '
        'Lbl_Freq_Remover
        '
        Me.Lbl_Freq_Remover.AutoSize = True
        Me.Lbl_Freq_Remover.Location = New System.Drawing.Point(9, 263)
        Me.Lbl_Freq_Remover.Name = "Lbl_Freq_Remover"
        Me.Lbl_Freq_Remover.Size = New System.Drawing.Size(134, 13)
        Me.Lbl_Freq_Remover.TabIndex = 3
        Me.Lbl_Freq_Remover.Text = "Removed Frequency (Hz) :"
        '
        'Lbl_Freq
        '
        Me.Lbl_Freq.Location = New System.Drawing.Point(25, 334)
        Me.Lbl_Freq.Name = "Lbl_Freq"
        Me.Lbl_Freq.Size = New System.Drawing.Size(10, 10)
        Me.Lbl_Freq.TabIndex = 8
        Me.Lbl_Freq.Text = "Most Effective Frequency"
        Me.Lbl_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lbl_Freq.Visible = False
        '
        'Cmd_Detailed
        '
        Me.Cmd_Detailed.Location = New System.Drawing.Point(12, 324)
        Me.Cmd_Detailed.Name = "Cmd_Detailed"
        Me.Cmd_Detailed.Size = New System.Drawing.Size(114, 30)
        Me.Cmd_Detailed.TabIndex = 1
        Me.Cmd_Detailed.Text = "Detailed"
        Me.Cmd_Detailed.UseVisualStyleBackColor = True
        '
        'NumUpDown_Freq_01
        '
        Me.NumUpDown_Freq_01.DecimalPlaces = 1
        Me.NumUpDown_Freq_01.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUpDown_Freq_01.Location = New System.Drawing.Point(12, 298)
        Me.NumUpDown_Freq_01.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumUpDown_Freq_01.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUpDown_Freq_01.Name = "NumUpDown_Freq_01"
        Me.NumUpDown_Freq_01.Size = New System.Drawing.Size(45, 20)
        Me.NumUpDown_Freq_01.TabIndex = 10
        Me.NumUpDown_Freq_01.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumUpDown_Freq_02
        '
        Me.NumUpDown_Freq_02.DecimalPlaces = 1
        Me.NumUpDown_Freq_02.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUpDown_Freq_02.Location = New System.Drawing.Point(150, 298)
        Me.NumUpDown_Freq_02.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumUpDown_Freq_02.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUpDown_Freq_02.Name = "NumUpDown_Freq_02"
        Me.NumUpDown_Freq_02.Size = New System.Drawing.Size(45, 20)
        Me.NumUpDown_Freq_02.TabIndex = 10
        Me.NumUpDown_Freq_02.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Lbl_Frreq1
        '
        Me.Lbl_Frreq1.AutoSize = True
        Me.Lbl_Frreq1.Location = New System.Drawing.Point(65, 300)
        Me.Lbl_Frreq1.Name = "Lbl_Frreq1"
        Me.Lbl_Frreq1.Size = New System.Drawing.Size(49, 13)
        Me.Lbl_Frreq1.TabIndex = 3
        Me.Lbl_Frreq1.Text = "Freq 01 :"
        '
        'Lbl_Frreq2
        '
        Me.Lbl_Frreq2.AutoSize = True
        Me.Lbl_Frreq2.Location = New System.Drawing.Point(201, 300)
        Me.Lbl_Frreq2.Name = "Lbl_Frreq2"
        Me.Lbl_Frreq2.Size = New System.Drawing.Size(52, 13)
        Me.Lbl_Frreq2.TabIndex = 3
        Me.Lbl_Frreq2.Text = "Freq 02  :"
        '
        'Lbl_Lower_Bound
        '
        Me.Lbl_Lower_Bound.AutoSize = True
        Me.Lbl_Lower_Bound.Location = New System.Drawing.Point(12, 708)
        Me.Lbl_Lower_Bound.Name = "Lbl_Lower_Bound"
        Me.Lbl_Lower_Bound.Size = New System.Drawing.Size(98, 13)
        Me.Lbl_Lower_Bound.TabIndex = 3
        Me.Lbl_Lower_Bound.Text = "Lower Bound (Hz) :"
        '
        'NumUpDown_Lower_Bound
        '
        Me.NumUpDown_Lower_Bound.Location = New System.Drawing.Point(116, 706)
        Me.NumUpDown_Lower_Bound.Name = "NumUpDown_Lower_Bound"
        Me.NumUpDown_Lower_Bound.Size = New System.Drawing.Size(68, 20)
        Me.NumUpDown_Lower_Bound.TabIndex = 10
        '
        'Lbl_Upper_Bound
        '
        Me.Lbl_Upper_Bound.AutoSize = True
        Me.Lbl_Upper_Bound.Location = New System.Drawing.Point(651, 708)
        Me.Lbl_Upper_Bound.Name = "Lbl_Upper_Bound"
        Me.Lbl_Upper_Bound.Size = New System.Drawing.Size(98, 13)
        Me.Lbl_Upper_Bound.TabIndex = 3
        Me.Lbl_Upper_Bound.Text = "Upper Bound (Hz) :"
        '
        'NumUpDown_Upper_Bound
        '
        Me.NumUpDown_Upper_Bound.Location = New System.Drawing.Point(755, 706)
        Me.NumUpDown_Upper_Bound.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUpDown_Upper_Bound.Name = "NumUpDown_Upper_Bound"
        Me.NumUpDown_Upper_Bound.Size = New System.Drawing.Size(68, 20)
        Me.NumUpDown_Upper_Bound.TabIndex = 10
        Me.NumUpDown_Upper_Bound.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Frm_SoundScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 732)
        Me.Controls.Add(Me.NumUpDown_Freq_02)
        Me.Controls.Add(Me.NumUpDown_Upper_Bound)
        Me.Controls.Add(Me.NumUpDown_Lower_Bound)
        Me.Controls.Add(Me.NumUpDown_Freq_01)
        Me.Controls.Add(Me.Cmd_Detailed)
        Me.Controls.Add(Me.Cmd_Start_Stop)
        Me.Controls.Add(Me.NumUpDown_Removed_Frequency)
        Me.Controls.Add(Me.Lbl_Freq)
        Me.Controls.Add(Me.NumUpDown_WindowFilter)
        Me.Controls.Add(Me.NumUpDown_Gain)
        Me.Controls.Add(Me.PicBox_Fourier)
        Me.Controls.Add(Me.PicBox_Signal)
        Me.Controls.Add(Me.Cmb_Samples)
        Me.Controls.Add(Me.Lbl_Samples)
        Me.Controls.Add(Me.Lbl_WindowFilter)
        Me.Controls.Add(Me.Lbl_Upper_Bound)
        Me.Controls.Add(Me.Lbl_Freq_Remover)
        Me.Controls.Add(Me.Lbl_Lower_Bound)
        Me.Controls.Add(Me.Lbl_Frreq2)
        Me.Controls.Add(Me.Lbl_Frreq1)
        Me.Controls.Add(Me.Lbl_Gain)
        Me.Controls.Add(Me.Lbl_Timing)
        Me.Controls.Add(Me.Lbl_resolution)
        Me.Controls.Add(Me.NumUpDown_Timing)
        Me.Controls.Add(Me.NumUpDown_Resolution)
        Me.Controls.Add(Me.Txt_Info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_SoundScan"
        Me.Text = "Sound Scan"
        CType(Me.NumUpDown_Resolution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Timing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox_Signal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Gain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_WindowFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox_Fourier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Removed_Frequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Freq_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Freq_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Lower_Bound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDown_Upper_Bound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txt_Info As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Start_Stop As System.Windows.Forms.Button
    Friend WithEvents Tmr_Runner As System.Windows.Forms.Timer
    Friend WithEvents NumUpDown_Resolution As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lbl_resolution As System.Windows.Forms.Label
    Friend WithEvents Lbl_Samples As System.Windows.Forms.Label
    Friend WithEvents Cmb_Samples As System.Windows.Forms.ComboBox
    Friend WithEvents NumUpDown_Timing As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lbl_Timing As System.Windows.Forms.Label
    Friend WithEvents PicBox_Signal As System.Windows.Forms.PictureBox
    Friend WithEvents Lbl_Gain As System.Windows.Forms.Label
    Friend WithEvents NumUpDown_Gain As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lbl_WindowFilter As System.Windows.Forms.Label
    Friend WithEvents NumUpDown_WindowFilter As System.Windows.Forms.NumericUpDown
    Friend WithEvents PicBox_Fourier As System.Windows.Forms.PictureBox
    Friend WithEvents NumUpDown_Removed_Frequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lbl_Freq_Remover As System.Windows.Forms.Label
    Friend WithEvents Lbl_Freq As System.Windows.Forms.Label
    Friend WithEvents Cmd_Detailed As System.Windows.Forms.Button
    Friend WithEvents NumUpDown_Freq_01 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumUpDown_Freq_02 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lbl_Frreq1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Frreq2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Lower_Bound As System.Windows.Forms.Label
    Friend WithEvents NumUpDown_Lower_Bound As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lbl_Upper_Bound As System.Windows.Forms.Label
    Friend WithEvents NumUpDown_Upper_Bound As System.Windows.Forms.NumericUpDown

End Class
