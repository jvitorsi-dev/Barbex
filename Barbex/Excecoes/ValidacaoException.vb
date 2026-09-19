Namespace Excecoes
    ''' <summary>
    ''' Erro genérico de validação de dados (campo obrigatório vazio,
    ''' formato inválido, Id duplicado etc.). Herda de BarbexException.
    ''' </summary>
    Public Class ValidacaoException
        Inherits BarbexException

        Public Sub New(mensagem As String)
            MyBase.New(mensagem)
        End Sub

    End Class
End Namespace
