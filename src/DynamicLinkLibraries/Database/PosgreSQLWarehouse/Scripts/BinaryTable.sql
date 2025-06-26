-- Table: public.BinaryTable

-- DROP TABLE IF EXISTS public."BinaryTable";

CREATE TABLE IF NOT EXISTS public."BinaryTable"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "ParentId" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default" NOT NULL,
    "Data" bytea NOT NULL,
    ext text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "ID" PRIMARY KEY ("Id"),
    CONSTRAINT "TableTree" FOREIGN KEY ("ParentId")
        REFERENCES public."BinaryTree" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."BinaryTable"
    OWNER to postgres;
-- Index: fki_TableTree

-- DROP INDEX IF EXISTS public."fki_TableTree";

CREATE INDEX IF NOT EXISTS "fki_TableTree"
    ON public."BinaryTable" USING btree
    ("ParentId" ASC NULLS LAST)
    TABLESPACE pg_default;