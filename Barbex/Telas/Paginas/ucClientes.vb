Imports System.Linq
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio
Imports System.IO

Public Class ucCLientes

    Public Sub New()
        InitializeComponent()
    End Sub

    Private barbearia As GerenciadorBarbearia = GerenciadorBarbearia.Instancia
    Private bsClientes As New BindingSource()
    Private idAtual As Integer = 0
    Private fotoSelecionada As Byte()


    Private ReadOnly caminhoFotoPadrao As String = Application.StartupPath & "\fotos\SemFoto.png"

    Private Sub ucCLientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCLientes.AutoGenerateColumns = False ' só as colunas definidas na mão aparecem na tabela — Foto nunca entra aqui
        dgvCLientes.DataSource = bsClientes
        cboCampoBusca.Items.Clear()
        cboCampoBusca.Items.AddRange({"Nome", "Telefone", "E-mail"})
        cboCampoBusca.SelectedIndex = 0
        picFoto.Image = BytesParaImagem(Nothing)
        AtualizarGrid()
    End Sub

    Private Sub dgvClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCLientes.SelectionChanged
        If dgvCLientes.CurrentRow Is Nothing OrElse dgvCLientes.CurrentRow.DataBoundItem Is Nothing Then Return
        Dim cliente As Cliente = DirectCast(dgvCLientes.CurrentRow.DataBoundItem, Cliente)
        idAtual = cliente.Id
        txtNome.Text = cliente.Nome
        txtTelefone.Text = cliente.Telefone
        txtEmail.Text = cliente.Email
        fotoSelecionada = cliente.Foto
        picFoto.Image = BytesParaImagem(fotoSelecionada)
    End Sub

    Private Sub picFoto_Click(sender As Object, e As EventArgs) Handles picFoto.Click
        Try
            With ofdFoto
                If .ShowDialog() = DialogResult.OK Then
                    fotoSelecionada = File.ReadAllBytes(.FileName)
                    picFoto.Image = BytesParaImagem(fotoSelecionada)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Não foi possível carregar a foto: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function BytesParaImagem(bytes As Byte()) As Image
        If bytes Is Nothing OrElse bytes.Length = 0 Then
            Try
                Return Image.FromFile(caminhoFotoPadrao)
            Catch
                Return Nothing
            End Try
        End If
        Dim ms As New MemoryStream(bytes)
        Return Image.FromStream(ms)
    End Function

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        LimparFormulario()
    End Sub

    Private Sub LimparFormulario()
        idAtual = 0
        txtNome.Clear()
        txtTelefone.Clear()
        txtEmail.Clear()
        fotoSelecionada = Nothing
        picFoto.Image = BytesParaImagem(Nothing)
        dgvCLientes.ClearSelection()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim cliente As New Cliente(idAtual, txtNome.Text, txtTelefone.Text, txtEmail.Text, fotoSelecionada)
            If idAtual = 0 Then
                barbearia.CadastrarCliente(cliente)
                MessageBox.Show("Cliente cadastrado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                barbearia.AtualizarCliente(cliente)
                MessageBox.Show("Cliente atualizado com sucesso!", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            LimparFormulario()
        Catch ex As BarbexException
            MessageBox.Show(ex.Message, "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Erro inesperado: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            AtualizarGrid()
        End Try
    End Sub

    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click
        If idAtual = 0 Then
            MessageBox.Show("Selecione um cliente na lista para remover.", "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim resposta = MessageBox.Show("Deseja realmente remover este cliente?", "Confirmar remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resposta <> DialogResult.Yes Then Return
        Try
            barbearia.RemoverCliente(idAtual)
            LimparFormulario()
        Catch ex As BarbexException
            MessageBox.Show(ex.Message, "Erro ao remover", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Erro inesperado: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            AtualizarGrid()
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        AtualizarGrid()
    End Sub

    Private Sub AtualizarGrid()
        Try
            Dim termo As String = txtBusca.Text.Trim()
            Dim lista = barbearia.ListarClientes().ToList()

            If Not String.IsNullOrEmpty(termo) Then
                Dim campo As String = If(cboCampoBusca.SelectedItem IsNot Nothing, cboCampoBusca.SelectedItem.ToString(), "Nome")
                lista = lista.Where(Function(c)
                                        Dim valor As String = c.Nome
                                        If campo = "Telefone" Then valor = c.Telefone
                                        If campo = "E-mail" Then valor = c.Email
                                        Return valor IsNot Nothing AndAlso valor.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0
                                    End Function).ToList()
            End If

            bsClientes.DataSource = lista
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar clientes: " & ex.Message, "Barbex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCLientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCLientes.CellContentClick

    End Sub
End Class