<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddPayment
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddPayment))
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalPaymentAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalRefInvAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalPayment = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNote = New DevExpress.XtraEditors.MemoEdit()
        Me.txtRate = New DevExpress.XtraEditors.TextEdit()
        Me.txtDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCashBank = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDocNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPartnertType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository(Me.components)
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.RbIncoming = New System.Windows.Forms.RadioButton()
        Me.rbOutgoing = New System.Windows.Forms.RadioButton()
        Me.txtPartnerName = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalPaymentIDR = New DevExpress.XtraEditors.TextEdit()
        Me.txtCurrency = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.txtTotalPaymentAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalRefInvAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCashBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartnertType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartnerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPaymentIDR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Location = New System.Drawing.Point(404, 65)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(81, 17)
        Me.LabelControl18.TabIndex = 300
        Me.LabelControl18.Text = "Partner Name"
        '
        'txtTotalPaymentAmount
        '
        Me.txtTotalPaymentAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPaymentAmount.EditValue = ""
        Me.txtTotalPaymentAmount.Location = New System.Drawing.Point(889, 401)
        Me.txtTotalPaymentAmount.Name = "txtTotalPaymentAmount"
        Me.txtTotalPaymentAmount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPaymentAmount.Properties.Appearance.Options.UseFont = True
        Me.txtTotalPaymentAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotalPaymentAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalPaymentAmount.Size = New System.Drawing.Size(181, 26)
        Me.txtTotalPaymentAmount.TabIndex = 17
        '
        'LabelControl14
        '
        Me.LabelControl14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(752, 406)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(131, 17)
        Me.LabelControl14.TabIndex = 291
        Me.LabelControl14.Text = "Total Payment Amount"
        '
        'txtTotalRefInvAmount
        '
        Me.txtTotalRefInvAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRefInvAmount.EditValue = ""
        Me.txtTotalRefInvAmount.Location = New System.Drawing.Point(889, 373)
        Me.txtTotalRefInvAmount.Name = "txtTotalRefInvAmount"
        Me.txtTotalRefInvAmount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRefInvAmount.Properties.Appearance.Options.UseFont = True
        Me.txtTotalRefInvAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotalRefInvAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalRefInvAmount.Size = New System.Drawing.Size(181, 26)
        Me.txtTotalRefInvAmount.TabIndex = 16
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(762, 376)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(121, 17)
        Me.LabelControl15.TabIndex = 289
        Me.LabelControl15.Text = "Total Ref Inv Amount"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.DataSource = Me.BindingSource1
        Me.GridControl1.Location = New System.Drawing.Point(5, 122)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.GridControl1.Size = New System.Drawing.Size(1065, 245)
        Me.GridControl1.TabIndex = 288
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
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(679, 10)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(29, 17)
        Me.LabelControl12.TabIndex = 285
        Me.LabelControl12.Text = "Note"
        '
        'txtTotalPayment
        '
        Me.txtTotalPayment.EditValue = "0"
        Me.txtTotalPayment.Location = New System.Drawing.Point(806, 60)
        Me.txtTotalPayment.Name = "txtTotalPayment"
        Me.txtTotalPayment.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPayment.Properties.Appearance.Options.UseFont = True
        Me.txtTotalPayment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotalPayment.Size = New System.Drawing.Size(257, 26)
        Me.txtTotalPayment.TabIndex = 11
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(679, 65)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(82, 17)
        Me.LabelControl6.TabIndex = 281
        Me.LabelControl6.Text = "Total Payment"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(14, 94)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(90, 17)
        Me.LabelControl9.TabIndex = 277
        Me.LabelControl9.Text = "Currency / Rate"
        '
        'txtNote
        '
        Me.txtNote.EditValue = ""
        Me.txtNote.Location = New System.Drawing.Point(806, 6)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Properties.Appearance.Options.UseFont = True
        Me.txtNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNote.Size = New System.Drawing.Size(257, 52)
        Me.txtNote.TabIndex = 10
        '
        'txtRate
        '
        Me.txtRate.EditValue = "1"
        Me.txtRate.Location = New System.Drawing.Point(213, 89)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRate.Properties.Appearance.Options.UseFont = True
        Me.txtRate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtRate.Size = New System.Drawing.Size(69, 26)
        Me.txtRate.TabIndex = 7
        '
        'txtDate
        '
        Me.txtDate.EditValue = Nothing
        Me.txtDate.Location = New System.Drawing.Point(487, 5)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Properties.Appearance.Options.UseFont = True
        Me.txtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Size = New System.Drawing.Size(174, 26)
        Me.txtDate.TabIndex = 2
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(404, 37)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(74, 17)
        Me.LabelControl8.TabIndex = 272
        Me.LabelControl8.Text = "Partner Type"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(404, 10)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(27, 17)
        Me.LabelControl5.TabIndex = 271
        Me.LabelControl5.Text = "Date"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 65)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(118, 17)
        Me.LabelControl3.TabIndex = 269
        Me.LabelControl3.Text = "Cash / Bank Account"
        '
        'txtCashBank
        '
        Me.txtCashBank.EditValue = ""
        Me.txtCashBank.Location = New System.Drawing.Point(139, 60)
        Me.txtCashBank.Name = "txtCashBank"
        Me.txtCashBank.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashBank.Properties.Appearance.Options.UseFont = True
        Me.txtCashBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCashBank.Size = New System.Drawing.Size(239, 26)
        Me.txtCashBank.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 37)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(99, 17)
        Me.LabelControl2.TabIndex = 267
        Me.LabelControl2.Text = "Type Of Payment"
        '
        'txtDocNumber
        '
        Me.txtDocNumber.EditValue = "Otomatis"
        Me.txtDocNumber.Location = New System.Drawing.Point(139, 5)
        Me.txtDocNumber.Name = "txtDocNumber"
        Me.txtDocNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocNumber.Properties.Appearance.Options.UseFont = True
        Me.txtDocNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDocNumber.Size = New System.Drawing.Size(134, 26)
        Me.txtDocNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(15, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(111, 17)
        Me.LabelControl1.TabIndex = 265
        Me.LabelControl1.Text = "Document Number"
        '
        'txtPartnertType
        '
        Me.txtPartnertType.Location = New System.Drawing.Point(487, 32)
        Me.txtPartnertType.Name = "txtPartnertType"
        Me.txtPartnertType.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartnertType.Properties.Appearance.Options.UseFont = True
        Me.txtPartnertType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtPartnertType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPartnertType.Properties.Items.AddRange(New Object() {"Customer", "Vendor", "Other"})
        Me.txtPartnertType.Size = New System.Drawing.Size(174, 26)
        Me.txtPartnertType.TabIndex = 8
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchLookUpEdit1})
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
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(120, 385)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(39, 34)
        Me.btnPrint.TabIndex = 14
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Appearance.Options.UseFont = True
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(165, 385)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(40, 34)
        Me.btnClear.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(10, 385)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 34)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        '
        'RbIncoming
        '
        Me.RbIncoming.AutoSize = True
        Me.RbIncoming.Location = New System.Drawing.Point(139, 37)
        Me.RbIncoming.Name = "RbIncoming"
        Me.RbIncoming.Size = New System.Drawing.Size(112, 17)
        Me.RbIncoming.TabIndex = 3
        Me.RbIncoming.TabStop = True
        Me.RbIncoming.Text = "Incoming Payment"
        Me.RbIncoming.UseVisualStyleBackColor = True
        '
        'rbOutgoing
        '
        Me.rbOutgoing.AutoSize = True
        Me.rbOutgoing.Location = New System.Drawing.Point(266, 37)
        Me.rbOutgoing.Name = "rbOutgoing"
        Me.rbOutgoing.Size = New System.Drawing.Size(112, 17)
        Me.rbOutgoing.TabIndex = 4
        Me.rbOutgoing.TabStop = True
        Me.rbOutgoing.Text = "Outgoing Payment"
        Me.rbOutgoing.UseVisualStyleBackColor = True
        '
        'txtPartnerName
        '
        Me.txtPartnerName.Location = New System.Drawing.Point(487, 60)
        Me.txtPartnerName.Name = "txtPartnerName"
        Me.txtPartnerName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartnerName.Properties.Appearance.Options.UseFont = True
        Me.txtPartnerName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtPartnerName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPartnerName.Properties.Items.AddRange(New Object() {"Customer", "Vendor", "Other"})
        Me.txtPartnerName.Size = New System.Drawing.Size(174, 26)
        Me.txtPartnerName.TabIndex = 9
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(679, 94)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(121, 17)
        Me.LabelControl7.TabIndex = 306
        Me.LabelControl7.Text = "Total Payment in IDR"
        '
        'txtTotalPaymentIDR
        '
        Me.txtTotalPaymentIDR.EditValue = "0"
        Me.txtTotalPaymentIDR.Location = New System.Drawing.Point(806, 89)
        Me.txtTotalPaymentIDR.Name = "txtTotalPaymentIDR"
        Me.txtTotalPaymentIDR.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPaymentIDR.Properties.Appearance.Options.UseFont = True
        Me.txtTotalPaymentIDR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtTotalPaymentIDR.Size = New System.Drawing.Size(257, 26)
        Me.txtTotalPaymentIDR.TabIndex = 12
        '
        'txtCurrency
        '
        Me.txtCurrency.EditValue = ""
        Me.txtCurrency.Location = New System.Drawing.Point(138, 89)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.Properties.Appearance.Options.UseFont = True
        Me.txtCurrency.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCurrency.Properties.Items.AddRange(New Object() {"IDR", "SGD", "USD", "EUR"})
        Me.txtCurrency.Size = New System.Drawing.Size(69, 26)
        Me.txtCurrency.TabIndex = 6
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'FormAddPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 431)
        Me.Controls.Add(Me.txtTotalPaymentIDR)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtPartnerName)
        Me.Controls.Add(Me.rbOutgoing)
        Me.Controls.Add(Me.RbIncoming)
        Me.Controls.Add(Me.LabelControl18)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtTotalPaymentAmount)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.txtTotalRefInvAmount)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.txtTotalPayment)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtCashBank)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtDocNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtPartnertType)
        Me.Controls.Add(Me.txtCurrency)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAddPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment"
        CType(Me.txtTotalPaymentAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalRefInvAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCashBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartnertType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartnerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPaymentIDR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTotalPaymentAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalRefInvAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalPayment As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCashBank As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDocNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPartnertType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RbIncoming As RadioButton
    Friend WithEvents rbOutgoing As RadioButton
    Friend WithEvents txtPartnerName As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalPaymentIDR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCurrency As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
