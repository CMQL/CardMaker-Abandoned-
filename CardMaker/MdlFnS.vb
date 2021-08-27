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
    Public Const COST = 1 '费用
    Public Const HP = 2 'HP
    Public Const MP = 3 'MP
    Public Const ATK = 4 'MP
    Public Const DEF = 5 'MP
    Public Const EFF = 6 '效果
    Public Const DES = 7 '描述
    Public Const CARD = 8 '卡图

    Public Const HPY = 1100 '属性纵坐标
    Public Const HPX = 450 'HP属性横中线坐标
    Public Const MPX = 375 '蓝
    Public Const MPY = 1250 '蓝
    Public Const ATKX = 300 '攻
    Public Const ATKY = 1400 '攻
    Public Const DEFX = 225 '防
    Public Const DEFY = 1550 '防
    'Public Const EFFX =
    Public Const EFFY = 510

    '位置偏移
    Public Const MVX = 100
    Public Const MVY = 50

    Public Const COSTX = 1420
    Public Const COSTY = 1580

    Public Const MARKX = 185
    Public Const MARKY = 1920

    Public Const PICX = 400
    Public Const PICY = 1100
    Public Const PICW = 1400
    Public Const PICH = 1050

    '文字数据
    Public Const INITXTCPA = "输入图片地址或点击""…""浏览" '缺省文字


    Public Const FLL = "暂定第一行七字" '行总长计算文本
    Public Const SLL = "第二行九字是七加二"
    Public Const TLL = "三行比二行多二字十一字"
    Public Const QLL = "四行超过三行二十一多二十三"
    Public Const CLL = "五行最多比四行多二十三到十五"
    '
=========

    Public costBoardPic As Bitmap
