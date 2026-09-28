Imports System.Linq
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

Public Class ucProfissionais

    Public Sub New()
        InitializeComponent()
    End Sub

    Private barbearia As GerenciadorBarbearia = GerenciadorBarbearia.Instancia
    Private bsProfissionais As New BindingSource()
    Private idAtual As Integer = 0

    Private Sub ucProfissionais_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvProfissionais.AutoGenerateColumns = False ' só as colunas definidas na mão aparecem — Foto/TemFoto nunca entram aqui
        dgvProfissionais.DataSource = bsProfissionais
        cboCampoBusca.Items.AddRange({"Nome", "Especialidade"})
        cboCampoBusca.SelectedIndex = 0
        AtualizarGrid()
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

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        AtualizarGrid()
    End Sub

    Private Sub cboCampoBusca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCampoBusca.SelectedIndexChanged
        AtualizarGrid()
    End Sub

    Private Sub AtualizarGrid()
        Try
            Dim termo As String = txtBusca.Text.Trim()
            Dim lista = barbearia.ListarProfissionais().ToList()

            If Not String.IsNullOrEmpty(termo) Then
                Dim campo As String = If(cboCampoBusca.SelectedItem IsNot Nothing, cboCampoBusca.SelectedItem.ToString(), "Nome")
                lista = lista.Where(Function(p)
                                        Dim valor As String = If(campo = "Especialidade", p.Especialidade, p.Nome)
                                        Return valor IsNot Nothing AndAlso valor.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0
                                    End Function).ToList()
            End If

            bsProfissionais.DataSource = lista
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar profissionais: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProfissionais_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProfissionais.CellContentClick

    End Sub
End Class