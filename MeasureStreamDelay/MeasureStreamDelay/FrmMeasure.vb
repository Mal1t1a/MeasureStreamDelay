Imports System.Runtime.InteropServices
Imports System.Windows
Imports Microsoft.Win32

Public Class FrmMeasure
    Public SC As New ScreenShot.ScreenCapture
    Public RNG As New Random
    Public targetColor As Color = Color.Red
    Public startTime As DateTime
    Public endTime As DateTime
    Public loc As Point
    Public siz As Size
    Public isRunning As Boolean = False
    Public isFound As Boolean = False

    Public Function GetDesktopRegion(ByVal LastRegionLocation As Point, ByVal LastRegionSize As Size) As Bitmap
        Dim myrec As New Rectangle(LastRegionLocation, LastRegionSize)
        Dim w, h As Integer
        w = LastRegionSize.Width
        h = LastRegionSize.Height
        Return SC.CaptureDeskTopRectangle(myrec, w, h)
    End Function

    Private Sub BtnSetRegion_Click(sender As Object, e As EventArgs) Handles BtnSetRegion.Click
        If RegionSelector.ShowDialog = Forms.DialogResult.OK Then
            loc = RegionSelector.Location
            siz = RegionSelector.Size
        End If
    End Sub

    Private Sub bgwCapture_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwCapture.DoWork
        Dim bmp As Bitmap = GetDesktopRegion(loc, siz)
        Dim c As Color = bmp.GetPixel(Math.Round(bmp.Width / 2), Math.Round(bmp.Height / 2))
        Dim rr As Integer = Math.Abs(Convert.ToInt32(c.R) - Convert.ToInt32(targetColor.R))
        Dim gg As Integer = Math.Abs(Convert.ToInt32(c.G) - Convert.ToInt32(targetColor.G))
        Dim bb As Integer = Math.Abs(Convert.ToInt32(c.B) - Convert.ToInt32(targetColor.B))
        If rr <= 2 And gg <= 2 And bb <= 2 Then
            isFound = True
        Else
            isFound = False
        End If
        If isFound Then
            endTime = DateTime.Now
        Else
            Debug.WriteLine(String.Format("{0} = {1} ", bmp.GetPixel(Math.Round(bmp.Width / 2), Math.Round(bmp.Height / 2)).ToString, targetColor.ToString))
        End If
        bmp.Dispose()
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        isRunning = True
        isFound = False
        targetColor = Color.FromArgb(RNG.Next(0, 256), RNG.Next(0, 256), RNG.Next(0, 256))
        Me.BackColor = targetColor
        startTime = DateTime.Now
        If Not bgwCapture.IsBusy Then
            bgwCapture.RunWorkerAsync()
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        isRunning = False
    End Sub

    Private Sub bgwCapture_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCapture.RunWorkerCompleted
        If isFound Then
            lblDelay.Text = String.Format("Delay: {0} ms", Math.Round(endTime.Subtract(startTime).TotalMilliseconds))
            isFound = False
            targetColor = Color.FromArgb(RNG.Next(0, 256), RNG.Next(0, 256), RNG.Next(0, 256))
            Me.BackColor = targetColor
            startTime = DateTime.Now
        End If
        If isRunning Then
            bgwCapture.RunWorkerAsync()
        End If
    End Sub
End Class
