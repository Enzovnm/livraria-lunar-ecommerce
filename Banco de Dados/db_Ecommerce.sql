create database db_Ecommerce
default character set utf8
default collate utf8_general_ci;

use db_Ecommerce;

/* CRIAÇÃO DAS TABELAS */ 

/*TABELA USUÁRIO*/
create table tbl_Usuario
(
cd_usuario int primary key auto_increment, 
nm_usuario varchar(70) not null, 
ds_email varchar(70) not null, 
ds_senha char(20) not null, 
no_cpf char(14) not null, 
no_telefone char(15) not null,
no_celular char(15) not null,
nm_logradouro varchar(160) not null,
no_logradouro varchar(5) not null,
ds_complemento varchar(60),
nm_bairro varchar(120) not null,
nm_cidade varchar(120) not null,
sg_uf char(2) not null,
no_cep char(8) not null,
sg_sexo char(1) not null, 
ds_status int not null, 
ds_tipo enum('1','2','3') not null
)default charset utf8; 

/*TABELA COMENTÁRIO*/
create table tbl_Comentario
(
cd_comentario int primary key auto_increment, 
ds_comentario varchar(1000) not null, 
cd_usuario int not null, 
dt_comentario varchar(12) not null,
foreign key(cd_usuario)references tbl_Usuario(cd_usuario)
)default charset utf8;

/*TABELA EDITORA*/
create table tbl_Editora
(
cd_editora int primary key auto_increment,
nm_editora varchar(70) not null
)default charset utf8;


/*TABELA AUTOR*/
create table tbl_Autor
(
cd_autor int primary key auto_increment,
nm_autor varchar(70) not null,
ds_status int not null
)default charset utf8;


/*TABELA CATEGORIA*/
create table tbl_Categoria
(
cd_categoria int primary key auto_increment, 
nm_categoria varchar(70) not null
)default charset utf8;


/*Inserir categoria Livros */
insert into tbl_categoria values(1, 'Livros'); 

/*TABELA PRODUTO */
create table tbl_Produto
(
cd_produto int primary key auto_increment,
nm_Produto varchar(70) not null, 
qt_estoque int not null, 
vl_unitario decimal(10,2) not null,
img_produto varchar(255) not null,
desc_produto varchar(1000) not null,
cd_categoria int,
foreign key(cd_categoria) references tbl_Categoria(cd_categoria)
)default charset utf8;

/*TABELA LIVRO */
create table tbl_Livro
(
cd_produto int,
no_paginas int,
no_isbn varchar(13),
dt_publicada date,
cd_autor int,
cd_editora int,
primary key(cd_produto),
foreign key(cd_produto) references tbl_Produto(cd_produto),
foreign key(cd_autor) references tbl_Autor(cd_autor),
foreign key(cd_editora) references tbl_Editora(cd_editora)
)default charset utf8;

/* TABELA COMPRA*/
create table tbl_Compra
(
cd_compra int primary key auto_increment,
dt_compra date not null,
vl_total decimal(10,2) not null,
cd_usuario int,
foreign key(cd_usuario) references tbl_Usuario(cd_usuario)
)default charset utf8; 

/* TABELA ITEM COMPRAS*/
create table tbl_ItemCompras
(
cd_itemCompras int primary key auto_increment,
cd_compra int,
cd_produto int, 
qtdeVendas int not null,
foreign key(cd_compra) references tbl_Compra(cd_compra),
foreign key(cd_produto) references tbl_Produto(cd_produto)
)default charset utf8;

/* TABELA PAGAMENTO*/
create table tbl_Pagamento 
(
cd_pagamento int primary key auto_increment,
ds_pagamento varchar(20) not null
)default charset utf8; 


/* INSERT PAGAMENTO*/ 
insert into tbl_Pagamento values 
(default, 'Boleto'),
(default, 'Cartão');

/* TABELA ENTREGA */
create table tbl_Entrega
(
cd_entrega int primary key auto_increment not null,
dt_entrega date not null,
cd_compra int,
foreign key(cd_compra) references tbl_Compra(cd_compra)
)default charset utf8;

/* ---------------------------------*/



/* ---------CRIAÇÃO DE PROCEDURES--------- */

