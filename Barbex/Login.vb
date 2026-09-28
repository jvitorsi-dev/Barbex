Imports System.Drawing.Text

Public Class Login

    Private Const emailValido As String = "admin@barbex.com"
    Private Const senhaValida As String = "admin"


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carrega as fontes só na primeira vez 
        If familiaInter Is Nothing Then
            CarregarFontsDoSistema()
        End If

        'Aplica a fonte 
        AplicarFontesDoForm(
        (Label1, 16, FontStyle.Bold),
        (Label2, 10, FontStyle.Regular),
        (Label3, 14, FontStyle.Regular),
        (Label5, 18, FontStyle.Regular),
        (Label6, 8, FontStyle.Bold),
        (Label7, 8, FontStyle.Bold),
        (Label9, 8, FontStyle.Regular),
        (Label10, 8, FontStyle.Regular),
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label9_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class