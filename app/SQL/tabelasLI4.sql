DROP DATABASE leiloes;

CREATE DATABASE leiloes;

USE master;
GO

ALTER DATABASE leiloes
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;
GO

USE master;
GO

DROP DATABASE leiloes;
GO

USE leiloes;

CREATE TABLE Pessoa (
    id INT PRIMARY KEY NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    saldo DECIMAL(9, 2) NOT NULL,
    telemovel INT NOT NULL,
    nickname VARCHAR(50) NOT NULL,
	estado VARCHAR(50) NOT NULL
);

CREATE TABLE Lance (
    id INT PRIMARY KEY NOT NULL,
    id_leilao INT NOT NULL,
    id_licitador INT NOT NULL,
    valor DECIMAL(9, 2),
    FOREIGN KEY (id_licitador) REFERENCES Pessoa(id)
);

CREATE TABLE Leilao (
    id INT PRIMARY KEY NOT NULL,
    id_Criador INT NOT NULL,
	descricao VARCHAR(280),
    precoReserva DECIMAL(9, 2) NOT NULL,
    precoMinimo DECIMAL(9, 2) NOT NULL,
    dataHoraInicial DATETIME NOT NULL,
    duracao INT NOT NULL,
    id_lanceAtual INT,
    id_lanceFinal INT,
    FOREIGN KEY (id_lanceAtual) REFERENCES Lance(id),
	FOREIGN KEY (id_lanceFinal) REFERENCES Lance(id)
);

CREATE TABLE Transacao (
    id INT PRIMARY KEY NOT NULL,
    id_leilao INT NOT NULL,
    id_vendedor INT NOT NULL,
    id_comprador INT NOT NULL,
    data DATETIME,
    valorTransacao DECIMAL(9, 2),
    taxa DECIMAL(9, 2)
);

CREATE TABLE Artigo (
    id INT PRIMARY KEY NOT NULL,
    id_leilao INT,
    id_transacao INT,
    nome VARCHAR(100) NOT NULL,
    condicao VARCHAR(50) NOT NULL,
    raridade VARCHAR(50) NOT NULL,
    caminhoImagem VARCHAR(250),
    tipo VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id),
	FOREIGN KEY (id_leilao) REFERENCES Leilao(id)
);

SELECT * FROM dbo.Pessoa;

SELECT * FROM dbo.Artigo;

SELECT * FROM dbo.Leilao;

-- Leiloes que ainda nao acabaram 
SELECT * FROM Leilao WHERE GETDATE() < dataHoraInicial OR GETDATE() > DATEADD(MINUTE, duracao, dataHoraInicial);

-- Leiloes e as suas skins
SELECT Leilao.*, Artigo.* FROM Leilao LEFT JOIN Artigo ON Leilao.id = Artigo.id_leilao;

DELETE dbo.Pessoa;

DELETE dbo.Leilao;

DELETE dbo.Artigo;

USE leiloes;

INSERT INTO dbo.Pessoa (id, tipo, email, password, saldo, telemovel, nickname, estado) VALUES (0, 'Administrador', 'admin@gmail.com', 'admin123', 0, 911111111, 'Admin1', 'Desbloqueado');

INSERT INTO dbo.Pessoa (id, tipo, email, password, saldo, telemovel, nickname, estado) VALUES (1, 'Utilizador', 'yeet@gmail.com', 'yeet', 0, 968780666, 'Yeet', 'Desbloqueado');

