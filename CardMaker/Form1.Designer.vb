<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GrpCardInfo = New System.Windows.Forms.GroupBox()
        Me.CmdAddPic = New System.Windows.Forms.Button()
        Me.TxtDescribe = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtEffect = New System.Windows.Forms.TextBox()
        Me.LblEffect = New System.Windows.Forms.Label()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.TxtPicAddress = New System.Windows.Forms.TextBox()
        Me.TxtDEF = New System.Windows.Forms.TextBox()
        Me.TxtATK = New System.Windows.Forms.TextBox()
        Me.TxtMP = New System.Windows.Forms.TextBox()
        Me.TxtHP = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblHP = New System.Windows.Forms.Label()
        Me.LblMP = New System.Windows.Forms.Label()
        Me.LblATK = New System.Windows.Forms.Label()
        Me.LblDEF = New System.Windows.Forms.Label()
        Me.LblPic = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.GrpCard = New System.Windows.Forms.GroupBox()
        Me.PicCard = New System.Windows.Forms.PictureBox()
        Me.OFDCardIPic = New System.Windows.Forms.OpenFileDialog()
        Me.SFDCardFPic = New System.Windows.Forms.SaveFileDialog()
        Me.CmdMake = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.FBDCardPic = New System.Windows.Forms.FolderBrowserDialog()
        Me.LblCost = New System.Windows.Forms.Label()
        Me.ChkE = New System.Windows.Forms.CheckBox()
        Me.ChkF = New System.Windows.Forms.CheckBox()
        Me.ChkT = New System.Windows.Forms.CheckBox()
        Me.ChkG = New System.Windows.Forms.CheckBox()
        Me.ChkM = New System.Windows.Forms.CheckBox()
        Me.TxtE = New System.Windows.Forms.TextBox()
        Me.TxtF = New System.Windows.Forms.TextBox()
        Me.TxtT = New System.Windows.Forms.TextBox()
        Me.TxtG = New System.Windows.Forms.TextBox()
        Me.TxtM = New System.Windows.Forms.TextBox()
        Me.LblAny = New System.Windows.Forms.Label()
        Me.TxtAny = New System.Windows.Forms.TextBox()
        Me.GrpCardInfo.SuspendLayout()
        Me.GrpCard.SuspendLayout()
        CType(Me.PicCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCardInfo
        '
        Me.GrpCardInfo.Controls.Add(Me.TxtAny)
        Me.GrpCardInfo.Controls.Add(Me.LblAny)
        Me.GrpCardInfo.Controls.Add(Me.TxtM)
        Me.GrpCardInfo.Controls.Add(Me.TxtG)
        Me.GrpCardInfo.Controls.Add(Me.TxtT)
        Me.GrpCardInfo.Controls.Add(Me.TxtF)
        Me.GrpCardInfo.Controls.Add(Me.TxtE)
        Me.GrpCardInfo.Controls.Add(Me.ChkM)
        Me.GrpCardInfo.Controls.Add(Me.ChkG)
        Me.GrpCardInfo.Controls.Add(Me.ChkT)
        Me.GrpCardInfo.Controls.Add(Me.ChkF)
        Me.GrpCardInfo.Controls.Add(Me.ChkE)
        Me.GrpCardInfo.Controls.Add(Me.LblCost)
        Me.GrpCardInfo.Controls.Add(Me.CmdAddPic)
        Me.GrpCardInfo.Controls.Add(Me.TxtDescribe)
        Me.GrpCardInfo.Controls.Add(Me.Label1)
        Me.GrpCardInfo.Controls.Add(Me.TxtEffect)
        Me.GrpCardInfo.Controls.Add(Me.LblEffect)
        Me.GrpCardInfo.Controls.Add(Me.CmdBrowse)
        Me.GrpCardInfo.Controls.Add(Me.TxtPicAddress)
        Me.GrpCardInfo.Controls.Add(Me.TxtDEF)
        Me.GrpCardInfo.Controls.Add(Me.TxtATK)
        Me.GrpCardInfo.Controls.Add(Me.TxtMP)
        Me.GrpCardInfo.Controls.Add(Me.TxtHP)
        Me.GrpCardInfo.Controls.Add(Me.TxtName)
        Me.GrpCardInfo.Controls.Add(Me.LblHP)
        Me.GrpCardInfo.Controls.Add(Me.LblMP)
        Me.GrpCardInfo.Controls.Add(Me.LblATK)
        Me.GrpCardInfo.Controls.Add(Me.LblDEF)
        Me.GrpCardInfo.Controls.Add(Me.LblPic)
        Me.GrpCardInfo.Controls.Add(Me.LblName)
        Me.GrpCardInfo.Location = New System.Drawing.Point(12, 12)
        Me.GrpCardInfo.Name = "GrpCardInfo"
        Me.GrpCardInfo.Size = New System.Drawing.Size(477, 645)
        Me.GrpCardInfo.TabIndex = 0
        Me.GrpCardInfo.TabStop = False
        Me.GrpCardInfo.Text = "卡牌信息"
        '
        'CmdAddPic
        '
        Me.CmdAddPic.Font = New System.Drawing.Font("黑体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdAddPic.Location = New System.Drawing.Point(397, 212)
        Me.CmdAddPic.Name = "CmdAddPic"
        Me.CmdAddPic.Size = New System.Drawing.Size(62, 48)
        Me.CmdAddPic.TabIndex = 19
        Me.CmdAddPic.Text = "插入图片"
        Me.CmdAddPic.UseVisualStyleBackColor = True
        '
        'TxtDescribe
        '
        Me.TxtDescribe.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDescribe.Location = New System.Drawing.Point(106, 542)
        Me.TxtDescribe.Multiline = True
        Me.TxtDescribe.Name = "TxtDescribe"
        Me.TxtDescribe.Size = New System.Drawing.Size(353, 89)
        Me.TxtDescribe.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 542)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 29)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "描述："
        '
        'TxtEffect
        '
        Me.TxtEffect.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtEffect.Location = New System.Drawing.Point(106, 272)
        Me.TxtEffect.Multiline = True
        Me.TxtEffect.Name = "TxtEffect"
        Me.TxtEffect.Size = New System.Drawing.Size(353, 155)
        Me.TxtEffect.TabIndex = 16
        '
        'LblEffect
        '
        Me.LblEffect.AutoSize = True
        Me.LblEffect.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblEffect.Location = New System.Drawing.Point(19, 271)
        Me.LblEffect.Name = "LblEffect"
        Me.LblEffect.Size = New System.Drawing.Size(106, 29)
        Me.LblEffect.TabIndex = 15
        Me.LblEffect.Text = "效果："
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Font = New System.Drawing.Font("黑体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdBrowse.Location = New System.Drawing.Point(406, 174)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(43, 32)
        Me.CmdBrowse.TabIndex = 14
        Me.CmdBrowse.Text = "…"
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'TxtPicAddress
        '
        Me.TxtPicAddress.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtPicAddress.Location = New System.Drawing.Point(106, 174)
        Me.TxtPicAddress.Multiline = True
        Me.TxtPicAddress.Name = "TxtPicAddress"
        Me.TxtPicAddress.Size = New System.Drawing.Size(285, 76)
        Me.TxtPicAddress.TabIndex = 13
        Me.TxtPicAddress.Text = "输入图片地址或点击""…""浏览"
        '
        'TxtDEF
        '
        Me.TxtDEF.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDEF.Location = New System.Drawing.Point(334, 124)
        Me.TxtDEF.Name = "TxtDEF"
        Me.TxtDEF.Size = New System.Drawing.Size(125, 35)
        Me.TxtDEF.TabIndex = 12
        '
        'TxtATK
        '
        Me.TxtATK.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtATK.Location = New System.Drawing.Point(106, 124)
        Me.TxtATK.Name = "TxtATK"
        Me.TxtATK.Size = New System.Drawing.Size(133, 35)
        Me.TxtATK.TabIndex = 11
        '
        'TxtMP
        '
        Me.TxtMP.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtMP.Location = New System.Drawing.Point(314, 71)
        Me.TxtMP.Name = "TxtMP"
        Me.TxtMP.Size = New System.Drawing.Size(145, 35)
        Me.TxtMP.TabIndex = 10
        '
        'TxtHP
        '
        Me.TxtHP.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtHP.Location = New System.Drawing.Point(81, 71)
        Me.TxtHP.Name = "TxtHP"
        Me.TxtHP.Size = New System.Drawing.Size(158, 35)
        Me.TxtHP.TabIndex = 9
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtName.Location = New System.Drawing.Point(106, 22)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(353, 35)
        Me.TxtName.TabIndex = 7
        '
        'LblHP
        '
        Me.LblHP.AutoSize = True
        Me.LblHP.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblHP.Location = New System.Drawing.Point(19, 71)
        Me.LblHP.Name = "LblHP"
        Me.LblHP.Size = New System.Drawing.Size(76, 29)
        Me.LblHP.TabIndex = 5
        Me.LblHP.Text = "HP："
        '
        'LblMP
        '
        Me.LblMP.AutoSize = True
        Me.LblMP.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMP.Location = New System.Drawing.Point(245, 71)
        Me.LblMP.Name = "LblMP"
        Me.LblMP.Size = New System.Drawing.Size(76, 29)
        Me.LblMP.TabIndex = 4
        Me.LblMP.Text = "MP："
        '
        'LblATK
        '
        Me.LblATK.AutoSize = True
        Me.LblATK.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblATK.Location = New System.Drawing.Point(19, 124)
        Me.LblATK.Name = "LblATK"
        Me.LblATK.Size = New System.Drawing.Size(106, 29)
        Me.LblATK.TabIndex = 3
        Me.LblATK.Text = "攻击："
        '
        'LblDEF
        '
        Me.LblDEF.AutoSize = True
        Me.LblDEF.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDEF.Location = New System.Drawing.Point(245, 123)
        Me.LblDEF.Name = "LblDEF"
        Me.LblDEF.Size = New System.Drawing.Size(106, 29)
        Me.LblDEF.TabIndex = 2
        Me.LblDEF.Text = "防御："
        '
        'LblPic
        '
        Me.LblPic.AutoSize = True
        Me.LblPic.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPic.Location = New System.Drawing.Point(19, 180)
        Me.LblPic.Name = "LblPic"
        Me.LblPic.Size = New System.Drawing.Size(106, 29)
        Me.LblPic.TabIndex = 1
        Me.LblPic.Text = "卡图："
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblName.Location = New System.Drawing.Point(19, 28)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(106, 29)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "名字："
        '
        'GrpCard
        '
        Me.GrpCard.Controls.Add(Me.PicCard)
        Me.GrpCard.Location = New System.Drawing.Point(510, 12)
        Me.GrpCard.Name = "GrpCard"
        Me.GrpCard.Size = New System.Drawing.Size(567, 644)
        Me.GrpCard.TabIndex = 1
        Me.GrpCard.TabStop = False
        Me.GrpCard.Text = "卡牌预览"
        '
        'PicCard
        '
        Me.PicCard.BackColor = System.Drawing.Color.White
        Me.PicCard.Image = CType(resources.GetObject("PicCard.Image"), System.Drawing.Image)
        Me.PicCard.Location = New System.Drawing.Point(6, 19)
        Me.PicCard.Name = "PicCard"
        Me.PicCard.Size = New System.Drawing.Size(555, 619)
        Me.PicCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicCard.TabIndex = 0
        Me.PicCard.TabStop = False
        '
        'OFDCardIPic
        '
        Me.OFDCardIPic.FileName = "OpenFileDialog1"
        '
        'CmdMake
        '
        Me.CmdMake.Font = New System.Drawing.Font("微软雅黑", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdMake.Location = New System.Drawing.Point(829, 677)
        Me.CmdMake.Name = "CmdMake"
        Me.CmdMake.Size = New System.Drawing.Size(157, 61)
        Me.CmdMake.TabIndex = 2
        Me.CmdMake.Text = "导出"
        Me.CmdMake.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("微软雅黑", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdClear.Location = New System.Drawing.Point(12, 677)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(157, 61)
        Me.CmdClear.TabIndex = 3
        Me.CmdClear.Text = "清空"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'LblCost
        '
        Me.LblCost.AutoSize = True
        Me.LblCost.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCost.Location = New System.Drawing.Point(19, 430)
        Me.LblCost.Name = "LblCost"
        Me.LblCost.Size = New System.Drawing.Size(106, 29)
        Me.LblCost.TabIndex = 20
        Me.LblCost.Text = "费用："
        '
        'ChkE
        '
        Me.ChkE.AutoSize = True
        Me.ChkE.Location = New System.Drawing.Point(118, 437)
        Me.ChkE.Name = "ChkE"
        Me.ChkE.Size = New System.Drawing.Size(36, 16)
        Me.ChkE.TabIndex = 21
        Me.ChkE.Text = "东"
        Me.ChkE.UseVisualStyleBackColor = True
        '
        'ChkF
        '
        Me.ChkF.AutoSize = True
        Me.ChkF.Location = New System.Drawing.Point(372, 437)
        Me.ChkF.Name = "ChkF"
        Me.ChkF.Size = New System.Drawing.Size(36, 16)
        Me.ChkF.TabIndex = 22
        Me.ChkF.Text = "斗"
        Me.ChkF.UseVisualStyleBackColor = True
        '
        'ChkT
        '
        Me.ChkT.AutoSize = True
        Me.ChkT.Location = New System.Drawing.Point(245, 492)
        Me.ChkT.Name = "ChkT"
        Me.ChkT.Size = New System.Drawing.Size(36, 16)
        Me.ChkT.TabIndex = 23
        Me.ChkT.Text = "科"
        Me.ChkT.UseVisualStyleBackColor = True
        '
        'ChkG
        '
        Me.ChkG.AutoSize = True
        Me.ChkG.Location = New System.Drawing.Point(245, 437)
        Me.ChkG.Name = "ChkG"
        Me.ChkG.Size = New System.Drawing.Size(36, 16)
        Me.ChkG.TabIndex = 24
        Me.ChkG.Text = "神"
        Me.ChkG.UseVisualStyleBackColor = True
        '
        'ChkM
        '
        Me.ChkM.AutoSize = True
        Me.ChkM.Location = New System.Drawing.Point(118, 492)
        Me.ChkM.Name = "ChkM"
        Me.ChkM.Size = New System.Drawing.Size(36, 16)
        Me.ChkM.TabIndex = 25
        Me.ChkM.Text = "魔"
        Me.ChkM.UseVisualStyleBackColor = True
        '
        'TxtE
        '
        Me.TxtE.Enabled = False
        Me.TxtE.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtE.Location = New System.Drawing.Point(154, 434)
        Me.TxtE.Name = "TxtE"
        Me.TxtE.Size = New System.Drawing.Size(45, 22)
        Me.TxtE.TabIndex = 26
        '
        'TxtF
        '
        Me.TxtF.Enabled = False
        Me.TxtF.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtF.Location = New System.Drawing.Point(414, 434)
        Me.TxtF.Name = "TxtF"
        Me.TxtF.Size = New System.Drawing.Size(45, 22)
        Me.TxtF.TabIndex = 27
        '
        'TxtT
        '
        Me.TxtT.Enabled = False
        Me.TxtT.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtT.Location = New System.Drawing.Point(287, 489)
        Me.TxtT.Name = "TxtT"
        Me.TxtT.Size = New System.Drawing.Size(45, 22)
        Me.TxtT.TabIndex = 28
        '
        'TxtG
        '
        Me.TxtG.Enabled = False
        Me.TxtG.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtG.Location = New System.Drawing.Point(287, 434)
        Me.TxtG.Name = "TxtG"
        Me.TxtG.Size = New System.Drawing.Size(45, 22)
        Me.TxtG.TabIndex = 29
        '
        'TxtM
        '
        Me.TxtM.Enabled = False
        Me.TxtM.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtM.Location = New System.Drawing.Point(154, 489)
        Me.TxtM.Name = "TxtM"
        Me.TxtM.Size = New System.Drawing.Size(45, 22)
        Me.TxtM.TabIndex = 30
        '
        'LblAny
        '
        Me.LblAny.AutoSize = True
        Me.LblAny.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblAny.Location = New System.Drawing.Point(367, 496)
        Me.LblAny.Name = "LblAny"
        Me.LblAny.Size = New System.Drawing.Size(41, 12)
        Me.LblAny.TabIndex = 31
        Me.LblAny.Text = "任意："
        '
        'TxtAny
        '
        Me.TxtAny.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtAny.Location = New System.Drawing.Point(414, 489)
        Me.TxtAny.Name = "TxtAny"
        Me.TxtAny.Size = New System.Drawing.Size(45, 22)
        Me.TxtAny.TabIndex = 32
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 750)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdMake)
        Me.Controls.Add(Me.GrpCard)
        Me.Controls.Add(Me.GrpCardInfo)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GrpCardInfo.ResumeLayout(False)
        Me.GrpCardInfo.PerformLayout()
        Me.GrpCard.ResumeLayout(False)
        CType(Me.PicCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpCardInfo As GroupBox
    Friend WithEvents TxtDescribe As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtEffect As TextBox
    Friend WithEvents LblEffect As Label
    Friend WithEvents CmdBrowse As Button
    Friend WithEvents TxtPicAddress As TextBox
    Friend WithEvents TxtDEF As TextBox
    Friend WithEvents TxtATK As TextBox
    Friend WithEvents TxtMP As TextBox
    Friend WithEvents TxtHP As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblHP As Label
    Friend WithEvents LblMP As Label
    Friend WithEvents LblATK As Label
    Friend WithEvents LblDEF As Label
    Friend WithEvents LblPic As Label
    Friend WithEvents LblName As Label
    Friend WithEvents GrpCard As GroupBox
    Friend WithEvents PicCard As PictureBox
    Friend WithEvents OFDCardIPic As OpenFileDialog
    Friend WithEvents SFDCardFPic As SaveFileDialog
    Friend WithEvents CmdMake As Button
    Friend WithEvents CmdClear As Button
    Friend WithEvents FBDCardPic As FolderBrowserDialog
    Friend WithEvents CmdAddPic As Button
    Friend WithEvents TxtAny As TextBox
    Friend WithEvents LblAny As Label
    Friend WithEvents TxtM As TextBox
    Friend WithEvents TxtG As TextBox
    Friend WithEvents TxtT As TextBox
    Friend WithEvents TxtF As TextBox
    Friend WithEvents TxtE As TextBox
    Friend WithEvents ChkM As CheckBox
    Friend WithEvents ChkG As CheckBox
    Friend WithEvents ChkT As CheckBox
    Friend WithEvents ChkF As CheckBox
    Friend WithEvents ChkE As CheckBox
    Friend WithEvents LblCost As Label
End Class
