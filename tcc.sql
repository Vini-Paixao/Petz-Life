drop database dbTcc;
create database dbTcc;
use dbTcc;

/*call pcd_selectLogin();
call pcd_selectEndereco();
call pcd_selectCliente();*/

CREATE TABLE tbLogin (
    idLogin int primary key auto_increment,
    usuario varchar(50),
    email varchar(50),
    senha varchar(50),
    tipo int 
);

CREATE TABLE tbPlano (
    idPlano int primary key auto_increment,
    nomePlano varchar(50),
    tagPlano varchar(50),
    valorPlano varchar(15),
    tipoPlano varchar(50),
    corPlano varchar(10),
    imgPlano varchar(255),
    descPlano varchar(800)
);

CREATE TABLE tbBeneficio (
    idBeneficio int primary key auto_increment,
    nomeBeneficio varchar(100),
    idPlano int references tbPlano(idPlano)
);

CREATE TABLE tbEstado (
    siglaEstado char(2) primary key,
    nomeEstado varchar(20) 
);

CREATE TABLE tbEndereco (
    idEndereco int primary key auto_increment,
    nomeEndereco varchar(50),
    logradouroEndereco varchar(80),
    numeroEndereco varchar(10),
    complementoEndereco varchar(50),
    cepEndereco varchar(10),
    bairroEndereco varchar(50),
    cidadeEndereco varchar(50),
    siglaEstado char(2) references tbEstado(siglaEstado)
);

CREATE TABLE tbCliente (
    idCliente int primary key auto_increment,
    nomeCliente varchar(50),
    sobrenomeCliente varchar(50),
    rgCliente varchar(15),
    cpfCliente varchar(15),
    telefoneCliente varchar(20),
    celularCliente varchar(20),
    idEndereco int references tbEndereco(idEndereco),
    idLogin int references tbLogin(idLogin),
    idPlano int references tbPlano(idPlano)
);

CREATE TABLE tbTipo (
    idTipo int primary key auto_increment,
    nomeTipo varchar(50) 
);

CREATE TABLE tbRaca (
    idRaca int primary key auto_increment,
    nomeRaca varchar(50),
    idTipo int references tbTipo(idTipo)
);

CREATE TABLE tbAnimal (
    idAnimal int primary key auto_increment,
    nomeAnimal varchar(50),
    apelidoAnimal varchar(50),
    idadeAnimal int,
    imgAnimal varchar(255),
    idRaca int references tbRaca(idRaca),
    idCliente int references tbCliente(idCliente)
);

CREATE TABLE tbCuidado (
    idCuidado int primary key auto_increment,
    descCuidado varchar(50),
    idAnimal int references tbAnimal(idAnimal)
);

CREATE TABLE tbInformacao (
    idInformacao int primary key auto_increment,
    descInformacao varchar(50),
    idAnimal int references tbAnimal(idAnimal)
);

CREATE TABLE tbClinica (
    idClinica int primary key auto_increment,
    nomeClinica varchar(50),
    telefoneClinica varchar(20),
    celularClinica varchar(20),
    emailClinica varchar(30),
    avaliacaoClinica varchar(10),
    horarioClinica varchar(100),
    idEndereco int references tbEndereco(idEndereco)
);

CREATE TABLE tbVeterinario (
    idVeterinario int primary key auto_increment,
    nomeVeterinario varchar(50),
    especVeterinario varchar(50),
    telefoneVeterinario varchar(20),
    emailVeterinario varchar(50),
    idClinica int references tbClinica(idClinica)
);

CREATE TABLE tbStatus (
    idStatus int primary key auto_increment,
    nomeStatus varchar(30) 
);

CREATE TABLE tbAtendimento (
    idAtendimento int primary key auto_increment,
    dataHoraAtendimento datetime,
    descricaoAtendimento varchar(500),
    idStatus int references tbStatus(idStatus),
    idClinica int references tbClinica(idClinica),
    idVeterinario int references tbVeterinario(idVeterinario),
    idAnimal int references tbAnimal(idAnimal)
);
/***************************************************************************/

 -- Inserts Estados
insert into tbEstado (siglaEstado, nomeEstado) values 
("AC", "Acre"),
("AL", "Alagoas"),
("AP", "Amapá"),
("AM", "Amazonas"),
("BA", "Bahia"),
("CE", "Ceará"),
("DF", "Distrito Federal"),
("ES", "Espírito Santo"),
("GO", "Goiás"),
("MA", "Maranhão"),
("MT", "Mato Grosso"),
("MS", "Mato Grosso do Sul"),
("MG", "Minas Gerais"),
("PA", "Pará"),
("PB", "Paraíba"),
("PR", "Paraná"),
("PE", "Pernambuco"),
("PI", "Piauí"),
("RJ", "Rio de Janeiro"),
("RN", "Rio Grande do Norte"),
("RS", "Rio Grande do Sul"),
("RO", "Rondônia"),
("RR", "Roraima"),
("SC", "Santa Catarina"),
("SP", "São Paulo"),
("SE", "Sergipe"),
("TO", "Tocantins");

 -- Inserts Status
insert into tbStatus (nomeStatus) values 
("Agendado"),("Atendido");
/***************************************************************************/

 -- PROCEDURES LOGIN
-- Procedure inserir login 
delimiter $$
create procedure pcd_insertLogin(
_usuario varchar(50),
_email varchar(50),
_senha varchar(50),
_tipo int
)
begin
	start transaction;
		insert into tbLogin(usuario ,email, senha, tipo)
		values(_usuario, _email, _senha, _tipo);
	commit;
		rollback;
end $$
select * from tbLogin;
-- Procedure consultar login
delimiter $$
create procedure pcd_selectLogin()
begin
	select * from tbLogin;
end $$

-- Procedure testar login
delimiter $$
create procedure pcd_testeLogin(
_email varchar(50),
_senha varchar(50)
)
begin
	select * from tbLogin where email = _email and senha = _senha;
end $$

-- Procedure testar email
delimiter $$
create procedure pcd_testeEmail(
_email varchar(50)
)
begin
	select email from tbLogin where email = _email;
end $$

-- Procedure alterar login
delimiter $$
create procedure pcd_updateLogin(
_idLogin int,
_usuario varchar(50),
_email varchar(50),
_senha varchar(50),
_tipo int
)
begin
	start transaction;
		update tbLogin set usuario = _usuario, email = _email, senha = _senha,
						tipo = _tipo where idLogin = _idLogin;
	commit;
		rollback;
end $$

-- Procedure apagar login
delimiter $$
create procedure pcd_deleteLogin(_idLogin int)
begin
	delete from tbLogin where idLogin = _idLogin;
end $$
-- */

 -- PROCEDURES PLANO
-- Procedure inserir plano 
delimiter $$
create procedure pcd_insertPlano(
_nomePlano varchar(50),
_tagPlano varchar(50),
_valorPlano varchar(15),
_tipoPlano varchar(50),
_corPlano varchar(50),
_imgPlano varchar(255),
_descPlano varchar(800)
)
begin
	start transaction;
		insert into tbPlano(nomePlano, tagPlano, valorPlano, tipoPlano, corPlano, imgPlano, descPlano)
		values(_nomePlano, _tagPlano, _valorPlano, _tipoPlano, _corPlano, _imgPlano, _descPlano);
	commit;
		rollback;
end $$

-- Procedure consultar plano
delimiter $$
create procedure pcd_selectPlano()
begin
	select * from tbPlano;
end $$

-- Procedure consultar plano por tipo
delimiter $$
create procedure pcd_selectPlanoPorTipo()
begin
	select * from tbPlano where tipoPlano = "Básico";
end $$

-- Procedure consultar planos para dropdown
delimiter $$
create procedure pcd_selectPlanos()
begin
	select idPlano, nomePlano from tbPlano;
end $$
call pcd_selectPlanoComBeneficios()
-- Procedure consultar plano com beneficios
delimiter $$
create procedure pcd_selectPlanoComBeneficios()
begin
	select 
		t1.idPlano,
		t1.nomePlano,
		t1.tagPlano, 
		t1.valorPlano, 
		t1.tipoPlano, 
		t1.corPlano, 
		t1.imgPlano, 
		t1.descPlano, 
		t2.nomeBeneficio from tbPlano as t1 
	INNER JOIN tbBeneficio as t2 ON t1.idPlano = t2.idPlano;
end $$

select tbBeneficio.nomeBeneficio from tbPlano inner join tbBeneficio on tbPlano.idPlano = tbBeneficio.idPlano where tbPlano.idPlano = 1;

