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
        Me.NumericUpDown_Hori = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Vert = New System.Windows.Forms.NumericUpDown()
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Offset_Vert = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_Offset_Hori = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox_NinePatchMode = New System.Windows.Forms.CheckBox()
        Me.Button_SelectExportDirectory = New System.Windows.Forms.Button()
        Me.Button_SplitSpriteSheet = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape6 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape5 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletionNotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.NumericUpDown_Hori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Vert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Image.SuspendLayout()
        CType(Me.PixelBoxGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.NumericUpDown_Offset_Vert, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Offset_Hori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumericUpDown_Hori
        '
        Me.NumericUpDown_Hori.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.NumericUpDown_Hori.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown_Hori.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown_Hori.Location = New System.Drawing.Point(160, 56)
        Me.NumericUpDown_Hori.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_Hori.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_Hori.Name = "NumericUpDown_Hori"
        Me.NumericUpDown_Hori.Size = New System.Drawing.Size(56, 16)
        Me.NumericUpDown_Hori.TabIndex = 1
        Me.NumericUpDown_Hori.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Number of horizontal cells:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Number of vertical cells:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericUpDown_Vert
        '
        Me.NumericUpDown_Vert.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.NumericUpDown_Vert.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown_Vert.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown_Vert.Location = New System.Drawing.Point(160, 96)
        Me.NumericUpDown_Vert.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_Vert.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_Vert.Name = "NumericUpDown_Vert"
        Me.NumericUpDown_Vert.Size = New System.Drawing.Size(56, 16)
        Me.NumericUpDown_Vert.TabIndex = 2
        Me.NumericUpDown_Vert.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label_EstimatedSpriteSize
        '
        Me.Label_EstimatedSpriteSize.AutoSize = True
        Me.Label_EstimatedSpriteSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label_EstimatedSpriteSize.Location = New System.Drawing.Point(16, 136)
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
        Me.TextBox_ExportDirectory.Location = New System.Drawing.Point(128, 216)
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
        Me.TextBox_FileName.Location = New System.Drawing.Point(128, 176)
        Me.TextBox_FileName.Name = "TextBox_FileName"
        Me.TextBox_FileName.Size = New System.Drawing.Size(128, 13)
        Me.TextBox_FileName.TabIndex = 3
        '
        'Label_FileName
        '
        Me.Label_FileName.Location = New System.Drawing.Point(56, 168)
        Me.Label_FileName.Name = "Label_FileName"
        Me.Label_FileName.Size = New System.Drawing.Size(60, 24)
        Me.Label_FileName.TabIndex = 18
        Me.Label_FileName.Text = "File name:"
        Me.Label_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_ExportDirectory
        '
        Me.Label_ExportDirectory.Location = New System.Drawing.Point(24, 208)
        Me.Label_ExportDirectory.Name = "Label_ExportDirectory"
        Me.Label_ExportDirectory.Size = New System.Drawing.Size(92, 24)
        Me.Label_ExportDirectory.TabIndex = 19
        Me.Label_ExportDirectory.Text = "Export directory:"
        Me.Label_ExportDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel_Image
        '
        Me.Panel_Image.AllowDrop = True
        Me.Panel_Image.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel_Image.Controls.Add(Me.PixelBoxGrid)
        Me.Panel_Image.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Image.Location = New System.Drawing.Point(0, 32)
        Me.Panel_Image.Name = "Panel_Image"
        Me.Panel_Image.Size = New System.Drawing.Size(418, 318)
        Me.Panel_Image.TabIndex = 82
        '
        'PixelBoxGrid
        '
        Me.PixelBoxGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PixelBoxGrid.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
        Me.PixelBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PixelBoxGrid.Location = New System.Drawing.Point(0, 0)
        Me.PixelBoxGrid.Name = "PixelBoxGrid"
        Me.PixelBoxGrid.Size = New System.Drawing.Size(418, 318)
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
        Me.Label1.Size = New System.Drawing.Size(418, 32)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Drag && Drop Sprite Sheet Here"
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.NumericUpDown_Offset_Vert)
        Me.SplitContainer1.Panel2.Controls.Add(Me.NumericUpDown_Offset_Hori)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckBox_NinePatchMode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.NumericUpDown_Hori)
        Me.SplitContainer1.Panel2.Controls.Add(Me.NumericUpDown_Vert)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(788, 375)
        Me.SplitContainer1.SplitterDistance = 418
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
        Me.Panel2.Size = New System.Drawing.Size(418, 32)
        Me.Panel2.TabIndex = 87
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_SizeMode, Me.ToolStripComboBox_SizeMode, Me.ToolStripLabel_ZoomLvl})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 350)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(418, 25)
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
        Me.ToolStripComboBox_SizeMode.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.ToolStripComboBox_SizeMode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripComboBox_SizeMode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripComboBox_SizeMode.Items.AddRange(New Object() {"Zoom", "Fixed Zoom", "Normal", "Center"})
        Me.ToolStripComboBox_SizeMode.Name = "ToolStripComboBox_SizeMode"
        Me.ToolStripComboBox_SizeMode.Size = New System.Drawing.Size(100, 25)
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
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(240, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 21)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Offset"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumericUpDown_Offset_Vert
        '
        Me.NumericUpDown_Offset_Vert.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.NumericUpDown_Offset_Vert.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown_Offset_Vert.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown_Offset_Vert.Location = New System.Drawing.Point(248, 96)
        Me.NumericUpDown_Offset_Vert.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_Offset_Vert.Name = "NumericUpDown_Offset_Vert"
        Me.NumericUpDown_Offset_Vert.Size = New System.Drawing.Size(56, 16)
        Me.NumericUpDown_Offset_Vert.TabIndex = 23
        '
        'NumericUpDown_Offset_Hori
        '
        Me.NumericUpDown_Offset_Hori.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.NumericUpDown_Offset_Hori.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown_Offset_Hori.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown_Offset_Hori.Location = New System.Drawing.Point(248, 56)
        Me.NumericUpDown_Offset_Hori.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_Offset_Hori.Name = "NumericUpDown_Offset_Hori"
        Me.NumericUpDown_Offset_Hori.Size = New System.Drawing.Size(56, 16)
        Me.NumericUpDown_Offset_Hori.TabIndex = 22
        '
        'CheckBox_NinePatchMode
        '
        Me.CheckBox_NinePatchMode.AutoSize = True
        Me.CheckBox_NinePatchMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_NinePatchMode.Location = New System.Drawing.Point(58, 16)
        Me.CheckBox_NinePatchMode.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CheckBox_NinePatchMode.Name = "CheckBox_NinePatchMode"
        Me.CheckBox_NinePatchMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_NinePatchMode.Size = New System.Drawing.Size(130, 17)
        Me.CheckBox_NinePatchMode.TabIndex = 21
        Me.CheckBox_NinePatchMode.Text = " :Nine patch mode"
        Me.CheckBox_NinePatchMode.UseVisualStyleBackColor = True
        '
        'Button_SelectExportDirectory
        '
        Me.Button_SelectExportDirectory.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button_SelectExportDirectory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button_SelectExportDirectory.FlatAppearance.BorderSize = 0
        Me.Button_SelectExportDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_SelectExportDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SelectExportDirectory.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button_SelectExportDirectory.Location = New System.Drawing.Point(272, 208)
        Me.Button_SelectExportDirectory.Name = "Button_SelectExportDirectory"
        Me.Button_SelectExportDirectory.Size = New System.Drawing.Size(72, 24)
        Me.Button_SelectExportDirectory.TabIndex = 5
        Me.Button_SelectExportDirectory.Text = "..."
        Me.Button_SelectExportDirectory.UseVisualStyleBackColor = False
        '
        'Button_SplitSpriteSheet
        '
        Me.Button_SplitSpriteSheet.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Button_SplitSpriteSheet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button_SplitSpriteSheet.FlatAppearance.BorderSize = 0
        Me.Button_SplitSpriteSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_SplitSpriteSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SplitSpriteSheet.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button_SplitSpriteSheet.Location = New System.Drawing.Point(120, 248)
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
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape6, Me.RectangleShape1, Me.RectangleShape2, Me.RectangleShape3, Me.RectangleShape4, Me.RectangleShape5})
        Me.ShapeContainer1.Size = New System.Drawing.Size(366, 375)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape6
        '
        Me.RectangleShape6.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape6.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape6.CornerRadius = 3
        Me.RectangleShape6.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape6.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape6.Location = New System.Drawing.Point(240, 88)
        Me.RectangleShape6.Name = "RectangleShape6"
        Me.RectangleShape6.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape6.Size = New System.Drawing.Size(72, 32)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape1.CornerRadius = 3
        Me.RectangleShape1.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape1.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape1.Location = New System.Drawing.Point(240, 48)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Size = New System.Drawing.Size(72, 32)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 3
        Me.RectangleShape2.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape2.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape2.Location = New System.Drawing.Point(152, 48)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Size = New System.Drawing.Size(72, 32)
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape3.CornerRadius = 3
        Me.RectangleShape3.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape3.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape3.Location = New System.Drawing.Point(152, 88)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape3.Size = New System.Drawing.Size(72, 32)
        '
        'RectangleShape4
        '
        Me.RectangleShape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.RectangleShape4.CornerRadius = 3
        Me.RectangleShape4.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape4.FillGradientColor = System.Drawing.Color.WhiteSmoke
        Me.RectangleShape4.Location = New System.Drawing.Point(120, 168)
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
        Me.RectangleShape5.Location = New System.Drawing.Point(120, 208)
        Me.RectangleShape5.Name = "RectangleShape5"
        Me.RectangleShape5.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape5.Size = New System.Drawing.Size(136, 24)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(788, 32)
        Me.MenuStrip1.TabIndex = 85
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.GridColorToolStripMenuItem, Me.CompletionNotificationToolStripMenuItem})
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripMenuItem1.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Settings
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(102, 28)
        Me.ToolStripMenuItem1.Text = "Settings"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ClearToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ClearToolStripMenuItem.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Clear
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(254, 30)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'GridColorToolStripMenuItem
        '
        Me.GridColorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.GridColorToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.GridColorToolStripMenuItem.Image = Global.Sprite_Sheet_Splitter.My.Resources.Resources.Color
        Me.GridColorToolStripMenuItem.Name = "GridColorToolStripMenuItem"
        Me.GridColorToolStripMenuItem.Size = New System.Drawing.Size(254, 30)
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
        Me.CompletionNotificationToolStripMenuItem.Size = New System.Drawing.Size(254, 30)
        Me.CompletionNotificationToolStripMenuItem.Text = "Completion Notification"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(788, 407)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(648, 345)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sprite Sheet Splitter"
        CType(Me.NumericUpDown_Hori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Vert, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.NumericUpDown_Offset_Vert, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Offset_Hori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NumericUpDown_Hori As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown_Vert As NumericUpDown
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
    Friend WithEvents CheckBox_NinePatchMode As CheckBox
    Friend WithEvents NumericUpDown_Offset_Hori As NumericUpDown
    Friend WithEvents NumericUpDown_Offset_Vert As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents RectangleShape6 As PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As PowerPacks.RectangleShape
End Class
