PGDMP      $                }            PostgreSQL_Warehouse    17.5    17.5     ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            @           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            A           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            B           1262    19575    PostgreSQL_Warehouse    DATABASE     �   CREATE DATABASE "PostgreSQL_Warehouse" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
 &   DROP DATABASE "PostgreSQL_Warehouse";
                     postgres    false                        3079    20535 	   uuid-ossp 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;
    DROP EXTENSION "uuid-ossp";
                        false            C           0    0    EXTENSION "uuid-ossp"    COMMENT     W   COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';
                             false    2            �            1255    20579    ClearTree() 	   PROCEDURE     c   CREATE PROCEDURE public."ClearTree"()
    LANGUAGE sql
    AS $$DELETE FROM public."BinaryTree"$$;
 %   DROP PROCEDURE public."ClearTree"();
       public               postgres    false            �            1255    20581 O   InsertChildTree(uuid, character varying[], character varying[], "char"[], uuid) 	   PROCEDURE     Z  CREATE PROCEDURE public."InsertChildTree"(IN parent uuid, IN name character varying[], IN description character varying[], IN ext "char"[], IN iid uuid DEFAULT public.uuid_generate_v4())
    LANGUAGE sql
    AS $$INSERT INTO public."BinaryTree"(
	"Id", "ParentId", "Name", "Description", "ext")
	VALUES (iid, parent, name, description, ext);
$$;
 �   DROP PROCEDURE public."InsertChildTree"(IN parent uuid, IN name character varying[], IN description character varying[], IN ext "char"[], IN iid uuid);
       public               postgres    false    2            �            1255    20578    InsertRoot(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public."InsertRoot"(IN iid uuid DEFAULT public.uuid_generate_v4())
    LANGUAGE sql
    AS $$INSERT INTO public."BinaryTree"(
	"Id", "ParentId", "Name", "Description", ext)
	VALUES (iid, iid, 'root', 'Root directory', 'ext');$$;
 1   DROP PROCEDURE public."InsertRoot"(IN iid uuid);
       public               postgres    false    2            �            1255    20572    SelectBinaryTable() 	   PROCEDURE     �   CREATE PROCEDURE public."SelectBinaryTable"()
    LANGUAGE sql
    AS $$SELECT "Id", "ParentId", "Name", "Description", "Ext"
	FROM public."BinaryTable";$$;
 -   DROP PROCEDURE public."SelectBinaryTable"();
       public               postgres    false            �            1255    20573    SelectBinaryTree() 	   PROCEDURE     �   CREATE PROCEDURE public."SelectBinaryTree"()
    LANGUAGE sql
    AS $$SELECT "Id", "ParentId", "Name", "Description", "ext"
	FROM public."BinaryTree";$$;
 ,   DROP PROCEDURE public."SelectBinaryTree"();
       public               postgres    false            �            1259    20557    BinaryTable    TABLE     N  CREATE TABLE public."BinaryTable" (
    "Id" uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    "ParentId" uuid NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Description" character varying(300) NOT NULL,
    "Data" bytea NOT NULL,
    "Length" character varying(30) NOT NULL,
    "Ext" character varying(10) NOT NULL
);
 !   DROP TABLE public."BinaryTable";
       public         heap r       postgres    false    2            �            1259    20546 
   BinaryTree    TABLE     �   CREATE TABLE public."BinaryTree" (
    "Id" uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    "ParentId" uuid NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Description" character varying(300) NOT NULL,
    ext character(10) NOT NULL
);
     DROP TABLE public."BinaryTree";
       public         heap r       postgres    false    2            �            1259    20524    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap r       postgres    false            <          0    20557    BinaryTable 
   TABLE DATA           i   COPY public."BinaryTable" ("Id", "ParentId", "Name", "Description", "Data", "Length", "Ext") FROM stdin;
    public               postgres    false    220   7       ;          0    20546 
   BinaryTree 
   TABLE DATA           T   COPY public."BinaryTree" ("Id", "ParentId", "Name", "Description", ext) FROM stdin;
    public               postgres    false    219   T       :          0    20524    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public               postgres    false    218   �       �           2606    20564    BinaryTable PK_BinaryTable 
   CONSTRAINT     ^   ALTER TABLE ONLY public."BinaryTable"
    ADD CONSTRAINT "PK_BinaryTable" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."BinaryTable" DROP CONSTRAINT "PK_BinaryTable";
       public                 postgres    false    220            �           2606    20551    BinaryTree PK_BinaryTree 
   CONSTRAINT     \   ALTER TABLE ONLY public."BinaryTree"
    ADD CONSTRAINT "PK_BinaryTree" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."BinaryTree" DROP CONSTRAINT "PK_BinaryTree";
       public                 postgres    false    219            �           2606    20528 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public                 postgres    false    218            �           1259    20570    IX_BinaryTable_ParentId    INDEX     Y   CREATE INDEX "IX_BinaryTable_ParentId" ON public."BinaryTable" USING btree ("ParentId");
 -   DROP INDEX public."IX_BinaryTable_ParentId";
       public                 postgres    false    220            �           1259    20571    IX_BinaryTree_ParentId    INDEX     W   CREATE INDEX "IX_BinaryTree_ParentId" ON public."BinaryTree" USING btree ("ParentId");
 ,   DROP INDEX public."IX_BinaryTree_ParentId";
       public                 postgres    false    219            �           2606    20565 %   BinaryTable FK_BinaryTable_BinaryTree    FK CONSTRAINT     �   ALTER TABLE ONLY public."BinaryTable"
    ADD CONSTRAINT "FK_BinaryTable_BinaryTree" FOREIGN KEY ("ParentId") REFERENCES public."BinaryTree"("Id");
 S   ALTER TABLE ONLY public."BinaryTable" DROP CONSTRAINT "FK_BinaryTable_BinaryTree";
       public               postgres    false    219    220    4771            �           2606    20552 #   BinaryTree FK_BinaryTree_BinaryTree    FK CONSTRAINT     �   ALTER TABLE ONLY public."BinaryTree"
    ADD CONSTRAINT "FK_BinaryTree_BinaryTree" FOREIGN KEY ("ParentId") REFERENCES public."BinaryTree"("Id");
 Q   ALTER TABLE ONLY public."BinaryTree" DROP CONSTRAINT "FK_BinaryTree_BinaryTree";
       public               postgres    false    219    219    4771            <      x������ � �      ;   N   x�K5HM6H12�5L25�5IN4�M4�0�5H1364OM1MN2�L%FQQ~~	g�PH�,JM.�/��L�(Q� �=... p��      :   0   x�32025032440115����,�L�q.JM,I��3�3����� ӭ	�     