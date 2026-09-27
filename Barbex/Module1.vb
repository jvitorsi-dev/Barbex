Imports System.Drawing.Text

Module Module1

    ' Guarda o caminho da foto atualmente selecionada/carregada
    Public caminhoFoto As String

    ' Guarda a referência da instância do Dashboard que está ativa na tela
    Public telaDashboardAtual As Dashboard
    Public telaConfiguracoesAtual As ucConfiguracoes

    ' Coleção de fontes
    Public fontesPrivadas As New PrivateFontCollection()
    Public familiaInter As FontFamily
    Public familiaDMSerif As FontFamily

    Sub CarregarFontsDoSistema()
        Try
            Dim caminhoRegular As String = Application.StartupPath & "\Inter-Regular.otf"
            Dim caminhoBold As String = Application.StartupPath & "\Inter-Bold.otf"
            Dim caminhoDMSerifRegular As String = Application.StartupPath & "\DMSerifDisplay-Regular.ttf"
            Dim caminhoDMSerifItalic As String = Application.StartupPath & "\DMSerifDisplay-Italic.ttf"

            fontesPrivadas.AddFontFile(caminhoRegular)
            fontesPrivadas.AddFontFile(caminhoBold)
            fontesPrivadas.AddFontFile(caminhoDMSerifRegular)
            fontesPrivadas.AddFontFile(caminhoDMSerifItalic)

            familiaInter = fontesPrivadas.Families(0)
            familiaDMSerif = fontesPrivadas.Families(1)
        Catch ex As Exception
            MsgBox("Erro ao carregar fontes: " & ex.Message)
        End Try
    End Sub

    ' Aplica a fonte a qualquer controle (padrão: Inter)
    Sub AplicarFonte(control As Control, tamanho As Single, estilo As FontStyle)
        control.Font = New Font(familiaInter, tamanho, estilo)
    End Sub

    ' Aplica a fonte a um controle, com família específica
    Sub AplicarFonte(control As Control, tamanho As Single, estilo As FontStyle, familia As FontFamily)
        control.Font = New Font(familia, tamanho, estilo)
    End Sub

    ' Aplica fontes em vários controles — versão original (usa Inter), continua igual
    Sub AplicarFontesDoForm(ParamArray controles As (Control, Single, FontStyle)())
        For Each item In controles
            item.Item1.Font = New Font(familiaInter, item.Item2, item.Item3)
        Next
    End Sub

    ' Sobrecarga NOVA: mesma ideia, mas permite escolher a família por controle
    Sub AplicarFontesDoForm(ParamArray controles As (Control, Single, FontStyle, FontFamily)())
        For Each item In controles
            item.Item1.Font = New Font(item.Item4, item.Item2, item.Item3)
        Next
    End Sub

End Module
