Module MdlFnS
    '关键字
    Public Const DRN = "吸取"
    Public Const FLY = "飞行"
    Public Const FRS = "先手"
    Public Const DBL = "双击"
    Public Const MGC = "魔法"
    Public Const HNR = "一击脱离"
    'Public Const KIL = "必杀"'待定，有点过于IMBA
    Public Const SPU = "疾行"
    Public Const CST = "通晓" '？？？我当时设置的什么来着------------费用产出

    '===============================================================================

    Public Const CDNAME = 0 '卡名索引
    Public Const DES = 1 '描述
    Public Const COST = 2 '费用纵坐标
    Public Const ST = 3 '属性纵坐标
    'Public Const MP = 1200 '蓝
    'Public Const ATK = 1500 '攻
    'Public Const DEF = 1700 '防
    Public Const INITXTCPA = "输入图片地址或点击""…""浏览" '缺省文字
    Public Const CARD = 8 '卡图

    Public CdP As Bitmap '卡图
    Public GcP As Graphics '图刷
    '---------------------
    Public CdB As Bitmap '卡底（不得妄动）
    Public GbP As Graphics '底刷

    Public BwP As Bitmap '源中间量
    Public GwP As Graphics '源刷

    Public OtB As Bitmap '卡输出
    Public GoP As Graphics '输出刷
    '----------------------------
    Public Tfont As Font '字体
    Public Tbrush As SolidBrush '字刷

    Public Sfont As Font '属性
    Public Sbrush As SolidBrush

    Public Dfont As Font '描述
    Public Dbrush As SolidBrush

    Dim Nlen As Integer

    Public poc As Integer = 0 '是否包含阵营符，数字表示数目，仅在1（和2）改变

    Public Sub DrawCard(DrawPart As Integer)
        'BwP = New Bitmap(CdB) '进入工作间
        GwP = Graphics.FromImage(BwP)
        Dim VNheight As Integer = GwP.MeasureString("VOID", Tfont).Height
        'Dim VdP As New Bitmap(CdB.Width, VNheight)
        'Dim GvP As Graphics = Graphics.FromImage(VdP)
        '擦除工

        Select Case DrawPart
            Case 0 '卡名
                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtName.Text, Tfont).Width
                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtName.Text, Tfont).Height

                Dim recD As New Rectangle((BwP.Width - Wwidth) / 2, 200, Wwidth, Wheight)
                Dim recB As New Rectangle(0, recD.Y, CdB.Width, Wheight)
                Dim recV As New Rectangle(0, recD.Y, CdB.Width, VNheight)
                'GwP.FillRectangle(New SolidBrush(Color.Red), recV)
                For x As Integer = 0 To CdB.Width - 1
                    For y As Integer = recD.Y To recD.Y + VNheight - 1
                        BwP.SetPixel(x, y, Color.Transparent)
                    Next
                Next
                'GwP.DrawImage(VdP, recV, recV, GraphicsUnit.Pixel)
                GwP.DrawImage(CdB, recB, recB, GraphicsUnit.Pixel)
                If Form1.TxtName.Text <> "" Then
                    GwP.DrawString(Form1.TxtName.Text, Tfont, Tbrush, recD)
                Else
                    GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                End If
                OtB = New Bitmap(BwP)
                Form1.PicCard.Image = OtB
            Case 1 '费用
                'If poc = 0 Then
                '    Form1.PicCard.Image = Image.FromFile(Application.StartupPath & "\CardBound\CB.png") '无色
                'ElseIf poc = 1 Then '存在阵营符号，开始调色
                '    Select Case Microsoft.VisualBasic.Right(Form1.TxtCost.Text, 1)
                '        Case "E"
                '            PicCard.Image = Image.FromFile(Application.StartupPath & "\CardBound\CB-E.png")
                '        Case "M"
                '            PicCard.Image = Image.FromFile(Application.StartupPath & "\CardBound\CB-M.png")
                '        Case "T"
                '            PicCard.Image = Image.FromFile(Application.StartupPath & "\CardBound\CB-T.png")
                '        Case "F"
                '            PicCard.Image = Image.FromFile(Application.StartupPath & "\CardBound\CB-F.png")
                '        Case "G"
                '            PicCard.Image = Image.FromFile(Application.StartupPath & "\CardBound\CB-G.png")
                '    End Select
                'End If
            Case 2'HP
            Case 3'MP
            Case 4'ATK
            Case 5'DEF
            Case 6'效果
            Case 7'描述
            Case 8 '卡图
                Dim recC As New Rectangle(400, 800, CdP.Width / 2, CdP.Height / 2)
                GwP.DrawImage(CdP, recC)
                OtB = New Bitmap(BwP)
                Form1.PicCard.Image = OtB
        End Select

    End Sub

    Public Sub ClearCard()
        BwP = New Bitmap(CdB)
        GwP = Graphics.FromImage(BwP)
    End Sub
End Module
