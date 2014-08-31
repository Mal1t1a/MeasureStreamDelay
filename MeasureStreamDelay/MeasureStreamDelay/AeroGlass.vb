Module AeroGlass
    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> Public Structure Side
        Public Left As Integer
        Public Right As Integer
        Public Top As Integer
        Public Bottom As Integer
    End Structure

    <Runtime.InteropServices.DllImport("dwmapi.dll")> Public Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarinset As Side) As Integer
    End Function

    Public Sub EnableAeroGlass(ByRef TheForm As Form)
        Try
            TheForm.BackColor = Color.Black 'It must be set to black...
            Dim Side As Side = New Side
            Side.Left = -1
            Side.Right = -1
            Side.Top = -1
            Side.Bottom = -1
            TheForm.ForeColor = Color.White
            Dim result As Integer = DwmExtendFrameIntoClientArea(TheForm.Handle, Side)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DisableAeroGlass(ByRef TheForm As Form)
        Try
            TheForm.BackColor = Color.FromArgb(-986896)
            Dim side As Side = New Side
            side.Left = 1
            side.Right = 1
            side.Top = 1
            side.Bottom = 1
            TheForm.ForeColor = Color.Black
            Dim result As Integer = DwmExtendFrameIntoClientArea(TheForm.Handle, side)
        Catch ex As Exception

        End Try
    End Sub
End Module
