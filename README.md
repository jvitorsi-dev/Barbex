# Barbex — Camada de Negócio (entregas do João)

Arquitetura, modelagem POO, regras de negócio e exceções personalizadas do
sistema de agendamento de barbearia. **Código testado e compilado com
`Option Strict On`, zero erros/warnings, alvo .NET Framework 4.7.2.**

## Estrutura de pastas

```
Barbex/
├── Excecoes/
│   ├── BarbexException.vb              ← base de todas as exceções do sistema
│   ├── ValidacaoException.vb           ← erros de validação de dados
│   ├── ComissaoInvalidaException.vb    ← comissão fora de 0–100%
│   ├── DescontoInvalidoException.vb    ← desconto fora de 0–100%
│   └── HorarioOcupadoException.vb      ← conflito de horário do profissional
├── Modelos/
│   ├── IIdentificavel.vb               ← interface das entidades (Id)
│   ├── StatusAgendamento.vb            ← enum: Pendente/Confirmado/Concluido/Cancelado
│   ├── Cliente.vb
│   ├── Profissional.vb
│   ├── Servico.vb
│   ├── Agendamento.vb                  ← classe BASE (métodos Overridable)
│   └── AgendamentoComDesconto.vb       ← HERDA de Agendamento (Overrides)
├── Negocio/
│   ├── Repositorio.vb                  ← CRUD genérico em memória (Of T)
│   └── GerenciadorBarbearia.vb         ← fachada: CRUD + regras + relatórios
└── Testes/
    └── ModuloTestes.vb                 ← bateria de testes (projeto CONSOLE)
```

## Diagrama da hierarquia

```
System.Exception
└── BarbexException
    ├── ValidacaoException
    │   ├── ComissaoInvalidaException
    │   └── DescontoInvalidoException
    └── HorarioOcupadoException

IIdentificavel (interface)
├── Cliente
├── Profissional
├── Servico
└── Agendamento  ──Inherits──>  AgendamentoComDesconto
     • CalcularValorTotal()  Overridable → Overrides (aplica desconto)
     • CalcularComissao()    Overridable → Overrides (comissão s/ valor c/ desconto)
     • Resumo()              Overridable → Overrides (marca o desconto)
     • ConflitaCom(outro)    ← regra de sobreposição de intervalos
```

## Mapa da rubrica (onde está cada conceito de POO)

| Requisito                                    | Onde está |
|----------------------------------------------|-----------|
| Encapsulamento (campos Private + Property)   | `Cliente`, `Profissional`, `Servico`, `Agendamento` |
| Validação no `Set`                           | `Profissional.PercentualComissao` (0–100%), `Servico.Preco`/`DuracaoMinutos` (> 0), `Cliente.Nome/Telefone/Email` |
| Herança                                      | `AgendamentoComDesconto Inherits Agendamento`; hierarquia de exceções |
| Polimorfismo (Overridable/Overrides)         | `CalcularValorTotal`, `CalcularComissao`, `Resumo` — usados de forma polimórfica nos relatórios do `GerenciadorBarbearia` |
| Exceções personalizadas + hierarquia         | pasta `Excecoes/` (5 classes) |
| Conflito de horários por profissional        | `Agendamento.ConflitaCom` + `GerenciadorBarbearia.Agendar/EncontrarConflito` (sobreposição de intervalo: `A.início < B.fim AndAlso B.início < A.fim`) |
| Bônus: interface + generics                  | `IIdentificavel`, `Repositorio(Of T As IIdentificavel)` |
| Fotos prontas p/ persistência                | `Foto As Byte()` nas 3 entidades (serializa em Base64 automaticamente em JSON/XML) |

## Como colocar no projeto (Visual Studio)

1. **File → New → Project → "Windows Forms App (.NET Framework)" — Visual Basic**
   - Nome: **Barbex** (o Root Namespace será `Barbex`; se usar outro nome,
     ajuste as linhas `Imports Barbex.*` no topo dos arquivos)
   - Framework: **.NET Framework 4.7.2**
2. No Solution Explorer, botão direito no projeto → **Add → New Folder** e crie
   as pastas `Excecoes`, `Modelos` e `Negocio`.
3. Arraste os arquivos `.vb` para as pastas correspondentes
   (ou clique com o direito → **Add → Existing Item...**).
4. Em *Project Properties → Compile*: ligue **Option Strict On** (boa prática).
5. **NÃO** adicione `Testes/ModuloTestes.vb` ao projeto Windows Forms
   (ele tem um `Sub Main` de console). Para rodar os testes, veja a seção abaixo.
6. Compile (Ctrl+Shift+B) — não requer nenhuma dependência externa/NuGet.

### Rodando a bateria de testes

1. Botão direito na **solução** → Add → New Project →
   **"Console App (.NET Framework)"** chamado `Barbex.Testes`.
2. Nesse projeto: Add → Existing Item → selecione `Testes/ModuloTestes.vb`
   (dica: use "Add As Link" para não duplicar o arquivo).
3. `Barbex.Testes` → Add Reference → Projects → marque **Barbex**.
4. Botão direito em `Barbex.Testes` → **Set as Startup Project** → F5.