/*PROCEDURE PARA INSERIR ADMINISTRADORES */
drop procedure if exists sp_InsAdministradores;
DELIMITER && 
create procedure sp_InsAdministradores
(
 nm_usuario varchar(70),
 ds_email varchar(70), 
 ds_senha char(20),
 no_cpf char(14),
 no_telefone char(15),
 no_celular char(15),
 nm_logradouro varchar(160),
 no_logradouro varchar(5),
 ds_complemento varchar(60),
 nm_bairro varchar(120),
 nm_cidade varchar(120),
 sg_uf char(2),
 no_cep char(8),
 sg_sexo char(1),
 ds_status int,
 ds_tipo enum('1','2','3')
)
BEGIN 
insert into tbl_usuario(nm_usuario, ds_email, ds_senha, no_cpf, no_telefone, no_celular, nm_logradouro, no_logradouro, ds_complemento, nm_bairro, nm_cidade,
sg_uf, no_cep, sg_sexo, ds_status, ds_tipo)
values(nm_usuario, ds_email, ds_senha, no_cpf, no_telefone, no_celular, nm_logradouro, no_logradouro, ds_complemento, nm_bairro, nm_cidade,
sg_uf, no_cep, sg_sexo, ds_status, ds_tipo); 
end && 
DELIMITER ;


/* PROCEDURE PARA ALTERAR ADMINISTRADORES */
drop procedure if exists sp_AltAdministradores; 
DELIMITER && 
create procedure sp_AltAdministradores
(
 CodUsuario int, 
 nm_usuario varchar(70),
 ds_email varchar(70), 
 ds_senha char(20),
 no_cpf char(14),
 no_telefone char(15),
 no_celular char(15),
 nm_logradouro varchar(160),
 no_logradouro varchar(5),
 ds_complemento varchar(60),
 nm_bairro varchar(120),
 nm_cidade varchar(120),
 sg_uf char(2),
 no_cep char(8),
 sg_sexo char(1),
 ds_status int,
 ds_tipo enum('1','2','3')
)
BEGIN 
update tbl_Usuario
set nm_usuario = nm_usuario, ds_email = ds_email, ds_senha = ds_senha, no_cpf = no_cpf, no_telefone = no_telefone,no_celular = no_celular, 
nm_logradouro = nm_logradouro, no_logradouro = no_logradouro, ds_complemento = ds_complemento, nm_bairro = nm_bairro, nm_cidade = nm_cidade, sg_uf = sg_uf, no_cep = no_cep, 
sg_sexo = sg_sexo, ds_status = ds_status, ds_tipo = ds_tipo where cd_usuario = CodUsuario; 
end &&
DELIMITER ;


/* PROCEDURE PARA CONSULTAR ADMINISTRADORES */
drop procedure if exists sp_MostraFuncionarios; 
delimiter &&
create procedure sp_MostraFuncionarios()
begin 
select cd_usuario,nm_usuario, ds_email,no_telefone,no_celular, no_cpf, nm_logradouro,no_logradouro, ds_complemento, nm_bairro,sg_uf,nm_cidade,no_cep,sg_sexo, ds_status, ds_tipo from tbl_Usuario where ds_tipo > 1 order by nm_usuario asc;
end &&
delimiter ;



/* PROCEDURE PARA EXCLUIR ADMINISTRADORES E USUARIOS */
drop procedure if exists sp_ExcUsuario; 
DELIMITER && 
create procedure sp_ExcUsuario
(
CodUsuario int
)
BEGIN
delete from tbl_Usuario where cd_usuario = CodUsuario;
end && 
DELIMITER ; 





