# mserver

select * from clientes_z
INSERT INTO clientes_z (nombre, correo, edad, pais)
VALUES
    ('Juan Pérez', 'juan@example.com', 30, 'México'),
    ('María López', 'maria@example.com', 25, 'España'),
    ('Carlos Rodríguez', 'carlos@example.com', 28, 'Argentina');

DROP TABLE clientes_z

CREATE TABLE clientes_z (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(255),
    correo VARCHAR(255) UNIQUE,
    edad INT,
    pais VARCHAR(50)
);

SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'clientes_z'

SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'clientes_Z'


CREATE TABLE tipo_comida (
    tipo_comida_id INT IDENTITY(1,1) PRIMARY KEY,
    tipo_comida VARCHAR(255) UNIQUE
);

CREATE TABLE comida (
    comida_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre_comida VARCHAR(255) UNIQUE,
	tipo_comida_id INT
	FOREIGN KEY (tipo_comida_id) REFERENCES tipo_comida(tipo_comida_id)
);


INSERT INTO comida (nombre_comida, tipo_comida_id)
VALUES ('manzanas', 1)

INSERT INTO tipo_comida (tipo_comida)
VALUES ('Mexicana')

select * from tipo_comida

select * from comida


#comando para crar los models automaticamente
Scaffold-DbContext "Server=localhost;Database=NetApiDb;User Id=sa;Password=as123456;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables tipo_comida,comida
