<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAgendamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAgendamentos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAgendar = New System.Windows.Forms.ToolStripButton()
        Me.btnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.pnlTopo = New System.Windows.Forms.Panel()
        Me.nudDesconto = New System.Windows.Forms.NumericUpDown()
        Me.lblDesconto = New System.Windows.Forms.Label()
        Me.lblDataHora = New System.Windows.Forms.Label()
        Me.dtpFiltroData = New System.Windows.Forms.DateTimePicker()
        Me.lblServico = New System.Windows.Forms.Label()
        Me.lblProfissional = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.cboServico = New System.Windows.Forms.ComboBox()
        Me.cboProfissional = New System.Windows.Forms.ComboBox()
        Me.dgvAgendamentos = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profissional = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Servico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HorarioFim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlTopo.SuspendLayout()
        CType(Me.nudDesconto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAgendamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.ToolStripSeparator1, Me.btnAgendar, Me.btnFiltrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(780, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalvar
        '
        Me.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalvar.Image = Global.Barbex.My.Resources.Resources.salvar
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(23, 22)
        Me.btnSalvar.Text = "Salvar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAgendar
        '
        Me.btnAgendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAgendar.Image = CType(resources.GetObject("btnAgendar.Image"), System.Drawing.Image)
        Me.btnAgendar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAgendar.Name = "btnAgendar"
        Me.btnAgendar.Size = New System.Drawing.Size(56, 22)
        Me.btnAgendar.Text = "Agendar"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(41, 22)
        Me.btnFiltrar.Text = "Filtrar"
        '
        'pnlTopo
        '
        Me.pnlTopo.Controls.Add(Me.nudDesconto)
        Me.pnlTopo.Controls.Add(Me.lblDesconto)
        Me.pnlTopo.Controls.Add(Me.lblDataHora)
        Me.pnlTopo.Controls.Add(Me.dtpFiltroData)
        Me.pnlTopo.Controls.Add(Me.lblServico)
        Me.pnlTopo.Controls.Add(Me.lblProfissional)
        Me.pnlTopo.Controls.Add(Me.lblCliente)
        Me.pnlTopo.Controls.Add(Me.cboCliente)
        Me.pnlTopo.Controls.Add(Me.cboServico)
        Me.pnlTopo.Controls.Add(Me.cboProfissional)
        Me.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopo.Location = New System.Drawing.Point(0, 25)
        Me.pnlTopo.Name = "pnlTopo"
        Me.pnlTopo.Size = New System.Drawing.Size(780, 170)
        Me.pnlTopo.TabIndex = 2
        '
        'nudDesconto
        '
        Me.nudDesconto.Location = New System.Drawing.Point(239, 127)
        Me.nudDesconto.Name = "nudDesconto"
        Me.nudDesconto.Size = New System.Drawing.Size(67, 20)
        Me.nudDesconto.TabIndex = 13
        '
        'lblDesconto
        '
        Me.lblDesconto.AutoSize = True
        Me.lblDesconto.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDesconto.Location = New System.Drawing.Point(236, 98)
        Me.lblDesconto.Name = "lblDesconto"
        Me.lblDesconto.Size = New System.Drawing.Size(70, 13)
        Me.lblDesconto.TabIndex = 12
        Me.lblDesconto.Text = "Desconto (%)"
        '
        'lblDataHora
        '
        Me.lblDataHora.AutoSize = True
        Me.lblDataHora.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDataHora.Location = New System.Drawing.Point(17, 98)
        Me.lblDataHora.Name = "lblDataHora"
        Me.lblDataHora.Size = New System.Drawing.Size(58, 13)
        Me.lblDataHora.TabIndex = 11
        Me.lblDataHora.Text = "Data/Hora"
        '
        'dtpFiltroData
        '
        Me.dtpFiltroData.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFiltroData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFiltroData.Location = New System.Drawing.Point(19, 127)
        Me.dtpFiltroData.Name = "dtpFiltroData"
        Me.dtpFiltroData.Size = New System.Drawing.Size(200, 20)
        Me.dtpFiltroData.TabIndex = 10
        '
        'lblServico
        '
        Me.lblServico.AutoSize = True
        Me.lblServico.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblServico.Location = New System.Drawing.Point(453, 27)
        Me.lblServico.Name = "lblServico"
        Me.lblServico.Size = New System.Drawing.Size(43, 13)
        Me.lblServico.TabIndex = 9
        Me.lblServico.Text = "Serviço"
        '
        'lblProfissional
        '
        Me.lblProfissional.AutoSize = True
        Me.lblProfissional.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblProfissional.Location = New System.Drawing.Point(236, 27)
        Me.lblProfissional.Name = "lblProfissional"
        Me.lblProfissional.Size = New System.Drawing.Size(60, 13)
        Me.lblProfissional.TabIndex = 8
        Me.lblProfissional.Text = "Profissional"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblCliente.Location = New System.Drawing.Point(16, 27)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Cliente"
        '
        'cboCliente
        '
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(20, 53)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(199, 21)
        Me.cboCliente.TabIndex = 6
        '
        'cboServico
        '
        Me.cboServico.FormattingEnabled = True
        Me.cboServico.Location = New System.Drawing.Point(456, 53)
        Me.cboServico.Name = "cboServico"
        Me.cboServico.Size = New System.Drawing.Size(199, 21)
        Me.cboServico.TabIndex = 5
        '
        'cboProfissional
        '
        Me.cboProfissional.FormattingEnabled = True
        Me.cboProfissional.Location = New System.Drawing.Point(239, 53)
        Me.cboProfissional.Name = "cboProfissional"
        Me.cboProfissional.Size = New System.Drawing.Size(199, 21)
        Me.cboProfissional.TabIndex = 4
        '
        'dgvAgendamentos
        '
        Me.dgvAgendamentos.AllowUserToAddRows = False
        Me.dgvAgendamentos.AllowUserToDeleteRows = False
        Me.dgvAgendamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAgendamentos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.dgvAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgendamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Cliente, Me.Profissional, Me.Servico, Me.DataHora, Me.Status, Me.HorarioFim})
        Me.dgvAgendamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAgendamentos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvAgendamentos.Location = New System.Drawing.Point(0, 195)
        Me.dgvAgendamentos.Name = "dgvAgendamentos"
        Me.dgvAgendamentos.ReadOnly = True
        Me.dgvAgendamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAgendamentos.Size = New System.Drawing.Size(780, 505)
        Me.dgvAgendamentos.TabIndex = 3
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Profissional
        '
        Me.Profissional.DataPropertyName = "Profissional"
        Me.Profissional.HeaderText = "Profissional"
        Me.Profissional.Name = "Profissional"
        Me.Profissional.ReadOnly = True
        '
        'Servico
        '
        Me.Servico.DataPropertyName = "Servico"
        Me.Servico.HeaderText = "Serviço"
        Me.Servico.Name = "Servico"
        Me.Servico.ReadOnly = True
        '
        'DataHora
        '
        Me.DataHora.DataPropertyName = "DataHora"
        Me.DataHora.HeaderText = "DataHora"
        Me.DataHora.Name = "DataHora"
        Me.DataHora.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'HorarioFim
        '
        Me.HorarioFim.DataPropertyName = "HorarioFim"
        Me.HorarioFim.HeaderText = "HorarioFim"
        Me.HorarioFim.Name = "HorarioFim"
        Me.HorarioFim.ReadOnly = True
        '
        'ucAgendamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Controls.Add(Me.dgvAgendamentos)
        Me.Controls.Add(Me.pnlTopo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "ucAgendamentos"
        Me.Size = New System.Drawing.Size(780, 700)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlTopo.ResumeLayout(False)
        Me.pnlTopo.PerformLayout()
        CType(Me.nudDesconto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAgendamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents pnlTopo As Panel
    Friend WithEvents lblCliente As Label
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents cboServico As ComboBox
    Friend WithEvents cboProfissional As ComboBox
    Friend WithEvents dtpFiltroData As DateTimePicker
    Friend WithEvents lblServico As Label
    Friend WithEvents lblProfissional As Label
    Friend WithEvents dgvAgendamentos As DataGridView
    Friend WithEvents lblDataHora As Label
    Friend WithEvents nudDesconto As NumericUpDown
    Friend WithEvents lblDesconto As Label
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Profissional As DataGridViewTextBoxColumn
    Friend WithEvents Servico As DataGridViewTextBoxColumn
    Friend WithEvents DataHora As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents HorarioFim As DataGridViewTextBoxColumn
    Friend WithEvents btnAgendar As ToolStripButton
    Friend WithEvents btnFiltrar As ToolStripButton
End Class
