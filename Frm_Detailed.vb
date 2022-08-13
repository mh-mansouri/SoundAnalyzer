Imports System.Windows.Forms

Public Class Frm_Detailed

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Frm_Detailed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim _I As Integer, _Index As Integer = -1
            Dim _J As Integer = 0
            Dim _Max As Double = -1000
            Dim _PointF As PointF = New PointF(-1, -1)
            Dim _Arr_Refined() As PointF
            Dim _Flag As Boolean = False
            For _I = 0 To UBound(Frm_SoundScan._Arr_Spec) - (UBound(Frm_SoundScan._Arr_Spec) * 0.05)
                If _Max < Frm_SoundScan._Arr_Spec(_I) Then
                    _Max = Frm_SoundScan._Arr_Spec(_I)
                    _Index = _I
                End If
            Next
            LstBox_Raw_Detailed.Items.Clear()
            LstBox_Raw_Detailed.Items.Add("Raw FFT Array")
            LstBox_Raw_Detailed.Items.Add("No. : " & vbTab & vbTab & "Value")
            For _I = 0 To (CInt(UBound(Frm_SoundScan._Arr_Spec) / 2) + 1)
                LstBox_Raw_Detailed.Items.Add(_I & " : " & vbTab & vbTab & (Frm_SoundScan._Arr_Spec(_I) * 100 / _Max).ToString("0.00") & " %")
            Next
            ReDim _Arr_Refined((CInt(UBound(Frm_SoundScan._Arr_Spec) / 2) + 1))
            For _I = 0 To UBound(_Arr_Refined)
                _Arr_Refined(_I) = New PointF(CSng((Frm_SoundScan._Size * _I) / (Frm_SoundScan._Arr_Spec.Length)), CSng(Frm_SoundScan._Arr_Spec(_I) * 100 / _Max))
            Next
            LstBox_Refined_Details.Items.Clear()
            LstBox_Refined_Details.Items.Add("Refined Information")
            LstBox_Refined_Details.Items.Add("Frequency : " & vbTab & "Effective Value")
            For _I = 0 To UBound(_Arr_Refined) - 1
                _Flag = False
                For _J = _I + 1 To UBound(_Arr_Refined)
                    If _Arr_Refined(_J).Y > _Arr_Refined(_I).Y Then
                        _PointF = _Arr_Refined(_I)
                        _Arr_Refined(_I) = _Arr_Refined(_J)
                        _Arr_Refined(_J) = _PointF
                        _Flag = True
                    End If
                Next
                If Not _Flag Then Exit For
            Next
            For _I = 0 To UBound(_Arr_Refined)
                LstBox_Refined_Details.Items.Add(_Arr_Refined(_I).X.ToString("0000.0") & "   x" & (1000 / Frm_SoundScan._Time_Interval).ToString("0") & " Hz : " & vbTab & vbTab & _Arr_Refined(_I).Y.ToString("0.00") & " %")
            Next
            Return
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "FKR_Fast Fourier Transition Tester")
            Return
        End Try
    End Sub

End Class
