-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2020 at 12:35 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `akinator`
--

-- --------------------------------------------------------

--
-- Table structure for table `clasificacion`
--

CREATE TABLE `clasificacion` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `clasificacion`
--

INSERT INTO `clasificacion` (`id`, `descripcion`) VALUES
(1, 'humano'),
(2, 'deidad'),
(3, 'extraterrestre'),
(4, 'robot'),
(5, 'devorador de mundos');

-- --------------------------------------------------------

--
-- Table structure for table `entrada`
--

CREATE TABLE `entrada` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `entrada`
--

INSERT INTO `entrada` (`id`, `descripcion`) VALUES
(1, 'heroe'),
(2, 'villano');

-- --------------------------------------------------------

--
-- Table structure for table `preguntas`
--

CREATE TABLE `preguntas` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(120) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `preguntas`
--

INSERT INTO `preguntas` (`id`, `descripcion`) VALUES
(1, 'Tu personaje usa armadura robótica?'),
(2, 'Tu personaje es de color rojo?'),
(3, 'Tu personaje es multimillonario?'),
(4, 'Tu personaje es una deidad (dios)?'),
(5, 'Tu personaje posee habilidades mágicas?'),
(6, 'Tu personaje posee ultra resistencia?'),
(7, 'Tu personaje usa un matillo?'),
(8, 'Tu personaje vuela?'),
(9, 'Tu personaje es un simbionte?'),
(10, 'Tu personaje fué villano de Spiderman?'),
(11, 'Tu personaje es de color negro?'),
(12, 'Tu personaje utiliza un traje creado por él mismo?'),
(13, 'Tu personaje trepa muros como una araña?'),
(14, 'Tu personaje lanza telarañas?'),
(15, 'Tu personaje es el villano más temido del universo?'),
(16, 'Tu personaje tiene el tal llamado “Guantelete del infinito”?'),
(17, 'Tu personaje desaparece gente con un chasquido?'),
(18, 'Tu personaje fue creado por el hombre?'),
(19, 'Tu personaje es un supersoldado experimentado?'),
(20, 'Tu personaje siempre lleva un escudo?'),
(21, 'Tu personaje devora mundos?'),
(22, 'Tu personaje obtiene energía proveniente del cosmos?'),
(23, 'Tu personaje puede anular el espacio-tiempo del universo?'),
(24, 'Tu personaje es de color verde?'),
(25, 'Tu personaje se transforma cuando se enoja?'),
(26, 'Tu personaje tiene fuerza sobrehumana?'),
(27, 'Tu personaje es técnicamente un “cyborg”?'),
(28, 'Tu personaje posee una inteligencia artificial muy avanzada?');

-- --------------------------------------------------------

--
-- Table structure for table `salida`
--

CREATE TABLE `salida` (
  `idEntrada` int(11) NOT NULL,
  `idClasificacion` int(11) NOT NULL,
  `idPregunta` int(11) NOT NULL,
  `nombreAprendizaje` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `salida`
--

INSERT INTO `salida` (`idEntrada`, `idClasificacion`, `idPregunta`, `nombreAprendizaje`) VALUES
(1, 1, 1, 'Iron Man'),
(1, 1, 2, 'Iron Man'),
(1, 1, 3, 'Iron Man'),
(2, 2, 4, 'Loki'),
(2, 2, 5, 'Loki'),
(2, 2, 6, 'Loki'),
(1, 2, 4, 'Thor'),
(1, 2, 7, 'Thor'),
(1, 2, 8, 'Thor'),
(2, 3, 9, 'Venom'),
(2, 3, 10, 'Venom'),
(2, 3, 11, 'Venom'),
(1, 1, 12, 'Spiderman'),
(1, 1, 13, 'Spiderman'),
(1, 1, 14, 'Spiderman'),
(2, 3, 15, 'Thanos'),
(2, 3, 16, 'Thanos'),
(2, 3, 17, 'Thanos'),
(1, 1, 18, 'Capitán América'),
(1, 1, 19, 'Capitán América'),
(1, 1, 20, 'Capitán América'),
(2, 5, 21, 'Galactus'),
(2, 5, 22, 'Galactus'),
(2, 5, 23, 'Galactus'),
(1, 1, 24, 'Hulk'),
(1, 1, 25, 'Hulk'),
(1, 1, 26, 'Hulk'),
(2, 4, 27, 'Ultrón'),
(2, 4, 28, 'Ultrón'),
(2, 4, 18, 'Ultrón');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clasificacion`
--
ALTER TABLE `clasificacion`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `entrada`
--
ALTER TABLE `entrada`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `preguntas`
--
ALTER TABLE `preguntas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `salida`
--
ALTER TABLE `salida`
  ADD KEY `fk_id_entrada` (`idEntrada`),
  ADD KEY `fk_id_clasificacion` (`idClasificacion`),
  ADD KEY `fk_id_pregunta` (`idPregunta`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clasificacion`
--
ALTER TABLE `clasificacion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `entrada`
--
ALTER TABLE `entrada`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `preguntas`
--
ALTER TABLE `preguntas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `salida`
--
ALTER TABLE `salida`
  ADD CONSTRAINT `fk_id_clasificacion` FOREIGN KEY (`idClasificacion`) REFERENCES `clasificacion` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_id_entrada` FOREIGN KEY (`idEntrada`) REFERENCES `entrada` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_id_pregunta` FOREIGN KEY (`idPregunta`) REFERENCES `preguntas` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
