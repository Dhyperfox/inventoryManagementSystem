-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Máj 23. 08:49
-- Kiszolgáló verziója: 10.1.37-MariaDB
-- PHP verzió: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `raktar_info_v1`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `firma_adatok`
--

CREATE TABLE `firma_adatok` (
  `id` int(2) NOT NULL,
  `ceg_nev` varchar(60) NOT NULL,
  `varos` varchar(40) NOT NULL,
  `post_br` varchar(6) NOT NULL,
  `utca` varchar(40) NOT NULL,
  `hazszam` varchar(4) NOT NULL,
  `tel` varchar(20) NOT NULL,
  `pib` varchar(10) NOT NULL,
  `mat_br` varchar(10) NOT NULL,
  `sifra_del` varchar(10) NOT NULL,
  `racun` varchar(20) NOT NULL,
  `pozivnabroj` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `firma_adatok`
--

INSERT INTO `firma_adatok` (`id`, `ceg_nev`, `varos`, `post_br`, `utca`, `hazszam`, `tel`, `pib`, `mat_br`, `sifra_del`, `racun`, `pozivnabroj`) VALUES
(0, 'Raktar info D.O.O.', 'SENTA', '24400', 'KARADJORDJEVA', '43', '065 1694323', '123451111', '432111329', '4950', '160-22222-92', '97-533266651315');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `partner`
--

CREATE TABLE `partner` (
  `idp` int(4) NOT NULL,
  `nev` varchar(30) NOT NULL,
  `varos` varchar(30) NOT NULL,
  `cim` varchar(30) NOT NULL,
  `post_br` varchar(6) NOT NULL,
  `pib` int(10) NOT NULL,
  `mat_br` varchar(10) NOT NULL,
  `rac1` varchar(30) NOT NULL,
  `rac2` varchar(30) NOT NULL,
  `rac3` varchar(30) NOT NULL,
  `rac4` varchar(30) NOT NULL,
  `tel` varchar(20) NOT NULL,
  `fax` varchar(11) NOT NULL,
  `email` varchar(20) NOT NULL,
  `megjegyzes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `partner`
--

INSERT INTO `partner` (`idp`, `nev`, `varos`, `cim`, `post_br`, `pib`, `mat_br`, `rac1`, `rac2`, `rac3`, `rac4`, `tel`, `fax`, `email`, `megjegyzes`) VALUES
(1, 'MOJO CLUB DOO', 'SENTA', 'JESENJA 5', '24400', 11072847, '1234567891', '', '', '', '', '822', '234', 'we@er.rs', 'Milivoje 12'),
(2, 'PIPAC SUTR', 'MALI IDJOS', 'MARSALA TITA 62', '24321', 103334629, '6432341325', '', '', '', '', '31', '234324', 'csiki@rom.ro', 'Kis utca 10'),
(3, 'Stefan Shop', 'Ada', 'Moša Piade 16', '24430', 105234202, '61962565', '', '', '', '', '', '', '', ''),
(4, 'ETNOGOLD GOSTIONA DOO', 'Senta', 'Svetozara Miletica 22', '24400', 105082341, ' 	20305037', '', '', '', '', '', '', '', ''),
(6, 'MINIMARKET 76 STR', 'Mali Idjos', 'Kalmana Dudasa 9', '24321', 106330566, '86743241', '', '', '', '', '', '', '', ''),
(7, 'STR MARKET ', 'Backa Topola ', 'Lenjinova 17', '24300', 103143729, '56286403', '', '', '', '', '', '', '', ''),
(11, 'JOKER MARKET', 'Senta', 'Petefi Sandora 42', '24400', 103078526, '555822297', '', '', '', '', '', '', '', ''),
(12, 'RIN-TIN-TIN S.U.R.', 'Senta', 'Kasapska bb', '24400', 101104408, '51737270', '', '', '', '', '', '', '', ''),
(14, 'STR FELIX', 'Cantavir', 'Adi Endrea 38', '24220', 100853671, '54984537', '', '', '', '', '', '', '', ''),
(25, 'JUKE BOX SUZR', 'Coka', 'Sencanska 12', '23320', 104853797, '60550271', '', '', '', '', '', '', '', ''),
(30, 'MINI MARKET STR', 'Orom', 'Veliki Put 180', '24207', 100788172, '31266546', '', '', '', '', '', '', '', ''),
(35, 'TISACOOP D.O.O.', 'KANJIZA', 'Put Narodnih Heroja 6', '24420', 10212624, '08181624', '', '', '', '', '', '', '', ''),
(42, 'STR MARKET', 'Pacir', 'Lenjinova 17', '24342', 103143729, '56286403', '', '', '', '', '', '', '', ''),
(57, 'Atlantis Garden Monika B.Pr', 'Tresnjevac', 'Marsala Titia bb', '24426', 104081584, '55567379', '', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `raktar`
--

CREATE TABLE `raktar` (
  `ids` int(4) NOT NULL,
  `tip` varchar(30) NOT NULL,
  `db` int(6) NOT NULL,
  `egys` varchar(4) NOT NULL,
  `datum_be` date NOT NULL,
  `megjegyzes` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `raktar`
--

INSERT INTO `raktar` (`ids`, `tip`, `db`, `egys`, `datum_be`, `megjegyzes`) VALUES
(1000, 'dobozos', 11, 'kom', '2019-03-19', ''),
(2000, 'uveges', 2955, 'kom', '2019-03-19', ''),
(3000, 'uveges', 4266, 'kom', '2019-07-28', ''),
(4000, '-', 936, 'kom', '2019-03-23', ''),
(5000, 'uveges', 20702, 'kom', '2019-03-21', ''),
(6000, '-', 55, 'kom', '2019-07-28', ''),
(7000, 'uveges', 230, 'kom', '2019-07-28', ''),
(8000, 'uveges', 0, 'kom', '2019-07-28', ''),
(9000, 'bure 30L', 26, 'kom', '2019-11-05', ''),
(10000, 'flasa 700ml', 0, 'kom', '2019-12-06', ''),
(11000, 'flasa 1000ml', 15, 'kom', '2019-12-06', ''),
(12000, 'flasa 1000ml', 34, 'kom', '2019-12-06', ''),
(13000, 'flasa 750ml', 0, 'kom', '2019-12-06', ''),
(14000, 'flasa 750ml', 0, 'kom', '2019-12-06', ''),
(15000, 'flasa 750ml', 0, 'kom', '2019-12-06', ''),
(16000, 'flasa 750ml', 0, 'kom', '2019-12-06', ''),
(17000, 'flasa 750ml', 40, 'kom', '2019-12-06', ''),
(18000, 'flasa 750ml', 13, 'kom', '2019-12-06', ''),
(19000, 'flasa 750ml', 34, 'kom', '2019-12-06', ''),
(20000, 'boca 1.5l', 30, 'kom', '2019-12-06', ''),
(21000, 'flasa', 6, 'kom', '2019-12-17', ''),
(22000, 'flasa', 0, 'kom', '2019-12-17', '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendel`
--

CREATE TABLE `rendel` (
  `id` int(10) NOT NULL,
  `idr` varchar(10) NOT NULL,
  `idp` int(10) NOT NULL,
  `nev` varchar(60) NOT NULL,
  `cim` varchar(60) NOT NULL,
  `ids` varchar(10) NOT NULL,
  `db` varchar(4) NOT NULL,
  `egys` varchar(10) NOT NULL,
  `dat_ins` date NOT NULL,
  `stamp` int(1) NOT NULL,
  `type` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `rendel`
--

INSERT INTO `rendel` (`id`, `idr`, `idp`, `nev`, `cim`, `ids`, `db`, `egys`, `dat_ins`, `stamp`, `type`) VALUES
(152, '2-20190728', 3, 'PIVO CSIKI', 'Stefan Sho', '1000 ', '24', 'kom', '2019-07-28', 0, 'uveges'),
(153, '3-20190729', 4, 'PIVO CSIKI', 'ETNOGOLD G', '2000 ', '40', 'kom', '2019-07-29', 1, 'uveges'),
(154, '4-20190729', 11, 'PIVO CSIKI', 'JOKER MARK', '1000 ', '48', 'kom', '2019-07-29', 1, 'uveges'),
(155, '4-20190729', 11, 'PIVO CSIKI', 'JOKER MARK', '2000 ', '20', 'kom', '2019-07-29', 1, 'uveges'),
(156, '5-20190729', 4, 'PIVO CSIKI', 'ETNOGOLD G', '2000 ', '40', 'kom', '2019-07-29', 1, 'dobozos'),
(157, '6-20190729', 10, 'PIVO CSIKI', 'Fortuna Ma', '1000 ', '24', 'kom', '2019-07-29', 1, 'uveges'),
(158, '6-20190729', 10, 'PIVO CSIKI', 'Fortuna Ma', '2000 ', '20', 'kom', '2019-07-29', 1, 'uveges'),
(159, '6-20190729', 10, 'PIVO CSIKI', 'Fortuna Ma', '3000 ', '20', 'kom', '2019-07-29', 1, 'uveges'),
(160, '7-20190729', 10, 'PIVO CSIKI', 'Fortuna Ma', '1000 ', '24', 'kom', '2019-07-29', 1, 'uveges'),
(161, '7-20190729', 10, 'PIVO CSIKI', 'Fortuna Ma', '2000 ', '20', 'kom', '2019-07-29', 1, 'uveges'),
(162, '7-20190729', 10, 'PIVO CSIKI', 'Fortuna Ma', '3000 ', '20', 'kom', '2019-07-29', 1, 'dobozos'),
(163, '7-20190729', 10, 'PIVO TILTO', 'Fortuna Ma', '8000 ', '6', 'kom', '2019-07-29', 1, 'dobozos'),
(164, '7-20190729', 10, 'PIVO TILTO', 'Fortuna Ma', '7000 ', '6', 'kom', '2019-07-29', 1, 'uveges'),
(165, '8-20190730', 19, 'PIVO CSIKI', 'GASTRO BAL', '2000 ', '60', 'kom', '2019-07-30', 1, 'dobozos'),
(166, '8-20190730', 19, 'PIVO CSIKI', 'GASTRO BAL', '3000 ', '20', 'kom', '2019-07-30', 1, 'uveges'),
(167, '8-20190730', 19, 'PIVO TILTO', 'GASTRO BAL', '8000 ', '20', 'kom', '2019-07-30', 1, 'uveges'),
(168, '9-20190801', 22, 'PIVO CSIKI', 'LA FELICIT', '1000 ', '72', 'kom', '2019-08-01', 1, 'uveges'),
(169, '9-20190801', 22, 'PIVO TILTO', 'LA FELICIT', '8000 ', '20', 'kom', '2019-08-01', 1, 'dobozos'),
(170, '10-2019080', 5, 'PIVO CSIKI', 'PAPA HOUSE', '3000 ', '40', 'kom', '2019-08-01', 1, 'uveges'),
(171, '10-2019080', 5, 'PIVO CSIKI', 'PAPA HOUSE', '2000 ', '20', 'kom', '2019-08-01', 1, 'uveges'),
(172, '11-2019080', 24, 'PIVO CSIKI', 'DEKOR-ART ', '2000 ', '20', 'kom', '2019-08-01', 1, 'uveges'),
(173, '12-2019080', 23, 'PIVO CSIKI', 'Madarski K', '2000 ', '80', 'kom', '2019-08-01', 1, 'dobozos'),
(174, '12-2019080', 23, 'PIVO CSIKI', 'Madarski K', '3000 ', '80', 'kom', '2019-08-01', 1, 'dobozos'),
(175, '13-2019080', 25, 'PIVO CSIKI', 'JUKE BOX S', '3000 ', '40', 'kom', '2019-08-02', 1, 'uveges'),
(177, '14-2019080', 20, 'PIVO CSIKI', 'CAROLINAS ', '2000 ', '40', 'kom', '2019-08-02', 1, 'dobozos'),
(758, '3-20210519', 1, 'PIVO CSIKI TILTOTT FLASA 0.5', 'MOJO CLUB DOO', '2000 ', '2', 'kom', '2021-05-19', 0, 'uveges'),
(759, '4-20210519', 2, 'PIVO CSIKI TILTOTT FLASA 0.5', 'PIPAC SUTR', '2000 ', '5', 'kom', '2021-05-19', 0, 'dobozos'),
(760, '5-20210524', 1, 'PIVO CSIKI TILTOTT FLASA 0.5', 'MOJO CLUB DOO', '2000 ', '111', 'kom', '2021-05-24', 1, 'uveges'),
(781, '49-2022-05', 61, 'test', 'test', '123', '123', 'Uveges', '2022-05-17', 0, 'dobozos'),
(782, '97-2022-05', 1, 'PIVO CSIKI TILTOTT LIMENKA 0.5', 'MOJO CLUB DOO', '1000', '23', 'Uveges', '2022-05-17', 0, 'uveges');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek`
--

CREATE TABLE `termek` (
  `idt` int(4) NOT NULL,
  `nev` varchar(60) NOT NULL,
  `ids` varchar(30) NOT NULL,
  `tip` varchar(30) NOT NULL,
  `egys_ar` float NOT NULL,
  `ruc` float NOT NULL,
  `tarifa` varchar(5) NOT NULL DEFAULT '080-3',
  `aktiv_termek` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `termek`
--

INSERT INTO `termek` (`idt`, `nev`, `ids`, `tip`, `egys_ar`, `ruc`, `tarifa`, `aktiv_termek`) VALUES
(1, 'PIVO CSIKI TILTOTT LIMENKA 0.5', '1000', 'dobozos', 102, 0, '080-3', '1'),
(2, 'PIVO CSIKI TILTOTT FLASA 0.5', '2000', 'uveges', 102, 0, '080-3', '1'),
(3, 'PIVO CSIKI SZEKELY FLASA 0.5', '3000', 'uveges', 97, 0, '080-3', '1'),
(4, 'GAJBA ZA PIVO 1/20', '4000', '-', 666, 0, '080-3', '1'),
(5, 'Flasa Csiki 0.5', '5000', 'uveges', 25, 0, '080-3', '1'),
(6, 'DRVENE EURO PALETE', '6000', '-', 850, 0, '080-3', '1'),
(7, 'PIVO TILTOTT CSIKI BARNA FLASA 0.5', '7000', 'uveges', 125, 0, '080-3', '1'),
(8, 'PIVO TILTOTT CSIKI AFONYA FLASA 0.5', '8000', 'uveges', 170, 0, '080-3', '1'),
(9, 'TILTOTT CSIKI SOR BURE 30L', '9000', 'bure 30L', 6000, 0, '080-3', '1'),
(10, 'Unikum-gorki liker 700ml', '10000', 'flasa 700 ml', 936, 0, '080-3', '1'),
(11, 'Unikum-gorki liker 1000ml', '11000', 'flasa 1000ml', 1190.4, 0, '080-3', '1'),
(12, 'Unikum sljiva-gorki liker 1000ml', '12000', 'flasa 1000ml', 1190.4, 0, '080-3', '1'),
(14, 'Torley Charmant doux-samp slatki 750ml', '14000', 'flasa 750ml', 261.3, 0, '080-3', '1'),
(15, 'Torley Gala - samp suvi 750ml', '15000', 'flasa 750ml', 261.3, 0, '080-3', '1'),
(16, 'Torley Talisman - samp polusuvo 750ml', '16000', 'flasa 750ml', 261.3, 0, '080-3', '1'),
(17, 'Vino Muskotaly poluslatko 750ml Torley', '17000', 'flasa 750ml', 276.9, 0, '080-3', '1'),
(18, 'Szik Dunantuli Chardonny-suvo belo 750 ml', '18000', 'flasa 750ml', 276.9, 0, '080-3', '1'),
(19, 'Egri Bikaver - suvo crno vino 750ml', '19000', 'flasa 750ml', 277.2, 0, '080-3', '1'),
(20, 'Negazirana min.voda 1.5 l Kiraly Kincse', '20000', 'boca 1.5l', 35, 0, '080-3', '1'),
(21, 'Torley Char rose - samp slatki 750ml', '13000', 'flasa 750ml', 261.3, 0, '080-3', '1'),
(22, 'Decji sampanjac sumska jagoda', '21000', 'flasa', 150, 0, '080-3', '1'),
(23, 'Jabuka decji sampanac 0,75l', '22000', 'flasa', 150, 0, '080-3', '1'),
(24, 'PIVO CSIKI TILTOTT FLASA 0.5l', '23000', 'flasa', 127, 0, '080-3', '1'),
(25, 'PIVO CSIKI SZEKELY FLASA 0.5l', '24000', 'flasa', 122, 0, '080-3', '1'),
(26, 'test', '123', 'test', 123, 0, '080-3', '1');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `firma_adatok`
--
ALTER TABLE `firma_adatok`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- A tábla indexei `partner`
--
ALTER TABLE `partner`
  ADD PRIMARY KEY (`idp`);

--
-- A tábla indexei `raktar`
--
ALTER TABLE `raktar`
  ADD PRIMARY KEY (`ids`),
  ADD UNIQUE KEY `ids` (`ids`);

--
-- A tábla indexei `rendel`
--
ALTER TABLE `rendel`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id` (`id`),
  ADD KEY `idp_restict` (`idp`);

--
-- A tábla indexei `termek`
--
ALTER TABLE `termek`
  ADD PRIMARY KEY (`idt`),
  ADD UNIQUE KEY `idt` (`idt`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `partner`
--
ALTER TABLE `partner`
  MODIFY `idp` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- AUTO_INCREMENT a táblához `rendel`
--
ALTER TABLE `rendel`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=783;

--
-- AUTO_INCREMENT a táblához `termek`
--
ALTER TABLE `termek`
  MODIFY `idt` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `rendel`
--
ALTER TABLE `rendel`
  ADD CONSTRAINT `idp_restict` FOREIGN KEY (`idp`) REFERENCES `raktar_info`.`partner` (`idp`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
