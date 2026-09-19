Namespace Excecoes
    ''' <summary>
    ''' Exceção BASE de todas as regras de negócio do Barbex.
    ''' Herda de Exception e permite que a interface capture qualquer erro
    ''' do sistema com um único "Catch ex As BarbexException".
    ''' </summary>
    Public Class BarbexException
        Inherits Exception

        Public Sub New(mensagem As String)
            MyBase.New(mensagem)
        End Sub

        Public Sub New(mensagem As String, excecaoInterna As Exception)
            MyBase.New(mensagem, excecaoInterna)
        End Sub

    End Class
End Namespace
