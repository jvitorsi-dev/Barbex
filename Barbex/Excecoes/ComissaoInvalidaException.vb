Namespace Excecoes
    Public Class ComissaoInvalidaException
        Inherits ValidacaoException

        Public ReadOnly Property ValorInformado As Decimal

        Public Sub New(valorInformado As Decimal)
            MyBase.New($"Comissão inválida: {valorInformado}%. A comissão deve estar entre 0% e 100%.")
            Me.ValorInformado = valorInformado
        End Sub

    End Class
End Namespace