/* PROCEDURE PARA INSERIR USUÁRIO */
drop procedure if exists sp_InsUsuario;
DELIMITER && 
create procedure sp_InsUsuario
(
 nm_usuario varchar(70),
 ds_email varchar(70), 
 ds_senha char(20),
 no_cpf char(14),
 no_telefone char(15),
 no_celular char(15),
 nm_logradouro varchar(160),
 no_logradouro varchar(5),
 ds_complemento varchar(60),
 nm_bairro varchar(120),
 nm_cidade varchar(120),
 sg_uf char(2),
 no_cep char(8),
 sg_sexo char(1)
)
BEGIN 
declare ds_status int;
declare ds_tipo enum('1','2','3');
set ds_status = 1; 
set ds_tipo = 1;
insert into tbl_usuario(nm_usuario, ds_email, ds_senha, no_cpf, no_telefone, no_celular, nm_logradouro, no_logradouro, ds_complemento, nm_bairro, nm_cidade,
sg_uf, no_cep, sg_sexo, ds_status, ds_tipo)
values(nm_usuario, ds_email, ds_senha, no_cpf, no_telefone, no_celular, nm_logradouro, no_logradouro, ds_complemento, nm_bairro, nm_cidade,
sg_uf, no_cep, sg_sexo, ds_status, ds_tipo); 
end && 
DELIMITER ;


/* PROCEDURE PARA CONSULTAR USUÁRIO */ 
drop procedure if exists sp_MostraUsuarios
delimiter &&
create procedure sp_MostraUsuarios()
begin 
select * from tbl_Usuario where ds_tipo < 2 order by nm_usuario asc;
end &&
delimiter ;



/* PROCEDURE PARA ALTERAR USUÁRIO */
drop procedure if exists sp_AltUsuario; 
DELIMITER && 
Drop procedure if exists sp_AltUsuario; 
DELIMITER && 
create procedure sp_AltUsuario
(
 CodUsuario int, 
 nm_usuario varchar(70),
 ds_email varchar(70), 
 ds_senha char(20),
 no_cpf char(14),
 no_telefone char(15),
 no_celular char(15),
 nm_logradouro varchar(160),
 no_logradouro varchar(5),
 ds_complemento varchar(60),
 nm_bairro varchar(120),
 nm_cidade varchar(120),
 sg_uf char(2),
 no_cep char(8),
 sg_sexo char(1)
)
BEGIN 
declare ds_status int;  
declare ds_tipo enum('1','2','3');
set ds_status = 1;
set ds_tipo = '1';  
update tbl_Usuario
set nm_usuario = nm_usuario, ds_email = ds_email, ds_senha = ds_senha, no_cpf = no_cpf, no_telefone = no_telefone,no_celular = no_celular, 
nm_logradouro = nm_logradouro, no_logradouro = no_logradouro, ds_complemento = ds_complemento, nm_bairro = nm_bairro, nm_cidade = nm_cidade, sg_uf = sg_uf, no_cep = no_cep, 
sg_sexo = sg_sexo, ds_status = ds_status, ds_tipo = ds_tipo where cd_usuario = CodUsuario; 
end &&
DELIMITER ; 


/* PROCEDURE PARA DESATIVAR USUÁRIO */
drop procedure if exists sp_DesativarConta; 
DELIMITER && 
create procedure sp_DesativarConta
(
 CodUsuario int
)
BEGIN 
declare ds_status int;  
set ds_status = 0;  
update tbl_Usuario
set ds_status = ds_status where cd_usuario = CodUsuario; 
end &&
DELIMITER ;



/* PROCEDURE PARA INSERIR CATEGORIA */
drop procedure if exists sp_InsCategoria;
DELIMITER && 
create procedure sp_InsCategoria
(
 nm_categoria varchar(70) 
)
BEGIN 
insert into tbl_Categoria(nm_Categoria)
values(nm_categoria); 
end && 
DELIMITER ;


/* PROCEDURE PARA ALTERAR CATEGORIA */
drop procedure if exists sp_AltCategoria; 
DELIMITER && 
create procedure sp_AltCategoria
(
 CodCategoria int,
 nm_categoria varchar(70) 
)
BEGIN 
update tbl_Categoria 
set nm_categoria = nm_categoria where cd_categoria = CodCategoria; 
end &&
DELIMITER ; 


/* PROCEDURE PARA EXCLUIR CATEGORIA */
drop procedure if exists sp_ExcCategoria; 
DELIMITER && 
create procedure sp_ExcCategoria
(
CodCategoria int
)
BEGIN
delete from tbl_Categoria where cd_categoria = CodCategoria;
end && 
DELIMITER ; 

/* PROCEDURE PARA CONSULTAR CATEGORIA */
drop procedure if exists sp_MostraCategoria
DELIMITER &&
create procedure sp_MostraCategoria()
begin 
select * from tbl_Categoria;
end &&
DELIMITER ;



