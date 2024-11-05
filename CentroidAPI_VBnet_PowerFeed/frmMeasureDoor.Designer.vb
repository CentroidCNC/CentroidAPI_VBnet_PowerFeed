<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMeasureDoor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMeasureDoor))
        tlpButtonContainer = New TableLayoutPanel()
        gpbMove = New GroupBox()
        txtDoorMeasurement = New TextBox()
        btnClear = New Button()
        btnEnterDecimal = New Button()
        btnEnter0 = New Button()
        btnEnter9 = New Button()
        btnEnter8 = New Button()
        btnEnter7 = New Button()
        btnEnter6 = New Button()
        btnEnter5 = New Button()
        btnEnter4 = New Button()
        btnEnter3 = New Button()
        btnEnter2 = New Button()
        btnEnter1 = New Button()
        picCycleCancel = New PictureBox()
        picCycleStart = New PictureBox()
        mnuMain = New MenuStrip()
        SetupToolStripMenuItem = New ToolStripMenuItem()
        PictureBox1 = New PictureBox()
        tlpButtonContainer.SuspendLayout()
        gpbMove.SuspendLayout()
        CType(picCycleCancel, ComponentModel.ISupportInitialize).BeginInit()
        CType(picCycleStart, ComponentModel.ISupportInitialize).BeginInit()
        mnuMain.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tlpButtonContainer
        ' 
        tlpButtonContainer.ColumnCount = 3
        tlpButtonContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333244F))
        tlpButtonContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        tlpButtonContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        tlpButtonContainer.Controls.Add(gpbMove, 0, 0)
        tlpButtonContainer.Controls.Add(btnClear, 2, 4)
        tlpButtonContainer.Controls.Add(btnEnterDecimal, 1, 4)
        tlpButtonContainer.Controls.Add(btnEnter0, 0, 4)
        tlpButtonContainer.Controls.Add(btnEnter9, 2, 3)
        tlpButtonContainer.Controls.Add(btnEnter8, 1, 3)
        tlpButtonContainer.Controls.Add(btnEnter7, 0, 3)
        tlpButtonContainer.Controls.Add(btnEnter6, 2, 2)
        tlpButtonContainer.Controls.Add(btnEnter5, 1, 2)
        tlpButtonContainer.Controls.Add(btnEnter4, 0, 2)
        tlpButtonContainer.Controls.Add(btnEnter3, 2, 1)
        tlpButtonContainer.Controls.Add(btnEnter2, 1, 1)
        tlpButtonContainer.Controls.Add(btnEnter1, 0, 1)
        tlpButtonContainer.Location = New Point(15, 32)
        tlpButtonContainer.Margin = New Padding(4, 3, 4, 3)
        tlpButtonContainer.Name = "tlpButtonContainer"
        tlpButtonContainer.RowCount = 5
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 14.49814F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.37547F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.3754635F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.3754635F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.3754635F))
        tlpButtonContainer.Size = New Size(436, 426)
        tlpButtonContainer.TabIndex = 1
        ' 
        ' gpbMove
        ' 
        tlpButtonContainer.SetColumnSpan(gpbMove, 3)
        gpbMove.Controls.Add(txtDoorMeasurement)
        gpbMove.Dock = DockStyle.Fill
        gpbMove.Location = New Point(3, 3)
        gpbMove.Name = "gpbMove"
        gpbMove.Size = New Size(430, 55)
        gpbMove.TabIndex = 4
        gpbMove.TabStop = False
        gpbMove.Text = "Move to X Position"
        ' 
        ' txtDoorMeasurement
        ' 
        txtDoorMeasurement.Dock = DockStyle.Bottom
        txtDoorMeasurement.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtDoorMeasurement.Location = New Point(3, 22)
        txtDoorMeasurement.Margin = New Padding(4, 3, 4, 3)
        txtDoorMeasurement.Name = "txtDoorMeasurement"
        txtDoorMeasurement.Size = New Size(424, 30)
        txtDoorMeasurement.TabIndex = 2
        ' 
        ' btnClear
        ' 
        btnClear.Dock = DockStyle.Fill
        btnClear.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnClear.Location = New Point(294, 337)
        btnClear.Margin = New Padding(4, 3, 4, 3)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(138, 86)
        btnClear.TabIndex = 14
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnEnterDecimal
        ' 
        btnEnterDecimal.Dock = DockStyle.Fill
        btnEnterDecimal.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnterDecimal.Location = New Point(149, 337)
        btnEnterDecimal.Margin = New Padding(4, 3, 4, 3)
        btnEnterDecimal.Name = "btnEnterDecimal"
        btnEnterDecimal.Size = New Size(137, 86)
        btnEnterDecimal.TabIndex = 13
        btnEnterDecimal.Text = "."
        btnEnterDecimal.UseVisualStyleBackColor = True
        ' 
        ' btnEnter0
        ' 
        btnEnter0.Dock = DockStyle.Fill
        btnEnter0.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter0.Location = New Point(4, 337)
        btnEnter0.Margin = New Padding(4, 3, 4, 3)
        btnEnter0.Name = "btnEnter0"
        btnEnter0.Size = New Size(137, 86)
        btnEnter0.TabIndex = 12
        btnEnter0.Text = "0"
        btnEnter0.UseVisualStyleBackColor = True
        ' 
        ' btnEnter9
        ' 
        btnEnter9.Dock = DockStyle.Fill
        btnEnter9.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter9.Location = New Point(294, 246)
        btnEnter9.Margin = New Padding(4, 3, 4, 3)
        btnEnter9.Name = "btnEnter9"
        btnEnter9.Size = New Size(138, 85)
        btnEnter9.TabIndex = 11
        btnEnter9.Text = "9"
        btnEnter9.UseVisualStyleBackColor = True
        ' 
        ' btnEnter8
        ' 
        btnEnter8.Dock = DockStyle.Fill
        btnEnter8.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter8.Location = New Point(149, 246)
        btnEnter8.Margin = New Padding(4, 3, 4, 3)
        btnEnter8.Name = "btnEnter8"
        btnEnter8.Size = New Size(137, 85)
        btnEnter8.TabIndex = 10
        btnEnter8.Text = "8"
        btnEnter8.UseVisualStyleBackColor = True
        ' 
        ' btnEnter7
        ' 
        btnEnter7.Dock = DockStyle.Fill
        btnEnter7.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter7.Location = New Point(4, 246)
        btnEnter7.Margin = New Padding(4, 3, 4, 3)
        btnEnter7.Name = "btnEnter7"
        btnEnter7.Size = New Size(137, 85)
        btnEnter7.TabIndex = 9
        btnEnter7.Text = "7"
        btnEnter7.UseVisualStyleBackColor = True
        ' 
        ' btnEnter6
        ' 
        btnEnter6.Dock = DockStyle.Fill
        btnEnter6.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter6.Location = New Point(294, 155)
        btnEnter6.Margin = New Padding(4, 3, 4, 3)
        btnEnter6.Name = "btnEnter6"
        btnEnter6.Size = New Size(138, 85)
        btnEnter6.TabIndex = 8
        btnEnter6.Text = "6"
        btnEnter6.UseVisualStyleBackColor = True
        ' 
        ' btnEnter5
        ' 
        btnEnter5.Dock = DockStyle.Fill
        btnEnter5.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter5.Location = New Point(149, 155)
        btnEnter5.Margin = New Padding(4, 3, 4, 3)
        btnEnter5.Name = "btnEnter5"
        btnEnter5.Size = New Size(137, 85)
        btnEnter5.TabIndex = 7
        btnEnter5.Text = "5"
        btnEnter5.UseVisualStyleBackColor = True
        ' 
        ' btnEnter4
        ' 
        btnEnter4.Dock = DockStyle.Fill
        btnEnter4.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter4.Location = New Point(4, 155)
        btnEnter4.Margin = New Padding(4, 3, 4, 3)
        btnEnter4.Name = "btnEnter4"
        btnEnter4.Size = New Size(137, 85)
        btnEnter4.TabIndex = 6
        btnEnter4.Text = "4"
        btnEnter4.UseVisualStyleBackColor = True
        ' 
        ' btnEnter3
        ' 
        btnEnter3.Dock = DockStyle.Fill
        btnEnter3.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter3.Location = New Point(294, 64)
        btnEnter3.Margin = New Padding(4, 3, 4, 3)
        btnEnter3.Name = "btnEnter3"
        btnEnter3.Size = New Size(138, 85)
        btnEnter3.TabIndex = 5
        btnEnter3.Text = "3"
        btnEnter3.UseVisualStyleBackColor = True
        ' 
        ' btnEnter2
        ' 
        btnEnter2.Dock = DockStyle.Fill
        btnEnter2.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter2.Location = New Point(149, 64)
        btnEnter2.Margin = New Padding(4, 3, 4, 3)
        btnEnter2.Name = "btnEnter2"
        btnEnter2.Size = New Size(137, 85)
        btnEnter2.TabIndex = 4
        btnEnter2.Text = "2"
        btnEnter2.UseVisualStyleBackColor = True
        ' 
        ' btnEnter1
        ' 
        btnEnter1.Dock = DockStyle.Fill
        btnEnter1.Font = New Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnEnter1.Location = New Point(4, 64)
        btnEnter1.Margin = New Padding(4, 3, 4, 3)
        btnEnter1.Name = "btnEnter1"
        btnEnter1.Size = New Size(137, 85)
        btnEnter1.TabIndex = 3
        btnEnter1.Text = "1"
        btnEnter1.UseVisualStyleBackColor = True
        ' 
        ' picCycleCancel
        ' 
        picCycleCancel.Image = My.Resources.Resources.cycle_cancel
        picCycleCancel.Location = New Point(13, 469)
        picCycleCancel.Margin = New Padding(4, 3, 4, 3)
        picCycleCancel.Name = "picCycleCancel"
        picCycleCancel.Size = New Size(140, 140)
        picCycleCancel.SizeMode = PictureBoxSizeMode.Zoom
        picCycleCancel.TabIndex = 2
        picCycleCancel.TabStop = False
        ' 
        ' picCycleStart
        ' 
        picCycleStart.Image = My.Resources.Resources.cycle_start
        picCycleStart.Location = New Point(312, 469)
        picCycleStart.Margin = New Padding(4, 3, 4, 3)
        picCycleStart.Name = "picCycleStart"
        picCycleStart.Size = New Size(140, 140)
        picCycleStart.SizeMode = PictureBoxSizeMode.Zoom
        picCycleStart.TabIndex = 3
        picCycleStart.TabStop = False
        ' 
        ' mnuMain
        ' 
        mnuMain.Items.AddRange(New ToolStripItem() {SetupToolStripMenuItem})
        mnuMain.Location = New Point(0, 0)
        mnuMain.Name = "mnuMain"
        mnuMain.Size = New Size(465, 24)
        mnuMain.TabIndex = 4
        mnuMain.Text = "MenuStrip1"
        ' 
        ' SetupToolStripMenuItem
        ' 
        SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        SetupToolStripMenuItem.Size = New Size(49, 20)
        SetupToolStripMenuItem.Text = "Setup"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.PowerFeed
        PictureBox1.Location = New Point(160, 469)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(145, 138)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' frmMeasureDoor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(465, 619)
        Controls.Add(PictureBox1)
        Controls.Add(picCycleStart)
        Controls.Add(picCycleCancel)
        Controls.Add(tlpButtonContainer)
        Controls.Add(mnuMain)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = mnuMain
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMeasureDoor"
        StartPosition = FormStartPosition.CenterParent
        Text = "Power Feed"
        tlpButtonContainer.ResumeLayout(False)
        gpbMove.ResumeLayout(False)
        gpbMove.PerformLayout()
        CType(picCycleCancel, ComponentModel.ISupportInitialize).EndInit()
        CType(picCycleStart, ComponentModel.ISupportInitialize).EndInit()
        mnuMain.ResumeLayout(False)
        mnuMain.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents tlpButtonContainer As TableLayoutPanel
    Friend WithEvents btnEnter3 As Button
    Friend WithEvents btnEnter2 As Button
    Friend WithEvents btnEnter1 As Button
    Friend WithEvents btnEnter5 As Button
    Friend WithEvents btnEnter4 As Button
    Friend WithEvents btnEnter6 As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnEnterDecimal As Button
    Friend WithEvents btnEnter0 As Button
    Friend WithEvents btnEnter9 As Button
    Friend WithEvents btnEnter8 As Button
    Friend WithEvents btnEnter7 As Button
    Friend WithEvents picCycleCancel As PictureBox
    Friend WithEvents picCycleStart As PictureBox
    Friend WithEvents gpbMove As GroupBox
    Friend WithEvents txtDoorMeasurement As TextBox
    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents SetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
