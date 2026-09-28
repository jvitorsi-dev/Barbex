CREATE DATABASE Barbex
GO

USE Barbex
GO

CREATE TABLE Cliente (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(120) NOT NULL,
    Telefone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(160) NULL,
    Foto VARBINARY(MAX) NULL
)
GO

CREATE TABLE Profissional (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(120) NOT NULL,
    Especialidade NVARCHAR(80) NULL,
    PercentualComissao DECIMAL(5,2) NOT NULL,
    Foto VARBINARY(MAX) NULL,
    Ativo BIT NOT NULL DEFAULT 1,
    CONSTRAINT CK_Profissional_Comissao CHECK (PercentualComissao BETWEEN 0 AND 100)
)
GO

CREATE TABLE Servico (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(120) NOT NULL,
    Descricao NVARCHAR(400) NULL,
    Preco DECIMAL(10,2) NOT NULL,
    DuracaoMinutos INT NOT NULL,
    Foto VARBINARY(MAX) NULL,
    CONSTRAINT CK_Servico_Preco CHECK (Preco > 0),
    CONSTRAINT CK_Servico_Duracao CHECK (DuracaoMinutos > 0)
)
GO

CREATE TABLE Agendamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdProfissional INT NOT NULL,
    IdServico INT NOT NULL,
    DataHora DATETIME2 NOT NULL,
    Status INT NOT NULL DEFAULT 0,
    PercentualDesconto DECIMAL(5,2) NULL,
    CONSTRAINT FK_Agendamento_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
    CONSTRAINT FK_Agendamento_Profissional FOREIGN KEY (IdProfissional) REFERENCES Profissional(Id),
    CONSTRAINT FK_Agendamento_Servico FOREIGN KEY (IdServico) REFERENCES Servico(Id),
    CONSTRAINT CK_Agendamento_Status CHECK (Status BETWEEN 0 AND 3),
    CONSTRAINT CK_Agendamento_Desconto CHECK (PercentualDesconto BETWEEN 0 AND 100)
)
GO

CREATE TRIGGER TR_Agendamento_Conflito
ON Agendamento
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Profissional NVARCHAR(120);
    DECLARE @Inicio DATETIME2;
    DECLARE @Fim DATETIME2;
    DECLARE @Mensagem NVARCHAR(400);

    SELECT TOP 1
        @Profissional = p.Nome,
        @Inicio = a.DataHora,
        @Fim = DATEADD(MINUTE, s.DuracaoMinutos, a.DataHora)
    FROM inserted i
    INNER JOIN Servico si ON si.Id = i.IdServico
    INNER JOIN Agendamento a ON a.IdProfissional = i.IdProfissional AND a.Id <> i.Id
    INNER JOIN Servico s ON s.Id = a.IdServico
    INNER JOIN Profissional p ON p.Id = i.IdProfissional
    WHERE i.Status <> 3
      AND a.Status <> 3
      AND i.DataHora < DATEADD(MINUTE, s.DuracaoMinutos, a.DataHora)
      AND a.DataHora < DATEADD(MINUTE, si.DuracaoMinutos, i.DataHora);

    IF @Profissional IS NOT NULL
    BEGIN
        SET @Mensagem = N'O profissional ' + @Profissional + N' já possui um agendamento das '
                      + CONVERT(VARCHAR(5), @Inicio, 108) + N' às '
                      + CONVERT(VARCHAR(5), @Fim, 108) + N' neste dia.';

        THROW 50001, @Mensagem, 1;
    END
END
GO

INSERT INTO Profissional (Nome, Especialidade, PercentualComissao) VALUES
('Rafael Souza', 'Corte e barba', 30),
('Bruno Costa', N'Coloração', 25),
('Lucas Almeida', 'Corte infantil', 30)

INSERT INTO Servico (Nome, Descricao, Preco, DuracaoMinutos) VALUES
('Corte masculino', N'Corte clássico com acabamento na máquina e tesoura', 50.00, 30),
('Barba completa', 'Toalha quente e navalha', 40.00, 20),
('Corte + barba', 'Combo de corte e barba', 80.00, 50),
('Sobrancelha', 'Limpeza e desenho na navalha', 15.00, 10),
(N'Pigmentação', N'Pigmentação de barba ou cabelo', 60.00, 40)

INSERT INTO Cliente (Nome, Telefone, Email) VALUES
('Carlos Pereira', '(11) 98765-4321', 'carlos@email.com'),
('Mariana Lima', '(11) 91234-5678', 'mariana@email.com'),
('Pedro Santos', '(11) 99876-1234', NULL)

INSERT INTO Agendamento (IdCliente, IdProfissional, IdServico, DataHora, Status, PercentualDesconto) VALUES
(1, 1, 1, '2026-10-01 09:00', 1, NULL),
(2, 2, 5, '2026-10-01 10:00', 0, 10),
(3, 1, 3, '2026-10-01 14:00', 0, NULL)
GO
