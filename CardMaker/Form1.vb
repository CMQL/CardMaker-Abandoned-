Option Explicit On


Public Class Form1


    Dim mulc As Boolean = False '是否多色

    ' Dim Nlen As Integer


    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
        Tfont = New Font("黑体", 108, FontStyle.Bold)
        Tbrush = New SolidBrush(Color.White)
        Call DrawCard(CDNAME)
    End Sub

    Private Sub TxtCost_TextChanged(sender As Object, e As EventArgs) Handles TxtCost.TextChanged
        'GcP.DrawString(TxtCost.Text,)
        '费用使用特殊表示元素，不使用文字

        mulc = False
        '
    End Sub
    Private Sub TxtCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCost.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) _
            Or e.KeyChar = "E" Or e.KeyChar = "F" Or e.KeyChar = "G" Or e.KeyChar = "T" Or e.KeyChar = "M" Then
            'e.Handled = True
        Else
            e.Handled = True
        End If
        If e.KeyChar = "E" Or e.KeyChar = "F" Or e.KeyChar = "G" Or e.KeyChar = "T" Or e.KeyChar = "M" Then '阵营输入与关联变量
            poc += 1
        End If
        If e.KeyChar = Chr(8) Then '消去阵营
            If Char.IsLetter(Microsoft.VisualBasic.Right(TxtCost.Text, 1)) Then
                poc -= 1
            End If
        End If
    End Sub

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
        Sfont = New Font("黑体", 48, FontStyle.Bold)
        Sbrush = New SolidBrush(Color.Blue)
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
        BwP = New Bitmap(CdB)
        PicCard.Image = CdB

        'GbW = Graphics.FromImage(CdB)
        'GbP = Graphics.FromImage(CdB)

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
End Class
