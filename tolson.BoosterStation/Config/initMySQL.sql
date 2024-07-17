
-- create database
CREATE DATABASE `toslson.boosterstation` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

-- create table
-- `toslson.boosterstation`.plchistorydata definition
CREATE TABLE `plchistorydata` (
  `ID` bigint NOT NULL AUTO_INCREMENT,
  `TempIn1` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TempIn2` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TempOut` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PressureTank1` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PressureTank2` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `LevelTank1` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `LevelTank2` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PressureTankOut` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreateUser` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `UpdateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateUser` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='PLC采集历史数据表';