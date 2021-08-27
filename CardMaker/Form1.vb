Option Explicit On


Public Class Form1


    'Dim mulc As Boolean = False '是否多色

    'Dim mk As Boolean = False

    ' Dim Nlen As Integer


    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
        Tfont = New Font("黑体", 108, FontStyle.Bold)
        Tbrush = New SolidBrush(Color.White)
        Call DrawCard(CDNAME)
    End Sub

    'Private Sub TxtCost_TextChanged(sender As Object, e As EventArgs)
    '    'GcP.DrawString(TxtCost.Text,)
    '    '费用使用特殊表示元素，不使用文字

    '    mulc = False
    '    '
    'End Sub
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

        PicCard.SizeMode = PictureBoxSizeMode.StretchImage
        CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB.png")
        CdB4C = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-O.png")
        BwP = New Bitmap(CdB)
        BwP4C = New Bitmap(CdB4C)

        PicCard.Image = CdB

        'GbW = Graphics.FromImage(CdB)
        'GbP = Graphics.FromImage(CdB)
        '----------------------------------------
        '添加费用板
        GwP = Graphics.FromImage(BwP)
        costBoardPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\C-BG-D.png")
        'costBoardGraph = Graphics.FromImage(costBoardPic)

        Dim costDrawRect As New Rectangle(COSTX, COSTY, costBoardPic.Width / 2, costBoardPic.Height / 2)

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
        If txtLen < maxLen Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    'checks and txts
    Private Sub ChkE_CheckedChanged(sender As Object, e As EventArgs) Handles ChkE.CheckedChanged
        If ChkE.Checked = True Then
            TxtE.Enabled = True
            monoTypeChosen += 1
            poc += 1
            'DrawCost(0)

        Else
            TxtE.Enabled = False
            monoTypeChosen -= 1
            poc -= 1
            'ClearCost(0)
        End If
    End Sub

    Private Sub ChkG_CheckedChanged(sender As Object, e As EventArgs) Handles ChkG.CheckedChanged
        If ChkG.Checked = True Then
            TxtG.Enabled = True
            monoTypeChosen += 2
            poc += 1
            ' DrawCost(2)

        Else
            TxtG.Enabled = False
            monoTypeChosen -= 2
            poc -= 1
            'ClearCost(2)
        End If
    End Sub

    Private Sub ChkM_CheckedChanged(sender As Object, e As EventArgs) Handles ChkM.CheckedChanged
        If ChkM.Checked = True Then
            TxtM.Enabled = True
            monoTypeChosen += 8
            poc += 1
            'DrawCost(3)

        Else
            TxtM.Enabled = False
            monoTypeChosen -= 8
            poc -= 1
            'ClearCost(3)
        End If
    End Sub

    Private Sub ChkT_CheckedChanged(sender As Object, e As EventArgs) Handles ChkT.CheckedChanged
        If ChkT.Checked = True Then
            TxtT.Enabled = True
            monoTypeChosen += 16
            poc += 1
            ' DrawCost(4)

        Else
            TxtT.Enabled = False
            monoTypeChosen -= 16
            poc -= 1
            'ClearCost(4)
        End If
    End Sub

    Private Sub ChkF_CheckedChanged(sender As Object, e As EventArgs) Handles ChkF.CheckedChanged
        If ChkF.Checked = True Then
            TxtF.Enabled = True
            monoTypeChosen += 4
            poc += 1
            'DrawCost(1)

        Else
            TxtF.Enabled = False
            monoTypeChosen -= 4
            poc -= 1
            'ClearCost(1)
        End If
    End Sub


    Private Sub TxtE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) And TxtE.Text.Length < 2 Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) And TxtM.Text.Length < 2 Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) And TxtT.Text.Length < 2 Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) And TxtG.Text.Length < 2 Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) And TxtF.Text.Length < 2 Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtE.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) And TxtAny.Text.Length < 2 Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtAny_TextChanged(sender As Object, e As EventArgs) Handles TxtAny.TextChanged
        CostNum(0)
    End Sub
    Private Sub TxtE_TextChanged(sender As Object, e As EventArgs) Handles TxtE.TextChanged
        CostNum(1)
    End Sub

    Private Sub TxtG_TextChanged(sender As Object, e As EventArgs) Handles TxtG.TextChanged
        CostNum(2)
    End Sub

    Private Sub TxtF_TextChanged(sender As Object, e As EventArgs) Handles TxtF.TextChanged
        CostNum(3)
    End Sub

    Private Sub TxtM_TextChanged(sender As Object, e As EventArgs) Handles TxtM.TextChanged
        CostNum(4)
    End Sub

    Private Sub TxtT_TextChanged(sender As Object, e As EventArgs) Handles TxtT.TextChanged
        CostNum(5)
    End Sub

    Private Sub CmdMake_Click(sender As Object, e As EventArgs) Handles CmdMake.Click
        SFDCardFPic.Filter = "XML Files (*.xml*)|*.xml"
        SFDCardFPic.Title = "Save Card"
        SFDCardFPic.InitialDirectory = Application.StartupPath
        If SFDCardFPic.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim savAddress As String = SFDCardFPic.FileName
            Call SavXML(savAddress)
            MsgBox("已导出至" & savAddress,, "导出成功")
        End If
    End Sub


    Private Sub RadioUnit_CheckedChanged(sender As Object, e As EventArgs) Handles RadioUnit.CheckedChanged
        If RadioUnit.Checked = True Then
            RadioTool.Checked = False
            RadioAction.Checked = False
            RadioSocery.Checked = False
            RadioEnchantment.Checked = False
            RadioArmor.Checked = False
            ChkHero.Enabled = True
            ttype = 0
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioTool_CheckedChanged(sender As Object, e As EventArgs) Handles RadioTool.CheckedChanged
        If RadioTool.Checked = True Then
            RadioUnit.Checked = False
            RadioAction.Checked = False
            RadioSocery.Checked = False
            RadioEnchantment.Checked = False
            RadioArmor.Checked = False
            ChkHero.Enabled = True
            ttype = 1
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioAction_CheckedChanged(sender As Object, e As EventArgs) Handles RadioAction.CheckedChanged
        If RadioAction.Checked = True Then
            RadioTool.Checked = False
            RadioUnit.Checked = False
            RadioSocery.Checked = False
            RadioEnchantment.Checked = False
            RadioArmor.Checked = False
            ChkHero.Enabled = False
            ttype = 2
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioSocery_CheckedChanged(sender As Object, e As EventArgs) Handles RadioSocery.CheckedChanged
        If RadioSocery.Checked = True Then
            RadioTool.Checked = False
            RadioAction.Checked = False
            RadioUnit.Checked = False
            RadioEnchantment.Checked = False
            RadioArmor.Checked = False
            ChkHero.Enabled = False
            ttype = 3
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioEnchantment_CheckedChanged(sender As Object, e As EventArgs) Handles RadioEnchantment.CheckedChanged
        If RadioEnchantment.Checked = True Then
            RadioTool.Checked = False
            RadioAction.Checked = False
            RadioSocery.Checked = False
            RadioUnit.Checked = False
            RadioArmor.Checked = False
            ChkHero.Enabled = False
            ttype = 4
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioArmor_CheckedChanged(sender As Object, e As EventArgs) Handles RadioArmor.CheckedChanged
        If RadioArmor.Checked = True Then
            RadioTool.Checked = False
            RadioAction.Checked = False
            RadioSocery.Checked = False
            RadioEnchantment.Checked = False
            RadioUnit.Checked = False
            ChkHero.Enabled = True
            ttype = 5
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub ChkHero_CheckedChanged(sender As Object, e As EventArgs) Handles ChkHero.CheckedChanged
        If ChkHero.Checked = True Then
            RadioN.Enabled = False
            RadioE.Enabled = False
            RadioAction.Enabled = False
            RadioSocery.Enabled = False
            RadioEnchantment.Enabled = False
            hs = True
            If RadioN.Checked = True Or RadioE.Checked = True Then
                RadioN.Checked = False
                RadioE.Checked = False
                RadioUnit.Checked = False
                RadioTool.Checked = False
                RadioArmor.Checked = False
                rtype = -1
                ttype = -1
                Exit Sub
            End If
            DrawMark(rtype, ttype, hs)
        Else
            RadioN.Enabled = True
            RadioE.Enabled = True
            RadioAction.Enabled = True
            RadioSocery.Enabled = True
            RadioEnchantment.Enabled = True
            hs = False
            DrawMark(rtype, ttype, hs)
        End If
    End Sub

    Private Sub RadioN_CheckedChanged(sender As Object, e As EventArgs) Handles RadioN.CheckedChanged
        If RadioN.Checked = True Then
            RadioE.Checked = False
            RadioR.Checked = False
            RadioS.Checked = False
            rtype = 0
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioE_CheckedChanged(sender As Object, e As EventArgs) Handles RadioE.CheckedChanged
        If RadioE.Checked = True Then
            RadioN.Checked = False
            RadioR.Checked = False
            RadioS.Checked = False
            rtype = 1
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioR_CheckedChanged(sender As Object, e As EventArgs) Handles RadioR.CheckedChanged
        If RadioR.Checked = True Then
            RadioE.Checked = False
            RadioN.Checked = False
            RadioS.Checked = False
            rtype = 2
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub

    Private Sub RadioS_CheckedChanged(sender As Object, e As EventArgs) Handles RadioS.CheckedChanged
        If RadioS.Checked = True Then
            RadioE.Checked = False
            RadioR.Checked = False
            RadioN.Checked = False
            rtype = 3
            DrawMark(rtype, ttype, hs)
        Else
            CleanMark()
        End If
    End Sub
End Class
