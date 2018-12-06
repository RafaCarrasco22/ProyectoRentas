-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.7.24-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema videoclub
--

CREATE DATABASE IF NOT EXISTS videoclub;
USE videoclub;

--
-- Definition of table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente` (
  `id_cliente` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `apPaterno` varchar(45) NOT NULL,
  `apMaterno` varchar(45) NOT NULL,
  `edad` int(10) unsigned NOT NULL,
  `direccion` varchar(85) NOT NULL,
  `cp` varchar(25) NOT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cliente`
--

/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`id_cliente`,`nombre`,`apPaterno`,`apMaterno`,`edad`,`direccion`,`cp`,`email`) VALUES 
 (1,'PEDRO','PICA','PIEDRA',356,'Calle Rocadura No. 200 a.c.','10010','pedro@gmail.com'),
 (2,'RAFAEL','CARRASCO','VALENCIA',19,'5ta de constitución s/n Gpe Etla','68256','cavr134@gmail.com'),
 (3,'ROSALIO','CARRASCO','HERNANDEZ',25,'Villa de Etla, Centro 10','68000','rafacarrasco22@hotmail.com'),
 (4,'JUAN','CRUZ','AGUILAR',20,'Ocotlán','68250','juan@gmail.com'),
 (5,'LUIS','VASQUEZ','GOMEZ',23,'Santiago Etla','68555','santi@gmail.com'),
 (6,'LUIS','GOMEZ','CUEVAS',25,'AV.INDEPENDENCIA NO.1010','68300','gom_cue@gmail.com');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;


--
-- Definition of table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
CREATE TABLE `empleado` (
  `id_emp` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `apPaterno` varchar(45) NOT NULL,
  `apMaterno` varchar(45) NOT NULL,
  `edad` int(10) unsigned NOT NULL,
  `direccion` varchar(85) NOT NULL,
  `cp` varchar(25) NOT NULL,
  `num_emp` varchar(45) NOT NULL,
  `num_ventas` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_emp`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `empleado`
--

/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` (`id_emp`,`nombre`,`apPaterno`,`apMaterno`,`edad`,`direccion`,`cp`,`num_emp`,`num_ventas`) VALUES 
 (1,'Godinez','López','Perez',28,'Calle Juárez No. 301','68000','101',3),
 (3,'SANTIAGO','MORALES','GONZALVEZ',45,'5ta de Constitución s/n Gpe Etla','8686256','102',11),
 (7,'AITOR','TORREGROSA','BARROS',78,'Prolongacion Paseo de Los Heroes #11951-1','22024','103',10),
 (8,'MATEO','BENITEZ','PEÑA',30,'CALLE AGUSTIN LARA NO. 69-B TUXTEPEC','68370','105',5);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;


--
-- Definition of table `pelicula`
--

DROP TABLE IF EXISTS `pelicula`;
CREATE TABLE `pelicula` (
  `id_pelicula` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(80) NOT NULL,
  `genero` varchar(45) NOT NULL,
  `anio_estreno` int(10) unsigned NOT NULL,
  `precio` double NOT NULL,
  `existencia` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_pelicula`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pelicula`
--

/*!40000 ALTER TABLE `pelicula` DISABLE KEYS */;
INSERT INTO `pelicula` (`id_pelicula`,`nombre`,`genero`,`anio_estreno`,`precio`,`existencia`) VALUES 
 (1,'Tiempos violentos','Acción',1994,30.5,6),
 (2,'El padrino','Acción',1972,45.5,4),
 (3,'La vida es bella','Drama',1997,40.3,5),
 (4,'El club de la pelea','Acción',1999,35.9,3),
 (5,'Sueño de fuga','Drama',1994,26.4,4),
 (6,'Matrix','Acción',1999,50.4,6),
 (7,'El origen','Ciencia ficción',2010,70.4,3),
 (8,'Avatar','Ciencia ficción',2009,80.5,4),
 (9,'Wall e','Animación',2008,65.3,3),
 (10,'Titanic','Drama',1997,50.5,6),
 (11,'El renacido','Drama',2015,60.5,7),
 (12,'Misión rescate','Drama',2015,80,10);
/*!40000 ALTER TABLE `pelicula` ENABLE KEYS */;


--
-- Definition of table `renta`
--

DROP TABLE IF EXISTS `renta`;
CREATE TABLE `renta` (
  `id_renta` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_cliente` int(10) unsigned NOT NULL,
  `id_emp` int(10) unsigned NOT NULL,
  `id_pelicula` int(10) unsigned NOT NULL,
  `fecha_renta` date NOT NULL,
  `fecha_entrega` date NOT NULL,
  `pagado` int(10) NOT NULL,
  PRIMARY KEY (`id_renta`),
  KEY `FK_client` (`id_cliente`),
  KEY `FK_emp` (`id_emp`),
  KEY `FK_peli` (`id_pelicula`),
  CONSTRAINT `FK_client` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`),
  CONSTRAINT `FK_emp` FOREIGN KEY (`id_emp`) REFERENCES `empleado` (`id_emp`),
  CONSTRAINT `FK_peli` FOREIGN KEY (`id_pelicula`) REFERENCES `pelicula` (`id_pelicula`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `renta`
--

/*!40000 ALTER TABLE `renta` DISABLE KEYS */;
INSERT INTO `renta` (`id_renta`,`id_cliente`,`id_emp`,`id_pelicula`,`fecha_renta`,`fecha_entrega`,`pagado`) VALUES 
 (1,1,1,3,'2018-11-24','2018-12-04',1),
 (2,1,3,8,'2018-11-27','2018-11-30',1),
 (3,1,7,8,'2018-11-28','2018-12-01',1),
 (4,1,7,5,'2018-11-28','2018-12-01',1),
 (5,1,3,10,'2018-11-28','2018-11-30',1),
 (6,2,7,9,'2018-11-28','2018-11-30',1),
 (7,2,7,7,'2018-11-28','2018-11-30',1),
 (8,2,7,8,'2018-11-28','2018-11-30',1),
 (9,3,3,3,'2018-11-28','2018-11-30',0),
 (10,3,3,10,'2018-11-28','2018-11-30',0),
 (14,4,7,11,'2018-11-28','2018-11-30',1),
 (15,4,7,10,'2018-11-28','2018-11-30',1),
 (16,1,3,5,'2018-11-28','2018-11-30',1),
 (17,5,7,10,'2018-11-28','2018-12-01',1),
 (18,5,7,11,'2018-11-28','2018-12-01',1),
 (19,4,1,10,'2018-11-29','2018-12-04',1),
 (20,5,3,10,'2018-11-29','2018-12-01',1),
 (25,6,8,4,'2018-11-30','2018-12-01',0),
 (26,1,8,4,'2018-11-30','2018-12-01',0),
 (27,1,8,7,'2018-11-30','2018-12-01',0),
 (28,1,3,4,'2018-11-30','2018-12-01',0),
 (29,6,8,12,'2018-11-30','2018-11-30',0),
 (30,2,3,8,'2018-11-30','2018-12-08',0);
/*!40000 ALTER TABLE `renta` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
