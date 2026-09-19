Imports Barbex.Excecoes
Imports Barbex.Modelos

Namespace Negocio
    ''' <summary>
    ''' Fachada de negócio do sistema: concentra o CRUD das entidades,
    ''' a validação de conflito de horários e os relatórios
    ''' (faturamento e comissão).
    '''
    ''' QUEM USA O QUÊ:
    '''  - Gabriel (UI): chama estes métodos nos eventos dos botões e
    '''    envolve as chamadas em Try...Catch com MessageBox.
    '''  - Helen (persistência): usa Listar*/Cadastrar* para salvar e
    '''    recarregar os dados (Ids informados são preservados; Id = 0
    '''    gera automaticamente).
    ''' </summary>
    Public Class GerenciadorBarbearia

        Private ReadOnly _clientes As New Repositorio(Of Cliente)()
        Private ReadOnly _profissionais As New Repositorio(Of Profissional)()
        Private ReadOnly _servicos As New Repositorio(Of Servico)()
        Private ReadOnly _agendamentos As New List(Of Agendamento)()

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
        ''' <summary>
        ''' Agenda um atendimento aplicando TODAS as regras de negócio.
        ''' Lança HorarioOcupadoException se o profissional já tiver
        ''' atendimento sobreposto ao horário solicitado.
        ''' </summary>
        Public Function Agendar(agendamento As Agendamento) As Agendamento
            ValidarAgendamentoCompleto(agendamento)

            Dim conflito As Agendamento = EncontrarConflito(agendamento)
            If conflito IsNot Nothing Then
                Throw New HorarioOcupadoException(agendamento.Profissional.Nome,
                                                  conflito.DataHora, conflito.HorarioFim)
            End If

            If agendamento.Id = 0 Then agendamento.Id = ProximoIdAgendamento()
            _agendamentos.Add(agendamento)
            Return agendamento
        End Function

        ''' <summary>Atualiza (reagenda) um agendamento existente, revalidando conflitos.</summary>
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

            _agendamentos.RemoveAll(Function(a) a.Id = agendamento.Id)
            _agendamentos.Add(agendamento)
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
            Dim ag As Agendamento = BuscarAgendamentoPorId(id)
            If ag Is Nothing Then Return False
            _agendamentos.Remove(ag)
            Return True
        End Function

        Public Function BuscarAgendamentoPorId(id As Integer) As Agendamento
            For Each ag In _agendamentos
                If ag.Id = id Then Return ag
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Retorna o agendamento que conflita com o informado, ou Nothing
        ''' se o horário estiver livre. Ignora o próprio Id (para updates).
        ''' </summary>
        Public Function EncontrarConflito(agendamento As Agendamento) As Agendamento
            For Each existente In _agendamentos
                If existente.Id <> agendamento.Id AndAlso existente.ConflitaCom(agendamento) Then
                    Return existente
                End If
            Next
            Return Nothing
        End Function

        Public Function ListarAgendamentos() As IReadOnlyList(Of Agendamento)
            Return _agendamentos.AsReadOnly()
        End Function

        ''' <summary>Agendamentos de um dia específico (para a grade do Gabriel).</summary>
        Public Function ListarAgendamentos(data As Date) As List(Of Agendamento)
            Dim resultado As New List(Of Agendamento)()
            For Each ag In _agendamentos
                If ag.DataHora.Date = data.Date Then resultado.Add(ag)
            Next
            Return resultado
        End Function

        Public Function ListarAgendamentosPorProfissional(profissionalId As Integer) As List(Of Agendamento)
            Dim resultado As New List(Of Agendamento)()
            For Each ag In _agendamentos
                If ag.Profissional IsNot Nothing AndAlso ag.Profissional.Id = profissionalId Then
                    resultado.Add(ag)
                End If
            Next
            Return resultado
        End Function
#End Region

#Region "Relatórios"
        ''' <summary>
        ''' Faturamento previsto do dia = soma dos valores de todos os
        ''' agendamentos não cancelados. Usa CalcularValorTotal de forma
        ''' POLIMÓRFICA (agendamentos com desconto entram com valor reduzido).
        ''' </summary>
        Public Function CalcularFaturamento(data As Date) As Decimal
            Dim total As Decimal = 0D
            For Each ag In _agendamentos
                If ag.Status <> StatusAgendamento.Cancelado AndAlso ag.DataHora.Date = data.Date Then
                    total += ag.CalcularValorTotal()
                End If
            Next
            Return total
        End Function

        ''' <summary>
        ''' Comissão acumulada de um profissional num período.
        ''' Usa CalcularComissao de forma POLIMÓRFICA.
        ''' </summary>
        Public Function CalcularComissaoProfissional(profissionalId As Integer,
                                                     inicio As Date, fim As Date) As Decimal
            Dim total As Decimal = 0D
            For Each ag In _agendamentos
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

#Region "Métodos auxiliares privados (encapsulados)"
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
            For Each ag In _agendamentos
                If ag.Id > maior Then maior = ag.Id
            Next
            Return maior + 1
        End Function
#End Region

    End Class
End Namespace
