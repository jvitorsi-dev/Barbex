<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucProfissionais
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvProfissionais = New System.Windows.Forms.DataGridView()
        Me.colid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEspecialidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAtivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlTopo = New System.Windows.Forms.Panel()
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblBuscarPor = New System.Windows.Forms.ToolStripLabel()
        Me.cboCampoBusca = New System.Windows.Forms.ToolStripComboBox()
        Me.txtBusca = New System.Windows.Forms.ToolStripTextBox()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.nudComissao = New System.Windows.Forms.NumericUpDown()
        Me.btnRemover = New System.Windows.Forms.Button()
        Me.txtEspecialidade = New System.Windows.Forms.TextBox()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.lblEspecialidade = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.lblComissao = New System.Windows.Forms.Label()
        CType(Me.dgvProfissionais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopo.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.nudComissao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProfissionais
        '
        Me.dgvProfissionais.AllowUserToAddRows = False
        Me.dgvProfissionais.AllowUserToDeleteRows = False
        Me.dgvProfissionais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProfissionais.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.dgvProfissionais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProfissionais.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colid, Me.colNome, Me.colEspecialidade, Me.colComissao, Me.colAtivo})
        Me.dgvProfissionais.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProfissionais.Location = New System.Drawing.Point(0, 155)
        Me.dgvProfissionais.MultiSelect = False
        Me.dgvProfissionais.Name = "dgvProfissionais"
        Me.dgvProfissionais.ReadOnly = True
        Me.dgvProfissionais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProfissionais.Size = New System.Drawing.Size(780, 545)
        Me.dgvProfissionais.TabIndex = 0
        '
        'colid
        '
        Me.colid.DataPropertyName = "Id"
        Me.colid.HeaderText = "Id"
        Me.colid.Name = "colid"
        Me.colid.ReadOnly = True
        '
        'colNome
        '
        Me.colNome.DataPropertyName = "Nome"
        Me.colNome.HeaderText = "Nome"
        Me.colNome.Name = "colNome"
        Me.colNome.ReadOnly = True
        '
        'colEspecialidade
        '
        Me.colEspecialidade.DataPropertyName = "Especialidade"
        Me.colEspecialidade.HeaderText = "Especialidade"
        Me.colEspecialidade.Name = "colEspecialidade"
        Me.colEspecialidade.ReadOnly = True
        '
        'colComissao
        '
        Me.colComissao.DataPropertyName = "PercentualComissao"
        Me.colComissao.HeaderText = "Comissão (%)"
        Me.colComissao.Name = "colComissao"
        Me.colComissao.ReadOnly = True
        '
        'colAtivo
        '
        Me.colAtivo.DataPropertyName = "Ativo"
        Me.colAtivo.HeaderText = "Ativo"
        Me.colAtivo.Name = "colAtivo"
        Me.colAtivo.ReadOnly = True
        '
        'pnlTopo
        '
        Me.pnlTopo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.pnlTopo.Controls.Add(Me.chkAtivo)
        Me.pnlTopo.Controls.Add(Me.ToolStrip1)
        Me.pnlTopo.Controls.Add(Me.nudComissao)
        Me.pnlTopo.Controls.Add(Me.btnRemover)
        Me.pnlTopo.Controls.Add(Me.txtEspecialidade)
        Me.pnlTopo.Controls.Add(Me.btnNovo)
        Me.pnlTopo.Controls.Add(Me.lblNome)
        Me.pnlTopo.Controls.Add(Me.lblEspecialidade)
        Me.pnlTopo.Controls.Add(Me.txtNome)
        Me.pnlTopo.Controls.Add(Me.lblComissao)
        Me.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopo.Name = "pnlTopo"
        Me.pnlTopo.Size = New System.Drawing.Size(780, 155)
        Me.pnlTopo.TabIndex = 1
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Checked = True
        Me.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAtivo.Location = New System.Drawing.Point(579, 70)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 17)
        Me.chkAtivo.TabIndex = 33
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.ToolStripSeparator1, Me.lblBuscarPor, Me.cboCampoBusca, Me.txtBusca, Me.btnBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(780, 25)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalvar
        '
        Me.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalvar.Image = Global.Barbex.My.Resources.Resources.salvar
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(23, 22)
        Me.btnSalvar.Text = "btnSalvar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblBuscarPor
        '
        Me.lblBuscarPor.Name = "lblBuscarPor"
        Me.lblBuscarPor.Size = New System.Drawing.Size(66, 22)
        Me.lblBuscarPor.Text = "Buscar por:"
        '
        'cboCampoBusca
        '
        Me.cboCampoBusca.Name = "cboCampoBusca"
        Me.cboCampoBusca.Size = New System.Drawing.Size(121, 25)
        '
        'txtBusca
        '
        Me.txtBusca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(100, 25)
        '
        'btnBuscar
        '
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(45, 22)
        Me.btnBuscar.Text = "Buscar"
        '
        'nudComissao
        '
        Me.nudComissao.DecimalPlaces = 2
        Me.nudComissao.Location = New System.Drawing.Point(461, 67)
        Me.nudComissao.Name = "nudComissao"
        Me.nudComissao.Size = New System.Drawing.Size(83, 20)
        Me.nudComissao.TabIndex = 31
        '
        'btnRemover
        '
        Me.btnRemover.BackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemover.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRemover.Location = New System.Drawing.Point(142, 110)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(75, 23)
        Me.btnRemover.TabIndex = 30
        Me.btnRemover.Text = "Remover"
        Me.btnRemover.UseVisualStyleBackColor = False
        '
        'txtEspecialidade
        '
        Me.txtEspecialidade.Location = New System.Drawing.Point(244, 67)
        Me.txtEspecialidade.Name = "txtEspecialidade"
        Me.txtEspecialidade.Size = New System.Drawing.Size(178, 20)
        Me.txtEspecialidade.TabIndex = 28
        '
        'btnNovo
        '
        Me.btnNovo.BackColor = System.Drawing.Color.Black
        Me.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNovo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNovo.Location = New System.Drawing.Point(24, 110)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(82, 23)
        Me.btnNovo.TabIndex = 29
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = False
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblNome.Location = New System.Drawing.Point(21, 38)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(35, 13)
        Me.lblNome.TabIndex = 24
        Me.lblNome.Text = "Nome"
        '
        'lblEspecialidade
        '
        Me.lblEspecialidade.AutoSize = True
        Me.lblEspecialidade.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblEspecialidade.Location = New System.Drawing.Point(241, 38)
        Me.lblEspecialidade.Name = "lblEspecialidade"
        Me.lblEspecialidade.Size = New System.Drawing.Size(73, 13)
        Me.lblEspecialidade.TabIndex = 25
        Me.lblEspecialidade.Text = "Especialidade"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(24, 67)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(193, 20)
        Me.txtNome.TabIndex = 27
        '
        'lblComissao
        '
        Me.lblComissao.AutoSize = True
        Me.lblComissao.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblComissao.Location = New System.Drawing.Point(458, 38)
        Me.lblComissao.Name = "lblComissao"
        Me.lblComissao.Size = New System.Drawing.Size(52, 13)
        Me.lblComissao.TabIndex = 26
        Me.lblComissao.Text = "Comissão"
        Me.lblComissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucProfissionais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Controls.Add(Me.dgvProfissionais)
        Me.Controls.Add(Me.pnlTopo)
        Me.Name = "ucProfissionais"
        Me.Size = New System.Drawing.Size(780, 700)
        CType(Me.dgvProfissionais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopo.ResumeLayout(False)
        Me.pnlTopo.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.nudComissao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvProfissionais As DataGridView
    Friend WithEvents pnlTopo As Panel
    Friend WithEvents btnRemover As Button
    Friend WithEvents txtEspecialidade As TextBox
    Friend WithEvents btnNovo As Button
    Friend WithEvents lblNome As Label
    Friend WithEvents lblEspecialidade As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents lblComissao As Label
    Friend WithEvents nudComissao As NumericUpDown
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lblBuscarPor As ToolStripLabel
    Friend WithEvents cboCampoBusca As ToolStripComboBox
    Friend WithEvents txtBusca As ToolStripTextBox
    Friend WithEvents btnBuscar As ToolStripButton
    Friend WithEvents colid As DataGridViewTextBoxColumn
    Friend WithEvents colNome As DataGridViewTextBoxColumn
    Friend WithEvents colEspecialidade As DataGridViewTextBoxColumn
    Friend WithEvents colComissao As DataGridViewTextBoxColumn
    Friend WithEvents colAtivo As DataGridViewTextBoxColumn
    Friend WithEvents chkAtivo As CheckBox
End Class