-- Procedure alterar plano
delimiter $$
create procedure pcd_updatePlano(
_idPlano int,
_nomePlano varchar(50),
_tagPlano varchar(50),
_valorPlano varchar(15),
_tipoPlano varchar(50),
_corPlano varchar(50),
_imgPlano varchar(255),
_descPlano varchar(800)
)
begin
	start transaction;
		update tbPlano set nomePlano = _nomePlano, tagPlano = _tagPlano, valorPlano = _valorPlano,
		tipoPlano = _tipoPlano, corPlano = _corPlano, imgPlano = _imgPlano, descPlano = _descPlano where idPlano = _idPlano;
	commit;
		rollback;
end $$

-- Procedure apagar plano
delimiter $$
create procedure pcd_deletePlano(_idPlano int)
begin
	delete from tbPlano where idPlano = _idPlano;
end $$
-- */

 -- PROCEDURES BENEFICIO
-- Procedure inserir beneficio 
delimiter $$
create procedure pcd_insertBeneficio(
_nomeBeneficio varchar(100),
_idPlano int
)
begin
	start transaction;
		insert into tbBeneficio(nomeBeneficio, idPlano)
		values(_nomeBeneficio, _idPlano);
	commit;
		rollback;
end $$

-- Procedure consultar beneficio
delimiter $$
create procedure pcd_selectBeneficio()
begin
	select 
		t1.idBeneficio,
		t1.nomeBeneficio, 
		t2.nomePlano from tbBeneficio as t1 
	INNER JOIN tbPlano as t2 ON t1.idPlano = t2.idPlano;
end $$

-- Procedure alterar beneficio
delimiter $$
create procedure pcd_updateBeneficio(
_idBeneficio int,
_nomeBeneficio varchar(100),
_idPlano int
)
begin
	start transaction;
		update tbBeneficio set nomeBeneficio = _nomeBeneficio, idPlano = _idPlano 
		where idBeneficio = _idBeneficio;
	commit;
		rollback;
end $$

-- Procedure apagar beneficio
delimiter $$
create procedure pcd_deleteBeneficio(_idBeneficio int)
begin
	delete from tbBeneficio where idBeneficio = _idBeneficio;
end $$
-- */

 -- PROCEDURES ENDERECO
-- Procedure inserir endereco 
delimiter $$
create procedure pcd_insertEndereco(
_nomeEndereco varchar(50),
_logradouroEndereco varchar(80),
_numeroEndereco varchar(10),
_complementoEndereco varchar(50),
_cepEndereco varchar(10),
_bairroEndereco varchar(50),
_cidadeEndereco varchar(50),
_siglaEstado char(2)
)
begin
	start transaction;
		insert into tbEndereco(nomeEndereco,logradouroEndereco,numeroEndereco,complementoEndereco,cepEndereco,bairroEndereco,cidadeEndereco,siglaEstado)
		values(_nomeEndereco,_logradouroEndereco,_numeroEndereco,_complementoEndereco,_cepEndereco,_bairroEndereco,_cidadeEndereco,_siglaEstado);
	commit;
		rollback;
end $$

-- Procedure testar endereco
delimiter $$
create procedure pcd_testeEndereco(
_nomeEndereco varchar(50),
_logradouroEndereco varchar(80),
_numeroEndereco varchar(10),
_complementoEndereco varchar(50)
)
begin
	select * from tbEndereco where nomeEndereco = _nomeEndereco and logradouroEndereco = _logradouroEndereco
    and numeroEndereco = _numeroEndereco and complementoEndereco = _complementoEndereco;
end $$

-- Procedure consultar endereco por código
delimiter $$
create procedure pcd_selectEnderecoPorId(_idEndereco int)
begin
	select 
		t1.idEndereco,
		t1.nomeEndereco, 
		t1.logradouroEndereco,  
		t1.numeroEndereco,  
		t1.complementoEndereco,  
		t1.cepEndereco,  
		t1.bairroEndereco, 
		t1.cidadeEndereco, 
		t2.siglaEstado, 
		t2.nomeEstado from tbEndereco as t1 
	INNER JOIN tbEstado as t2 ON t1.siglaEstado = t2.siglaEstado
    where idEndereco = _idEndereco;
end $$


-- Procedure consultar endereco
delimiter $$
create procedure pcd_selectEndereco()
begin
	select 
		t1.idEndereco,
		t1.nomeEndereco, 
		t1.logradouroEndereco,  
		t1.numeroEndereco,  
		t1.complementoEndereco,  
		t1.cepEndereco,  
		t1.bairroEndereco, 
		t1.cidadeEndereco, 
		t2.siglaEstado, 
		t2.nomeEstado from tbEndereco as t1 
	INNER JOIN tbEstado as t2 ON t1.siglaEstado = t2.siglaEstado;
end $$

-- Procedure alterar endereco
delimiter $$
create procedure pcd_updateEndereco(
_idEndereco int,
_nomeEndereco varchar(50),
_logradouroEndereco varchar(80),
_numeroEndereco varchar(10),
_complementoEndereco varchar(50),
_cepEndereco varchar(10),
_bairroEndereco varchar(50),
_cidadeEndereco varchar(50),
_siglaEstado char(2)
)
begin
	start transaction;
		update tbEndereco set nomeEndereco = _nomeEndereco, logradouroEndereco = _logradouroEndereco, numeroEndereco = _numeroEndereco, complementoEndereco = _complementoEndereco,
		cepEndereco = _cepEndereco, bairroEndereco = _bairroEndereco, cidadeEndereco = _cidadeEndereco, siglaEstado = _siglaEstado where _idEndereco = _idEndereco;
	commit;
		rollback;
end $$

-- Procedure apagar endereco
delimiter $$
create procedure pcd_deleteEndereco(_idEndereco int)
begin
	delete from tbEndereco where idEndereco = _idEndereco;
end $$
-- */

  -- PROCEDURES CLIENTE
-- Procedure inserir cliente 
delimiter $$
create procedure pcd_insertCliente(
_nomeCliente varchar(50),
_sobrenomeCliente varchar(50),
_rgCliente varchar(15),
_cpfCliente varchar(15),
_telefoneCliente varchar(20),
_celularCliente varchar(20),
_idEndereco int,
_idLogin int,
_idPlano int
)
begin
	start transaction;
		insert into tbCliente(nomeCliente,sobrenomeCliente,rgCliente,cpfCliente,telefoneCliente,celularCliente,idEndereco,idLogin,idPlano)
		values(_nomeCliente,_sobrenomeCliente,_rgCliente,_cpfCliente,_telefoneCliente,_celularCliente,_idEndereco,_idLogin,_idPlano);
	commit;
		rollback;
end $$

-- Procedure inserir Login do cliente 
delimiter $$
create procedure pcd_insertLoginCliente(
_usuario varchar(50),
_email varchar(50),
_senha varchar(50)
)
begin
	start transaction;
		insert into tbLogin(usuario, email, senha, tipo)
		values(_usuario, _email, _senha, 2);
	commit;
		rollback;
end $$

-- Procedure testar cliente
delimiter $$
create procedure pcd_testeCliente(
_nomeCliente varchar(50),
_sobrenomeCliente varchar(50),
_rgCliente varchar(15),
_cpfCliente varchar(15)
)
begin
	select * from tbCliente where nomeCliente = _nomeCliente and sobrenomeCliente = _sobrenomeCliente
    and rgCliente = _rgCliente and cpfCliente = _cpfCliente;
end $$

-- Procedure consultar cliente
delimiter $$
create procedure pcd_selectCliente()
begin
	select 
		t1.idCliente,
		t1.nomeCliente, 
		t1.sobrenomeCliente,  
		t1.rgCliente,  
		t1.cpfCliente,  
		t1.telefoneCliente,  
		t1.celularCliente, 
		t2.idEndereco,  
		t2.nomeEndereco,  
		t2.logradouroEndereco,
		t2.numeroEndereco,
		t2.complementoEndereco,
		t2.cepEndereco,   
		t2.bairroEndereco,  
		t2.cidadeEndereco,  
		t2.siglaEstado,
		t3.idLogin,  
		t3.email,  
		t3.senha,  
		t4.idPlano,
		t4.nomePlano,
		t4.corPlano,
		t4.imgPlano,
		t4.tipoPlano from tbCliente as t1 
	INNER JOIN tbEndereco as t2 ON t1.idEndereco = t2.idEndereco
	INNER JOIN tbLogin as t3 ON t1.idLogin = t3.idLogin
	INNER JOIN tbPlano as t4 ON t1.idPlano = t4.idPlano;
end $$

-- Procedure alterar login do cliente
delimiter $$
create procedure pcd_updateLoginCliente(
_idLogin int,
_usuario varchar(50),
_email varchar(50),
_senha varchar(50)
)
begin
	start transaction;
		update tbLogin set usuario = _usuario, email = _email, senha = _senha where idLogin = _idLogin;
	commit;
		rollback;
