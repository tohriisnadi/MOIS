<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddSalesOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddSalesOrder))
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.txtNetPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTotalPPN = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDiscount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDiscountHeader = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository(Me.components)
        Me.RepoItemCode = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtNote = New DevExpress.XtraEditors.MemoEdit()
        Me.txtRate = New DevExpress.XtraEditors.TextEdit()
        Me.txtRef = New DevExpress.XtraEditors.TextEdit()
        Me.txtDeliveryDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtContactPerson = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDocNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cbCust = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtSalesPerson = New DevExpress.XtraEditors.TextEdit()
        Me.txtPPNStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtTermOfPayment = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCurrency = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.RepocbDiscountType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNetPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPPN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscountHeader.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoItemCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeliveryDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeliveryDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCust.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalesPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPNStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTermOfPayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepocbDiscountType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'txtNetPrice
        '
        Me.txtNetPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNetPrice.EditValue = ""
        Me.txtNetPrice.Location = New System.Drawing.Point(830, 482)
        Me.txtNetPrice.Name = "txtNetPrice"
        Me.txtNetPrice.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetPrice.Properties.Appearance.Options.UseFont = True
        Me.txtNetPrice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNetPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNetPrice.Size = New System.Drawing.Size(181, 26)
        Me.txtNetPrice.TabIndex = 139
        '
        'LabelControl16
        '
        Me.LabelControl16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Location = New System.Drawing.Point(767, 485)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(53, 17)
        Me.LabelControl16.TabIndex = 138
        Me.LabelControl16.Text = "Net Price"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(115, 396)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(38, 34)
        Me.btnPrint.TabIndex = 137
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Appearance.Options.UseFont = True
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(159, 396)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(41, 34)
        Me.btnClear.TabIndex = 136
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(5, 396)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 34)
        Me.btnSave.TabIndex = 135
        Me.btnSave.Text = "Save"
        '
        'txtTotalPPN
        '
        Me.txtTotalPPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPPN.EditValue = ""
        Me.txtTotalPPN.Location = New System.Drawing.Point(830, 453)
        Me.txtTotalPPN.Name = "txtTotalPPN"
        Me.txtTotalPPN.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPPN.Properties.Appearance.Options.UseFont = True
        Me.txtTotalPPN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotalPPN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalPPN.Size = New System.Drawing.Size(181, 26)
        Me.txtTotalPPN.TabIndex = 134
        '
        'LabelControl13
        '
        Me.LabelControl13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(763, 456)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(57, 17)
        Me.LabelControl13.TabIndex = 133
        Me.LabelControl13.Text = "Total PPN"
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.EditValue = ""
        Me.txtDiscount.Location = New System.Drawing.Point(830, 424)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Properties.Appearance.Options.UseFont = True
        Me.txtDiscount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiscount.Size = New System.Drawing.Size(181, 26)
        Me.txtDiscount.TabIndex = 132
        '
        'LabelControl14
        '
        Me.LabelControl14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(737, 427)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(83, 17)
        Me.LabelControl14.TabIndex = 131
        Me.LabelControl14.Text = "Total Discount"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.EditValue = ""
        Me.txtTotal.Location = New System.Drawing.Point(830, 396)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Properties.Appearance.Options.UseFont = True
        Me.txtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(181, 26)
        Me.txtTotal.TabIndex = 130
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(759, 399)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(61, 17)
        Me.LabelControl15.TabIndex = 129
        Me.LabelControl15.Text = "Total Price"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.DataSource = Me.BindingSource1
        Me.GridControl1.Location = New System.Drawing.Point(5, 154)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.GridControl1.Size = New System.Drawing.Size(1006, 236)
        Me.GridControl1.TabIndex = 128
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(849, 124)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(162, 23)
        Me.btnConvert.TabIndex = 127
        Me.btnConvert.Text = "Convert From Sales Quotation"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(697, 10)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(29, 17)
        Me.LabelControl12.TabIndex = 125
        Me.LabelControl12.Text = "Note"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(385, 127)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(63, 17)
        Me.LabelControl11.TabIndex = 123
        Me.LabelControl11.Text = "PPN Status"
        '
        'txtDiscountHeader
        '
        Me.txtDiscountHeader.EditValue = "0"
        Me.txtDiscountHeader.Location = New System.Drawing.Point(467, 93)
        Me.txtDiscountHeader.Name = "txtDiscountHeader"
        Me.txtDiscountHeader.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscountHeader.Properties.Appearance.Options.UseFont = True
        Me.txtDiscountHeader.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDiscountHeader.Size = New System.Drawing.Size(39, 26)
        Me.txtDiscountHeader.TabIndex = 122
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(382, 98)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(50, 17)
        Me.LabelControl6.TabIndex = 121
        Me.LabelControl6.Text = "Discount"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(15, 127)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(90, 17)
        Me.LabelControl9.TabIndex = 117
        Me.LabelControl9.Text = "Currency / Rate"
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoItemCode, Me.RepositoryItemSearchLookUpEdit1, Me.RepocbDiscountType})
        '
        'RepoItemCode
        '
        Me.RepoItemCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoItemCode.Name = "RepoItemCode"
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
        'txtNote
        '
        Me.txtNote.EditValue = ""
        Me.txtNote.Location = New System.Drawing.Point(737, 8)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Properties.Appearance.Options.UseFont = True
        Me.txtNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNote.Size = New System.Drawing.Size(267, 70)
        Me.txtNote.TabIndex = 126
        '
        'txtRate
        '
        Me.txtRate.EditValue = "1"
        Me.txtRate.Location = New System.Drawing.Point(203, 122)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRate.Properties.Appearance.Options.UseFont = True
        Me.txtRate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtRate.Size = New System.Drawing.Size(69, 26)
        Me.txtRate.TabIndex = 119
        '
        'txtRef
        '
        Me.txtRef.EditValue = ""
        Me.txtRef.Location = New System.Drawing.Point(128, 92)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRef.Properties.Appearance.Options.UseFont = True
        Me.txtRef.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtRef.Size = New System.Drawing.Size(239, 26)
        Me.txtRef.TabIndex = 115
        '
        'txtDeliveryDate
        '
        Me.txtDeliveryDate.EditValue = Nothing
        Me.txtDeliveryDate.Location = New System.Drawing.Point(467, 34)
        Me.txtDeliveryDate.Name = "txtDeliveryDate"
        Me.txtDeliveryDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryDate.Properties.Appearance.Options.UseFont = True
        Me.txtDeliveryDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDeliveryDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDeliveryDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDeliveryDate.Size = New System.Drawing.Size(195, 26)
        Me.txtDeliveryDate.TabIndex = 113
        '
        'txtDate
        '
        Me.txtDate.EditValue = Nothing
        Me.txtDate.Location = New System.Drawing.Point(467, 5)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Properties.Appearance.Options.UseFont = True
        Me.txtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Size = New System.Drawing.Size(195, 26)
        Me.txtDate.TabIndex = 112
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(382, 68)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(70, 17)
        Me.LabelControl8.TabIndex = 111
        Me.LabelControl8.Text = "SalesPerson"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(382, 39)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(77, 17)
        Me.LabelControl7.TabIndex = 110
        Me.LabelControl7.Text = "Delivery Date"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(382, 10)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(27, 17)
        Me.LabelControl5.TabIndex = 109
        Me.LabelControl5.Text = "Date"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(15, 97)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(58, 17)
        Me.LabelControl4.TabIndex = 108
        Me.LabelControl4.Text = "Reference"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 68)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(88, 17)
        Me.LabelControl3.TabIndex = 107
        Me.LabelControl3.Text = "Contact Person"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.EditValue = ""
        Me.txtContactPerson.Location = New System.Drawing.Point(128, 63)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Properties.Appearance.Options.UseFont = True
        Me.txtContactPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtContactPerson.Size = New System.Drawing.Size(239, 26)
        Me.txtContactPerson.TabIndex = 106
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 39)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 17)
        Me.LabelControl2.TabIndex = 105
        Me.LabelControl2.Text = "Customer"
        '
        'txtDocNumber
        '
        Me.txtDocNumber.EditValue = "Otomatis"
        Me.txtDocNumber.Location = New System.Drawing.Point(128, 5)
        Me.txtDocNumber.Name = "txtDocNumber"
        Me.txtDocNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocNumber.Properties.Appearance.Options.UseFont = True
        Me.txtDocNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDocNumber.Size = New System.Drawing.Size(134, 26)
        Me.txtDocNumber.TabIndex = 104
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(15, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(111, 17)
        Me.LabelControl1.TabIndex = 103
        Me.LabelControl1.Text = "Document Number"
        '
        'cbCust
        '
        Me.cbCust.EditValue = ""
        Me.cbCust.Location = New System.Drawing.Point(128, 34)
        Me.cbCust.Name = "cbCust"
        Me.cbCust.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCust.Properties.Appearance.Options.UseFont = True
        Me.cbCust.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.cbCust.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbCust.Properties.DisplayFormat.FormatString = "d"
        Me.cbCust.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbCust.Properties.EditFormat.FormatString = "d"
        Me.cbCust.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbCust.Size = New System.Drawing.Size(134, 26)
        Me.cbCust.TabIndex = 114
        '
        'txtSalesPerson
        '
        Me.txtSalesPerson.Location = New System.Drawing.Point(467, 63)
        Me.txtSalesPerson.Name = "txtSalesPerson"
        Me.txtSalesPerson.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPerson.Properties.Appearance.Options.UseFont = True
        Me.txtSalesPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtSalesPerson.Size = New System.Drawing.Size(195, 26)
        Me.txtSalesPerson.TabIndex = 116
        '
        'txtPPNStatus
        '
        Me.txtPPNStatus.EditValue = ""
        Me.txtPPNStatus.Location = New System.Drawing.Point(468, 122)
        Me.txtPPNStatus.Name = "txtPPNStatus"
        Me.txtPPNStatus.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPNStatus.Properties.Appearance.Options.UseFont = True
        Me.txtPPNStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtPPNStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPPNStatus.Properties.Items.AddRange(New Object() {"Include", "Exclude", "Not Aplicable"})
        Me.txtPPNStatus.Size = New System.Drawing.Size(91, 26)
        Me.txtPPNStatus.TabIndex = 124
        '
        'txtTermOfPayment
        '
        Me.txtTermOfPayment.EditValue = "0"
        Me.txtTermOfPayment.Location = New System.Drawing.Point(793, 84)
        Me.txtTermOfPayment.Name = "txtTermOfPayment"
        Me.txtTermOfPayment.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTermOfPayment.Properties.Appearance.Options.UseFont = True
        Me.txtTermOfPayment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTermOfPayment.Size = New System.Drawing.Size(39, 26)
        Me.txtTermOfPayment.TabIndex = 141
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(686, 89)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(101, 17)
        Me.LabelControl10.TabIndex = 140
        Me.LabelControl10.Text = "Term Of Payment"
        '
        'txtCurrency
        '
        Me.txtCurrency.EditValue = ""
        Me.txtCurrency.Location = New System.Drawing.Point(128, 122)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.Properties.Appearance.Options.UseFont = True
        Me.txtCurrency.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCurrency.Properties.Items.AddRange(New Object() {"IDR", "SGD", "USD", "EUR"})
        Me.txtCurrency.Size = New System.Drawing.Size(69, 26)
        Me.txtCurrency.TabIndex = 118
        '
        'btnEdit
        '
        Me.btnEdit.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Appearance.Options.UseFont = True
        Me.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(206, 396)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(104, 34)
        Me.btnEdit.TabIndex = 142
        Me.btnEdit.Text = "Edit"
        '
        'RepocbDiscountType
        '
        Me.RepocbDiscountType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepocbDiscountType.Name = "RepocbDiscountType"
        '
        'FormAddSalesOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 512)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtTermOfPayment)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.txtNetPrice)
        Me.Controls.Add(Me.LabelControl16)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtTotalPPN)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.txtDiscountHeader)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.txtDeliveryDate)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtContactPerson)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtDocNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cbCust)
        Me.Controls.Add(Me.txtSalesPerson)
        Me.Controls.Add(Me.txtPPNStatus)
        Me.Controls.Add(Me.txtCurrency)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAddSalesOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Order"
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNetPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPPN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscountHeader.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoItemCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeliveryDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeliveryDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCust.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalesPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPNStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTermOfPayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepocbDiscountType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents txtNetPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTotalPPN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDiscount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnConvert As Button
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDiscountHeader As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepoItemCode As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents txtNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDeliveryDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtContactPerson As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDocNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbCust As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtSalesPerson As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPPNStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtTermOfPayment As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCurrency As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepocbDiscountType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
