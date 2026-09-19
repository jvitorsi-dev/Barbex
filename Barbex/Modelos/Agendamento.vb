Imports Barbex.Excecoes

Namespace Modelos
    ''' <summary>
    ''' Agendamento de um serviço.
    ''' Classe BASE da hierarquia: os métodos de cálculo são Overridable
    ''' para que AgendamentoComDesconto possa especializá-los (POLIMORFISMO).
    ''' </summary>
    Public Class Agendamento
        Implements IIdentificavel

        Private _id As Integer
        Private _cliente As Cliente
        Private _profissional As Profissional
        Private _servico As Servico
        Private _dataHora As DateTime
        Private _status As StatusAgendamento

        Public Sub New()
            _status = StatusAgendamento.Pendente
        End Sub

        Public Sub New(id As Integer, cliente As Cliente, profissional As Profissional,
                       servico As Servico, dataHora As DateTime)
            Me.Id = id
            Me.Cliente = cliente
            Me.Profissional = profissional
            Me.Servico = servico
            Me.DataHora = dataHora
            Me.Status = StatusAgendamento.Pendente
        End Sub

        Public Property Id As Integer Implements IIdentificavel.Id
            Get
                Return _id
            End Get
            Set(value As Integer)
                If value < 0 Then
                    Throw New ValidacaoException("O Id do agendamento não pode ser negativo.")
                End If
                _id = value
            End Set
        End Property

        Public Property Cliente As Cliente
            Get
                Return _cliente
            End Get
            Set(value As Cliente)
                If value Is Nothing Then
                    Throw New ValidacaoException("O agendamento precisa de um cliente.")
                End If
                _cliente = value
            End Set
        End Property

        Public Property Profissional As Profissional
            Get
                Return _profissional
            End Get
            Set(value As Profissional)
                If value Is Nothing Then
                    Throw New ValidacaoException("O agendamento precisa de um profissional.")
                End If
                _profissional = value
            End Set
        End Property

        Public Property Servico As Servico
            Get
                Return _servico
            End Get
            Set(value As Servico)
                If value Is Nothing Then
                    Throw New ValidacaoException("O agendamento precisa de um serviço.")
                End If
                _servico = value
            End Set
        End Property

        Public Property DataHora As DateTime
            Get
                Return _dataHora
            End Get
            Set(value As DateTime)
                _dataHora = value
            End Set
        End Property

        Public Property Status As StatusAgendamento
            Get
                Return _status
            End Get
            Set(value As StatusAgendamento)
                _status = value
            End Set
        End Property

        ''' <summary>Horário de término = início + duração do serviço.</summary>
        Public ReadOnly Property HorarioFim As DateTime
            Get
                Return DataHora.AddMinutes(If(Servico Is Nothing, 0, Servico.DuracaoMinutos))
            End Get
        End Property

        ' ============================================================
        '  MÉTODOS OVERRIDABLE — aqui mora o POLIMORFISMO da P1
        ' ============================================================

        ''' <summary>Valor cobrado do cliente. Na classe base é o preço cheio do serviço.</summary>
        Public Overridable Function CalcularValorTotal() As Decimal
            Return If(Servico Is Nothing, 0D, Servico.Preco)
        End Function

        ''' <summary>Comissão devida ao profissional sobre o valor do atendimento.</summary>
        Public Overridable Function CalcularComissao() As Decimal
            Dim percentual As Decimal = If(Profissional Is Nothing, 0D, Profissional.PercentualComissao)
            Return CalcularValorTotal() * (percentual / 100D)
        End Function

        ''' <summary>Texto de exibição do agendamento (telas e relatórios).</summary>
        Public Overridable Function Resumo() As String
            Return $"[{Status}] {DataHora:dd/MM/yyyy HH:mm} - {Cliente?.Nome} com {Profissional?.Nome} ({Servico?.Nome}) = {CalcularValorTotal():C2}"
        End Function

        ''' <summary>
        ''' REGRA DE CONFLITO: dois agendamentos conflitam quando são do MESMO
        ''' profissional e seus intervalos [início, fim) se sobrepõem.
        ''' Agendamentos cancelados nunca conflitam.
        ''' </summary>
        Public Function ConflitaCom(outro As Agendamento) As Boolean
            If outro Is Nothing Then Return False
            If Me.Status = StatusAgendamento.Cancelado OrElse
               outro.Status = StatusAgendamento.Cancelado Then Return False
            If Me.Profissional Is Nothing OrElse outro.Profissional Is Nothing Then Return False
            If Me.Profissional.Id <> outro.Profissional.Id Then Return False

            ' Sobreposição de intervalos: A começa antes de B terminar E B começa antes de A terminar
            Return Me.DataHora < outro.HorarioFim AndAlso outro.DataHora < Me.HorarioFim
        End Function

        Public Overrides Function ToString() As String
            Return Resumo()
        End Function

    End Class
End Namespace