end $$


-- Procedure alterar cliente
delimiter $$
create procedure pcd_updateCliente(
_idCliente int,
_nomeCliente varchar(50),
_sobrenomeCliente varchar(50),
_rgCliente varchar(15),
_cpfCliente varchar(15),
_telefoneCliente varchar(20),
_celularCliente varchar(20)
)
begin
	start transaction;
		update tbCliente set nomeCliente = _nomeCliente, sobrenomeCliente = _sobrenomeCliente, rgCliente = _rgCliente, cpfCliente = _cpfCliente, 
		telefoneCliente = _telefoneCliente, celularCliente = _celularCliente where idCliente = _idCliente;
	commit;
		rollback;
end $$

-- Procedure apagar cliente
delimiter $$
create procedure pcd_deleteCliente(_idCliente int)
begin
	delete from tbCliente where idCliente = _idCliente;
end $$
-- */

 -- PROCEDURES TIPO
-- Procedure inserir tipo 
delimiter $$
create procedure pcd_insertTipo(
_nomeTipo  varchar(50)
)
begin
	start transaction;
		insert into tbTipo(nomeTipo)
		values(_nomeTipo);
	commit;
		rollback;
end $$

-- Procedure consultar tipo
delimiter $$
create procedure pcd_selectTipo()
begin
	select * from tbTipo;
end $$

-- Procedure alterar tipo
delimiter $$
create procedure pcd_updateTipo(
_idTipo int,
_nomeTipo varchar(50)
)
begin
	start transaction;
		update tbTipo set nomeTipo = _nomeTipo where idTipo = _idTipo;
	commit;
		rollback;
end $$

-- Procedure apagar tipo
delimiter $$
create procedure pcd_deleteTipo(_idTipo int)
begin
	delete from tbTipo where idTipo = _idTipo;
end $$
-- */

 -- PROCEDURES RACA
-- Procedure inserir raca 
delimiter $$
create procedure pcd_insertRaca(
_nomeRaca varchar(50),
_idTipo int
)
begin
	start transaction;
		insert into tbRaca(nomeRaca,idTipo)
		values(_nomeRaca,_idTipo);
	commit;
		rollback;
end $$

-- Procedure consultar raca
delimiter $$
create procedure pcd_selectRaca()
begin
	select 
		t1.idRaca,
		t1.nomeRaca, 
		t2.nomeTipo from tbRaca as t1 
	INNER JOIN tbTipo as t2 ON t1.idTipo = t2.idTipo;
end $$

-- Procedure alterar raca
delimiter $$
create procedure pcd_updateRaca(
_idRaca int,
_nomeRaca varchar(50),
_idTipo int
)
begin
	start transaction;
		update tbRaca set nomeRaca = _nomeRaca, idTipo = _idTipo where idRaca = _idRaca;
	commit;
		rollback;
end $$

-- Procedure apagar raca
delimiter $$
create procedure pcd_deleteRaca(_idRaca int)
begin
	delete from tbRaca where idRaca = _idRaca;
end $$
-- */

 -- PROCEDURES ANIMAL
-- Procedure inserir animal 
delimiter $$
create procedure pcd_insertAnimal(
_nomeAnimal varchar(50),
_apelidoAnimal varchar(50),
_idadeAnimal int,
_imgAnimal varchar(255),
_idRaca int,
_idCliente int
)
begin
	start transaction;
		insert into tbAnimal(nomeAnimal,apelidoAnimal,idadeAnimal,imgAnimal,idRaca,idCliente)
		values(_nomeAnimal,_apelidoAnimal,_idadeAnimal,_imgAnimal,_idRaca,_idCliente);
	commit;
		rollback;
end $$

-- Procedure consultar animal
delimiter $$
create procedure pcd_selectAnimal()
begin
	select 
		t1.idAnimal,
		t1.nomeAnimal,
		t1.apelidoAnimal, 
		t1.idadeAnimal,
		t1.imgAnimal, 
		t2.idRaca, 
		t2.nomeRaca, 
		t3.idTipo, 
		t3.nomeTipo, 
		t4.idCliente,
		t4.idLogin from tbAnimal as t1 
	INNER JOIN tbRaca as t2 ON t1.idRaca = t2.idRaca
	INNER JOIN tbTipo as t3 ON t2.idTipo = t3.idTipo
	INNER JOIN tbCliente as t4 ON t1.idCliente = t4.idCliente;
end $$

-- Procedure consultar animal
delimiter $$
create procedure pcd_selectAnimalPorId(
_idLogin int
)
begin
	select 
		t1.idAnimal,
		t1.nomeAnimal from tbAnimal as t1 
	INNER JOIN tbCliente as t2 ON t1.idCliente = t2.idCliente
	WHERE t2.idLogin = _idLogin;
end $$

-- Procedure consultar animal
delimiter $$
create procedure pcd_selectClienteId(
_idLogin int
)
begin
	select idCliente from tbCliente where idLogin = _idLogin;
end $$

-- Procedure alterar animal
delimiter $$
create procedure pcd_updateAnimal(
_idAnimal int,
_nomeAnimal varchar(50),
_apelidoAnimal varchar(50),
_idadeAnimal int,
_imgAnimal varchar(255),
_idRaca int
)
begin
	start transaction;
		update tbAnimal set nomeAnimal = _nomeAnimal, apelidoAnimal = _apelidoAnimal, idadeAnimal = _idadeAnimal,
						imgAnimal = _imgAnimal, idRaca = _idRaca where idAnimal = _idAnimal;
	commit;
		rollback;
end $$

-- Procedure apagar animal
delimiter $$
create procedure pcd_deleteAnimal(_idAnimal int)
begin
	delete from tbAnimal where idAnimal = _idAnimal;
end $$
-- */

 -- PROCEDURES CUIDADO
-- Procedure inserir cuidado 
delimiter $$
create procedure pcd_insertCuidado(
_descCuidado varchar(50),
_idAnimal int
)
begin
	start transaction;
		insert into tbCuidado(descCuidado,idAnimal)
		values(_descCuidado,_idAnimal);
	commit;
		rollback;
end $$

-- Procedure consultar cuidado
delimiter $$
create procedure pcd_selectCuidado()
begin
	select 
		t1.idCuidado,
		t1.descCuidado, 
		t2.idAnimal, 
		t2.nomeAnimal from tbCuidado as t1 
	INNER JOIN tbAnimal as t2 ON t1.idAnimal = t2.idAnimal;
end $$

-- Procedure consultar cuidado por id
delimiter $$
create procedure pcd_selectCuidadoPorId(
_idAnimal int
)
begin
	select 
		t1.idCuidado,
		t1.descCuidado, 
		t2.idAnimal, 
		t2.nomeAnimal from tbCuidado as t1 
	INNER JOIN tbAnimal as t2 ON t1.idAnimal = t2.idAnimal
    WHERE t1.idAnimal = _idAnimal;
end $$

-- Procedure alterar cuidado
delimiter $$
create procedure pcd_updateCuidado(
_idCuidado int,
_descCuidado varchar(50),
_idAnimal int
)
begin
	start transaction;
		update tbCuidado set descCuidado = _descCuidado, idAnimal = _idAnimal where idCuidado = _idCuidado;
	commit;
		rollback;
end $$

-- Procedure apagar cuidado
delimiter $$
create procedure pcd_deleteCuidado(_idCuidado int)
begin
	delete from tbCuidado where idCuidado = _idCuidado;
end $$
-- */

 -- PROCEDURES INFORMACAO
-- Procedure inserir informacao 
delimiter $$
create procedure pcd_insertInformacao(
_descInformacao varchar(50),
_idAnimal int
)
begin
	start transaction;
		insert into tbInformacao(descInformacao,idAnimal)
		values(_descInformacao,_idAnimal);
	commit;
		rollback;
end $$

-- Procedure consultar informacao
delimiter $$
create procedure pcd_selectInformacao()
begin
	select 
		t1.idInformacao,
		t1.descInformacao, 
		t2.idAnimal, 
		t2.nomeAnimal from tbInformacao as t1 
	INNER JOIN tbAnimal as t2 ON t1.idAnimal = t2.idAnimal;
	select * from tbInformacao;
end $$

-- Procedure consultar informacao por id
delimiter $$
create procedure pcd_selectInformacaoPorId(
_idAnimal int
)
begin
	select 
		t1.idInformacao,
		t1.descInformacao, 
		t2.idAnimal, 
		t2.nomeAnimal from tbInformacao as t1 
	INNER JOIN tbAnimal as t2 ON t1.idAnimal = t2.idAnimal
    WHERE t1.idAnimal = _idAnimal;
