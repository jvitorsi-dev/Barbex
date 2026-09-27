<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAgendamentos = New System.Windows.Forms.Button()
        Me.btnProfissionais = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnConfiguracoes = New System.Windows.Forms.Button()
        Me.btnServicos = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlsidebar = New System.Windows.Forms.Panel()
        Me.pnlConteudo = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlsidebar.SuspendLayout()
        Me.SuspendLayout()
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1384, 86)
        Me.Panel2.TabIndex = 1
        Me.btnAgendamentos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAgendamentos.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAgendamentos.Location = New System.Drawing.Point(12, 23)
        Me.btnAgendamentos.Name = "btnAgendamentos"
        Me.btnAgendamentos.Size = New System.Drawing.Size(191, 39)
        Me.btnAgendamentos.TabIndex = 1
        Me.btnAgendamentos.Text = "Agendamentos"
        Me.btnAgendamentos.UseVisualStyleBackColor = True
        Me.btnProfissionais.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnProfissionais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnProfissionais.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProfissionais.ForeColor = System.Drawing.Color.Transparent
        Me.btnProfissionais.Location = New System.Drawing.Point(12, 113)
        Me.btnProfissionais.Name = "btnProfissionais"
        Me.btnProfissionais.Size = New System.Drawing.Size(191, 39)
        Me.btnProfissionais.TabIndex = 3
        Me.btnProfissionais.Text = "Profissionais"
        Me.btnProfissionais.UseVisualStyleBackColor = False
        Me.btnClientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClientes.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClientes.Image = CType(resources.GetObject("btnClientes.Image"), System.Drawing.Image)
        Me.btnClientes.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnClientes.Location = New System.Drawing.Point(12, 68)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(191, 39)
        Me.btnClientes.TabIndex = 2
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = False
        Me.btnConfiguracoes.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnConfiguracoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfiguracoes.ForeColor = System.Drawing.Color.Transparent
        Me.btnConfiguracoes.Location = New System.Drawing.Point(12, 203)
        Me.btnConfiguracoes.Name = "btnConfiguracoes"
        Me.btnConfiguracoes.Size = New System.Drawing.Size(191, 39)
        Me.btnConfiguracoes.TabIndex = 4
        Me.btnConfiguracoes.Text = "Configurações"
        Me.btnConfiguracoes.UseVisualStyleBackColor = False
        Me.btnServicos.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnServicos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnServicos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnServicos.ForeColor = System.Drawing.Color.Transparent
        Me.btnServicos.Location = New System.Drawing.Point(12, 158)
        Me.btnServicos.Name = "btnServicos"
        Me.btnServicos.Size = New System.Drawing.Size(191, 39)
        Me.btnServicos.TabIndex = 5
        Me.btnServicos.Text = "Serviços"
        Me.btnServicos.UseVisualStyleBackColor = False
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(212, 86)
        Me.Panel1.TabIndex = 1
        Me.Panel3.Location = New System.Drawing.Point(220, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1164, 815)
        Me.Panel3.TabIndex = 2
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(88, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 37)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Barbex"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(23, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 47)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        Me.pnlsidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.pnlsidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlsidebar.Controls.Add(Me.btnServicos)
        Me.pnlsidebar.Controls.Add(Me.btnConfiguracoes)
        Me.pnlsidebar.Controls.Add(Me.btnClientes)
        Me.pnlsidebar.Controls.Add(Me.btnProfissionais)
        Me.pnlsidebar.Controls.Add(Me.btnAgendamentos)
        Me.pnlsidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlsidebar.Location = New System.Drawing.Point(0, 86)
        Me.pnlsidebar.Name = "pnlsidebar"
        Me.pnlsidebar.Size = New System.Drawing.Size(212, 730)
        Me.pnlsidebar.TabIndex = 0
        Me.pnlConteudo.Location = New System.Drawing.Point(210, 86)
        Me.pnlConteudo.Name = "pnlConteudo"
        Me.pnlConteudo.Size = New System.Drawing.Size(1174, 730)
        Me.pnlConteudo.TabIndex = 2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.Controls.Add(Me.pnlsidebar)
        Me.Controls.Add(Me.pnlConteudo)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Dashboard"
        Me.Size = New System.Drawing.Size(1384, 816)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlsidebar.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAgendamentos As Button
    Friend WithEvents btnProfissionais As Button
    Friend WithEvents btnClientes As Button
    Friend WithEvents btnConfiguracoes As Button
    Friend WithEvents btnServicos As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlsidebar As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlConteudo As Panel
End Class
