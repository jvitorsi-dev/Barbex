Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

Namespace Testes
    ''' <summary>
    ''' Bateria de testes da camada de negócio do João.
    ''' Prova o CRUD, a regra de conflito de horários, as validações e o
    ''' polimorfismo ANTES de a tela do Gabriel existir.
    '''
    ''' COMO USAR: crie um projeto "Aplicativo de Console (.NET Framework)"
    ''' chamado Barbex.Testes na mesma solução, referencie o projeto Barbex
    ''' e adicione ESTE arquivo nele (não no projeto Windows Forms).
    ''' </summary>
    Module ModuloTestes

        Sub Main()
            Console.OutputEncoding = Encoding.UTF8
            Console.WriteLine("===== BARBEX - Testes da camada de negócio (João) =====" & vbCrLf)

            Dim barbearia As New GerenciadorBarbearia()

            ' ----------------------------------------------------------
            ' 1) CADASTROS BÁSICOS (CRUD)
            ' ----------------------------------------------------------
            Dim rafael As New Profissional(1, "Rafael Barbeiro", "Corte e barba", 30D)
            Dim bruno As New Profissional(2, "Bruno Costa", "Coloração", 25D)
            barbearia.CadastrarProfissional(rafael)
            barbearia.CadastrarProfissional(bruno)

            Dim corte As New Servico(1, "Corte masculino", "Corte clássico com acabamento", 50D, 30)
            Dim barba As New Servico(2, "Barba completa", "Toalha quente e navalha", 40D, 20)
            barbearia.CadastrarServico(corte)
            barbearia.CadastrarServico(barba)

            Dim cliente As New Cliente(1, "Carlos Souza", "(11) 98765-4321", "carlos@email.com")
            barbearia.CadastrarCliente(cliente)

            Console.WriteLine($"Cadastros OK: {barbearia.ListarClientes().Count} cliente(s), " &
                              $"{barbearia.ListarProfissionais().Count} profissional(is), " &
                              $"{barbearia.ListarServicos().Count} serviço(s)." & vbCrLf)

            ' ----------------------------------------------------------
            ' 2) AGENDAMENTO NORMAL
            ' ----------------------------------------------------------
            Dim ag1 As New Agendamento(1, cliente, rafael, corte, New DateTime(2026, 9, 21, 10, 0, 0))
            barbearia.Agendar(ag1)
            Console.WriteLine("Agendado: " & ag1.Resumo())
            Console.WriteLine($"   Valor: {ag1.CalcularValorTotal():C2} | Comissão: {ag1.CalcularComissao():C2}" & vbCrLf)

            ' ----------------------------------------------------------
            ' 3) TESTE: CONFLITO DE HORÁRIO (mesmo profissional, 10:15
            '    cai dentro do atendimento das 10:00 às 10:30)
            ' ----------------------------------------------------------
            Try
                Dim ag2 As New Agendamento(2, cliente, rafael, barba, New DateTime(2026, 9, 21, 10, 15, 0))
                barbearia.Agendar(ag2)
                Console.WriteLine("ERRO: o conflito de horário NÃO foi detectado!")
            Catch ex As HorarioOcupadoException
                Console.WriteLine("EXCEÇÃO ESPERADA (HorarioOcupadoException):" & vbCrLf & "   " & ex.Message & vbCrLf)
            End Try

            ' ----------------------------------------------------------
            ' 4) TESTE: horário livre para OUTRO profissional no mesmo
            '    horário (NÃO pode dar conflito)
            ' ----------------------------------------------------------
            Dim agOk As New Agendamento(4, cliente, bruno, barba, New DateTime(2026, 9, 21, 10, 15, 0))
            barbearia.Agendar(agOk)
            Console.WriteLine("Sem conflito para outro profissional: " & agOk.Resumo() & vbCrLf)

            ' ----------------------------------------------------------
            ' 5) TESTE: COMISSÃO INVÁLIDA (150%)
            ' ----------------------------------------------------------
            Try
                Dim invalido As New Profissional(3, "Teste Comissão", "Nada", 150D)
                Console.WriteLine("ERRO: a comissão inválida NÃO foi bloqueada!")
            Catch ex As ComissaoInvalidaException
                Console.WriteLine("EXCEÇÃO ESPERADA (ComissaoInvalidaException):" & vbCrLf & "   " & ex.Message & vbCrLf)
            End Try

            ' ----------------------------------------------------------
            ' 6) TESTE: DESCONTO INVÁLIDO (120%)
            ' ----------------------------------------------------------
            Try
                Dim agRuim As New AgendamentoComDesconto(5, cliente, bruno, corte,
                                                         New DateTime(2026, 9, 21, 16, 0, 0), 120D)
                Console.WriteLine("ERRO: o desconto inválido NÃO foi bloqueado!")
            Catch ex As DescontoInvalidoException
                Console.WriteLine("EXCEÇÃO ESPERADA (DescontoInvalidoException):" & vbCrLf & "   " & ex.Message & vbCrLf)
            End Try

            ' ----------------------------------------------------------
            ' 7) TESTE: VALIDAÇÃO GENÉRICA capturada pela exceção BASE
            '    (mostra a hierarquia de exceções em ação)
            ' ----------------------------------------------------------
            Try
                Dim semNome As New Cliente(9, "", "(11) 99999-0000")
                Console.WriteLine("ERRO: cliente sem nome NÃO foi bloqueado!")
            Catch ex As BarbexException
                Console.WriteLine("CAPTURADO PELA EXCEÇÃO BASE (BarbexException):" & vbCrLf & "   " & ex.Message & vbCrLf)
            End Try

            ' ----------------------------------------------------------
            ' 8) POLIMORFISMO: mesma lista, chamadas idênticas,
            '    comportamentos diferentes (com e sem desconto)
            ' ----------------------------------------------------------
            Dim ag3 As New AgendamentoComDesconto(3, cliente, bruno, corte,
                                                  New DateTime(2026, 9, 21, 14, 0, 0), 10D)
            barbearia.Agendar(ag3)

            Dim lista As New List(Of Agendamento) From {ag1, ag3}
            Console.WriteLine("--- POLIMORFISMO (Overrides em ação) ---")
            For Each ag As Agendamento In lista
                Console.WriteLine(ag.Resumo())
                Console.WriteLine($"   Valor final: {ag.CalcularValorTotal():C2} | Comissão: {ag.CalcularComissao():C2}")
            Next
            Console.WriteLine()

            ' ----------------------------------------------------------
            ' 9) RELATÓRIOS DO DIA
            ' ----------------------------------------------------------
            Dim dia As Date = New DateTime(2026, 9, 21)
            Console.WriteLine($"Agendamentos em {dia:dd/MM/yyyy}: {barbearia.ListarAgendamentos(dia).Count}")
            Console.WriteLine($"Faturamento previsto: {barbearia.CalcularFaturamento(dia):C2}")
            Console.WriteLine($"Comissão do {rafael.Nome}: {barbearia.CalcularComissaoProfissional(rafael.Id, dia, dia):C2}")
            Console.WriteLine($"Comissão do {bruno.Nome}: {barbearia.CalcularComissaoProfissional(bruno.Id, dia, dia):C2}" & vbCrLf)

            Console.WriteLine("===== FIM DOS TESTES =====")
            If Not Console.IsInputRedirected Then
                Console.ReadKey()
            End If
        End Sub

    End Module
End Namespace
