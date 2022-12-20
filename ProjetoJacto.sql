-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.31 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para projetojacto
CREATE DATABASE IF NOT EXISTS `projetojacto` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `projetojacto`;

-- Copiando estrutura para tabela projetojacto.agendamentos
CREATE TABLE IF NOT EXISTS `agendamentos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` int DEFAULT NULL,
  `idUsuario` int DEFAULT NULL,
  `cliente` varchar(100) DEFAULT NULL,
  `datacadastro` datetime DEFAULT NULL,
  `datainicio` datetime DEFAULT NULL,
  `datafinal` datetime DEFAULT NULL,
  `cep` varchar(8) DEFAULT NULL,
  `endereco` varchar(2000) DEFAULT NULL,
  `numero` varchar(5) DEFAULT NULL,
  `bairro` varchar(100) DEFAULT NULL,
  `cidade` varchar(150) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `complemento` varchar(100) DEFAULT NULL,
  `detalhes` varchar(800) DEFAULT NULL,
  `Finalizado` char(1) DEFAULT NULL,
  `DataFinalizacao` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportação de dados foi desmarcado.

-- Copiando estrutura para tabela projetojacto.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `Codigo` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Senha` varchar(10) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Celular` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportação de dados foi desmarcado.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
