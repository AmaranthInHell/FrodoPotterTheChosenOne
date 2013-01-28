Public Class Form1
    'vb bug:  if the media player is visible then the key press events are 
    'not detected!

    Inherits System.Windows.Forms.Form
    Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    Dim isLoaded As Boolean 'Flag denoting whether or not a MIDI has been loaded
    Dim isPaused As Boolean 'Flag denoting whether or not the MIDI has been paused
    Dim x, i, rock, a(16) As Integer   'i identifies specific bad guy, rock transfers this identity to explosion sequence
    Dim RES As Integer      'x identifies x coordinates of bad guys when laying them down
    Dim direction As String  'RES is a counter that allows the bad buys to show arms in, arms out like clockwork
    Dim level As Integer     'direction variable hand left vs right movement of badguys
    Dim WhichKey As Integer  'whichkey is used to track left, right keys, & space bar for shooter
    Dim bulx, buly, bulyold As Integer  'This is used to track shooter (good guy) bullets
    Dim gkill, bkill, win, lose As Integer
    Dim quit As Integer
    Dim going As Integer
    Dim leftpostim4, leftpostim5, leftpostim6, leftpostim7, leftpostim8, leftpostim9 As Integer
    Dim klick As Integer


    'Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    'Const VK_A = &H41  'A
    'Const VK_Z = &H54  'Z
    Const VK_LSHIFT = 37  '&HA0
    Const VK_RSHIFT = 39  '&HA1
    'Const VK_LKCONTROL = &HA2
    'Const VK_RKCONTROL = &HA3
    'Const VK_RIGHT = &H27
    'Const VK_LEFT = &H25
    'Const VK_UP = &H26
    'Const VK_DOWN = &H28
    Const VK_SPACE = 32   '&H20
    Const VK_ESC = &H1B
    Dim reset As Boolean = True
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'WhichKey = e.KeyCode                'This section handles movement of the shooter,
        If e.KeyCode = VK_RSHIFT Then      'whichkey records the keycode of which key is
            '                               pressed

            If Shooter.Left > 602 Then
                Shooter.Left = 602
            End If
            Shooter.Left = Shooter.Left + 7
        End If
        If e.KeyCode = VK_LSHIFT Then
            If Shooter.Left < 0 Then
                Shooter.Left = 0
            End If
            Shooter.Left = Shooter.Left - 7
        End If
        If e.KeyCode = VK_SPACE And Shooter.Visible = True Then
            Timer1.Enabled = True
            If line1.Visible = False Then shoot()
            'says if the bullet isn't fired already and is flying it can be fired now
            'sounds like it is shot when it is shot
        End If
        If e.KeyCode = VK_ESC Then
            End
        End If
        If e.KeyCode = VK_ESC Then End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Label6.BackColor = Color.Transparent
        For i = 0 To 6
            ReDim Preserve line2(i)
            ReDim Preserve badBang(i)

            line2(i) = New PictureBox
            line2(i).Text = CStr(i)
            line2(i).Size = line3.Size
            line2(i).Image = line3.Image
            line2(i).Visible = False
            line2(i).BackColor = Color.Transparent
            AddHandler line2(i).Click, AddressOf PictureBox_Click
            Me.Controls.Add(line2(i))
            badBang(i) = New PictureBox
            badBang(i).Text = CStr(i)
            badBang(i).Size = boom6.Size
            badBang(i).Image = boom6.Image
            badBang(i).Visible = False
            badBang(i).BackColor = Color.Transparent

            Me.Controls.Add(badBang(i))
            'MsgBox("hi")
        Next i

        For i = 0 To 15 'makes 10 pictureboxs
            ReDim Preserve bad1(i) 'resizes array for new picturebox
            bad1(i) = New PictureBox 'dynamically creates a new picturebox
            bad1(i).Text = CStr(i) 'assigns an index to the picture which can be seen
            bad1(i).Size = PictureBox1.Size
            bad1(i).Image = PictureBox1.Image
            bad1(i).BackColor = Color.Transparent
            If i < 8 Then
                bad1(i).Location = New Point(x, 25)
                If i = 7 Then x = 0
                x = x + 44
            End If
            If i > 7 Then
                bad1(i).Location = New Point(x - 44, 61)
                x = x + 44
                If i = 15 Then x = 0
            End If
            AddHandler bad1(i).Click, AddressOf PictureBox_Click
            Me.Controls.Add(bad1(i))
        Next i

        isLoaded = True
        bkill = 0       'bkill tracks number of good guys killed
        gkill = 0       'gkill tracks number of bad guys killed
        win = 0         'win tracks number of games won by shooter (the player)
        lose = 0        'lose tracks number of games lost by the shooter (player)
        If isLoaded Then
            playmusic()
        End If
    End Sub
    Private Sub PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pic As PictureBox = DirectCast(sender, PictureBox)
    End Sub
    Sub playmusic()
        AxWindowsMediaPlayer3.URL = "maryhay.mid"
    End Sub
    Sub shoot()
        AxWindowsMediaPlayer1.URL = "missile.WAV"
    End Sub
    Sub bang()
        AxWindowsMediaPlayer2.URL = "colt1.wav"
    End Sub
    Sub boom()
        AxWindowsMediaPlayer4.URL = "explosion2.wav"
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'handles bullets (lines) which are shooter bullets
        Static count As Integer     'up
        Dim i As Integer
        If count = 0 Then
            line1.Visible = True       'This routine allows bullet to be placed first time when
            line1.Location = New Point(Shooter.Left + 15, Shooter.Top - 20)
            bulyold = 300
        End If
        count = count + 1            'count used only to detect when the shooter shoots first
        If count > 1 Then count = 1 'time
        line1.Top = line1.Top - 35
        For i = 0 To 15
            If line1.Left > bad1(i).Left And line1.Left < bad1(i).Left + 40 Then
                If line1.Top > bad1(i).Top - 30 And line1.Top < bad1(i).Top + 40 And line1.Visible = True Then
                    If i > 7 Then                           'above is the detection routine
                        If bad1(i).Visible = True Then       'line1 is the shooter's bullet
                            line1.Visible = False              'can't shoot a bullet until the first
                            bang()                               'bullet goes off screen or hits a bad
                            rock = i                           'guy
                            tim_expl.Enabled = True
                            count = 0                          'the i>7 is for the lower 8 bad guys.
                            Timer1.Enabled = False             'The rock variable is global, it transfers
                        End If                                  'the exact bad guy to blow up to the
                    End If                                 'sequence that shows explosions
                    If i < 8 Then
                        If bad1(i).Visible = True Then
                            If bad1(i + 8).Visible = False Then  'Line checks to see if bad guy below is cleared
                                'If bad1(i).Visible = True Then  'The i<8 code handles the upper 8
                                line1.Visible = False            'bad guys who can only be hit
                                rock = i                         'if the bad guy directly below has
                                bang()                             'already been hit
                                tim_expl.Enabled = True
                                count = 0
                                Timer1.Enabled = False
                            End If
                        End If
                    End If
                End If
            End If
        Next i
        If line1.Top <= 20 Then
            count = 0
            Timer1.Enabled = False
            line1.Visible = False
        End If
    End Sub

    Private Sub Shooter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shooter.Click

    End Sub

    Private Sub timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'hhandles placement of bad guys and if they make it to the ground to authomatically win
        Dim i As Integer
        RES = RES + 1  'global variable, so that positions can be reset
        For i = 0 To 15
            If level = 0 Then direction = "R"
            If bad1(15).Left >= 602 Then direction = "L"
            If RES = 1 Then bad1(i).Image = PictureBox1.Image
            If RES = 3 Then bad1(i).Image = PictureBox2.Image
            If direction = "R" Then
                If i < 8 Then
                    bad1(i).Location = New Point(bad1(i).Left + 10, level * 36 + 25)
                    If i = 7 Then x = 0
                End If
                If i > 7 Then
                    bad1(i).Location = New Point(bad1(i).Left + 10, level * 36 + 61)
                    If bad1(15).Left >= 602 Then
                        level = level + 1
                    End If
                End If
            End If
            If direction = "L" Then
                If i < 8 Then
                    bad1(i).Location = New Point(bad1(i).Left - 10, level * 36 + 25)
                    If i = 7 Then x = 0
                End If
                If i > 7 Then
                    bad1(i).Location = New Point(bad1(i).Left - 10, level * 36 + 61)
                    If bad1(15).Left < 286 Then
                        direction = "R"
                        level = level + 1
                    End If
                End If
            End If
            If bad1(i).Top >= 337 And bad1(i).Visible = True Then
                showWinner("You Lose")
                Timer2.Enabled = False
                gkill = gkill + 1
                lose = lose + 1
                endgame()
                Exit For
            End If
        Next i     'line above says if bad guys get to the bottom they win
        If RES = 4 Then RES = 0
    End Sub
    Private Sub tim_expl_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tim_expl.Tick
        Static klick As Integer  'displays explosions in sequence
        Dim i As Integer
        klick = klick + 1        'handles death of bad guy in klick=4
        boom6.Location = New Point(bad1(rock).Left, bad1(rock).Top)
        If klick = 1 Then
            boom6.Image = boom0.Image
            boom6.Visible = True
        End If
        If klick = 2 Then
            boom6.Image = boom1.Image
        End If
        If klick = 3 Then
            boom6.Image = boom2.Image
        End If
        If klick = 4 Then
            boom6.Image = boom3.Image
            bad1(rock).Visible = False
            bkill = bkill + 1
            Label10.Text = bkill
            If bkill = 16 Then
                win = win + 1
                Label10.Text = bkill
                Label11.Text = gkill
                Label8.Text = win      'win tracks number of games won by shooter (the player)
                Label9.Text = lose     'lose tracks number of games lost by the shooter (player)
                line2(0).Visible = False
                line2(1).Visible = False
                line2(2).Visible = False
                line2(4).Visible = False
                line2(5).Visible = False
                Timer1.Enabled = False
                Timer2.Enabled = False
                showWinner("You Win")
                For i = 1 To 6
                    line1.Visible = False
                    line2(0).Visible = False
                    line2(1).Visible = False
                    line2(2).Visible = False
                    line2(3).Visible = False
                    line2(4).Visible = False
                    line2(5).Visible = False
                Next i
            End If
        End If
        If klick = 5 Then
            boom6.Image = boom4.Image
        End If
        If klick = 6 Then
            boom6.Image = boom5.Image
        End If
        If klick = 7 Then
            boom6.Image = boom4.Image
        End If
        If klick = 8 Then
            boom6.Image = boom5.Image
            tim_expl.Enabled = False
            boom6.Visible = False
            klick = 0
            tim_expl.Enabled = False
        End If
    End Sub
    Private Sub AxWindowsMediaPlayer1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        'bad guy bullets (originally from timer7)
        Static coun As Integer
        Static HAND As String  'TRACKS IF BADIES TO RIGHT OR LEFT SHOULD DROP BOMBS
        'line2(3) goes all the time and handles the movement
        'of the others...everything depends on it...
        If reset = True Then
            coun = 0
            reset = False
        End If
        coun = coun + 1 'timer8 is timer4, 
        'If coun = 1 Then
        If coun = 1 And Timer4.Enabled = False And Timer5.Enabled = False And Timer6.Enabled = False And Timer7.Enabled = False And Timer8.Enabled = False Then
            line2(0).Visible = False
            line2(1).Visible = False
            line2(2).Visible = False
            line2(4).Visible = False
            line2(5).Visible = False
            If Math.Abs(bad1(15).Left - Shooter.Left) < Math.Abs(bad1(9).Left - Shooter.Left) Then HAND = "RIGHT"
            If Math.Abs(bad1(15).Left - Shooter.Left) >= Math.Abs(bad1(9).Left - Shooter.Left) Then HAND = "LEFT"
            'ALL THE OTHER LINES WORK OFF OF THIS
            line2(3).Location = New Point(bad1(15).Left + 9, bad1(15).Top + 27)
            line2(3).Left = bad1(15).Left + 27        'ALL THE OTHER LINES WORK OFF OF THIS

            If HAND = "RIGHT" Then
                If bad1(15).Visible = True Then
                    line2(0).Location = New Point(bad1(15).Left + 9, bad1(15).Top + 27)
                    line2(0).Visible = True
                End If
                If bad1(15).Visible = False Then
                    If bad1(7).Visible = True Then
                        line2(0).Location = New Point(bad1(7).Left + 9, bad1(7).Top + 27)
                        line2(0).Visible = True
                    End If
                End If
                If bad1(14).Visible = True Then
                    line2(1).Location = New Point(bad1(14).Left + 9, bad1(14).Top + 27)
                    line2(1).Visible = True
                End If
                If bad1(14).Visible = False Then
                    If bad1(6).Visible = True Then
                        line2(1).Location = New Point(bad1(6).Left + 9, bad1(6).Top + 27)
                        line2(1).Visible = True
                    End If
                End If
                If bad1(13).Visible = True Then
                    line2(2).Location = New Point(bad1(13).Left + 9, bad1(13).Top + 27)
                    line2(2).Visible = True
                End If
                If bad1(13).Visible = False Then
                    If bad1(5).Visible = True Then
                        line2(2).Location = New Point(bad1(5).Left + 9, bad1(5).Top + 27)
                        line2(2).Visible = True
                    End If
                End If
                If bad1(15).Visible = False And bad1(14).Visible = False And bad1(13).Visible = False And bad1(7).Visible = False And bad1(6).Visible = False And bad1(5).Visible = False Then
                    If bad1(12).Visible = True Then     'shoots the center guys when everyone else is gone
                        line2(5).Location = New Point(bad1(12).Left + 9, bad1(12).Top + 27)
                        line2(5).Visible = True
                    End If
                    If bad1(12).Visible = False Then
                        If bad1(4).Visible = True Then
                            line2(5).Location = New Point(bad1(4).Left + 9, bad1(4).Top + 27)
                            line2(5).Visible = True
                        End If
                    End If
                End If
            End If
            '*****************
            If HAND = "LEFT" Then
                If bad1(8).Visible = True Then
                    line2(0).Location = New Point(bad1(8).Left + 9, bad1(8).Top + 27)
                    line2(0).Visible = True
                End If
                If bad1(8).Visible = False Then
                    If bad1(0).Visible = True Then
                        line2(0).Location = New Point(bad1(0).Left + 9, bad1(0).Top + 27)
                        line2(0).Visible = True
                    End If
                End If
                If bad1(9).Visible = True Then
                    line2(1).Location = New Point(bad1(9).Left + 9, bad1(9).Top + 27)
                    line2(1).Visible = True
                End If
                If bad1(9).Visible = False Then
                    If bad1(1).Visible = True Then
                        line2(1).Location = New Point(bad1(1).Left + 9, bad1(1).Top + 27)
                        line2(1).Visible = True
                    End If
                End If
                If bad1(10).Visible = True Then
                    line2(2).Location = New Point(bad1(10).Left + 9, bad1(10).Top + 27)
                    line2(2).Visible = True
                End If
                If bad1(10).Visible = False Then
                    If bad1(2).Visible = True Then
                        line2(2).Location = New Point(bad1(2).Left + 9, bad1(2).Top + 27)
                        line2(2).Visible = True
                    End If
                End If
            End If
            If bad1(8).Visible = False And bad1(9).Visible = False And bad1(10).Visible = False And bad1(0).Visible = False And bad1(1).Visible = False And bad1(2).Visible = False Then
                If bad1(11).Visible = True Then
                    line2(4).Location = New Point(bad1(11).Left + 9, bad1(11).Top + 27)
                    line2(4).Visible = True
                End If
                If bad1(11).Visible = False Then
                    If bad1(3).Visible = True Then
                        line2(4).Location = New Point(bad1(3).Left + 9, bad1(3).Top + 27)
                        line2(4).Visible = True
                    End If
                End If
            End If
        End If

        '*******************
        'controls movement of lines down

        If line2(0).Top >= 356 Then 'when hits the ground
            leftpostim4 = line2(0).Left
            Timer4.Enabled = True 'explosion is set off
            line2(0).Visible = False
            line2(0).Top = bad1(15).Top + 9
            boom()
        End If
        If line2(1).Top > 356 And line2(1).Visible = True Then
            leftpostim5 = line2(1).Left
            Timer5.Enabled = True 'when they hit bottom
            line2(1).Top = bad1(14).Top + 9
            line2(1).Visible = False
            boom()
        End If
        If line2(2).Top > 356 And line2(2).Visible = True Then
            leftpostim6 = line2(2).Left
            Timer6.Enabled = True 'when they hit bottom
            line2(2).Top = bad1(13).Top + 9
            line2(2).Visible = False
            boom()
        End If
        If line2(3).Top > 356 And line2(3).Visible = True Then
            leftpostim7 = line2(3).Left
            Timer7.Enabled = True 'when they hit bottom
            line2(3).Top = bad1(12).Top + 9
            line2(3).Visible = False
            boom()
        End If
        If line2(4).Top > 356 And line2(4).Visible = True Then
            leftpostim8 = line2(4).Left
            Timer8.Enabled = True
            line2(4).Top = bad1(4).Top + 9
            line2(4).Visible = False
            boom()
        End If
        If line2(5).Top > 356 And line2(5).Visible = True Then
            leftpostim5 = line2(5).Left
            Timer9.Enabled = True
            line2(5).Top = bad1(5).Top + 9
            line2(5).Visible = False
            boom()
        End If
        If line2(0).Top <= 356 And line2(0).Visible = True Then line2(0).Top = line2(0).Top + 9
        If line2(1).Top <= 356 And line2(1).Visible = True Then line2(1).Top = line2(1).Top + 9
        If line2(2).Top <= 356 And line2(2).Visible = True Then line2(2).Top = line2(2).Top + 9
        line2(3).Top = line2(3).Top + 120 ' this line works all the time
        If line2(4).Top <= 356 And line2(4).Visible = True Then line2(4).Top = line2(4).Top + 9
        If line2(5).Top <= 356 And line2(5).Visible = True Then line2(5).Top = line2(5).Top + 9
        'Label12.Text = line2(3).Top & " " & line2(3).Visible
        If line2(3).Top >= 3700 Then coun = 0

    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        'explosion for line1(0)
        Static klick, OLDX, OLDY As Integer
        klick = klick + 1
        If klick = 1 Then
            OLDX = leftpostim4 - 16 'line2(0).Left - 9
            OLDY = 345
            badBang(0).Image = boom0.Image
            badBang(0).Location = New Point(OLDX, OLDY)
            badBang(0).Visible = True
        End If
        If klick = 2 Then
            badBang(0).Image = boom1.Image
            badBang(0).Location = New Point(OLDX, OLDY)
        End If
        If klick = 3 Then
            badBang(0).Image = boom2.Image
            badBang(0).Location = New Point(OLDX, OLDY)
        End If
        If klick = 4 Then
            badBang(0).Image = boom3.Image
            badBang(0).Location = New Point(OLDX, OLDY)
        End If
        If klick = 5 Then
            badBang(0).Image = boom4.Image
            badBang(0).Location = New Point(OLDX, OLDY)
        End If
        If klick = 6 Then
            badBang(0).Image = boom5.Image
            badBang(0).Location = New Point(OLDX, OLDY)
        End If
        If klick = 7 Then
            badBang(0).Image = boom4.Image
            badBang(0).Location = New Point(OLDX, OLDY)
        End If
        If klick = 8 Then
            badBang(0).Image = boom5.Image
            badBang(0).Location = New Point(OLDX, OLDY)
            badBang(0).Visible = False
            klick = 0
            'line2(0).Visible = False
            Timer4.Enabled = False
        End If
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        'explosion for line1(1)
        Static klick, OLDX, OLDY As Integer
        klick = klick + 1
        If klick = 1 Then
            OLDX = leftpostim5 - 16 'line2(1).Left - 9
            OLDY = 345
            badBang(1).Image = boom0.Image
            badBang(1).Location = New Point(OLDX, OLDY)
            badBang(1).Visible = True
        End If
        If klick = 2 Then
            badBang(1).Image = boom1.Image
            badBang(1).Location = New Point(OLDX, OLDY)
        End If
        If klick = 3 Then
            badBang(1).Image = boom2.Image
            badBang(1).Location = New Point(OLDX, OLDY)
        End If
        If klick = 4 Then
            badBang(1).Image = boom3.Image
            badBang(1).Location = New Point(OLDX, OLDY)
        End If
        If klick = 5 Then
            badBang(1).Image = boom4.Image
            badBang(1).Location = New Point(OLDX, OLDY)
        End If
        If klick = 6 Then
            badBang(1).Image = boom5.Image
            badBang(1).Location = New Point(OLDX, OLDY)
        End If
        If klick = 7 Then
            badBang(1).Image = boom4.Image
            badBang(1).Location = New Point(OLDX, OLDY)
        End If
        If klick = 8 Then
            badBang(1).Image = boom5.Image
            badBang(1).Location = New Point(OLDX, OLDY)
            badBang(1).Visible = False
            klick = 0
            Timer5.Enabled = False
        End If
    End Sub

    Private Sub Timer6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer6.Tick
        'explosion for line1(2)
        Static klick, OLDX, OLDY As Integer
        klick = klick + 1
        If klick = 1 Then
            OLDX = leftpostim6 - 16
            OLDY = 345
            badBang(2).Image = boom0.Image
            badBang(2).Location = New Point(OLDX, OLDY)
            badBang(2).Visible = True
        End If
        If klick = 2 Then
            badBang(2).Image = boom1.Image
            badBang(2).Location = New Point(OLDX, OLDY)
        End If
        If klick = 3 Then
            badBang(2).Image = boom2.Image
            badBang(2).Location = New Point(OLDX, OLDY)
        End If
        If klick = 4 Then
            badBang(2).Image = boom3.Image
            badBang(2).Location = New Point(OLDX, OLDY)
        End If
        If klick = 5 Then
            badBang(2).Image = boom4.Image
            badBang(2).Location = New Point(OLDX, OLDY)
        End If
        If klick = 6 Then
            badBang(2).Image = boom5.Image
            badBang(2).Location = New Point(OLDX, OLDY)
        End If
        If klick = 7 Then
            badBang(2).Image = boom4.Image
            badBang(2).Location = New Point(OLDX, OLDY)
        End If
        If klick = 8 Then
            badBang(2).Image = boom5.Image
            badBang(2).Location = New Point(OLDX, OLDY)
            badBang(2).Visible = False
            klick = 0
            Timer6.Enabled = False
        End If
    End Sub

    Private Sub Timer7_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer7.Tick
        'explosion for line1(3)
        Static klick, OLDX, OLDY As Integer
        klick = klick + 1
        If klick = 1 Then
            OLDX = leftpostim7 - 16
            OLDY = 345
            badBang(3).Image = boom0.Image
            badBang(3).Location = New Point(OLDX, OLDY)
            badBang(3).Visible = True
        End If
        If klick = 2 Then
            badBang(3).Image = boom1.Image
            badBang(3).Location = New Point(OLDX, OLDY)
        End If
        If klick = 3 Then
            badBang(3).Image = boom2.Image
            badBang(3).Location = New Point(OLDX, OLDY)
        End If
        If klick = 4 Then
            badBang(3).Image = boom3.Image
            badBang(3).Location = New Point(OLDX, OLDY)
        End If
        If klick = 5 Then
            badBang(3).Image = boom4.Image
            badBang(3).Location = New Point(OLDX, OLDY)
        End If
        If klick = 6 Then
            badBang(3).Image = boom5.Image
            badBang(3).Location = New Point(OLDX, OLDY)
        End If
        If klick = 7 Then
            badBang(3).Image = boom4.Image
            badBang(3).Location = New Point(OLDX, OLDY)
        End If
        If klick = 8 Then
            badBang(3).Image = boom5.Image
            badBang(3).Location = New Point(OLDX, OLDY)
            badBang(3).Visible = False
            klick = 0
            Timer7.Enabled = False
        End If
    End Sub

    Private Sub Timer8_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer8.Tick
        'explosion for line1(4)
        Static klick, OLDX, OLDY As Integer
        klick = klick + 1
        If klick = 1 Then
            OLDX = leftpostim8 - 16
            OLDY = 345
            badBang(4).Image = boom0.Image
            badBang(4).Location = New Point(OLDX, OLDY)
            badBang(4).Visible = True
        End If
        If klick = 2 Then
            badBang(4).Image = boom1.Image
            badBang(4).Location = New Point(OLDX, OLDY)
        End If
        If klick = 3 Then
            badBang(4).Image = boom2.Image
            badBang(4).Location = New Point(OLDX, OLDY)
        End If
        If klick = 4 Then
            badBang(4).Image = boom3.Image
            badBang(4).Location = New Point(OLDX, OLDY)
        End If
        If klick = 5 Then
            badBang(4).Image = boom4.Image
            badBang(4).Location = New Point(OLDX, OLDY)
        End If
        If klick = 6 Then
            badBang(4).Image = boom5.Image
            badBang(4).Location = New Point(OLDX, OLDY)
        End If
        If klick = 7 Then
            badBang(4).Image = boom4.Image
            badBang(4).Location = New Point(OLDX, OLDY)
        End If
        If klick = 8 Then
            badBang(4).Image = boom5.Image
            badBang(4).Location = New Point(OLDX, OLDY)
            badBang(4).Visible = False
            klick = 0
            Timer8.Enabled = False
        End If
    End Sub

    Private Sub Timer9_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer9.Tick
        'explosion for line1(5)
        Static klick, OLDX, OLDY As Integer
        klick = klick + 1
        If klick = 1 Then
            OLDX = leftpostim9 - 16
            OLDY = 345
            badBang(5).Image = boom0.Image
            badBang(5).Location = New Point(OLDX, OLDY)
            badBang(5).Visible = True
        End If
        If klick = 2 Then
            badBang(5).Image = boom1.Image
            badBang(5).Location = New Point(OLDX, OLDY)
        End If
        If klick = 3 Then
            badBang(5).Image = boom2.Image
            badBang(5).Location = New Point(OLDX, OLDY)
        End If
        If klick = 4 Then
            badBang(5).Image = boom3.Image
            badBang(5).Location = New Point(OLDX, OLDY)
        End If
        If klick = 5 Then
            badBang(5).Image = boom4.Image
            badBang(5).Location = New Point(OLDX, OLDY)
        End If
        If klick = 6 Then
            badBang(5).Image = boom5.Image
            badBang(5).Location = New Point(OLDX, OLDY)
        End If
        If klick = 7 Then
            badBang(5).Image = boom4.Image
            badBang(5).Location = New Point(OLDX, OLDY)
        End If
        If klick = 8 Then
            badBang(5).Image = boom5.Image
            badBang(5).Location = New Point(OLDX, OLDY)
            badBang(5).Visible = False
            klick = 0
            Timer9.Enabled = False
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label1.Click

    End Sub

    Private Sub Timer10_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer10.Tick
        'handles when the shooter gets shot and explodes
        klick = klick + 1
        badBang(5).Location = New Point(Shooter.Left, 356)
        If klick = 1 Then
            badBang(5).Image = boom0.Image
            badBang(5).Visible = True
        End If
        If klick = 2 Then
            badBang(5).Image = boom1.Image
        End If
        If klick = 3 Then
            badBang(5).Image = boom2.Image
        End If
        If klick = 4 Then
            badBang(5).Image = boom3.Image
            Shooter.Visible = False
        End If
        If klick = 5 Then
            badBang(5).Image = boom4.Image
        End If
        If klick = 6 Then
            badBang(5).Image = boom5.Image
        End If
        If klick = 7 Then
            badBang(5).Image = boom4.Image
        End If
        If klick = 8 Then
            badBang(5).Image = boom5.Image
            badBang(5).Visible = False
            klick = 0
            Timer10.Enabled = False
            gkill = gkill + 1
            lose = lose + 1
            endgame()
        End If
    End Sub

    Private Sub Timer11_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer11.Tick
        'detects if badguys hit goodguy and counts kills of badguys
        If line2(0).Top > Shooter.Top And line2(0).Visible = True And Shooter.Visible = True Then
            If line2(0).Left > Shooter.Left And line2(0).Left < Shooter.Left + 36 Then
                If Timer10.Enabled = False Then Timer10.Enabled = True
                Exit Sub
            End If
        End If
        If line2(1).Top > Shooter.Top And line2(1).Visible = True And Shooter.Visible = True Then
            If line2(1).Left > Shooter.Left And line2(1).Left < Shooter.Left + 36 Then
                If Timer10.Enabled = False Then Timer10.Enabled = True
                Exit Sub
            End If
        End If

        If line2(2).Top > Shooter.Top And line2(2).Visible = True And Shooter.Visible = True Then
            If line2(2).Left > Shooter.Left And line2(2).Left < Shooter.Left + 36 Then
                If Timer10.Enabled = False Then Timer10.Enabled = True
                Exit Sub
            End If
        End If
        If line2(4).Top > Shooter.Top And line2(4).Visible = True And Shooter.Visible = True Then
            If line2(4).Left > Shooter.Left And line2(4).Left < Shooter.Left + 36 Then
                If Timer10.Enabled = False Then Timer10.Enabled = True
                Exit Sub
            End If
        End If
        If line2(5).Top > Shooter.Top And line2(5).Visible = True And Shooter.Visible = True Then
            If line2(5).Left > Shooter.Left And line2(5).Left < Shooter.Left + 36 Then
                If Timer10.Enabled = False Then Timer10.Enabled = True
                Exit Sub
            End If
        End If
    End Sub
    Sub endgame()

        Label10.Text = bkill 'bkill tracks number of good guys killed
        Label11.Text = gkill 'gkill tracks number of bad guys killed
        Label8.Text = win      'win tracks number of games won by shooter (the player)
        Label9.Text = lose    'lose tracks number of games lost by the shooter (player)
        line1.Visible = False
        line2(0).Visible = False
        line2(1).Visible = False
        line2(2).Visible = False
        line2(4).Visible = False
        line2(5).Visible = False
        Timer11.Enabled = False
        Timer1.Enabled = False
        Timer2.Enabled = False
        'Timer3.Enabled = False
        Timer4.Enabled = False
        Timer5.Enabled = False
        Timer6.Enabled = False
        Timer7.Enabled = False
        Timer8.Enabled = False
        Timer9.Enabled = False
        Timer10.Enabled = False
        tim_expl.Enabled = False
        Dim i As Integer
        For i = 1 To 6
            badBang(i).Visible = False
            line2(i).Visible = False
        Next i
        line1.Visible = False
        boom6.Visible = False
        showWinner("You Lose")
    End Sub
    Private Sub showWinner(ByVal mymessage As String)
        Label6.AutoSize = True
        Label6.Text = mymessage
        Dim formHeight As Integer
        Dim myGraphicImage As Graphics
        Dim myBitmap As Bitmap
        Dim xStartIntSource As Integer
        Dim yStartIntSource As Integer
        Dim BorderW As Integer
        BorderW = (Me.Width - Me.ClientRectangle.Width) / 2
        formHeight = ((Me.Height - Me.ClientRectangle.Height - (2 * BorderW)))
        xStartIntSource = Label6.Left + BorderW + Me.Left + BorderW
        yStartIntSource = Label6.Top + BorderW + Me.Top + formHeight
        Label6.Visible = False
        Application.DoEvents()
        myBitmap = New Bitmap(Label6.Width, Label6.Height)
        myGraphicImage = Graphics.FromImage(myBitmap)
        myGraphicImage.CopyFromScreen(xStartIntSource, yStartIntSource, 0, 0, myBitmap.Size)
        myGraphicImage.Dispose()
        Label6.BackgroundImageLayout = ImageLayout.None
        Label6.BackgroundImage = myBitmap
        Label6.Visible = True
        Application.DoEvents()
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        Dim i As Integer
        reset = True
        Label6.Text = ""
        Label6.Visible = False
        tim_expl.Enabled = False  'This code resets all the variables and allows the
        badBang(0).Visible = False
        badBang(1).Visible = False
        badBang(2).Visible = False
        badBang(3).Visible = False
        badBang(4).Visible = False
        line2(0).Visible = False
        line2(1).Visible = False
        line2(2).Visible = False
        line2(4).Visible = False
        line2(5).Visible = False
        RES = 0
        Timer2.Enabled = True
        Timer3.Enabled = True
        Timer11.Enabled = True
        gkill = 0
        bkill = 0
        Label10.Text = gkill
        Label11.Text = bkill
        direction = ""
        level = 0
        For i = 0 To 15
            If i < 8 Then
                bad1(i).Location = New Point(x, 25)
                bad1(i).Visible = True
                If i = 7 Then x = 0
                x = x + 44
            End If
            If i > 7 Then
                bad1(i).Location = New Point(x - 44, 61)
                bad1(i).Visible = True
                x = x + 44
                If i = 15 Then x = 0
            End If
        Next i
        If Shooter.Visible = False Then
            Shooter.Location = New Point(286, 340)
            Shooter.Visible = True
        End If

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub


    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub TheStoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TheStoryToolStripMenuItem.Click
        Form2.Timer1.Enabled = True
        Form2.Show()
        xstuff = "Long ago in a world far, far away your best friends left you on a planet which was being invaded by aliens.  The bottom line is that you have to shoot all the aliens down before your friends will come back for you.  May the force be with you..."
    End Sub

    Private Sub HowToPlayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HowToPlayToolStripMenuItem.Click
        Form2.Show()
        Form2.Timer1.Enabled = True
        xstuff = "So you wanted help huh?  Well you were the one who wanted to play this game. All I can tell you is hit the space bar a lot (it shoots) and try to hit something.  The escape key quits. Press the right arrow key to go right and the left arrow key to go left. And try not to get hit..."
        Me.Refresh()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Form2.Timer1.Enabled = True
        Form2.Show()
        xstuff = "Space Invaders 2008" & vbCrLf & "Version 2" & vbCrLf & "Written by Jim Krumm" & vbCrLf & "6/10/2009"
    End Sub
End Class
