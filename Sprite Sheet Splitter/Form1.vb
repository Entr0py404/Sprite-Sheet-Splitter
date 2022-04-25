Imports System.ComponentModel
Public Class Form1
    Dim EstimatedSpriteWidth As Integer = 0
    Dim EstimatedSpriteHeight As Integer = 0
    Public GridColor As New Pen(Color.FromArgb(0, 255, 128)) 'Color of the lines
    Dim ZoomCounter As Integer = 100
    ReadOnly SupportedIamgeFormats() As String = {".png", ".bmp", ".jpeg", ".jpg", ".tiff", ".tif"}
    Dim EventsOn As Boolean = False
    'Form1 - Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel_Image.AllowDrop = True
        'Load setttings
        CompletionNotificationToolStripMenuItem.Checked = My.Settings.CompletionNotification
        GridColor.Color = My.Settings.GridColor
        Label_EstimatedSpriteSize.ForeColor = GridColor.Color
        ToolStripComboBox_SizeMode.SelectedIndex = My.Settings.SizeModeIndex
        EventsOn = True
    End Sub
    'NumericUpDownH - ValueChanged
    Private Sub NumericUpDownH_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownH.ValueChanged
        If PictureBox_SpriteSheet.Image IsNot Nothing Then
            If NumericUpDownH.Value > 1 Then
                EstimatedSpriteWidth = CInt(PictureBox_SpriteSheet.Image.Width / NumericUpDownH.Value)
            Else
                EstimatedSpriteWidth = PictureBox_SpriteSheet.Image.Width
            End If
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"
            MakeTransparent_GridBitmap()
        End If
    End Sub
    'NumericUpDownV - ValueChanged
    Private Sub NumericUpDownV_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownV.ValueChanged
        If PictureBox_SpriteSheet.Image IsNot Nothing Then
            If NumericUpDownV.Value > 1 Then
                EstimatedSpriteHeight = CInt(PictureBox_SpriteSheet.Image.Height / NumericUpDownV.Value)
            Else
                EstimatedSpriteHeight = PictureBox_SpriteSheet.Image.Height
            End If
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"
            MakeTransparent_GridBitmap()
        End If
    End Sub
    'Button_SelectExportDirectory - Click
    Private Sub Button_SelectExportDirectory_Click(sender As Object, e As EventArgs) Handles Button_SelectExportDirectory.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox_ExportDirectory.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    'Button_SplitSheet - Click
    Private Sub Button_SplitSpriteStrip_Click(sender As Object, e As EventArgs) Handles Button_SplitSpriteSheet.Click
        If PictureBox_SpriteSheet.Image IsNot Nothing Then
            Dim MainLoopIndex As Integer = 0
            For indexH As Integer = 0 To CInt(NumericUpDownV.Value - 1)
                For indexW As Integer = 0 To CInt(NumericUpDownH.Value - 1)
                    MainLoopIndex += 1
                    Dim CropRect As Rectangle
                    Dim W As Integer = 0
                    If indexW > 0 Then
                        W = EstimatedSpriteWidth * indexW
                    End If
                    Dim H As Integer = 0
                    If indexH > 0 Then
                        H = EstimatedSpriteHeight * indexH
                    End If
                    CropRect = New Rectangle(W, H, EstimatedSpriteWidth, EstimatedSpriteHeight)
                    Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.SmoothingMode = SmoothingMode.None
                        grp.InterpolationMode = InterpolationMode.HighQualityBicubic
                        grp.CompositingQuality = CompositingQuality.HighQuality
                        grp.DrawImage(PictureBox_SpriteSheet.Image, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        grp.Dispose()
                    End Using
                    CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                    CropImage.Dispose()
                Next
            Next
            If CompletionNotificationToolStripMenuItem.Checked Then
                MsgBox("Sprite sheet split complete.", MsgBoxStyle.Information)
            End If
            ClearAllForNext()
        End If
    End Sub
    'MakeTransparent_GridBitmap
    Private Sub MakeTransparent_GridBitmap()
        If PictureBox_SpriteSheet.Image IsNot Nothing Then
            Dim x As Integer
            Dim y As Integer
            Dim intSpacingH As Integer = CInt(PictureBox_SpriteSheet.Image.Width / NumericUpDownH.Value)
            Dim intSpacingV As Integer = CInt(PictureBox_SpriteSheet.Image.Height / NumericUpDownV.Value)
            Dim GridBitmap = New Bitmap(PictureBox_SpriteSheet.Image.Width + 1, PictureBox_SpriteSheet.Image.Height + 1)
            Using grp = Graphics.FromImage(GridBitmap)
                grp.CompositingQuality = CompositingQuality.HighQuality
                grp.DrawImage(PictureBox_SpriteSheet.Image, 0, 0, GridBitmap.Width - 1, GridBitmap.Height - 1)
                'Draw the horizontal lines
                y = PictureBox_SpriteSheet.Image.Height
                For x = 0 To PictureBox_SpriteSheet.Image.Width + 1 Step intSpacingH
                    grp.DrawLine(GridColor, New Point(x, 0), New Point(x, y))
                Next
                'Draw the vertical lines
                x = PictureBox_SpriteSheet.Image.Width
                For y = 0 To PictureBox_SpriteSheet.Image.Height + 1 Step intSpacingV
                    grp.DrawLine(GridColor, New Point(0, y), New Point(x, y))
                Next
                grp.Dispose()
            End Using
            PixelBoxGrid.Image = GridBitmap
        End If
    End Sub
    'Panel_Image - DragDrop
    Private Sub Panel_Image_DragDrop(sender As Object, e As DragEventArgs) Handles Panel_Image.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length <> 0 Then
            Try
                ClearPictureboxes()
                PictureBox_SpriteSheet.Image = GetMemoryBitmapFromFile(files(0))
                TextBox_FileName.Text = Path.GetFileNameWithoutExtension(files(0))
                TextBox_ExportDirectory.Text = Path.GetDirectoryName(files(0))
                EstimatedSpriteWidth = CInt(PictureBox_SpriteSheet.Image.Width / NumericUpDownH.Value)
                EstimatedSpriteHeight = CInt(PictureBox_SpriteSheet.Image.Height / NumericUpDownV.Value)
                Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"
                MakeTransparent_GridBitmap()
            Catch ex As Exception
                MsgBox("Problem opening file.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    'Panel_Image - DragEnter
    Private Sub Panel_Image_DragEnter(sender As Object, e As DragEventArgs) Handles Panel_Image.DragEnter
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If e.Data.GetDataPresent(DataFormats.FileDrop) And SupportedIamgeFormats.Contains(Path.GetExtension(files(0)).ToLower) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    'ToolStripComboBox_SizeMode - SelectedIndexChanged
    Private Sub ToolStripComboBox_SizeMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox_SizeMode.SelectedIndexChanged
        If EventsOn = True Then
            My.Settings.SizeModeIndex = ToolStripComboBox_SizeMode.SelectedIndex
        End If

        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.Zoom
            ToolStripLabel_ZoomLvl.Text = "Zoom: " & ZoomCounter & "%"
            ToolStripLabel_ZoomLvl.Visible = True
            ZoomCounter = 100
            PixelBoxGrid.Dock = DockStyle.None
            ResizeAndPosistionPictureBox()
        ElseIf ToolStripComboBox_SizeMode.SelectedItem Is "Fixed Zoom" Then
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.Zoom
            ToolStripLabel_ZoomLvl.Visible = False
            PixelBoxGrid.Dock = DockStyle.Fill
        ElseIf ToolStripComboBox_SizeMode.SelectedItem Is "Normal" Then
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.Normal
            ToolStripLabel_ZoomLvl.Text = "Size Mode: Normal"
            ToolStripLabel_ZoomLvl.Visible = False
            PixelBoxGrid.Dock = DockStyle.Fill
        ElseIf ToolStripComboBox_SizeMode.SelectedItem Is "Center" Then
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.CenterImage
            ToolStripLabel_ZoomLvl.Text = "Size Mode: Center"
            ToolStripLabel_ZoomLvl.Visible = False
            PixelBoxGrid.Dock = DockStyle.Fill
        End If
    End Sub
    'GridColorToolStripMenuItem_Click
    Private Sub GridColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GridColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            GridColor.Color = ColorDialog1.Color
            Label_EstimatedSpriteSize.ForeColor = ColorDialog1.Color
            My.Settings.GridColor = ColorDialog1.Color
            MakeTransparent_GridBitmap()
        End If
    End Sub
    'ClearToolStripMenuItem - Click
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ClearAllForNext()
        NumericUpDownH.Value = 1
        NumericUpDownV.Value = 1
    End Sub
    'CompletionNotificationToolStripMenuItem - CheckedChanged
    Private Sub CompletionNotificationToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles CompletionNotificationToolStripMenuItem.CheckedChanged
        If EventsOn = True Then
            My.Settings.CompletionNotification = CompletionNotificationToolStripMenuItem.Checked
        End If
    End Sub
    'ResizeAndPosistionPictureBox
    Private Sub ResizeAndPosistionPictureBox()
        PixelBoxGrid.Size = ObjectScale(New Size(CType(Panel_Image.Size, Point)), ZoomCounter)
        PixelBoxGrid.Location = New Point(CInt((Panel_Image.Width / 2 - PixelBoxGrid.Width / 2)), CInt((Panel_Image.Height / 2 - PixelBoxGrid.Height / 2)))
    End Sub
    'PixelBoxGrid - MouseWheel
    Private Sub PixelBoxGrid_MouseWheel(sender As Object, e As MouseEventArgs) Handles PixelBoxGrid.MouseWheel
        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            If e.Delta < 0 And ZoomCounter < 100 Then 'Zoom in
                ZoomCounter += 5
                ToolStripLabel_ZoomLvl.Text = "Zoom: " & ZoomCounter & "%"
                PixelBoxGrid.Size = ObjectScale(New Size(CType(Panel_Image.Size, Point)), ZoomCounter)
                PixelBoxGrid.Location = New Point(CInt((Panel_Image.Width / 2 - PixelBoxGrid.Width / 2)), CInt((Panel_Image.Height / 2 - PixelBoxGrid.Height / 2)))
            ElseIf e.Delta > 0 And ZoomCounter > 10 Then 'Zoom out
                ZoomCounter -= 5
                ToolStripLabel_ZoomLvl.Text = "Zoom: " & ZoomCounter & "%"
                PixelBoxGrid.Size = ObjectScale(New Size(CType(Panel_Image.Size, Point)), ZoomCounter)
                PixelBoxGrid.Location = New Point(CInt((Panel_Image.Width / 2 - PixelBoxGrid.Width / 2)), CInt((Panel_Image.Height / 2 - PixelBoxGrid.Height / 2)))
            End If
        End If
    End Sub
    'Panel_Image - Resize
    Private Sub Panel_Image_Resize(sender As Object, e As EventArgs) Handles Panel_Image.Resize
        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            ResizeAndPosistionPictureBox()
        End If
    End Sub
    'ObjectScale
    Public Shared Function ObjectScale(size As Size, scalePercent As Single) As Size
        If Math.Abs(scalePercent - 1) < Single.Epsilon Then
            Return size
        End If
        Dim height = CInt(size.Height * (scalePercent / 100))
        Dim width = CInt(size.Width * (scalePercent / 100))
        Return New Size(width, height)
    End Function
    'TextBox_FileName - KeyPress
    Private Sub TextBox_FileName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_FileName.KeyPress
        If Not e.KeyChar = ChrW(Keys.Back) Then
            If New String(Path.GetInvalidFileNameChars()).Contains(e.KeyChar.ToString) Then
                e.Handled = True
            End If
        End If
    End Sub
    'GetMemoryBitmapFromFile(path)
    Public Shared Function GetMemoryBitmapFromFile(path As String) As Bitmap
        Dim bm As Bitmap
        Using img As Image = Image.FromFile(path)
            bm = New Bitmap(img)
        End Using
        Return bm
    End Function
    'Clear Pictureboxes
    Private Sub ClearPictureboxes()
        PictureBox_SpriteSheet.Image = Nothing
        PixelBoxGrid.Image = Nothing
        PictureBox_SpriteSheet.Refresh()
        PixelBoxGrid.Refresh()
    End Sub
    'Clear All For Next
    Private Sub ClearAllForNext()
        TextBox_ExportDirectory.Clear()
        TextBox_FileName.Clear()
        ClearPictureboxes()
        Label_EstimatedSpriteSize.Text = "Estimated Sprite Size"
    End Sub
    'ToolStripComboBox_SizeMode - DropDownClosed
    Private Sub ToolStripComboBox_SizeMode_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripComboBox_SizeMode.DropDownClosed
        PixelBoxGrid.Select()
    End Sub
    'ToolStripMenuItem1 - DropDownClosed
    Private Sub ToolStripMenuItem1_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.DropDownClosed
        ToolStripMenuItem1.ForeColor = Color.WhiteSmoke
    End Sub
    'ToolStripMenuItem1 - DropDownOpened
    Private Sub ToolStripMenuItem1_DropDownOpened(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.DropDownOpened
        ToolStripMenuItem1.ForeColor = Color.Black
    End Sub
End Class

Public Class PixelBox
    Inherits PictureBox

    <Category("Behavior")>
    <DefaultValue(InterpolationMode.NearestNeighbor)>
    Public Property InterpolationMode As InterpolationMode = InterpolationMode.NearestNeighbor

    <Category("Behavior")>
    <DefaultValue(PixelOffsetMode.Default)>
    Public Property PixelOffsetMode As PixelOffsetMode = PixelOffsetMode.Default

    <Category("Behavior")>
    <DefaultValue(SmoothingMode.Default)>
    Public Property SmoothingMode As SmoothingMode = SmoothingMode.Default

    <Category("Behavior")>
    <DefaultValue(CompositingQuality.Default)>
    Public Property CompositingQuality As CompositingQuality = CompositingQuality.Default

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.InterpolationMode = Me.InterpolationMode
        e.Graphics.PixelOffsetMode = Me.PixelOffsetMode
        e.Graphics.SmoothingMode = Me.SmoothingMode
        e.Graphics.CompositingQuality = Me.CompositingQuality
        MyBase.OnPaint(e)
    End Sub
End Class