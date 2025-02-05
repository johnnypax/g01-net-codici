CREATE TABLE Persona(
	personaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	cod_fis CHAR(16) NOT NULL UNIQUE,
	numero_mezzi INTEGER CHECK (numero_mezzi > 0)
);

INSERT INTO Persona (nome, cognome, cod_fis, numero_mezzi)
VALUES 
('Mario', 'Rossi', 'RSSMRA85M01H501Z', 2),
('Luca', 'Bianchi', 'BNCLCU90A02F205X', 1),
('Giulia', 'Verdi', 'VRDGLL75P15L219T', 3),
('Francesca', 'Neri', 'NRIFNC88D23H501Y', 1),
('Antonio', 'Gallo', 'GLLNTN92E04D969B', 2),
('Alessia', 'Romano', 'RMNLSA99L20H501Q', 4),
('Stefano', 'Ferrari', 'FRRSTF81T17A662C', 2),
('Simona', 'Moretti', 'MRTSMN78B22H501J', 1),
('Davide', 'Conti', 'CNTDVD86D10G273A', 3),
('Serena', 'Marini', 'MRNSRN95C14H501W', 1);

SELECT personaID, nome, cognome, cod_fis, numero_mezzi FROM Persona;