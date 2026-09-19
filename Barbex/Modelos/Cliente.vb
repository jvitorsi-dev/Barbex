Imports System.Text.RegularExpressions
Imports Barbex.Excecoes

Namespace Modelos
    ''' <summary>
    ''' Representa um cliente da barbearia.
    ''' ENCAPSULAMENTO: todos os campos são Private e o acesso acontece
    ''' apenas pelas Properties, que validam os dados no bloco Set.
    ''' </summary>
    Public Class Cliente
        Implements IIdentificavel

        ' ---------- Campos privados (backing fields) ----------
        Private _id As Integer
        Private _nome As String
        Private _telefone As String
        Private _email As String
        Private _foto As Byte()   ' foto em bytes: a Helen converte p/ Base64 na persistência

        ' ---------- Construtores ----------
        Public Sub New()
        End Sub

        Public Sub New(id As Integer, nome As String, telefone As String,
                       Optional email As String = "", Optional foto As Byte() = Nothing)
            Me.Id = id
            Me.Nome = nome
            Me.Telefone = telefone
            Me.Email = email
            Me.Foto = foto
        End Sub

        ' ---------- Properties encapsuladas com validação no Set ----------
        Public Property Id As Integer Implements IIdentificavel.Id
            Get
                Return _id
            End Get
            Set(value As Integer)
                If value < 0 Then
                    Throw New ValidacaoException("O Id do cliente não pode ser negativo.")
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
                    Throw New ValidacaoException("O nome do cliente é obrigatório.")
                End If
                _nome = value.Trim()
            End Set
        End Property

        Public Property Telefone As String
            Get
                Return _telefone
            End Get
            Set(value As String)
                If String.IsNullOrWhiteSpace(value) Then
                    Throw New ValidacaoException("O telefone do cliente é obrigatório.")
                End If
                Dim digitos As String = Regex.Replace(value, "\D", "")
                If digitos.Length < 8 Then
                    Throw New ValidacaoException("Telefone inválido: informe DDD + número (mínimo de 8 dígitos).")
                End If
                _telefone = value.Trim()
            End Set
        End Property

        Public Property Email As String
            Get
                Return _email
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    If Not value.Contains("@") OrElse Not value.Contains(".") Then
                        Throw New ValidacaoException("E-mail inválido.")
                    End If
                End If
                _email = If(value, String.Empty).Trim()
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

        ''' <summary>True quando há foto carregada (útil para a tela do Gabriel).</summary>
        Public ReadOnly Property TemFoto As Boolean
            Get
                Return _foto IsNot Nothing AndAlso _foto.Length > 0
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{Id} - {Nome}"
        End Function

    End Class
End Namespace
