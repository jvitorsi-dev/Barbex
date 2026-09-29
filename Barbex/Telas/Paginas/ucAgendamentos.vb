Imports System.Collections.Generic
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
            cboProfissional.DropDownStyle = ComboBoxStyle.DropDownList
            cboProfissional.DisplayMember = "Texto"
            cboProfissional.DataSource = CriarOpcoesFiltro(Of Profissional)(
                barbearia.ListarProfissionais(), Function(profissional) profissional.ToString())

            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList
            cboCliente.DisplayMember = "Texto"
            cboCliente.DataSource = CriarOpcoesFiltro(Of Cliente)(
                barbearia.ListarClientes(), Function(cliente) cliente.ToString())

            cboServico.DropDownStyle = ComboBoxStyle.DropDownList
            cboServico.DisplayMember = "Texto"
            cboServico.DataSource = CriarOpcoesFiltro(Of Servico)(
                barbearia.ListarServicos(), Function(servico) servico.ToString())
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar combos: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        AtualizarGrid()
    End Sub

    Private Sub btnAgendar_Click(sender As Object, e As EventArgs) Handles btnAgendar.Click
        Try
            Dim cliente As Cliente = ObterValorSelecionado(Of Cliente)(cboCliente)
            Dim profissional As Profissional = ObterValorSelecionado(Of Profissional)(cboProfissional)
            Dim servico As Servico = ObterValorSelecionado(Of Servico)(cboServico)

            If cliente Is Nothing OrElse profissional Is Nothing OrElse servico Is Nothing Then
                MessageBox.Show("Selecione cliente, profissional e serviço.", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim ag As New AgendamentoComDesconto(0,
                cliente,
                profissional,
                servico,
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
            Dim cliente As Cliente = ObterValorSelecionado(Of Cliente)(cboCliente)
            Dim profissional As Profissional = ObterValorSelecionado(Of Profissional)(cboProfissional)
            Dim servico As Servico = ObterValorSelecionado(Of Servico)(cboServico)
            Dim agendamentos As IEnumerable(Of Agendamento) = barbearia.ListarAgendamentos(dtpFiltroData.Value)

            If cliente IsNot Nothing Then
                agendamentos = agendamentos.Where(Function(ag) ag.Cliente IsNot Nothing AndAlso ag.Cliente.Id = cliente.Id)
            End If

            If profissional IsNot Nothing Then
                agendamentos = agendamentos.Where(Function(ag) ag.Profissional IsNot Nothing AndAlso ag.Profissional.Id = profissional.Id)
            End If

            If servico IsNot Nothing Then
                agendamentos = agendamentos.Where(Function(ag) ag.Servico IsNot Nothing AndAlso ag.Servico.Id = servico.Id)
            End If

            bsAgendamentos.DataSource = agendamentos.ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar agendamentos: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CriarOpcoesFiltro(Of T As Class)(itens As IEnumerable(Of T), obterTexto As Func(Of T, String)) As List(Of OpcaoFiltro(Of T))
        Dim opcoes As New List(Of OpcaoFiltro(Of T)) From {
            New OpcaoFiltro(Of T) With {.Texto = "Todos", .Valor = Nothing}
        }

        For Each item As T In itens
            opcoes.Add(New OpcaoFiltro(Of T) With {.Texto = obterTexto(item), .Valor = item})
        Next

        Return opcoes
    End Function

    Private Function ObterValorSelecionado(Of T As Class)(combo As ComboBox) As T
        Dim opcao As OpcaoFiltro(Of T) = TryCast(combo.SelectedItem, OpcaoFiltro(Of T))
        If opcao Is Nothing Then Return Nothing
        Return opcao.Valor
    End Function

    Private Class OpcaoFiltro(Of T As Class)
        Public Property Texto As String
        Public Property Valor As T
    End Class

    Private Sub dgvAgendamentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAgendamentos.CellContentClick

    End Sub
End Class
