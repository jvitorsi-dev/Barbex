Imports System.Configuration
Imports System.Data.SqlClient

Namespace Persistencia
    Public NotInheritable Class Conexao

        Public Const NomeConnectionString As String = "Barbex"

        Private Const StringPadrao As String =
            "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Barbex;Integrated Security=True"

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property StringConexao As String
            Get
                Dim cfg As ConnectionStringSettings =
                    ConfigurationManager.ConnectionStrings(NomeConnectionString)

                If cfg Is Nothing OrElse String.IsNullOrWhiteSpace(cfg.ConnectionString) Then
                    Return StringPadrao
                End If
                Return cfg.ConnectionString
            End Get
        End Property

        Public Shared Function CriarConexao() As SqlConnection
            Return New SqlConnection(StringConexao)
        End Function

        Public Shared Function TestarConexao() As Boolean
            Try
                Using cn As SqlConnection = CriarConexao()
                    cn.Open()
                    Return True
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
