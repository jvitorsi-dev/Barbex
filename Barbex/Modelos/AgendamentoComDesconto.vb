Imports Barbex.Excecoes

Namespace Modelos
    Public Class AgendamentoComDesconto
        Inherits Agendamento

        Private _percentualDesconto As Decimal

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(id As Integer, cliente As Cliente, profissional As Profissional,
                       servico As Servico, dataHora As DateTime, percentualDesconto As Decimal)
            MyBase.New(id, cliente, profissional, servico, dataHora)
            Me.PercentualDesconto = percentualDesconto
        End Sub

        Public Property PercentualDesconto As Decimal
            Get
                Return _percentualDesconto
            End Get
            Set(value As Decimal)
                If value < 0D OrElse value > 100D Then
                    Throw New DescontoInvalidoException(value)
                End If
                _percentualDesconto = value
            End Set
        End Property

        Public Overrides Function CalcularValorTotal() As Decimal
            Dim valorBase As Decimal = MyBase.CalcularValorTotal()
            Return valorBase - (valorBase * (PercentualDesconto / 100D))
        End Function

        Public Overrides Function CalcularComissao() As Decimal
            Return CalcularValorTotal() * (Profissional.PercentualComissao / 100D)
        End Function

        Public Overrides Function Resumo() As String
            Return MyBase.Resumo() & $" (desconto de {PercentualDesconto}%)"
        End Function

    End Class
End Namespace
