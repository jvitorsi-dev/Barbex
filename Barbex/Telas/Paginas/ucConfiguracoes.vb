Public Class ucConfiguracoes

    Private ReadOnly corAbaAtiva As Color = Color.FromArgb(54, 42, 20)
    Private ReadOnly corTextoAtivo As Color = Color.FromArgb(230, 168, 62)
    Private ReadOnly corAbaPadrao As Color = Color.FromArgb(28, 28, 30)
    Private ReadOnly corTextoPadrao As Color = Color.Silver

    Private Sub ucConfiguracoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarAba(pnlBarbearia, btnTabBarbearia)
    End Sub

    Private Sub btnTabBarbearia_Click(sender As Object, e As EventArgs) Handles btnTabBarbearia.Click
        MostrarAba(pnlBarbearia, btnTabBarbearia)
    End Sub

    Private Sub btnTabUsuario_Click(sender As Object, e As EventArgs) Handles btnTabUsuario.Click
        MostrarAba(pnlUsuario, btnTabUsuario)
    End Sub

    Private Sub btnTabNotificacoes_Click(sender As Object, e As EventArgs) Handles btnTabNotificacoes.Click
        MostrarAba(pnlNotificacoes, btnTabNotificacoes)
    End Sub

    Private Sub MostrarAba(aba As Panel, botaoAtivo As Button)
        pnlBarbearia.Visible = False
        pnlUsuario.Visible = False
        pnlNotificacoes.Visible = False

        aba.Visible = True
        aba.BringToFront()

        For Each btn As Button In {btnTabBarbearia, btnTabUsuario, btnTabNotificacoes}
            btn.BackColor = corAbaPadrao
            btn.ForeColor = corTextoPadrao
        Next
        botaoAtivo.BackColor = corAbaAtiva
        botaoAtivo.ForeColor = corTextoAtivo
    End Sub

End Class
