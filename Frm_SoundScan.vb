
#Region "References"

Option Compare Text
Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.DateAndTime
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Drawing.Text
Imports System.Security.Permissions
Imports System.Threading
Imports SoundAnalysis

#End Region

Public Class Frm_SoundScan

#Region "API Definition"

    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean
    Private Declare Function SOUNDIS Lib "Port.Dll" () As Integer
    Private Declare Sub SOUNDCAPIN Lib "Port.Dll" ()
    Private Declare Sub SOUNDCAPOUT Lib "Port.Dll" ()
    Private Declare Sub SOUNDIN Lib "Port.Dll" (ByVal A() As Byte, ByVal Gr As Long)
    Private Declare Sub SOUNDOUT Lib "Port.Dll" (ByVal A() As Char, ByVal Gr As Long)
    Private Declare Function SOUNDGETRATE Lib "Port.Dll" () As Integer
    Private Declare Function SOUNDSETRATE Lib "Port.Dll" (ByVal Rate As Long) As Long
    Private Declare Function SOUNDGETBYTES Lib "Port.Dll" () As Integer
    Private Declare Function SOUNDSETBYTES Lib "Port.Dll" (ByVal Rate As Long) As Long

#End Region

#Region "Variables"

    Private WithEvents m_PrintDocument As PrintDocument
    Private Bt_mn As Bitmap
    Private m_PrintBitmap As Bitmap
    Private GRFX As Graphics
    Private Const SRCCOPY As Integer = &HCC0020
    Private _Height As Single = 1
    Private _Width As Single = 1
    Private X_0 As Single = 0
    Private X_1 As Single = 1
    Private X_Unit As Single = 1
    Private Y_0 As Single = 0
    Private Y_1 As Single = 1
    Private Y_Unit As Single = 1
    Private _Heigth_Fourier As Double = 1
    Private _Width_Fourier As Double = 1
    Public _Time_Interval As Single = 100
    Private _Removed_Freq As Double = -1
    Private _Freq_01 As Double = 1
    Private _Freq_02 As Double = 1
    Private _U_B As Decimal = 1
    Private _L_B As Decimal = 0

    Private _Arr_Refined() As PointF
    Private _Rate As Integer = 11025
    Private _Samples() As Byte
    Public _Size As Decimal = 0
    Public _Bits As _Sample_Bit = _Sample_Bit.Mono
    Private _Samples_Refined() As Double
    Public _Arr_Spec() As Double
    Private _Arr_Samples As ArrayList = New ArrayList
    Private _Gain As Single = 1
    Private _Window_Size As Integer
    Private _WindowFilter() As Double
    Private Working As Boolean = False

#End Region

#Region "Enums"

    Public Enum _Sample_Rate
        _11KHz = 11025
        _22KHz = 22050
        _44KHz = 44100
    End Enum

    Public Enum _Sample_Bit
        Mono = 8
        Stereo = 16
    End Enum

#End Region

