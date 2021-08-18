Option Explicit On


Public Class Form1


    Dim mulc As Boolean = False '是否多色

    ' Dim Nlen As Integer


    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
        Tfont = New Font("黑体", 108, FontStyle.Bold)
        Tbrush = New SolidBrush(Color.White)
        Call DrawCard(CDNAME)
    End Sub

    Private Sub TxtCost_TextChanged(sender As Object, e As EventArgs)
        'GcP.DrawString(TxtCost.Text,)
        '费用使用特殊表示元素，不使用文字

        mulc = False
        '
    End Sub
    'Private Sub TxtCost_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) _
    '        Or e.KeyChar = "E" Or e.KeyChar = "F" Or e.KeyChar = "G" Or e.KeyChar = "T" Or e.KeyChar = "M" Then
    '        'e.Handled = True
    '    Else
    '        e.Handled = True
    '    End If
    '    If e.KeyChar = "E" Or e.KeyChar = "F" Or e.KeyChar = "G" Or e.KeyChar = "T" Or e.KeyChar = "M" Then '阵营输入与关联变量
    '        poc += 1
    '    End If
    '    If e.KeyChar = Chr(8) Then '消去阵营
    '        If Char.IsLetter(Microsoft.VisualBasic.Right(TxtCost.Text, 1)) Then
    '            poc -= 1
    '        End If
    '    End If
    'End Sub

    Private Sub TxtMP_TextChanged(sender As Object, e As EventArgs) Handles TxtMP.TextChanged
        Sfont = New Font("黑体", 96, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.Blue)
        Call DrawCard(MP)
    End Sub

    Private Sub TxtATK_TextChanged(sender As Object, e As EventArgs) Handles TxtATK.TextChanged
        Sfont = New Font("黑体", 96, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.DarkRed)
        Call DrawCard(ATK)
    End Sub

    Private Sub TxtDEF_TextChanged(sender As Object, e As EventArgs) Handles TxtDEF.TextChanged
        Sfont = New Font("黑体", 96, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.Green)
        Call DrawCard(DEF)
    End Sub
    Private Sub TxtPicAddress_Click(sender As Object, e As EventArgs) Handles TxtPicAddress.Click
        If TxtPicAddress.Text = INITXTCPA Then
            TxtPicAddress.Text = ""
        End If
    End Sub


    Private Sub TxtEffect_TextChanged(sender As Object, e As EventArgs) Handles TxtEffect.TextChanged
        Sfont = New Font("黑体", 60, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.Black)

        Call DrawCard(EFF)
    End Sub

    Private Sub TxtDescribe_TextChanged(sender As Object, e As EventArgs) Handles TxtDescribe.TextChanged

    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        If OFDCardIPic.ShowDialog() = DialogResult.OK Then
            CdP = New Bitmap(OFDCardIPic.FileName) '读入卡图
            TxtPicAddress.Text = OFDCardIPic.FileName
            Call DrawCard(CARD)
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OFDCardIPic.Filter = "Pictures(*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files(*.*)|*.*"
        OFDCardIPic.FilterIndex = 1
        OFDCardIPic.InitialDirectory = Application.StartupPath
        OFDCardIPic.RestoreDirectory = False

        CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB.png")
        CdB4C = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-O.png")
        BwP = New Bitmap(CdB)
        BwP4C = New Bitmap(CdB4C)

        PicCard.Image = CdB

        'GbW = Graphics.FromImage(CdB)
        'GbP = Graphics.FromImage(CdB)
        '----------------------------------------
        '添加费用板
        costBoardPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\C-BG-D.png")
        'costBoardGraph = Graphics.FromImage(costBoardPic)

        Dim costDrawRect As New Rectangle(COSTX, COSTY, costBoardPic.Width / 2, costBoardPic.Height / 2)
        GwP = Graphics.FromImage(BwP)
        GwP.DrawImage(costBoardPic, costDrawRect)
        GwP.Dispose()
        OtB = New Bitmap(BwP)
        PicCard.Image = OtB

    End Sub

    Private Sub CmdAddPic_Click(sender As Object, e As EventArgs) Handles CmdAddPic.Click
        Try
            CdP = New Bitmap(TxtPicAddress.Text)
        Catch ex As Exception
            MsgBox("请输入正确的文件地址！")
            Exit Sub
        End Try
        CdP = New Bitmap(TxtPicAddress.Text)

        Call DrawCard(CARD)

    End Sub

    Private Sub TxtHP_TextChanged(sender As Object, e As EventArgs) Handles TxtHP.TextChanged
        Sfont = New Font("黑体", 96, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.Red)
        Call DrawCard(HP)
    End Sub

    Private Sub TxtHP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtHP.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub PicCard_Click(sender As Object, e As EventArgs) Handles PicCard.Click

    End Sub

    Private Sub TxtEffect_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtEffect.KeyPress
        Sfont = New Font("黑体", 60, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.Black)

        Dim tempG As Graphics = Graphics.FromImage(BwP)
        Dim maxLen As Integer = tempG.MeasureString(FLL & SLL & TLL & QLL & CLL, Sfont).Width
        Dim txtLen As Integer = tempG.MeasureString(TxtEffect.Text, Sfont).Width
        If txtLen <= maxLen Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    'checks and txts
    Private Sub ChkE_CheckedChanged(sender As Object, e As EventArgs) Handles ChkE.CheckedChanged
        If ChkE.Checked = True Then
            TxtE.Enabled = True
            DrawCost(0)
        Else
            TxtE.Enabled = False
            ClearCost(0)
        End If
    End Sub

    Private Sub ChkG_CheckedChanged(sender As Object, e As EventArgs) Handles ChkG.CheckedChanged
        If ChkG.Checked = True Then
            TxtG.Enabled = True
            DrawCost(2)
        Else
            TxtG.Enabled = False
            ClearCost(2)
        End If
    End Sub

    Private Sub ChkM_CheckedChanged(sender As Object, e As EventArgs) Handles ChkM.CheckedChanged
        If ChkM.Checked = True Then
            TxtM.Enabled = True
            DrawCost(3)
        Else
            TxtM.Enabled = False
            ClearCost(3)
        End If
    End Sub

    Private Sub ChkT_CheckedChanged(sender As Object, e As EventArgs) Handles ChkT.CheckedChanged
        If ChkT.Checked = True Then
            TxtT.Enabled = True
            DrawCost(4)
        Else
            TxtT.Enabled = False
            ClearCost(4)
        End If
    End Sub

    Private Sub ChkF_CheckedChanged(sender As Object, e As EventArgs) Handles ChkF.CheckedChanged
        If ChkF.Checked = True Then
            TxtF.Enabled = True
            DrawCost(1)
        Else
            TxtF.Enabled = False
            ClearCost(1)
        End If
    End Sub


    Private Sub TxtE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
End Class