/* PROCEDURE PARA INSERIR AUTOR */
drop procedure if exists sp_InsAutor;
DELIMITER && 
create procedure sp_InsAutor
(
 nm_autor varchar(70), 
 ds_status int
)
BEGIN 
insert into tbl_Autor(nm_autor, ds_status)
values(nm_autor, ds_status); 
end && 
DELIMITER ;



/* PROCEDURE PARA ALTERAR AUTOR */
Drop procedure if exists sp_AltAutor; 
DELIMITER && 
create procedure sp_AltAutor
(
 CodAutor int,
 nm_autor varchar(70), 
 ds_status int
)
BEGIN 
update tbl_Autor 
set nm_autor = nm_autor, ds_status = ds_status where cd_autor = CodAutor; 
end &&
DELIMITER ; 



/* PROCEDURE PARA CONSULTAR AUTOR */
drop procedure if exists sp_MostraAutor
DELIMITER &&
create procedure sp_MostraAutor()
begin 
select * from tbl_Autor;
end &&
delimiter ;



/* PROCEDURE PARA INSERIR EDITORA */
drop procedure if exists sp_InsEditora;
DELIMITER && 
create procedure sp_InsEditora
(
 nm_editora varchar(70)
)
BEGIN 
insert into tbl_Editora(nm_editora)
values(nm_editora); 
end && 
DELIMITER ;


/* PROCEDURE PARA ALTERAR EDITORA */
Drop procedure if exists sp_AltEditora; 
DELIMITER && 
create procedure sp_AltEditora
(
 CodEditora int,
 nm_editora varchar(70)
)
BEGIN 
update tbl_Editora 
set nm_editora = nm_editora where cd_editora = CodEditora; 
end &&
DELIMITER ; 


/* PROCEDURE PARA EXCLUIR EDITORA */
drop procedure if exists sp_ExcEditora; 
DELIMITER && 
create procedure sp_ExcEditora
(
CodEditora int
)
BEGIN
delete from tbl_Editora where cd_editora = CodEditora;
end && 
DELIMITER ;


/* PROCEDURE PARA CONSULTAR EDITORA */
drop procedure if exists sp_MostraEditora
DELIMITER &&
create procedure sp_MostraEditora()
begin 
select * from tbl_Editora;
end &&
delimiter ;




/* PROCEDURE PARA INSERIR COMENTÁRIO */
drop procedure if exists sp_InsComentario;
DELIMITER && 
create procedure sp_InsComentario
(
ds_comentario varchar(1000),
cd_usuario int 
)
BEGIN 
declare DataComentario date; 
set DataComentario = curdate();
insert into tbl_Comentario(ds_comentario, cd_usuario, dt_comentario)
values(ds_comentario, cd_usuario, DataComentario); 
end && 
DELIMITER ;





/* PROCEDURE PARA EXCLUIR COMENTÁRIO */
drop procedure if exists sp_ExcComentario; 
DELIMITER && 
create procedure sp_ExcComentario
(
CodComentario int
)
BEGIN
delete from tbl_Comentario where cd_comentario = CodComentario;
end && 
DELIMITER ;


/* PROCEDURE PARA CONSULTAR COMENTÁRIO */
create view vw_Comentarios
as select
co.cd_usuario,
usu.nm_usuario,
co.cd_comentario,
co.ds_comentario,
co.dt_comentario
from tbl_Comentario as co inner join tbl_Usuario as usu on usu.cd_usuario = co.cd_usuario;

drop procedure if exists sp_MostraComentario;
DELIMITER &&
create procedure sp_MostraComentario()
begin 
select * from vw_Comentarios;
end &&
DELIMITER ;


/* PROCEDURE PARA INSERIR LIVROS PRODUTOS */
drop procedure if exists sp_InsProdutosLivros;
DELIMITER && 
create procedure sp_InsProdutosLivros
(
nm_produto varchar(70),
qt_estoque int, 
vl_unitario decimal(10,2),
img_produto varchar(255),
desc_produto varchar(1000),
cd_produto int,
no_paginas int,
no_isbn varchar(13),
dt_publicada date,
cd_autor int,
cd_editora int
)
BEGIN
declare cd_categoria int;
set cd_categoria = 1;
insert into tbl_Produto values(default,nm_produto, qt_estoque, vl_unitario, img_produto, desc_produto, cd_categoria);
select last_insert_id() into cd_produto;
insert into tbl_Livro values(cd_produto, no_paginas, no_isbn, dt_publicada, cd_autor, cd_editora);
end && 
DELIMITER ;