#Region "Component Events"

    Private Sub Frm_SoundScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cmb_Samples.SelectedIndex = 0
            _Height = PicBox_Signal.Height
            _Width = PicBox_Signal.Width
            X_0 = _Width * 0.1
            X_1 = _Width * 0.9
            Y_0 = _Height * 0.1
            Y_1 = _Height * 0.9
            _Heigth_Fourier = PicBox_Fourier.Height
            _Width_Fourier = PicBox_Fourier.Width

            If _Bits = _Sample_Bit.Mono Then
                Y_Unit = 0.8 * _Height / 256
            Else
                Y_Unit = 0.8 * _Height / 65536
            End If
            TextBox_Filling()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Sub Cmd_Detailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Detailed.Click
        Dim NewF As Frm_Detailed = New Frm_Detailed
        NewF.ShowDialog(Me)
    End Sub

    Private Sub Cmd_Start_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Start_Stop.Click
        Try
            Working = Not Working
            If Working Then
                Call Start()
            Else
                Call _Stop()
            End If
        Catch ex As Exception
            Call _Stop()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Sub Cmb_Samples_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Samples.SelectedIndexChanged
        Try
            Select Case Cmb_Samples.SelectedIndex
                Case 0
                    _Rate = _Sample_Rate._11KHz
                Case 1
                    _Rate = _Sample_Rate._22KHz
                Case 2
                    _Rate = _Sample_Rate._44KHz
            End Select
            SOUNDSETRATE(CLng(_Rate))
            Call TextBox_Filling()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Sub NumUpDown_Freq_01_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Freq_01.ValueChanged
        _Freq_01 = NumUpDown_Freq_01.Value
    End Sub

    Private Sub NumUpDown_Freq_02_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Freq_02.ValueChanged
        _Freq_02 = NumUpDown_Freq_02.Value
    End Sub

    Private Sub NumUpDown_Gain_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Gain.ValueChanged
        _Gain = NumUpDown_Gain.Value
        If _Bits = _Sample_Bit.Mono Then
            Y_Unit = 0.8 * _Height / 256
        Else
            Y_Unit = 0.8 * _Height / 65536
        End If
    End Sub

    Private Sub NumUpDown_Resolution_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Resolution.ValueChanged
        Try
            SOUNDSETBYTES(CLng(NumUpDown_Resolution.Value / 8))
            _Bits = NumUpDown_Resolution.Value
            If _Bits = _Sample_Bit.Mono Then
                Y_Unit = 0.8 * PicBox_Signal.Height / 256
            Else
                Y_Unit = 0.8 * PicBox_Signal.Height / 65536
            End If
            Call TextBox_Filling()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Sub NumUpDown_Removed_Frequency_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Removed_Frequency.ValueChanged
        _Removed_Freq = NumUpDown_Removed_Frequency.Value * _Time_Interval / 1000
        Return
    End Sub

    Private Sub NumUpDown_Timing_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Timing.ValueChanged
        Try
            Tmr_Runner.Interval = CInt(NumUpDown_Timing.Value)
            _Time_Interval = CInt(NumUpDown_Timing.Value)
            Call TextBox_Filling()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Sub NumUpDown_WindowFilter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_WindowFilter.ValueChanged
        ReDim _WindowFilter(NumUpDown_WindowFilter.Value - 1)
        _Window_Size = NumUpDown_WindowFilter.Value
    End Sub

    Private Sub NumUpDown_Lower_Bound_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Lower_Bound.ValueChanged
        _L_B = NumUpDown_Lower_Bound.Value
        If _L_B > _U_B Then
            _L_B = _U_B
        End If
    End Sub

    Private Sub NumUpDown_Upper_Bound_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDown_Upper_Bound.ValueChanged
        _U_B = NumUpDown_Upper_Bound.Value
        If _U_B < _L_B Then _U_B = _L_B
    End Sub

#End Region

#Region "Printing"

    Private Function GetFormImage() As Bitmap
        Dim me_gr As Graphics = Me.CreateGraphics
        Dim bm As New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height, me_gr)
        Dim bm_gr As Graphics = me_gr.FromImage(bm)
        Dim bm_hdc As IntPtr = bm_gr.GetHdc
        me_gr.RotateTransform(180)
        Dim me_hdc As IntPtr = me_gr.GetHdc
        BitBlt(bm_hdc, 0, 0, Me.ClientSize.Width, Me.ClientSize.Height, me_hdc, 0, 0, SRCCOPY)
        me_gr.ReleaseHdc(me_hdc)
        bm_gr.ReleaseHdc(bm_hdc)

        Return bm
    End Function

    Private Sub m_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles m_PrintDocument.PrintPage
        Try
            Dim X As Integer, Y As Integer
            Dim Bt_mn As Bitmap = New Bitmap(400, 35)
            Dim GRFX As Graphics = Graphics.FromImage(Bt_mn)
            'Dim ICO As Icon = New Icon(CurDir() & "\" & "FKR.ICO")
            'GRFX.DrawString("Farzankar Ind Co.FKR-LKS_P_V20" & vbNewLine & "Leakage Test Machine", New Font("Tahoma", 10), Brushes.DarkGoldenrod, New PointF(1, 1))
            'Bt_mn.RotateFlip(RotateFlipType.Rotate90FlipNone)

            m_PrintBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
            e.PageSettings.Landscape = True
            X = e.MarginBounds.X + (e.MarginBounds.Width - m_PrintBitmap.Width) \ 2
            Y = e.MarginBounds.Y + (e.MarginBounds.Height - m_PrintBitmap.Height) \ 2
            e.Graphics.DrawImageUnscaled(m_PrintBitmap, X, Y)

            e.HasMorePages = False
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & "Error Occurred during printing process." & vbNewLine & "Please check your printing settig or the network connection", MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "Timer"

    Private Sub Tmr_Runner_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Runner.Tick
        Try
            If Not Working Then
                Call _Stop()
                Exit Try
            End If
            Call _Data_Capturing()
            Call _Fourier_Transformation()
            Call Picture_Redrawing_Wave(_Samples_Refined)
            Call Draw_Fourier(_Arr_Spec, _Width_Fourier, _Heigth_Fourier / 2)
        Catch ex As Exception
            Call _Stop()
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

