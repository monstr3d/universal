-- PROCEDURE: public.InsertChildTree(uuid, character varying[], character varying[], "char"[], uuid)

-- DROP PROCEDURE IF EXISTS public."InsertChildTree"(uuid, character varying[], character varying[], "char"[], uuid);

CREATE OR REPLACE PROCEDURE public."InsertChildTree"(
	IN parent uuid,
	IN name character varying[],
	IN description character varying[],
	IN ext "char"[],
	IN iid uuid DEFAULT uuid_generate_v4())
LANGUAGE 'sql'
AS $BODY$
INSERT INTO public."BinaryTree"(
	"Id", "ParentId", "Name", "Description", "ext")
	VALUES (iid, parent, name, description, ext);
$BODY$;
ALTER PROCEDURE public."InsertChildTree"(uuid, character varying[], character varying[], "char"[], uuid)
    OWNER TO postgres;
