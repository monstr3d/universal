-- PROCEDURE: public.CreateTable(uuid, uuid, text, text, bytea, text)

-- DROP PROCEDURE IF EXISTS public."CreateTable"(uuid, uuid, text, text, bytea, text);

CREATE OR REPLACE PROCEDURE public."CreateTable"(
	IN id uuid,
	IN parent uuid,
	IN name text,
	IN description text,
	IN data bytea,
	IN extension text)
LANGUAGE 'sql'
AS $BODY$
INSERT INTO public."BinaryTable"(
	"Id", "ParentId", "Name", "Description", "Data", "ext")
	VALUES (id, parent, name, description, data, extension);
$BODY$;
ALTER PROCEDURE public."CreateTable"(uuid, uuid, text, text, bytea, text)
    OWNER TO postgres;
