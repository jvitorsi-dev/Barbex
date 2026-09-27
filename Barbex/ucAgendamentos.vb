Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

''' <summary>
''' Tela de Agendamentos: formulário para criar um novo agendamento + grid dos agendamentos do dia.
''' Consumida pelo Dashboard via:
'''   AbrirTela(New ucAgendamentos(), btnAgendamentos)
'''
''' Estrutura: UM único painel de topo (pnlTopo, Dock=Top) reunindo filtro + formulário,
''' adicionado a Me.Controls DEPOIS do grid (Dock=Fill) — mesma ordem que já validamos
''' funcionar corretamente no ucConfiguracoes (Fill primeiro, Top por último).
''' </summary>
Public Class ucAgendamentos
    Inherits UserControl

    ' ===================== CORES DO TEMA =====================
    Private ReadOnly corFundo As Color = Color.FromArgb(18, 18, 18)
    Private ReadOnly corCard As Color = Color.FromArgb(28, 28, 28)
    Private ReadOnly corTextoSecundario As Color = Color.Silver
    Private ReadOnly corDourado As Color = Color.FromArgb(212, 163, 82)

    ' ===================== NEGÓCIO =====================
    Private barbearia As New GerenciadorBarbearia()
    Private bsAgendamentos As New BindingSource()

    ' ===================== CONTROLES =====================
    Private pnlTopo As Panel
    Private WithEvents dtpFiltroData As DateTimePicker
    Private WithEvents btnFiltrar As Button

    Private cboCliente As ComboBox
    Private cboProfissional As ComboBox
    Private cboServico As ComboBox
    Private dtpDataHora As DateTimePicker
    Private nudDesconto As NumericUpDown
    Private WithEvents btnAgendar As Button

    Private dgvAgendamentos As DataGridView

    Private tt As New ToolTip()

    Private ReadOnly ALTURA_TOPO As Integer = 190

    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = corFundo

        ' 1) Grid primeiro (Dock=Fill) — igual ao padrão validado no ucConfiguracoes
        MontarGrid()

        ' 2) Painel de topo por último (Dock=Top) — fica por cima/reserva espaço corretamente
        MontarTopo()

        AddHandler Me.Load, AddressOf ucAgendamentos_Load
    End Sub

    Private Sub ucAgendamentos_Load(sender As Object, e As EventArgs)
        CarregarCombos()
        AtualizarGrid()
    End Sub

    ' ===================== TOPO: FILTRO + FORMULÁRIO EM UM SÓ PAINEL =====================
    Private Sub MontarTopo()
        pnlTopo = New Panel With {.Dock = DockStyle.Top, .Height = ALTURA_TOPO, .BackColor = corCard, .Padding = New Padding(20, 15, 20, 10)}

        ' --- Linha 1: Cliente / Profissional / Serviço ---
        Dim lblCliente As New Label With {.Text = "Cliente", .ForeColor = corTextoSecundario, .Top = 15, .Left = 20, .AutoSize = True}
        cboCliente = New ComboBox With {.Top = 35, .Left = 20, .Width = 200, .DropDownStyle = ComboBoxStyle.DropDownList}

        Dim lblProfissional As New Label With {.Text = "Profissional", .ForeColor = corTextoSecundario, .Top = 15, .Left = 240, .AutoSize = True}
        cboProfissional = New ComboBox With {.Top = 35, .Left = 240, .Width = 200, .DropDownStyle = ComboBoxStyle.DropDownList}

        Dim lblServico As New Label With {.Text = "Serviço", .ForeColor = corTextoSecundario, .Top = 15, .Left = 460, .AutoSize = True}
        cboServico = New ComboBox With {.Top = 35, .Left = 460, .Width = 200, .DropDownStyle = ComboBoxStyle.DropDownList}

        ' --- Linha 2: Data/Hora / Desconto / Agendar ---
        Dim lblDataHora As New Label With {.Text = "Data/Hora", .ForeColor = corTextoSecundario, .Top = 75, .Left = 20, .AutoSize = True}
        dtpDataHora = New DateTimePicker With {.Top = 95, .Left = 20, .Width = 200, .Format = DateTimePickerFormat.Custom, .CustomFormat = "dd/MM/yyyy HH:mm"}

        Dim lblDesconto As New Label With {.Text = "Desconto (%)", .ForeColor = corTextoSecundario, .Top = 75, .Left = 240, .AutoSize = True}
        nudDesconto = New NumericUpDown With {.Top = 95, .Left = 240, .Width = 100, .Minimum = 0, .Maximum = 100, .DecimalPlaces = 0}

        btnAgendar = New Button With {.Text = "Agendar", .Top = 93, .Left = 460, .Width = 150, .Height = 32, .BackColor = corDourado, .FlatStyle = FlatStyle.Flat}
        btnAgendar.FlatAppearance.BorderSize = 0

        ' --- Linha 3: filtro de data do grid ---
        Dim lblFiltroData As New Label With {.Text = "Ver agendamentos de:", .ForeColor = corTextoSecundario, .Top = 145, .Left = 20, .AutoSize = True}
        dtpFiltroData = New DateTimePicker With {.Top = 143, .Left = 170, .Width = 130, .Format = DateTimePickerFormat.Short, .Value = DateTime.Today}
        btnFiltrar = New Button With {.Text = "Filtrar", .Top = 141, .Left = 310, .Width = 90, .Height = 26, .FlatStyle = FlatStyle.Flat, .BackColor = corFundo, .ForeColor = Color.White}
        btnFiltrar.FlatAppearance.BorderColor = Color.DimGray

        tt.SetToolTip(nudDesconto, "Desconto aplicado somente a este agendamento")

        pnlTopo.Controls.AddRange({lblCliente, cboCliente, lblProfissional, cboProfissional, lblServico, cboServico,
                                    lblDataHora, dtpDataHora, lblDesconto, nudDesconto, btnAgendar,
                                    lblFiltroData, dtpFiltroData, btnFiltrar})
        Me.Controls.Add(pnlTopo)
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        AtualizarGrid()
    End Sub

    Private Sub CarregarCombos()
        Try
            cboProfissional.DataSource = barbearia.ListarProfissionais().ToList()
            cboCliente.DataSource = barbearia.ListarClientes().ToList()
            cboServico.DataSource = barbearia.ListarServicos().ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar combos: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgendar_Click(sender As Object, e As EventArgs) Handles btnAgendar.Click
        Try
            If cboCliente.SelectedItem Is Nothing OrElse cboProfissional.SelectedItem Is Nothing OrElse cboServico.SelectedItem Is Nothing Then
                MessageBox.Show("Selecione cliente, profissional e serviço.", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim ag As New AgendamentoComDesconto(0,
                DirectCast(cboCliente.SelectedItem, Cliente),
                DirectCast(cboProfissional.SelectedItem, Profissional),
                DirectCast(cboServico.SelectedItem, Servico),
                dtpDataHora.Value,
                nudDesconto.Value)

            barbearia.Agendar(ag)
            MessageBox.Show("Agendado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As HorarioOcupadoException
            MessageBox.Show(ex.Message, "Horário indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As BarbexException
            MessageBox.Show(ex.Message, "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            AtualizarGrid()
        End Try
    End Sub

    ' ===================== GRID =====================
    Private Sub MontarGrid()
        dgvAgendamentos = New DataGridView With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = corFundo,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        Me.Controls.Add(dgvAgendamentos)
        dgvAgendamentos.DataSource = bsAgendamentos
    End Sub

    Private Sub AtualizarGrid()
        Try
            bsAgendamentos.DataSource = barbearia.ListarAgendamentos(dtpFiltroData.Value).ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar agendamentos: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
