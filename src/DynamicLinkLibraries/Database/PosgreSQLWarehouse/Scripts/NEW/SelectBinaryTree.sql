-- PROCEDURE: public.SelectBinaryTree()

-- DROP PROCEDURE IF EXISTS public."SelectBinaryTree"();

CREATE OR REPLACE PROCEDURE public."SelectBinaryTree"(
	)
LANGUAGE 'sql'
AS $BODY$
SELECT "Id", "ParentId", "Name", "Description", "ext"
	FROM public."BinaryTree";
$BODY$;
ALTER PROCEDURE public."SelectBinaryTree"()
    OWNER TO postgres;
