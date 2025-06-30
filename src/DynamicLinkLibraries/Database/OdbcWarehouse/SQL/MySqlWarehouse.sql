-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema mysqlwarehouse
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mysqlwarehouse
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mysqlwarehouse` DEFAULT CHARACTER SET utf8mb3 ;
USE `mysqlwarehouse` ;

-- -----------------------------------------------------
-- Table `mysqlwarehouse`.`binarytree`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mysqlwarehouse`.`binarytree` ;

CREATE TABLE IF NOT EXISTS `mysqlwarehouse`.`binarytree` (
  `Id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `ParentId` BIGINT UNSIGNED NOT NULL,
  `Name` TEXT NOT NULL,
  `Description` TEXT NOT NULL,
  `Extension` TEXT NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  INDEX `TreeTree` (`ParentId` ASC) VISIBLE,
  CONSTRAINT `TreeTree`
    FOREIGN KEY (`ParentId`)
    REFERENCES `mysqlwarehouse`.`binarytree` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mysqlwarehouse`.`binarytable`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mysqlwarehouse`.`binarytable` ;

CREATE TABLE IF NOT EXISTS `mysqlwarehouse`.`binarytable` (
  `Id` BIGINT UNSIGNED NOT NULL,
  `ParentId` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Name` TEXT NOT NULL,
  `Description` TEXT NOT NULL,
  `Extension` TEXT NOT NULL,
  `Data` BLOB NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  INDEX `TableTree` (`ParentId` ASC) VISIBLE,
  CONSTRAINT `TableTree`
    FOREIGN KEY (`ParentId`)
    REFERENCES `mysqlwarehouse`.`binarytree` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;

USE `mysqlwarehouse` ;

-- -----------------------------------------------------
-- Placeholder table for view `mysqlwarehouse`.`tablew`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mysqlwarehouse`.`tablew` (`Id` INT, `ParentId` INT, `Name` INT, `Extension` INT);

-- -----------------------------------------------------
-- procedure insert_table
-- -----------------------------------------------------

USE `mysqlwarehouse`;
DROP procedure IF EXISTS `mysqlwarehouse`.`insert_table`;

DELIMITER $$
USE `mysqlwarehouse`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_table`(ParentId bigint, Name text, description text, extension text, data blob, id bigint)
BEGIN
declare id bigint;
set id = LAST_INSERT_ID() + 1;
INSERT INTO `mysqlwarehouse`.`binarytable`
(`Id`,
`ParentId`,
`Name`,
`Description`,
`Extension`,
`Data`)
VALUES (
id,
ParentId,
Name,
description,
extension,
data);
select id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure insert_tree
-- -----------------------------------------------------

USE `mysqlwarehouse`;
DROP procedure IF EXISTS `mysqlwarehouse`.`insert_tree`;

DELIMITER $$
USE `mysqlwarehouse`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_tree`(PareantId bigint, Name text, description text, extension text)
BEGIN
declare id bigint;
set id = LAST_INSERT_ID() + 1;
INSERT INTO `mysqlwarehouse`.`binarytree`
(`Id`,
`ParentId`,
`Name`,
`Description`,
`Extension`)
VALUES (
id,
ParentId,
Name,
description,
extension);
select id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure insert_root
-- -----------------------------------------------------

USE `mysqlwarehouse`;
DROP procedure IF EXISTS `mysqlwarehouse`.`insert_root`;

DELIMITER $$
USE `mysqlwarehouse`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_root`(Name text, description text, extension text)
BEGIN
declare id bigint;
set id = LAST_INSERT_ID() + 1;
INSERT INTO `mysqlwarehouse`.`binarytree`
(`Id`,
`ParentId`,
`Name`,
`Description`,
`Extension`)
VALUES (
id,
id,
Name,
description,
extension);
select id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `mysqlwarehouse`.`tablew`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mysqlwarehouse`.`tablew`;
DROP VIEW IF EXISTS `mysqlwarehouse`.`tablew` ;
USE `mysqlwarehouse`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `mysqlwarehouse`.`tablew` AS select `mysqlwarehouse`.`binarytable`.`Id` AS `Id`,`mysqlwarehouse`.`binarytable`.`ParentId` AS `ParentId`,`mysqlwarehouse`.`binarytable`.`Name` AS `Name`,`mysqlwarehouse`.`binarytable`.`Extension` AS `Extension` from `mysqlwarehouse`.`binarytable`;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
