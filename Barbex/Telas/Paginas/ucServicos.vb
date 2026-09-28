Imports System.Linq
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

Public Class ucServicos

    Public Sub New()
        InitializeComponent()
    End Sub

    Private barbearia As GerenciadorBarbearia = GerenciadorBarbearia.Instancia
    Private bsServicos As New BindingSource()
    Private idAtual As Integer = 0

    Private Sub ucServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvServicos.AutoGenerateColumns = False ' só as colunas definidas na mão aparecem — Foto/TemFoto nunca entram aqui
        dgvServicos.DataSource = bsServicos
        cboCampoBusca.Items.AddRange({"Nome", "Descrição"})
        cboCampoBusca.SelectedIndex = 0
        AtualizarGrid()
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

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        AtualizarGrid()
    End Sub

    Private Sub cboCampoBusca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCampoBusca.SelectedIndexChanged
        AtualizarGrid()
    End Sub

    Private Sub AtualizarGrid()
        Try
            Dim termo As String = txtBusca.Text.Trim()
            Dim lista = barbearia.ListarServicos().ToList()

            If Not String.IsNullOrEmpty(termo) Then
                Dim campo As String = If(cboCampoBusca.SelectedItem IsNot Nothing, cboCampoBusca.SelectedItem.ToString(), "Nome")
                lista = lista.Where(Function(s)
                                        Dim valor As String = If(campo = "Descrição", s.Descricao, s.Nome)
                                        Return valor IsNot Nothing AndAlso valor.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0
                                    End Function).ToList()
            End If

            bsServicos.DataSource = lista
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar serviços: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvServicos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServicos.CellContentClick

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
End Class