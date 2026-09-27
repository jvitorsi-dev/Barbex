Namespace Excecoes
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
