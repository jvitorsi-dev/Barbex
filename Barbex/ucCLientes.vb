Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

''' <summary>
''' Tela de Clientes: formulário de cadastro/edição + grid de clientes.
''' Consumida pelo Dashboard via:
'''   AbrirTela(New ucCLientes(), btnClientes)
'''
''' Mesma estrutura validada em ucAgendamentos: grid (Dock=Fill) montado
''' PRIMEIRO e adicionado a Me.Controls, painel de formulário (Dock=Top)
''' montado e adicionado POR ÚLTIMO.
'''
''' Fluxo de edição: clicar numa linha do grid carrega os dados no formulário
''' (idAtual passa a ser o Id daquele cliente). Botão "Novo" limpa o formulário
''' e zera idAtual, voltando ao modo de cadastro (Id = 0 → gera automaticamente).
''' </summary>
Public Class ucCLientes
    Inherits UserControl

    ' ===================== CORES DO TEMA =====================
    Private ReadOnly corFundo As Color = Color.FromArgb(18, 18, 18)
    Private ReadOnly corCard As Color = Color.FromArgb(28, 28, 28)
    Private ReadOnly corTextoSecundario As Color = Color.Silver
    Private ReadOnly corDourado As Color = Color.FromArgb(212, 163, 82)

    ' ===================== NEGÓCIO =====================
    Private barbearia As New GerenciadorBarbearia()
    Private bsClientes As New BindingSource()
    Private idAtual As Integer = 0

    ' ===================== CONTROLES =====================
    Private pnlTopo As Panel
    Private txtNome As TextBox
    Private txtTelefone As TextBox
    Private txtEmail As TextBox
    Private WithEvents btnSalvar As Button
    Private WithEvents btnNovo As Button
    Private WithEvents btnRemover As Button

    Private WithEvents dgvClientes As DataGridView

    Private tt As New ToolTip()

    Private ReadOnly ALTURA_TOPO As Integer = 130

    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = corFundo

        ' 1) Grid primeiro (Dock=Fill)
        MontarGrid()

        ' 2) Painel de formulário por último (Dock=Top)
        MontarTopo()

        AddHandler Me.Load, AddressOf ucCLientes_Load
    End Sub

    Private Sub ucCLientes_Load(sender As Object, e As EventArgs)
        AtualizarGrid()
    End Sub

    ' ===================== TOPO: FORMULÁRIO =====================
    Private Sub MontarTopo()
        pnlTopo = New Panel With {.Dock = DockStyle.Top, .Height = ALTURA_TOPO, .BackColor = corCard, .Padding = New Padding(20, 15, 20, 10)}

        Dim lblNome As New Label With {.Text = "Nome", .ForeColor = corTextoSecundario, .Top = 15, .Left = 20, .AutoSize = True}
        txtNome = New TextBox With {.Top = 35, .Left = 20, .Width = 220}

        Dim lblTelefone As New Label With {.Text = "Telefone", .ForeColor = corTextoSecundario, .Top = 15, .Left = 260, .AutoSize = True}
        txtTelefone = New TextBox With {.Top = 35, .Left = 260, .Width = 160}

        Dim lblEmail As New Label With {.Text = "E-mail (opcional)", .ForeColor = corTextoSecundario, .Top = 15, .Left = 440, .AutoSize = True}
        txtEmail = New TextBox With {.Top = 35, .Left = 440, .Width = 220}

        btnSalvar = New Button With {.Text = "Salvar", .Top = 70, .Left = 20, .Width = 120, .Height = 32, .BackColor = corDourado, .FlatStyle = FlatStyle.Flat}
        btnSalvar.FlatAppearance.BorderSize = 0

        btnNovo = New Button With {.Text = "Novo", .Top = 70, .Left = 150, .Width = 100, .Height = 32, .FlatStyle = FlatStyle.Flat, .BackColor = corFundo, .ForeColor = Color.White}
        btnNovo.FlatAppearance.BorderColor = Color.DimGray

        btnRemover = New Button With {.Text = "Remover", .Top = 70, .Left = 260, .Width = 120, .Height = 32, .BackColor = Color.FromArgb(120, 40, 40), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat}
        btnRemover.FlatAppearance.BorderSize = 0

        tt.SetToolTip(txtTelefone, "Informe DDD + número (mínimo de 8 dígitos)")
        tt.SetToolTip(txtEmail, "Se informado, deve conter '@' e '.'")

        pnlTopo.Controls.AddRange({lblNome, txtNome, lblTelefone, txtTelefone, lblEmail, txtEmail,
                                    btnSalvar, btnNovo, btnRemover})
        Me.Controls.Add(pnlTopo)
    End Sub

    ' ===================== GRID =====================
    Private Sub MontarGrid()
        dgvClientes = New DataGridView With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = corFundo,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .AutoGenerateColumns = False,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Id", .HeaderText = "Id", .FillWeight = 40})
        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Nome", .HeaderText = "Nome", .FillWeight = 130})
        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Telefone", .HeaderText = "Telefone", .FillWeight = 100})
        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Email", .HeaderText = "E-mail", .FillWeight = 140})

        Me.Controls.Add(dgvClientes)
        dgvClientes.DataSource = bsClientes
    End Sub

    Private Sub dgvClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged
        If dgvClientes.CurrentRow Is Nothing OrElse dgvClientes.CurrentRow.DataBoundItem Is Nothing Then Return

        Dim cliente As Cliente = DirectCast(dgvClientes.CurrentRow.DataBoundItem, Cliente)
        idAtual = cliente.Id
        txtNome.Text = cliente.Nome
        txtTelefone.Text = cliente.Telefone
        txtEmail.Text = cliente.Email
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        LimparFormulario()
    End Sub

    Private Sub LimparFormulario()
        idAtual = 0
        txtNome.Clear()
        txtTelefone.Clear()
        txtEmail.Clear()
        dgvClientes.ClearSelection()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim cliente As New Cliente(idAtual, txtNome.Text, txtTelefone.Text, txtEmail.Text)

            If idAtual = 0 Then
                barbearia.CadastrarCliente(cliente)
                MessageBox.Show("Cliente cadastrado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                barbearia.AtualizarCliente(cliente)
                MessageBox.Show("Cliente atualizado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            LimparFormulario()

        Catch ex As BarbexException
            MessageBox.Show(ex.Message, "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Erro inesperado: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            AtualizarGrid()
        End Try
    End Sub

    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click
        If idAtual = 0 Then
            MessageBox.Show("Selecione um cliente na lista para remover.", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim resposta = MessageBox.Show("Deseja realmente remover este cliente?", "Confirmar remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resposta <> DialogResult.Yes Then Return

        Try
            barbearia.RemoverCliente(idAtual)
            LimparFormulario()
        Catch ex As BarbexException
            MessageBox.Show(ex.Message, "Erro ao remover", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Erro inesperado: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            AtualizarGrid()
        End Try
    End Sub

    Private Sub AtualizarGrid()
        Try
            bsClientes.DataSource = barbearia.ListarClientes().ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar clientes: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ucCLientes_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
