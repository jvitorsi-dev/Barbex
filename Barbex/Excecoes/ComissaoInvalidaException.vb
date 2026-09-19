Namespace Excecoes
    ''' <summary>
    ''' Lançada quando o percentual de comissão de um profissional
    ''' está fora da faixa permitida (0% a 100%).
    ''' </summary>
    Public Class ComissaoInvalidaException
        Inherits ValidacaoException

        ''' <summary>Percentual que o usuário tentou informar.</summary>
        Public ReadOnly Property ValorInformado As Decimal

        Public Sub New(valorInformado As Decimal)
            MyBase.New($"Comissão inválida: {valorInformado}%. A comissão deve estar entre 0% e 100%.")
            Me.ValorInformado = valorInformado
        End Sub

    End Class
End Namespace