/* PROCEDURE PARA INSERIR PRODUTOS */
drop procedure if exists sp_InsProdutos;
DELIMITER && 
create procedure sp_InsProdutos
(
nm_produto varchar(70),
qt_estoque int, 
vl_unitario decimal(10,2),
img_produto varchar(255),
desc_produto varchar(1000),
cd_categoria int
)
BEGIN
insert into tbl_Produto(nm_produto, qt_estoque, vl_unitario, img_produto, desc_produto, cd_categoria) 
values (nm_produto, qt_estoque, vl_unitario, img_produto, desc_produto, cd_categoria);
end && 
DELIMITER ;


create view vw_ConsultarProdutos
as 
select 
pr.cd_produto, 
pr.nm_produto,
pr.vl_unitario, 
pr.img_produto,
pr.qt_estoque,
pr.desc_produto,
pr.cd_categoria,
cat.nm_categoria,
li.no_paginas,
li.no_isbn,
li.dt_publicada,
li.cd_autor,
au.nm_autor,
li.cd_editora,
ed.nm_editora
from tbl_Produto as pr inner join tbl_Categoria as cat on cat.cd_categoria = pr.cd_categoria 
inner join tbl_Livro as li on pr.cd_produto = li.cd_produto
inner join tbl_Editora as ed on ed.cd_Editora = li.cd_Editora
inner join tbl_Autor as au on au.cd_autor = li.cd_autor where cat.cd_categoria = 1;


create view vw_ConsultaSemLivros
as 
select 
pr.cd_produto, 
pr.nm_produto,
pr.qt_estoque,
pr.vl_unitario, 
pr.img_produto,
pr.desc_produto,
cat.nm_categoria,
cat.cd_categoria
from tbl_Produto as pr inner join tbl_Categoria as cat on cat.cd_categoria = pr.cd_categoria where cat.nm_categoria != 'Livros';


/* PROCEDURE PARA CONSULTAR LIVROS PRODUTOS */
drop procedure if exists sp_MostraProdutosLivros;
delimiter $$ 
create procedure sp_MostraProdutosLivros()
begin 
select * from vw_ConsultarProdutos;
end $$
delimiter ;


/* PROCEDURE PARA CONSULTAR PRODUTOS */
drop procedure if exists sp_MostraProdutos;
DELIMITER &&
create procedure sp_MostraProdutos()
begin 
select * from vw_ConsultaSemLivros;
end &&
DELIMITER ;

create view vw_ConsultarTodosOsProdutos as
select 
pr.cd_produto, 
pr.nm_produto,
pr.vl_unitario, 
pr.img_produto,
pr.qt_estoque,
pr.desc_produto,
cat.nm_categoria,
li.no_paginas,
li.no_isbn,
li.dt_publicada,
li.cd_autor,
au.nm_autor,
li.cd_editora,
ed.nm_editora
from tbl_produto as pr left join tbl_livro as li  on pr.cd_produto = li.cd_produto 
left join tbl_editora as ed on ed.cd_editora = li.cd_editora
left join tbl_autor as au on au.cd_autor = li.cd_autor
left join tbl_categoria as cat on pr.cd_categoria = cat.cd_categoria;



/* PROCEDURE PARA CONSULTAR TODOS PRODUTOS */
drop procedure if exists sp_MostraTodosProdutos;
delimiter $$ 
create procedure sp_MostraTodosProdutos()
begin 
select * from vw_ConsultarTodosOsProdutos;
end $$
delimiter ;


drop procedure if exists sp_MostraTodosProdutosporNome;
delimiter $$ 
create procedure sp_MostraTodosProdutosporNome(in NomeProd varchar(70))
begin 
select * from vw_ConsultarTodosOsProdutos where nm_produto like concat('%',NomeProd,'%');
end $$
delimiter ;




