-- PROCEDURE: public.InsertTree(uuid, uuid, text, text, text)

-- DROP PROCEDURE IF EXISTS public."InsertTree"(uuid, uuid, text, text, text);

CREATE OR REPLACE PROCEDURE public."InsertTree"(
	IN id uuid,
	IN parent uuid,
	IN name text,
	IN description text,
	IN ext text)
LANGUAGE 'sql'
AS $BODY$
INSERT INTO public."BinaryTree"(
	"Id", "ParentId", "Name", "Description", ext)
	VALUES (id, parent, name,  description, ext);
$BODY$;
ALTER PROCEDURE public."InsertTree"(uuid, uuid, text, text, text)
    OWNER TO postgres;
