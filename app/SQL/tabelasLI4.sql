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
    saldo DECIMAL(9, 2),
    telemovel INT,
    nickname VARCHAR(50),
	estado VARCHAR(50)
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
	FOREIGN KEY (id_Criador) REFERENCES Pessoa(id),
);

CREATE TABLE Lance (
    id INT PRIMARY KEY NOT NULL,
    id_leilao INT NOT NULL,
    id_licitador INT NOT NULL,
    valor DECIMAL(9, 2) NOT NULL,
	FOREIGN KEY (id_leilao) REFERENCES Leilao(id),
    FOREIGN KEY (id_licitador) REFERENCES Pessoa(id)
);


ALTER TABLE Leilao
ADD FOREIGN KEY (id_lanceAtual) REFERENCES Lance(id);

CREATE TABLE Artigo (
    id INT PRIMARY KEY NOT NULL,
    id_leilao INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    condicao VARCHAR(50) NOT NULL,
    raridade VARCHAR(50) NOT NULL,
    caminhoImagem VARCHAR(500),
    tipo VARCHAR(45) NOT NULL,
	FOREIGN KEY (id_leilao) REFERENCES Leilao(id)
);

CREATE TABLE LeilaoFavoritos (
    id_leilao INT NOT NULL,
    id_pessoa INT NOT NULL,
    FOREIGN KEY (id_leilao) REFERENCES Leilao(id),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id),
	PRIMARY KEY(id_leilao, id_pessoa)
);

SELECT * FROM dbo.Pessoa;

SELECT * FROM dbo.Artigo;

SELECT * FROM dbo.Leilao;

SELECT * FROM dbo.Lance;

SELECT * FROM dbo.LeilaoFavoritos;

-- Leiloes que ainda nao acabaram 
SELECT * FROM Leilao WHERE (DATEADD(MINUTE, duracao, dataHoraInicial) >= GETDATE()) OR (dataHoraInicial > GETDATE());

-- Leiloes e as suas skins
SELECT Leilao.*, Artigo.* FROM Leilao LEFT JOIN Artigo ON Leilao.id = Artigo.id_leilao;

-- Artigos de leiloes que nao acabaram
SELECT * FROM Artigo A JOIN Leilao L ON A.id_leilao = L.id WHERE GETDATE() < L.dataHoraInicial;

-- Transacoes de um utilizador (yeet)
SELECT * FROM dbo.Leilao WHERE (DATEADD(MINUTE, duracao, dataHoraInicial) < GETDATE()) AND id_lanceAtual IS NOT NULL AND id_lanceAtual IN (SELECT id FROM dbo.Lance WHERE id_licitador = 340990);

DELETE dbo.Pessoa;

DELETE dbo.Leilao;

DELETE dbo.Artigo;

USE leiloes;

INSERT INTO dbo.Pessoa (id, tipo, email, password, saldo, telemovel, nickname, estado) VALUES (0, 'Administrador', 'admin@gmail.com', 'admin123', null, null, null, null);

INSERT INTO dbo.Pessoa (id, tipo, email, password, saldo, telemovel, nickname, estado) VALUES (1, 'Utilizador', 'yeet@gmail.com', 'yeet', 500, 968780666, 'Yeet', 'Desbloqueado');

INSERT INTO dbo.Pessoa (id, tipo, email, password, saldo, telemovel, nickname, estado) VALUES (69, 'Utilizador', 'tone@gmail.com', 'tone', 500, 912345678, 'Tone', 'Desbloqueado');

INSERT INTO dbo.Pessoa (id, tipo, email, password, saldo, telemovel, nickname, estado) VALUES (420, 'Utilizador', 'liro@gmail.com', 'liro', 500, 987654321, 'Liro', 'Desbloqueado');

