CREATE TABLE Prodotto(
	prodottoID INTEGER PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	prezzo DECIMAL(5,2),
	codice VARCHAR(250) NOT NULL UNIQUE
);

INSERT INTO Prodotto (nome, prezzo, codice) VALUES
('Laptop HP Pavilion', 799.99, 'HP123456'),
('Smartphone Samsung Galaxy S23', 999.99, 'SGS23ULTRA'),
('Monitor Dell 27"', 299.50, 'DELLM27'),
('Mouse Logitech MX Master 3', 99.99, 'LOGIMX3'),
('Tastiera meccanica Corsair K70', 149.99, 'CORSAIRK70'),
('SSD Samsung 1TB NVMe', 129.49, 'SSD1TB-SAMS'),
('Stampante Epson EcoTank', 249.00, 'EPSONET4700'),
('Tablet Apple iPad Air', 649.99, 'IPADAIR2024'),
('Cuffie Sony WH-1000XM5', 349.99, 'SONYWHXM5'),
('Scheda grafica NVIDIA RTX 4070', 599.99, 'RTX4070NVIDIA');
