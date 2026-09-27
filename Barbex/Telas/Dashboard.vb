Public Class Dashboard

    Private ReadOnly corTextoSelecionado As Color = Color.FromArgb(230, 168, 62)
    Private ReadOnly corFundoSelecionado As Color = Color.FromArgb(54, 42, 20)
    Private ReadOnly corTextoPadrao As Color = Color.FromArgb(190, 190, 190)
    Private ReadOnly corFundoPadrao As Color = Color.FromArgb(20, 20, 20)

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If familiaInter Is Nothing Then
            CarregarFontsDoSistema()
        End If

        AplicarFontesDoForm(
            (Label3, 14, FontStyle.Regular, familiaDMSerif)
        )

        AbrirTela(New ucAgendamentos(), btnAgendamentos)
    End Sub

    Private Sub btnAgendamentos_Click(sender As Object, e As EventArgs) Handles btnAgendamentos.Click
        AbrirTela(New ucAgendamentos(), btnAgendamentos)
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        AbrirTela(New ucClientes(), btnClientes)
    End Sub

    Private Sub btnProfissionais_Click(sender As Object, e As EventArgs) Handles btnProfissionais.Click
        AbrirTela(New ucProfissionais(), btnProfissionais)
    End Sub

    Private Sub btnServicos_Click(sender As Object, e As EventArgs) Handles btnServicos.Click
        AbrirTela(New ucServicos(), btnServicos)
    End Sub

    Private Sub btnConfiguracoes_Click(sender As Object, e As EventArgs) Handles btnConfiguracoes.Click
        Dim tela As New ucConfiguracoes()
        telaConfiguracoesAtual = tela
        AbrirTela(tela, btnConfiguracoes)
    End Sub

    Private Sub AbrirTela(tela As UserControl, botaoAtivo As Button)
        Try
            For Each ctrl As Control In pnlConteudo.Controls
                ctrl.Dispose()
            Next
            pnlConteudo.Controls.Clear()

            tela.Dock = DockStyle.Fill
            pnlConteudo.Controls.Add(tela)

            For Each ctrl As Control In pnlsidebar.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.BackColor = corFundoPadrao
                    ctrl.ForeColor = corTextoPadrao
                End If
            Next

            botaoAtivo.BackColor = corFundoSelecionado
            botaoAtivo.ForeColor = corTextoSelecionado

        Catch ex As Exception
            MsgBox("Erro ao abrir a tela: " & ex.Message, MsgBoxStyle.Critical, "Atenção")
        End Try
    End Sub

End Class
