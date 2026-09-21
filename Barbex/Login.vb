Imports System.Drawing.Text

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Colecao de Fontes
        Dim fontesPrivadas As New PrivateFontCollection()

        'Carregamente de OTFs 
        Dim caminhoDaFonte As String = Application.StartupPath & "\Inter-Regular.otf"
        fontesPrivadas.AddFontFile(caminhoDaFonte)

        'Aplicação da fonte
        Label1.Font = New Font(fontesPrivadas.Families(0), 16, FontStyle.Bold)
        Label2.Font = New Font(fontesPrivadas.Families(0), 10, FontStyle.Regular)
        Label3.Font = New Font(fontesPrivadas.Families(0), 14, FontStyle.Regular)
        Label5.Font = New Font(fontesPrivadas.Families(0), 18, FontStyle.Regular)
        Label6.Font = New Font(fontesPrivadas.Families(0), 8, FontStyle.Bold)
        Label7.Font = New Font(fontesPrivadas.Families(0), 8, FontStyle.Bold)
        Button1.Font = New Font(fontesPrivadas.Families(0), 8, FontStyle.Bold)
        TextBox1.Font = New Font(fontesPrivadas.Families(0), 8, FontStyle.Regular)
        TextBox2.Font = New Font(fontesPrivadas.Families(0), 8, FontStyle.Regular)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

End Class