end $$

-- Procedure alterar informacao
delimiter $$
create procedure pcd_updateInformacao(
_idInformacao int,
_descInformacao varchar(50),
_idAnimal int
)
begin
	start transaction;
		update tbInformacao set descInformacao = _descInformacao, idAnimal = _idAnimal where idInformacao = _idInformacao;
	commit;
		rollback;
end $$

-- Procedure apagar informacao
delimiter $$
create procedure pcd_deleteInformacao(_idInformacao int)
begin
	delete from tbInformacao where idInformacao = _idInformacao;
end $$
-- */

 -- PROCEDURES CLINICA
-- Procedure inserir clinica 
delimiter $$
create procedure pcd_insertClinica(
_nomeClinica varchar(50),
_telefoneClinica varchar(20),
_celularClinica varchar(20),
_emailClinica varchar(30),
_avaliacaoClinica varchar(10),
_horarioClinica varchar(50),
_idEndereco int
)
begin
	start transaction;
		insert into tbClinica(nomeClinica, telefoneClinica, celularClinica, emailClinica, avaliacaoClinica, horarioClinica, idEndereco)
		values(_nomeClinica, _telefoneClinica, _celularClinica, _emailClinica, _avaliacaoClinica, _horarioClinica, _idEndereco);
	commit;
		rollback;
end $$

-- Procedure consultar clinica
delimiter $$
create procedure pcd_selectClinica()
begin
	select 
		t1.idClinica,
		t1.nomeClinica, 
		t1.telefoneClinica,
		t1.celularClinica, 
		t1.emailClinica, 
		t1.avaliacaoClinica,
		t1.horarioClinica,
		t2.idEndereco,
		t2.nomeEndereco,
		t2.logradouroEndereco,
		t2.numeroEndereco,
		t2.cepEndereco,
		t2.bairroEndereco,
		t2.cidadeEndereco,
		t2.siglaEstado from tbClinica as t1 
	INNER JOIN tbEndereco as t2 ON t1.idEndereco = t2.idEndereco;
end $$

-- Procedure alterar clinica
delimiter $$
create procedure pcd_updateClinica(
_idClinica int,
_nomeClinica varchar(50),
_telefoneClinica varchar(20),
_celularClinica varchar(20),
_emailClinica varchar(30),
_avaliacaoClinica varchar(10),
_horarioClinica varchar(50)
)
begin
	start transaction;
		update tbClinica set nomeClinica = _nomeClinica, telefoneClinica = _telefoneClinica, celularClinica = _celularClinica, emailClinica = _emailClinica, 
        avaliacaoClinica = _avaliacaoClinica, horarioClinica = _horarioClinica where idClinica = _idClinica;
	commit;
		rollback;
end $$

-- Procedure apagar clinica
delimiter $$
create procedure pcd_deleteClinica(_idClinica int)
begin
	delete from tbClinica where idClinica = _idClinica;
end $$
-- */

 -- PROCEDURES VETERINARIO
-- Procedure inserir veterinario 
delimiter $$
create procedure pcd_insertVeterinario(
_nomeVeterinario varchar(50),
_especVeterinario varchar(50),
_telefoneVeterinario varchar(20),
_emailVeterinario varchar(50),
_idClinica int
)
begin
	start transaction;
		insert into tbVeterinario(nomeVeterinario,especVeterinario,telefoneVeterinario,emailVeterinario,idClinica)
		values(_nomeVeterinario,_especVeterinario,_telefoneVeterinario,_emailVeterinario,_idClinica);
	commit;
		rollback;
end $$

-- Procedure consultar veterinario
delimiter $$
create procedure pcd_selectVeterinario()
begin
	select 
		t1.idVeterinario,
		t1.nomeVeterinario, 
		t1.especVeterinario, 
		t1.telefoneVeterinario,
		t1.emailVeterinario, 
		t2.nomeClinica from tbVeterinario as t1 
	INNER JOIN tbClinica as t2 ON t1.idClinica = t2.idClinica;
end $$

-- Procedure alterar veterinario
delimiter $$
create procedure pcd_updateVeterinario(
_idVeterinario int,
_nomeVeterinario varchar(50),
_especVeterinario varchar(50),
_telefoneVeterinario varchar(20),
_emailVeterinario varchar(50),
_idClinica int
)
begin
	start transaction;
		update tbVeterinario set nomeVeterinario = _nomeVeterinario, especVeterinario = _especVeterinario, telefoneVeterinario = _telefoneVeterinario,
				emailVeterinario = _emailVeterinario, idClinica = _idClinica where idVeterinario = _idVeterinario;
	commit;
		rollback;
end $$

-- Procedure apagar veterinario
delimiter $$
create procedure pcd_deleteVeterinario(_idVeterinario int)
begin
	delete from tbVeterinario where idVeterinario = _idVeterinario;
end $$
-- */

 -- PROCEDURES ATENDIMENTO
-- Procedure inserir atendimento 
delimiter $$
create procedure pcd_insertAtendimento(
_dataHoraAtendimento datetime,
_descricaoAtendimento varchar(500),
_idStatus int,
_idClinica int,
_idVeterinario int,
_idAnimal int
)
begin
	start transaction;
		insert into tbAtendimento(dataHoraAtendimento,descricaoAtendimento,idStatus,idClinica,idVeterinario,idAnimal)
		values(_dataHoraAtendimento,_descricaoAtendimento,_idStatus,_idClinica,_idVeterinario,_idAnimal);
	commit;
		rollback;
end $$

-- Procedure consultar todos os atendimento
delimiter $$
create procedure pcd_selectAtendimentos()
begin
	select 
		t1.idAtendimento,
		t1.dataHoraAtendimento, 
		t1.descricaoAtendimento, 
		t2.idStatus, 
		t2.nomeStatus, 
		t3.idClinica,
		t3.nomeClinica, 
		t4.idEndereco,
		t4.logradouroEndereco, 
		t4.numeroEndereco, 
		t4.cepEndereco, 
		t4.bairroEndereco, 
		t4.cidadeEndereco, 
		t4.siglaEstado, 
		t5.idVeterinario, 
		t5.nomeVeterinario, 
		t5.especVeterinario, 
		t6.idAnimal,
		t6.nomeAnimal,
		t6.idCliente,
		t7.nomeCliente from tbAtendimento as t1
	INNER JOIN tbStatus as t2 ON t1.idStatus = t2.idStatus
	INNER JOIN tbClinica as t3 ON t1.idClinica = t3.idClinica
	INNER JOIN tbEndereco as t4 ON t3.idEndereco = t4.idEndereco
	INNER JOIN tbVeterinario as t5 ON t1.idVeterinario = t5.idVeterinario
	INNER JOIN tbAnimal as t6 ON t1.idAnimal = t6.idAnimal
	INNER JOIN tbCliente as t7 ON t6.idCliente = t7.idCliente
	ORDER BY t1.dataHoraAtendimento DESC;
end $$

-- Procedure consultar atendimento
delimiter $$
create procedure pcd_selectAtendimento(
_idLogin int
)
begin
	select 
		t1.idAtendimento,
		t1.dataHoraAtendimento, 
		t1.descricaoAtendimento, 
		t2.idStatus, 
		t2.nomeStatus, 
		t3.idClinica,
		t3.nomeClinica, 
		t4.idEndereco,
		t4.logradouroEndereco, 
		t4.numeroEndereco, 
		t4.cepEndereco, 
		t4.bairroEndereco, 
		t4.cidadeEndereco, 
		t4.siglaEstado, 
		t5.idVeterinario, 
		t5.nomeVeterinario, 
		t5.especVeterinario, 
		t6.idAnimal,
		t6.nomeAnimal,
		t6.idCliente from tbAtendimento as t1
	INNER JOIN tbStatus as t2 ON t1.idStatus = t2.idStatus
	INNER JOIN tbClinica as t3 ON t1.idClinica = t3.idClinica
	INNER JOIN tbEndereco as t4 ON t3.idEndereco = t4.idEndereco
	INNER JOIN tbVeterinario as t5 ON t1.idVeterinario = t5.idVeterinario
	INNER JOIN tbAnimal as t6 ON t1.idAnimal = t6.idAnimal
	INNER JOIN tbCliente as t7 ON t6.idCliente = t7.idCliente
	where t2.nomeStatus = "Atendido" and t7.idLogin = _idLogin ORDER BY t1.dataHoraAtendimento DESC;
end $$

