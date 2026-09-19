Imports Barbex.Excecoes

Namespace Modelos
    ''' <summary>
    ''' Representa um profissional (barbeiro/cabeleireiro).
    ''' Regra de negócio: o percentual de comissão DEVE estar entre 0% e 100%
    ''' — a validação mora no Set da propriedade e lança ComissaoInvalidaException.
    ''' </summary>
    Public Class Profissional
        Implements IIdentificavel

        Private _id As Integer
        Private _nome As String
        Private _especialidade As String
        Private _percentualComissao As Decimal
        Private _foto As Byte()
        Private _ativo As Boolean = True

        Public Sub New()
        End Sub

        Public Sub New(id As Integer, nome As String, especialidade As String,
                       percentualComissao As Decimal, Optional foto As Byte() = Nothing)
            Me.Id = id
            Me.Nome = nome
            Me.Especialidade = especialidade
            Me.PercentualComissao = percentualComissao
            Me.Foto = foto
        End Sub

        Public Property Id As Integer Implements IIdentificavel.Id
            Get
                Return _id
            End Get
            Set(value As Integer)
                If value < 0 Then
                    Throw New ValidacaoException("O Id do profissional não pode ser negativo.")
                End If
                _id = value
            End Set
        End Property

        Public Property Nome As String
            Get
                Return _nome
            End Get
            Set(value As String)
                If String.IsNullOrWhiteSpace(value) Then
                    Throw New ValidacaoException("O nome do profissional é obrigatório.")
                End If
                _nome = value.Trim()
            End Set
        End Property

        Public Property Especialidade As String
            Get
                Return _especialidade
            End Get
            Set(value As String)
                _especialidade = If(value, String.Empty).Trim()
            End Set
        End Property

        ''' <summary>
        ''' Percentual de comissão (0 a 100). REGRA DE NEGÓCIO CHAVE:
        ''' valores fora da faixa lançam ComissaoInvalidaException.
        ''' </summary>
        Public Property PercentualComissao As Decimal
            Get
                Return _percentualComissao
            End Get
            Set(value As Decimal)
                If value < 0D OrElse value > 100D Then
                    Throw New ComissaoInvalidaException(value)
                End If
                _percentualComissao = value
            End Set
        End Property

        Public Property Foto As Byte()
            Get
                Return _foto
            End Get
            Set(value As Byte())
                _foto = value
            End Set
        End Property

        Public ReadOnly Property TemFoto As Boolean
            Get
                Return _foto IsNot Nothing AndAlso _foto.Length > 0
            End Get
        End Property

        Public Property Ativo As Boolean
            Get
                Return _ativo
            End Get
            Set(value As Boolean)
                _ativo = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"{Id} - {Nome} ({Especialidade})"
        End Function

    End Class
End Namespace
