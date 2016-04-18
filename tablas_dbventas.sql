create table categoria(
idcategoria int identity primary key not null,
nombre varchar(50) not null,
descripcion varchar(256) not null
)
create table presentacion
(
 idpresentacion int identity primary key not null,
 nombre varchar(50) not null,
 descripcion varchar(256)
)
create table articulo(
idarticulo int identity primary key not null,
codigo varchar(50) not null,
nombre varchar(50) not null,
descripcion varchar(256),
imagen image,
idcategoria int not null,
idpresentacion int not null
)
create table proveedor(
idproveedor int identity primary key not null,
razon_social varchar(256) not null,
sector_comercial varchar(50) not null,
tipo_documento varchar(20) not null,
num_documento varchar(11) not null,
direccion varchar(100),
telefono varchar(10),
email varchar(50),
url varchar(100)
)
create table trabajador(
idtrabajador int identity primary key not null,
nombre varchar(20) not null,
apellidos varchar(40) not null,
sexo varchar(1) not null,
fecha_nac date not null,
num_documento varchar(8) not null,
direccion varchar(10),
telefono varchar(10),
email varchar(50),
acceso varchar(20) not null,
usuario varchar(20) not null,
pass varchar(20) not null
)
create table ingreso(
idingreso int identity primary key not null,
idtrabajador int not null,
idproveedor int not null, 
fecha date not null,
tipo_comprobante varchar(20) not null,
serie varchar(4) not null,
correlativo varchar(7) not null,
igv decimal(4,2) not null
)
create table detalle_ingreso(
iddetalle_ingreso int identity primary key not null,
idingreso int not null,
idarticulo int not null,
precio_compra money not null,
precio_venta money not null,
stock_inicial int not null,
stock_actual int not null,
fecha_produccion date not null,
fecha_vencimiento date not null
)
create table cliente(
idcliente int identity primary key not null,
nombre varchar(50) not null,
apellidos varchar(40),
sexo varchar(1),
fecha_nac date,
tipo_documento varchar(20) not null,
num_documento varchar(10) not null,
direccion varchar(20),
telefono varchar(10),
email varchar(50)
)
create table venta(
idventa int identity primary key not null,
idcliente int not null,
idtrabajador int not null,
fecha date not null,
tipo_comprobante varchar(20) not null,
serie varchar(4) not null,
correlativo varchar(7) not null,
igv decimal(4,2) not null
)
create table detalle_venta(
iddetalle_venta int identity primary key not null,
idventa int not null,
iddetalle_ingreso int not null,
cantidad int not null,
precio_venta money not null,
descuento money not null
)