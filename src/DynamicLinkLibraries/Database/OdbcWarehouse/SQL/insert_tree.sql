CREATE PROCEDURE `mysqlwarehouse`.`insert_tree` (ParentId bigint, Name text, description text, extension text, id bigint)
BEGIN
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
END