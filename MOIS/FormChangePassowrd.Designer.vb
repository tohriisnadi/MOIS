<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChangePassowrd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormChangePassowrd))
        Me.txtNewPwd2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtOldpwd = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNewPwd1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lbUsername = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtNewPwd2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOldpwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNewPwd1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNewPwd2
        '
        Me.txtNewPwd2.Location = New System.Drawing.Point(217, 130)
        Me.txtNewPwd2.Name = "txtNewPwd2"
        Me.txtNewPwd2.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPwd2.Properties.Appearance.Options.UseFont = True
        Me.txtNewPwd2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNewPwd2.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPwd2.Size = New System.Drawing.Size(236, 26)
        Me.txtNewPwd2.TabIndex = 9
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl2.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl2.LineColor = System.Drawing.Color.Transparent
        Me.LabelControl2.Location = New System.Drawing.Point(125, 133)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(86, 34)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Re Type " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "New Password"
        '
        'txtOldpwd
        '
        Me.txtOldpwd.Location = New System.Drawing.Point(217, 70)
        Me.txtOldpwd.Name = "txtOldpwd"
        Me.txtOldpwd.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldpwd.Properties.Appearance.Options.UseFont = True
        Me.txtOldpwd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtOldpwd.Size = New System.Drawing.Size(236, 26)
        Me.txtOldpwd.TabIndex = 8
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl1.LineColor = System.Drawing.Color.Transparent
        Me.LabelControl1.Location = New System.Drawing.Point(125, 73)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 17)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Old Password"
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(346, 177)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 46)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'btnUpdate
        '
        Me.btnUpdate.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Appearance.Options.UseFont = True
        Me.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(217, 177)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(104, 46)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        '
        'txtNewPwd1
        '
        Me.txtNewPwd1.Location = New System.Drawing.Point(217, 100)
        Me.txtNewPwd1.Name = "txtNewPwd1"
        Me.txtNewPwd1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPwd1.Properties.Appearance.Options.UseFont = True
        Me.txtNewPwd1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNewPwd1.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPwd1.Size = New System.Drawing.Size(236, 26)
        Me.txtNewPwd1.TabIndex = 11
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl3.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl3.LineColor = System.Drawing.Color.Transparent
        Me.LabelControl3.Location = New System.Drawing.Point(125, 103)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(86, 17)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "New Password"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl4.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl4.LineColor = System.Drawing.Color.Transparent
        Me.LabelControl4.Location = New System.Drawing.Point(125, 37)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(98, 20)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "USER NAME : "
        '
        'lbUsername
        '
        Me.lbUsername.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lbUsername.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.lbUsername.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUsername.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lbUsername.LineColor = System.Drawing.Color.Transparent
        Me.lbUsername.Location = New System.Drawing.Point(226, 37)
        Me.lbUsername.Name = "lbUsername"
        Me.lbUsername.Size = New System.Drawing.Size(95, 20)
        Me.lbUsername.TabIndex = 13
        Me.lbUsername.Text = "Old Password"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(2, 48)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(117, 119)
        Me.PictureEdit1.TabIndex = 14
        '
        'FormChangePassowrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 239)
        Me.Controls.Add(Me.lbUsername)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtNewPwd1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtNewPwd2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtOldpwd)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormChangePassowrd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOIS - Change Password"
        CType(Me.txtNewPwd2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOldpwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNewPwd1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNewPwd2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOldpwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNewPwd1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbUsername As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
End Class
