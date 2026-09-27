Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

Public Class ucServicos
    Inherits UserControl

    Private ReadOnly corFundo As Color = Color.FromArgb(18, 18, 18)
    Private ReadOnly corCard As Color = Color.FromArgb(28, 28, 28)
    Private ReadOnly corTextoSecundario As Color = Color.Silver
    Private ReadOnly corDourado As Color = Color.FromArgb(212, 163, 82)

    Private barbearia As New GerenciadorBarbearia()
    Private bsServicos As New BindingSource()
    Private idAtual As Integer = 0

    Private pnlTopo As Panel
    Private txtNome As TextBox
    Private txtDescricao As TextBox
    Private nudPreco As NumericUpDown
    Private nudDuracao As NumericUpDown
    Private WithEvents btnSalvar As Button
    Private WithEvents btnNovo As Button
    Private WithEvents btnRemover As Button

    Private WithEvents dgvServicos As DataGridView

    Private tt As New ToolTip()

    Private Const AlturaTopo As Integer = 130

    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = corFundo

        MontarGrid()
        MontarTopo()

        AddHandler Me.Load, AddressOf ucServicos_Load
    End Sub

    Private Sub ucServicos_Load(sender As Object, e As EventArgs)
        AtualizarGrid()
    End Sub

    Private Sub MontarTopo()
        pnlTopo = New Panel With {.Dock = DockStyle.Top, .Height = AlturaTopo, .BackColor = corCard, .Padding = New Padding(20, 15, 20, 10)}

        Dim lblNome As New Label With {.Text = "Nome", .ForeColor = corTextoSecundario, .Top = 15, .Left = 20, .AutoSize = True}
        txtNome = New TextBox With {.Top = 35, .Left = 20, .Width = 200}

        Dim lblDescricao As New Label With {.Text = "Descrição", .ForeColor = corTextoSecundario, .Top = 15, .Left = 240, .AutoSize = True}
        txtDescricao = New TextBox With {.Top = 35, .Left = 240, .Width = 260}

        Dim lblPreco As New Label With {.Text = "Preço (R$)", .ForeColor = corTextoSecundario, .Top = 15, .Left = 520, .AutoSize = True}
        nudPreco = New NumericUpDown With {.Top = 35, .Left = 520, .Width = 100, .Minimum = 0.01D, .Maximum = 100000D, .DecimalPlaces = 2, .Increment = 1D}

        Dim lblDuracao As New Label With {.Text = "Duração (min)", .ForeColor = corTextoSecundario, .Top = 15, .Left = 640, .AutoSize = True}
        nudDuracao = New NumericUpDown With {.Top = 35, .Left = 640, .Width = 80, .Minimum = 1, .Maximum = 600}

        btnSalvar = New Button With {.Text = "Salvar", .Top = 70, .Left = 20, .Width = 120, .Height = 32, .BackColor = corDourado, .FlatStyle = FlatStyle.Flat}
        btnSalvar.FlatAppearance.BorderSize = 0

        btnNovo = New Button With {.Text = "Novo", .Top = 70, .Left = 150, .Width = 100, .Height = 32, .FlatStyle = FlatStyle.Flat, .BackColor = corFundo, .ForeColor = Color.White}
        btnNovo.FlatAppearance.BorderColor = Color.DimGray

        btnRemover = New Button With {.Text = "Remover", .Top = 70, .Left = 260, .Width = 120, .Height = 32, .BackColor = Color.FromArgb(120, 40, 40), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat}
        btnRemover.FlatAppearance.BorderSize = 0

        tt.SetToolTip(nudDuracao, "Duração do serviço em minutos (usada para detectar conflitos de agenda)")

        pnlTopo.Controls.AddRange({lblNome, txtNome, lblDescricao, txtDescricao, lblPreco, nudPreco, lblDuracao, nudDuracao,
                                    btnSalvar, btnNovo, btnRemover})
        Me.Controls.Add(pnlTopo)
    End Sub

    Private Sub MontarGrid()
        dgvServicos = New DataGridView With {
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
        dgvServicos.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Id", .HeaderText = "Id", .FillWeight = 30})
        dgvServicos.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Nome", .HeaderText = "Nome", .FillWeight = 110})
        dgvServicos.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Descricao", .HeaderText = "Descrição", .FillWeight = 150})

        Dim colPreco As New DataGridViewTextBoxColumn With {.DataPropertyName = "Preco", .HeaderText = "Preço", .FillWeight = 70}
        colPreco.DefaultCellStyle.Format = "C2"
        dgvServicos.Columns.Add(colPreco)

        dgvServicos.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "DuracaoMinutos", .HeaderText = "Duração (min)", .FillWeight = 70})

        Me.Controls.Add(dgvServicos)
        dgvServicos.DataSource = bsServicos
    End Sub

    Private Sub dgvServicos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvServicos.SelectionChanged
        If dgvServicos.CurrentRow Is Nothing OrElse dgvServicos.CurrentRow.DataBoundItem Is Nothing Then Return

        Dim servico As Servico = DirectCast(dgvServicos.CurrentRow.DataBoundItem, Servico)
        idAtual = servico.Id
        txtNome.Text = servico.Nome
        txtDescricao.Text = servico.Descricao
        nudPreco.Value = servico.Preco
        nudDuracao.Value = servico.DuracaoMinutos
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        LimparFormulario()
    End Sub

    Private Sub LimparFormulario()
        idAtual = 0
        txtNome.Clear()
        txtDescricao.Clear()
        nudPreco.Value = nudPreco.Minimum
        nudDuracao.Value = nudDuracao.Minimum
        dgvServicos.ClearSelection()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim servico As New Servico(idAtual, txtNome.Text, txtDescricao.Text, nudPreco.Value, CInt(nudDuracao.Value))

            If idAtual = 0 Then
                barbearia.CadastrarServico(servico)
                MessageBox.Show("Serviço cadastrado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                barbearia.AtualizarServico(servico)
                MessageBox.Show("Serviço atualizado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Selecione um serviço na lista para remover.", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim resposta = MessageBox.Show("Deseja realmente remover este serviço?", "Confirmar remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resposta <> DialogResult.Yes Then Return

        Try
            barbearia.RemoverServico(idAtual)
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
            bsServicos.DataSource = barbearia.ListarServicos().ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar serviços: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
