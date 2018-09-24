CREATE TABLE IF NOT EXISTS `log` (
  `ad` date DEFAULT NULL,
  `at` time DEFAULT NULL,
  `user` varchar(10) DEFAULT NULL,
  `action` varchar(512) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;