-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table biller_demo_db.billers
CREATE TABLE IF NOT EXISTS `billers` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `code` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `bill_type` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  `metadata` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Dumping data for table biller_demo_db.billers: ~12 rows (approximately)
INSERT INTO `billers` (`id`, `name`, `code`, `bill_type`, `status`, `metadata`, `created_at`, `updated_at`) VALUES
	(1, 'Viqarunnisa Noon School & College', 'VNC', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(2, 'Notre Dame College', 'NDC', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(3, 'KATTALI CITY CORPORATION GIRLS HIGH SCHOOL & COLLEGE', 'KCCGHSC', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(4, 'CHATTOGRAM CITY CORPORATION KAISER NILUFAR COLLEGE', 'CCCKNC', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(5, 'SARAIPARA CITY CORPORATION HIGH SCHOOL', 'SCCHS', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(6, 'SARAIPARA CITY CORPORATION DEGREE COLLEGE', 'SCCDC', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(7, 'FIROZSHAH CITY CORPORATION GIRLS HIGH SCHOOL', 'FCCGHS', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(8, 'CHATTOGRAM CITY CORPORATION PREMIER COLLEGE', 'CCCPC', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(9, 'RAMPUR CITY CORPORATION HIGH SCHOOL', 'RCCHS', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(10, 'HAJI ABDUL ALI CITY CORPORATION HIGH SCHOOL', 'HAACCHS', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(11, 'West Nasirabad Abdul Hakim City Corporation Kindergarten School', 'WNAHCCHS', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00'),
	(12, 'Ocean Marytime Academy', 'OMA', NULL, 1, NULL, '2023-07-05 00:00:00', '2023-07-05 00:00:00');

-- Dumping structure for table biller_demo_db.biller_assignments
CREATE TABLE IF NOT EXISTS `biller_assignments` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `biller_id` bigint DEFAULT NULL,
  `user_id` bigint DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Dumping data for table biller_demo_db.biller_assignments: ~13 rows (approximately)
INSERT INTO `biller_assignments` (`id`, `biller_id`, `user_id`, `created_at`, `updated_at`) VALUES
	(1, 1, 2, NULL, NULL),
	(2, 2, 2, NULL, NULL),
	(3, 1, 1, NULL, NULL),
	(4, 2, 1, NULL, NULL),
	(5, 1, 3, NULL, NULL),
	(6, 2, 3, NULL, NULL),
	(7, 8, 3, NULL, NULL),
	(8, 4, 3, NULL, NULL),
	(9, 5, 3, NULL, NULL),
	(10, 3, 1, NULL, NULL),
	(11, 8, 1, NULL, NULL),
	(12, 1, 2, NULL, NULL),
	(13, 12, 3, NULL, NULL);

-- Dumping structure for table biller_demo_db.biller_configuration
CREATE TABLE IF NOT EXISTS `biller_configuration` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `status` tinyint(1) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `biller_id` bigint DEFAULT NULL,
  `purpose` varchar(255) DEFAULT NULL,
  `configuration` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table biller_demo_db.biller_configuration: ~11 rows (approximately)
INSERT INTO `biller_configuration` (`id`, `status`, `created_at`, `updated_at`, `biller_id`, `purpose`, `configuration`) VALUES
	(2, 1, '2023-07-19 00:00:00', NULL, 1, 'TRANSACTION_MODEL', 'COMMON_API'),
	(4, 1, '2023-07-19 00:00:00', NULL, 1, 'TRANSACTION_API_SCOPE', 'POCKET_WALLET'),
	(5, 1, '2023-07-19 00:00:00', NULL, 2, 'TRANSACTION_MODEL', 'COMMON_API'),
	(7, 1, '2023-07-19 00:00:00', NULL, 2, 'TRANSACTION_API_SCOPE', 'POCKET_WALLET'),
	(8, 1, '2023-07-19 00:00:00', NULL, 3, 'TRANSACTION_MODEL', 'COMMON_API'),
	(9, 1, '2023-07-19 00:00:00', NULL, 4, 'TRANSACTION_MODEL', 'COMMON_API'),
	(10, 1, '2023-07-19 00:00:00', NULL, 3, 'TRANSACTION_API_SCOPE', 'OMA'),
	(11, 1, '2023-07-19 00:00:00', NULL, 4, 'TRANSACTION_API_SCOPE', 'POCKET_WALLET'),
	(12, 1, '2023-07-19 00:00:00', NULL, 8, 'TRANSACTION_MODEL', 'OFFLINE'),
	(13, 1, '2023-07-19 00:00:00', NULL, 12, 'TRANSACTION_API_SCOPE', 'OMA'),
	(14, 1, '2023-07-19 00:00:00', NULL, 12, 'TRANSACTION_MODEL', 'COMMON_API');

-- Dumping structure for table biller_demo_db.biller_form_datasets
CREATE TABLE IF NOT EXISTS `biller_form_datasets` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `dataset_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `unique_id` varchar(100) DEFAULT NULL,
  `biller_id` bigint NOT NULL,
  `created_by` bigint DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_by` bigint DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `biller_form_datasets_FK` (`biller_id`),
  CONSTRAINT `biller_form_datasets_FK` FOREIGN KEY (`biller_id`) REFERENCES `billers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table biller_demo_db.biller_form_datasets: ~5 rows (approximately)
INSERT INTO `biller_form_datasets` (`id`, `dataset_name`, `unique_id`, `biller_id`, `created_by`, `created_at`, `updated_by`, `updated_at`) VALUES
	(1, 'OMA Form', 'eaec0692-8f4a-4a39-a14e-a4cccd8c6dda', 12, 1, '2023-08-22 00:00:00', 2, '2023-09-06 15:21:00'),
	(2, 'Pocket Wallet Form (VNC)', '69134db0-929f-40c0-98a3-8018c81cef27', 1, 1, '2023-08-22 00:00:00', NULL, NULL),
	(15, 'Sanjatul Hasan Siam', 'eaec0692-8f4a-4a39-a14e-a4cccd8c6ff', 3, 2222, '2023-08-09 15:35:00', 3, '2023-08-15 15:35:00'),
	(16, 'Abudullah', 'eaec0692-8f4a-4a39-a14e-a4cccd8c6fe', 3, 2, '2023-08-04 15:37:00', 2, '2023-08-15 15:37:00'),
	(19, 'Sanjatul Hasan', 'eaec0692-8f4a-4a39-a14e-a4cccd8c6ff', 4, 33, '2023-09-01 16:07:00', 33, '2023-09-01 16:07:00'),
	(21, 'Maruf', 'eaec0692-8f4a-4a39-a14e-a4cccd8c6ff', 6, 33, '2023-09-21 16:16:00', 33, '2023-09-01 16:16:00');

-- Dumping structure for table biller_demo_db.biller_form_dataset_fields
CREATE TABLE IF NOT EXISTS `biller_form_dataset_fields` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `is_mandatory` tinyint(1) DEFAULT NULL,
  `max_length` int DEFAULT NULL,
  `regex` longtext,
  `field_type_id` bigint NOT NULL,
  `created_by` bigint DEFAULT NULL,
  `updated_by` bigint DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `dataset_id` bigint NOT NULL,
  `min_value` decimal(16,4) DEFAULT NULL,
  `max_value` decimal(16,4) DEFAULT NULL,
  `field_order` int DEFAULT NULL,
  `field_name` varchar(100) DEFAULT NULL,
  `friendly_field_name` varchar(100) DEFAULT NULL,
  `is_active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `biller_form_dataset_fields_FK` (`dataset_id`),
  KEY `biller_form_dataset_fields_FK_1` (`field_type_id`),
  CONSTRAINT `biller_form_dataset_fields_FK` FOREIGN KEY (`dataset_id`) REFERENCES `biller_form_datasets` (`id`),
  CONSTRAINT `biller_form_dataset_fields_FK_1` FOREIGN KEY (`field_type_id`) REFERENCES `biller_form_field_types` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table biller_demo_db.biller_form_dataset_fields: ~15 rows (approximately)
INSERT INTO `biller_form_dataset_fields` (`id`, `is_mandatory`, `max_length`, `regex`, `field_type_id`, `created_by`, `updated_by`, `created_at`, `updated_at`, `dataset_id`, `min_value`, `max_value`, `field_order`, `field_name`, `friendly_field_name`, `is_active`) VALUES
	(1, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 1, NULL, NULL, 1, 'customer_no', 'student_id', 1),
	(2, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 1, NULL, NULL, 2, 'amount', 'amount', 1),
	(3, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 1, NULL, NULL, 3, 'transaction_id', 'transaction_id', 1),
	(4, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 1, NULL, NULL, 4, 'biller_id', 'biller_id', 1),
	(5, 1, NULL, NULL, 3, 1, NULL, '2023-08-22 00:00:00', NULL, 1, NULL, NULL, 5, 'branch_id', 'branch_id', 1),
	(6, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 1, NULL, NULL, 6, 'contact_no', 'contact_no', 1),
	(7, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 2, NULL, NULL, 6, 'customer_no', 'wallet_no', 1),
	(8, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 2, NULL, NULL, 6, 'amount', 'amount', 1),
	(9, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 2, NULL, NULL, 6, 'transaction_id', 'transaction_id', 1),
	(10, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 2, NULL, NULL, 6, 'biller_id', 'biller_id', 1),
	(11, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 2, NULL, NULL, 6, 'branch_id', 'branch_id', 1),
	(12, 1, NULL, NULL, 1, 1, NULL, '2023-08-22 00:00:00', NULL, 2, NULL, NULL, 6, 'contact_no', 'contact_no', 1),
	(46, 1, 5, 'abc', 3, 4, 4, '2023-09-22 15:53:00', '2023-09-13 15:53:00', 16, 4.0000, 4.0000, 4, 'mahmud', 'abc', 0),
	(47, 1, 6, 'abc', 2, 6, 6, '2023-09-07 15:53:00', '2023-09-21 15:54:00', 16, 6.0000, 6.0000, 6, 'sanjatul', 'sanja', 0),
	(48, 1, 3, 'abc', 3, 33, 33, '2023-09-22 16:07:00', '2023-09-01 16:08:00', 19, 3.0000, 3.0000, 3, 'sanjatul', 'sanja', 1),
	(49, 1, 3, 'abc', 4, 33, 33, '2023-09-01 16:08:00', '2023-09-01 16:09:00', 19, 3.0000, 3.0000, 3, 'siam', 'siam', 0),
	(51, 1, 3, 'abc', 2, 33, 33, '2023-09-01 16:16:00', '2023-09-14 16:16:00', 21, 3.0000, 3.0000, 3, 'maruf', 'maruf', 0),
	(57, 1, NULL, NULL, 2, NULL, NULL, NULL, NULL, 21, NULL, NULL, NULL, NULL, NULL, NULL);

-- Dumping structure for table biller_demo_db.biller_form_dataset_field_values
CREATE TABLE IF NOT EXISTS `biller_form_dataset_field_values` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `value` varchar(500) DEFAULT NULL,
  `is_default` tinyint(1) DEFAULT NULL,
  `dataset_field_id` bigint NOT NULL,
  `created_by` bigint DEFAULT NULL,
  `updated_by` bigint DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `text` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `biller_form_field_values_FK` (`dataset_field_id`),
  CONSTRAINT `biller_form_field_values_FK` FOREIGN KEY (`dataset_field_id`) REFERENCES `biller_form_dataset_fields` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table biller_demo_db.biller_form_dataset_field_values: ~3 rows (approximately)
INSERT INTO `biller_form_dataset_field_values` (`id`, `value`, `is_default`, `dataset_field_id`, `created_by`, `updated_by`, `created_at`, `updated_at`, `text`) VALUES
	(1, '1', 0, 5, 1, NULL, '2023-08-27 15:18:42', NULL, 'Gulshan'),
	(2, '2', 0, 5, 1, NULL, '2023-08-27 15:18:42', NULL, 'Mirpur'),
	(3, '1', 1, 11, 1, NULL, '2023-08-27 15:18:42', NULL, 'Gulshan');

-- Dumping structure for table biller_demo_db.biller_form_dataset_mapping_fields
CREATE TABLE IF NOT EXISTS `biller_form_dataset_mapping_fields` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `mapping_field_name` varchar(500) DEFAULT NULL,
  `biller_id` bigint DEFAULT NULL,
  `created_by` bigint DEFAULT NULL,
  `updated_by` bigint DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table biller_demo_db.biller_form_dataset_mapping_fields: ~0 rows (approximately)

-- Dumping structure for table biller_demo_db.biller_form_field_types
CREATE TABLE IF NOT EXISTS `biller_form_field_types` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table biller_demo_db.biller_form_field_types: ~4 rows (approximately)
INSERT INTO `biller_form_field_types` (`id`, `description`) VALUES
	(1, 'textbox'),
	(2, 'checkbox'),
	(3, 'dropdown'),
	(4, 'radiobutton');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
