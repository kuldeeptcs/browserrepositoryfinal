/*
SQLyog Community Edition- MySQL GUI v8.2 
MySQL - 5.6.33-0ubuntu0.14.04.1 : Database - MEDTRONIC_BE
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`MEDTRONIC_BE` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;

USE `MEDTRONIC_BE`;

/*Table structure for table `feedback` */

DROP TABLE IF EXISTS `feedback`;

CREATE TABLE `feedback` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `address` varchar(20) CHARACTER SET latin1 NOT NULL,
  `urlpath` varchar(500) CHARACTER SET latin1 NOT NULL,
  `feedback` varchar(500) CHARACTER SET latin1 NOT NULL,
  `result` tinyint(4) NOT NULL,
  `created_time` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=597 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `feedback` */

insert  into `feedback`(`id`,`user_id`,`address`,`urlpath`,`feedback`,`result`,`created_time`) values (593,'jitendrab2','10.10.11.45','https://stackoverflow.com/','by jitendra',0,'2019-04-29 13:45:43');
insert  into `feedback`(`id`,`user_id`,`address`,`urlpath`,`feedback`,`result`,`created_time`) values (594,'jitendrab2','10.10.11.45','https://stackoverflow.com/','success',0,'2019-04-29 13:46:18');
insert  into `feedback`(`id`,`user_id`,`address`,`urlpath`,`feedback`,`result`,`created_time`) values (595,'jitendrab2','10.10.11.45','https://stackoverflow.com/','begdgdgdgddgdgdgdgddg',1,'2019-04-29 13:47:14');
insert  into `feedback`(`id`,`user_id`,`address`,`urlpath`,`feedback`,`result`,`created_time`) values (596,'jitendrab2','10.10.11.45','https://stackoverflow.com/','by jitu bonde',1,'2019-04-29 13:51:36');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
