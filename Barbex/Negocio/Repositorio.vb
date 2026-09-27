Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Persistencia

Namespace Negocio

    ''' <summary>
    ''' Repositório genérico que grava no SQL Server.
    ''' É a mesma classe de antes (Adicionar, BuscarPorId, Atualizar, Remover,
    ''' ListarTodos, ProximoId) com as mesmas assinaturas — só o "dentro" mudou:
    ''' em vez da List(Of T) em memória, agora vai para o banco.
    ''' O GerenciadorBarbearia continua chamando do mesmo jeito.
    ''' </summary>
    Public Class Repositorio(Of T As IIdentificavel)

        ''' <summary>Nome da tabela dessa entidade. Ex.: "dbo.Cliente".</summary>
        Private ReadOnly _tabela As String

        Public Sub New(tabela As String)
            If String.IsNullOrWhiteSpace(tabela) Then
                Throw New ArgumentNullException(NameOf(tabela))
            End If
            _tabela = tabela
        End Sub

        ' ============================================================
        '  CRUD — mesma API da versão em memória
        ' ============================================================

        ''' <summary>
        ''' INSERT. Se o objeto vier com Id = 0, o IDENTITY do banco gera o Id
        ''' e ele é devolvido dentro do próprio objeto (igual ao ProximoId de antes).
        ''' </summary>
        Public Sub Adicionar(item As T)
            If item Is Nothing Then Throw New ArgumentNullException(NameOf(item))

            Try
                Using cn As SqlConnection = Conexao.CriarConexao()
                    Using cmd As New SqlCommand(SqlInserir, cn)
                        PreencherParametros(cmd, item)
                        cn.Open()

                        Dim gerado As Object = cmd.ExecuteScalar()   ' SELECT SCOPE_IDENTITY()
                        If gerado IsNot Nothing AndAlso gerado IsNot DBNull.Value Then
                            DefinirId(item, Convert.ToInt32(gerado))
                        End If
                    End Using
                End Using

            Catch ex As SqlException
                Throw TraduzirErro(ex)
            End Try
        End Sub

        ''' <summary>SELECT por Id. Devolve Nothing se não existir.</summary>
        Public Function BuscarPorId(id As Integer) As T
            Try
                Using cn As SqlConnection = Conexao.CriarConexao()
                    Using cmd As New SqlCommand(SqlSelecionar & " WHERE " & CampoId & " = @Id", cn)
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id
                        cn.Open()

                        Using rd As SqlDataReader = cmd.ExecuteReader()
                            If rd.Read() Then Return Mapear(rd)
                        End Using
                    End Using
                End Using

            Catch ex As SqlException
                Throw TraduzirErro(ex)
            End Try

            Return Nothing
        End Function

        ''' <summary>UPDATE. Lança ValidacaoException se o Id não existir.</summary>
        Public Sub Atualizar(item As T)
            If item Is Nothing Then Throw New ArgumentNullException(NameOf(item))

            Dim linhasAfetadas As Integer = 0

            Try
                Using cn As SqlConnection = Conexao.CriarConexao()
                    Using cmd As New SqlCommand(SqlAtualizar, cn)
                        PreencherParametros(cmd, item)
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = item.Id
                        cn.Open()
                        linhasAfetadas = cmd.ExecuteNonQuery()
                    End Using
                End Using

            Catch ex As SqlException
                Throw TraduzirErro(ex)
            End Try

            If linhasAfetadas = 0 Then
                Throw New ValidacaoException($"Registro com Id {item.Id} não encontrado para atualização.")
            End If
        End Sub

        ''' <summary>DELETE. True se alguma linha foi excluída.</summary>
        Public Function Remover(id As Integer) As Boolean
            Try
                Using cn As SqlConnection = Conexao.CriarConexao()
                    Using cmd As New SqlCommand($"DELETE FROM {_tabela} WHERE Id = @Id", cn)
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id
                        cn.Open()
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using

            Catch ex As SqlException
                Throw TraduzirErro(ex)
            End Try
        End Function

        ''' <summary>SELECT de tudo, na ordem padrão da entidade.</summary>
        Public Function ListarTodos() As IReadOnlyList(Of T)
            Dim lista As New List(Of T)()

            Try
                Using cn As SqlConnection = Conexao.CriarConexao()
                    Using cmd As New SqlCommand($"{SqlSelecionar} ORDER BY {OrdemPadrao}", cn)
                        cn.Open()

                        Using rd As SqlDataReader = cmd.ExecuteReader()
                            While rd.Read()
                                lista.Add(Mapear(rd))
                            End While
                        End Using
                    End Using
                End Using

            Catch ex As SqlException
                Throw TraduzirErro(ex)
            End Try

            Return lista.AsReadOnly()
        End Function

        ''' <summary>Próximo Id livre (maior Id + 1), igual à versão em memória.</summary>
        Public Function ProximoId() As Integer
            Using cn As SqlConnection = Conexao.CriarConexao()
                Using cmd As New SqlCommand($"SELECT ISNULL(MAX(Id), 0) + 1 FROM {_tabela}", cn)
                    cn.Open()
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        ' ============================================================
        '  SQL de cada entidade (o que muda de uma para outra)
        ' ============================================================

        Private ReadOnly Property SqlSelecionar As String
            Get
                ' Agendamento faz JOIN porque precisa montar Cliente, Profissional e Serviço
                If GetType(T) Is GetType(Agendamento) Then
                    Return "SELECT a.Id, a.IdCliente, a.IdProfissional, a.IdServico, " &
                           "a.DataHora, a.Status, a.PercentualDesconto, " &
                           "c.Nome AS ClienteNome, c.Telefone, c.Email, " &
                           "p.Nome AS ProfissionalNome, p.Especialidade, p.PercentualComissao, " &
                           "s.Nome AS ServicoNome, s.Descricao, s.Preco, s.DuracaoMinutos " &
                           "FROM dbo.Agendamento a " &
                           "INNER JOIN dbo.Cliente c ON c.Id = a.IdCliente " &
                           "INNER JOIN dbo.Profissional p ON p.Id = a.IdProfissional " &
                           "INNER JOIN dbo.Servico s ON s.Id = a.IdServico"
                End If

                Return $"SELECT * FROM {_tabela}"
            End Get
        End Property

        Private ReadOnly Property CampoId As String
            Get
                Return If(GetType(T) Is GetType(Agendamento), "a.Id", "Id")
            End Get
        End Property

        Private ReadOnly Property OrdemPadrao As String
            Get
                If GetType(T) Is GetType(Agendamento) Then Return "a.DataHora"
                Return "Nome"
            End Get
        End Property

        Private ReadOnly Property SqlInserir As String
            Get
                If GetType(T) Is GetType(Cliente) Then
                    Return "INSERT INTO dbo.Cliente (Nome, Telefone, Email, Foto) " &
                           "VALUES (@Nome, @Telefone, @Email, @Foto); SELECT SCOPE_IDENTITY();"
                End If

                If GetType(T) Is GetType(Profissional) Then
                    Return "INSERT INTO dbo.Profissional (Nome, Especialidade, PercentualComissao, Foto, Ativo) " &
                           "VALUES (@Nome, @Especialidade, @PercentualComissao, @Foto, @Ativo); SELECT SCOPE_IDENTITY();"
                End If

                If GetType(T) Is GetType(Servico) Then
                    Return "INSERT INTO dbo.Servico (Nome, Descricao, Preco, DuracaoMinutos, Foto) " &
                           "VALUES (@Nome, @Descricao, @Preco, @DuracaoMinutos, @Foto); SELECT SCOPE_IDENTITY();"
                End If

                Return "INSERT INTO dbo.Agendamento (IdCliente, IdProfissional, IdServico, DataHora, Status, PercentualDesconto) " &
                       "VALUES (@IdCliente, @IdProfissional, @IdServico, @DataHora, @Status, @PercentualDesconto); " &
                       "SELECT SCOPE_IDENTITY();"
            End Get
        End Property

        Private ReadOnly Property SqlAtualizar As String
            Get
                If GetType(T) Is GetType(Cliente) Then
                    Return "UPDATE dbo.Cliente SET Nome = @Nome, Telefone = @Telefone, " &
                           "Email = @Email, Foto = @Foto WHERE Id = @Id"
                End If

                If GetType(T) Is GetType(Profissional) Then
                    Return "UPDATE dbo.Profissional SET Nome = @Nome, Especialidade = @Especialidade, " &
                           "PercentualComissao = @PercentualComissao, Foto = @Foto, Ativo = @Ativo WHERE Id = @Id"
                End If

                If GetType(T) Is GetType(Servico) Then
                    Return "UPDATE dbo.Servico SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, " &
                           "DuracaoMinutos = @DuracaoMinutos, Foto = @Foto WHERE Id = @Id"
                End If

                Return "UPDATE dbo.Agendamento SET IdCliente = @IdCliente, IdProfissional = @IdProfissional, " &
                       "IdServico = @IdServico, DataHora = @DataHora, Status = @Status, " &
                       "PercentualDesconto = @PercentualDesconto WHERE Id = @Id"
            End Get
        End Property

        ' ============================================================
        '  objeto -> parâmetros  e  DataReader -> objeto
        ' ============================================================

        Private Sub PreencherParametros(cmd As SqlCommand, item As T)

            If TypeOf item Is Cliente Then
                Dim c As Cliente = CType(CObj(item), Cliente)
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 120).Value = c.Nome
                cmd.Parameters.Add("@Telefone", SqlDbType.NVarChar, 20).Value = c.Telefone
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 160).Value = Nulo(c.Email)
                cmd.Parameters.Add("@Foto", SqlDbType.VarBinary, -1).Value = Nulo(c.Foto)
                Return
            End If

            If TypeOf item Is Profissional Then
                Dim p As Profissional = CType(CObj(item), Profissional)
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 120).Value = p.Nome
                cmd.Parameters.Add("@Especialidade", SqlDbType.NVarChar, 80).Value = Nulo(p.Especialidade)
                ParamDecimal(cmd, "@PercentualComissao", p.PercentualComissao)
                cmd.Parameters.Add("@Foto", SqlDbType.VarBinary, -1).Value = Nulo(p.Foto)
                cmd.Parameters.Add("@Ativo", SqlDbType.Bit).Value = p.Ativo
                Return
            End If

            If TypeOf item Is Servico Then
                Dim s As Servico = CType(CObj(item), Servico)
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 120).Value = s.Nome
                cmd.Parameters.Add("@Descricao", SqlDbType.NVarChar, 400).Value = Nulo(s.Descricao)
                ParamDecimal(cmd, "@Preco", s.Preco)
                cmd.Parameters.Add("@DuracaoMinutos", SqlDbType.Int).Value = s.DuracaoMinutos
                cmd.Parameters.Add("@Foto", SqlDbType.VarBinary, -1).Value = Nulo(s.Foto)
                Return
            End If

            ' Agendamento (vale também para AgendamentoComDesconto, que herda dele)
            Dim a As Agendamento = CType(CObj(item), Agendamento)
            cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = a.Cliente.Id
            cmd.Parameters.Add("@IdProfissional", SqlDbType.Int).Value = a.Profissional.Id
            cmd.Parameters.Add("@IdServico", SqlDbType.Int).Value = a.Servico.Id
            cmd.Parameters.Add("@DataHora", SqlDbType.DateTime2).Value = a.DataHora
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = CInt(a.Status)

            If TypeOf a Is AgendamentoComDesconto Then
                ParamDecimal(cmd, "@PercentualDesconto", CType(a, AgendamentoComDesconto).PercentualDesconto)
            Else
                ParamDecimal(cmd, "@PercentualDesconto", Nothing)
            End If
        End Sub

        Private Function Mapear(rd As SqlDataReader) As T

            If GetType(T) Is GetType(Cliente) Then
                Return CType(CObj(New Cliente(CInt(rd("Id")), CStr(rd("Nome")), CStr(rd("Telefone")),
                                              Texto(rd, "Email"), Binario(rd, "Foto"))), T)
            End If

            If GetType(T) Is GetType(Profissional) Then
                Return CType(CObj(New Profissional(CInt(rd("Id")), CStr(rd("Nome")), CStr(rd("Especialidade")),
                                                   CDec(rd("PercentualComissao")), Binario(rd, "Foto")) With {
                                                       .Ativo = CBool(rd("Ativo"))}), T)
            End If

            If GetType(T) Is GetType(Servico) Then
                Return CType(CObj(New Servico(CInt(rd("Id")), CStr(rd("Nome")), CStr(rd("Descricao")),
                                              CDec(rd("Preco")), CInt(rd("DuracaoMinutos")), Binario(rd, "Foto"))), T)
            End If

            ' Agendamento: monta os objetos relacionados a partir do JOIN
            Dim cli As New Cliente(CInt(rd("IdCliente")), Texto(rd, "ClienteNome"),
                                   Texto(rd, "Telefone"), Texto(rd, "Email"))
            Dim prof As New Profissional(CInt(rd("IdProfissional")), Texto(rd, "ProfissionalNome"),
                                        Texto(rd, "Especialidade"), CDec(rd("PercentualComissao")))
            Dim serv As New Servico(CInt(rd("IdServico")), Texto(rd, "ServicoNome"),
                                    Texto(rd, "Descricao"), CDec(rd("Preco")), CInt(rd("DuracaoMinutos")))
            Dim inicio As DateTime = CDate(rd("DataHora"))

            Dim ag As Agendamento
            If rd("PercentualDesconto") Is DBNull.Value Then
                ag = New Agendamento(CInt(rd("Id")), cli, prof, serv, inicio)
            Else
                ' veio com desconto → é a classe filha (herança preservada ao carregar)
                ag = New AgendamentoComDesconto(CInt(rd("Id")), cli, prof, serv, inicio,
                                                CDec(rd("PercentualDesconto")))
            End If
            ag.Status = CType(CInt(rd("Status")), StatusAgendamento)
            Return CType(CObj(ag), T)
        End Function

        ''' <summary>Devolve ao objeto o Id que o IDENTITY do banco gerou.</summary>
        Private Sub DefinirId(item As T, id As Integer)
            If TypeOf item Is Cliente Then
                CType(CObj(item), Cliente).Id = id

            ElseIf TypeOf item Is Profissional Then
                CType(CObj(item), Profissional).Id = id

            ElseIf TypeOf item Is Servico Then
                CType(CObj(item), Servico).Id = id

            ElseIf TypeOf item Is Agendamento Then
                CType(CObj(item), Agendamento).Id = id
            End If
        End Sub

        ' ============================================================
        '  Erros do SQL Server -> exceções do Barbex
        ' ============================================================

        ''' <summary>
        ''' Converte SqlException em exceção do sistema, para a tela continuar
        ''' capturando só BarbexException. Erro 50001 é o conflito de horário
        ''' levantado pela trigger do banco.
        ''' </summary>
        Private Function TraduzirErro(ex As SqlException) As BarbexException
            If ex.Number = 50001 Then
                Dim conflito As HorarioOcupadoException = MontarConflito(ex.Message)
                If conflito IsNot Nothing Then Return conflito
            End If

            Return New ValidacaoException(ex.Message)
        End Function

        ''' <summary>
        ''' Lê a mensagem do erro 50001 (trigger do banco) e monta a
        ''' HorarioOcupadoException com o nome e o intervalo conflitante.
        ''' Ex.: "o profissional Rafael já possui um agendamento das 10:00 às 10:30"
        ''' </summary>
        Private Shared Function MontarConflito(mensagem As String) As HorarioOcupadoException
            Dim nome As Match = Regex.Match(mensagem, "profissional\s+(.+?)\s+\p{L}+\s+possui",
                                            RegexOptions.IgnoreCase)
            Dim horas As Match = Regex.Match(mensagem, "(\d{1,2}:\d{2})\D{1,6}(\d{1,2}:\d{2})")

            If Not nome.Success OrElse Not horas.Success Then Return Nothing

            Return New HorarioOcupadoException(nome.Groups(1).Value.Trim(),
                                               DateTime.Parse(horas.Groups(1).Value),
                                               DateTime.Parse(horas.Groups(2).Value))
        End Function

        ' ============================================================
        '  helpers de leitura/escrita
        ' ============================================================

        Private Shared Function Nulo(valor As Object) As Object
            Return If(valor, CObj(DBNull.Value))
        End Function

        ''' <summary>Parâmetro DECIMAL com escala, para não arredondar centavos.</summary>
        Private Shared Sub ParamDecimal(cmd As SqlCommand, nome As String, valor As Object)
            Dim p As SqlParameter = cmd.Parameters.Add(nome, SqlDbType.Decimal)
            p.Precision = 10
            p.Scale = 2
            p.Value = Nulo(valor)
        End Sub

        ''' <summary>Lê texto que pode estar NULL no banco.</summary>
        Private Shared Function Texto(rd As SqlDataReader, coluna As String) As String
            Dim i As Integer = rd.GetOrdinal(coluna)
            Return If(rd.IsDBNull(i), Nothing, rd.GetString(i))
        End Function

        ''' <summary>Lê a foto (VARBINARY) — Nothing quando não tem imagem.</summary>
        Private Shared Function Binario(rd As SqlDataReader, coluna As String) As Byte()
            Dim i As Integer = rd.GetOrdinal(coluna)
            If rd.IsDBNull(i) Then Return Nothing
            Return DirectCast(rd.GetValue(i), Byte())
        End Function

    End Class

End Namespace
