
Public Module MDL_FFT

#Region "Variable Definition"

    Public REX() As Double 'REX[ ] holds the real part of the frequency domain
    Public IMX() As Double 'IMX[ ] holds the imaginary part of the frequency domain
    Public Const Pi As Double = Math.PI  'Set Constants

#End Region

#Region "Function Definition"

    Public Sub FFT(ByVal N As Integer)
        'THE FAST FOURIER TRANSFORM
        'Upon entry, N% contains the number of points in the DFT, REX[ ] and
        'IMX[ ] contain the real and imaginary parts of the input. Upon return,
        'REX[ ] and IMX[ ] contain the DFT output. All signals run from 0 to N%-1.
        Dim NM1 As Integer, ND2 As Integer
        Dim M As Integer, J As Integer
        Dim I As Integer, K As Integer
        Dim L As Integer, LE As Integer
        Dim LE2 As Integer, JM1 As Integer
        Dim IP As Integer

        Dim TR As Double, TI As Double
        Dim UR As Double, UI As Double
        Dim SR As Double, SI As Double

        NM1 = N - 1
        ND2 = N / 2
        M = CInt(Math.Log(N) / Math.Log(2))
        J = ND2
        For I = 1 To N - 2 'Bit reversal sorting
            If I >= J Then GoTo 1190
            TR = REX(J)
            TI = IMX(J)
            REX(J) = REX(I)
            IMX(J) = IMX(I)
            REX(I) = TR
            IMX(I) = TI
1190:       K = ND2
1200:       If K > J Then GoTo 1240
            J = J - K
            K = K / 2
            GoTo 1200
1240:       J = J + K
        Next I
        For L = 1 To M 'Loop for each stage
            LE = CInt(2 ^ L)
            LE = LE / 2
            UR = 1
            UI = 0
            SR = Math.Cos(Pi / LE2) 'Calculate sine & cosine values
            SI = -Math.Sin(Pi / LE2)
            For J = 1 To LE2 'Loop for each sub DFT
                JM1 = J - 1
                For I = JM1 To NM1 Step LE 'Loop for each butterfly
                    IP% = I + LE2
                    TR = REX(IP) * UR - IMX(IP) * UI 'Butterfly calculation
                    TI = REX(IP) * UI + IMX(IP) * UR
                    REX(IP) = REX(I) - TR
                    IMX(IP) = IMX(I) - TI
                    REX(I) = REX(I) + TR
                    IMX(I) = IMX(I) + TI
                Next I
                TR = UR
                UR = TR * SR - UI * SI
                UI = TR * SI + UI * SR
            Next J
        Next L
    End Sub

#End Region

End Module