/* PROCEDURE PARA ALTERAR PRODUTOS */
drop procedure if exists sp_AltProdutos;
DELIMITER && 
create procedure sp_AltProdutos
(
CodProduto int,
nm_produto varchar(70),
qt_estoque int, 
vl_unitario decimal(10,2),
img_produto varchar(255),
desc_produto varchar(1000),
cd_categoria int
)
BEGIN
Update tbl_Produto set nm_produto = nm_produto, qt_estoque = qt_estoque, vl_unitario = vl_unitario, img_produto = img_produto, desc_produto = desc_produto,
cd_categoria = cd_categoria where cd_produto = CodProduto;
end && 
DELIMITER ;


/* PROCEDURE PARA ALTERAR PRODUTOS LIVROS*/
drop procedure if exists sp_AltProdutosLivros;
DELIMITER && 
create procedure sp_AltProdutosLivros
(
CodProduto int,
nm_produto varchar(70),
qt_estoque int, 
vl_unitario decimal(10,2),
img_produto varchar(255),
desc_produto varchar(1000),
CodProdutoLivro int, 
no_paginas int,
no_isbn varchar(13),
dt_publicada date, 
cd_autor int,
cd_editora int
)
BEGIN
Update tbl_Produto set nm_produto = nm_produto, qt_estoque = qt_estoque, vl_unitario = vl_unitario, img_produto = img_produto, desc_produto = desc_produto,
cd_categoria = cd_categoria where cd_produto = CodProduto;
Update tbl_Livro set no_paginas = no_paginas, no_isbn = no_isbn, dt_publicada = dt_publicada, cd_autor = cd_autor, cd_editora = cd_editora
where cd_produto = CodProdutoLivro;
end && 
DELIMITER ;


/* PROCEDURE PARA EXCLUIR PRODUTOS */
drop procedure if exists sp_ExcProduto; 
DELIMITER && 
create procedure sp_ExcProduto
(
CodProduto int
)
BEGIN
delete from tbl_Produto where cd_produto = CodProduto;
end && 
DELIMITER ;

/* PROCEDURE PARA EXCLUIR PRODUTOS LIVROS*/
drop procedure if exists sp_ExcProdutoLivro; 
DELIMITER && 
create procedure sp_ExcProdutoLivro
(
CodProduto int
)
BEGIN
delete from tbl_Livro where cd_produto = CodProduto; 
delete from tbl_Produto where cd_produto = CodProduto;
end && 
DELIMITER ;


/* PROCEDURE PARA INSERIR COMPRAS */
drop procedure if exists sp_InsCompra;
DELIMITER && 
create procedure sp_InsCompra
(
vl_total decimal(10,2),
cd_usuario int
)
BEGIN 
declare cd_compra int;
declare DataCompra date;
declare DataEntrega date; 
set DataCompra = curdate();
set DataEntrega = curdate() + Interval 7 DAY;
insert into tbl_Compra(dt_compra, vl_total, cd_usuario) values(DataCompra, vl_total, cd_usuario); 
select last_insert_id() into cd_compra;
insert into tbl_Entrega(dt_entrega, cd_compra) values (DataEntrega, cd_compra);
end && 
DELIMITER ; 





/* PROCEDURE PARA INSERIR ITENS COMPRA*/
drop procedure if exists sp_InsItemCompras;
DELIMITER && 
create procedure sp_InsItemCompras
(
cd_compra int,
cd_produto int,
qtdeVendas int
)
BEGIN 
insert into tbl_ItemCompras(cd_compra, cd_produto, qtdeVendas)
values(cd_compra, cd_produto, qtdeVendas); 
end && 
DELIMITER ;

drop procedure if exists sp_buscaIdVenda
delimiter &&
create procedure sp_buscaIdVenda()
begin 
select cd_compra from tbl_Compra order by cd_compra desc limit 1;
end &&
delimiter ;





/* TRIGGER PARA DAR BAIXA NO ESTOQUE*/
DELIMITER $$ 
create trigger tgi_baixaestoque after insert on tbl_itemcompras FOR EACH ROW 
begin 
update tbl_Produto set qt_Estoque =(qt_Estoque - new.qtdeVendas) where cd_produto = new.cd_produto;
end $$ 
DELIMITER ;



