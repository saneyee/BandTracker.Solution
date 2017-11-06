-- phpMyAdmin SQL Dump
-- version 4.7.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Nov 06, 2017 at 09:55 AM
-- Server version: 5.6.35
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `band_tracker_test`
--
CREATE DATABASE IF NOT EXISTS `band_tracker_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `band_tracker_test`;

-- --------------------------------------------------------

--
-- Table structure for table `bands`
--

CREATE TABLE `bands` (
  `id` int(11) NOT NULL,
  `band_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `bands_venues`
--

CREATE TABLE `bands_venues` (
  `id` int(11) NOT NULL,
  `band_id` int(11) DEFAULT NULL,
  `venue_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bands_venues`
--

INSERT INTO `bands_venues` (`id`, `band_id`, `venue_id`) VALUES
(1, 4, 1),
(2, 4, 2),
(3, 5, 3),
(4, 6, 8),
(5, 7, 8),
(6, 8, 10),
(7, 12, 11),
(8, 12, 12),
(9, 13, 13),
(10, 14, 18),
(11, 15, 18),
(12, 16, 20),
(13, 20, 21),
(14, 20, 22),
(15, 21, 23),
(16, 22, 28),
(17, 23, 28),
(19, 28, 31),
(20, 28, 32),
(21, 29, 33),
(22, 30, 38),
(23, 31, 38),
(24, 32, 39),
(26, 38, 42),
(27, 38, 43),
(28, 39, 44),
(29, 40, 49),
(30, 41, 50),
(32, 47, 53),
(33, 47, 54),
(34, 48, 55),
(36, 50, 62),
(37, 51, 63),
(38, 56, 64),
(39, 56, 65),
(40, 57, 66),
(42, 59, 73),
(43, 60, 74),
(44, 65, 75),
(45, 65, 76),
(46, 66, 77),
(48, 68, 84),
(49, 69, 85),
(51, 75, 87),
(52, 75, 88),
(53, 76, 89),
(55, 79, 96),
(56, 80, 97),
(58, 86, 99),
(59, 86, 100),
(60, 87, 101),
(62, 90, 108),
(63, 91, 109),
(65, 97, 111),
(66, 97, 112),
(67, 98, 113),
(69, 101, 120),
(70, 102, 121),
(72, 108, 123),
(73, 108, 124),
(74, 109, 125),
(76, 112, 132),
(77, 113, 132),
(78, 114, 133),
(80, 120, 135),
(81, 121, 136),
(83, 124, 143),
(84, 125, 143),
(85, 126, 144),
(87, 132, 146),
(88, 133, 147),
(90, 136, 154),
(91, 137, 154),
(92, 138, 155),
(94, 144, 157),
(95, 145, 158),
(97, 148, 165),
(98, 149, 165),
(99, 150, 166),
(101, 156, 168),
(102, 157, 169),
(104, 160, 176),
(105, 161, 176),
(106, 162, 177),
(108, 168, 179),
(109, 169, 180),
(111, 172, 187),
(112, 173, 187),
(113, 174, 188),
(115, 180, 190),
(116, 180, 191),
(117, 181, 192),
(119, 184, 199),
(120, 185, 200),
(122, 191, 202),
(123, 191, 203),
(124, 192, 204),
(126, 195, 211),
(127, 196, 212);

-- --------------------------------------------------------

--
-- Table structure for table `venues`
--

CREATE TABLE `venues` (
  `id` int(11) NOT NULL,
  `venue_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bands`
--
ALTER TABLE `bands`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `bands_venues`
--
ALTER TABLE `bands_venues`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `venues`
--
ALTER TABLE `venues`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bands`
--
ALTER TABLE `bands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=198;
--
-- AUTO_INCREMENT for table `bands_venues`
--
ALTER TABLE `bands_venues`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=128;
--
-- AUTO_INCREMENT for table `venues`
--
ALTER TABLE `venues`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=213;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
