# Barbex

Sistema desktop para gerenciar os agendamentos de uma barbearia: clientes, profissionais, serviços e horários.

Feito em VB.NET com Windows Forms (.NET Framework 4.7.2) e SQL Server.

## Estrutura

```
Barbex/
├── Excecoes/       exceções do sistema
├── Modelos/        Cliente, Profissional, Servico, Agendamento...
├── Negocio/        GerenciadorBarbearia (regras de negócio e relatórios)
├── Persistencia/   conexão com o banco e repositório
├── Recursos/
│   └── Fontes/     Inter e DM Serif Display
├── Telas/          Login, FormPrincipal e Dashboard
│   └── Paginas/    agendamentos, clientes, profissionais, serviços e configurações
├── Testes/         testes da camada de negócio
└── Utilitarios/    fontes e variáveis globais
Banco/              script de criação do banco
Imagens/            logo e fotos da equipe
```

## Como rodar

1. Rode o script `Banco/Barbex.sql` no SQL Server (pelo SSMS ou pelo
   SQL Server Object Explorer do Visual Studio). Ele cria o banco, as tabelas
   e já insere alguns dados de exemplo.
2. Abra o `Barbex.slnx` no Visual Studio.
3. Confira a conexão com o banco. Por padrão o sistema usa
   `(localdb)\MSSQLLocalDB` com o banco `Barbex`. Para usar outro servidor,
   adicione uma connection string chamada `Barbex` no `App.config`.
4. Rode o projeto (F5).

Login padrão: `admin@barbex.com` / `admin`

## Funcionalidades

- Cadastro de clientes, profissionais e serviços
- Agendamento com verificação de conflito de horário por profissional
- Desconto por agendamento
- Cálculo de comissão e faturamento do dia

## Equipe

- João
- Gabriel
- Helen
