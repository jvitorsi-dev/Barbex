Imports System.Linq
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

Public Class ucAgendamentos

    Private barbearia As GerenciadorBarbearia = GerenciadorBarbearia.Instancia
    Private bsAgendamentos As New BindingSource()

    Private Sub ucAgendamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvAgendamentos.DataSource = bsAgendamentos
        dtpFiltroData.Value = DateTime.Today
        CarregarCombos()
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

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        AtualizarGrid()
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
                dtpFiltroData.Value,
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

    Private Sub AtualizarGrid()
        Try
            bsAgendamentos.DataSource = barbearia.ListarAgendamentos(dtpFiltroData.Value).ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar agendamentos: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvAgendamentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAgendamentos.CellContentClick

    End Sub
End Class