-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 14/12/2023 às 00:06
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `lavacarros`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `carros`
--

CREATE TABLE `carros` (
  `Id` int(11) NOT NULL,
  `Dono` longtext NOT NULL,
  `Placa` longtext NOT NULL,
  `Modelo` longtext NOT NULL,
  `TipoLavagemId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `carros`
--

INSERT INTO `carros` (`Id`, `Dono`, `Placa`, `Modelo`, `TipoLavagemId`) VALUES
(6, 'Matheus', 'BMW', 'BMW', 1),
(7, 'EDUARDA', 'Q2EQWE', 'QWEEQWE', 2),
(8, 'test', 'qwe', 'qwe', 4);

-- --------------------------------------------------------

--
-- Estrutura para tabela `servicoslavagem`
--

CREATE TABLE `servicoslavagem` (
  `Id` int(11) NOT NULL,
  `Tipo` longtext DEFAULT NULL,
  `Valor` decimal(18,2) NOT NULL,
  `Detalhes` longtext DEFAULT NULL,
  `TipoLavagem` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `servicoslavagem`
--

INSERT INTO `servicoslavagem` (`Id`, `Tipo`, `Valor`, `Detalhes`, `TipoLavagem`) VALUES
(1, 'Seco', 100.00, 'Sabo , gua , teste, teste, tes ', NULL),
(2, 'Premium ', 300.00, NULL, NULL),
(3, 'Polizada', 10.00, 'Sab\0o , \0gua , teste, teste, tes ', NULL),
(4, 'sassa', 1000.00, 'asdas', NULL);

-- --------------------------------------------------------

--
-- Estrutura para tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231121172116_InitialCreate', '5.0.5'),
('20231123162815_AdicionarServicosLavagem', '5.0.5'),
('20231123173628_LavaCarros', '5.0.5'),
('20231123173739_NomeDaMigracao', '5.0.5'),
('20231125004630_ServicoLavagem', '5.0.5'),
('20231125011108_NomeDaSuaMigracao', '5.0.5'),
('20231127223124_Atualizacao', '5.0.5'),
('20231128180331_AtualizarCarroModel', '5.0.5'),
('20231128182248_Final', '5.0.5');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `carros`
--
ALTER TABLE `carros`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Carros_TipoLavagemId` (`TipoLavagemId`);

--
-- Índices de tabela `servicoslavagem`
--
ALTER TABLE `servicoslavagem`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `carros`
--
ALTER TABLE `carros`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de tabela `servicoslavagem`
--
ALTER TABLE `servicoslavagem`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `carros`
--
ALTER TABLE `carros`
  ADD CONSTRAINT `FK_Carros_ServicosLavagem_TipoLavagemId` FOREIGN KEY (`TipoLavagemId`) REFERENCES `servicoslavagem` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
