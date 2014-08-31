Public Class RegionSelector
    Dim startpos As Point
    Dim drag As Boolean = False
    Dim dragwidth As Boolean = False
    Dim dragheight As Boolean = False

    Private Sub RegionSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableAeroGlass(Me)
        Me.Location = System.Windows.Forms.Cursor.Position - New Point(125, 125)
        Me.Size = New Size(My.Computer.Screen.WorkingArea.Width / 4, My.Computer.Screen.WorkingArea.Height / 4)
        Me.Opacity = 0.75
        Me.TopMost = True
        Me.BringToFront()
        Me.Text = "You can drag this around"
    End Sub

    Private Sub RegionSelector_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If e.X > (Me.Width - 10) And e.Y > (Me.Height - 10) Then 'bottom right
                System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE
            ElseIf e.X > (Me.Width - 10) And e.Y < 10 Then 'top right
                System.Windows.Forms.Cursor.Current = Cursors.SizeNESW
            ElseIf e.X < 10 And e.Y < 10 Then 'top left
                System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE
            ElseIf e.X < 10 And e.Y > (Me.Height - 10) Then 'bottom left
                System.Windows.Forms.Cursor.Current = Cursors.SizeNESW
            ElseIf e.X < 10 Or e.X > (Me.Width - 10) Then
                System.Windows.Forms.Cursor.Current = Cursors.SizeWE
            ElseIf e.Y < 10 Or e.Y > (Me.Height - 10) Then
                System.Windows.Forms.Cursor.Current = Cursors.SizeNS
            Else
                System.Windows.Forms.Cursor.Current = Cursors.SizeAll
            End If
            startpos = System.Windows.Forms.Cursor.Position - Me.Location
            Select Case System.Windows.Forms.Cursor.Current
                Case Cursors.SizeWE
                    dragwidth = True
                Case Cursors.SizeNS
                    dragheight = True
                Case Cursors.SizeAll
                    drag = True
                Case Else
                    dragwidth = True
                    dragheight = True
            End Select
        End If
    End Sub

    Private Sub RegionSelector_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.X > (Me.Width - 10) And e.Y > (Me.Height - 10) Then 'bottom right
            System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE
        ElseIf e.X > (Me.Width - 10) And e.Y < 10 Then 'top right
            System.Windows.Forms.Cursor.Current = Cursors.SizeNESW
        ElseIf e.X < 10 And e.Y < 10 Then 'top left
            System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE
        ElseIf e.X < 10 And e.Y > (Me.Height - 10) Then 'bottom left
            System.Windows.Forms.Cursor.Current = Cursors.SizeNESW
        ElseIf e.X < 10 Or e.X > (Me.Width - 10) Then
            System.Windows.Forms.Cursor.Current = Cursors.SizeWE
        ElseIf e.Y < 10 Or e.Y > (Me.Height - 10) Then
            System.Windows.Forms.Cursor.Current = Cursors.SizeNS
        Else
            System.Windows.Forms.Cursor.Current = Cursors.SizeAll
        End If
        If drag Then
            Me.Location = System.Windows.Forms.Cursor.Position - startpos
        End If
        If dragwidth Then
            If e.X < 10 Then
                Me.Width = ((Me.Width + Me.Location.X) - System.Windows.Forms.Cursor.Position.X)
                Me.Left = System.Windows.Forms.Cursor.Position.X
            Else
                Me.Width = System.Windows.Forms.Cursor.Position.X - Me.Location.X
            End If
        End If
        If dragheight Then
            If e.Y < 10 Then
                Me.Height = ((Me.Height + Me.Location.Y) - System.Windows.Forms.Cursor.Position.Y)
                Me.Top = System.Windows.Forms.Cursor.Position.Y
            Else
                Me.Height = System.Windows.Forms.Cursor.Position.Y - Me.Location.Y
            End If
        End If
    End Sub

    Private Sub RegionSelector_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            drag = False
            dragwidth = False
            dragheight = False
        End If
    End Sub
End Class