<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddWarehouse
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddWarehouse))
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtWhsCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtWhsDesc = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAddress = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCity = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCountry = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtZipCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtContact = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFax = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.ckInactive = New DevExpress.XtraEditors.CheckEdit()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWhsCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWhsDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtZipCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckInactive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureEdit1.EditValue = Global.MOIS.My.Resources.Resources.building1
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(643, 75)
        Me.PictureEdit1.TabIndex = 17
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(15, 81)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 17)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Whs. Code"
        '
        'txtWhsCode
        '
        Me.txtWhsCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtWhsCode.Location = New System.Drawing.Point(132, 78)
        Me.txtWhsCode.Name = "txtWhsCode"
        Me.txtWhsCode.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhsCode.Properties.Appearance.Options.UseFont = True
        Me.txtWhsCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtWhsCode.Size = New System.Drawing.Size(181, 26)
        Me.txtWhsCode.TabIndex = 19
        Me.txtWhsCode.ToolTip = "Press Enter to Validate Whs Code"
        '
        'txtWhsDesc
        '
        Me.txtWhsDesc.Location = New System.Drawing.Point(132, 105)
        Me.txtWhsDesc.Name = "txtWhsDesc"
        Me.txtWhsDesc.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhsDesc.Properties.Appearance.Options.UseFont = True
        Me.txtWhsDesc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtWhsDesc.Size = New System.Drawing.Size(499, 26)
        Me.txtWhsDesc.TabIndex = 21
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 108)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(98, 17)
        Me.LabelControl2.TabIndex = 20
        Me.LabelControl2.Text = "Whs. Description"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(132, 132)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Properties.Appearance.Options.UseFont = True
        Me.txtAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtAddress.Size = New System.Drawing.Size(499, 26)
        Me.txtAddress.TabIndex = 23
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 135)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 17)
        Me.LabelControl3.TabIndex = 22
        Me.LabelControl3.Text = "Address"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(132, 159)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Properties.Appearance.Options.UseFont = True
        Me.txtCity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtCity.Size = New System.Drawing.Size(181, 26)
        Me.txtCity.TabIndex = 25
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(15, 162)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(21, 17)
        Me.LabelControl4.TabIndex = 24
        Me.LabelControl4.Text = "City"
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(132, 186)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Properties.Appearance.Options.UseFont = True
        Me.txtCountry.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtCountry.Size = New System.Drawing.Size(181, 26)
        Me.txtCountry.TabIndex = 27
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(15, 189)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(40, 17)
        Me.LabelControl5.TabIndex = 26
        Me.LabelControl5.Text = "County"
        '
        'txtZipCode
        '
        Me.txtZipCode.Location = New System.Drawing.Point(414, 159)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.Properties.Appearance.Options.UseFont = True
        Me.txtZipCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtZipCode.Size = New System.Drawing.Size(217, 26)
        Me.txtZipCode.TabIndex = 29
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(346, 162)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(53, 17)
        Me.LabelControl6.TabIndex = 28
        Me.LabelControl6.Text = "Zip Code"
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(132, 213)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Properties.Appearance.Options.UseFont = True
        Me.txtContact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtContact.Size = New System.Drawing.Size(499, 26)
        Me.txtContact.TabIndex = 31
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(15, 216)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(44, 17)
        Me.LabelControl7.TabIndex = 30
        Me.LabelControl7.Text = "Contact"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(132, 244)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Properties.Appearance.Options.UseFont = True
        Me.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtPhone.Size = New System.Drawing.Size(181, 26)
        Me.txtPhone.TabIndex = 33
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(15, 247)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(36, 17)
        Me.LabelControl8.TabIndex = 32
        Me.LabelControl8.Text = "Phone"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(414, 241)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.Properties.Appearance.Options.UseFont = True
        Me.txtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtFax.Size = New System.Drawing.Size(217, 26)
        Me.txtFax.TabIndex = 35
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(346, 244)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(19, 17)
        Me.LabelControl9.TabIndex = 34
        Me.LabelControl9.Text = "Fax"
        '
        'ckInactive
        '
        Me.ckInactive.Location = New System.Drawing.Point(526, 77)
        Me.ckInactive.Name = "ckInactive"
        Me.ckInactive.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckInactive.Properties.Appearance.Options.UseFont = True
        Me.ckInactive.Properties.Caption = "Inactive"
        Me.ckInactive.Size = New System.Drawing.Size(105, 21)
        Me.ckInactive.TabIndex = 36
        '
        'btnClear
        '
        Me.btnClear.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Appearance.Options.UseFont = True
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(247, 273)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(104, 34)
        Me.btnClear.TabIndex = 38
        Me.btnClear.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(132, 273)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 34)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Save"
        '
        'FormAddWarehouse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(643, 316)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ckInactive)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtZipCode)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtWhsDesc)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtWhsCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddWarehouse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warehouse"
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWhsCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWhsDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtZipCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckInactive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWhsCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtWhsDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCountry As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtZipCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtContact As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ckInactive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
