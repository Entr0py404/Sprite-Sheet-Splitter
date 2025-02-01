Public Class Form1
    ' Variables
    Dim EstimatedSpriteWidth As Integer = 0
    Dim EstimatedSpriteHeight As Integer = 0
    Public GridColor As New Pen(Color.FromArgb(0, 255, 128), 2) 'Color of the lines
    Dim ZoomCounter As Integer = 100
    ReadOnly SupportedImageFormats() As String = {".png", ".bmp", ".jpeg", ".jpg", ".tiff", ".tif"}
    ReadOnly NinePatchDirections() As String = {"northwest", "north", "northeast", "west", "center", "east", "southwest", "south", "southeast"}
    ReadOnly CubemapStripModeDirections() As String = {"px", "nx", "pz", "nz", "py", "ny"}

    'RIGHT, LEFT , Front , back , Up , Down

    Dim EventsOn As Boolean = False
    Dim SpriteSheet_Image As Image
    Dim controlBitmap As Bitmap
    Dim EyeDropperMode As Boolean = False
    Dim BulkMode As Boolean = False
    Dim ColorToTransparent As Boolean = False
    Dim ExcludeBlanksFromExport As Boolean = False
    Dim CubemapStripMode As Boolean = False

    ' External Function Declaration
    Private Declare Unicode Function LoadCursorFromFile Lib "user32.dll" Alias "LoadCursorFromFileW" (ByVal filename As String) As IntPtr

    ' Form1 - Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load settings
        CompletionNotificationToolStripMenuItem.Checked = My.Settings.CompletionNotification
        GridColor.Color = My.Settings.GridColor
        Label_EstimatedSpriteSize.ForeColor = GridColor.Color
        ToolStripComboBox_SizeMode.SelectedIndex = My.Settings.SizeModeIndex
        EventsOn = True

        ' Set custom renderers
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        ToolStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        ContextMenuStrip_ListBox_Bulk.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        ' Check if Eyedropper cursor file exists, if not, create it
        If Not File.Exists(Application.StartupPath & "\Eyedropper.cur") Then
            File.WriteAllBytes(Application.StartupPath & "\Eyedropper.cur", My.Resources.Eyedropper)
        End If
    End Sub

    ' NumericUpDownH - ValueChanged
    Private Sub NumericUpDownH_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Hori.ValueChanged
        H_ValueChanged()
    End Sub

    ' NumericUpDown_Offset_H - ValueChanged
    Private Sub NumericUpDown_Offset_H_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Offset_Hori.ValueChanged
        H_ValueChanged()
    End Sub

    ' NumericUpDownV - ValueChanged
    Private Sub NumericUpDownV_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Vert.ValueChanged
        V_ValueChanged()
    End Sub

    ' NumericUpDown_Offset_V - ValueChanged
    Private Sub NumericUpDown_Offset_V_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Offset_Vert.ValueChanged
        V_ValueChanged()
    End Sub

    ' H_ValueChanged()
    Private Sub H_ValueChanged()
        ' Check if the sprite sheet image is loaded
        If SpriteSheet_Image IsNot Nothing Then
            ' Calculate the estimated sprite width based on the horizontal value
            If NumericUpDown_Hori.Value > 1 Then
                EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            Else
                EstimatedSpriteWidth = SpriteSheet_Image.Width
            End If

            ' Update the label with the estimated sprite size
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

            ' Make the grid bitmap transparent
            MakeTransparent_GridBitmap()
        End If
    End Sub

    ' V_ValueChanged()
    Private Sub V_ValueChanged()
        ' Check if the sprite sheet image is loaded
        If SpriteSheet_Image IsNot Nothing Then
            ' Calculate the estimated sprite height based on the vertical value
            If NumericUpDown_Vert.Value > 1 Then
                EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
            Else
                EstimatedSpriteHeight = SpriteSheet_Image.Height
            End If

            ' Update the label with the estimated sprite size
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

            ' Make the grid bitmap transparent
            MakeTransparent_GridBitmap()
        End If
    End Sub

    ' Button_SelectExportDirectory - Click
    Private Sub Button_SelectExportDirectory_Click(sender As Object, e As EventArgs) Handles Button_SelectExportDirectory.Click
        ' Show the folder browser dialog to select the export directory
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            ' Set the selected path as the text of the export directory textbox
            TextBox_ExportDirectory.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    ' Button_SplitSheet - Click
    Private Sub Button_SplitSpriteStrip_Click(sender As Object, e As EventArgs) Handles Button_SplitSpriteSheet.Click
        ' Check if bulk mode is enabled and there are items in the bulk list
        If BulkMode = True And Not ListBox_Bulk.Items.Count = 0 Then
            ' Iterate through each item in the bulk list
            For Each item As String In ListBox_Bulk.Items
                ' Load the sprite sheet image from the item
                SpriteSheet_Image = SafeImageFromFile(item)

                ' Split the sprite sheet into individual sprites
                SplitSpriteStrip(Path.GetDirectoryName(item), Path.GetFileNameWithoutExtension(item))
            Next

            ' Show completion message if enabled
            If CompletionNotificationToolStripMenuItem.Checked Then
                MsgBox("Bulk sprite sheet split complete.", MsgBoxStyle.Information)
            End If

            ' Clear all settings for the next operation
            ClearAllForNext()
        Else
            ' Check if the sprite sheet image is loaded
            If SpriteSheet_Image IsNot Nothing Then
                ' Split the sprite sheet into individual sprites
                SplitSpriteStrip("", "")

                ' Show completion message if enabled
                If CompletionNotificationToolStripMenuItem.Checked Then
                    MsgBox("Sprite sheet split complete.", MsgBoxStyle.Information)
                End If

                ' Clear all settings for the next operation
                ClearAllForNext()
            End If
        End If
    End Sub

    ' SplitSpriteStrip()
    Private Sub SplitSpriteStrip(imgPath As String, imgNameNoExt As String)
        ' Check if in bulk mode and there are items in the bulk list
        If BulkMode = True And Not ListBox_Bulk.Items.Count = 0 Then
            ' Load the sprite sheet image
            SpriteSheet_Image = New Bitmap(Image.FromFile(imgPath & "\" & imgNameNoExt & ".png"))
            EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
        End If

        ' Set the vertical offset
        Dim Offset_Vert As Integer = CInt(NumericUpDown_Offset_Vert.Value)
        Dim MainLoopIndex As Integer = 0

        ' Loop through each row of sprites
        For indexH As Integer = 0 To CInt(NumericUpDown_Vert.Value - 1)
            ' Set the horizontal offset
            Dim Offset_Hori As Integer = CInt(NumericUpDown_Offset_Hori.Value)

            ' Loop through each sprite in the row
            For indexW As Integer = 0 To CInt(NumericUpDown_Hori.Value - 1)
                ' Define the cropping rectangle for the current sprite
                Dim CropRect As Rectangle
                Dim CropRect_X As Integer = 0

                ' Calculate the X-coordinate of the cropping rectangle
                If indexW > 0 Then
                    CropRect_X = (EstimatedSpriteWidth * indexW) + Offset_Hori * indexW
                End If

                Dim CropRect_Y As Integer = 0

                ' Calculate the Y-coordinate of the cropping rectangle
                If indexH > 0 Then
                    CropRect_Y = (EstimatedSpriteHeight * indexH) + Offset_Vert * indexH
                End If

                ' Create a new bitmap for the cropped sprite
                CropRect = New Rectangle(CropRect_X, CropRect_Y, EstimatedSpriteWidth, EstimatedSpriteHeight)
                Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)

                ' Use Graphics object to draw the cropped sprite image
                Using grp = Graphics.FromImage(CropImage)
                    grp.SmoothingMode = SmoothingMode.None
                    grp.InterpolationMode = InterpolationMode.HighQualityBicubic
                    grp.CompositingQuality = CompositingQuality.HighQuality
                    grp.DrawImage(SpriteSheet_Image, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                    grp.Dispose()
                End Using

                ' Apply transparency if enabled
                If ColorToTransparent = True Then
                    CropImage.MakeTransparent(Button_EyeDropper.BackColor)
                End If

                ' Check if the image has color and ExcludeBlanksFromExport is enabled
                Dim ImageHasColor As Boolean = False
                If ExcludeBlanksFromExport = True Then
                    Dim TempColor As Color
                    For y As Integer = 0 To CropImage.Height - 1
                        If ImageHasColor = False Then
                            For x As Integer = 0 To CropImage.Width - 1
                                TempColor = CropImage.GetPixel(x, y)
                                If Not TempColor = Color.FromArgb(0, 0, 0, 0) Then
                                    ImageHasColor = True
                                    Exit For
                                End If
                            Next
                        Else
                            Exit For
                        End If
                    Next

                    ' Save the image if it has color
                    If ImageHasColor = True Then
                        MainLoopIndex += 1

                        ' Determine the export path based on the mode
                        If BulkMode = False And ListBox_Bulk.Items.Count = 0 Then
                            CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                        Else ' Bulk Mode
                            CropImage.Save(imgPath & "\" & imgNameNoExt & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                        End If
                        CropImage.Dispose()
                    End If

                Else
                    ' Save the image
                    MainLoopIndex += 1

                    ' Determine the export path based on the mode
                    If BulkMode = False And ListBox_Bulk.Items.Count = 0 Then
                        If CubemapStripMode = True Then
                            CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & CubemapStripModeDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                        Else
                            CropImage.Save(TextBox_ExportDirectory.Text & "\" & TextBox_FileName.Text & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                        End If

                    Else ' Bulk Mode
                        If CubemapStripMode = True Then
                            CropImage.Save(TextBox_ExportDirectory.Text & "\" & imgNameNoExt & "_" & CubemapStripModeDirections(MainLoopIndex - 1) & ".png", ImageFormat.Png)
                        Else
                            CropImage.Save(imgPath & "\" & imgNameNoExt & "_" & MainLoopIndex & ".png", ImageFormat.Png)
                        End If
                    End If
                    CropImage.Dispose()
                End If

            Next
        Next
    End Sub

    ' MakeTransparent_GridBitmap()
    Private Sub MakeTransparent_GridBitmap()
        ' Check if a sprite sheet image is available
        If SpriteSheet_Image IsNot Nothing Then
            ' Initialize variables
            Dim x As Integer
            Dim y As Integer
            Dim intSpacingH As Integer = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value)
            Dim intSpacingV As Integer = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value)

            ' Create a new bitmap for the grid
            Dim GridBitmap = New Bitmap(SpriteSheet_Image.Width + 1, SpriteSheet_Image.Height + 1)

            ' Use Graphics object to draw on the bitmap
            Using grp = Graphics.FromImage(GridBitmap)
                grp.CompositingQuality = CompositingQuality.HighQuality

                ' Draw the sprite sheet image on the grid bitmap
                grp.DrawImage(SpriteSheet_Image, 0, 0, GridBitmap.Width - 1, GridBitmap.Height - 1)

                ' Draw the vertical lines of the grid
                y = SpriteSheet_Image.Height + 1
                For x = 1 - CInt(NumericUpDown_Offset_Hori.Value) To SpriteSheet_Image.Width + 1 Step intSpacingH
                    grp.DrawLine(GridColor, New Point(x, 0), New Point(x, y))
                Next

                ' Draw the horizontal lines of the grid
                x = SpriteSheet_Image.Width '+ 1
                For y = 1 - CInt(NumericUpDown_Offset_Vert.Value) To SpriteSheet_Image.Height + 1 Step intSpacingV
                    grp.DrawLine(GridColor, New Point(0, y), New Point(x, y))
                Next

                ' Dispose of the Graphics object
                grp.Dispose()
            End Using

            ' Apply transparency if enabled
            If ColorToTransparent = True Then
                GridBitmap.MakeTransparent(Button_EyeDropper.BackColor)
            End If

            ' Set the grid bitmap as the image for the PixelBoxGrid
            PixelBoxGrid.Image = GridBitmap
        End If
    End Sub

    ' Panel_Image - DragDrop
    Private Sub Panel_Image_DragDrop(sender As Object, e As DragEventArgs) Handles Panel_Image.DragDrop
        ' Retrieve the dropped files from the event arguments
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        ' Check if any files were dropped
        If files.Length <> 0 Then
            Try
                ' Clear the picture boxes
                ClearPictureboxes()

                ' Load the sprite sheet image from the first dropped file
                SpriteSheet_Image = SafeImageFromFile(files(0))

                ' Set the file name and export directory
                TextBox_FileName.Text = Path.GetFileNameWithoutExtension(files(0))
                TextBox_ExportDirectory.Text = Path.GetDirectoryName(files(0))

                ' Calculate the estimated sprite size based on horizontal and vertical settings
                EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
                EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
                Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

                ' Set the maximum offset values based on the sprite sheet image dimensions
                NumericUpDown_Offset_Hori.Maximum = SpriteSheet_Image.Width
                NumericUpDown_Offset_Vert.Maximum = SpriteSheet_Image.Height

                ' Generate the transparent grid bitmap
                MakeTransparent_GridBitmap()
            Catch ex As Exception
                MsgBox("Problem opening file.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    ' Panel_Image - DragEnter
    Private Sub Panel_Image_DragEnter(sender As Object, e As DragEventArgs) Handles Panel_Image.DragEnter
        ' Retrieve the dropped files from the event data
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        ' Check if the dropped data contains files and if the file extension is supported
        If e.Data.GetDataPresent(DataFormats.FileDrop) And SupportedImageFormats.Contains(Path.GetExtension(files(0)).ToLower) Then
            ' Set the drag effect to Copy to indicate that the drop is allowed
            e.Effect = DragDropEffects.Copy
        Else
            ' Set the drag effect to None to indicate that the drop is not allowed
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' ToolStripComboBox_SizeMode - SelectedIndexChanged
    Private Sub ToolStripComboBox_SizeMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox_SizeMode.SelectedIndexChanged
        ' Update the selected size mode index in the settings if events are enabled
        If EventsOn = True Then
            My.Settings.SizeModeIndex = ToolStripComboBox_SizeMode.SelectedIndex
        End If

        ' Handle different size mode selections
        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            ' Zoom mode
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.Zoom
            ToolStripLabel_ZoomLvl.Text = "Zoom: " & ZoomCounter & "%"
            ToolStripLabel_ZoomLvl.Visible = True
            ZoomCounter = 100
            PixelBoxGrid.Dock = DockStyle.None
            ResizeAndPositionPictureBox()
        ElseIf ToolStripComboBox_SizeMode.SelectedItem Is "Fixed Zoom" Then
            ' Fixed Zoom mode
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.Zoom
            ToolStripLabel_ZoomLvl.Visible = False
            PixelBoxGrid.Dock = DockStyle.Fill
        ElseIf ToolStripComboBox_SizeMode.SelectedItem Is "Normal" Then
            ' Normal mode
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.Normal
            ToolStripLabel_ZoomLvl.Text = "Size Mode: Normal"
            ToolStripLabel_ZoomLvl.Visible = False
            PixelBoxGrid.Dock = DockStyle.Fill
        ElseIf ToolStripComboBox_SizeMode.SelectedItem Is "Center" Then
            ' Center mode
            PixelBoxGrid.SizeMode = PictureBoxSizeMode.CenterImage
            ToolStripLabel_ZoomLvl.Text = "Size Mode: Center"
            ToolStripLabel_ZoomLvl.Visible = False
            PixelBoxGrid.Dock = DockStyle.Fill
        End If

        ' Enable/disable controls and update visibility based on the selected size mode
        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            PixelBox_Checkbox_ColorToTransparent.Enabled = False
            Button_EyeDropper.Enabled = False
            Button_EyeDropper.Visible = False
            Label_SizeModeNotice.Visible = True
        Else
            PixelBox_Checkbox_ColorToTransparent.Enabled = True
            Button_EyeDropper.Enabled = True
            Label_SizeModeNotice.Visible = False
            If ColorToTransparent = True Then
                Button_EyeDropper.Visible = True
            End If
        End If
    End Sub

    ' GridColorToolStripMenuItem_Click
    Private Sub GridColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GridColorToolStripMenuItem.Click
        ' Display the color dialog and check if the user selected a color
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            ' Update the GridColor with the selected color
            GridColor.Color = ColorDialog1.Color

            ' Update the foreground color of the Label_EstimatedSpriteSize to match the selected color
            Label_EstimatedSpriteSize.ForeColor = ColorDialog1.Color

            ' Update the GridColor setting in the application settings
            My.Settings.GridColor = ColorDialog1.Color

            ' Update the transparent grid bitmap with the new grid color
            MakeTransparent_GridBitmap()
        End If
    End Sub

    ' ClearToolStripMenuItem - Click
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ' Clear all input fields and associated data for the next operation
        ClearAllForNext()

        ' Reset the values of the NumericUpDown controls for horizontal and vertical sprite counts to 1
        NumericUpDown_Hori.Value = 1
        NumericUpDown_Vert.Value = 1
    End Sub

    ' CompletionNotificationToolStripMenuItem - CheckedChanged
    Private Sub CompletionNotificationToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles CompletionNotificationToolStripMenuItem.CheckedChanged
        ' Handle the CheckedChanged event of the CompletionNotificationToolStripMenuItem

        ' Check if EventsOn flag is set to True
        If EventsOn = True Then
            ' Update the CompletionNotification setting in the application's settings based on the checked state of the menu item
            My.Settings.CompletionNotification = CompletionNotificationToolStripMenuItem.Checked
        End If
    End Sub

    ' ResizeAndPositionPictureBox
    Private Sub ResizeAndPositionPictureBox()
        ' Resize and reposition the PixelBoxGrid within the Panel_Image

        ' Resize the PixelBoxGrid based on the scaled size of the Panel_Image and the current zoom level
        PixelBoxGrid.Size = ObjectScale(New Size(CType(Panel_Image.Size, Point)), ZoomCounter)

        ' Reposition the PixelBoxGrid at the center of the Panel_Image
        PixelBoxGrid.Location = New Point(CInt((Panel_Image.Width / 2 - PixelBoxGrid.Width / 2)), CInt((Panel_Image.Height / 2 - PixelBoxGrid.Height / 2)))
    End Sub

    ' PixelBoxGrid - MouseWheel
    Private Sub PixelBoxGrid_MouseWheel(sender As Object, e As MouseEventArgs) Handles PixelBoxGrid.MouseWheel
        ' Handle the mouse wheel event for zooming the PixelBoxGrid

        ' Check if the selected size mode is "Zoom"
        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            ' Check the direction of the mouse wheel scroll
            If e.Delta < 0 And ZoomCounter < 100 Then 'Zoom in
                ' Zoom in: Increase the zoom level
                ZoomCounter += 5
                ToolStripLabel_ZoomLvl.Text = "Zoom: " & ZoomCounter & "%"
                PixelBoxGrid.Size = ObjectScale(New Size(CType(Panel_Image.Size, Point)), ZoomCounter)
                PixelBoxGrid.Location = New Point(CInt((Panel_Image.Width / 2 - PixelBoxGrid.Width / 2)), CInt((Panel_Image.Height / 2 - PixelBoxGrid.Height / 2)))
            ElseIf e.Delta > 0 And ZoomCounter > 10 Then 'Zoom out
                ' Zoom out: Decrease the zoom level
                ZoomCounter -= 5
                ToolStripLabel_ZoomLvl.Text = "Zoom: " & ZoomCounter & "%"
                PixelBoxGrid.Size = ObjectScale(New Size(CType(Panel_Image.Size, Point)), ZoomCounter)
                PixelBoxGrid.Location = New Point(CInt((Panel_Image.Width / 2 - PixelBoxGrid.Width / 2)), CInt((Panel_Image.Height / 2 - PixelBoxGrid.Height / 2)))
            End If
        End If
    End Sub

    ' Panel_Image - Resize
    Private Sub Panel_Image_Resize(sender As Object, e As EventArgs) Handles Panel_Image.Resize
        ' Check if the selected size mode is "Zoom"
        If ToolStripComboBox_SizeMode.SelectedItem Is "Zoom" Then
            ' Resize and reposition the picture box
            ResizeAndPositionPictureBox()
        End If
    End Sub

    ' ObjectScale
    Public Shared Function ObjectScale(size As Size, scalePercent As Single) As Size
        ' Scale the size of an object based on the provided scale percentage

        ' Check if the scale percentage is 1 (no scaling)
        If Math.Abs(scalePercent - 1) < Single.Epsilon Then
            ' If the scale percentage is 1 (no scaling), return the original size
            Return size
        End If

        ' Calculate the scaled height and width based on the scale percentage
        Dim height = CInt(size.Height * (scalePercent / 100))
        Dim width = CInt(size.Width * (scalePercent / 100))

        ' Return the scaled size
        Return New Size(width, height)
    End Function

    ' TextBox_FileName - KeyPress
    Private Sub TextBox_FileName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_FileName.KeyPress
        ' Handle key press events for the file name text box
        If Not e.KeyChar = ChrW(Keys.Back) Then
            ' Check if the entered character is invalid for a file name
            If New String(Path.GetInvalidFileNameChars()).Contains(e.KeyChar.ToString) Then
                ' If the character is invalid, handle the event (prevent entering the character)
                e.Handled = True
            End If
        End If
    End Sub

    ' ClearPictureboxes
    Private Sub ClearPictureboxes()
        ' Clear the picture boxes and associated data
        SpriteSheet_Image = Nothing
        PixelBoxGrid.Image = Nothing
        PixelBoxGrid.Refresh()
    End Sub

    ' Clear All For Next
    Private Sub ClearAllForNext()
        ' Clear all input fields and associated data for the next operation
        TextBox_ExportDirectory.Clear()
        TextBox_FileName.Clear()
        ListBox_Bulk.Items.Clear()

        ' Clear the picture boxes and associated data
        ClearPictureboxes()

        ' Reset the label for estimated sprite size
        Label_EstimatedSpriteSize.Text = "Estimated Sprite Size"

        ' Reset the control bitmap
        controlBitmap = Nothing
    End Sub

    ' ToolStripComboBox_SizeMode - DropDownClosed
    Private Sub ToolStripComboBox_SizeMode_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripComboBox_SizeMode.DropDownClosed
        PixelBoxGrid.Select()
    End Sub

    ' ToolStripMenuItem1 - DropDownClosed
    Private Sub ToolStripMenuItem1_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.DropDownClosed
        ToolStripMenuItem1.ForeColor = Color.WhiteSmoke
    End Sub

    ' ToolStripMenuItem1 - DropDownOpened
    Private Sub ToolStripMenuItem1_DropDownOpened(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.DropDownOpened
        ToolStripMenuItem1.ForeColor = Color.Black
    End Sub

    ' ListBox_Bulk_SelectedIndexChanged
    Private Sub ListBox_Bulk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Bulk.SelectedIndexChanged
        ' Check if an item is selected in the list box
        If Not ListBox_Bulk.SelectedIndex = -1 Then
            ' Clear the picture boxes
            ClearPictureboxes()

            ' Load the selected sprite sheet image
            SpriteSheet_Image = SafeImageFromFile(ListBox_Bulk.SelectedItem.ToString)

            ' Calculate the estimated sprite size based on the number of horizontal and vertical divisions
            EstimatedSpriteWidth = CInt(SpriteSheet_Image.Width / NumericUpDown_Hori.Value) - CInt(NumericUpDown_Offset_Hori.Value)
            EstimatedSpriteHeight = CInt(SpriteSheet_Image.Height / NumericUpDown_Vert.Value) - CInt(NumericUpDown_Offset_Vert.Value)
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size (" & EstimatedSpriteWidth & "x" & EstimatedSpriteHeight & ")"

            ' Make the grid bitmap transparent
            MakeTransparent_GridBitmap()
        End If
    End Sub

    ' ListBox_Bulk - DragDrop
    Private Sub ListBox_Bulk_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox_Bulk.DragDrop
        ' Retrieve the dropped files from the drag event
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length <> 0 Then
            Try
                For Each item In files
                    ' Check if the file has a supported image format and add it to the list box
                    If SupportedImageFormats.Contains(Path.GetExtension(item).ToLower) Then
                        If Not ListBox_Bulk.Items.Contains(item) Then
                            ListBox_Bulk.Items.Add(item)
                        End If
                    End If
                Next

                ' Select the first item in the list box
                If Not ListBox_Bulk.Items.Count = 0 Then
                    ListBox_Bulk.SelectedIndex = 0 'Select first item
                End If
            Catch ex As Exception
                MsgBox("Problem opening file.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    ' ListBox_Bulk - DragEnter
    Private Sub ListBox_Bulk_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox_Bulk.DragEnter
        ' Check if the dragged data contains a file drop and if it is a supported image format
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If e.Data.GetDataPresent(DataFormats.FileDrop) And SupportedImageFormats.Contains(Path.GetExtension(files(0)).ToLower) Then
            ' Allow the drop operation to copy the files
            e.Effect = DragDropEffects.Copy
        Else
            ' Disable the drop operation
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' ListBox_Bulk - DoubleClick
    Private Sub ListBox_Bulk_DoubleClick(sender As Object, e As EventArgs) Handles ListBox_Bulk.DoubleClick
        ' Check if an item is selected in the list box
        If Not ListBox_Bulk.SelectedIndex = -1 Then
            ' Remove the selected item from the list box and clear the picture boxes
            ListBox_Bulk.Items.RemoveAt(ListBox_Bulk.SelectedIndex)
            ClearPictureboxes()
        End If
    End Sub

    ' SafeImageFromFile()
    Public Shared Function SafeImageFromFile(path As String) As Image
        ' Load an image from a file into a safe memory stream
        Dim bytes = File.ReadAllBytes(path)
        Using ms As New MemoryStream(bytes)
            Dim img = Image.FromStream(ms)
            Return img
        End Using
    End Function

    ' TextBox_ExportDirectory - TextChanged
    Private Sub TextBox_ExportDirectory_TextChanged(sender As Object, e As EventArgs) Handles TextBox_ExportDirectory.TextChanged
        ToolTip1.SetToolTip(TextBox_ExportDirectory, TextBox_ExportDirectory.Text)
    End Sub

    ' Button_EyeDropper - Click
    Private Sub Button_EyeDropper_Click(sender As Object, e As EventArgs) Handles Button_EyeDropper.Click
        ' Enable eye dropper mode
        EyeDropperMode = True
        PictureBox_EyeDropper.Visible = True

        ' Load custom cursor if it exists
        If File.Exists(Application.StartupPath & "\Eyedropper.cur") Then
            PixelBoxGrid.Cursor = New Cursor(LoadCursorFromFile(Application.StartupPath & "\Eyedropper.cur"))
        End If
    End Sub

    ' PixelBoxGrid - MouseMove
    Private Sub PixelBoxGrid_MouseMove(sender As Object, e As MouseEventArgs) Handles PixelBoxGrid.MouseMove
        ' Check if eye dropper mode is enabled
        If EyeDropperMode = True Then
            ' Move the eye dropper icon and get the color under the cursor
            PictureBox_EyeDropper.Location = New Point(e.Location.X + 6, e.Location.Y + 6)
            PictureBox_EyeDropper.BackColor = controlBitmap.GetPixel(e.Location.X, e.Location.Y)
        End If
    End Sub

    ' PixelBoxGrid - MouseEnter
    Private Sub PixelBoxGrid_MouseEnter(sender As Object, e As EventArgs) Handles PixelBoxGrid.MouseEnter
        ' Check if eye dropper mode is enabled
        If EyeDropperMode = True Then
            ' Capture the control's client area as a bitmap
            controlBitmap = ControlToBitmap(PixelBoxGrid, True)
            'controlBitmap = New Bitmap(PixelBoxGrid.Image)
        End If
    End Sub

    ' PixelBoxGrid - MouseClick
    Private Sub PixelBoxGrid_MouseClick(sender As Object, e As MouseEventArgs) Handles PixelBoxGrid.MouseClick
        ' Check if eye dropper mode is active
        If EyeDropperMode = True Then
            ' Check if the eye dropper color is different from the grid color
            If Not PictureBox_EyeDropper.BackColor = GridColor.Color Then
                ' Set the eye dropper color as the selected color
                Button_EyeDropper.BackColor = PictureBox_EyeDropper.BackColor

                ' Disable eye dropper mode and hide the eye dropper
                EyeDropperMode = False
                PictureBox_EyeDropper.Visible = False

                ' Reset the cursor and redraw the transparent grid bitmap
                PixelBoxGrid.Cursor = DefaultCursor
                MakeTransparent_GridBitmap()
                controlBitmap = Nothing
            End If
        End If
    End Sub

    ' PixelBoxGrid - MouseLeave
    Private Sub PixelBoxGrid_MouseLeave(sender As Object, e As EventArgs) Handles PixelBoxGrid.MouseLeave
        ' Disable eye dropper mode and hide the eye dropper
        EyeDropperMode = False
        PictureBox_EyeDropper.Visible = False

        ' Reset the cursor and clear the control bitmap
        PixelBoxGrid.Cursor = DefaultCursor
        controlBitmap = Nothing
    End Sub

    ' ControlToBitmap
    Private Function ControlToBitmap(ctrl As Control, clientAreaOnly As Boolean) As Bitmap
        ' Convert a control to a bitmap

        ' Check if the control is null
        If ctrl Is Nothing Then Return Nothing

        ' Define a rectangle to capture the control's area
        Dim rect As Rectangle

        ' Check if only the client area should be captured
        If clientAreaOnly Then
            ' Capture the control's client area rectangle relative to the screen
            rect = ctrl.RectangleToScreen(ctrl.ClientRectangle)
        Else
            ' Capture the control's bounds relative to its parent or screen
            rect = If(ctrl.Parent Is Nothing, ctrl.Bounds, ctrl.Parent.RectangleToScreen(ctrl.Bounds))
        End If

        ' Create a new bitmap with the size of the captured rectangle
        Dim img As New Bitmap(rect.Width, rect.Height)

        ' Create a Graphics object from the bitmap
        Using g As Graphics = Graphics.FromImage(img)
            ' Copy the screen content within the captured rectangle to the bitmap
            g.CopyFromScreen(rect.Location, Point.Empty, img.Size)
        End Using

        ' Return the generated bitmap
        Return img
    End Function

    ' PixelBox_Checkbox_ColorToTransparent - Click
    Private Sub PixelBox_Checkbox_ColorToTransparent_Click(sender As Object, e As EventArgs) Handles PixelBox_Checkbox_ColorToTransparent.Click
        ' Check if color-to-transparent mode is being enabled
        If ColorToTransparent = False Then
            ' Enable color-to-transparent mode
            ColorToTransparent = True
            PixelBox_Checkbox_ColorToTransparent.Image = My.Resources.Checkbox_Grey_Checked
            Button_EyeDropper.Visible = True

            ' Enable eye dropper mode
            EyeDropperMode = True
            PictureBox_EyeDropper.Visible = True

            ' Load custom cursor for eye dropper
            If File.Exists(Application.StartupPath & "\Eyedropper.cur") Then
                PixelBoxGrid.Cursor = New Cursor(LoadCursorFromFile(Application.StartupPath & "\Eyedropper.cur"))
            End If
        Else
            ' Disable color-to-transparent mode
            ColorToTransparent = False
            PictureBox_EyeDropper.Visible = False
            PixelBox_Checkbox_ColorToTransparent.Image = My.Resources.Checkbox_Grey_Unchecked
            Button_EyeDropper.Visible = False

            ' Reset transparent color and redraw grid bitmap
            MakeTransparent_GridBitmap()
        End If
    End Sub

    ' ToolStripMenuItem_Clear - Click
    Private Sub ToolStripMenuItem_Clear_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Clear.Click
        ' Clear all items from the bulk list
        ListBox_Bulk.Items.Clear()
    End Sub

    ' CubemapStripToolStripMenuItem - CheckedChanged
    Private Sub CubemapStripToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles CubemapStripToolStripMenuItem.CheckedChanged
        CubemapStripMode = CubemapStripToolStripMenuItem.Checked
    End Sub

    ' CubemapStripToolStripMenuItem - Click
    Private Sub CubemapStripToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CubemapStripToolStripMenuItem.Click
        If CubemapStripToolStripMenuItem.Checked Then
            ' Enable CubemapStrip mode
            CubemapStripMode = True
            NumericUpDown_Hori.Value = 6
            NumericUpDown_Vert.Value = 1
            NumericUpDown_Hori.Enabled = False
            NumericUpDown_Vert.Enabled = False
        Else
            ' Disable CubemapStrip mode
            CubemapStripMode = False
            NumericUpDown_Hori.Enabled = True
            NumericUpDown_Vert.Enabled = True
        End If
    End Sub

    ' BulkToolStripMenuItem - CheckedChanged
    Private Sub BulkToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles BulkToolStripMenuItem.CheckedChanged
        ' Check if bulk mode is being enabled
        If BulkMode = False Then
            ' Enable bulk mode
            BulkMode = True
            Panel_BulkMode.Visible = True
            Button_SelectExportDirectory.Enabled = False
            TextBox_FileName.Enabled = False
            TextBox_ExportDirectory.Enabled = False
            TextBox_FileName.Clear()

            ' Set the selected index of the bulk listbox
            If Not ListBox_Bulk.Items.Count = 0 Then
                ListBox_Bulk.SelectedIndex = 0
            End If
        Else
            ' Disable bulk mode
            BulkMode = False
            Panel_BulkMode.Visible = False
            Button_SelectExportDirectory.Enabled = True
            TextBox_FileName.Enabled = True
            TextBox_ExportDirectory.Enabled = True

            TextBox_FileName.Clear()
            ClearPictureboxes()
            Label_EstimatedSpriteSize.Text = "Estimated Sprite Size"
            controlBitmap = Nothing
            ListBox_Bulk.SelectedIndex = -1
        End If
    End Sub

    ' PixelBox_Checkbox_ExcludeBlanksFromExport - Click
    Private Sub PixelBox_Checkbox_ExcludeBlanksFromExport_Click(sender As Object, e As EventArgs) Handles PixelBox_Checkbox_ExcludeBlanksFromExport.Click
        ' Check if excluding blanks from export is being enabled
        If ExcludeBlanksFromExport = False Then
            ' Enable excluding blanks from export
            ExcludeBlanksFromExport = True
            PixelBox_Checkbox_ExcludeBlanksFromExport.Image = My.Resources.Checkbox_Grey_Checked
        Else
            ' Disable excluding blanks from export
            ExcludeBlanksFromExport = False
            PixelBox_Checkbox_ExcludeBlanksFromExport.Image = My.Resources.Checkbox_Grey_Unchecked
        End If
    End Sub
End Class