>>>>>>>>> Temporary merge branch 2


    Public CdP As Bitmap '卡图
    Public GcP As Graphics '图刷
    '---------------------
    Public CdB4C As Bitmap '计算用原版图
    Public CdB As Bitmap '卡底（不得妄动）
    Public GbP As Graphics '底刷

    Public BwP4C As Bitmap '计算用刷
    Public BwP As Bitmap '源中间量
    Public GwP As Graphics '源刷

    Public OtB As Bitmap '卡输出
    Public GoP As Graphics '输出刷
    '----------------------------
    Public Tfont As Font '字体
    Public Tbrush As SolidBrush '字刷

    Public Sfont As Font '属性
    Public Sbrush As SolidBrush

    'Public Cfont As Font '费用
    'Public Cbrush As SolidBrush

    Public Nwritten As Integer = 0 '已写行数，用于清除

    Public monoTypeChosen As Integer = 0 '阵营总代码，1东2神4斗8魔16科
    Dim costNumber As Integer = 0 '阵营数

    '-------------------------标志
    Public rtype As Integer = -1
    Public ttype As Integer = -1
    Public hs As Boolean = False

    Public Property poc As Integer
        Get
            Return costNumber
        End Get
        'Set(value As Integer)
        Set(value As Integer)
            costNumber = value
            Form1.PicCard.SizeMode = PictureBoxSizeMode.StretchImage
            '----------------------------------------底板
            Select Case costNumber
                Case 0 '无
                    CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-N.png")
                Case 1 '单
                    Select Case monoTypeChosen
                        Case 1
                            CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-E.png")
                        Case 2
                            CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-G.png")
                        Case 8
                            CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-M.png")
                        Case 16
                            CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-T.png")
                        Case 4
                            CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-F.png")
                    End Select
                Case >= 2 '多
                    CdB = Bitmap.FromFile(Application.StartupPath & "\CardBound\CB-P.png")
            End Select
            BwP = New Bitmap(CdB)
            'GwP = Graphics.FromImage(BwP)

            Form1.PicCard.Image = CdB
            '---------------------------------------文字
            '-----------卡名
            Tfont = New Font("黑体", 108, FontStyle.Bold)
            Tbrush = New SolidBrush(Color.White)
            Call DrawCard(CDNAME)
            '-----------属性
            Sfont = New Font("黑体", 96, FontStyle.Bold)
            Sbrush = New SolidBrush(Color.Red)
            Call DrawCard(HP)
            Sfont = New Font("黑体", 96, FontStyle.Bold)
            Sbrush = New SolidBrush(Color.Blue)
            Call DrawCard(MP)
            Sfont = New Font("黑体", 96, FontStyle.Bold)
            Sbrush = New SolidBrush(Color.DarkRed)
            Call DrawCard(ATK)
            Sfont = New Font("黑体", 96, FontStyle.Bold)
            Sbrush = New SolidBrush(Color.Green)
            Call DrawCard(DEF)
            '-----------效果
            Sfont = New Font("黑体", 60, FontStyle.Bold)
            Sbrush = New SolidBrush(Color.Black)
            Call DrawCard(EFF)
            '---------------------------------------卡图和标记
            Call DrawCard(CARD)
            Call DrawMark(rtype, ttype, hs)
            '----------------------------------------费用板
            costBoardPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\C-BG-D.png")
            GwP = Graphics.FromImage(BwP)

            Dim costDrawRect As New Rectangle(COSTX, COSTY, costBoardPic.Width / 2, costBoardPic.Height / 2)

            GwP.DrawImage(costBoardPic, costDrawRect)
            Dim tempMonoTypeChosen As Integer = monoTypeChosen
            Do Until tempMonoTypeChosen <= 0
                Select Case tempMonoTypeChosen
                    Case >= 16 '科
                        tempMonoTypeChosen -= 16
                        DrawCost(4)
                        CostNum(5)
                    Case >= 8 '魔
                        tempMonoTypeChosen -= 8
                        DrawCost(3)
                        CostNum(4)
                    Case >= 4 '斗
                        tempMonoTypeChosen -= 4
                        DrawCost(1)
                        CostNum(3)
                    Case >= 2 '神
                        tempMonoTypeChosen -= 2
                        DrawCost(2)
                        CostNum(2)
                    Case >= 1 '东
                        tempMonoTypeChosen -= 1
                        DrawCost(0)
                        CostNum(1)
                End Select
            Loop

            DrawMark(rtype, ttype, hs)

            CostNum(0)

            GwP.Dispose()
            OtB = New Bitmap(BwP)
            Form1.PicCard.Image = OtB
        End Set
    End Property

    'Public pastDrawTxt As String() = {"", "", "", "", ""} '旧文本，用于动态变化





    Private Sub DrawTextOutlined(txt As String, ByRef g As Graphics, f As Font, b As SolidBrush, p As Pen, r As Rectangle)
        'Dim grp As Graphics = Me.CreateGraphics
        Dim gp As New Drawing2D.GraphicsPath
        'Dim useFont As Font = New Font("黑体", 100, FontStyle.Regular)

        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        '解决方法：进行一次虚空添加，并使用bound方法获取实际大小，然后用point进行位置的调整并通过矩阵转置解决AddString自带的偏移问题
        gp.AddString(txt, f.FontFamily, FontStyle.Bold, f.Size, New Point(0, 0), StringFormat.GenericTypographic)
        Dim txtrec As Rectangle = Rectangle.Round(gp.GetBounds)
        Dim offset As Point = New Point(r.Left + (r.Width - txtrec.Width) / 2 - txtrec.Left, r.Top + (r.Height - txtrec.Height) / 2 - txtrec.Top)
        Dim trans As System.Drawing.Drawing2D.Matrix = New Drawing2D.Matrix
        trans.Translate(offset.X, offset.Y)
        gp.Transform(trans)

        'gp.AddString(txt, f.FontFamily, FontStyle.Bold, f.Size, New Point(r.X, r.Y), StringFormat.GenericTypographic)
        '原方案，位置有偏移
        f.Dispose()

        'Dim pn As Pen
        'pn = New Pen(Color.Black, 5)
        g.FillPath(b, gp)
        'If CheckBox1.Checked Then
        g.DrawPath(p, gp)
        'End If

        gp.Dispose()
    End Sub

    Private Sub CardBackChange()
        'CDNAME = 0 '卡名索引
        'Public Const COST = 1 '费用
        'Public Const HP = 2 'HP
        'Public Const MP = 3 'MP
        'Public Const ATK = 4 'MP
        'Public Const DEF = 5 'MP
        'Public Const EFF = 6 '效果
        'Public Const DES = 7 '描述
        'Public Const CARD = 8 '卡图
        DrawCard(CDNAME)
        DrawCard(HP)
        DrawCard(MP)
        DrawCard(ATK)
        DrawCard(DEF)
        DrawCard(EFF)
        DrawCard(CARD)
    End Sub

    Public Sub DrawCost(costType As Integer)
        Dim costDType As Bitmap
        Dim costDTypeRect As Rectangle
        Select Case costType
            Case 0
                costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\E-S-B.png")
                costDTypeRect = New Rectangle(COSTX, COSTY + costDType.Height / 2, costDType.Width / 2, costDType.Height / 2)
            Case 1
                costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\F-S-B.png")
                costDTypeRect = New Rectangle(COSTX + costDType.Width / 2, COSTY + costDType.Height, costDType.Width / 2, costDType.Height / 2)
            Case 2
                costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\G-S-B.png")
                costDTypeRect = New Rectangle(COSTX + costDType.Width / 6, COSTY + costDType.Height, costDType.Width / 2, costDType.Height / 2)
            Case 3
                costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\M-S-B.png")
                costDTypeRect = New Rectangle(COSTX + costDType.Width / 3, COSTY, costDType.Width / 2, costDType.Height / 2)
            Case 4
                costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\T-S-B.png")
                costDTypeRect = New Rectangle(COSTX + costDType.Width / 3, COSTY + costDType.Height / 2, costDType.Width / 2, costDType.Height / 2)
        End Select
        GwP = Graphics.FromImage(BwP)
        'Dim costE As Bitmap
        'costE = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\E-S-B.png")

        GwP.DrawImage(costDType, costDTypeRect)
        GwP.Dispose()
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB
    End Sub

    Public Sub CostNum(costType As Integer)
        '费用具体数字
        GwP = Graphics.FromImage(BwP)

        Dim numCost As String '内容
        Dim costRect As Rectangle '位置矩形
        Dim costSourceCleanRect As Rectangle '清除矩形
        Dim Cfont As Font = New Font("黑体", 60, FontStyle.Bold) '费用
        Dim Cbrush As SolidBrush
        Dim costG4C As Bitmap = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\E-S-B.png")
        Dim costC As Bitmap
        Dim triL As Integer = costG4C.Width / 2
        Dim triH As Integer = costG4C.Height / 4
        Dim costTW As Integer
        Dim costTH As Integer
        Select Case costType
            Case 0 '任意
                numCost = Form1.TxtAny.Text
                costC = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\C-BG-D.png") '使用大面板
                costTW = GwP.MeasureString(numCost, Cfont).Width
                costTH = GwP.MeasureString(numCost, Cfont).Height
                costRect = New Rectangle(COSTX + triL / 2 + (triL - costTW) / 2, COSTY + triH + (triH - costTH) / 2 + MVY / 2, costTW, costTH)
                costSourceCleanRect = New Rectangle(triL + (triL * 2 - costTW) / 2, triH * 2 + (triH * 2 - costTH) / 2, costTW, costTH)
            Case 1 '东
                numCost = Form1.TxtE.Text
                costC = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\E-S-B.png")
                costTW = GwP.MeasureString(numCost, Cfont).Width
                costTH = GwP.MeasureString(numCost, Cfont).Height
                costRect = New Rectangle(COSTX + (triL - costTW) / 2, COSTY + triH * 3 + (triH - costTH) / 2, costTW, costTH)
                costSourceCleanRect = New Rectangle((triL * 2 - costTW * 2) / 2, triH * 2 + (triH * 2 - costTH * 2) / 2, costTW * 2, costTH * 2)
            Case 2 '神
                numCost = Form1.TxtG.Text
                costC = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\G-S-B.png")
                costTW = GwP.MeasureString(numCost, Cfont).Width
                costTH = GwP.MeasureString(numCost, Cfont).Height
                costRect = New Rectangle(COSTX + triL * 1.1 + (triL * 0.9 - costTW) / 2, COSTY + triH * 2.5 + (triH * 0.5 - costTH) / 2, costTW, costTH)
                costSourceCleanRect = New Rectangle(triL * 1.2 + (triL * 1.8 - costTW * 2) / 2, triH + (triH - costTH * 2) / 2, costTW * 2, costTH * 2)
            Case 3 '斗
                numCost = Form1.TxtF.Text
                costC = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\F-S-B.png")
                costTW = GwP.MeasureString(numCost, Cfont).Width
                costTH = GwP.MeasureString(numCost, Cfont).Height
                costRect = New Rectangle(COSTX + triL * 2.2 + (triL * 0.8 - costTW) / 2, COSTY + triH * 2.5 + (triH * 0.5 - costTH) / 2, costTW, costTH)
                costSourceCleanRect = New Rectangle(triL * 1.4 + (triL * 1.6 - costTW * 2) / 2, triH + (triH - costTH * 2) / 2, costTW * 2, costTH * 2)
            Case 4 '魔
                numCost = Form1.TxtM.Text '浅色
                costC = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\M-S-B.png")
                costTW = GwP.MeasureString(numCost, Cfont).Width
                costTH = GwP.MeasureString(numCost, Cfont).Height
                costRect = New Rectangle(COSTX + triL * 1.75 + (triL * 0.75 - costTW) / 2, COSTY + (triH * 0.4 - costTH) / 2, costTW, costTH)
                costSourceCleanRect = New Rectangle(triL * 1.5 + (triL * 1.5 - costTW * 2) / 2, (triH * 0.8 - costTH * 2) / 2, costTW * 2, costTH * 2)
            Case 5 '科
                numCost = Form1.TxtT.Text
                costC = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\T-S-B.png")
                costTW = GwP.MeasureString(numCost, Cfont).Width
                costTH = GwP.MeasureString(numCost, Cfont).Height
                costRect = New Rectangle(COSTX + triL * 1.75 + (triL * 0.75 - costTW) / 2, COSTY + triH * 1.5 + (triH * 0.5 - costTH) / 2, costTW, costTH)
                costSourceCleanRect = New Rectangle(triL * 1.5 + (triL * 1.5 - costTW * 2) / 2, triH * 1 + (triH * 1 - costTH * 2) / 2, costTW * 2, costTH * 2)
        End Select

        For x As Integer = costRect.X To costRect.X + costTW - 1
            For y As Integer = costRect.Y To costRect.Y + costTH - 1
                BwP.SetPixel(x, y, Color.Transparent)
            Next
        Next
        'If costType = 0 Then '大面板
        GwP.DrawImage(costC, costRect, costSourceCleanRect, GraphicsUnit.Pixel)
        'Else
        'GwP.DrawImage(costC, costRect, costSourceCleanRect, GraphicsUnit.Pixel)
        'End If
        If numCost <> "" Then
            'GwP.DrawString(Form1.TxtHP.Text, Sfont, Sbrush, recD)
            Dim CPen As Pen = New Pen(Color.White, 0)
            If costType = 4 Then
                Cbrush = New SolidBrush(Color.White)
            Else
                Cbrush = New SolidBrush(Color.Black)
            End If
            DrawTextOutlined(numCost, GwP, Cfont, Cbrush, CPen, costRect)
            Else
                GwP.DrawImage(costC, costRect, costSourceCleanRect, GraphicsUnit.Pixel)
        End If


        GwP.Dispose()
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB
    End Sub

    'Public Sub ClearCost(costType As Integer)
    '    Dim costDType As Bitmap
    '    Dim costCTypeRect As Rectangle
    '    Dim costSourceCleanRect As Rectangle
    '    GwP = Graphics.FromImage(BwP)
    '    Select Case costType
    '        Case 0
    '            costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\E-S-B.png")
    '            costCTypeRect = New Rectangle(COSTX, COSTY + costDType.Height / 2, costDType.Width / 2, costDType.Height / 2)
    '            costSourceCleanRect = New Rectangle(0, costDType.Height, costDType.Width, costDType.Height)
    '        Case 1
    '            costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\F-S-B.png")
    '            costCTypeRect = New Rectangle(COSTX + costDType.Width / 2, COSTY + costDType.Height, costDType.Width / 2, costDType.Height / 2)
    '            costSourceCleanRect = New Rectangle(costDType.Width, 2 * costDType.Height, costDType.Width, costDType.Height)
    '        Case 2
    '            costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\G-S-B.png")
    '            costCTypeRect = New Rectangle(COSTX + costDType.Width / 6, COSTY + costDType.Height, costDType.Width / 2, costDType.Height / 2)
    '            costSourceCleanRect = New Rectangle(costDType.Width / 3, 2 * costDType.Height, costDType.Width, costDType.Height)
    '        Case 3
    '            costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\M-S-B.png")
    '            costCTypeRect = New Rectangle(COSTX + costDType.Width / 3, COSTY, costDType.Width / 2, costDType.Height / 2)
    '            costSourceCleanRect = New Rectangle(costDType.Width * 2 / 3, 0, costDType.Width, costDType.Height)
    '        Case 4
    '            costDType = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\T-S-B.png")
    '            costCTypeRect = New Rectangle(COSTX + costDType.Width / 3, COSTY + costDType.Height / 2, costDType.Width / 2, costDType.Height / 2)
    '            costSourceCleanRect = New Rectangle(costDType.Width * 2 / 3, costDType.Height, costDType.Width, costDType.Height)
    '    End Select

    '    'GwP.DrawImage(costDType, costDTypeRect)
    '    For x As Integer = costCTypeRect.X To costCTypeRect.X + costCTypeRect.Width - 1
    '        For y As Integer = costCTypeRect.Y To costCTypeRect.Y + costCTypeRect.Height - 1
    '            BwP.SetPixel(x, y, Color.Transparent)
    '        Next
    '    Next
    '    costBoardPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\C-BG-D.png")

    '    GwP.DrawImage(CdB, costCTypeRect, costCTypeRect, GraphicsUnit.Pixel)
    '    GwP.DrawImage(costBoardPic, costCTypeRect, costSourceCleanRect, GraphicsUnit.Pixel)

    '    GwP.Dispose()
    '    OtB = New Bitmap(BwP)
    '    Form1.PicCard.Image = OtB
    'End Sub

    Public Sub DrawCard(DrawPart As Integer)
        'BwP = New Bitmap(CdB) '进入工作间
        GwP = Graphics.FromImage(BwP)

        'Dim VdP As New Bitmap(CdB.Width, VNheight)
        'Dim GvP As Graphics = Graphics.FromImage(VdP)
        '擦除工

        Select Case DrawPart
            Case 0 '卡名;
                'X坐标完全正常，效果文字向左平移
                '说明实际情况应是width中留白的区域在使用中被消除，导致实际文字向左移动
                '（已解决，问题出在GraphicsPath的AddString中，位置存在偏移且尺寸有留白，引起bug，需要对执行点进行特殊调整）

                'Dim Awidth As Integer = GwP.MeasureString("A", Tfont).Width
                'Dim Awidth2 As Integer = TextRenderer.MeasureText("A", Tfont).Width
                Dim VNheight As Integer = GwP.MeasureString(Form1.TxtName.Text & "M", Tfont).Height
                Dim VNwidth As Integer = GwP.MeasureString(Form1.TxtName.Text & "M", Tfont).Width

                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtName.Text, Tfont).Width

                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtName.Text, Tfont).Height

                Dim recD As New Rectangle((BwP4C.Width - Wwidth) / 2 + MVX, 200 + MVY, Wwidth, Wheight)
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
                    'GwP.DrawString(Form1.TxtName.Text, Tfont, Tbrush, recD)//
                    Dim NamePen As Pen = New Pen(Color.Black, 5)
                    DrawTextOutlined(Form1.TxtName.Text, GwP, Tfont, Tbrush, NamePen, recD)
                Else
                    GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                End If

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
            Case 2 'HP
                'GwP.RotateTransform(-30.0F)
                Dim VNheight As Integer = GwP.MeasureString(Form1.TxtHP.Text & "M", Sfont).Height
                Dim VNwidth As Integer = GwP.MeasureString(Form1.TxtHP.Text & "M", Sfont).Width

                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtHP.Text, Sfont).Width
                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtHP.Text, Sfont).Height

                Dim recD As New Rectangle(HPX + MVX, HPY + MVY, Wwidth, Wheight)
                'Dim recB As New Rectangle(0, recD.Y, recD.X + Wwidth, Wheight)
                Dim recV As New Rectangle(recD.X, recD.Y, VNwidth, VNheight)

                For x As Integer = recD.X To recD.X + VNwidth - 1
                    For y As Integer = recD.Y To recD.Y + VNheight - 1
                        BwP.SetPixel(x, y, Color.Transparent)
                    Next
                Next

                GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                If Form1.TxtHP.Text <> "" Then
                    'GwP.DrawString(Form1.TxtHP.Text, Sfont, Sbrush, recD)
                    Dim HPPen As Pen = New Pen(Color.White, 2)
                    DrawTextOutlined(Form1.TxtHP.Text, GwP, Sfont, Sbrush, HPPen, recD)
                Else
                    GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                End If

            Case 3 'MP
                Dim VNheight As Integer = GwP.MeasureString(Form1.TxtMP.Text & "M", Sfont).Height
                Dim VNwidth As Integer = GwP.MeasureString(Form1.TxtMP.Text & "M", Sfont).Width

                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtMP.Text, Sfont).Width
                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtMP.Text, Sfont).Height

                Dim recD As New Rectangle(MPX + MVX, MPY + MVY, Wwidth, Wheight)
                'Dim recB As New Rectangle(0, recD.Y, recD.X + Wwidth, Wheight)
                Dim recV As New Rectangle(recD.X, recD.Y, VNwidth, VNheight)

                For x As Integer = recD.X To recD.X + VNwidth - 1
                    For y As Integer = recD.Y To recD.Y + VNheight - 1
                        BwP.SetPixel(x, y, Color.Transparent)
                    Next
                Next

                GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                If Form1.TxtMP.Text <> "" Then
                    'GwP.DrawString(Form1.TxtHP.Text, Sfont, Sbrush, recD)
                    Dim MPPen As Pen = New Pen(Color.White, 2)
                    DrawTextOutlined(Form1.TxtMP.Text, GwP, Sfont, Sbrush, MPPen, recD)
                Else
                    GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                End If
            Case 4 'ATK
                Dim VNheight As Integer = GwP.MeasureString(Form1.TxtATK.Text & "M", Sfont).Height
                Dim VNwidth As Integer = GwP.MeasureString(Form1.TxtATK.Text & "M", Sfont).Width

                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtATK.Text, Sfont).Width
                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtATK.Text, Sfont).Height

                Dim recD As New Rectangle(ATKX + MVX, ATKY + MVY, Wwidth, Wheight)
                'Dim recB As New Rectangle(0, recD.Y, recD.X + Wwidth, Wheight)
                Dim recV As New Rectangle(recD.X, recD.Y, VNwidth, VNheight)

                For x As Integer = recD.X To recD.X + VNwidth - 1
                    For y As Integer = recD.Y To recD.Y + VNheight - 1
                        BwP.SetPixel(x, y, Color.Transparent)
                    Next
                Next

                GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                If Form1.TxtATK.Text <> "" Then
                    'GwP.DrawString(Form1.TxtHP.Text, Sfont, Sbrush, recD)
                    Dim ATKPen As Pen = New Pen(Color.White, 2)
                    DrawTextOutlined(Form1.TxtATK.Text, GwP, Sfont, Sbrush, ATKPen, recD)
                Else
                    GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                End If
            Case 5 'DEF
                Dim VNheight As Integer = GwP.MeasureString(Form1.TxtDEF.Text & "M", Sfont).Height
                Dim VNwidth As Integer = GwP.MeasureString(Form1.TxtDEF.Text & "M", Sfont).Width

                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtDEF.Text, Sfont).Width
                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtDEF.Text, Sfont).Height

                Dim recD As New Rectangle(DEFX + MVX, DEFY + MVY, Wwidth, Wheight)
                'Dim recB As New Rectangle(0, recD.Y, recD.X + Wwidth, Wheight)
                Dim recV As New Rectangle(recD.X, recD.Y, VNwidth, VNheight)

                For x As Integer = recD.X To recD.X + VNwidth - 1
                    For y As Integer = recD.Y To recD.Y + VNheight - 1
                        BwP.SetPixel(x, y, Color.Transparent)
                    Next
                Next

                GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                If Form1.TxtDEF.Text <> "" Then
                    'GwP.DrawString(Form1.TxtHP.Text, Sfont, Sbrush, recD)
                    Dim DEFPen As Pen = New Pen(Color.White, 2)
                    DrawTextOutlined(Form1.TxtDEF.Text, GwP, Sfont, Sbrush, DEFPen, recD)
                Else
                    GwP.DrawImage(CdB, recV, recV, GraphicsUnit.Pixel)
                End If
            Case 6 '效果

                'GwP.RotateTransform(-30.0F)
                '每一次变化执行一次
                '获取全部文本，然后进行检测
                '设标记a为当前所在位置，每当a所经过文字达到行长度限数或a指向换行符时，换行
                '设h为行数，用以标记行所在及方便行长度计算
                '将每一行单独提取作为一个stirng
                '设string数组储存全部内容
                '遍历数组并居中绘制
                Dim allTxt As String = Form1.TxtEffect.Text
                Dim pMark As Integer = 0
                Dim hMark As Integer = 0
                Dim drawTxt As String() = {"", "", "", "", ""}

                '上限尺寸，用于清除
                Dim Theight As Integer = GwP.MeasureString(FLL, Sfont).Height
                Dim FLTwidth As Integer = GwP.MeasureString(FLL, Sfont).Width '此处应为最大长度对应的文本 第一行
                Dim SLTwidth As Integer = GwP.MeasureString(SLL, Sfont).Width '此处应为最大长度对应的文本   二
                Dim TLTwidth As Integer = GwP.MeasureString(TLL, Sfont).Width '此处应为最大长度对应的文本   三
                Dim QLTwidth As Integer = GwP.MeasureString(QLL, Sfont).Width '此处应为最大长度对应的文本   四
                Dim CLTwidth As Integer = GwP.MeasureString(CLL, Sfont).Width '此处应为最大长度对应的文本   五
                Dim widthS As Integer() = {FLTwidth, SLTwidth, TLTwidth, QLTwidth, CLTwidth} '统合
                Dim widthRS As Integer() = {0, 0, 0, 0, 0} '实际统合
                '此处有清除代码'
                '************************************'
                For i As Integer = 0 To Nwritten
                    For x As Integer = (BwP4C.Width - widthS(i)) / 2 + MVX To (BwP4C.Width + widthS(i)) / 2 + MVX - 1
                        For y As Integer = EFFY + i * Theight + MVY To EFFY + (i + 1) * Theight + MVY - 1
                            BwP.SetPixel(x, y, Color.Transparent)
                        Next
                    Next
                    Dim recC As New Rectangle((BwP4C.Width - widthS(i)) / 2 + MVX, EFFY + i * Theight + MVY, widthS(i), Theight)
                    GwP.DrawImage(CdB, recC, recC, GraphicsUnit.Pixel)
                Next
                If allTxt = "" Then '为空则清除后直接结束，跳过后面
                    Exit Select
                End If
                Do '循环检测
                    pMark += 1
                    Dim tempTxt As String = allTxt.Substring(0, pMark)
                    Dim tempLen As Integer = GwP.MeasureString(tempTxt, Sfont).Width
                    If allTxt.Substring(pMark - 1, 1) = Chr(10) Or tempLen >= widthS(hMark) Or pMark = allTxt.Length Then
                        '失败的debug
                        If pMark < allTxt.Length - 1 Then
                            If allTxt.Substring(pMark - 1, 1) = Chr(10) And tempLen >= widthS(hMark) Then
                                Continue Do
                            End If
                        End If
                        '*****************************************************************'
                        drawTxt(hMark) = allTxt.Substring(0, pMark)
                        widthRS(hMark) = GwP.MeasureString(drawTxt(hMark), Sfont).Width
                        allTxt = allTxt.Substring(pMark, allTxt.Length - pMark)
                        pMark = 0
                        hMark = hMark + 1
                    End If
                    Nwritten = hMark
                    If hMark >= 5 Or allTxt = "" Then '结束退出
                        Nwritten = 4
                        Exit Do
                    End If
                Loop

                '开始绘制
                For h = 0 To hMark - 1
                    '行Y需要一个数组进行标记
                    Dim recD As New Rectangle((BwP4C.Width - widthRS(h)) / 2 + MVX, EFFY + h * Theight + MVY, widthRS(h), Theight)

                    'GwP.DrawString(drawTxt(h), Sfont, Sbrush, recD)
                    Dim EffPen As Pen = New Pen(Color.Black, 0)
                    DrawTextOutlined(drawTxt(h), GwP, Sfont, Sbrush, EffPen, recD)
                Next
                '        drawTxt(hMark) = allTxt.Substring(0, pMark)
                '        widthRS(hMark) = GwP.MeasureString(drawTxt(hMark), Sfont).Width
                '        allTxt = allTxt.Substring(pMark, allTxt.Length - pMark)
                '        pMark = 0
                '        hMark = hMark + 1
                '    End If
                '    If hMark >= 5 Or allTxt = "" Then '结束退出
                '        Exit Do
                '    End If
                'Loop
                ''开始绘制
                'For h = 0 To hMark - 1
                '    '行Y需要一个数组进行标记
                '    Dim recD As New Rectangle((BwP4C.Width - widthRS(h)) / 2 + MVX, EFFY + MVY, widthRS(h), Theight)
                '    GwP.DrawString(drawTxt(h), Sfont, Sbrush, recD)
                'Next


                '*************************************************

            Case 8 '卡图
                If IsNothing(CdP) = True Then
                    Exit Sub
                End If
                Dim recC As New Rectangle(PICX, PICY, PICW, PICH)
                GwP.DrawImage(CdP, recC)
                OtB = New Bitmap(BwP)
                Form1.PicCard.Image = OtB
                        Form1.PicCard.Image = OtB
        End Select
        GwP.Dispose()
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB

    End Sub

    Public Sub ClearCard()
        BwP = New Bitmap(CdB)
        GwP = Graphics.FromImage(BwP)
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB
    End Sub

    Public Sub SavXML(ByVal savAdd As String)
        Dim xmlWS As Xml.XmlWriterSettings = New Xml.XmlWriterSettings()
        xmlWS.Indent = True
        xmlWS.NewLineOnAttributes = True

        Using xmlW As Xml.XmlWriter = Xml.XmlWriter.Create(savAdd, xmlWS)
            xmlW.WriteComment("Save Card Information")
            xmlW.WriteStartElement("Card_State")
            xmlW.WriteStartElement("Card_Name")
            xmlW.WriteAttributeString("Name", Form1.TxtName.Text)
            xmlW.WriteEndElement()
            xmlW.WriteStartElement("Card_cost")
            xmlW.WriteAttributeString("Any", Form1.TxtAny.Text)
            xmlW.WriteAttributeString("East", Form1.ChkE.Checked & Form1.TxtE.Text)
            xmlW.WriteAttributeString("God", Form1.ChkG.Checked & Form1.TxtG.Text)
            xmlW.WriteAttributeString("Fight", Form1.ChkF.Checked & Form1.TxtF.Text)
            xmlW.WriteAttributeString("Magic", Form1.ChkM.Checked & Form1.TxtM.Text)
            xmlW.WriteAttributeString("Tech", Form1.ChkT.Checked & Form1.TxtT.Text)
            xmlW.WriteEndElement()
            xmlW.WriteStartElement("Card_State")
            xmlW.WriteAttributeString("HP", Form1.TxtHP.Text)
            xmlW.WriteAttributeString("MP", Form1.TxtMP.Text)
            xmlW.WriteAttributeString("ATK", Form1.TxtATK.Text)
            xmlW.WriteAttributeString("DEF", Form1.TxtDEF.Text)
            xmlW.WriteEndElement()
            xmlW.WriteStartElement("Card_Pic") '需要写入图片
            Using mS4P As IO.MemoryStream = New IO.MemoryStream()
                CdP.Save(mS4P, Drawing.Imaging.ImageFormat.Png) '卡图
                Dim picdata As Byte() = mS4P.ToArray()
                xmlW.WriteBase64(picdata, 0, picdata.Length)
            End Using
            Using mS4C As IO.MemoryStream = New IO.MemoryStream()
                OtB.Save(mS4C, Drawing.Imaging.ImageFormat.Png) '整卡
                Dim picdata As Byte() = mS4C.ToArray()
                xmlW.WriteBase64(picdata, 0, picdata.Length)
            End Using
            xmlW.WriteEndElement()
            xmlW.WriteStartElement("Type_and_Rare_Mark")
            xmlW.WriteAttributeString("Rare", rtype)
            xmlW.WriteAttributeString("Type", ttype)
            xmlW.WriteAttributeString("isHero", hs)
            xmlW.WriteEndElement()
            xmlW.WriteStartElement("Effect_and_Description")
            xmlW.WriteAttributeString("Effect", Form1.TxtEffect.Text)
            xmlW.WriteAttributeString("Description", Form1.TxtDescribe.Text)
            xmlW.WriteEndElement()
            xmlW.WriteEndElement()
            xmlW.Flush()
        End Using
    End Sub


    Private markDRect As Rectangle
    Public marked As Boolean
    Public Sub CleanMark()
        If marked = False Then
            Exit Sub
        End If
        GwP = Graphics.FromImage(BwP)

        For x As Integer = markDRect.X To markDRect.X - 1
            For y As Integer = markDRect.Y To markDRect.Y - 1
                BwP.SetPixel(x, y, Color.Transparent)
            Next
        Next

        GwP.DrawImage(CdB, markDRect, markDRect, GraphicsUnit.Pixel)
        marked = False
        GwP.Dispose()
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB
    End Sub
    Public Sub DrawMark(ByVal rareType As Integer, ByVal typeType As Integer, ByVal isHero As Boolean)
        If rareType = -1 Or typeType = -1 Then
            Exit Sub
        End If
        Dim markPic As Bitmap
        Select Case typeType
            Case 0 '单位
                If isHero = True Then
                    Select Case rareType
                        Case 2
                            markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\HU-R.png")
                        Case 3
                            markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\HU-S.png")
                    End Select
                    Exit Select
                End If
                Select Case rareType
                    Case 0
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\U-N.png")
                    Case 1
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\U-E.png")
                    Case 2
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\U-R.png")
                    Case 3
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\U-S.png")
                End Select
            Case 1 '造物
                If isHero = True Then
                    Select Case rareType
                        Case 2
                            markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\HT-R.png")
                        Case 3
                            markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\HT-S.png")
                    End Select
                    Exit Select
                End If
                Select Case rareType
                    Case 0
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\T-N.png")
                    Case 1
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\T-E.png")
                    Case 2
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\T-R.png")
                    Case 3
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\T-S.png")
                End Select
            Case 2 '动作
                Select Case rareType
                    Case 0
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\US-N.png")
                    Case 1
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\US-E.png")
                    Case 2
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\US-R.png")
                    Case 3
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\US-S.png")
                End Select
            Case 3 '法术
                Select Case rareType
                    Case 0
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\S-N.png")
                    Case 1
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\S-E.png")
                    Case 2
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\S-R.png")
                    Case 3
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\S-S.png")
                End Select
            Case 4 '结界
                Select Case rareType
                    Case 0
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\E-N.png")
                    Case 1
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\E-E.png")
                    Case 2
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\E-R.png")
                    Case 3
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\E-S.png")
                End Select
            Case 5 '装备
                If isHero = True Then
                    Select Case rareType
                        Case 2
                            markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\HA-R.png")
                        Case 3
                            markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\HA-S.png")
                    End Select
                    Exit Select
                End If
                Select Case rareType
                    Case 0
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\A-N.png")
                    Case 1
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\A-E.png")
                    Case 2
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\A-R.png")
                    Case 3
                        markPic = Bitmap.FromFile(Application.StartupPath & "\CardBound\Marks\A-S.png")
                End Select
        End Select
        markDRect = New Rectangle(MARKX, MARKY, markPic.Width / 2, markPic.Height / 2)
        GwP = Graphics.FromImage(BwP)
        'Dim costE As Bitmap
        'costE = Bitmap.FromFile(Application.StartupPath & "\CardBound\Cost\E-S-B.png")

        GwP.DrawImage(markPic, markDRect)
        marked = True
        GwP.Dispose()
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB
    End Sub

End Module