-- Procedure consultar ultimos 3 atendimentos
delimiter $$
create procedure pcd_selectUltimosAtendimentos(
_idLogin int
)
begin
	select 
		t1.idAtendimento,
		t1.dataHoraAtendimento, 
		t1.descricaoAtendimento, 
		t2.idStatus, 
		t2.nomeStatus, 
		t3.idClinica,
		t3.nomeClinica, 
		t4.idEndereco,
		t4.logradouroEndereco, 
		t4.numeroEndereco, 
		t4.cepEndereco, 
		t4.bairroEndereco, 
		t4.cidadeEndereco, 
		t4.siglaEstado, 
		t5.idVeterinario, 
		t5.nomeVeterinario, 
		t5.especVeterinario, 
		t6.idAnimal,
		t6.nomeAnimal,
		t6.idCliente from tbAtendimento as t1
	INNER JOIN tbStatus as t2 ON t1.idStatus = t2.idStatus
	INNER JOIN tbClinica as t3 ON t1.idClinica = t3.idClinica
	INNER JOIN tbEndereco as t4 ON t3.idEndereco = t4.idEndereco
	INNER JOIN tbVeterinario as t5 ON t1.idVeterinario = t5.idVeterinario
	INNER JOIN tbAnimal as t6 ON t1.idAnimal = t6.idAnimal
	INNER JOIN tbCliente as t7 ON t6.idCliente = t7.idCliente
	where nomeStatus = "Atendido" and idLogin = _idLogin ORDER BY t1.dataHoraAtendimento DESC
	LIMIT 3;
end$$

-- Procedure consultar atendimentos agendados
delimiter $$
create procedure pcd_selectAtendimentosAgendados(
_idLogin int
)
begin
	select 
		t1.idAtendimento,
		t1.dataHoraAtendimento, 
		t1.descricaoAtendimento, 
		t2.idStatus, 
		t2.nomeStatus, 
		t3.idClinica,
		t3.nomeClinica, 
		t4.idEndereco,
		t4.logradouroEndereco, 
		t4.numeroEndereco, 
		t4.cepEndereco, 
		t4.bairroEndereco, 
		t4.cidadeEndereco, 
		t4.siglaEstado, 
		t5.idVeterinario, 
		t5.nomeVeterinario, 
		t5.especVeterinario, 
		t6.idAnimal,
		t6.nomeAnimal,
		t6.idCliente from tbAtendimento as t1
	INNER JOIN tbStatus as t2 ON t1.idStatus = t2.idStatus
	INNER JOIN tbClinica as t3 ON t1.idClinica = t3.idClinica
	INNER JOIN tbEndereco as t4 ON t3.idEndereco = t4.idEndereco
	INNER JOIN tbVeterinario as t5 ON t1.idVeterinario = t5.idVeterinario
	INNER JOIN tbAnimal as t6 ON t1.idAnimal = t6.idAnimal
	INNER JOIN tbCliente as t7 ON t6.idCliente = t7.idCliente
	where nomeStatus = "Agendado" and idLogin = _idLogin ORDER BY t1.dataHoraAtendimento ASC;
end$$

-- Procedure alterar atendimento
delimiter $$
create procedure pcd_updateAtendimento(
_idAtendimento int,
_dataHoraAtendimento datetime,
_descricaoAtendimento varchar(500),
_idStatus int,
_idClinica int,
_idVeterinario int,
_idAnimal int
)
begin
	start transaction;
		update tbAtendimento set dataHoraAtendimento = _dataHoraAtendimento, descricaoAtendimento = _descricaoAtendimento,  idStatus = _idStatus,
        idClinica = _idClinica, idVeterinario = _idVeterinario, idAnimal = _idAnimal where idAtendimento = _idAtendimento;
	commit;
		rollback;
end $$

-- Procedure apagar atendimento
delimiter $$
create procedure pcd_deleteAtendimento(_idAtendimento int)
begin
	delete from tbAtendimento where idAtendimento = _idAtendimento;
end $$
-- */

-- Procedure consultar veterinarios por especialidade
delimiter $$
create procedure pcd_listarVeterinario(
_especVeterinario varchar(50)
)
begin
	select 
		t1.idVeterinario, 
		t1.nomeVeterinario, 
		t1.especVeterinario, 
		t2.idClinica,
		t2.nomeClinica, 
		t3.idEndereco,
		t3.logradouroEndereco, 
		t3.numeroEndereco, 
		t3.cepEndereco, 
		t3.bairroEndereco, 
		t3.cidadeEndereco, 
		t3.siglaEstado from tbVeterinario as t1
	INNER JOIN tbClinica as t2 ON t1.idClinica = t2.idClinica
	INNER JOIN tbEndereco as t3 ON t2.idEndereco = t3.idEndereco
	where t1.especVeterinario = _especVeterinario order by t1.especVeterinario ASC;
end$$

-- Procedure consultar atendimentos agendados
delimiter $$
create procedure pcd_listarEspecialidade()
begin
	select DISTINCT especVeterinario from tbVeterinario order by especVeterinario ASC;
end$$

/***************************************************************************/

/* -- CHAMADAS PROCEDURES LOGIN
-- Chamada da Procedure inserir login 
call pcd_insertLogin("teste","teste","teste");

-- Chamada da Procedure consultar login 
call pcd_selectLogin();

-- Chamada da Procedure testar login 
call pcd_testeLogin("teste","teste")
	
-- Chamada da Procedure alterar login
call pcd_updateLogin(3, "teste", "teste", "teste");

-- Chamada da Procedure apagar login
-- call pcd_deleteLogin(4); 
-- */

/* -- CHAMADAS PROCEDURES PLANO
-- Chamada da Procedure inserir plano 
call pcd_insertPlano("teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure consultar plano 
call pcd_selectPlano();

-- Chamada da Procedure consultar plano por tipo
call pcd_selectPlanoPorTipo("teste");

-- Chamada da Procedure consultar planos para dropdown 
call pcd_selectPlanos();

-- Chamada da Procedure consultar plano com beneficios
call pcd_selectPlanoComBeneficios();
	
-- Chamada da Procedure alterar plano
call pcd_updatePlano(3, "teste", "teste", "teste", "teste", "teste", "teste");

-- Chamada da Procedure apagar plano
-- call pcd_deletePlano(4); 
-- */

/* -- CHAMADAS PROCEDURES BENEFICIO
-- Chamada da Procedure inserir beneficio 
call pcd_insertBeneficio("teste","teste");

-- Chamada da Procedure consultar beneficio 
call pcd_selectBeneficio();
	
-- Chamada da Procedure alterar beneficio
call pcd_updateBeneficio(3, "teste", "teste");

-- Chamada da Procedure apagar beneficio
-- call pcd_deleteBeneficio(4); 
-- */

/* -- CHAMADAS PROCEDURES ENDERECO
-- Chamada da Procedure inserir endereco 
call pcd_insertEndereco("teste","teste","teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure consultar endereco por id
call pcd_selectEndereco(1);

-- Chamada da Procedure consultar endereco 
call pcd_selectEndereco();
	
-- Chamada da Procedure alterar endereco
call pcd_updateEndereco(3,"teste","teste","teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure apagar endereco
-- call pcd_deleteEndereco(4); 
-- */

/* -- CHAMADAS PROCEDURES CLIENTE
-- Chamada da Procedure inserir cliente 
call pcd_insertCliente("teste","teste","teste","teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure inserir login do cliente
call pcd_insertLoginCliente("teste","teste","teste");

-- Chamada da Procedure consultar cliente 
call pcd_selectCliente();
	
-- Chamada da Procedure alterar login do cliente
call pcd_updateLoginCliente(3, "teste", "teste", "teste");
	
-- Chamada da Procedure alterar cliente
call pcd_updateCliente(3,"teste","teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure apagar cliente
-- call pcd_deleteCliente(4); 
-- */

/* -- CHAMADAS PROCEDURES TIPO
-- Chamada da Procedure inserir tipo 
call pcd_insertTipo("teste");

-- Chamada da Procedure consultar tipo 
call pcd_selectTipo();
	
-- Chamada da Procedure alterar tipo
call pcd_updateTipo(3, "teste");

-- Chamada da Procedure apagar tipo
-- call pcd_deleteTipo(4); 
-- */

/* -- CHAMADAS PROCEDURES RACA
-- Chamada da Procedure inserir raca 
call pcd_insertRaca("teste","teste");

-- Chamada da Procedure consultar raca 
call pcd_selectRaca();
	
-- Chamada da Procedure alterar raca
call pcd_updateRaca(3, "teste", "teste");

-- Chamada da Procedure apagar raca
-- call pcd_deleteRaca(4); 
-- */

