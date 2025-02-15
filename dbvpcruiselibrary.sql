-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 14, 2025 at 11:01 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbvpcruiselibrary`
--

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `book_id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `author` varchar(100) DEFAULT NULL,
  `isbn` varchar(20) DEFAULT NULL,
  `publication_year` int(11) DEFAULT NULL,
  `category` varchar(100) DEFAULT NULL,
  `status` enum('available','borrowed','reserved') DEFAULT 'available'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `title`, `author`, `isbn`, `publication_year`, `category`, `status`) VALUES
(2, 'Dertogada', 'Yesmak Worku', '1234567125798', 2000, 'Fiction', 'borrowed'),
(4, 'Ramatora', 'Yesmak Worku', '152476581698702', 2009, 'Fiction', 'available');

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `member_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone_number` varchar(15) DEFAULT NULL,
  `registration_date` date DEFAULT curdate(),
  `status` enum('active','inactive') DEFAULT 'active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`member_id`, `name`, `email`, `phone_number`, `registration_date`, `status`) VALUES
(1, 'Minase Wondu', 'minasewendu@gmail.com', '0912129835', '2024-12-25', 'active'),
(3, 'Hiwot G', 'hiwot32@gmail.com', '0932124589', '2024-12-28', 'active');

-- --------------------------------------------------------

--
-- Table structure for table `reports`
--

CREATE TABLE `reports` (
  `report_id` int(11) NOT NULL,
  `report_type` varchar(50) NOT NULL,
  `generated_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `data` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reports`
--

INSERT INTO `reports` (`report_id`, `report_type`, `generated_at`, `data`) VALUES
(1, 'Active Members List', '2025-02-08 19:42:10', NULL),
(2, 'Inactive Members List', '2025-02-08 20:08:49', NULL),
(3, 'Members With Overdue', '2025-02-08 20:09:05', NULL),
(4, 'Available Books List', '2025-02-08 20:09:33', NULL),
(5, 'Borrowed Books List', '2025-02-08 20:09:51', NULL),
(6, 'Most Borrowed Books', '2025-02-08 20:10:03', NULL),
(7, 'Active Transactions List', '2025-02-08 20:10:24', NULL),
(8, 'Complete Transactions List', '2025-02-08 20:10:41', NULL),
(9, 'User With Most Transactions', '2025-02-08 20:10:58', NULL),
(10, 'Report On Reports', '2025-02-08 20:13:58', NULL),
(11, 'User Report', '2025-02-08 20:17:00', NULL),
(12, 'Active Members List', '2025-02-09 15:50:01', NULL),
(13, 'Members With Overdue', '2025-02-09 15:50:20', NULL),
(14, 'Most Borrowed Books', '2025-02-09 15:50:41', NULL),
(15, 'Members With Overdue', '2025-02-09 15:56:15', NULL),
(16, 'User With Most Transactions', '2025-02-09 23:39:13', NULL),
(17, 'Inactive Members List', '2025-02-11 16:08:35', NULL),
(18, 'Report On Reports', '2025-02-11 16:08:44', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `transaction_id` int(11) NOT NULL,
  `member_id` int(11) DEFAULT NULL,
  `book_id` int(11) DEFAULT NULL,
  `borrow_date` date NOT NULL,
  `return_date` date DEFAULT NULL,
  `due_date` date NOT NULL,
  `status` enum('active','completed','overdue') DEFAULT 'active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`transaction_id`, `member_id`, `book_id`, `borrow_date`, `return_date`, `due_date`, `status`) VALUES
(5, 3, 4, '2024-12-28', '2024-12-29', '2024-12-29', 'completed'),
(7, 3, 2, '2024-12-31', '2024-12-31', '2024-12-31', 'completed'),
(8, 1, 4, '2024-12-31', '2024-12-31', '2024-12-31', 'completed'),
(9, 3, 4, '2025-01-01', '2025-01-02', '2025-01-02', 'completed'),
(10, 1, 2, '2025-01-04', '2025-01-05', '2025-01-06', 'overdue');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role` enum('librarian','Admin') NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password_hash`, `role`, `created_at`) VALUES
(1, 'AbelAschalew', '0112135990', 'Admin', '2024-12-24 17:25:07'),
(21, 'NatolDegefu', '123456789', 'librarian', '2024-12-28 13:45:55'),
(22, 'Abebe', '4545', 'librarian', '2025-01-04 13:42:25');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`book_id`),
  ADD UNIQUE KEY `isbn` (`isbn`);

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`member_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`report_id`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `member_id` (`member_id`),
  ADD KEY `book_id` (`book_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `members`
--
ALTER TABLE `members`
  MODIFY `member_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `report_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`member_id`) REFERENCES `members` (`member_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `books` (`book_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
