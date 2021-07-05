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
    Public Const EFFY = 515

    Public Const INITXTCPA = "输入图片地址或点击""…""浏览" '缺省文字


    Public Const FLL = "暂定第一行七字" '行总长计算文本
    Public Const SLL = "第二行十字是七再加三"
    Public Const TLL = "三行比二行再多三字合十三字"
    Public Const QLL = "四行超过三行三字比十三多总十六字"
    Public Const CLL = "五行是最多比四行再多十六加三达到十九字"


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
    Public Sub DrawCard(DrawPart As Integer)
        'BwP = New Bitmap(CdB) '进入工作间
        GwP = Graphics.FromImage(BwP)

        'Dim VdP As New Bitmap(CdB.Width, VNheight)
        'Dim GvP As Graphics = Graphics.FromImage(VdP)
        '擦除工

        Select Case DrawPart
            Case 0 '卡名
                'X坐标完全正常，效果文字向左平移
                '说明实际情况应是width中留白的区域在使用中被消除，导致实际文字向左移动
                '（已解决，问题出在GraphicsPath的AddString中，位置存在偏移且尺寸有留白，引起bug，需要对执行点进行特殊调整）

                'Dim Awidth As Integer = GwP.MeasureString("A", Tfont).Width
                'Dim Awidth2 As Integer = TextRenderer.MeasureText("A", Tfont).Width
                Dim VNheight As Integer = GwP.MeasureString(Form1.TxtName.Text & "M", Tfont).Height
                Dim VNwidth As Integer = GwP.MeasureString(Form1.TxtName.Text & "M", Tfont).Width

                Dim Wwidth As Integer = GwP.MeasureString(Form1.TxtName.Text, Tfont).Width

                Dim Wheight As Integer = GwP.MeasureString(Form1.TxtName.Text, Tfont).Height

                Dim recD As New Rectangle((BwP.Width - Wwidth) / 2 , 200, Wwidth, Wheight)
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

                Dim recD As New Rectangle(HPX, HPY, Wwidth, Wheight)
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

                Dim recD As New Rectangle(MPX, MPY, Wwidth, Wheight)
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

                Dim recD As New Rectangle(ATKX, ATKY, Wwidth, Wheight)
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

                Dim recD As New Rectangle(DEFX, DEFY, Wwidth, Wheight)
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
                If allTxt = "" Then '为空则清除后直接结束，跳过后面
                    Exit Select
                End If
                Do '循环检测
                    pMark += 1
                    Dim tempTxt As String = allTxt.Substring(0, pMark)
                    Dim tempLen As Integer = GwP.MeasureString(tempTxt, Sfont).Width
                    If allTxt.Substring(pMark - 1, 1) = Chr(10) Or tempLen > widthS(hMark) Or pMark = allTxt.Length Then
                        drawTxt(hMark) = allTxt.Substring(0, pMark)
                        widthRS(hMark) = GwP.MeasureString(drawTxt(hMark), Sfont).Width
                        allTxt = allTxt.Substring(pMark, allTxt.Length - pMark)
                        pMark = 0
                        hMark = hMark + 1
                    End If
                    If hMark >= 5 Or allTxt = "" Then '结束退出
                        Exit Do
                    End If
                Loop
                '开始绘制
                For h = 0 To hMark - 1
                    '行Y需要一个数组进行标记
                    Dim recD As New Rectangle((BwP.Width - widthRS(h)) / 2, 530, widthRS(h), Theight)
                    GwP.DrawString(drawTxt(h), Sfont, Sbrush, recD)
                Next


                '*************************************************

            Case 7'描述
            Case 8 '卡图
                Dim recC As New Rectangle(400, 800, CdP.Width / 2, CdP.Height / 2)
                GwP.DrawImage(CdP, recC)
                OtB = New Bitmap(BwP)
                Form1.PicCard.Image = OtB
        End Select
        GwP.Dispose()
        OtB = New Bitmap(BwP)
        Form1.PicCard.Image = OtB

    End Sub

    Public Sub ClearCard()
        BwP = New Bitmap(CdB)
        GwP = Graphics.FromImage(BwP)
    End Sub


End Module