/* -- CHAMADAS PROCEDURES ANIMAL
-- Chamada da Procedure inserir animal 
call pcd_insertAnimal("teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure consultar animal 
call pcd_selectAnimal();
	
-- Chamada da Procedure alterar animal
call pcd_updateAnimal(3, "teste", "teste", "teste", "teste", "teste", "teste");

-- Chamada da Procedure apagar animal
-- call pcd_deleteAnimal(4); 
-- */

/* -- CHAMADAS PROCEDURES CUIDADO
-- Chamada da Procedure inserir cuidado 
call pcd_insertCuidado("teste","teste");

-- Chamada da Procedure consultar cuidado 
call pcd_selectCuidado();
	
-- Chamada da Procedure alterar cuidado
call pcd_updateCuidado(3, "teste", "teste");

-- Chamada da Procedure apagar cuidado
-- call pcd_deleteCuidado(4); 
-- */

/* -- CHAMADAS PROCEDURES INFORMACAO
-- Chamada da Procedure inserir informacao 
call pcd_insertInformacao("teste","teste");

-- Chamada da Procedure consultar informacao 
call pcd_selectInformacao();
	
-- Chamada da Procedure alterar informacao
call pcd_updateInformacao(3, "teste", "teste");

-- Chamada da Procedure apagar informacao
-- call pcd_deleteInformacao(4); 
-- */

/* -- CHAMADAS PROCEDURES CLINICA
-- Chamada da Procedure inserir clinica 
call pcd_insertClinica("teste","teste","teste","teste","teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure consultar clinica 
call pcd_selectClinica();
	
-- Chamada da Procedure consultar clinica por id
call pcd_selectClinicaPorId("teste");
	
-- Chamada da Procedure alterar clinica
call pcd_updateClinica(3, "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste");

-- Chamada da Procedure apagar clinica
-- call pcd_deleteClinica(4); 
-- */

/* -- CHAMADAS PROCEDURES VETERINARIO
-- Chamada da Procedure inserir veterinario 
call pcd_insertVeterinario("teste","teste","teste","teste");

-- Chamada da Procedure consultar veterinario 
call pcd_selectVeterinario();
	
-- Chamada da Procedure alterar veterinario
call pcd_updateVeterinario(3, "teste", "teste", "teste", "teste");

-- Chamada da Procedure apagar veterinario
-- call pcd_deleteVeterinario(4); 
-- */

/* -- CHAMADAS PROCEDURES ATENDIMENTO
-- Chamada da Procedure inserir atendimento 
call pcd_insertAtendimento("teste","teste","teste","teste","teste","teste","teste");

-- Chamada da Procedure consultar atendimento 
call pcd_selectAtendimento();

-- Chamada da Procedure consultar atendimento por cliente
call pcd_selectAtendimentoPorCliente("teste");
	
-- Chamada da Procedure alterar atendimento
call pcd_updateAtendimento(3, "teste", "teste", "teste", "teste", "teste", "teste", "teste");

-- Chamada da Procedure apagar atendimento
-- call pcd_deleteAtendimento(4); 
-- */
/***************************************************************************/

call pcd_insertLogin("Maycon","maycon@email.com","senha123","0");
call pcd_insertLogin("Marcus","marcus@email.com","54321","1");
call pcd_insertLogin("Pedro","pedro@email.com","12345","2");
call pcd_selectLogin();

call pcd_insertPlano("Prata","Mais Econômico","R$49,90","Básico","#E3E3E3","/Imagens/Plano 1.png","O Plano Prata é a escolha ideal para cuidados básicos e acessíveis do seu pet. Ele oferece um check-up anual completo para garantir que seu amiguinho esteja sempre saudável. Além disso, você terá acesso ao suporte telefônico 24h, fornecendo orientações e esclarecimentos em momentos de emergência. Nossos benefícios exclusivos incluem descontos em consultas veterinárias, permitindo que você cuide da saúde do seu pet com profissionais qualificados, entre outros...\nCom o Plano Prata, você terá a tranquilidade de saber que seu pet receberá os cuidados necessários, sem comprometer sua renda. Proporcione ao seu amiguinho toda a atenção e carinho que ele merece, garantindo sua saúde e bem-estar por um preço acessível.\nInvista no Plano Prata e proporcione ao seu pet uma vida longa e saudável");
call pcd_insertPlano("Ouro","Melhor Custo Benefício ","R$99,90","Básico","#FFBB00","/Imagens/Plano 2.png","O Plano Ouro é a opção básica que vai além do Plano Prata.\nAlém de todos os benefícios do Plano Prata, o Plano Ouro inclui consultas ilimitadas, proporcionando atendimento veterinário sempre que necessário, você terá acesso a exames laboratoriais abrangentes, permitindo uma avaliação detalhada da saúde do seu pet. Com essa ampla cobertura, você terá a certeza de que seu amiguinho receberá todos os cuidados necessários para uma vida saudável. O Plano Ouro também oferece descontos em serviços especializados, como cirurgias, tratamentos terapêuticos e serviços de emergência. Dessa forma, você poderá proporcionar ao seu pet cuidados de alto nível, mesmo em situações mais complexas.\nEscolha o Plano Ouro e ofereça ao seu amiguinho uma vida repleta de saúde, bem-estar e carinho.");
call pcd_insertPlano("Diamante","Mais Cobertura","R$159,90","Básico","#1DE1CA","/Imagens/Plano 3.png","O Plano Diamante é a escolha mais exclusiva, reunindo todos os benefícios do Plano Ouro e muito mais. Além de oferecer consultas ilimitadas, exames laboratoriais abrangentes e descontos em serviços especializados, o Plano Diamante ainda garante uma cobertura de emergência 24 horas, fornecendo assistência imediata em casos de necessidade. Você terá acesso a tratamentos avançados, que vão além dos cuidados básicos, proporcionando opções terapêuticas e avançadas para garantir o bem-estar completo do seu pet.\nEscolha o Plano Diamante e proporcione ao seu amiguinho uma vida saudável e cheia de mimos. Invista no bem-estar do seu pet com o Plano Diamante e desfrute de todos os benefícios que ele oferece.");
call pcd_insertPlano("Ruby","Maior Acessibilidade","R$249,90","Premium","#E32A2A","/Imagens/Plano 4.png","O Plano Ruby é a opção premium além do Plano Diamante, oferecendo um conjunto completo de benefícios para o seu pet. Além de incluir todos os benefícios do Plano Diamante, inclui consultas domiciliares, programa de reabilitação e fisioterapia, proporcionando suporte completo para a recuperação e bem-estar do seu pet.\nPara mais comodidade, o Plano Ruby oferece serviço de transporte para consultas e emergências. Nossa equipe estará disponível para buscá-lo e levá-lo às consultas necessárias, garantindo que ele receba os cuidados adequados, mesmo em emergências.\nEscolha o Plano Ruby e proporcione ao seu pet uma experiência de cuidado premium!");
call pcd_insertPlano("Safira","Mais Benefícios","R$349,90","Premium","#5F06B8","/Imagens/Plano 5.png","O Plano Safira é a opção premium mais completa, indo além do Plano Ruby, oferecendo uma gama completa de benefícios para o seu pet. Além de todos os benefícios de todos os planos até agora, o Plano Safira oferece consultas com especialistas renomados, garantindo atendimento de alta qualidade para o seu amiguinho, você terá acesso ao serviço de creche e hotel para pets, proporcionando um ambiente seguro e confortável quando você precisar se ausentar.\nPara garantir a saúde do seu pet, o Plano Safira oferece um programa de prevenção e controle de parasitas, mantendo-o protegido contra pulgas, carrapatos e outros parasitas indesejados.\nCom o Plano Safira, seu pet receberá os melhores cuidados, desde consultas especializadas até hospedagem e prevenção de parasitas!");
call pcd_insertPlano("Esmeralda","Animais Exóticos","R$459,90*","Premium","#50C878","/Imagens/Plano 6.png","O Plano Esmeralda é exclusivamente desenvolvido para atender aos requisitos especiais de animais exóticos. Com foco em cuidados personalizados, o plano oferece consultas com veterinários especializados em animais exóticos, garantindo um atendimento de qualidade para cada espécie.\nGarantimos que seu animal receba a atenção e os cuidados necessários para sua saúde e bem-estar.\nInvista no bem-estar do seu animal com o Plano Esmeralda e desfrute dos benefícios exclusivos que oferecemos. Essa flexibilidade permite que cada proprietário receba um plano personalizado conforme as necessidades específicas do seu animal de estimação exótico.");
-- call pcd_selectPlano();

