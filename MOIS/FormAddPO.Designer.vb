<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddPO))
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNetPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDiscount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.txtRef = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDocNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNote = New DevExpress.XtraEditors.MemoEdit()
        Me.txtPPN = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository(Me.components)
        Me.RepocbItemCode = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RbI = New System.Windows.Forms.RadioButton()
        Me.RbE = New System.Windows.Forms.RadioButton()
        Me.RbO = New System.Windows.Forms.RadioButton()
        Me.txtCurRate = New DevExpress.XtraEditors.TextEdit()
        Me.txtDiscountHead = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCurrency = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.cbVendor = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RepocbDiscountType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.txtNetPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepocbItemCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscountHead.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepocbDiscountType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(129, 421)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(42, 34)
        Me.btnPrint.TabIndex = 13
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Appearance.Options.UseFont = True
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(177, 421)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(42, 34)
        Me.btnClear.TabIndex = 14
        '
        'txtNetPrice
        '
        Me.txtNetPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNetPrice.EditValue = ""
        Me.txtNetPrice.Location = New System.Drawing.Point(914, 474)
        Me.txtNetPrice.Name = "txtNetPrice"
        Me.txtNetPrice.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetPrice.Properties.Appearance.Options.UseFont = True
        Me.txtNetPrice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNetPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNetPrice.Size = New System.Drawing.Size(181, 26)
        Me.txtNetPrice.TabIndex = 106
        '
        'LabelControl13
        '
        Me.LabelControl13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(851, 477)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(53, 17)
        Me.LabelControl13.TabIndex = 105
        Me.LabelControl13.Text = "Net Price"
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.EditValue = ""
        Me.txtDiscount.Location = New System.Drawing.Point(914, 419)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Properties.Appearance.Options.UseFont = True
        Me.txtDiscount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiscount.Size = New System.Drawing.Size(181, 26)
        Me.txtDiscount.TabIndex = 104
        '
        'LabelControl12
        '
        Me.LabelControl12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(821, 422)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(83, 17)
        Me.LabelControl12.TabIndex = 103
        Me.LabelControl12.Text = "Total Discount"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.EditValue = ""
        Me.txtTotal.Location = New System.Drawing.Point(914, 391)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Properties.Appearance.Options.UseFont = True
        Me.txtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(181, 26)
        Me.txtTotal.TabIndex = 102
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(843, 394)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(61, 17)
        Me.LabelControl11.TabIndex = 101
        Me.LabelControl11.Text = "Total Price"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.DataSource = Me.BindingSource1
        Me.GridControl1.Location = New System.Drawing.Point(5, 128)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.GridControl1.Size = New System.Drawing.Size(1090, 259)
        Me.GridControl1.TabIndex = 100
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(12, 421)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 34)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(959, 94)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(136, 23)
        Me.btnConvert.TabIndex = 99
        Me.btnConvert.Text = "Convert From PR"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'txtRef
        '
        Me.txtRef.EditValue = ""
        Me.txtRef.Location = New System.Drawing.Point(772, 92)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRef.Properties.Appearance.Options.UseFont = True
        Me.txtRef.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtRef.Size = New System.Drawing.Size(181, 26)
        Me.txtRef.TabIndex = 11
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(708, 97)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(58, 17)
        Me.LabelControl10.TabIndex = 97
        Me.LabelControl10.Text = "Reference"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(708, 10)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(29, 17)
        Me.LabelControl9.TabIndex = 95
        Me.LabelControl9.Text = "Note"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(499, 92)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Properties.Appearance.Options.UseFont = True
        Me.txtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtStatus.Properties.Items.AddRange(New Object() {"Open", "Complete"})
        Me.txtStatus.Size = New System.Drawing.Size(181, 26)
        Me.txtStatus.TabIndex = 9
        '
        'txtDate
        '
        Me.txtDate.EditValue = Nothing
        Me.txtDate.Location = New System.Drawing.Point(499, 5)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Properties.Appearance.Options.UseFont = True
        Me.txtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Size = New System.Drawing.Size(181, 26)
        Me.txtDate.TabIndex = 8
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(457, 97)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(35, 17)
        Me.LabelControl8.TabIndex = 88
        Me.LabelControl8.Text = "Status"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(457, 10)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(27, 17)
        Me.LabelControl5.TabIndex = 85
        Me.LabelControl5.Text = "Date"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(7, 97)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(90, 17)
        Me.LabelControl4.TabIndex = 84
        Me.LabelControl4.Text = "Currency / Rate"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(7, 67)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(63, 17)
        Me.LabelControl3.TabIndex = 83
        Me.LabelControl3.Text = "PPN Status"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(7, 39)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(43, 17)
        Me.LabelControl2.TabIndex = 81
        Me.LabelControl2.Text = "Vendor"
        '
        'txtDocNumber
        '
        Me.txtDocNumber.EditValue = "Otomatis"
        Me.txtDocNumber.Location = New System.Drawing.Point(136, 5)
        Me.txtDocNumber.Name = "txtDocNumber"
        Me.txtDocNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocNumber.Properties.Appearance.Options.UseFont = True
        Me.txtDocNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDocNumber.Size = New System.Drawing.Size(134, 26)
        Me.txtDocNumber.TabIndex = 80
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(6, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(111, 17)
        Me.LabelControl1.TabIndex = 79
        Me.LabelControl1.Text = "Document Number"
        '
        'txtNote
        '
        Me.txtNote.EditValue = ""
        Me.txtNote.Location = New System.Drawing.Point(772, 5)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Properties.Appearance.Options.UseFont = True
        Me.txtNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNote.Size = New System.Drawing.Size(323, 83)
        Me.txtNote.TabIndex = 10
        '
        'txtPPN
        '
        Me.txtPPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPPN.EditValue = ""
        Me.txtPPN.Location = New System.Drawing.Point(914, 446)
        Me.txtPPN.Name = "txtPPN"
        Me.txtPPN.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPN.Properties.Appearance.Options.UseFont = True
        Me.txtPPN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtPPN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPPN.Size = New System.Drawing.Size(181, 26)
        Me.txtPPN.TabIndex = 114
        '
        'LabelControl6
        '
        Me.LabelControl6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(843, 449)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(57, 17)
        Me.LabelControl6.TabIndex = 113
        Me.LabelControl6.Text = "Total PPN"
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepocbItemCode, Me.RepocbDiscountType})
        '
        'RepocbItemCode
        '
        Me.RepocbItemCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepocbItemCode.Name = "RepocbItemCode"
        '
        'RbI
        '
        Me.RbI.AutoSize = True
        Me.RbI.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbI.Location = New System.Drawing.Point(137, 65)
        Me.RbI.Name = "RbI"
        Me.RbI.Size = New System.Drawing.Size(82, 21)
        Me.RbI.TabIndex = 2
        Me.RbI.TabStop = True
        Me.RbI.Text = "Include (I)"
        Me.RbI.UseVisualStyleBackColor = True
        '
        'RbE
        '
        Me.RbE.AutoSize = True
        Me.RbE.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbE.Location = New System.Drawing.Point(225, 65)
        Me.RbE.Name = "RbE"
        Me.RbE.Size = New System.Drawing.Size(85, 21)
        Me.RbE.TabIndex = 3
        Me.RbE.TabStop = True
        Me.RbE.Text = "Exclude(E)"
        Me.RbE.UseVisualStyleBackColor = True
        '
        'RbO
        '
        Me.RbO.AutoSize = True
        Me.RbO.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbO.Location = New System.Drawing.Point(316, 65)
        Me.RbO.Name = "RbO"
        Me.RbO.Size = New System.Drawing.Size(135, 21)
        Me.RbO.TabIndex = 4
        Me.RbO.TabStop = True
        Me.RbO.Text = "Not Applicable (O)"
        Me.RbO.UseVisualStyleBackColor = True
        '
        'txtCurRate
        '
        Me.txtCurRate.EditValue = "1"
        Me.txtCurRate.Location = New System.Drawing.Point(192, 92)
        Me.txtCurRate.Name = "txtCurRate"
        Me.txtCurRate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurRate.Properties.Appearance.Options.UseFont = True
        Me.txtCurRate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCurRate.Size = New System.Drawing.Size(101, 26)
        Me.txtCurRate.TabIndex = 6
        '
        'txtDiscountHead
        '
        Me.txtDiscountHead.EditValue = "0"
        Me.txtDiscountHead.Location = New System.Drawing.Point(338, 92)
        Me.txtDiscountHead.Name = "txtDiscountHead"
        Me.txtDiscountHead.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscountHead.Properties.Appearance.Options.UseFont = True
        Me.txtDiscountHead.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDiscountHead.Size = New System.Drawing.Size(42, 26)
        Me.txtDiscountHead.TabIndex = 7
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(308, 97)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 17)
        Me.LabelControl7.TabIndex = 120
        Me.LabelControl7.Text = "Disc"
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(386, 97)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(11, 17)
        Me.LabelControl14.TabIndex = 121
        Me.LabelControl14.Text = "%"
        '
        'txtCurrency
        '
        Me.txtCurrency.EditValue = ""
        Me.txtCurrency.Location = New System.Drawing.Point(137, 92)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.Properties.Appearance.Options.UseFont = True
        Me.txtCurrency.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCurrency.Properties.Items.AddRange(New Object() {"IDR", "SGD", "USD", "EUR"})
        Me.txtCurrency.Size = New System.Drawing.Size(49, 26)
        Me.txtCurrency.TabIndex = 5
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Appearance.Options.UseFont = True
        Me.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(225, 421)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(104, 34)
        Me.btnEdit.TabIndex = 15
        Me.btnEdit.Text = "Edit"
        '
        'cbVendor
        '
        Me.cbVendor.Location = New System.Drawing.Point(136, 34)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.Properties.Appearance.Options.UseFont = True
        Me.cbVendor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.cbVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbVendor.Size = New System.Drawing.Size(247, 26)
        Me.cbVendor.TabIndex = 122
        '
        'RepocbDiscountType
        '
        Me.RepocbDiscountType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepocbDiscountType.Name = "RepocbDiscountType"
        '
        'FormAddPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 508)
        Me.Controls.Add(Me.cbVendor)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtDiscountHead)
        Me.Controls.Add(Me.txtCurRate)
        Me.Controls.Add(Me.RbO)
        Me.Controls.Add(Me.RbE)
        Me.Controls.Add(Me.RbI)
        Me.Controls.Add(Me.txtPPN)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtNetPrice)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtDocNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtCurrency)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAddPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        CType(Me.txtNetPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepocbItemCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscountHead.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepocbDiscountType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNetPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDiscount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnConvert As Button
    Friend WithEvents txtRef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDocNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtPPN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepocbItemCode As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RbI As RadioButton
    Friend WithEvents RbE As RadioButton
    Friend WithEvents RbO As RadioButton
    Friend WithEvents txtCurRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDiscountHead As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCurrency As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbVendor As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RepocbDiscountType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
