Public Class Form1
    Dim EstimatedSpriteWidth As Integer = 0
    Dim EstimatedSpriteHeight As Integer = 0
    Public GridColor As New Pen(Color.FromArgb(0, 255, 128), 2) 'Color of the lines
    Dim ZoomCounter As Integer = 100
    ReadOnly SupportedIamgeFormats() As String = {".png", ".bmp", ".jpeg", ".jpg", ".tiff", ".tif"}
    ReadOnly NinePatchDirections() As String = {"northwest", "north", "northeast", "west", "center", "east", "southwest", "south", "southeast"}
    Dim EventsOn As Boolean = False
    Dim SpriteSheet_Image As Bitmap
    'Dim SpriteSheet_Image As Image

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
        If Not ListBox_Bulk.Items.Count = 0 Then
            For Each item As String In ListBox_Bulk.Items
                SpriteSheet_Image = GetMemoryBitmapFromFile(item)
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

        If Not ListBox_Bulk.Items.Count = 0 Then
            SpriteSheet_Image = New Bitmap(Image.FromFile(imgPath & "\" & imgNameNoExt & ".png"))
            EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
        End If

        Dim Offset_Vert As Integer = CInt(NumericUpDown_Offset_Vert.Value)
        Dim MainLoopIndex As Integer = 0
        For indexH As Integer = 0 To CInt(NumericUpDown_Vert.Value - 1)
            Dim Offset_Hori As Integer = CInt(NumericUpDown_Offset_Hori.Value)
            For indexW As Integer = 0 To CInt(NumericUpDown_Hori.Value - 1)
                MainLoopIndex += 1
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

                If ListBox_Bulk.Items.Count = 0 Then
                    If CheckBox_NinePatchMode.Checked = False Then
                        CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                    Else
                        CropImage.Save(TextBox_ExportDirectory.Text & "\9patch_" & TextBox_FileName.Text & "_" & NinePatchDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                    End If
                Else 'Bulk Mode
                    If CheckBox_NinePatchMode.Checked = False Then
                        CropImage.Save(imgPath & "\" & imgNameNoExt & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                    Else
                        CropImage.Save(imgPath & "\9patch_" & imgNameNoExt & "_" & NinePatchDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                    End If
                End If

                CropImage.Dispose()

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
            PixelBoxGrid.Image = GridBitmap
        End If
    End Sub
    'Panel_Image - DragDrop
    Private Sub Panel_Image_DragDrop(sender As Object, e As DragEventArgs) Handles Panel_Image.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length <> 0 Then
            Try
                ClearPictureboxes()

                SpriteSheet_Image = GetMemoryBitmapFromFile(files(0))
                'SpriteSheet_Image = Image.FromFile(files(0))

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
    'CheckBox_NinePatchMode - CheckedChanged
    Private Sub CheckBox_NinePatchMode_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_NinePatchMode.CheckedChanged
        If CheckBox_NinePatchMode.Checked = True Then
            NumericUpDown_Hori.Value = 3
            NumericUpDown_Vert.Value = 3
            NumericUpDown_Hori.Enabled = False
            NumericUpDown_Vert.Enabled = False
        Else
            NumericUpDown_Hori.Enabled = True
            NumericUpDown_Vert.Enabled = True
        End If
    End Sub
    'ListBox_Bulk_SelectedIndexChanged
    Private Sub ListBox_Bulk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Bulk.SelectedIndexChanged
        If Not ListBox_Bulk.SelectedIndex = -1 Then
            ClearPictureboxes()

            SpriteSheet_Image = GetMemoryBitmapFromFile(ListBox_Bulk.SelectedItem.ToString)
            'SpriteSheet_Image = Image.FromFile(files(0))

            'TextBox_FileName.Text = Path.GetFileNameWithoutExtension(ListBox_Bulk.SelectedItem.ToString)
            'TextBox_ExportDirectory.Text = Path.GetDirectoryName(ListBox_Bulk.SelectedItem.ToString)
            EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

            'NumericUpDown_Offset_Hori.Maximum = SpriteSheet_Image.Width
            'NumericUpDown_Offset_Vert.Maximum = SpriteSheet_Image.Height

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
                        ListBox_Bulk.Items.Add(item)
                    End If
                Next

                If Not ListBox_Bulk.Items.Count = 0 Then
                    'Select first item
                    ListBox_Bulk.SelectedIndex = 0
                    '
                    Button_SelectExportDirectory.Enabled = False
                    TextBox_FileName.Enabled = False
                    TextBox_ExportDirectory.Enabled = False
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
            '
            If ListBox_Bulk.Items.Count = 0 Then
                Button_SelectExportDirectory.Enabled = True
                TextBox_FileName.Enabled = True
                TextBox_ExportDirectory.Enabled = True
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
        '//Other Method
        'Dim streamReader As StreamReader = New StreamReader(path)
        'Dim tmpBitmap As Bitmap = CType(Bitmap.FromStream(streamReader.BaseStream), Bitmap)
        'streamReader.Close()
        'Return tmpBitmap
    End Function
End Class