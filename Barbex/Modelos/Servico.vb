Imports Barbex.Excecoes

Namespace Modelos
    ''' <summary>
    ''' Representa um serviço oferecido (corte, barba, coloração...).
    ''' A duração em minutos é usada para calcular o horário de término
    ''' do atendimento e detectar conflitos de agenda.
    ''' </summary>
    Public Class Servico
        Implements IIdentificavel

        Private _id As Integer
        Private _nome As String
        Private _descricao As String
        Private _preco As Decimal
        Private _duracaoMinutos As Integer
        Private _foto As Byte()   ' imagem ilustrativa do serviço (exibida no DataGridView)

        Public Sub New()
        End Sub

        Public Sub New(id As Integer, nome As String, descricao As String,
                       preco As Decimal, duracaoMinutos As Integer, Optional foto As Byte() = Nothing)
            Me.Id = id
            Me.Nome = nome
            Me.Descricao = descricao
            Me.Preco = preco
            Me.DuracaoMinutos = duracaoMinutos
            Me.Foto = foto
        End Sub

        Public Property Id As Integer Implements IIdentificavel.Id
            Get
                Return _id
            End Get
            Set(value As Integer)
                If value < 0 Then
                    Throw New ValidacaoException("O Id do serviço não pode ser negativo.")
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
                    Throw New ValidacaoException("O nome do serviço é obrigatório.")
                End If
                _nome = value.Trim()
            End Set
        End Property

        Public Property Descricao As String
            Get
                Return _descricao
            End Get
            Set(value As String)
                _descricao = If(value, String.Empty).Trim()
            End Set
        End Property

        Public Property Preco As Decimal
            Get
                Return _preco
            End Get
            Set(value As Decimal)
                If value <= 0D Then
                    Throw New ValidacaoException("O preço do serviço deve ser maior que zero.")
                End If
                _preco = value
            End Set
        End Property

        Public Property DuracaoMinutos As Integer
            Get
                Return _duracaoMinutos
            End Get
            Set(value As Integer)
                If value <= 0 Then
                    Throw New ValidacaoException("A duração do serviço deve ser maior que zero minutos.")
                End If
                _duracaoMinutos = value
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

        Public Overrides Function ToString() As String
            Return $"{Nome} ({DuracaoMinutos} min - {Preco:C2})"
        End Function

    End Class
End Namespace
