DROP DATABASE leiloes;

CREATE DATABASE leiloes;

USE leiloes;


CREATE TABLE Pessoa (
    id INT PRIMARY KEY NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    saldo DECIMAL(9, 2) NOT NULL,
    telemovel INT NOT NULL,
    nickname VARCHAR(50) NOT NULL
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
    precoReserva DECIMAL(9, 2) NOT NULL,
    precoMinimo DECIMAL(9, 2) NOT NULL,
    dataHoraInicial DATETIME,
    dataHoraFinal DATETIME,
    duracao INT NOT NULL,
    id_lanceAtual INT NOT NULL,
    id_lanceFinal INT NOT NULL,
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
    id_leilao INT NOT NULL,
    id_transacao INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    condicao DECIMAL(3, 2) NOT NULL,
    raridade VARCHAR(50) NOT NULL,
    descricao VARCHAR(250) NOT NULL,
    caminhoImagem VARCHAR(250) NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id),
	FOREIGN KEY (id_leilao) REFERENCES Leilao(id)
);


CREATE TABLE LeilaoFavoritos (
    id_leilao INT NOT NULL,
    id_pessoa INT NOT NULL,
    FOREIGN KEY (id_leilao) REFERENCES Leilao(id),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id)
);

CREATE TABLE ValorFinal (
    id_lance INT NOT NULL,
    id_transacao INT NOT NULL,
    FOREIGN KEY (id_lance) REFERENCES Lance(id),
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id)
);

CREATE TABLE HistoricoTransacoes (
    id_transacao INT NOT NULL,
    id_pessoa INT NOT NULL,
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id)
);

SELECT * FROM dbo.Pessoa;

DELETE dbo.Pessoa;

