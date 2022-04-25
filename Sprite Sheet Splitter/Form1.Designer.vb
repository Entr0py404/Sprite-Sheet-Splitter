<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NumericUpDownH = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDownV = New System.Windows.Forms.NumericUpDown()
        Me.Label_EstimatedSpriteSize = New System.Windows.Forms.Label()
        Me.TextBox_ExportDirectory = New System.Windows.Forms.TextBox()
        Me.TextBox_FileName = New System.Windows.Forms.TextBox()
        Me.Label_FileName = New System.Windows.Forms.Label()
        Me.Label_ExportDirectory = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel_Image = New System.Windows.Forms.Panel()
        Me.PixelBoxGrid = New Sprite_Sheet_Splitter.PixelBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_SizeMode = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox_SizeMode = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel_ZoomLvl = New System.Windows.Forms.ToolStripLabel()
        Me.PictureBox_SpriteSheet = New System.Windows.Forms.PictureBox()
        Me.Button_SelectExportDirectory = New System.Windows.Forms.Button()
        Me.Button_SplitSpriteSheet = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape5 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletionNotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.NumericUpDownH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Image.SuspendLayout()
        CType(Me.PixelBoxGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox_SpriteSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumericUpDownH
        '
        Me.NumericUpDownH.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.NumericUpDownH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDownH.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDownH.Location = New System.Drawing.Point(160, 40)
        Me.NumericUpDownH.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDownH.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownH.Name = "NumericUpDownH"
        Me.NumericUpDownH.Size = New System.Drawing.Size(56, 16)
        Me.NumericUpDownH.TabIndex = 1
        Me.NumericUpDownH.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Number of horizontal cells:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Number of vertical cells:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericUpDownV
        '
        Me.NumericUpDownV.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.NumericUpDownV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDownV.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDownV.Location = New System.Drawing.Point(160, 80)
        Me.NumericUpDownV.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDownV.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownV.Name = "NumericUpDownV"
        Me.NumericUpDownV.Size = New System.Drawing.Size(56, 16)
        Me.NumericUpDownV.TabIndex = 2
        Me.NumericUpDownV.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label_EstimatedSpriteSize
        '
        Me.Label_EstimatedSpriteSize.AutoSize = True
        Me.Label_EstimatedSpriteSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label_EstimatedSpriteSize.Location = New System.Drawing.Point(16, 120)
        Me.Label_EstimatedSpriteSize.Name = "Label_EstimatedSpriteSize"
        Me.Label_EstimatedSpriteSize.Size = New System.Drawing.Size(106, 13)
        Me.Label_EstimatedSpriteSize.TabIndex = 15
        Me.Label_EstimatedSpriteSize.Text = "Estimated Sprite Size"
        '
        'TextBox_ExportDirectory
        '
        Me.TextBox_ExportDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TextBox_ExportDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_ExportDirectory.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox_ExportDirectory.Location = New System.Drawing.Point(128, 200)
        Me.TextBox_ExportDirectory.Name = "TextBox_ExportDirectory"
        Me.TextBox_ExportDirectory.ReadOnly = True
        Me.TextBox_ExportDirectory.Size = New System.Drawing.Size(128, 13)
        Me.TextBox_ExportDirectory.TabIndex = 4
        Me.TextBox_ExportDirectory.TabStop = False
        '
        'TextBox_FileName
        '
        Me.TextBox_FileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TextBox_FileName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_FileName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox_FileName.Location = New System.Drawing.Point(128, 160)
        Me.TextBox_FileName.Name = "TextBox_FileName"
        Me.TextBox_FileName.Size = New System.Drawing.Size(128, 13)
        Me.TextBox_FileName.TabIndex = 3
        '
        'Label_FileName
        '
        Me.Label_FileName.Location = New System.Drawing.Point(56, 152)
        Me.Label_FileName.Name = "Label_FileName"
        Me.Label_FileName.Size = New System.Drawing.Size(60, 24)
        Me.Label_FileName.TabIndex = 18
        Me.Label_FileName.Text = "File name:"
        Me.Label_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_ExportDirectory
        '
        Me.Label_ExportDirectory.Location = New System.Drawing.Point(24, 192)
        Me.Label_ExportDirectory.Name = "Label_ExportDirectory"
        Me.Label_ExportDirectory.Size = New System.Drawing.Size(92, 24)
        Me.Label_ExportDirectory.TabIndex = 19
        Me.Label_ExportDirectory.Text = "Export directory:"
        Me.Label_ExportDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel_Image
        '
        Me.Panel_Image.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel_Image.Controls.Add(Me.PixelBoxGrid)
        Me.Panel_Image.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Image.Location = New System.Drawing.Point(0, 32)
        Me.Panel_Image.Name = "Panel_Image"
        Me.Panel_Image.Size = New System.Drawing.Size(332, 217)
        Me.Panel_Image.TabIndex = 82
        '
        'PixelBoxGrid
        '
        Me.PixelBoxGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PixelBoxGrid.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
        Me.PixelBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PixelBoxGrid.Location = New System.Drawing.Point(0, 0)
        Me.PixelBoxGrid.Name = "PixelBoxGrid"
        Me.PixelBoxGrid.Size = New System.Drawing.Size(332, 217)
        Me.PixelBoxGrid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PixelBoxGrid.TabIndex = 85
        Me.PixelBoxGrid.TabStop = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 32)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Drag And Drop Sprite Sheet Here"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColorDialog1
        '
        Me.ColorDialog1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel_Image)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.NumericUpDownH)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox_SpriteSheet)
        Me.SplitContainer1.Panel2.Controls.Add(Me.NumericUpDownV)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_ExportDirectory)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_FileName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button_SelectExportDirectory)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button_SplitSpriteSheet)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_EstimatedSpriteSize)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_FileName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_ExportDirectory)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(690, 274)
        Me.SplitContainer1.SplitterDistance = 332
        Me.SplitContainer1.TabIndex = 84
        Me.SplitContainer1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 32)
        Me.Panel2.TabIndex = 87
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_SizeMode, Me.ToolStripComboBox_SizeMode, Me.ToolStripLabel_ZoomLvl})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 249)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(332, 25)
        Me.ToolStrip1.TabIndex = 89
        '
        'ToolStripLabel_SizeMode
        '
        Me.ToolStripLabel_SizeMode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel_SizeMode.Name = "ToolStripLabel_SizeMode"
        Me.ToolStripLabel_SizeMode.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel_SizeMode.Text = "Size Mode:"
        '
        'ToolStripComboBox_SizeMode
        '
        Me.ToolStripComboBox_SizeMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ToolStripComboBox_SizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox_SizeMode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripComboBox_SizeMode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripComboBox_SizeMode.Items.AddRange(New Object() {"Zoom", "Fixed Zoom", "Normal", "Center"})
        Me.ToolStripComboBox_SizeMode.Name = "ToolStripComboBox_SizeMode"
        Me.ToolStripComboBox_SizeMode.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel_ZoomLvl
        '
        Me.ToolStripLabel_ZoomLvl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel_ZoomLvl.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel_ZoomLvl.Name = "ToolStripLabel_ZoomLvl"
        Me.ToolStripLabel_ZoomLvl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripLabel_ZoomLvl.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripLabel_ZoomLvl.Text = "Zoom: 100%"
        '
        'PictureBox_SpriteSheet
        '
        Me.PictureBox_SpriteSheet.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.PictureBox_SpriteSheet.Location = New System.Drawing.Point(232, 32)
        Me.PictureBox_SpriteSheet.Name = "PictureBox_SpriteSheet"
        Me.PictureBox_SpriteSheet.Size = New System.Drawing.Size(88, 72)
        Me.PictureBox_SpriteSheet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_SpriteSheet.TabIndex = 1
        Me.PictureBox_SpriteSheet.TabStop = False
        Me.PictureBox_SpriteSheet.Visible = False
        '
        'Button_SelectExportDirectory
        '
        Me.Button_SelectExportDirectory.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button_SelectExportDirectory.FlatAppearance.BorderSize = 0
        Me.Button_SelectExportDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_SelectExportDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SelectExportDirectory.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button_SelectExportDirectory.Location = New System.Drawing.Point(272, 192)
        Me.Button_SelectExportDirectory.Name = "Button_SelectExportDirectory"
        Me.Button_SelectExportDirectory.Size = New System.Drawing.Size(72, 24)
        Me.Button_SelectExportDirectory.TabIndex = 5
        Me.Button_SelectExportDirectory.Text = "..."
        Me.Button_SelectExportDirectory.UseVisualStyleBackColor = False
        '
        'Button_SplitSpriteSheet
        '
        Me.Button_SplitSpriteSheet.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Button_SplitSpriteSheet.FlatAppearance.BorderSize = 0
        Me.Button_SplitSpriteSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_SplitSpriteSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SplitSpriteSheet.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button_SplitSpriteSheet.Location = New System.Drawing.Point(120, 232)
        Me.Button_SplitSpriteSheet.Name = "Button_SplitSpriteSheet"
        Me.Button_SplitSpriteSheet.Size = New System.Drawing.Size(144, 32)
        Me.Button_SplitSpriteSheet.TabIndex = 6
        Me.Button_SplitSpriteSheet.Text = "Split"
        Me.Button_SplitSpriteSheet.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape3, Me.RectangleShape4, Me.RectangleShape5})
        Me.ShapeContainer1.Size = New System.Drawing.Size(354, 274)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 3
        Me.RectangleShape2.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape2.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape2.Location = New System.Drawing.Point(155, 31)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Size = New System.Drawing.Size(68, 32)
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape3.CornerRadius = 3
        Me.RectangleShape3.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape3.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape3.Location = New System.Drawing.Point(155, 72)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape3.Size = New System.Drawing.Size(68, 32)
        '
        'RectangleShape4
        '
        Me.RectangleShape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape4.CornerRadius = 3
        Me.RectangleShape4.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape4.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape4.Location = New System.Drawing.Point(123, 153)
        Me.RectangleShape4.Name = "RectangleShape4"
        Me.RectangleShape4.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape4.Size = New System.Drawing.Size(136, 24)
        '
        'RectangleShape5
        '
        Me.RectangleShape5.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape5.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape5.CornerRadius = 3
        Me.RectangleShape5.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape5.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape5.Location = New System.Drawing.Point(123, 193)
        Me.RectangleShape5.Name = "RectangleShape5"
        Me.RectangleShape5.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape5.Size = New System.Drawing.Size(136, 24)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(690, 32)
        Me.MenuStrip1.TabIndex = 85
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.GridColorToolStripMenuItem, Me.CompletionNotificationToolStripMenuItem})
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripMenuItem1.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Settings
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(85, 28)
        Me.ToolStripMenuItem1.Text = "Settings"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ClearToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ClearToolStripMenuItem.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Clear
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'GridColorToolStripMenuItem
        '
        Me.GridColorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.GridColorToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.GridColorToolStripMenuItem.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Color
        Me.GridColorToolStripMenuItem.Name = "GridColorToolStripMenuItem"
        Me.GridColorToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.GridColorToolStripMenuItem.Text = "Grid Color"
        '
        'CompletionNotificationToolStripMenuItem
        '
        Me.CompletionNotificationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.CompletionNotificationToolStripMenuItem.Checked = True
        Me.CompletionNotificationToolStripMenuItem.CheckOnClick = True
        Me.CompletionNotificationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CompletionNotificationToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CompletionNotificationToolStripMenuItem.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Notification
        Me.CompletionNotificationToolStripMenuItem.Name = "CompletionNotificationToolStripMenuItem"
        Me.CompletionNotificationToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CompletionNotificationToolStripMenuItem.Text = "Completion Notification"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(690, 306)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(648, 345)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sprite Sheet Splitter"
        CType(Me.NumericUpDownH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Image.ResumeLayout(False)
        CType(Me.PixelBoxGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox_SpriteSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NumericUpDownH As NumericUpDown
    Friend WithEvents PictureBox_SpriteSheet As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDownV As NumericUpDown
    Friend WithEvents Button_SplitSpriteSheet As Button
    Friend WithEvents Label_EstimatedSpriteSize As Label
    Friend WithEvents TextBox_ExportDirectory As TextBox
    Friend WithEvents TextBox_FileName As TextBox
    Friend WithEvents Label_FileName As Label
    Friend WithEvents Label_ExportDirectory As Label
    Friend WithEvents Button_SelectExportDirectory As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Panel_Image As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As PowerPacks.RectangleShape
    Friend WithEvents RectangleShape3 As PowerPacks.RectangleShape
    Friend WithEvents RectangleShape4 As PowerPacks.RectangleShape
    Friend WithEvents RectangleShape5 As PowerPacks.RectangleShape
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GridColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletionNotificationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel_SizeMode As ToolStripLabel
    Friend WithEvents ToolStripComboBox_SizeMode As ToolStripComboBox
    Friend WithEvents ToolStripLabel_ZoomLvl As ToolStripLabel
    Friend WithEvents PixelBoxGrid As PixelBox
End Class
