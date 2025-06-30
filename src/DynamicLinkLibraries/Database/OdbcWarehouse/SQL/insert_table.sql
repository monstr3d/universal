CREATE PROCEDURE `mysqlwarehouse`.`insert_table` (ParentId bigint, Name text, description text, extension text, data blob, id bigint)
BEGIN
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
END