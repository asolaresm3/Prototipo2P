CREATE DATABASE  IF NOT EXISTS `sin` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sin`;
-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: sin
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `concepto`
--

DROP TABLE IF EXISTS `concepto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `concepto` (
  `codigo_concepto` varchar(5) NOT NULL,
  `nombre_concepto` varchar(60) DEFAULT NULL,
  `efecto_concepto` varchar(1) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codigo_concepto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `concepto`
--

LOCK TABLES `concepto` WRITE;
/*!40000 ALTER TABLE `concepto` DISABLE KEYS */;
/*!40000 ALTER TABLE `concepto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamento`
--

DROP TABLE IF EXISTS `departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departamento` (
  `codigo_departamento` varchar(5) NOT NULL,
  `nombre_departamento` varchar(80) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codigo_departamento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamento`
--

LOCK TABLES `departamento` WRITE;
/*!40000 ALTER TABLE `departamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleado` (
  `codigo_empleado` varchar(5) NOT NULL,
  `nombre_empleado` varchar(60) DEFAULT NULL,
  `codigo_puesto` varchar(5) DEFAULT NULL,
  `codigo_departamento` varchar(5) DEFAULT NULL,
  `sueldo_empleado` float(10,2) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codigo_empleado`),
  KEY `FK_puestoempleado` (`codigo_puesto`),
  KEY `FK_departamentoempleado` (`codigo_departamento`),
  CONSTRAINT `FK_departamentoempleado` FOREIGN KEY (`codigo_departamento`) REFERENCES `departamento` (`codigo_departamento`),
  CONSTRAINT `FK_puestoempleado` FOREIGN KEY (`codigo_puesto`) REFERENCES `puesto` (`codigo_puesto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nominad`
--

DROP TABLE IF EXISTS `nominad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nominad` (
  `codigo_nomina` varchar(5) NOT NULL,
  `codigo_empleado` varchar(5) NOT NULL,
  `codigo_concepto` varchar(5) NOT NULL,
  `valor_nominaD` float(10,2) DEFAULT NULL,
  PRIMARY KEY (`codigo_nomina`,`codigo_empleado`,`codigo_concepto`),
  KEY `FK_conceptonominaD` (`codigo_concepto`),
  KEY `FK_empleadonominaD` (`codigo_empleado`),
  CONSTRAINT `FK_conceptonominaD` FOREIGN KEY (`codigo_concepto`) REFERENCES `concepto` (`codigo_concepto`),
  CONSTRAINT `FK_empleadonominaD` FOREIGN KEY (`codigo_empleado`) REFERENCES `empleado` (`codigo_empleado`),
  CONSTRAINT `FK_nominaEnominaD` FOREIGN KEY (`codigo_nomina`) REFERENCES `nominae` (`codigo_nomina`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nominad`
--

LOCK TABLES `nominad` WRITE;
/*!40000 ALTER TABLE `nominad` DISABLE KEYS */;
/*!40000 ALTER TABLE `nominad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nominae`
--

DROP TABLE IF EXISTS `nominae`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nominae` (
  `codigo_nomina` varchar(5) NOT NULL,
  `fecha_inicial_nomina` date DEFAULT NULL,
  `fecha_final_nomina` date DEFAULT NULL,
  PRIMARY KEY (`codigo_nomina`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nominae`
--

LOCK TABLES `nominae` WRITE;
/*!40000 ALTER TABLE `nominae` DISABLE KEYS */;
/*!40000 ALTER TABLE `nominae` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puesto`
--

DROP TABLE IF EXISTS `puesto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `puesto` (
  `codigo_puesto` varchar(5) NOT NULL,
  `nombre_puesto` varchar(60) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codigo_puesto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puesto`
--

LOCK TABLES `puesto` WRITE;
/*!40000 ALTER TABLE `puesto` DISABLE KEYS */;
INSERT INTO `puesto` VALUES ('1','Jefe',1);
/*!40000 ALTER TABLE `puesto` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-29 12:18:38
