-- PROCEDURE: public.SelectRoots()

-- DROP PROCEDURE IF EXISTS public."SelectRoots"();

CREATE OR REPLACE PROCEDURE public."SelectRoots"(
	)
LANGUAGE 'sql'
AS $BODY$
SELECT "Id", "ParentId", "Name", "Description", "ext"
	FROM public."BinaryTree" WHERE "Id" = "ParentId";
$BODY$;
ALTER PROCEDURE public."SelectRoots"()
    OWNER TO postgres;
