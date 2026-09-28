Imports System.Reflection.Emit

Public Class Dashboard

    Private ReadOnly corTextoSelecionado As Color = Color.FromArgb(230, 168, 62)
    Private ReadOnly corFundoSelecionado As Color = Color.FromArgb(54, 42, 20)
    Private ReadOnly corTextoPadrao As Color = Color.FromArgb(190, 190, 190)
    Private ReadOnly corFundoPadrao As Color = Color.FromArgb(20, 20, 20)

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carrega as fontes só na primeira vez que o programa inicia
        If familiaInter Is Nothing Then
            CarregarFontsDoSistema()
        End If

        'Aplica fonte
        AplicarFontesDoForm(
            (Label3, 14, FontStyle.Regular, familiaDMSerif)
        )

        ' Tela inicial 
        AbrirTela(New ucAgendamentos(), btnAgendamentos)
    End Sub

    Private Sub btnAgendamentos_Click(sender As Object, e As EventArgs) Handles btnAgendamentos.Click
        AbrirTela(New ucAgendamentos(), btnAgendamentos)
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        AbrirTela(New ucCLientes(), btnClientes)
    End Sub

    Private Sub btnProfissionais_Click(sender As Object, e As EventArgs) Handles btnProfissionais.Click
        AbrirTela(New ucProfissionais(), btnProfissionais)
    End Sub

    Private Sub btnServicos_Click(sender As Object, e As EventArgs) Handles btnServicos.Click
        AbrirTela(New ucServicos(), btnServicos)
    End Sub


    Private Sub AbrirTela(tela As UserControl, botaoAtivo As Button)
        Try
            ' Libera os controles antigos antes de trocar
            For Each ctrl As Control In pnlConteudo.Controls
                ctrl.Dispose()
            Next
            pnlConteudo.Controls.Clear()

            tela.Dock = DockStyle.Fill
            pnlConteudo.Controls.Add(tela)

            ' Reseta a cor 
            For Each ctrl As Control In pnlsidebar.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.BackColor = corFundoPadrao
                    ctrl.ForeColor = corTextoPadrao
                End If
            Next

            ' Destaca o botão da tela que acabou de abrir
            botaoAtivo.BackColor = corFundoSelecionado
            botaoAtivo.ForeColor = corTextoSelecionado

        Catch ex As Exception
            MsgBox("Erro ao abrir a tela: " & ex.Message, MsgBoxStyle.Critical, "Atenção")
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlConteudo_Paint(sender As Object, e As PaintEventArgs) Handles pnlConteudo.Paint

    End Sub
End Class