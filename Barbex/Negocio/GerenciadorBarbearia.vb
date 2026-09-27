Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Persistencia

Namespace Negocio
    Public Class GerenciadorBarbearia

        Private ReadOnly _clientes As New Repositorio(Of Cliente)("dbo.Cliente")
        Private ReadOnly _profissionais As New Repositorio(Of Profissional)("dbo.Profissional")
        Private ReadOnly _servicos As New Repositorio(Of Servico)("dbo.Servico")
        Private ReadOnly _agendamentos As New Repositorio(Of Agendamento)("dbo.Agendamento")

#Region "Clientes"
        Public Function CadastrarCliente(cliente As Cliente) As Cliente
            If cliente.Id = 0 Then cliente.Id = _clientes.ProximoId()
            _clientes.Adicionar(cliente)
            Return cliente
        End Function

        Public Sub AtualizarCliente(cliente As Cliente)
            _clientes.Atualizar(cliente)
        End Sub

        Public Function RemoverCliente(id As Integer) As Boolean
            Return _clientes.Remover(id)
        End Function

        Public Function BuscarClientePorId(id As Integer) As Cliente
            Return _clientes.BuscarPorId(id)
        End Function

        Public Function ListarClientes() As IReadOnlyList(Of Cliente)
            Return _clientes.ListarTodos()
        End Function
#End Region

#Region "Profissionais"
        Public Function CadastrarProfissional(profissional As Profissional) As Profissional
            If profissional.Id = 0 Then profissional.Id = _profissionais.ProximoId()
            _profissionais.Adicionar(profissional)
            Return profissional
        End Function

        Public Sub AtualizarProfissional(profissional As Profissional)
            _profissionais.Atualizar(profissional)
        End Sub

        Public Function RemoverProfissional(id As Integer) As Boolean
            Return _profissionais.Remover(id)
        End Function

        Public Function BuscarProfissionalPorId(id As Integer) As Profissional
            Return _profissionais.BuscarPorId(id)
        End Function

        Public Function ListarProfissionais() As IReadOnlyList(Of Profissional)
            Return _profissionais.ListarTodos()
        End Function
#End Region

#Region "Serviços"
        Public Function CadastrarServico(servico As Servico) As Servico
            If servico.Id = 0 Then servico.Id = _servicos.ProximoId()
            _servicos.Adicionar(servico)
            Return servico
        End Function

        Public Sub AtualizarServico(servico As Servico)
            _servicos.Atualizar(servico)
        End Sub

        Public Function RemoverServico(id As Integer) As Boolean
            Return _servicos.Remover(id)
        End Function

        Public Function BuscarServicoPorId(id As Integer) As Servico
            Return _servicos.BuscarPorId(id)
        End Function

        Public Function ListarServicos() As IReadOnlyList(Of Servico)
            Return _servicos.ListarTodos()
        End Function
#End Region

