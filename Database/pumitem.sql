-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 
-- サーバのバージョン： 10.4.6-MariaDB
-- PHP のバージョン: 7.2.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `techtest`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `pumitem`
--

CREATE TABLE `pumitem` (
  `Id` int(11) NOT NULL,
  `Itemname` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
  `Attack` int(11) NOT NULL,
  `Speed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- テーブルのデータのダンプ `pumitem`
--

INSERT INTO `pumitem` (`Id`, `Itemname`, `Attack`, `Speed`) VALUES
(1, 'ハンバーガー', 10, -10),
(2, 'スイカ', 2, 5),
(3, 'チーズ', 6, -3),
(4, 'バナナ', 7, 0),
(5, 'さくらんぼ', 3, 4),
(6, 'ホットドッグ', 8, -5),
(7, 'おりーぶ！！', 10, 10);

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `pumitem`
--
ALTER TABLE `pumitem`
  ADD PRIMARY KEY (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
