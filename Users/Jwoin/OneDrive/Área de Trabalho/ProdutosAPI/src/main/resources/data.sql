CREATE TABLE jogos (
    id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    genero VARCHAR(50),
    ano INT,
    status VARCHAR(20)  -- "zerado" ou "não zerado"
);
