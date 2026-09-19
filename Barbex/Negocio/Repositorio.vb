Imports Barbex.Excecoes
Imports Barbex.Modelos

Namespace Negocio
    ''' <summary>
    ''' Repositório genérico em memória com o CRUD básico de qualquer
    ''' entidade que implemente IIdentificavel.
    ''' GENERICS (Of T) + INTERFACE: uma única classe atende Cliente,
    ''' Profissional e Servico sem duplicar código.
    ''' A Helen poderá trocar o armazenamento interno por JSON/SQLite
    ''' mantendo esta mesma interface pública.
    ''' </summary>
    Public Class Repositorio(Of T As IIdentificavel)

        Private ReadOnly _itens As New List(Of T)()

        Public Sub Adicionar(item As T)
            If item Is Nothing Then Throw New ArgumentNullException(NameOf(item))
            If BuscarPorId(item.Id) IsNot Nothing Then
                Throw New ValidacaoException($"Já existe um registro com o Id {item.Id}.")
            End If
            _itens.Add(item)
        End Sub

        Public Function BuscarPorId(id As Integer) As T
            For Each item In _itens
                If item.Id = id Then Return item
            Next
            Return Nothing
        End Function

        Public Sub Atualizar(item As T)
            If item Is Nothing Then Throw New ArgumentNullException(NameOf(item))
            Dim existente As T = BuscarPorId(item.Id)
            If existente Is Nothing Then
                Throw New ValidacaoException($"Registro com Id {item.Id} não encontrado para atualização.")
            End If
            _itens.Remove(existente)
            _itens.Add(item)
        End Sub

        Public Function Remover(id As Integer) As Boolean
            Dim existente As T = BuscarPorId(id)
            If existente Is Nothing Then Return False
            _itens.Remove(existente)
            Return True
        End Function

        Public Function ListarTodos() As IReadOnlyList(Of T)
            Return _itens.AsReadOnly()
        End Function

        ''' <summary>Próximo Id livre (maior Id em uso + 1). Começa em 1.</summary>
        Public Function ProximoId() As Integer
            Dim maior As Integer = 0
            For Each item In _itens
                If item.Id > maior Then maior = item.Id
            Next
            Return maior + 1
        End Function

    End Class
End Namespace
