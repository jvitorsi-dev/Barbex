Namespace Excecoes
    ''' <summary>
    ''' Lançada quando o percentual de desconto de um agendamento
    ''' promocional está fora da faixa permitida (0% a 100%).
    ''' </summary>
    Public Class DescontoInvalidoException
        Inherits ValidacaoException

        ''' <summary>Percentual que o usuário tentou informar.</summary>
        Public ReadOnly Property ValorInformado As Decimal

        Public Sub New(valorInformado As Decimal)
            MyBase.New($"Desconto inválido: {valorInformado}%. O desconto deve estar entre 0% e 100%.")
            Me.ValorInformado = valorInformado
        End Sub

    End Class
End Namespace
