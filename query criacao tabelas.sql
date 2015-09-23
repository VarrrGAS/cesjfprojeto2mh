CREATE TABLE tb_usuario (
		id INT PRIMARY KEY IDENTITY(1,1),
		usuario NVARCHAR(20) NOT NULL,
		nome NVARCHAR(30) NOT NULL,
		cpf NVARCHAR(11) NOT NULL
)

CREATE TABLE tb_tipo_bebida (
		id INT PRIMARY KEY IDENTITY(1,1),
		tipo NVARCHAR(20) NOT NULL
)

CREATE TABLE tb_bebida (
		id INT PRIMARY KEY IDENTITY(1,1),
		id_tipo_bebida INT NOT NULL,
		nome NVARCHAR(30) NOT NULL,
		FOREIGN KEY (id_tipo_bebida) REFERENCES tb_tipo_bebida(id)	
)

CREATE TABLE tb_tipo_transacao (
		id INT PRIMARY KEY IDENTITY(1,1),
		tipo NVARCHAR(20) NOT NULL
)

CREATE TABLE tb_transacao (
		id INT PRIMARY KEY IDENTITY(1,1),
		id_bebida INT NOT NULL,
		id_usuario INT NOT NULL,
		id_tipo_transacao INT NOT NULL,
		qtd INT NOT NULL,
		FOREIGN KEY (id_bebida) REFERENCES tb_bebida(id),
		FOREIGN KEY (id_usuario) REFERENCES tb_usuario(id),
		FOREIGN KEY (id_tipo_transacao) REFERENCES tb_tipo_transacao(id)
)
