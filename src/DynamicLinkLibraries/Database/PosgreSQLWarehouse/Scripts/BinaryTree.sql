-- Table: public.BinaryTree

-- DROP TABLE IF EXISTS public."BinaryTree";

CREATE TABLE IF NOT EXISTS public."BinaryTree"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "ParentId" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default" NOT NULL,
    ext text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_BinaryTree" PRIMARY KEY ("Id"),
    CONSTRAINT "BinaryTree_BinaryTree" FOREIGN KEY ("ParentId")
        REFERENCES public."BinaryTree" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."BinaryTree"
    OWNER to postgres;
-- Index: fki_BinaryTree_BinaryTree

-- DROP INDEX IF EXISTS public."fki_BinaryTree_BinaryTree";

CREATE INDEX IF NOT EXISTS "fki_BinaryTree_BinaryTree"
    ON public."BinaryTree" USING btree
    ("ParentId" ASC NULLS LAST)
    TABLESPACE pg_default;