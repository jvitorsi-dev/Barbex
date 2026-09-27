Imports System.Configuration
Imports System.Data.SqlClient

Namespace Persistencia

    ''' <summary>
    ''' Classe de conexão do Barbex com o SQL Server.
    ''' Guarda a string de conexão (lida do App.config) e entrega conexões prontas.
    ''' É o único lugar do sistema que sabe "onde" está o banco.
    ''' </summary>
    ''' <remarks>
    ''' Referências necessárias no projeto:
    '''   System.Data  e  System.Configuration
    '''   (Project → Add Reference → Assemblies → Framework)
    ''' </remarks>
    Public NotInheritable Class Conexao

        ''' <summary>Nome da connection string procurada no App.config.</summary>
        Public Const NomeConnectionString As String = "Barbex"

        ''' <summary>Usada se o App.config não tiver a connection string.</summary>
        Private Const StringPadrao As String =
            "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Barbex;Integrated Security=True"

        Private Sub New()
        End Sub

        ''' <summary>String de conexão em uso.</summary>
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

        ''' <summary>Devolve uma conexão fechada. Use sempre dentro de Using.</summary>
        Public Shared Function CriarConexao() As SqlConnection
            Return New SqlConnection(StringConexao)
        End Function

        ''' <summary>True se conseguir abrir e fechar a conexão com o banco.</summary>
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