## Como o Gabriel consome (UI / Windows Forms)

```vb
Imports Barbex.Excecoes
Imports Barbex.Modelos
Imports Barbex.Negocio

' No Form (campo da classe): uma única instância compartilhada
Private barbearia As New GerenciadorBarbearia()

' ComboBoxes exibem Nome/Preço sozinhas (ToString já foi sobrescrito):
cboProfissional.DataSource = barbearia.ListarProfissionais().ToList()

' Botão Agendar — todo fluxo protegido por Try...Catch...Finally:
Private Sub btnAgendar_Click(sender As Object, e As EventArgs) Handles btnAgendar.Click
    Try
        Dim ag As New AgendamentoComDesconto(0,
            DirectCast(cboCliente.SelectedItem, Cliente),
            DirectCast(cboProfissional.SelectedItem, Profissional),
            DirectCast(cboServico.SelectedItem, Servico),
            dtpDataHora.Value,
            nudDesconto.Value)
        barbearia.Agendar(ag)
        MessageBox.Show("Agendado com sucesso!", "Barbex",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    Catch ex As HorarioOcupadoException
        MessageBox.Show(ex.Message, "Horário indisponível",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Catch ex As BarbexException      ' captura QUALQUER erro de negócio
        MessageBox.Show(ex.Message, "Dados inválidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Finally
        AtualizarGrid()              ' recarrega o DataGridView sempre
    End Try
End Sub
```

- Id `0` no agendamento/cadastro = o gerenciador gera o Id automaticamente.
- `ListarAgendamentos(data)`, `ListarAgendamentosPorProfissional(id)` e
  `Listar*()` alimentam o `DataGridView` (idealmente via `BindingSource`).

## Como a Helen consome (persistência)

- As entidades têm **somente membros públicos serializáveis** e
  `Foto As Byte()` — JSON (Newtonsoft) e XML (DataContract/XmlSerializer)
  convertem `Byte()` ⇄ Base64 automaticamente; o helper
  `ImageToByteArray/ByteArrayToImage` dela só precisa cuidar de `Image` ⇄ `Byte()`.
- Ciclo de persistência sugerido: **salvar** = serializar as listas de
  `ListarClientes/Profissionais/Servicos/Agendamentos`; **carregar** =
  desserializar e reinserir via `Cadastrar*`/`Agendar` (Ids informados são
  preservados; só gera Id novo quando vier `0`).
- Relatórios prontos: `CalcularFaturamento(data)` e
  `CalcularComissaoProfissional(idProf, inicio, fim)` — ambos usam os métodos
  **polimórficos**, então descontos entram corretamente nas contas.

## Prova dos testes (saída real da bateria)

```
===== BARBEX - Testes da camada de negócio (João) =====

Cadastros OK: 1 cliente(s), 2 profissional(is), 2 serviço(s).

Agendado: [Pendente] 21/09/2026 10:00 - Carlos Souza com Rafael Barbeiro (Corte masculino) = R$ 50,00
   Valor: R$ 50,00 | Comissão: R$ 15,00

EXCEÇÃO ESPERADA (HorarioOcupadoException):
   O profissional Rafael Barbeiro já possui um agendamento das 10:00 às 10:30 neste dia.

Sem conflito para outro profissional: [Pendente] 21/09/2026 10:15 - Carlos Souza com Bruno Costa (Barba completa) = R$ 40,00

EXCEÇÃO ESPERADA (ComissaoInvalidaException):
   Comissão inválida: 150%. A comissão deve estar entre 0% e 100%.

EXCEÇÃO ESPERADA (DescontoInvalidoException):
   Desconto inválido: 120%. O desconto deve estar entre 0% e 100%.

CAPTURADO PELA EXCEÇÃO BASE (BarbexException):
   O nome do cliente é obrigatório.

--- POLIMORFISMO (Overrides em ação) ---
[Pendente] 21/09/2026 10:00 - ... (Corte masculino) = R$ 50,00
   Valor final: R$ 50,00 | Comissão: R$ 15,00
[Pendente] 21/09/2026 14:00 - ... (Corte masculino) = R$ 45,00 (desconto de 10%)
   Valor final: R$ 45,00 | Comissão: R$ 11,25

Agendamentos em 21/09/2026: 3
Faturamento previsto: R$ 135,00
Comissão do Rafael Barbeiro: R$ 15,00
Comissão do Bruno Costa: R$ 21,25
```

## Checklist do roadmap (parte do João)

- [x] **Fase 1** — Estrutura da solução + classes de modelo com Properties
       encapsuladas e validações no `Set`
- [x] **Fase 2** — Herança/polimorfismo em `Agendamento`/`AgendamentoComDesconto`,
       cálculo de comissão/desconto e checagem de conflitos
- [x] **Fase 3** — Exceções personalizadas (`HorarioOcupadoException`,
       `ComissaoInvalidaException`, `DescontoInvalidoException`, ...) com hierarquia
- [ ] **Fase 4** — Envolver os fluxos dos formulários em `Try...Catch...Finally`
       (fazer em parceria com o Gabriel — modelo de código na seção acima)
