-- PROCEDURE: public.InsertRoot(uuid)

-- DROP PROCEDURE IF EXISTS public."InsertRoot"(uuid);

CREATE OR REPLACE PROCEDURE public."InsertRoot"(
	IN iid uuid DEFAULT uuid_generate_v4())
LANGUAGE 'sql'
AS $BODY$
INSERT INTO public."BinaryTree"(
	"Id", "ParentId", "Name", "Description", ext)
	VALUES (iid, iid, 'root', 'Root directory', 'ext');
$BODY$;
ALTER PROCEDURE public."InsertRoot"(uuid)
    OWNER TO postgres;
