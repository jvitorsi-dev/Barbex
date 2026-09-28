<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucServicos
    Inherits System.Windows.Forms.UserControl

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvServicos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnRemover = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblBuscarPor = New System.Windows.Forms.ToolStripLabel()
        Me.cboCampoBusca = New System.Windows.Forms.ToolStripComboBox()
        Me.txtBusca = New System.Windows.Forms.ToolStripTextBox()
        Me.nudDuracao = New System.Windows.Forms.NumericUpDown()
        Me.lblDuracao = New System.Windows.Forms.Label()
        Me.nudPreco = New System.Windows.Forms.NumericUpDown()
        Me.lblPreco = New System.Windows.Forms.Label()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuracao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvServicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.nudDuracao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPreco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvServicos
        '
        Me.dgvServicos.AllowUserToAddRows = False
        Me.dgvServicos.AllowUserToDeleteRows = False
        Me.dgvServicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvServicos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.dgvServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNome, Me.colDescricao, Me.colPreco, Me.colDuracao})
        Me.dgvServicos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicos.Location = New System.Drawing.Point(0, 155)
        Me.dgvServicos.MultiSelect = False
        Me.dgvServicos.Name = "dgvServicos"
        Me.dgvServicos.ReadOnly = True
        Me.dgvServicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServicos.Size = New System.Drawing.Size(780, 545)
        Me.dgvServicos.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnNovo)
        Me.Panel1.Controls.Add(Me.btnRemover)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.nudDuracao)
        Me.Panel1.Controls.Add(Me.lblDuracao)
        Me.Panel1.Controls.Add(Me.nudPreco)
        Me.Panel1.Controls.Add(Me.lblPreco)
        Me.Panel1.Controls.Add(Me.txtDescricao)
        Me.Panel1.Controls.Add(Me.lblDescricao)
        Me.Panel1.Controls.Add(Me.txtNome)
        Me.Panel1.Controls.Add(Me.lblNome)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 155)
        Me.Panel1.TabIndex = 1
        '
        'btnNovo
        '
        Me.btnNovo.BackColor = System.Drawing.Color.Black
        Me.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNovo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNovo.Location = New System.Drawing.Point(20, 113)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(82, 23)
        Me.btnNovo.TabIndex = 32
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = False
        '
        'btnRemover
        '
        Me.btnRemover.BackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemover.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRemover.Location = New System.Drawing.Point(144, 113)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(75, 23)
        Me.btnRemover.TabIndex = 31
        Me.btnRemover.Text = "Remover"
        Me.btnRemover.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.ToolStripSeparator1, Me.lblBuscarPor, Me.cboCampoBusca, Me.txtBusca})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(780, 25)
        Me.ToolStrip1.TabIndex = 11
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
        Me.cboCampoBusca.Items.AddRange(New Object() {"Nome", "Descrição"})
        Me.cboCampoBusca.Name = "cboCampoBusca"
        Me.cboCampoBusca.Size = New System.Drawing.Size(121, 25)
        '
        'txtBusca
        '
        Me.txtBusca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(100, 25)
        '
        'nudDuracao
        '
        Me.nudDuracao.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.nudDuracao.Location = New System.Drawing.Point(561, 73)
        Me.nudDuracao.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.nudDuracao.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDuracao.Name = "nudDuracao"
        Me.nudDuracao.Size = New System.Drawing.Size(82, 20)
        Me.nudDuracao.TabIndex = 10
        Me.nudDuracao.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblDuracao
        '
        Me.lblDuracao.AutoSize = True
        Me.lblDuracao.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDuracao.Location = New System.Drawing.Point(558, 48)
        Me.lblDuracao.Name = "lblDuracao"
        Me.lblDuracao.Size = New System.Drawing.Size(48, 13)
        Me.lblDuracao.TabIndex = 9
        Me.lblDuracao.Text = "Duração"
        '
        'nudPreco
        '
        Me.nudPreco.DecimalPlaces = 2
        Me.nudPreco.Location = New System.Drawing.Point(453, 73)
        Me.nudPreco.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudPreco.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudPreco.Name = "nudPreco"
        Me.nudPreco.Size = New System.Drawing.Size(82, 20)
        Me.nudPreco.TabIndex = 8
        Me.nudPreco.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'lblPreco
        '
        Me.lblPreco.AutoSize = True
        Me.lblPreco.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblPreco.Location = New System.Drawing.Point(450, 48)
        Me.lblPreco.Name = "lblPreco"
        Me.lblPreco.Size = New System.Drawing.Size(58, 13)
        Me.lblPreco.TabIndex = 7
        Me.lblPreco.Text = "Preço (R$)"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(238, 73)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(199, 20)
        Me.txtDescricao.TabIndex = 5
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDescricao.Location = New System.Drawing.Point(235, 44)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(55, 13)
        Me.lblDescricao.TabIndex = 2
        Me.lblDescricao.Text = "Descrição"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(20, 73)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(199, 20)
        Me.txtNome.TabIndex = 1
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblNome.Location = New System.Drawing.Point(17, 44)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(35, 13)
        Me.lblNome.TabIndex = 0
        Me.lblNome.Text = "Nome"
        '
        'colId
        '
        Me.colId.DataPropertyName = "Id"
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        '
        'colNome
        '
        Me.colNome.DataPropertyName = "Nome"
        Me.colNome.HeaderText = "Nome"
        Me.colNome.Name = "colNome"
        Me.colNome.ReadOnly = True
        '
        'colDescricao
        '
        Me.colDescricao.DataPropertyName = "Descricao"
        Me.colDescricao.HeaderText = "Descrição"
        Me.colDescricao.Name = "colDescricao"
        Me.colDescricao.ReadOnly = True
        '
        'colPreco
        '
        Me.colPreco.DataPropertyName = "Preco"
        Me.colPreco.HeaderText = "Preço"
        Me.colPreco.Name = "colPreco"
        Me.colPreco.ReadOnly = True
        '
        'colDuracao
        '
        Me.colDuracao.DataPropertyName = "DuracaoMinutos"
        Me.colDuracao.HeaderText = "Duração"
        Me.colDuracao.Name = "colDuracao"
        Me.colDuracao.ReadOnly = True
        '
        'ucServicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Controls.Add(Me.dgvServicos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucServicos"
        Me.Size = New System.Drawing.Size(780, 700)
        CType(Me.dgvServicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.nudDuracao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPreco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvServicos As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtNome As TextBox
    Friend WithEvents lblNome As Label
    Friend WithEvents lblDescricao As Label
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents nudPreco As NumericUpDown
    Friend WithEvents lblPreco As Label
    Friend WithEvents lblDuracao As Label
    Friend WithEvents nudDuracao As NumericUpDown
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lblBuscarPor As ToolStripLabel
    Friend WithEvents cboCampoBusca As ToolStripComboBox
    Friend WithEvents btnRemover As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents txtBusca As ToolStripTextBox
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colNome As DataGridViewTextBoxColumn
    Friend WithEvents colDescricao As DataGridViewTextBoxColumn
    Friend WithEvents colPreco As DataGridViewTextBoxColumn
    Friend WithEvents colDuracao As DataGridViewTextBoxColumn
End Class
