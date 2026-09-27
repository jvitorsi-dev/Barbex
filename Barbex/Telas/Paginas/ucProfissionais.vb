Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

Public Class ucProfissionais
    Inherits UserControl

    Private ReadOnly corFundo As Color = Color.FromArgb(18, 18, 18)
    Private ReadOnly corCard As Color = Color.FromArgb(28, 28, 28)
    Private ReadOnly corTextoSecundario As Color = Color.Silver
    Private ReadOnly corDourado As Color = Color.FromArgb(212, 163, 82)

    Private barbearia As New GerenciadorBarbearia()
    Private bsProfissionais As New BindingSource()
    Private idAtual As Integer = 0

    Private pnlTopo As Panel
    Private txtNome As TextBox
    Private txtEspecialidade As TextBox
    Private nudComissao As NumericUpDown
    Private chkAtivo As CheckBox
    Private WithEvents btnSalvar As Button
    Private WithEvents btnNovo As Button
    Private WithEvents btnRemover As Button

    Private WithEvents dgvProfissionais As DataGridView

    Private tt As New ToolTip()

    Private Const AlturaTopo As Integer = 130

    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = corFundo

        MontarGrid()
        MontarTopo()

        AddHandler Me.Load, AddressOf ucProfissionais_Load
    End Sub

    Private Sub ucProfissionais_Load(sender As Object, e As EventArgs)
        AtualizarGrid()
    End Sub

    Private Sub MontarTopo()
        pnlTopo = New Panel With {.Dock = DockStyle.Top, .Height = AlturaTopo, .BackColor = corCard, .Padding = New Padding(20, 15, 20, 10)}

        Dim lblNome As New Label With {.Text = "Nome", .ForeColor = corTextoSecundario, .Top = 15, .Left = 20, .AutoSize = True}
        txtNome = New TextBox With {.Top = 35, .Left = 20, .Width = 200}

        Dim lblEspecialidade As New Label With {.Text = "Especialidade", .ForeColor = corTextoSecundario, .Top = 15, .Left = 240, .AutoSize = True}
        txtEspecialidade = New TextBox With {.Top = 35, .Left = 240, .Width = 200}

        Dim lblComissao As New Label With {.Text = "Comissão (%)", .ForeColor = corTextoSecundario, .Top = 15, .Left = 460, .AutoSize = True}
        nudComissao = New NumericUpDown With {.Top = 35, .Left = 460, .Width = 90, .Minimum = 0, .Maximum = 100, .DecimalPlaces = 2}

        chkAtivo = New CheckBox With {.Text = "Ativo", .ForeColor = corTextoSecundario, .Top = 40, .Left = 570, .AutoSize = True, .Checked = True}

        btnSalvar = New Button With {.Text = "Salvar", .Top = 70, .Left = 20, .Width = 120, .Height = 32, .BackColor = corDourado, .FlatStyle = FlatStyle.Flat}
        btnSalvar.FlatAppearance.BorderSize = 0

        btnNovo = New Button With {.Text = "Novo", .Top = 70, .Left = 150, .Width = 100, .Height = 32, .FlatStyle = FlatStyle.Flat, .BackColor = corFundo, .ForeColor = Color.White}
        btnNovo.FlatAppearance.BorderColor = Color.DimGray

        btnRemover = New Button With {.Text = "Remover", .Top = 70, .Left = 260, .Width = 120, .Height = 32, .BackColor = Color.FromArgb(120, 40, 40), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat}
        btnRemover.FlatAppearance.BorderSize = 0

        tt.SetToolTip(nudComissao, "Percentual de comissão sobre os atendimentos (0 a 100)")

        pnlTopo.Controls.AddRange({lblNome, txtNome, lblEspecialidade, txtEspecialidade, lblComissao, nudComissao, chkAtivo,
                                    btnSalvar, btnNovo, btnRemover})
        Me.Controls.Add(pnlTopo)
    End Sub

    Private Sub MontarGrid()
        dgvProfissionais = New DataGridView With {
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
        dgvProfissionais.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Id", .HeaderText = "Id", .FillWeight = 30})
        dgvProfissionais.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Nome", .HeaderText = "Nome", .FillWeight = 120})
        dgvProfissionais.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Especialidade", .HeaderText = "Especialidade", .FillWeight = 120})
        dgvProfissionais.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "PercentualComissao", .HeaderText = "Comissão (%)", .FillWeight = 80})
        dgvProfissionais.Columns.Add(New DataGridViewCheckBoxColumn With {.DataPropertyName = "Ativo", .HeaderText = "Ativo", .FillWeight = 50})

        Me.Controls.Add(dgvProfissionais)
        dgvProfissionais.DataSource = bsProfissionais
    End Sub

    Private Sub dgvProfissionais_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProfissionais.SelectionChanged
        If dgvProfissionais.CurrentRow Is Nothing OrElse dgvProfissionais.CurrentRow.DataBoundItem Is Nothing Then Return

        Dim profissional As Profissional = DirectCast(dgvProfissionais.CurrentRow.DataBoundItem, Profissional)
        idAtual = profissional.Id
        txtNome.Text = profissional.Nome
        txtEspecialidade.Text = profissional.Especialidade
        nudComissao.Value = profissional.PercentualComissao
        chkAtivo.Checked = profissional.Ativo
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        LimparFormulario()
    End Sub

    Private Sub LimparFormulario()
        idAtual = 0
        txtNome.Clear()
        txtEspecialidade.Clear()
        nudComissao.Value = 0
        chkAtivo.Checked = True
        dgvProfissionais.ClearSelection()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim profissional As New Profissional(idAtual, txtNome.Text, txtEspecialidade.Text, nudComissao.Value)
            profissional.Ativo = chkAtivo.Checked

            If idAtual = 0 Then
                barbearia.CadastrarProfissional(profissional)
                MessageBox.Show("Profissional cadastrado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                barbearia.AtualizarProfissional(profissional)
                MessageBox.Show("Profissional atualizado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            LimparFormulario()

        Catch ex As ComissaoInvalidaException
            MessageBox.Show(ex.Message, "Comissão inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show("Selecione um profissional na lista para remover.", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim resposta = MessageBox.Show("Deseja realmente remover este profissional?", "Confirmar remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resposta <> DialogResult.Yes Then Return

        Try
            barbearia.RemoverProfissional(idAtual)
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
            bsProfissionais.DataSource = barbearia.ListarProfissionais().ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar profissionais: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
