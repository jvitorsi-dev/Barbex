Public Class FormPrincipal

    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1366, 768)   ' tamanho inicial só de fallback, caso Maximized não "pegue" no load
        Me.WindowState = FormWindowState.Maximized

        Dim dash As New Dashboard()
        dash.Dock = DockStyle.Fill
        Me.Controls.Add(dash)
    End Sub

End Class