<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfiguracoes
    Inherits System.Windows.Forms.UserControl

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlAbas = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTabBarbearia = New System.Windows.Forms.Button()
        Me.btnTabUsuario = New System.Windows.Forms.Button()
        Me.btnTabNotificacoes = New System.Windows.Forms.Button()
        Me.pnlBarbearia = New System.Windows.Forms.Panel()
        Me.pnlUsuario = New System.Windows.Forms.Panel()
        Me.pnlNotificacoes = New System.Windows.Forms.Panel()
        Me.pnlAbas.SuspendLayout()
        Me.SuspendLayout()
        Me.pnlAbas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAbas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAbas.Name = "pnlAbas"
        Me.pnlAbas.Size = New System.Drawing.Size(780, 110)
        Me.pnlAbas.TabIndex = 6
        Me.pnlAbas.Controls.Add(Me.Panel1)
        Me.pnlAbas.Controls.Add(Me.btnTabBarbearia)
        Me.pnlAbas.Controls.Add(Me.btnTabUsuario)
        Me.pnlAbas.Controls.Add(Me.btnTabNotificacoes)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(774, 37)
        Me.Panel1.TabIndex = 3
        Me.btnTabBarbearia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTabBarbearia.FlatAppearance.BorderSize = 0
        Me.btnTabBarbearia.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnTabBarbearia.ForeColor = System.Drawing.Color.Silver
        Me.btnTabBarbearia.Location = New System.Drawing.Point(44, 10)
        Me.btnTabBarbearia.Name = "btnTabBarbearia"
        Me.btnTabBarbearia.Size = New System.Drawing.Size(106, 29)
        Me.btnTabBarbearia.TabIndex = 0
        Me.btnTabBarbearia.Text = "Barbearia"
        Me.btnTabBarbearia.UseVisualStyleBackColor = False
        Me.btnTabUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTabUsuario.FlatAppearance.BorderSize = 0
        Me.btnTabUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnTabUsuario.ForeColor = System.Drawing.Color.Silver
        Me.btnTabUsuario.Location = New System.Drawing.Point(156, 10)
        Me.btnTabUsuario.Name = "btnTabUsuario"
        Me.btnTabUsuario.Size = New System.Drawing.Size(106, 29)
        Me.btnTabUsuario.TabIndex = 1
        Me.btnTabUsuario.Text = "Usuário"
        Me.btnTabUsuario.UseVisualStyleBackColor = False
        Me.btnTabNotificacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTabNotificacoes.FlatAppearance.BorderSize = 0
        Me.btnTabNotificacoes.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnTabNotificacoes.ForeColor = System.Drawing.Color.Silver
        Me.btnTabNotificacoes.Location = New System.Drawing.Point(268, 10)
        Me.btnTabNotificacoes.Name = "btnTabNotificacoes"
        Me.btnTabNotificacoes.Size = New System.Drawing.Size(106, 29)
        Me.btnTabNotificacoes.TabIndex = 2
        Me.btnTabNotificacoes.Text = "Notificações"
        Me.btnTabNotificacoes.UseVisualStyleBackColor = False
        Me.pnlBarbearia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBarbearia.Location = New System.Drawing.Point(0, 110)
        Me.pnlBarbearia.Name = "pnlBarbearia"
        Me.pnlBarbearia.Size = New System.Drawing.Size(780, 510)
        Me.pnlBarbearia.TabIndex = 5
        Me.pnlUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUsuario.Location = New System.Drawing.Point(0, 110)
        Me.pnlUsuario.Name = "pnlUsuario"
        Me.pnlUsuario.Size = New System.Drawing.Size(780, 510)
        Me.pnlUsuario.TabIndex = 5
        Me.pnlUsuario.Visible = False
        Me.pnlNotificacoes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNotificacoes.Location = New System.Drawing.Point(0, 110)
        Me.pnlNotificacoes.Name = "pnlNotificacoes"
        Me.pnlNotificacoes.Size = New System.Drawing.Size(780, 510)
        Me.pnlNotificacoes.TabIndex = 4
        Me.pnlNotificacoes.Visible = False
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Controls.Add(Me.pnlBarbearia)
        Me.Controls.Add(Me.pnlNotificacoes)
        Me.Controls.Add(Me.pnlUsuario)
        Me.Controls.Add(Me.pnlAbas)
        Me.Name = "ucConfiguracoes"
        Me.Size = New System.Drawing.Size(780, 620)
        Me.pnlAbas.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlAbas As Panel
    Friend WithEvents btnTabBarbearia As Button
    Friend WithEvents btnTabUsuario As Button
    Friend WithEvents btnTabNotificacoes As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlNotificacoes As Panel
    Friend WithEvents pnlUsuario As Panel
    Friend WithEvents pnlBarbearia As Panel
End Class
