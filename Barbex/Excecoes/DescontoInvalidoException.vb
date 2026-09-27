Namespace Excecoes
    Public Class DescontoInvalidoException
        Inherits ValidacaoException

        Public ReadOnly Property ValorInformado As Decimal

        Public Sub New(valorInformado As Decimal)
            MyBase.New($"Desconto inválido: {valorInformado}%. O desconto deve estar entre 0% e 100%.")
            Me.ValorInformado = valorInformado
        End Sub

    End Class
End Namespace
