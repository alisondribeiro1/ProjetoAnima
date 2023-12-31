-- Criar o banco de dados "servico_matricula"
CREATE DATABASE servico_matricula;
/*
-- Conceder permissões ao usuário "postgre" no banco de dados "servico_matricula"
GRANT ALL PRIVILEGES ON DATABASE servico_matricula TO postgre;

-- Alterar para o banco de dados "servico_matricula"
\c servico_matricula;

-- Conceder permissões ao usuário "postgre" no esquema "public"
GRANT ALL PRIVILEGES ON SCHEMA public TO postgre;

-- Finalizar
\q
*/
-- public.usuario definition

-- Drop table

-- DROP TABLE public.usuario;

CREATE TABLE public.matricula (
	idmatricula int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	idusuario int NOT NULL,
	idcurso int NOT NULL,
	ativo bool NOT NULL,
	aprovado bool NOT NULL,
	CONSTRAINT "PK_matricula" PRIMARY KEY (idmatricula)
);

-- Permissions

ALTER TABLE public.matricula OWNER TO postgres;
GRANT ALL ON TABLE public.matricula TO postgres;