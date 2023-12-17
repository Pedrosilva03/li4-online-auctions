USE leiloes;
CREATE SCHEMA leiloes;
DROP SCHEMA leiloes;

CREATE TABLE Pessoa (
    id INT PRIMARY KEY,
    tipo VARCHAR(50),
    email VARCHAR(100),
    password VARCHAR(100),
    saldo DECIMAL(9, 2),
    telemovel INT,
    nickname VARCHAR(50)
);

CREATE TABLE Artigo (
    id INT PRIMARY KEY,
    id_leilao INT,
    id_transacao INT,
    nome VARCHAR(100),
    condicao DECIMAL(3, 2),
    raridade VARCHAR(50),
    descricao VARCHAR(250),
    caminhoImagem VARCHAR(250),
    tipo VARCHAR(50),
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id),
	FOREIGN KEY (id_leilao) REFERENCES Leilao(id)
);

CREATE TABLE Leilao (
    id INT PRIMARY KEY,
    id_Criador INT,
    precoReserva DECIMAL(9, 2),
    precoMinimo DECIMAL(9, 2),
    dataHoraInicial DATETIME,
    dataHoraFinal DATETIME,
    duracao INT,
    id_lanceAtual INT,
    id_lanceFinal INT,
    FOREIGN KEY (id_lanceAtual) REFERENCES Lance(id),
	FOREIGN KEY (id_lanceFinal) REFERENCES Lance(id)
);

CREATE TABLE Lance (
    id INT PRIMARY KEY,
    id_leilao INT,
    id_licitador INT,
    valor DECIMAL(9, 2),
    FOREIGN KEY (id_licitador) REFERENCES Pessoa(id)
);

CREATE TABLE Transacao (
    id INT PRIMARY KEY,
    id_leilao INT,
    id_vendedor INT,
    id_comprador INT,
    data DATETIME,
    valorTransacao DECIMAL(9, 2),
    taxa DECIMAL(9, 2)
);

CREATE TABLE LeilaoFavoritos (
    id_leilao INT,
    id_pessoa INT,
    FOREIGN KEY (id_leilao) REFERENCES Leilao(id),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id)
);

CREATE TABLE ValorFinal (
    id_lance INT,
    id_transacao INT,
    FOREIGN KEY (id_lance) REFERENCES Lance(id),
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id)
);

CREATE TABLE HistoricoTransacoes (
    id_transacao INT,
    id_pessoa INT,
    FOREIGN KEY (id_transacao) REFERENCES Transacao(id),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id)
);
