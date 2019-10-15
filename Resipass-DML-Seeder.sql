USE Resipass
GO
INSERT INTO usuario (nombre, apellido, nombreusuario, password) VALUES ('Jorge', 'Escamilla', 'jescamilla', 'joresc00');
INSERT INTO usuario (nombre, apellido, nombreusuario, password) VALUES ('Dehlia', 'Brockton', 'dbrock1', 'k979R2');
------------------------------------------------------------------------------------------------------------
INSERT INTO domicilio (direccion, numero) VALUES ('Dapin', '55624');
INSERT INTO domicilio (direccion, numero) VALUES ('6th', '30');
INSERT INTO domicilio (direccion, numero) VALUES ('Hollow Ridge', '3493');
INSERT INTO domicilio (direccion, numero) VALUES ('Burning Wood', '34745');
INSERT INTO domicilio (direccion, numero) VALUES ('Weeping Birch', '062');
INSERT INTO domicilio (direccion, numero) VALUES ('Darwin', '26');
INSERT INTO domicilio (direccion, numero) VALUES ('Meadow Valley', '23');
INSERT INTO domicilio (direccion, numero) VALUES ('Ryan', '13811');
INSERT INTO domicilio (direccion, numero) VALUES ('Village', '9917');
INSERT INTO domicilio (direccion, numero) VALUES ('8th', '950');
INSERT INTO domicilio (direccion, numero) VALUES ('Graedel', '11052');
INSERT INTO domicilio (direccion, numero) VALUES ('Grim', '5');
INSERT INTO domicilio (direccion, numero) VALUES ('Farmco', '457');
INSERT INTO domicilio (direccion, numero) VALUES ('Becker', '9989');
INSERT INTO domicilio (direccion, numero) VALUES ('Gulseth', '82');
INSERT INTO domicilio (direccion, numero) VALUES ('Weeping Birch', '150');
INSERT INTO domicilio (direccion, numero) VALUES ('Red Cloud', '82');
INSERT INTO domicilio (direccion, numero) VALUES ('Prairieview', '2526');
INSERT INTO domicilio (direccion, numero) VALUES ('Sunfield', '89');
INSERT INTO domicilio (direccion, numero) VALUES ('Kennedy', '7187');
------------------------------------------------------------------------------------------------------------
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Aretha', 'Dank', 'adank0', 'Kg2S1wl', 5);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Johna', 'McAlindon', 'jmcalindon1', 'MJoKeMI', 13);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Nani', 'Bohden', 'nbohden2', 'ymkch7w4', 2);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Elia', 'Potebury', 'epotebury3', 'fO83eN', 20);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Sloan', 'Overington', 'soveton4', 'BYuI8oi2', 1);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Seymour', 'Cocklie', 'scocklie5', 'wReEob26t', 16);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Boigie', 'Shay', 'bshay6', 'XneQMY8', 16);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Minnie', 'Trundler', 'mtrundler7', '8CHhgWw', 11);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Dexter', 'Chaffyn', 'dchaffyn8', 'ZQSiq3CW', 7);
INSERT INTO residente (nombre, apellido, nombreusuario, password, domicilioId) VALUES ('Lucy', 'McCrudden', 'lucymcd', 'AWDtKvW', 20);
------------------------------------------------------------------------------------------------------------
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('IHV-929', '2019-6-9 10:15:35', 0, 10);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('URG-812', '2019-11-5 10:15:35', 1, 7);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('MUC-435', '2019-6-29 10:15:35', 0, 4);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('AIB-305', '2019-12-1 10:15:35', 1, 5);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('DWF-694', '2019-8-24 10:15:35', 0, 9);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('FFX-062', '2019-10-13 10:15:35', 0, 6);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('CED-005', '2019-5-16 10:15:35', 0, 3);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('VLR-873', '2019-12-22 10:15:35', 1, 8);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('CVA-469', '2019-8-30 10:15:35', 0, 2);
INSERT INTO tarjeta (codigo, vigencia, activa, residenteId) VALUES ('QAS-215', '2018-11-19 10:15:35', 1, 1);
------------------------------------------------------------------------------------------------------------
INSERT INTO aviso(comunicado, FechaPublicacion, UsuarioId) VALUES ('Hay nuevos horarios para recolección de basura', '2019-10-10 10:15:35', 1);
INSERT INTO aviso(comunicado, FechaPublicacion, UsuarioId) VALUES ('Se reestablece patrullaje de 12 am a 5 am', '2019-10-6 10:15:35', 1);
INSERT INTO aviso(comunicado, FechaPublicacion, UsuarioId) VALUES ('Existe una fuga de agua en el deposito central', '2019-9-25 10:15:35', 1);
INSERT INTO aviso(comunicado, FechaPublicacion, UsuarioId) VALUES ('Habrá reparaciones a juegos infantiles en parque #3', '2019-9-1 10:15:35', 1);
INSERT INTO aviso(comunicado, FechaPublicacion, UsuarioId) VALUES ('Daremos la bienvenida a los nuevos guardias de seguridad el proximo lunes', '2019-8-16 10:15:35', 2);
INSERT INTO aviso(comunicado, FechaPublicacion, UsuarioId) VALUES ('Los domingos se cierra el circuito oeste para residentes que practican ciclismo, esté atento a su velocidad', '2019-8-8 10:15:35', 2);
------------------------------------------------------------------------------------------------------------
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-11-01 10:15:35','2019-12-01 10:15:35','300','761396648','640961','8903','Amity C. Lester');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-10-01 10:15:35','2019-11-01 10:15:35','300','090816378','930491','6608','Tatiana Aguirre');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-09-01 10:15:35','2019-10-01 10:15:35','300','244968600','805328','4512','Lucius W. Matthews');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-08-01 10:15:35','2019-09-01 10:15:35','300','836922887','328115','1625','Salvador West');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-07-01 10:15:35','2019-08-01 10:15:35','300','926468371','995954','4181','Amy H. Monroe');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-06-01 10:15:35','2019-07-01 10:15:35','300','362005812','590116','5301','Hedda Dawson');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-05-01 10:15:35','2019-06-01 10:15:35','300','042528101','344104','0578','Libby Woodward');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-04-01 10:15:35','2019-05-01 10:15:35','300','112739771','674911','2314','Colby D. Obrien');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-03-01 10:15:35','2019-04-01 10:15:35','300','519166087','589393','5963','Quinn F. Acosta');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-02-01 10:15:35','2019-03-01 10:15:35','300','344664204','471416','7010','Rhoda Shields');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2019-01-01 10:15:35','2019-02-01 10:15:35','300','275812514','815821','7512','Noble Jenkins');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-12-01 10:15:35','2019-01-01 10:15:35','300','468876410','402260','9150','Nerea F. Zamora');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-11-01 10:15:35','2018-12-01 10:15:35','300','206897490','823812','3955','Christian Kemp');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-10-01 10:15:35','2018-11-01 10:15:35','300','085757256','647339','9512','Rhonda Gillespie');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-09-01 10:15:35','2018-10-01 10:15:35','300','185030726','512286','6695','Vivian Baird');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-08-01 10:15:35','2018-09-01 10:15:35','300','090997346','618765','8472','Georgia Montoya');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-07-01 10:15:35','2018-08-01 10:15:35','300','176378674','320107','9862','Kessie G. Fuentes');
INSERT INTO registroPago(tarjetaId,FechaPago,FechaVencimiento,importe,numerofolio,numeroautorizacion,sucursal,cajero) VALUES(4,'2018-06-01 10:15:35','2018-07-01 10:15:35','300','482002270','246396','1694','Jerome V. Barnes');