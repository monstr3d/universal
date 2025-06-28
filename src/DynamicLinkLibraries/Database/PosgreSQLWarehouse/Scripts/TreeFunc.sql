-- FUNCTION: public.TreesFunc(uuid)

-- DROP FUNCTION IF EXISTS public."TreesFunc"(uuid);

CREATE OR REPLACE FUNCTION public."TreesFunc"(
	idd uuid)
    RETURNS TABLE(id uuid, parent uuid, name text, description text, ext text) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "Id", "ParentId", "Name", "Description", "ext"
	FROM public."BinaryTree" WHERE "ParentId" = idd;
$BODY$;

ALTER FUNCTION public."TreesFunc"(uuid)
    OWNER TO postgres;

    '6210af43-ef8a-41b7-97cc-5a7f759b2d12'

    '6210af43-ef8a-41b7-97cc-5a7f759b2d12'