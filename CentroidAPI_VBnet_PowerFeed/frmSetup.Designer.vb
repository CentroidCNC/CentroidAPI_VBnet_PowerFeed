<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        GroupBox1 = New GroupBox()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        txtFeedrate = New TextBox()
        lblUnits = New Label()
        tlpButtonContainer = New TableLayoutPanel()
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
        btnAccept = New Button()
        btnCancel = New Button()
        GroupBox1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        tlpButtonContainer.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        tlpButtonContainer.SetColumnSpan(GroupBox1, 3)
        GroupBox1.Controls.Add(FlowLayoutPanel1)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(430, 55)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Default Feedrate:"
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(txtFeedrate)
        FlowLayoutPanel1.Controls.Add(lblUnits)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.Location = New Point(3, 19)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(424, 33)
        FlowLayoutPanel1.TabIndex = 3
        ' 
        ' txtFeedrate
        ' 
        txtFeedrate.Dock = DockStyle.Bottom
        txtFeedrate.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtFeedrate.Location = New Point(3, 3)
        txtFeedrate.Name = "txtFeedrate"
        txtFeedrate.Size = New Size(277, 30)
        txtFeedrate.TabIndex = 2
        ' 
        ' lblUnits
        ' 
        lblUnits.AutoSize = True
        lblUnits.Dock = DockStyle.Right
        lblUnits.Location = New Point(286, 0)
        lblUnits.Name = "lblUnits"
        lblUnits.Size = New Size(102, 36)
        lblUnits.TabIndex = 1
        lblUnits.Text = "Inches Per Minute"
        lblUnits.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' tlpButtonContainer
        ' 
        tlpButtonContainer.ColumnCount = 3
        tlpButtonContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333244F))
        tlpButtonContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        tlpButtonContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        tlpButtonContainer.Controls.Add(btnClear, 2, 4)
        tlpButtonContainer.Controls.Add(GroupBox1, 0, 0)
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
        tlpButtonContainer.Location = New Point(13, 12)
        tlpButtonContainer.Margin = New Padding(4, 3, 4, 3)
        tlpButtonContainer.Name = "tlpButtonContainer"
        tlpButtonContainer.RowCount = 5
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 14.49814F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.37547F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.3754635F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.3754635F))
        tlpButtonContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 21.3754635F))
        tlpButtonContainer.Size = New Size(436, 426)
        tlpButtonContainer.TabIndex = 2
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
        ' btnAccept
        ' 
        btnAccept.Location = New Point(143, 444)
        btnAccept.Name = "btnAccept"
        btnAccept.Size = New Size(150, 42)
        btnAccept.TabIndex = 15
        btnAccept.Text = "Accept"
        btnAccept.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(299, 444)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(150, 42)
        btnCancel.TabIndex = 16
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' frmSetup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(461, 498)
        Controls.Add(btnCancel)
        Controls.Add(btnAccept)
        Controls.Add(tlpButtonContainer)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        Name = "frmSetup"
        StartPosition = FormStartPosition.CenterParent
        Text = "Power Feed App - Setup"
        GroupBox1.ResumeLayout(False)
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        tlpButtonContainer.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblUnits As Label
    Friend WithEvents tlpButtonContainer As TableLayoutPanel
    Friend WithEvents btnClear As Button
    Friend WithEvents btnEnterDecimal As Button
    Friend WithEvents btnEnter0 As Button
    Friend WithEvents btnEnter9 As Button
    Friend WithEvents btnEnter8 As Button
    Friend WithEvents btnEnter7 As Button
    Friend WithEvents btnEnter6 As Button
    Friend WithEvents btnEnter5 As Button
    Friend WithEvents btnEnter4 As Button
    Friend WithEvents btnEnter3 As Button
    Friend WithEvents btnEnter2 As Button
    Friend WithEvents btnEnter1 As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents txtFeedrate As TextBox
    Friend WithEvents btnAccept As Button
    Friend WithEvents btnCancel As Button



End Class
