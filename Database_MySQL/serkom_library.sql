-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 30 Des 2023 pada 10.36
-- Versi server: 10.4.11-MariaDB
-- Versi PHP: 7.3.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `serkom_library`
--

DELIMITER $$
--
-- Prosedur
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAnggotaByGender` (IN `gender_param` ENUM('L','P'))  BEGIN
   SELECT * FROM anggota WHERE jenis_kelamin = gender_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetBukuByPenerbit` (IN `penerbit_param` VARCHAR(40))  BEGIN
   SELECT * FROM buku WHERE penerbit = penerbit_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTransaksiByStatus` (IN `status_param` VARCHAR(20))  BEGIN
   SELECT * FROM transaksi WHERE status = status_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserByHakAkses` (IN `role_param` ENUM('admin','user'))  BEGIN
   SELECT * FROM user WHERE hak_akses = role_param;
END$$

--
-- Fungsi
--
CREATE DEFINER=`root`@`localhost` FUNCTION `GetAvailableBookCount` (`judul_buku_param` VARCHAR(40)) RETURNS INT(11) BEGIN
DECLARE book_count INT;
SELECT jml_buku INTO book_count FROM buku WHERE judul_buku = judul_buku_param;
RETURN book_count;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `GetGenderByMemberName` (`nama_anggota_param` VARCHAR(50)) RETURNS ENUM('L','P') CHARSET utf8mb4 BEGIN
DECLARE jenis_kelamin_result ENUM('L','P');
SELECT jenis_kelamin INTO jenis_kelamin_result FROM anggota WHERE nama_anggota = nama_anggota_param;
RETURN jenis_kelamin_result;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `GetTransactionStatusByMemberName` (`nama_anggota_param` VARCHAR(50)) RETURNS ENUM('Dipinjam','Dikembalikan') CHARSET utf8mb4 BEGIN
DECLARE status_result ENUM('Dipinjam','Dikembalikan');
SELECT status INTO status_result FROM transaksi WHERE nama_anggota = nama_anggota_param;
RETURN status_result;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `GetUserAccess` (`username_param` VARCHAR(50)) RETURNS ENUM('admin','user') CHARSET utf8mb4 BEGIN
DECLARE user_access ENUM('admin', 'user');
SELECT hak_akses INTO user_access FROM user WHERE username = username_param;
RETURN user_access;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `anggota`
--