#End Region

#Region "User Defiend Functions and Subs"

    Private Sub Start()
        Try
            Working = True
            Cmd_Start_Stop.Text = "Stop"
            Cmb_Samples.Enabled = False
            NumUpDown_Resolution.Enabled = False
            NumUpDown_Timing.Enabled = False
            NumUpDown_WindowFilter.Enabled = False
            Cmd_Detailed.Enabled = False
            Call TextBox_Filling()
            Tmr_Runner.Enabled = Working
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Sub _Stop()
        Try
            Working = False
            Cmd_Start_Stop.Text = "Start"
            Cmb_Samples.Enabled = True
            NumUpDown_Resolution.Enabled = True
            NumUpDown_Timing.Enabled = True
            NumUpDown_WindowFilter.Enabled = True
            Cmd_Detailed.Enabled = True
            Call TextBox_Filling()
            Tmr_Runner.Enabled = Working
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Sub

    Private Function _Data_Capturing() As Boolean
        Try
            Dim I As Integer, J As Integer
            Dim Str_Out As String = ""
            Dim _Sum As Double = 0
            Dim _X_Unit_01 As Single = _Width / _Freq_01
            Dim _X_Unit_02 As Single = _Width / _Freq_02
            Dim _Step_01 As Single = _Width / _Size
            Dim _Temp_01 As Single = 0
            Dim _Temp_02 As Single = 0
            If _Bits = _Sample_Bit.Mono Then
                ReDim _Samples(_Size - 1)
            Else
                ReDim _Samples((_Size * 2) - 1)
            End If
            SOUNDIN(_Samples, CLng(_Size))
            If _Bits = _Sample_Bit.Mono Then
                Str_Out = ""
                ReDim _Samples_Refined(_Size - 2)
                For I = 0 To (UBound(_Samples) - 1)
                    'The Range is amoung 0 to 255
                    _Temp_01 = (I * _Step_01 * 100) Mod (_X_Unit_01 * 100)
                    _Temp_01 = _Temp_01 / (100 * _X_Unit_01)
                    _Temp_02 = (I * _Step_01 * 100) Mod (_X_Unit_02 * 100)
                    _Temp_02 = _Temp_02 / (100 * _X_Unit_02)
                    _Samples_Refined(I) = CDbl(CInt(_Samples(I)) - 128) '+ (Math.Sin(2 * Math.PI * _Temp_01) * 32) + (Math.Sin(2 * Math.PI * _Temp_02) * 32)
                    _Samples_Refined(I) = ((_Samples_Refined(I) / 128) * _Gain) * 128
                Next
            Else
                ReDim _Samples_Refined(_Size - 1)
                Dim _Byte_arr(1) As Byte
                For I = 0 To UBound(_Samples) - 1 Step 2
                    _Byte_arr(0) = _Samples(I)
                    _Byte_arr(1) = _Samples(I + 1)
                    'The Range changed to 0 to 65535
                    _Temp_01 = (I * _Step_01 * 50) Mod (_X_Unit_01 * 100)
                    _Temp_01 = _Temp_01 / (100 * _X_Unit_01)
                    _Temp_02 = (I * _Step_01 * 50) Mod (_X_Unit_02 * 100)
                    _Temp_02 = _Temp_02 / (100 * _X_Unit_02)
                    _Samples_Refined(I / 2) = CDbl(CInt(BitConverter.ToInt16(_Byte_arr, 0))) '+ (Math.Sin(2 * Math.PI * _Temp_01) * 1024) + (Math.Sin(2 * Math.PI * _Temp_02) * 1024)
                    _Samples_Refined(I / 2) = ((_Samples_Refined(I / 2) / 32768) * _Gain) * 32768
                Next
            End If
            'Window Filter Implementing
            ReDim _WindowFilter(_Window_Size - 1)
            For I = 0 To UBound(_Samples_Refined)
                _WindowFilter(I Mod _Window_Size) = _Samples_Refined(I)
                _Sum = 0
                For J = 0 To UBound(_WindowFilter)
                    _Sum += _WindowFilter(J)
                Next
                _Samples_Refined(I) = (_Sum / _Window_Size)
            Next
        Catch ex As Exception
            Call _Stop()
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Function

    Private Function _Fourier_Transformation() As Boolean
        Try
            'Window Filtering
            Dim _I As Integer = 0
            Dim _J As Integer = 0
            Dim _Max As Double = -100
            Dim _Index As Integer = -1
            Dim _Freq_Out As Double = -1
            Dim _PointF As PointF = New PointF(-1, -1)
            Dim _Flag As Boolean = False
            'Fourier Transforming
            _Arr_Spec = SoundAnalysis.FftAlgorithm.Calculate(_Samples_Refined)
            Dim _Arr_Length As Integer = _Arr_Spec.Length
            For _I = 0 To CInt(UBound(_Arr_Spec) * 0.95)
                If (_Size * _I / _Arr_Length >= 0) And (_Size * _I / _Arr_Length < 1) Then
                    _Arr_Spec(_I) = 0
                End If
                If (_Size * _I / _Arr_Length > (_Removed_Freq - 1)) And (_Size * _I / _Arr_Length < (_Removed_Freq + 1)) Then
                    _Arr_Spec(_I) = 0
                End If
                If _Max < _Arr_Spec(_I) Then
                    _Max = _Arr_Spec(_I)
                    _Index = _I
                End If
            Next
            'Lbl_Freq.Text = "M.E. Freq : " & CDbl((_Size * _Index / _Arr_Length) * (1000 / _Time_Interval)).ToString("0.0") & " Hz"
            Return True
        Catch ex As Exception
            Call _Stop()
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "FKR_Sound Scan")
            Return False
        End Try
    End Function

    Private Sub TextBox_Filling()
        Dim Str_Out As String = ""
        If SOUNDIS <> 0 Then
            _Size = (Tmr_Runner.Interval / 1000) * _Rate
            Dim _Arr_Spec_Length As Decimal = Math.Pow(2, Math.Floor(Math.Log(_Size) / Math.Log(2)) + 1)
            Dim _Sample As Decimal = (_Arr_Spec_Length / 2) + 1
            Dim _X_Max As Decimal = CInt(_Size * CSng(_Sample) / CSng(_Arr_Spec_Length))
            _X_Max *= 1000 / _Time_Interval
            Lbl_Frreq1.Text = "x " & CDbl(1000 / _Time_Interval).ToString("0") & " Hz"
            Lbl_Frreq2.Text = "x " & CDbl(1000 / _Time_Interval).ToString("0") & " Hz"
            X_Unit = 0.8 * _Width / _Size
            NumUpDown_Upper_Bound.Maximum = _X_Max
            NumUpDown_Lower_Bound.Maximum = _X_Max * 0.8
            NumUpDown_Upper_Bound.Value = _X_Max
            Str_Out = "Sound Card is Available!" & vbNewLine
            Str_Out &= "Set Recording Rate: " & (SOUNDGETRATE / 1000).ToString("0.000") & "KHz" & vbNewLine
            Str_Out &= "Set Recording Resolution: " & SOUNDGETBYTES * 8 & " Bit" & vbNewLine
            Str_Out &= "Timing Interval : " & Tmr_Runner.Interval & " mSec" & vbNewLine
            Str_Out &= "Sampling process : " & Microsoft.VisualBasic.IIf(Working, "Running", "Stopped") & vbNewLine
            Str_Out &= "Sample No. : " & _Size & vbNewLine
            Str_Out &= "Buffer Size: " & _Size * SOUNDGETBYTES & " Bytes"
        Else
            Str_Out = "No Sound Card found!"
            MsgBox(Str_Out, MsgBoxStyle.Critical)
            End
        End If
        Txt_Info.Text = Str_Out

    End Sub

    Private Function Drawing_Initialize(ByRef GRFX As Graphics) As Boolean
        Try
            GRFX.Clear(Color.WhiteSmoke)
        Catch ex As Exception
        End Try
    End Function

    Private Function Picture_Redrawing_Wave(ByVal _Arr_In() As Double) As Boolean
        Try
            Dim _Draw_Pen As Pen = New Pen(Color.LightGreen, 1)
            Dim X_Slot As Single = 0.8 * PicBox_Signal.Width / 10
            Dim Y_Slot As Single = 0.8 * PicBox_Signal.Height / 10
            Dim I As Integer = 0
            Dim J As Integer = 0
            Dim Sum As Single = 0
            Dim _Arr_PointF() As PointF
            Dim X As Single = 0
            Dim Y As Single = 0
            If _Bits = _Sample_Bit.Mono Then
                For I = 0 To UBound(_Arr_In)
                    _Arr_In(I) = _Arr_In(I) + 128
                Next
            Else
                For I = 0 To UBound(_Arr_In)
                    _Arr_In(I) = _Arr_In(I) + 32768
                Next
            End If

            Bt_mn = New Bitmap(CInt(_Width), CInt(_Height))
            GRFX = Graphics.FromImage(Bt_mn)
            GRFX.Clear(Color.DarkGreen)
            GRFX.DrawLine(Pens.Black, X_0, Y_0, X_0, Y_1)
            GRFX.DrawLine(Pens.Black, X_0, Y_1, X_1, Y_1)
            For I = 1 To 9
                GRFX.DrawLine(_Draw_Pen, X_0, Y_0 + (I * Y_Slot), X_1, Y_0 + (I * Y_Slot))
                GRFX.DrawLine(_Draw_Pen, X_0 + (I * X_Slot), Y_0, X_0 + (I * X_Slot), Y_1)
            Next
            _Draw_Pen.Width = 2.0F
            GRFX.DrawLine(_Draw_Pen, X_0, Y_0 + (5 * Y_Slot), X_1, Y_0 + (5 * Y_Slot))
            GRFX.DrawLine(_Draw_Pen, X_0 + (5 * X_Slot), Y_0, X_0 + (5 * X_Slot), Y_1)
            X_Unit = 0.8 * PicBox_Signal.Width / UBound(_Samples_Refined)

            'Drawing Preparation
            ReDim _Arr_PointF(UBound(_Arr_In))
            For I = 0 To UBound(_Arr_In)
                X = X_0 + (I * X_Unit)
                Y = Y_1 - (_Arr_In(I) * Y_Unit)
                _Arr_PointF(I) = New PointF(X, Y)
            Next
            GRFX.DrawLines(Pens.AntiqueWhite, _Arr_PointF)
            GRFX.Flush()
            PicBox_Signal.Image = Bt_mn
        Catch ex As Exception
            Call _Stop()
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "FKR_Sound Scan")
        End Try
    End Function

    Private Function Draw_Fourier(ByVal _Arr_In() As Double, ByVal _Base_Distance As Single, ByVal _Heigth_Distance As Single) As Boolean
        Try
            Dim _Sample As Decimal = CInt((UBound(_Arr_In) / 2) + 1)
            Dim _Sample_Start As Decimal = _L_B * _Arr_In.Length * _Time_Interval / (_Size * 1000)
            Dim _Sample_End As Decimal = _U_B * _Arr_In.Length * _Time_Interval / (_Size * 1000)
            If _Sample_End > _Sample Then _Sample_End = _Sample
            Dim _Sample_In_Use As Decimal = _Sample_End - _Sample_Start + 1
            If _Sample_In_Use > _Sample Then _Sample_In_Use = _Sample
            Dim _X_Max As Single = _Size * CSng(_Sample) / _Arr_In.Length
            Dim _X_Max_In_Use As Decimal = _Size * CSng(_Sample_In_Use) / _Arr_In.Length
            Dim _X_Step As Double = _Base_Distance * 0.8 / _X_Max
            Dim _X_Step_In_Use As Decimal = _Base_Distance * 0.8 / _X_Max_In_Use
            Dim _Arr_PointF() As PointF
            Dim _Arr_Refined() As PointF
            Dim _Flag As Boolean = False
            Dim _I As Decimal = 0
            Dim _X As Single = 0
            Dim _X_0 As Single = 0.1 * _Base_Distance
            Dim _Y As Single = 0
            Dim _Y_1 As Single = 2 * _Heigth_Distance
            Dim _Y_Unit As Single = 0.9 * _Heigth_Distance
            Dim _Drawing_Pen As Pen = New Pen(Color.Black, 1.8F)
            Dim _Max As Double = -1
            Dim _Index As Integer = -1
            ReDim _Arr_PointF(_Sample_In_Use)
            ReDim _Arr_Refined(_Sample)
            For _I = _Sample_Start To _Sample_End
                If _Max < _Arr_In(_I) Then _Max = _Arr_In(_I)
            Next
            For _I = 0 To UBound(_Arr_Refined)
                _Arr_Refined(_I) = New PointF(CSng(_Size * (_I - _Sample_Start) / _Arr_In.Length), CSng(_Arr_In(_I) / _Max))
            Next
            Bt_mn = New Bitmap(CInt(_Base_Distance), CInt(_Y_1))
            GRFX = Graphics.FromImage(Bt_mn)
            GRFX.DrawLine(_Drawing_Pen, 0, _Heigth_Distance, _Base_Distance, _Heigth_Distance)
            GRFX.DrawLine(_Drawing_Pen, CSng(_Base_Distance * 0.1), 0, CSng(_Base_Distance * 0.1), _Y_1)
            For _I = _Sample_Start To CDbl(_Sample_Start + (_Sample_In_Use * 0.9)) Step CDbl(_Sample_In_Use / 10)
                GRFX.DrawString(((_Size * CSng(_I) / _Arr_In.Length) * 1000 / _Time_Interval).ToString("0") & " Hz", New Font("Arial", 8, FontStyle.Regular), Brushes.AntiqueWhite, CSng(((0.8 * _Base_Distance * (_I - _Sample_Start) / _Sample_In_Use) + 0.1 * _Base_Distance) - 10), CSng(_Y_1 / 2))
            Next
            GRFX.DrawString((_Sample_End * _Size * 1000 / (_Time_Interval * _Arr_In.Length)).ToString("0") & " Hz", New Font("Arial", 8, FontStyle.Regular), Brushes.AntiqueWhite, CSng(0.9 * _Base_Distance - 10), CSng(_Y_1 / 2))
            For _I = Math.Floor(_Sample_Start) To Math.Ceiling(_Sample_End)
                _X = (_Arr_Refined(_I).X * _X_Step_In_Use) + _X_0
                _Y = (_Arr_Refined(_I).Y * _Y_Unit) + _Heigth_Distance
                _Y = _Y_1 - _Y
                _Arr_PointF(_I - _Sample_Start) = New PointF(_X, _Y)
            Next
            If _Arr_PointF(UBound(_Arr_PointF)).X = 0 Then
                _Arr_PointF(UBound(_Arr_PointF)) = _Arr_PointF(UBound(_Arr_PointF) - 1)
            End If
            GRFX.DrawLines(Pens.AntiqueWhite, _Arr_PointF)
            GRFX.Flush()
            PicBox_Fourier.Image = Bt_mn
        Catch ex As Exception
            Call _Stop()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FKR_Fast Fourier Transition Tester")
            Return False
        End Try
    End Function

#End Region

End Class