#Region "Agendamentos"
        Public Function Agendar(agendamento As Agendamento) As Agendamento
            ValidarAgendamentoCompleto(agendamento)

            Dim conflito As Agendamento = EncontrarConflito(agendamento)
            If conflito IsNot Nothing Then
                Throw New HorarioOcupadoException(agendamento.Profissional.Nome,
                                                  conflito.DataHora, conflito.HorarioFim)
            End If

            If agendamento.Id = 0 Then agendamento.Id = ProximoIdAgendamento()
            _agendamentos.Adicionar(agendamento)
            Return agendamento
        End Function

        Public Sub AtualizarAgendamento(agendamento As Agendamento)
            ValidarAgendamentoCompleto(agendamento)

            If BuscarAgendamentoPorId(agendamento.Id) Is Nothing Then
                Throw New ValidacaoException($"Agendamento com Id {agendamento.Id} não encontrado para atualização.")
            End If

            Dim conflito As Agendamento = EncontrarConflito(agendamento)
            If conflito IsNot Nothing Then
                Throw New HorarioOcupadoException(agendamento.Profissional.Nome,
                                                  conflito.DataHora, conflito.HorarioFim)
            End If

            _agendamentos.Atualizar(agendamento)
        End Sub

        Public Function ConfirmarAgendamento(id As Integer) As Boolean
            Return AlterarStatus(id, StatusAgendamento.Confirmado)
        End Function

        Public Function ConcluirAgendamento(id As Integer) As Boolean
            Return AlterarStatus(id, StatusAgendamento.Concluido)
        End Function

        Public Function CancelarAgendamento(id As Integer) As Boolean
            Return AlterarStatus(id, StatusAgendamento.Cancelado)
        End Function

        Public Function ExcluirAgendamento(id As Integer) As Boolean
            Return _agendamentos.Remover(id)
        End Function

        Public Function BuscarAgendamentoPorId(id As Integer) As Agendamento
            For Each ag In _agendamentos.ListarTodos()
                If ag.Id = id Then Return ag
            Next
            Return Nothing
        End Function

        Public Function EncontrarConflito(agendamento As Agendamento) As Agendamento
            For Each existente In _agendamentos.ListarTodos()
                If existente.Id <> agendamento.Id AndAlso existente.ConflitaCom(agendamento) Then
                    Return existente
                End If
            Next
            Return Nothing
        End Function

        Public Function ListarAgendamentos() As IReadOnlyList(Of Agendamento)
            Return _agendamentos.ListarTodos()
        End Function

        Public Function ListarAgendamentos(data As Date) As List(Of Agendamento)
            Dim resultado As New List(Of Agendamento)()
            For Each ag In _agendamentos.ListarTodos()
                If ag.DataHora.Date = data.Date Then resultado.Add(ag)
            Next
            Return resultado
        End Function

        Public Function ListarAgendamentosPorProfissional(profissionalId As Integer) As List(Of Agendamento)
            Dim resultado As New List(Of Agendamento)()
            For Each ag In _agendamentos.ListarTodos()
                If ag.Profissional IsNot Nothing AndAlso ag.Profissional.Id = profissionalId Then
                    resultado.Add(ag)
                End If
            Next
            Return resultado
        End Function
#End Region

#Region "Relatórios"
        Public Function CalcularFaturamento(data As Date) As Decimal
            Dim total As Decimal = 0D
            For Each ag In _agendamentos.ListarTodos()
                If ag.Status <> StatusAgendamento.Cancelado AndAlso ag.DataHora.Date = data.Date Then
                    total += ag.CalcularValorTotal()
                End If
            Next
            Return total
        End Function

        Public Function CalcularComissaoProfissional(profissionalId As Integer,
                                                     inicio As Date, fim As Date) As Decimal
            Dim total As Decimal = 0D
            For Each ag In _agendamentos.ListarTodos()
                If ag.Status <> StatusAgendamento.Cancelado AndAlso
                   ag.Profissional IsNot Nothing AndAlso
                   ag.Profissional.Id = profissionalId AndAlso
                   ag.DataHora.Date >= inicio.Date AndAlso
                   ag.DataHora.Date <= fim.Date Then
                    total += ag.CalcularComissao()
                End If
            Next
            Return total
        End Function
#End Region

#Region "Auxiliares"
        Private Sub ValidarAgendamentoCompleto(agendamento As Agendamento)
            If agendamento Is Nothing Then Throw New ArgumentNullException(NameOf(agendamento))
            If agendamento.Cliente Is Nothing OrElse
               agendamento.Profissional Is Nothing OrElse
               agendamento.Servico Is Nothing Then
                Throw New ValidacaoException("Agendamento incompleto: informe cliente, profissional e serviço.")
            End If
        End Sub

        Private Function AlterarStatus(id As Integer, novoStatus As StatusAgendamento) As Boolean
            Dim ag As Agendamento = BuscarAgendamentoPorId(id)
            If ag Is Nothing Then Return False
            ag.Status = novoStatus
            Return True
        End Function

        Private Function ProximoIdAgendamento() As Integer
            Dim maior As Integer = 0
            For Each ag In _agendamentos.ListarTodos()
                If ag.Id > maior Then maior = ag.Id
            Next
            Return maior + 1
        End Function
#End Region

    End Class
End Namespace
