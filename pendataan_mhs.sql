-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 01, 2022 at 03:10 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pendataan_mhs`
--

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `id_mhs` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `nim` varchar(15) NOT NULL,
  `angkatan` int(11) NOT NULL,
  `prodi` varchar(45) NOT NULL,
  `kelas` varchar(45) NOT NULL,
  `asal_sekolah` varchar(45) NOT NULL,
  `gol_ukt` int(11) NOT NULL,
  `ipk` int(11) NOT NULL,
  `status` varchar(15) NOT NULL,
  `agama` varchar(15) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `jk` varchar(10) NOT NULL,
  `tgl_lahir` varchar(45) NOT NULL,
  `ayah` varchar(45) NOT NULL,
  `ibu` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mahasiswa`
--

INSERT INTO `mahasiswa` (`id_mhs`, `nama`, `nim`, `angkatan`, `prodi`, `kelas`, `asal_sekolah`, `gol_ukt`, `ipk`, `status`, `agama`, `alamat`, `jk`, `tgl_lahir`, `ayah`, `ibu`) VALUES
(12, 'Muhamad Putra Satria', 'F55120009', 2020, 'S1 Teknik Informatika', 'A', 'SMA', 1, 3, 'Aktif', 'Islam', 'Kelapa Gading', 'Laki-laki', '09/05/2002', 'abc', 'abc'),
(13, 'Muhammad Fadhil', 'F55120019', 2020, 'S1 Teknik Informatika', 'A', 'SMA', 2, 3, 'Aktif', 'Islam', 'Tondo', 'Laki-laki', '12/05/2002', 'cde', 'fgh'),
(14, 'Merryska', 'F55120034', 2020, 'S1 Teknik Informatika', 'A', 'SMA', 1, 3, 'Aktif', 'Kristen', 'Lagarutu', 'Perempuan', '17/05/2002', 'rgb', 'rbg'),
(16, 'Khairun Nisa Cipta Hapsari', 'F55120010', 2020, 'S1 Teknik Informatika', 'A', 'MAN 2 KOTA PALU', 1, 3, 'Aktif', 'Islam', 'Jl. Pue Bongo', 'Perempuan', '14/01/2003', 'qwe', 'qwe');

-- --------------------------------------------------------

--
-- Table structure for table `mata_kuliah`
--

CREATE TABLE `mata_kuliah` (
  `kode_mk` varchar(20) NOT NULL,
  `nama_mk` varchar(100) NOT NULL,
  `dosen` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mata_kuliah`
--

INSERT INTO `mata_kuliah` (`kode_mk`, `nama_mk`, `dosen`) VALUES
('01', 'Database', 'Ibu A'),
('02', 'WEB', 'Bapak B'),
('03', 'desain', 'ibu b'),
('04', 'Web2', 'Ibu A');

-- --------------------------------------------------------

--
-- Table structure for table `nilai`
--

CREATE TABLE `nilai` (
  `nim` varchar(11) NOT NULL,
  `kode_mk` varchar(20) NOT NULL,
  `nilai_tugas` int(10) NOT NULL,
  `nilai_uts` int(10) NOT NULL,
  `nilai_uas` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `nilai`
--

INSERT INTO `nilai` (`nim`, `kode_mk`, `nilai_tugas`, `nilai_uts`, `nilai_uas`) VALUES
('F55120034', '01', 80, 80, 90),
('F55120034', '02', 90, 90, 90),
('F55120034', '03', 90, 95, 90);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD PRIMARY KEY (`id_mhs`),
  ADD UNIQUE KEY `nim` (`nim`);

--
-- Indexes for table `mata_kuliah`
--
ALTER TABLE `mata_kuliah`
  ADD PRIMARY KEY (`kode_mk`);

--
-- Indexes for table `nilai`
--
ALTER TABLE `nilai`
  ADD PRIMARY KEY (`nim`,`kode_mk`),
  ADD KEY `test` (`kode_mk`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  MODIFY `id_mhs` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `nilai`
--
ALTER TABLE `nilai`
  ADD CONSTRAINT `nim` FOREIGN KEY (`nim`) REFERENCES `mahasiswa` (`nim`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `test` FOREIGN KEY (`kode_mk`) REFERENCES `mata_kuliah` (`kode_mk`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
