Imports System.Drawing.Text
Imports System.IO

Module ModuloGlobal

    Public caminhoFoto As String

    Public telaDashboardAtual As Dashboard
    Public telaConfiguracoesAtual As ucConfiguracoes

    Public fontesPrivadas As New PrivateFontCollection()
    Public familiaInter As FontFamily
    Public familiaDMSerif As FontFamily

    Sub CarregarFontsDoSistema()
        Try
            Dim pastaFontes As String = Path.Combine(Application.StartupPath, "Recursos", "Fontes")

            fontesPrivadas.AddFontFile(Path.Combine(pastaFontes, "Inter-Regular.otf"))
            fontesPrivadas.AddFontFile(Path.Combine(pastaFontes, "Inter-Bold.otf"))
            fontesPrivadas.AddFontFile(Path.Combine(pastaFontes, "DMSerifDisplay-Regular.ttf"))
            fontesPrivadas.AddFontFile(Path.Combine(pastaFontes, "DMSerifDisplay-Italic.ttf"))

            familiaInter = fontesPrivadas.Families(0)
            familiaDMSerif = fontesPrivadas.Families(1)
        Catch ex As Exception
            MsgBox("Erro ao carregar fontes: " & ex.Message)
        End Try
    End Sub

    Sub AplicarFonte(control As Control, tamanho As Single, estilo As FontStyle)
        control.Font = New Font(familiaInter, tamanho, estilo)
    End Sub

    Sub AplicarFonte(control As Control, tamanho As Single, estilo As FontStyle, familia As FontFamily)
        control.Font = New Font(familia, tamanho, estilo)
    End Sub

    Sub AplicarFontesDoForm(ParamArray controles As (Control, Single, FontStyle)())
        For Each item In controles
            item.Item1.Font = New Font(familiaInter, item.Item2, item.Item3)
        Next
    End Sub

    Sub AplicarFontesDoForm(ParamArray controles As (Control, Single, FontStyle, FontFamily)())
        For Each item In controles
            item.Item1.Font = New Font(item.Item4, item.Item2, item.Item3)
        Next
    End Sub

End Module