call pcd_insertBeneficio("Check-up anual completo","1");
call pcd_insertBeneficio("Vacinações essenciais","1");
call pcd_insertBeneficio("Linha telefônica de suporte 24h","1");
call pcd_insertBeneficio("Descontos em consultas veterinárias","1");
call pcd_insertBeneficio("Descontos em medicamentos e procedimentos de rotina","1");
call pcd_insertBeneficio("Consultas ilimitadas","2");
call pcd_insertBeneficio("Exames laboratoriais abrangentes","2");
call pcd_insertBeneficio("Descontos em castração, microchipagem e tratamentos odontológicos","2");
call pcd_insertBeneficio("Exames de sangue e urina","2");
call pcd_insertBeneficio("Acesso a serviços especializados","2");
call pcd_insertBeneficio("Cobertura de emergência 24h","3");
call pcd_insertBeneficio("Acesso a tratamentos avançados e especializados","3");
call pcd_insertBeneficio("Cirurgias complexas e terapias alternativas","3");
call pcd_insertBeneficio("Medicamentos de última geração","3");
call pcd_insertBeneficio("Descontos em produtos de bem-estar","3");
call pcd_insertBeneficio("Consultas domiciliares","4");
call pcd_insertBeneficio("Programa de reabilitação e fisioterapia","4");
call pcd_insertBeneficio("Serviço de transporte para consultas e emergências","4");
call pcd_insertBeneficio("Atendimento para animais com dificuldade de locomoção","4");
call pcd_insertBeneficio("Suporte para proprietários com limitações físicas","4");
call pcd_insertBeneficio("Consultas com especialistas renomados","5");
call pcd_insertBeneficio("Serviço de creche e hotel para pets","5");
call pcd_insertBeneficio("Programa de prevenção e controle de parasitas","5");
call pcd_insertBeneficio("Tratamentos contra pulgas, carrapatos e vermes","5");
call pcd_insertBeneficio("Acesso a especialidades como dermatologia, oftalmologia, cardiologia e oncologia","5");
call pcd_insertBeneficio("Consultas com veterinários especializados em animais exóticos","6");
call pcd_insertBeneficio("Check-up anual completo adaptado a animais exóticos","6");
call pcd_insertBeneficio("Acesso a tratamentos e medicamentos específicos para animais exóticos","6");
call pcd_insertBeneficio("Suporte telefônico 24h com especialistas em animais exóticos","6");
call pcd_insertBeneficio("Descontos em serviços e produtos especializados para animais exóticos","6");
-- call pcd_selectBeneficio();

call pcd_insertTipo("Cachorro");
call pcd_insertTipo("Gato");
call pcd_insertTipo("Hamster");
call pcd_insertTipo("Pássaro");
call pcd_insertTipo("Coelho");
call pcd_insertTipo("Peixe");
call pcd_insertTipo("Répteis");
call pcd_insertTipo("Exóticos");
-- call pcd_selectTipo();

call pcd_insertRaca("Labrador Retriever", 1); -- Cachorro
call pcd_insertRaca("Dobberman", 1); -- Cachorro
call pcd_insertRaca("Golden Retriever", 1); -- Cachorro
call pcd_insertRaca("Pastor Alemão", 1); -- Cachorro
call pcd_insertRaca("Buldogue", 1); -- Cachorro
call pcd_insertRaca("Poodle", 1); -- Cachorro
call pcd_insertRaca("Persa", 2); -- Gato
call pcd_insertRaca("Siamês", 2); -- Gato
call pcd_insertRaca("Maine Coon", 2); -- Gato
call pcd_insertRaca("Ragdoll", 2); -- Gato
call pcd_insertRaca("Sphynx", 2); -- Gato
call pcd_insertRaca("Sírio", 3); -- Hamster
call pcd_insertRaca("Roborovski", 3); -- Hamster
call pcd_insertRaca("Campbell", 3); -- Hamster
call pcd_insertRaca("Anão Russo", 3); -- Hamster
call pcd_insertRaca("Chinese", 3); -- Hamster
call pcd_insertRaca("Calopsita", 4); -- Pássaro
call pcd_insertRaca("Periquito Australiano", 4); -- Pássaro
call pcd_insertRaca("Canário", 4); -- Pássaro
call pcd_insertRaca("Papagaio", 4); -- Pássaro
call pcd_insertRaca("Agapornis", 4); -- Pássaro
call pcd_insertRaca("Mini Lop", 5); -- Coelho
call pcd_insertRaca("Holland Lop", 5); -- Coelho
call pcd_insertRaca("Netherland Dwarf", 5); -- Coelho
call pcd_insertRaca("Leão", 5); -- Coelho
call pcd_insertRaca("Gigante de Flandres", 5); -- Coelho
call pcd_insertRaca("Betta", 6); -- Peixe
call pcd_insertRaca("Molly", 6); -- Peixe
call pcd_insertRaca("Guppy", 6); -- Peixe
call pcd_insertRaca("Tetra", 6); -- Peixe
call pcd_insertRaca("Oscar", 6); -- Peixe
call pcd_insertRaca("Iguana", 7); -- Répteis
call pcd_insertRaca("Camaleão", 7); -- Répteis
call pcd_insertRaca("Gecko Leopardo", 7); -- Répteis
call pcd_insertRaca("Jiboia", 7); -- Répteis
call pcd_insertRaca("Tartaruga", 7); -- Répteis
call pcd_insertRaca("Ferret", 8); -- Exóticos
call pcd_insertRaca("Chinchila", 8); -- Exóticos
call pcd_insertRaca("Tarântula", 8); -- Exóticos
call pcd_insertRaca("Escorpião", 8); -- Exóticos
call pcd_insertRaca("Sugarglider", 8); -- Exóticos
-- call pcd_selectRaca();

call pcd_insertEndereco("Clínica Veterinária PetCare","Rua Oscar Freire","123","","01426-001","Jardins","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Amigo Fiel","Avenida Paulista","456","","01310-000","Bela Vista","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Vida Animal","Rua Augusta","789","","01305-100","Consolação","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Bicho Feliz","Avenida Rebouças","987","","05401-100","Pinheiros","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Pets & Cia","Rua Itapeva","321",""," 01332-000","Bela Vista","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Mundo Pet","Rua Dr. Alceu de Campos Rodrigues","456","","04544-000","Vila Nova Conceição","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Animalis","Avenida Engenheiro Luís Carlos Berrini","789","","04571-000","Itaim Bibi","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária PetVet","Rua Pamplona","1234","","01405-001","Jardim Paulista","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária Patinhas Felizes","Avenida Indianópolis","567","","04063-000","Moema","São Paulo","SP");
call pcd_insertEndereco("Clínica Veterinária PetCenter","Rua Fradique Coutinho","987","","05416-001","Pinheiros","São Paulo","SP");
call pcd_insertEndereco("Minha Casa","Rua da Coreografia","668","Bloco 3, Apt.35","04937-250","Jardim Planalto","São Paulo","SP");
-- call pcd_selectEndereco();

call pcd_insertClinica("PetCare","(11) 4444-4444","(11) 5555-5555","contato@petcare.com","5.0","Seg-Sex: 9h-18h, Sáb: 9h-13h","1");
call pcd_insertClinica("Amigo Fiel","(11) 4444-4448","(11) 4444-4449","contato@amigofiel.com","5.0","Seg-Sex: 8h-20h, Sáb: 9h-16h","2");
call pcd_insertClinica("Vida Animal","(11) 4444-4453","(11) 4444-4454","contato@vidaanimal.com","3.5","Seg-Sex: 8h-19h, Sáb: 9h-13h","3");
call pcd_insertClinica("Bicho Feliz","(11) 4444-4458","(11) 4444-4459","contato@bichofeliz.com","4.5","Seg-Sex: 9h-18h, Sáb: 9h-14h","4");
call pcd_insertClinica("Pets & Cia","(11) 4444-4463","(11) 4444-4464","contato@petscia.com","5.0","Seg-Sex: 8h-20h, Sáb: 9h-17h","5");
call pcd_insertClinica("Mundo Pet","(11) 4444-4468","(11) 4444-4469","contato@mundopet.com","4.0","Seg-Sex: 9h-19h, Sáb: 9h-14h","6");
call pcd_insertClinica("Animalis","(11) 4444-4473","(11) 4444-4474","contato@animalis.com","4.5","Seg-Sex: 8h-18h, Sáb: 9h-12h","7");
call pcd_insertClinica("PetVet","(11) 4444-4478","(11) 4444-4479","contato@petvet.com","4.5","Seg-Sex: 8h-20h, Sáb: 9h-16h","8");
call pcd_insertClinica("Patinhas Felizes","(11) 4444-4483","(11) 4444-4484","contato@patinhasfelizes.com","4.0","Seg-Sex: 9h-18h, Sáb: 9h-13h","9");
call pcd_insertClinica("PetCenter","(11) 4444-4488","(11) 4444-4489","contato@petcenter.com","5.0","Seg-Sex: 8h-19h, Sáb: 9h-15h","10");
-- call pcd_selectClinica();