CREATE TABLE `anggota` (
  `id_anggota` int(11) NOT NULL,
  `nama_anggota` varchar(50) NOT NULL,
  `tempat_lahir` varchar(40) NOT NULL,
  `tgl_lahir` datetime NOT NULL,
  `jenis_kelamin` enum('L','P') NOT NULL,
  `alamat` text NOT NULL,
  `tgl_masuk` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `anggota`
--

INSERT INTO `anggota` (`id_anggota`, `nama_anggota`, `tempat_lahir`, `tgl_lahir`, `jenis_kelamin`, `alamat`, `tgl_masuk`) VALUES
(1, 'Budi', 'Purwokerto', '2003-12-21 00:00:00', 'L', 'Jalan Kenanga No.12', '2023-12-01 00:00:00'),
(2, 'Dominic', 'Jakarta', '1999-07-02 00:00:00', 'P', 'Jalan Haji Husada', '2023-12-27 00:00:00'),
(3, 'Carolina', 'Tambun', '2001-11-17 00:00:00', 'L', 'Jalan jalan', '2023-12-28 00:00:00'),
(4, 'Fresti', 'Jakarta', '1999-02-11 00:00:00', 'P', 'Jl. Edelweis F', '2023-12-28 00:00:00'),
(5, 'Markati', 'Bandung', '2023-12-28 00:00:00', 'P', 'Jl. Asia Afrika', '2023-12-28 00:00:00'),
(6, 'Black Utomo', 'Karawang', '1995-11-13 00:00:00', 'L', 'Jalan Kasuari No. 3', '2023-12-28 00:00:00'),
(7, 'Noel', 'Bekasi', '2010-07-15 00:00:00', 'L', 'Jalan Kasmaran', '2023-12-29 00:00:00');

--
-- Trigger `anggota`
--
DELIMITER $$
CREATE TRIGGER `anggota_before_insert` BEFORE INSERT ON `anggota` FOR EACH ROW BEGIN
    IF NEW.tgl_masuk < NEW.tgl_lahir THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Tanggal masuk anggota tidak boleh lebih awal dari tanggal lahir.';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `buku`
--

CREATE TABLE `buku` (
  `id_buku` int(11) NOT NULL,
  `judul_buku` varchar(40) NOT NULL,
  `pengarang` varchar(40) NOT NULL,
  `penerbit` varchar(40) NOT NULL,
  `thn_terbit` int(11) NOT NULL,
  `jml_buku` int(40) NOT NULL,
  `tgl_input` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `buku`
--

INSERT INTO `buku` (`id_buku`, `judul_buku`, `pengarang`, `penerbit`, `thn_terbit`, `jml_buku`, `tgl_input`) VALUES
(1, 'Laskar Pelangi', 'Andre Hirata', 'Erlangga', 2007, 9, '2023-12-27 00:00:00'),
(2, 'MTK Diskrit', 'James Arthur', 'Gramed', 2020, 11, '2023-12-27 00:00:00'),
(7, 'Kalkulus Lanjutan', 'Mawar Melati', 'Erlangga', 2020, 39, '2023-12-28 00:00:00'),
(8, 'Harry Potter', 'James Arthur', 'Dunia Buku', 2001, 19, '2023-12-28 00:00:00'),
(9, 'Algoritma Pemrograman', 'Gumbira Pratama', 'Dunia Ilkom', 2022, 8, '2023-12-28 00:00:00'),
(11, 'ABCD', 'Dian', 'Erlangga', 2017, 20, '2023-12-29 00:00:00'),
(12, 'Mengenal Planet', 'Heliks', 'Sinar Dunia', 2019, 19, '2023-12-29 00:00:00'),
(14, 'HTML Uncover', 'Andre Pratama', 'DuniaIlkom', 2008, 10, '2023-12-29 00:00:00');

--
-- Trigger `buku`
--
DELIMITER $$
CREATE TRIGGER `buku_before_insert` BEFORE INSERT ON `buku` FOR EACH ROW BEGIN
    IF NEW.jml_buku <= 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Jumlah buku tidak boleh kurang dari 0';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `nama_anggota` varchar(50) NOT NULL,
  `judul_buku` varchar(40) NOT NULL,
  `tgl_pinjam` datetime NOT NULL,
  `tgl_kembali` datetime NOT NULL,
  `status` enum('Dipinjam','Dikembalikan') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `username`, `nama_anggota`, `judul_buku`, `tgl_pinjam`, `tgl_kembali`, `status`) VALUES
(1, 'andre', 'Dominic', 'MTK Diskrit', '2023-12-28 00:00:00', '2023-12-31 00:00:00', 'Dipinjam'),
(3, 'andre', 'Fresti', 'Kalkulus Lanjutan', '2023-12-28 00:00:00', '2023-12-31 00:00:00', 'Dikembalikan'),
(5, 'andre', 'Markati', 'Algoritma Pemrograman', '2023-12-28 00:00:00', '2023-12-31 00:00:00', 'Dipinjam'),
(6, 'Happy', 'Black Utomo', 'Harry Potter', '2023-12-28 00:00:00', '2023-12-31 00:00:00', 'Dipinjam'),
(7, 'andre', 'Noel', 'Mengenal Planet', '2023-12-29 00:00:00', '2024-01-01 00:00:00', 'Dipinjam'),
(11, 'fresti', 'Noel', 'ABCD', '2023-12-29 00:00:00', '2024-01-01 00:00:00', 'Dikembalikan');

--
-- Trigger `transaksi`
--
DELIMITER $$
CREATE TRIGGER `transaksi_before_insert` BEFORE INSERT ON `transaksi` FOR EACH ROW BEGIN
    IF NEW.tgl_kembali < NEW.tgl_pinjam THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Tanggal kembali tidak boleh lebih awal dari tanggal pinjam.';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id_user` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `hak_akses` enum('admin','user') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id_user`, `username`, `password`, `email`, `hak_akses`) VALUES
(1, 'andre', 'novito', 'andi@sano.dev', 'admin'),
(2, 'Happy', 'Asih', 'Wulandari@sano.dev', 'user'),
(4, 'puput', 'kinanti', 'natalia@sano.dev', 'user'),
(5, 'fresti', 'fransiska', 'andani@sano.dev', 'user'),
(8, 'orange', 'orange1', 'orange123@sano.dev', 'user');

--
-- Trigger `user`
--
DELIMITER $$
CREATE TRIGGER `CheckHakAksesBeforeInsert` BEFORE INSERT ON `user` FOR EACH ROW BEGIN
    IF NEW.hak_akses NOT IN ('admin', 'user') THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Hak akses yang dimasukkan tidak valid. Harus "admin" atau "user".';
    END IF;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `anggota`
--
ALTER TABLE `anggota`
  ADD PRIMARY KEY (`id_anggota`),
  ADD KEY `idx_nama_anggota` (`nama_anggota`);

--
-- Indeks untuk tabel `buku`
--
ALTER TABLE `buku`
  ADD PRIMARY KEY (`id_buku`),
  ADD KEY `idx_judul_buku` (`judul_buku`);

--
-- Indeks untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`),
  ADD KEY `FK_Anggota_Transaksi` (`nama_anggota`),
  ADD KEY `FK_Buku_Transaksi` (`judul_buku`),
  ADD KEY `FK_User_Transaksi` (`username`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`),
  ADD KEY `idx_username` (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `anggota`
--
ALTER TABLE `anggota`
  MODIFY `id_anggota` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT untuk tabel `buku`
--
ALTER TABLE `buku`
  MODIFY `id_buku` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD CONSTRAINT `FK_Anggota_Transaksi` FOREIGN KEY (`nama_anggota`) REFERENCES `anggota` (`nama_anggota`),
  ADD CONSTRAINT `FK_Buku_Transaksi` FOREIGN KEY (`judul_buku`) REFERENCES `buku` (`judul_buku`),
  ADD CONSTRAINT `FK_User_Transaksi` FOREIGN KEY (`username`) REFERENCES `user` (`username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
