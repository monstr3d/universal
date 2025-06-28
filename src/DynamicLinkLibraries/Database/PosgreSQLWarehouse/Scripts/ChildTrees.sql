-- PROCEDURE: public.ChildTrees(uuid)

-- DROP PROCEDURE IF EXISTS public."ChildTrees"(uuid);

CREATE OR REPLACE PROCEDURE public."ChildTrees"(
	IN idd uuid)
LANGUAGE 'sql'
AS $BODY$
SELECT "Id", "ParentId", "Name", "Description", ext
	FROM public."BinaryTree" WHERE "ParentId" = idd;
$BODY$;
ALTER PROCEDURE public."ChildTrees"(uuid)
    OWNER TO postgres;
