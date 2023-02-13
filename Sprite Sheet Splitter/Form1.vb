
Imports System.Net.Security

Public Class Form1
    Dim EstimatedSpriteWidth As Integer = 0
    Dim EstimatedSpriteHeight As Integer = 0
    Public GridColor As New Pen(Color.FromArgb(0, 255, 128), 2) 'Color of the lines
    Dim ZoomCounter As Integer = 100
    ReadOnly SupportedIamgeFormats() As String = {".png", ".bmp", ".jpeg", ".jpg", ".tiff", ".tif"}
    ReadOnly NinePatchDirections() As String = {"northwest", "north", "northeast", "west", "center", "east", "southwest", "south", "southeast"}
    Dim EventsOn As Boolean = False
    Dim SpriteSheet_Image As Image
    Dim controlImage As Bitmap
    Dim EyeDropperMode As Boolean = False
    Dim NinePatchMode As Boolean = False
    Dim BulkMode As Boolean = False
    Dim ColorToTransparent As Boolean = False
    Dim RemoveBlanksFromExport As Boolean = False
    Private Declare Unicode Function LoadCursorFromFile Lib "user32.dll" Alias "LoadCursorFromFileW" (ByVal filename As String) As IntPtr
    'Form1 - Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load setttings
        CompletionNotificationToolStripMenuItem.Checked = My.Settings.CompletionNotification
        GridColor.Color = My.Settings.GridColor
        Label_EstimatedSpriteSize.ForeColor = GridColor.Color
        ToolStripComboBox_SizeMode.SelectedIndex = My.Settings.SizeModeIndex
        EventsOn = True
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        ToolStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        ContextMenuStrip_ListBox_Bulk.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        If Not File.Exists(Application.StartupPath & "\Eyedropper.cur") Then
            File.WriteAllBytes(Application.StartupPath & "\Eyedropper.cur", My.Resources.Eyedropper)
        End If
    End Sub
    'NumericUpDownH - ValueChanged
    Private Sub NumericUpDownH_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Hori.ValueChanged
        H_ValueChanged()
    End Sub
    'NumericUpDown_Offset_H - ValueChanged
    Private Sub NumericUpDown_Offset_H_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Offset_Hori.ValueChanged
        H_ValueChanged()
    End Sub
    'NumericUpDownV - ValueChanged
    Private Sub NumericUpDownV_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Vert.ValueChanged
        V_ValueChanged()
    End Sub
    'NumericUpDown_Offset_V - ValueChanged
    Private Sub NumericUpDown_Offset_V_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Offset_Vert.ValueChanged
        V_ValueChanged()
    End Sub
    'H_ValueChanged()
    Private Sub H_ValueChanged()
        If SpriteSheet_Image IsNot Nothing Then
            If NumericUpDown_Hori.Value > 1 Then
                EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            Else
                EstimatedSpriteWidth = SpriteSheet_Image.Width
            End If
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"
            MakeTransparent_GridBitmap()
        End If
    End Sub
    'V_ValueChanged()
    Private Sub V_ValueChanged()
        If SpriteSheet_Image IsNot Nothing Then
            If NumericUpDown_Vert.Value > 1 Then
                EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
            Else
                EstimatedSpriteHeight = SpriteSheet_Image.Height
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
        If BulkMode = True And Not ListBox_Bulk.Items.Count = 0 Then
            For Each item As String In ListBox_Bulk.Items
                SpriteSheet_Image = SafeImageFromFile(item)
                SplitSpriteStrip(Path.GetDirectoryName(item), Path.GetFileNameWithoutExtension(item))
            Next
            If CompletionNotificationToolStripMenuItem.Checked Then
                MsgBox("Bulk sprite sheet split complete.", MsgBoxStyle.Information)
            End If
            ClearAllForNext()
        Else
            If SpriteSheet_Image IsNot Nothing Then
                SplitSpriteStrip("", "")
                If CompletionNotificationToolStripMenuItem.Checked Then
                    MsgBox("Sprite sheet split complete.", MsgBoxStyle.Information)
                End If
                ClearAllForNext()
            End If
        End If
    End Sub
    'SplitSpriteStrip()
    Private Sub SplitSpriteStrip(imgPath As String, imgNameNoExt As String)

        If BulkMode = True And Not ListBox_Bulk.Items.Count = 0 Then
            SpriteSheet_Image = New Bitmap(Image.FromFile(imgPath & "\" & imgNameNoExt & ".png"))
            EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
        End If

        Dim Offset_Vert As Integer = CInt(NumericUpDown_Offset_Vert.Value)
        Dim MainLoopIndex As Integer = 0
        For indexH As Integer = 0 To CInt(NumericUpDown_Vert.Value - 1)
            Dim Offset_Hori As Integer = CInt(NumericUpDown_Offset_Hori.Value)
            For indexW As Integer = 0 To CInt(NumericUpDown_Hori.Value - 1)

                Dim CropRect As Rectangle

                Dim CropRect_X As Integer = 0
                If indexW > 0 Then
                    CropRect_X = (EstimatedSpriteWidth * indexW) + Offset_Hori * indexW
                End If

                Dim CropRect_Y As Integer = 0
                If indexH > 0 Then
                    CropRect_Y = (EstimatedSpriteHeight * indexH) + Offset_Vert * indexH
                End If

                CropRect = New Rectangle(CropRect_X, CropRect_Y, EstimatedSpriteWidth, EstimatedSpriteHeight)
                Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)

                Using grp = Graphics.FromImage(CropImage)
                    grp.SmoothingMode = SmoothingMode.None
                    grp.InterpolationMode = InterpolationMode.HighQualityBicubic
                    grp.CompositingQuality = CompositingQuality.HighQuality
                    grp.DrawImage(SpriteSheet_Image, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                    grp.Dispose()
                End Using

                If ColorToTransparent = True Then
                    CropImage.MakeTransparent(Button_EyeDropper.BackColor)
                End If

                Dim ImageHasColor As Boolean = False
                If RemoveBlanksFromExport = True Then
                    Dim TempColor As Color
                    For y As Integer = 0 To CropImage.Height - 1
                        If ImageHasColor = False Then
                            For x As Integer = 0 To CropImage.Width - 1
                                TempColor = CropImage.GetPixel(x, y)
                                If ColorToTransparent = True Then
                                    If Not TempColor = Button_EyeDropper.BackColor Or Not TempColor = Color.FromArgb(0, 0, 0, 0) Then
                                        ImageHasColor = True
                                        Exit For
                                    End If
                                Else
                                    If Not TempColor = Color.FromArgb(0, 0, 0, 0) Then
                                        ImageHasColor = True
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    Next

                    If ImageHasColor = True Then
                        MainLoopIndex += 1

                        If BulkMode = False And ListBox_Bulk.Items.Count = 0 Then
                            If NinePatchMode = False Then
                                CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                            Else
                                CropImage.Save(TextBox_ExportDirectory.Text & "\9patch_" & TextBox_FileName.Text & "_" & NinePatchDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                            End If
                        Else 'Bulk Mode
                            If NinePatchMode = False Then
                                CropImage.Save(imgPath & "\" & imgNameNoExt & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                            Else
                                CropImage.Save(imgPath & "\9patch_" & imgNameNoExt & "_" & NinePatchDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                            End If
                        End If
                        CropImage.Dispose()
                    End If

                Else
                    MainLoopIndex += 1

                    If BulkMode = False And ListBox_Bulk.Items.Count = 0 Then
                        If NinePatchMode = False Then
                            CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                        Else
                            CropImage.Save(TextBox_ExportDirectory.Text & "\9patch_" & TextBox_FileName.Text & "_" & NinePatchDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                        End If
                    Else 'Bulk Mode
                        If NinePatchMode = False Then
                            CropImage.Save(imgPath & "\" & imgNameNoExt & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                        Else
                            CropImage.Save(imgPath & "\9patch_" & imgNameNoExt & "_" & NinePatchDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                        End If
                    End If
                    CropImage.Dispose()
                End If

            Next
        Next
    End Sub
    'MakeTransparent_GridBitmap()
    Private Sub MakeTransparent_GridBitmap()
        If SpriteSheet_Image IsNot Nothing Then
            Dim x As Integer
            Dim y As Integer
            Dim intSpacingH As Integer = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value)
            Dim intSpacingV As Integer = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value)
            Dim GridBitmap = New Bitmap(SpriteSheet_Image.Width + 1, SpriteSheet_Image.Height + 1)
            Using grp = Graphics.FromImage(GridBitmap)
                grp.CompositingQuality = CompositingQuality.HighQuality
                grp.DrawImage(SpriteSheet_Image, 0, 0, GridBitmap.Width - 1, GridBitmap.Height - 1)
                'Draw the vertical lines
                y = SpriteSheet_Image.Height + 1
                For x = 1 - CInt(NumericUpDown_Offset_Hori.Value) To SpriteSheet_Image.Width + 1 Step intSpacingH
                    grp.DrawLine(GridColor, New Point(x, 0), New Point(x, y))
                Next
                'Draw the horizontal lines
                x = SpriteSheet_Image.Width '+ 1
                For y = 1 - CInt(NumericUpDown_Offset_Vert.Value) To SpriteSheet_Image.Height + 1 Step intSpacingV
                    grp.DrawLine(GridColor, New Point(0, y), New Point(x, y))
                Next
                grp.Dispose()
            End Using

            If ColorToTransparent = True Then
                GridBitmap.MakeTransparent(Button_EyeDropper.BackColor)
            End If

            PixelBoxGrid.Image = GridBitmap

        End If
    End Sub
    'Panel_Image - DragDrop
    Private Sub Panel_Image_DragDrop(sender As Object, e As DragEventArgs) Handles Panel_Image.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length <> 0 Then
            Try
                ClearPictureboxes()

                SpriteSheet_Image = SafeImageFromFile(files(0))

                TextBox_FileName.Text = Path.GetFileNameWithoutExtension(files(0))
                TextBox_ExportDirectory.Text = Path.GetDirectoryName(files(0))
                EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
                EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
                Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

                NumericUpDown_Offset_Hori.Maximum = SpriteSheet_Image.Width
                NumericUpDown_Offset_Vert.Maximum = SpriteSheet_Image.Height

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
        NumericUpDown_Hori.Value = 1
        NumericUpDown_Vert.Value = 1
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
    'Clear Pictureboxes
    Private Sub ClearPictureboxes()
        SpriteSheet_Image = Nothing
        PixelBoxGrid.Image = Nothing
        PixelBoxGrid.Refresh()
    End Sub
    'Clear All For Next
    Private Sub ClearAllForNext()
        TextBox_ExportDirectory.Clear()
        TextBox_FileName.Clear()
        ListBox_Bulk.Items.Clear()
        ClearPictureboxes()
        Label_EstimatedSpriteSize.Text = "Estimated Sprite Size"
        controlImage = Nothing
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
    'ListBox_Bulk_SelectedIndexChanged
    Private Sub ListBox_Bulk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Bulk.SelectedIndexChanged
        If Not ListBox_Bulk.SelectedIndex = -1 Then
            ClearPictureboxes()

            SpriteSheet_Image = SafeImageFromFile(ListBox_Bulk.SelectedItem.ToString)

            EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

            MakeTransparent_GridBitmap()
        End If
    End Sub
    'ListBox_Bulk - DragDrop
    Private Sub ListBox_Bulk_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox_Bulk.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length <> 0 Then
            Try
                For Each item In files
                    If SupportedIamgeFormats.Contains(Path.GetExtension(item).ToLower) Then
                        If Not ListBox_Bulk.Items.Contains(item) Then
                            ListBox_Bulk.Items.Add(item)
                        End If
                    End If
                Next

                If Not ListBox_Bulk.Items.Count = 0 Then
                    ListBox_Bulk.SelectedIndex = 0 'Select first item
                End If
            Catch ex As Exception
                MsgBox("Problem opening file.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    'ListBox_Bulk - DragEnter
    Private Sub ListBox_Bulk_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox_Bulk.DragEnter
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If e.Data.GetDataPresent(DataFormats.FileDrop) And SupportedIamgeFormats.Contains(Path.GetExtension(files(0)).ToLower) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    'ListBox_Bulk - DoubleClick
    Private Sub ListBox_Bulk_DoubleClick(sender As Object, e As EventArgs) Handles ListBox_Bulk.DoubleClick
        If Not ListBox_Bulk.SelectedIndex = -1 Then
            ListBox_Bulk.Items.RemoveAt(ListBox_Bulk.SelectedIndex)
            ClearPictureboxes()
        End If
    End Sub
    'SafeImageFromFile()
    Public Shared Function SafeImageFromFile(path As String) As Image
        Dim bytes = File.ReadAllBytes(path)
        Using ms As New MemoryStream(bytes)
            Dim img = Image.FromStream(ms)
            Return img
        End Using
    End Function
    'TextBox_ExportDirectory - TextChanged
    Private Sub TextBox_ExportDirectory_TextChanged(sender As Object, e As EventArgs) Handles TextBox_ExportDirectory.TextChanged
        ToolTip1.SetToolTip(TextBox_ExportDirectory, TextBox_ExportDirectory.Text)
    End Sub
    'Button_EyeDropper - Click
    Private Sub Button_EyeDropper_Click(sender As Object, e As EventArgs) Handles Button_EyeDropper.Click
        EyeDropperMode = True
        PictureBox_EyeDropper.Visible = True
        If File.Exists(Application.StartupPath & "\Eyedropper.cur") Then
            PixelBoxGrid.Cursor = New Cursor(LoadCursorFromFile(Application.StartupPath & "\Eyedropper.cur"))
        End If
    End Sub
    'PixelBoxGrid - MouseMove
    Private Sub PixelBoxGrid_MouseMove(sender As Object, e As MouseEventArgs) Handles PixelBoxGrid.MouseMove
        If EyeDropperMode = True Then
            PictureBox_EyeDropper.Location = New Point(e.Location.X + 6, e.Location.Y + 6)
            PictureBox_EyeDropper.BackColor = controlImage.GetPixel(e.Location.X, e.Location.Y)
        End If
    End Sub
    'PixelBoxGrid - MouseEnter
    Private Sub PixelBoxGrid_MouseEnter(sender As Object, e As EventArgs) Handles PixelBoxGrid.MouseEnter
        If EyeDropperMode = True Then
            controlImage = ControlToBitmap(PixelBoxGrid, True)
        End If
    End Sub
    'PixelBoxGrid - MouseClick
    Private Sub PixelBoxGrid_MouseClick(sender As Object, e As MouseEventArgs) Handles PixelBoxGrid.MouseClick
        If EyeDropperMode = True Then
            If Not PictureBox_EyeDropper.BackColor = GridColor.Color Then
                Button_EyeDropper.BackColor = PictureBox_EyeDropper.BackColor
                EyeDropperMode = False
                PictureBox_EyeDropper.Visible = False
                PixelBoxGrid.Cursor = DefaultCursor
                MakeTransparent_GridBitmap()
                controlImage = Nothing
            End If
        End If
    End Sub
    'PixelBoxGrid - MouseLeave
    Private Sub PixelBoxGrid_MouseLeave(sender As Object, e As EventArgs) Handles PixelBoxGrid.MouseLeave
        EyeDropperMode = False
        PictureBox_EyeDropper.Visible = False
        PixelBoxGrid.Cursor = DefaultCursor
        controlImage = Nothing
    End Sub
    'ControlToBitmap
    Private Function ControlToBitmap(ctrl As Control, clientAreaOnly As Boolean) As Bitmap
        If ctrl Is Nothing Then Return Nothing
        Dim rect As Rectangle

        If clientAreaOnly Then
            rect = ctrl.RectangleToScreen(ctrl.ClientRectangle)
        Else
            rect = If(ctrl.Parent Is Nothing, ctrl.Bounds, ctrl.Parent.RectangleToScreen(ctrl.Bounds))
        End If

        Dim img As New Bitmap(rect.Width, rect.Height)
        Using g As Graphics = Graphics.FromImage(img)
            g.CopyFromScreen(rect.Location, Point.Empty, img.Size)
        End Using
        Return img
    End Function
    'PixelBox_Checkbox_ColorToTransparent - Click
    Private Sub PixelBox_Checkbox_ColorToTransparent_Click(sender As Object, e As EventArgs) Handles PixelBox_Checkbox_ColorToTransparent.Click
        If ColorToTransparent = False Then
            ColorToTransparent = True
            PixelBox_Checkbox_ColorToTransparent.Image = My.Resources.Checkbox_Grey_Checked
            Button_EyeDropper.Visible = True

            EyeDropperMode = True
            PictureBox_EyeDropper.Visible = True
            If File.Exists(Application.StartupPath & "\Eyedropper.cur") Then
                PixelBoxGrid.Cursor = New Cursor(LoadCursorFromFile(Application.StartupPath & "\Eyedropper.cur"))
            End If
        Else
                ColorToTransparent = False
            PixelBox_Checkbox_ColorToTransparent.Image = My.Resources.Checkbox_Grey_Unchecked
            Button_EyeDropper.Visible = False
            MakeTransparent_GridBitmap()
        End If
    End Sub
    'ToolStripMenuItem_Clear - Click
    Private Sub ToolStripMenuItem_Clear_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Clear.Click
        ListBox_Bulk.Items.Clear()
    End Sub
    'NinePatchToolStripMenuItem - CheckedChanged
    Private Sub NinePatchToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles NinePatchToolStripMenuItem.CheckedChanged
        If NinePatchMode = False Then
            NinePatchMode = True
            NumericUpDown_Hori.Value = 3
            NumericUpDown_Vert.Value = 3
            NumericUpDown_Hori.Enabled = False
            NumericUpDown_Vert.Enabled = False
        Else
            NinePatchMode = False
            NumericUpDown_Hori.Enabled = True
            NumericUpDown_Vert.Enabled = True
        End If
    End Sub
    'BulkToolStripMenuItem - CheckedChanged
    Private Sub BulkToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles BulkToolStripMenuItem.CheckedChanged
        If BulkMode = False Then
            BulkMode = True
            Panel_BulkMode.Visible = True
            Button_SelectExportDirectory.Enabled = False
            TextBox_FileName.Enabled = False
            TextBox_ExportDirectory.Enabled = False
            TextBox_FileName.Clear()

            If Not ListBox_Bulk.Items.Count = 0 Then
                ListBox_Bulk.SelectedIndex = 0
            End If
        Else
            BulkMode = False
            Panel_BulkMode.Visible = False
            Button_SelectExportDirectory.Enabled = True
            TextBox_FileName.Enabled = True
            TextBox_ExportDirectory.Enabled = True

            TextBox_FileName.Clear()
            ClearPictureboxes()
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size"
            controlImage = Nothing
            ListBox_Bulk.SelectedIndex = -1
        End If
    End Sub
    'PixelBox_Checkbox_RemoveBlanksFromExport - Click
    Private Sub PixelBox_Checkbox_RemoveBlanksFromExport_Click(sender As Object, e As EventArgs) Handles PixelBox_Checkbox_RemoveBlanksFromExport.Click
        If RemoveBlanksFromExport = False Then
            RemoveBlanksFromExport = True
            PixelBox_Checkbox_RemoveBlanksFromExport.Image = My.Resources.Checkbox_Grey_Checked
        Else
            RemoveBlanksFromExport = False
            PixelBox_Checkbox_RemoveBlanksFromExport.Image = My.Resources.Checkbox_Grey_Unchecked
        End If
    End Sub
End Class