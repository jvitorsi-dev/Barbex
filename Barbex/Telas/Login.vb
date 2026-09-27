Public Class Login

    Private Const emailValido As String = "admin@barbex.com"
    Private Const senhaValida As String = "admin"

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If familiaInter Is Nothing Then
            CarregarFontsDoSistema()
        End If

        AplicarFontesDoForm(
        (Label1, 16, FontStyle.Bold),
        (Label2, 10, FontStyle.Regular),
        (Label3, 14, FontStyle.Regular),
        (Label5, 18, FontStyle.Regular),
        (Label6, 8, FontStyle.Bold),
        (Label7, 8, FontStyle.Bold),
        (Label9, 8, FontStyle.Regular),
        (Label10, 8, FontStyle.Regular),
        (Label11, 16, FontStyle.Regular),
        (Label12, 16, FontStyle.Regular),
        (Label13, 16, FontStyle.Regular),
        (Button1, 8, FontStyle.Bold),
        (TextBox1, 8, FontStyle.Regular),
        (TextBox2, 8, FontStyle.Regular)
    )
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text.Trim().ToLower() = emailValido And TextBox2.Text = senhaValida Then
                MessageBox.Show("Login realizado com sucesso!", "Barbex",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim frmPrincipal As New FormPrincipal()
                frmPrincipal.Show()
                Me.Hide()
            Else
                MessageBox.Show("E-mail ou senha inválidos.", "Barbex",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Clear()
                TextBox2.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao realizar login: " & ex.Message, "Barbex",
                             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