drop procedure if exists sp_ConsProd
delimiter &&
create procedure sp_ConsProd(codProduto int)
begin 
select * from tbl_produto where cd_produto = codProduto;
end &&
delimiter ;

drop procedure if exists sp_Dashboard;
delimiter &&
create procedure sp_Dashboard()
begin 
Select (Select sum(vl_total) from tbl_Compra) as Caixa,
(Select count(cd_usuario) from tbl_Usuario where ds_tipo <2) as Cliente,
(Select count(cd_usuario) from tbl_Usuario where ds_tipo >1) as Funcionarios,
(Select count(cd_produto) from tbl_Produto) as Produtos,
(Select count(cd_autor) from tbl_Autor) as Autores,
(Select count(cd_editora) from tbl_Editora) as Editora;
end &&
delimiter ;

drop procedure if exists sp_ConsultaPerfil;
delimiter $$
create procedure sp_ConsultaPerfil( in CodCli int)
begin
    select cd_usuario,nm_usuario, ds_email, ds_senha, no_telefone,no_celular, no_cpf, 
    nm_logradouro,no_logradouro, ds_complemento, nm_bairro,sg_uf,nm_cidade,no_cep, sg_sexo from tbl_Usuario
    where cd_usuario = CodCli; 
end $$ 
delimiter ;


create view vw_Entrega as select 
et.cd_entrega,
et.cd_compra,
group_concat(prod.nm_produto) as nm_produto,
cp.vl_total,
cli.nm_usuario,
et.dt_entrega,
cli.no_cep,
cli.nm_logradouro,
cli.no_logradouro,
cli.ds_complemento
from tbl_Entrega as et inner join tbl_Compra as cp on cp.cd_compra = et.cd_compra
left join tbl_usuario as cli on cli.cd_usuario = cp.cd_usuario
inner join tbl_itemCompras as it on cp.cd_compra = it.cd_compra
inner join tbl_Produto as prod on prod.cd_produto = it.cd_produto group by et.cd_entrega
;


drop procedure if exists sp_MostraEntrega;
DELIMITER &&
create procedure sp_MostraEntrega()
begin 
select * from vw_Entrega;
end &&
DELIMITER ;



create view vw_Pedido as select 
et.cd_compra,
group_concat(prod.nm_produto) as nm_produto,
cp.vl_total,
cli.cd_usuario,
et.dt_entrega
from tbl_Entrega as et inner join tbl_Compra as cp on cp.cd_compra = et.cd_compra
inner join tbl_usuario as cli on cli.cd_usuario = cp.cd_usuario
inner join tbl_itemCompras as it on cp.cd_compra = it.cd_compra
inner join tbl_Produto as prod on prod.cd_produto = it.cd_produto group by et.cd_compra;


drop procedure if exists sp_MostraPedido;
DELIMITER &&
create procedure sp_MostraPedido(in CodCli int)
begin 
select * from vw_Pedido where cd_usuario = CodCli;
end &&
DELIMITER ;


/* ---------INSERTS NECESSÁRIOS--------- */

insert into tbl_Usuario value(default,'Jo', 'Jo@gmail.com','12345678','555.555.555-24','123456789','123456789',
'Rua Menk','123', 'Apto 10', 'Mutinga', 'OSASCO','SP','1235566','F',1,1);

insert into tbl_Usuario values(default,'Administrador', 'Livrarialunar@gmail.com','12345','12345',
'1231515','123145','Rua Menk','123', '', 'Mutinga', 'OSASCO','SP','1235566','M',1,2);


insert into tbl_Autor value (default, 'Machado',1);

insert into tbl_Editora value (default, 'Fabesp');

insert into tbl_Produto values (default, 'Produto TESTE','55','55.55','JPEG','Teste', 1);


insert into tbl_Compra values (default, '2021-12-12', '55.55', 1);

insert into tbl_itemcompras values (default, 1, 1, 2);


/* ---------------------------------*/




/* Selects */ 
Select * from tbl_Usuario;
Select * from tbl_Editora;
Select * from tbl_Autor;
Select * from tbl_Categoria;
Select * from tbl_Pagamento;
Select * from tbl_Comentario;
select * from tbl_livro;
select * from tbl_produto;
select * from tbl_compra;
select * from tbl_entrega;
select * from tbl_itemcompras;
