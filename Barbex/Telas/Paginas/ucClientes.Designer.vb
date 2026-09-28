<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCLientes
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvCLientes = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTelefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.lblTelefone = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.pnlTopo = New System.Windows.Forms.Panel()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblBuscarpor = New System.Windows.Forms.ToolStripLabel()
        Me.cboCampoBusca = New System.Windows.Forms.ToolStripComboBox()
        Me.txtBusca = New System.Windows.Forms.ToolStripTextBox()
        Me.btnRemover = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.txtTelefone = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.ofdFoto = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dgvCLientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopo.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCLientes
        '
        Me.dgvCLientes.AllowUserToAddRows = False
        Me.dgvCLientes.AllowUserToDeleteRows = False
        Me.dgvCLientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCLientes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.dgvCLientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCLientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNome, Me.colTelefone, Me.colEmail})
        Me.dgvCLientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCLientes.Location = New System.Drawing.Point(0, 155)
        Me.dgvCLientes.MultiSelect = False
        Me.dgvCLientes.Name = "dgvCLientes"
        Me.dgvCLientes.ReadOnly = True
        Me.dgvCLientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCLientes.Size = New System.Drawing.Size(780, 545)
        Me.dgvCLientes.TabIndex = 0
        '
        'colId
        '
        Me.colId.DataPropertyName = "Id"
        Me.colId.HeaderText = "Id"
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
        'colTelefone
        '
        Me.colTelefone.DataPropertyName = "Telefone"
        Me.colTelefone.HeaderText = "Telefone"
        Me.colTelefone.Name = "colTelefone"
        Me.colTelefone.ReadOnly = True
        '
        'colEmail
        '
        Me.colEmail.DataPropertyName = "Email"
        Me.colEmail.HeaderText = "Email"
        Me.colEmail.Name = "colEmail"
        Me.colEmail.ReadOnly = True
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblNome.Location = New System.Drawing.Point(17, 44)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(35, 13)
        Me.lblNome.TabIndex = 16
        Me.lblNome.Text = "Nome"
        '
        'lblTelefone
        '
        Me.lblTelefone.AutoSize = True
        Me.lblTelefone.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTelefone.Location = New System.Drawing.Point(237, 44)
        Me.lblTelefone.Name = "lblTelefone"
        Me.lblTelefone.Size = New System.Drawing.Size(49, 13)
        Me.lblTelefone.TabIndex = 17
        Me.lblTelefone.Text = "Telefone"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblEmail.Location = New System.Drawing.Point(454, 44)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(86, 13)
        Me.lblEmail.TabIndex = 18
        Me.lblEmail.Text = "E-mail (Opcional)"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlTopo
        '
        Me.pnlTopo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.pnlTopo.Controls.Add(Me.picFoto)
        Me.pnlTopo.Controls.Add(Me.ToolStrip1)
        Me.pnlTopo.Controls.Add(Me.btnRemover)
        Me.pnlTopo.Controls.Add(Me.btnNovo)
        Me.pnlTopo.Controls.Add(Me.txtTelefone)
        Me.pnlTopo.Controls.Add(Me.txtEmail)
        Me.pnlTopo.Controls.Add(Me.txtNome)
        Me.pnlTopo.Controls.Add(Me.lblEmail)
        Me.pnlTopo.Controls.Add(Me.lblTelefone)
        Me.pnlTopo.Controls.Add(Me.lblNome)
        Me.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopo.Name = "pnlTopo"
        Me.pnlTopo.Size = New System.Drawing.Size(780, 155)
        Me.pnlTopo.TabIndex = 1
        '
        'picFoto
        '
        Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picFoto.Location = New System.Drawing.Point(677, 44)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(100, 94)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFoto.TabIndex = 25
        Me.picFoto.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.ToolStripSeparator1, Me.lblBuscarpor, Me.cboCampoBusca, Me.txtBusca})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(780, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalvar
        '
        Me.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalvar.Image = Global.Barbex.My.Resources.Resources.salvar
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(23, 22)
        Me.btnSalvar.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblBuscarpor
        '
        Me.lblBuscarpor.Name = "lblBuscarpor"
        Me.lblBuscarpor.Size = New System.Drawing.Size(66, 22)
        Me.lblBuscarpor.Text = "Buscar por:"
        '
        'cboCampoBusca
        '
        Me.cboCampoBusca.Items.AddRange(New Object() {"Nome", "Telefone", "E-mail"})
        Me.cboCampoBusca.Name = "cboCampoBusca"
        Me.cboCampoBusca.Size = New System.Drawing.Size(121, 25)
        '
        'txtBusca
        '
        Me.txtBusca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(100, 25)
        '
        'btnRemover
        '
        Me.btnRemover.BackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemover.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRemover.Location = New System.Drawing.Point(144, 115)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(75, 23)
        Me.btnRemover.TabIndex = 23
        Me.btnRemover.Text = "Remover"
        Me.btnRemover.UseVisualStyleBackColor = False
        '
        'btnNovo
        '
        Me.btnNovo.BackColor = System.Drawing.Color.Black
        Me.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNovo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNovo.Location = New System.Drawing.Point(20, 115)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(82, 23)
        Me.btnNovo.TabIndex = 22
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = False
        '
        'txtTelefone
        '
        Me.txtTelefone.Location = New System.Drawing.Point(240, 73)
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(199, 20)
        Me.txtTelefone.TabIndex = 21
        Me.txtTelefone.Text = "(  )     -    "
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(457, 73)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(199, 20)
        Me.txtEmail.TabIndex = 20
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(20, 73)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(199, 20)
        Me.txtNome.TabIndex = 19
        '
        'ofdFoto
        '
        Me.ofdFoto.Filter = "Imagens (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
        Me.ofdFoto.Title = "Selecione uma foto"
        '
        'ucCLientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Controls.Add(Me.dgvCLientes)
        Me.Controls.Add(Me.pnlTopo)
        Me.Name = "ucCLientes"
        Me.Size = New System.Drawing.Size(780, 700)
        CType(Me.dgvCLientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopo.ResumeLayout(False)
        Me.pnlTopo.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCLientes As DataGridView
    Friend WithEvents lblNome As Label
    Friend WithEvents lblTelefone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents pnlTopo As Panel
    Friend WithEvents btnRemover As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents txtTelefone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNome As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lblBuscarpor As ToolStripLabel
    Friend WithEvents cboCampoBusca As ToolStripComboBox
    Friend WithEvents txtBusca As ToolStripTextBox
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colNome As DataGridViewTextBoxColumn
    Friend WithEvents colTelefone As DataGridViewTextBoxColumn
    Friend WithEvents colEmail As DataGridViewTextBoxColumn
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents ofdFoto As OpenFileDialog
End Class
