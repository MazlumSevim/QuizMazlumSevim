-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 03. Feb 2026 um 14:16
-- Server-Version: 10.4.28-MariaDB
-- PHP-Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `quizdb`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `land`
--

CREATE TABLE `land` (
  `LandID` int(11) NOT NULL,
  `Landname` varchar(80) NOT NULL,
  `Hauptstadt` varchar(80) NOT NULL,
  `iso2` char(2) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Daten für Tabelle `land`
--

INSERT INTO `land` (`LandID`, `Landname`, `Hauptstadt`, `iso2`) VALUES
(1, 'Deutschland', 'Berlin', 'de'),
(2, 'Frankreich', 'Paris', 'fr'),
(3, 'Italien', 'Rom', 'it'),
(4, 'Spanien', 'Madrid', 'es'),
(5, 'Portugal', 'Lissabon', 'pt'),
(6, 'Niederlande', 'Amsterdam', 'nl'),
(7, 'Belgien', 'Brüssel', 'be'),
(8, 'Österreich', 'Wien', 'at'),
(9, 'Schweiz', 'Bern', 'ch'),
(10, 'Polen', 'Warschau', 'pl'),
(11, 'Tschechien', 'Prag', 'cz'),
(12, 'Slowakei', 'Bratislava', 'sk'),
(13, 'Ungarn', 'Budapest', 'hu'),
(14, 'Dänemark', 'Kopenhagen', 'dk'),
(15, 'Schweden', 'Stockholm', 'se'),
(16, 'Norwegen', 'Oslo', 'no'),
(17, 'Finnland', 'Helsinki', 'fi'),
(18, 'Irland', 'Dublin', 'ie'),
(19, 'Großbritannien', 'London', 'gb'),
(20, 'Island', 'Reykjavik', 'is'),
(21, 'Griechenland', 'Athen', 'gr'),
(22, 'Türkei', 'Ankara', 'tr'),
(23, 'Russland', 'Moskau', 'ru'),
(24, 'USA', 'Washington', 'us'),
(25, 'Kanada', 'Ottawa', 'ca'),
(26, 'Mexiko', 'Mexiko-Stadt', 'mx'),
(27, 'Brasilien', 'Brasília', 'br'),
(28, 'Argentinien', 'Buenos Aires', 'ar'),
(29, 'Chile', 'Santiago', 'cl'),
(30, 'Japan', 'Tokio', 'jp'),
(31, 'China', 'Peking', 'cn'),
(32, 'Südkorea', 'Seoul', 'kr'),
(33, 'Indien', 'Neu-Delhi', 'in'),
(34, 'Australien', 'Canberra', 'au'),
(35, 'Neuseeland', 'Wellington', 'nz'),
(36, 'Ägypten', 'Kairo', 'eg'),
(37, 'Südafrika', 'Pretoria', 'za'),
(38, 'Nigeria', 'Abuja', 'ng'),
(39, 'Marokko', 'Rabat', 'ma'),
(40, 'Tunesien', 'Tunis', 'tn');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `punkte`
--

CREATE TABLE `punkte` (
  `PunkteID` int(11) NOT NULL,
  `SpielerID` int(11) NOT NULL,
  `LandID` int(11) NOT NULL,
  `Punktzahl` int(11) NOT NULL,
  `Kategorie` enum('Land','Hauptstadt','Flagge') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Daten für Tabelle `punkte`
--

INSERT INTO `punkte` (`PunkteID`, `SpielerID`, `LandID`, `Punktzahl`, `Kategorie`) VALUES
(1, 1, 34, 5, 'Hauptstadt'),
(2, 1, 14, 0, 'Hauptstadt'),
(3, 1, 24, 0, 'Hauptstadt'),
(4, 1, 31, 5, 'Hauptstadt'),
(5, 1, 11, 5, 'Hauptstadt'),
(6, 1, 2, 5, 'Hauptstadt'),
(7, 1, 5, 5, 'Hauptstadt'),
(8, 1, 37, 5, 'Hauptstadt'),
(9, 1, 33, 5, 'Hauptstadt'),
(10, 1, 20, 5, 'Hauptstadt'),
(11, 2, 17, 0, 'Land'),
(12, 2, 13, 0, 'Land'),
(13, 2, 23, 5, 'Land'),
(14, 2, 6, 0, 'Land'),
(15, 2, 40, 5, 'Land'),
(16, 2, 36, 0, 'Land'),
(17, 2, 31, 0, 'Land'),
(18, 2, 24, 0, 'Land'),
(19, 2, 35, 0, 'Land'),
(20, 2, 39, 5, 'Land'),
(21, 2, 4, 5, 'Flagge'),
(22, 2, 23, 5, 'Flagge'),
(23, 2, 40, 5, 'Flagge'),
(24, 2, 33, 5, 'Flagge'),
(25, 2, 18, 0, 'Flagge'),
(26, 2, 34, 5, 'Flagge'),
(27, 2, 13, 0, 'Flagge'),
(28, 2, 26, 5, 'Flagge'),
(29, 2, 31, 5, 'Flagge'),
(30, 2, 8, 5, 'Flagge'),
(31, 2, 23, 5, 'Land'),
(32, 2, 12, 0, 'Land'),
(33, 2, 36, 0, 'Land'),
(34, 2, 26, 5, 'Land'),
(35, 2, 31, 0, 'Land'),
(36, 2, 21, 0, 'Land'),
(37, 2, 2, 5, 'Land'),
(38, 2, 33, 0, 'Land'),
(39, 2, 15, 0, 'Land'),
(40, 2, 24, 5, 'Land'),
(41, 2, 18, 5, 'Hauptstadt'),
(42, 2, 30, 5, 'Hauptstadt'),
(43, 2, 36, 5, 'Hauptstadt'),
(44, 2, 16, 5, 'Hauptstadt'),
(45, 2, 33, 5, 'Hauptstadt'),
(46, 2, 34, 5, 'Hauptstadt'),
(47, 2, 5, 5, 'Hauptstadt'),
(48, 2, 7, 5, 'Hauptstadt'),
(49, 2, 18, 0, 'Hauptstadt'),
(50, 2, 1, 5, 'Hauptstadt'),
(51, 2, 11, 5, 'Land'),
(52, 2, 24, 5, 'Land'),
(53, 2, 12, 5, 'Land'),
(54, 2, 4, 5, 'Land'),
(55, 2, 27, 5, 'Land'),
(56, 2, 28, 5, 'Land'),
(57, 2, 17, 5, 'Land'),
(58, 2, 9, 5, 'Land'),
(59, 2, 37, 5, 'Land'),
(60, 2, 22, 5, 'Land'),
(61, 2, 33, 5, 'Hauptstadt'),
(62, 2, 10, 0, 'Hauptstadt'),
(63, 1, 31, 0, 'Hauptstadt'),
(64, 1, 24, 0, 'Flagge'),
(65, 1, 23, 0, 'Land');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spieler`
--

CREATE TABLE `spieler` (
  `SpielerID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Gesamtpunkte` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Daten für Tabelle `spieler`
--

INSERT INTO `spieler` (`SpielerID`, `Name`, `Gesamtpunkte`) VALUES
(1, 'Mazlum', 0),
(2, 'Sevim', 0);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `land`
--
ALTER TABLE `land`
  ADD PRIMARY KEY (`LandID`),
  ADD UNIQUE KEY `Land` (`Landname`);

--
-- Indizes für die Tabelle `punkte`
--
ALTER TABLE `punkte`
  ADD PRIMARY KEY (`PunkteID`),
  ADD KEY `idx_punkte_spieler` (`SpielerID`),
  ADD KEY `idx_punkte_land` (`LandID`);

--
-- Indizes für die Tabelle `spieler`
--
ALTER TABLE `spieler`
  ADD PRIMARY KEY (`SpielerID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `land`
--
ALTER TABLE `land`
  MODIFY `LandID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT für Tabelle `punkte`
--
ALTER TABLE `punkte`
  MODIFY `PunkteID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT für Tabelle `spieler`
--
ALTER TABLE `spieler`
  MODIFY `SpielerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `punkte`
--
ALTER TABLE `punkte`
  ADD CONSTRAINT `fk_punkte_land` FOREIGN KEY (`LandID`) REFERENCES `land` (`LandID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_punkte_spieler` FOREIGN KEY (`SpielerID`) REFERENCES `spieler` (`SpielerID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
