<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKartuStock
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKartuStock))
        Me.btnProses = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDate2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDate1 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtDesc = New DevExpress.XtraEditors.LabelControl()
        Me.txtItemCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtWhs = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.txtDate2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWhs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnProses
        '
        Me.btnProses.Location = New System.Drawing.Point(9, 122)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(75, 23)
        Me.btnProses.TabIndex = 5
        Me.btnProses.Text = "Proses"
        '
        'txtDate2
        '
        Me.txtDate2.EditValue = Nothing
        Me.txtDate2.Location = New System.Drawing.Point(295, 91)
        Me.txtDate2.Name = "txtDate2"
        Me.txtDate2.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate2.Properties.Appearance.Options.UseFont = True
        Me.txtDate2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDate2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate2.Size = New System.Drawing.Size(181, 26)
        Me.txtDate2.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(271, 96)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(15, 17)
        Me.LabelControl1.TabIndex = 66
        Me.LabelControl1.Text = "To"
        '
        'txtDate1
        '
        Me.txtDate1.EditValue = Nothing
        Me.txtDate1.Location = New System.Drawing.Point(81, 90)
        Me.txtDate1.Name = "txtDate1"
        Me.txtDate1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate1.Properties.Appearance.Options.UseFont = True
        Me.txtDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDate1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate1.Size = New System.Drawing.Size(181, 26)
        Me.txtDate1.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(12, 94)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(27, 17)
        Me.LabelControl5.TabIndex = 64
        Me.LabelControl5.Text = "Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(9, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 17)
        Me.LabelControl2.TabIndex = 69
        Me.LabelControl2.Text = "Item"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(9, 55)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(66, 17)
        Me.LabelControl3.TabIndex = 71
        Me.LabelControl3.Text = "Warehouse"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.GridControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(0, 151)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(725, 285)
        Me.GroupControl1.TabIndex = 73
        Me.GroupControl1.Text = "All Item"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.BindingSource1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 20)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(721, 263)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'txtDesc
        '
        Me.txtDesc.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(271, 16)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(0, 17)
        Me.txtDesc.TabIndex = 74
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(81, 12)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Properties.Appearance.Options.UseFont = True
        Me.txtItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtItemCode.Properties.DisplayFormat.FormatString = "d"
        Me.txtItemCode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtItemCode.Properties.EditFormat.FormatString = "d"
        Me.txtItemCode.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtItemCode.Size = New System.Drawing.Size(181, 26)
        Me.txtItemCode.TabIndex = 1
        Me.txtItemCode.ToolTip = "Tekan F1 Untuk Memunculkan Kode Barang"
        '
        'txtWhs
        '
        Me.txtWhs.Location = New System.Drawing.Point(81, 51)
        Me.txtWhs.Name = "txtWhs"
        Me.txtWhs.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhs.Properties.Appearance.Options.UseFont = True
        Me.txtWhs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtWhs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtWhs.Properties.DisplayFormat.FormatString = "d"
        Me.txtWhs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtWhs.Properties.EditFormat.FormatString = "d"
        Me.txtWhs.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtWhs.Size = New System.Drawing.Size(181, 26)
        Me.txtWhs.TabIndex = 2
        '
        'FormKartuStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 437)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.txtDate2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtDate1)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtWhs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormKartuStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kartu Stock"
        CType(Me.txtDate2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWhs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnProses As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDate2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDate1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtDesc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtItemCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtWhs As DevExpress.XtraEditors.ComboBoxEdit
End Class
