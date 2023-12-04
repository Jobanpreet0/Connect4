Public Class Form1
    Dim connect(7, 6) As PictureBox
    Dim connectbutton(7) As Button
    Dim counter(7) As Integer
    Dim setdown(7) As Integer
    Dim changego As Boolean = True
    Dim flash As Boolean = True
    Dim column As Integer
    Dim whichplayer As String
    Dim flashconnect(4) As PictureBox
    Dim playcounter As Boolean = True
    Dim theboardisfull As Boolean



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        createimages() 'procedure used to develop the images on screen.

        For h = 1 To 7
            counter(h) = 0
            connectbutton(h).Text = h
            setdown(h) = 0
        Next
        column = 0

    End Sub

    Private Sub createimages()
        connect(1, 1) = EmptyBox1
        connect(1, 2) = EmptyBox2
        connect(1, 3) = EmptyBox3
        connect(1, 4) = EmptyBox4 ' first column
        connect(1, 5) = EmptyBox5
        connect(1, 6) = EmptyBox6

        connect(2, 1) = EmptyBox7
        connect(2, 2) = EmptyBox8
        connect(2, 3) = EmptyBox9
        connect(2, 4) = EmptyBox10 'second column
        connect(2, 5) = EmptyBox11
        connect(2, 6) = EmptyBox12

        connect(3, 1) = EmptyBox13
        connect(3, 2) = EmptyBox14
        connect(3, 3) = EmptyBox15
        connect(3, 4) = EmptyBox16 ' third column
        connect(3, 5) = EmptyBox17
        connect(3, 6) = EmptyBox18

        connect(4, 1) = EmptyBox19
        connect(4, 2) = EmptyBox20
        connect(4, 3) = EmptyBox21
        connect(4, 4) = EmptyBox22 'fourth column
        connect(4, 5) = EmptyBox23
        connect(4, 6) = EmptyBox24

        connect(5, 1) = EmptyBox25
        connect(5, 2) = EmptyBox26
        connect(5, 3) = EmptyBox27
        connect(5, 4) = EmptyBox28 'fifth column
        connect(5, 5) = EmptyBox29
        connect(5, 6) = EmptyBox30

        connect(6, 1) = EmptyBox31
        connect(6, 2) = EmptyBox32
        connect(6, 3) = EmptyBox33
        connect(6, 4) = EmptyBox34  ' sixth column
        connect(6, 5) = EmptyBox35
        connect(6, 6) = EmptyBox36

        connect(7, 1) = EmptyBox37
        connect(7, 2) = EmptyBox38
        connect(7, 3) = EmptyBox39
        connect(7, 4) = EmptyBox40 'seventh column
        connect(7, 5) = EmptyBox41
        connect(7, 6) = EmptyBox42


        connectbutton(1) = Button1
        connectbutton(2) = Button2
        connectbutton(3) = Button3
        connectbutton(4) = Button4
        connectbutton(5) = Button5
        connectbutton(6) = Button6
        connectbutton(7) = Button7

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Buttons(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click
        TmrConnect1.Start()

        column = Val(DirectCast(sender, Button).Text) 'Column to drop coin into

        setdown(column) = 6
        If counter(column) < 6 Then

            counter(column) += 1
            TmrConnect1.Start()


            If changego Then
                changego = False
            Else
                changego = True
            End If
        End If

    End Sub


    Private Sub TmrConnect1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrConnect1.Tick

        For k = 1 To 7
            connectbutton(k).Enabled = False 'making the commandbuttons disabled
        Next

        If changego Then
            connect(column, setdown(column)).Image = Connet4.My.Resources.Resources.BlueDisc 'changing the play-ers go from yellow to red alternately

            connect(column, setdown(column)).BackColor = Color.Blue


        Else
            connect(column, setdown(column)).Image = Connet4.My.Resources.Resources.OrangeDisc

            connect(column, setdown(column)).BackColor = Color.Orange

        End If

        If setdown(column) < 6 Then
            connect(column, setdown(column) + 1).Image = Connet4.My.Resources.Resources.EmptyDisc

            connect(column, setdown(column) + 1).BackColor = Color.DimGray
        End If
        If setdown(column) = counter(column) Then
            TmrConnect1.Stop()

            For k = 1 To 7
                connectbutton(k).Enabled = True 'making the commandbuttons enabled for use
            Next

            'showing which player's turn it is
            If Not changego Then
                lblwinner.Text = "Blue in Play"
                PlayerInControl.Image = Connet4.My.Resources.Resources.BlueDisc
                PlayerInControl.BackColor = Color.Blue

                'playcounter = False
            Else
                lblwinner.Text = "Orange in Play"
                PlayerInControl.Image = Connet4.My.Resources.Resources.OrangeDisc
                PlayerInControl.BackColor = Color.Orange
                ' playcounter = True
            End If
        Else
            setdown(column) -= 1
        End If
        Player1win()

    End Sub

    Private Sub Player1win()
        For j = 1 To 2
            If j = 1 Then
                PlayerInControl.BackColor = Color.Blue

            Else
                PlayerInControl.BackColor = Color.Orange
            End If
            'checking columns vertical line
            For h = 1 To 7
                For k = 1 To 3
                    If connect(h, k).BackColor = PlayerInControl.BackColor And connect(h, k + 1).BackColor = PlayerInControl.BackColor And connect(h, k + 2).BackColor = PlayerInControl.BackColor And connect(h, k + 3).BackColor = PlayerInControl.BackColor Then
                        'enabling the win to flash
                        flashconnect(1) = connect(h, k)
                        flashconnect(2) = connect(h, k + 1)
                        flashconnect(3) = connect(h, k + 2)
                        flashconnect(4) = connect(h, k + 3)
                        lblwinner.Text = "You Won"
                        Tmrflashwin.Start()
                    End If
                Next
            Next
            'checking rows horizontal line
            For k = 1 To 6
                For h = 1 To 4

                    If connect(h, k).BackColor = PlayerInControl.BackColor And connect(h + 1, k).BackColor = PlayerInControl.BackColor And connect(h + 2, k).BackColor = PlayerInControl.BackColor And connect(h + 3, k).BackColor = PlayerInControl.BackColor Then
                        'enabling the win to flash
                        flashconnect(1) = connect(h, k)
                        flashconnect(2) = connect(h + 1, k)
                        flashconnect(3) = connect(h + 2, k)
                        flashconnect(4) = connect(h + 3, k)
                        lblwinner.Text = "You Won"
                        Tmrflashwin.Start()
                    End If
                Next
            Next
            'checking diagional upwards right  h = column k = row
            For k = 1 To 3
                For h = 1 To 4

                    If connect(h, k).BackColor = PlayerInControl.BackColor And connect(h + 1, k + 1).BackColor = PlayerInControl.BackColor And connect(h + 2, k + 2).BackColor = PlayerInControl.BackColor And connect(h + 3, k + 3).BackColor = PlayerInControl.BackColor Then
                        'enabling the win to flash
                        flashconnect(1) = connect(h, k)
                        flashconnect(2) = connect(h + 1, k + 1)
                        flashconnect(3) = connect(h + 2, k + 2)
                        flashconnect(4) = connect(h + 3, k + 3)
                        lblwinner.Text = "You Won"
                        Tmrflashwin.Start()

                    End If
                Next
            Next

            'checking diagional upwards left

            For k = 6 To 4 Step -1
                For h = 1 To 4
                    If connect(h, k).BackColor = PlayerInControl.BackColor And connect(h + 1, k - 1).BackColor = PlayerInControl.BackColor And connect(h + 2, k - 2).BackColor = PlayerInControl.BackColor And connect(h + 3, k - 3).BackColor = PlayerInControl.BackColor Then
                        'enabling the win to flash
                        flashconnect(1) = connect(h, k)
                        flashconnect(2) = connect(h + 1, k - 1)
                        flashconnect(3) = connect(h + 2, k - 2)
                        flashconnect(4) = connect(h + 3, k - 3)
                        lblwinner.Text = "You Won"
                        Tmrflashwin.Start()
                    End If
                Next

            Next
        Next
    End Sub

    Private Sub Tmrflashwin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmrflashwin.Tick

        If flash Then

            flashconnect(1).Image = Connet4.My.Resources.Resources.Blue
            flashconnect(2).Image = Connet4.My.Resources.Resources.Blue
            flashconnect(3).Image = Connet4.My.Resources.Resources.Blue
            flashconnect(4).Image = Connet4.My.Resources.Resources.Blue
            flash = False
        Else

            flashconnect(1).Image = Connet4.My.Resources.Resources.Orange
            flashconnect(2).Image = Connet4.My.Resources.Resources.Orange
            flashconnect(3).Image = Connet4.My.Resources.Resources.Orange
            flashconnect(4).Image = Connet4.My.Resources.Resources.Orange
            flash = True
        End If
        For k = 1 To 7
            connectbutton(k).Enabled = False 'disabling game when won.

        Next
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Dim frm = New Form1               '' Change the class name if necessary
        frm.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form2.Show()
        Visible = False
    End Sub
End Class