call pcd_insertCliente("Pedro","Henrique","23.294.954-2","457.904.688-96","(11) 3829-1787","(11) 99592-3957",11,3,2);
-- call pcd_selectCliente();

call pcd_insertAnimal("Azulão","Zuzu", 3,"/Imagens/Peixe.png",27,1);
call pcd_insertAnimal("Cleiton","Cleitin", 2,"/Imagens/CachorroNãoTãoBonito.png",5,1);
-- call pcd_selectAnimal();

call pcd_insertCuidado("Insulina","1");
call pcd_insertCuidado("novalgina","1");
call pcd_insertCuidado("Cat-nip","1");
call pcd_insertCuidado("Dipirona","1");
call pcd_insertCuidado("Insulina","2");
call pcd_insertCuidado("novalgina","2");
call pcd_insertCuidado("Cat-nip","2");
call pcd_insertCuidado("Dipirona","2");
-- call pcd_selectCuidado();

call pcd_insertInformacao("Carinhoso","1");
call pcd_insertInformacao("Medroso","1");
call pcd_insertInformacao("Sapequinha","1");
call pcd_insertInformacao("Bagunceiro","1");
call pcd_insertInformacao("Sofrendo pela Ex","1");
call pcd_insertInformacao("Cachaceiro","1");
-- call pcd_selectInformacao();

call pcd_insertVeterinario("Lucas Silva","Clínica Geral","(11) 1111-1111","lucas.silva@petcare.com",1);
call pcd_insertVeterinario("Isabela Santos","Dermatologia","(11) 2222-2222","isabela.santos@petcare.com",1);
call pcd_insertVeterinario("Gustavo Oliveira","Cirurgia","(11) 3333-3333","gustavo.oliveira@petcare.com",1);
call pcd_insertVeterinario("Pedro Rodrigues","Cardiologia","(11) 4444-4445","pedro.rodrigues@amigofiel.com",2);
call pcd_insertVeterinario("Camila Costa","Odontologia","(11) 4444-4446","camila.costa@amigofiel.com",2);
call pcd_insertVeterinario("Rafael Almeida","Ortopedia","(11) 4444-4447","rafael.almeida@amigofiel.com",2);
call pcd_insertVeterinario("Thiago Lima","Clínica Geral","(11) 4444-4450","thiago.lima@vidaanimal.com",3);
call pcd_insertVeterinario("Marina Castro","Oftalmologia","(11) 4444-4451","marina.castro@vidaanimal.com",3);
call pcd_insertVeterinario("Ricardo Santos","Neurologia","(11) 4444-4452","ricardo.santos@vidaanimal.com",3);
call pcd_insertVeterinario("Marcelo Oliveira","Oncologia","(11) 4444-4455","marcelo.oliveira@bichofeliz.com",4);
call pcd_insertVeterinario("Juliana Mendes","Endocrinologia","(11) 4444-4456","juliana.mendes@bichofeliz.com",4);
call pcd_insertVeterinario("Leonardo Santos","Ortopedia","(11) 4444-4457","leonardo.santos@bichofeliz.com",4);
call pcd_insertVeterinario("Rodrigo Almeida","Clínica Geral","(11) 4444-4460","rodrigo.almeida@petscia.com",5);
call pcd_insertVeterinario("Amanda Costa","Dermatologia","(11) 4444-4461","amanda.costa@petscia.com",5);
call pcd_insertVeterinario("Eduardo Santos","Cirurgia","(11) 4444-4462","eduardo.santos@petscia.com",5);
call pcd_insertVeterinario("Victor Lima","Clínica Geral","(11) 4444-4465","victor.lima@mundopet.com",6);
call pcd_insertVeterinario("Gabriela Oliveira","Cardiologia","(11) 4444-4466","gabriela.oliveira@mundopet.com",6);
call pcd_insertVeterinario("Henrique Santos","Cirurgia","(11) 4444-4467","henrique.santos@mundopet.com",6);
call pcd_insertVeterinario("Felipe Costa","Clínica Geral","(11) 4444-4470","felipe.costa@animalis.com",7);
call pcd_insertVeterinario("Larissa Fernandes","Dermatologia","(11) 4444-4471","larissa.fernandes@animalis.com",7);
call pcd_insertVeterinario("Ricardo Oliveira","Ortopedia","(11) 4444-4472","ricardo.oliveira@animalis.com",7);
call pcd_insertVeterinario("Gabriel Alves","Clínica Geral","(11) 4444-4475","gabriel.alves@petvet.com",8);
call pcd_insertVeterinario("Marcela Lima","Oftalmologia","(11) 4444-4476","marcela.lima@petvet.com",8);
call pcd_insertVeterinario("Daniel Santos","Neurologia","(11) 4444-4477","daniel.santos@petvet.com",8);
call pcd_insertVeterinario("Renato Almeida","Clínica Geral","(11) 4444-4480","renato.almeida@patinhasfelizes.com",9);
call pcd_insertVeterinario("Juliana Santos","Odontologia","(11) 4444-4481","juliana.santos@patinhasfelizes.com",9);
call pcd_insertVeterinario("Eduardo Costa","Oncologia","(11) 4444-4482","eduardo.costa@patinhasfelizes.com",9);
call pcd_insertVeterinario("Ricardo Almeida","Clínica Geral","(11) 4444-4485","ricardo.almeida@petcenter.com",10);
call pcd_insertVeterinario("Ana Costa","Dermatologia","(11) 4444-4486","ana.costa@petcenter.com",10);
call pcd_insertVeterinario("Gustavo Santos","Cardiologia","(11) 4444-4487","gustavo.santos@petcenter.com",10);
-- call pcd_selectVeterinario();

CALL pcd_insertAtendimento('2023-06-24 10:00:00', 'Consulta de rotina', 1, 1, 1, 1);
CALL pcd_insertAtendimento('2023-06-25 14:00:00', 'Vacinação', 1, 2, 2, 2);
CALL pcd_insertAtendimento('2023-06-26 16:00:00', 'Exame de sangue', 1, 3, 3, 2);
CALL pcd_insertAtendimento('2023-05-27 10:00:00', 'Consulta de rotina', 2, 4, 4, 1);
CALL pcd_insertAtendimento('2023-01-18 14:00:00', 'Vacinação', 2, 1, 5, 1);
CALL pcd_insertAtendimento('2023-04-29 16:00:00', 'Exame de sangue', 2, 2, 1, 2);
CALL pcd_insertAtendimento('2023-06-30 10:00:00', 'Consulta de rotina', 1, 3, 2, 1);
CALL pcd_insertAtendimento('2023-07-01 14:00:00', 'Vacinação', 1, 4, 3, 2);
CALL pcd_insertAtendimento('2023-07-02 16:00:00', 'Exame de sangue', 1, 1, 4, 2);
CALL pcd_insertAtendimento('2023-03-03 10:00:00', 'Consulta de rotina', 2, 2, 5, 2);

CALL pcd_insertAtendimento('2023-06-07 10:00:00', 'Consulta de rotina', 2, 4, 4, 1);
CALL pcd_insertAtendimento('2023-06-20 14:00:00', 'Vacinação', 2, 1, 5, 1);
CALL pcd_insertAtendimento('2023-05-29 16:00:00', 'Exame de sangue', 2, 2, 1, 1);
CALL pcd_insertAtendimento('2023-06-30 10:00:00', 'Consulta de rotina', 1, 3, 2, 2);
CALL pcd_insertAtendimento('2023-07-01 14:00:00', 'Vacinação', 1, 4, 3, 1);
CALL pcd_insertAtendimento('2023-07-02 16:00:00', 'Exame de sangue', 1, 1, 4, 2);
CALL pcd_insertAtendimento('2023-05-13 10:00:00', 'Consulta de rotina', 2, 2, 5, 2);
CALL pcd_insertAtendimento('2023-02-24 14:00:00', 'Vacinação', 2, 3, 1, 1);
CALL pcd_insertAtendimento('2023-03-05 16:00:00', 'Exame de sangue', 2, 4, 2, 2);
CALL pcd_insertAtendimento('2023-07-06 10:00:00', 'Consulta de rotina', 1, 1, 3, 1);
/*
call pcd_selectAtendimento();
call pcd_selectUltimosAtendimentos();
call pcd_selectAtendimentosAgendados();*/
/*
call pcd_testeLogin("maycon@email.com","senha123");

call pcd_selectBeneficio();

select * from tbEstado;*/