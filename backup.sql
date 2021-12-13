--
-- PostgreSQL database dump
--

-- Dumped from database version 14.0
-- Dumped by pg_dump version 14.0

-- Started on 2021-12-13 18:12:52

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 211 (class 1259 OID 33088)
-- Name: Armazems; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Armazems" (
    "Id" uuid NOT NULL
);


ALTER TABLE public."Armazems" OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 33093)
-- Name: Consultas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Consultas" (
    "Id" uuid NOT NULL,
    "DentistaId" uuid NOT NULL,
    "ClienteId" uuid NOT NULL,
    "DataHora" timestamp without time zone NOT NULL,
    "DataCriacao" timestamp without time zone NOT NULL
);


ALTER TABLE public."Consultas" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 33139)
-- Name: Documentos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Documentos" (
    "Id" uuid NOT NULL,
    "Observacao" text,
    "Imagens" bytea NOT NULL,
    "ProntuarioId" uuid
);


ALTER TABLE public."Documentos" OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 33108)
-- Name: Endereco; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Endereco" (
    "Id" uuid NOT NULL,
    "Rua" text NOT NULL,
    bairro text NOT NULL,
    "Cidade" text NOT NULL,
    "Numero" integer NOT NULL
);


ALTER TABLE public."Endereco" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 33151)
-- Name: PerguntaBooleana; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PerguntaBooleana" (
    "Id" uuid NOT NULL,
    "Pergunta" text NOT NULL,
    "Resposta" boolean NOT NULL,
    "ProntuarioId" uuid
);


ALTER TABLE public."PerguntaBooleana" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 33163)
-- Name: Perguntastring; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Perguntastring" (
    "Id" uuid NOT NULL,
    "Perunta" text NOT NULL,
    "Reposta" text,
    "ProntuarioId" uuid
);


ALTER TABLE public."Perguntastring" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 33127)
-- Name: Produtos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Produtos" (
    "Id" uuid NOT NULL,
    "Nome" text NOT NULL,
    "Quantidade" integer NOT NULL,
    "Validade" timestamp without time zone NOT NULL,
    "Descricao" text NOT NULL,
    "ArmazemId" uuid NOT NULL,
    "DataDeAdicao" timestamp without time zone NOT NULL
);


ALTER TABLE public."Produtos" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 33115)
-- Name: Prontuarios; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Prontuarios" (
    "Id" uuid NOT NULL
);


ALTER TABLE public."Prontuarios" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 33120)
-- Name: TipoUsuario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TipoUsuario" (
    "Id" integer NOT NULL,
    "Nome" character varying(60) NOT NULL,
    "Role" text NOT NULL
);


ALTER TABLE public."TipoUsuario" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16401)
-- Name: Usuarios; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Usuarios" (
    "Id" uuid NOT NULL,
    "Nome" text NOT NULL,
    "Cpf" text NOT NULL,
    "Senha" text DEFAULT ''::text NOT NULL,
    "DataCriacao" timestamp without time zone NOT NULL,
    "Ativo" boolean NOT NULL,
    "Email" text NOT NULL,
    "Telefone" text NOT NULL,
    "Discriminator" text NOT NULL,
    "Cro" text,
    "DataNascimento" timestamp without time zone DEFAULT '0001-01-01 00:00:00'::timestamp without time zone NOT NULL,
    "EnderecoId" uuid,
    "ResponsavelId" uuid,
    "TipoId" integer
);


ALTER TABLE public."Usuarios" OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16396)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 3389 (class 0 OID 33088)
-- Dependencies: 211
-- Data for Name: Armazems; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Armazems" ("Id") FROM stdin;
74242b55-4e16-4003-a309-50c38bb0c630
de42b1d6-432e-4115-b1dd-2a8dbdd6f83f
8a312f2f-27b7-49de-980f-4e129faeccd6
\.


--
-- TOC entry 3390 (class 0 OID 33093)
-- Dependencies: 212
-- Data for Name: Consultas; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Consultas" ("Id", "DentistaId", "ClienteId", "DataHora", "DataCriacao") FROM stdin;
003585cf-02f0-4c2b-806e-bbb3a2cd311d	d60986b4-7179-4d9e-8bbb-454ead32e595	bbaa76ce-6c4a-4513-b62e-83dccce08bde	2021-11-21 23:30:00	2021-10-26 19:33:14.830564
e5b4b86f-fbb5-42ed-b275-2809ebbf3114	600c2437-6ab4-49fe-9bad-db110a16771c	7b1b2504-6190-4242-b430-5135aa5469d4	2021-12-26 20:25:00	2021-11-24 18:55:05.018778
bc6e8ac9-cdf6-4a4d-b3cb-1ba6d6cc0e7c	b49866bc-09f0-4930-a13b-9c3a36799640	2408f2f6-c9ee-49c0-9774-90646e1d5bcb	2022-01-22 18:25:00	2021-12-13 18:01:13.478072
\.


--
-- TOC entry 3395 (class 0 OID 33139)
-- Dependencies: 217
-- Data for Name: Documentos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Documentos" ("Id", "Observacao", "Imagens", "ProntuarioId") FROM stdin;
\.


--
-- TOC entry 3391 (class 0 OID 33108)
-- Dependencies: 213
-- Data for Name: Endereco; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Endereco" ("Id", "Rua", bairro, "Cidade", "Numero") FROM stdin;
\.


--
-- TOC entry 3396 (class 0 OID 33151)
-- Dependencies: 218
-- Data for Name: PerguntaBooleana; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PerguntaBooleana" ("Id", "Pergunta", "Resposta", "ProntuarioId") FROM stdin;
\.


--
-- TOC entry 3397 (class 0 OID 33163)
-- Dependencies: 219
-- Data for Name: Perguntastring; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Perguntastring" ("Id", "Perunta", "Reposta", "ProntuarioId") FROM stdin;
\.


--
-- TOC entry 3394 (class 0 OID 33127)
-- Dependencies: 216
-- Data for Name: Produtos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Produtos" ("Id", "Nome", "Quantidade", "Validade", "Descricao", "ArmazemId", "DataDeAdicao") FROM stdin;
a3fa262e-ade7-4ed5-be05-e4a70b768283	Luvas	32	2021-12-10 00:00:00	luvas	74242b55-4e16-4003-a309-50c38bb0c630	2021-12-13 17:29:07.769872
\.


--
-- TOC entry 3392 (class 0 OID 33115)
-- Dependencies: 214
-- Data for Name: Prontuarios; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Prontuarios" ("Id") FROM stdin;
\.


--
-- TOC entry 3393 (class 0 OID 33120)
-- Dependencies: 215
-- Data for Name: TipoUsuario; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TipoUsuario" ("Id", "Nome", "Role") FROM stdin;
1	Administrativo	Admin
2	Dentista	Dentista
3	Cliente	Cliente
4	Recepcionista	Recepcionista
\.


--
-- TOC entry 3388 (class 0 OID 16401)
-- Dependencies: 210
-- Data for Name: Usuarios; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Usuarios" ("Id", "Nome", "Cpf", "Senha", "DataCriacao", "Ativo", "Email", "Telefone", "Discriminator", "Cro", "DataNascimento", "EnderecoId", "ResponsavelId", "TipoId") FROM stdin;
4d2a42a1-2688-47a4-80f3-4539dbfd5cc1	Recepcionista	213.213.233-23	AQAAAAEAACcQAAAAEPEG4kKSMRdb+INgEZZuflti9n5USm8mEYlp0ig6EUF7ZQkPS0r2TrZPee2goIbqEA==	2021-10-23 16:34:07.796426	t	recepcionista@mail.com	21987923404	Recepcionista	\N	0001-01-01 00:00:00	\N	\N	\N
d60986b4-7179-4d9e-8bbb-454ead32e595	dentista	213.343.123.32	AQAAAAEAACcQAAAAEC3Lj/ClM6Iw4g6IN9e9uUV0RRt9G03SFzsnxjFJ0HqO2uYezsOzXO+gKv1RamMPZQ==	2021-10-23 21:24:39.369	t	dentista@mail.com	1232312323	Dentista	1232132	0001-01-01 00:00:00	\N	\N	\N
3fa85f64-5717-4562-b3fc-2c963f66afa6	teste	314423124123123	AQAAAAEAACcQAAAAEBaNrcthAeZVqRBiK/DH/9If+sk56JJobyfxL0griQb/9t3JqkBKy3ivmPd8FOUeww==	2021-10-26 10:45:54.809349	t	teste1@mail.com	12121231231	Recepcionista	\N	2021-10-23 21:29:03.064	\N	\N	4
ea1b7576-9990-4e84-9496-35235a47ae41	cliente	12323232133	AQAAAAEAACcQAAAAEAyK3k8kXN6jCK9jdhCYrFBwbpevLQmXVLiuCqqNZNG/z0JP0a5R4bl8dzgl8L0erw==	2021-10-23 21:29:03.064	t	cliente@mail.com	1232312321123	Cliente	\N	2021-10-23 21:29:03.064	\N	\N	3
7b1b2504-6190-4242-b430-5135aa5469d4	ricarod	43534532	AQAAAAEAACcQAAAAELUkraCxUdEmAwBU7RgyRz3fFccVjtsKELLMvebzzKS657AyGD/lAHcggKuByvJp8g==	2021-10-26 12:37:44.974329	t	ricardo@mail.com	12121231231	Cliente	\N	2021-10-23 21:29:03.064	\N	\N	3
bbaa76ce-6c4a-4513-b62e-83dccce08bde	fefe	234234223	AQAAAAEAACcQAAAAECUYS8HO8kKj/I3aFGSPoQ3iONPBu+1noDAVAEEl/8MexhM/FDSCHjvCPfRdly5ppQ==	2021-10-26 12:44:23.418714	t	fefe@mail.com	123114214	Cliente	\N	2021-10-18 00:00:00	\N	\N	3
e0924f31-29ae-4e06-ae87-16e131509329	hhhhhhhhhhhhhhh	67867867867	AQAAAAEAACcQAAAAENOBLL/Obi99bskdl991e3ZSUmV7GXztFuo98DY/GzUkOQomBBirW72xwEZC7iIamA==	2021-10-26 15:00:32.633317	t	jkjkjkjkjkjkjkjk	567567567567	Cliente	\N	2021-10-27 00:00:00	\N	\N	3
935ec230-acad-475a-b8ec-3e85843e252c	vvvvvvv	vvvv	AQAAAAEAACcQAAAAEClBABvgCrimdeEFxYXKLlPArefuz4wQvlJcZaDZeMEPPreOk+cjkQDuGViU5Nh2OQ==	2021-10-26 15:22:51.76545	t	vvvv	vvv	Cliente	\N	2021-10-17 00:00:00	\N	\N	3
5ec7ea56-f027-4f6c-9660-c5716bb89149	asdasd	asdasdasd	AQAAAAEAACcQAAAAENaUBnHinIBeEHROC+SaYr5B8YqWwoBvwa/EWF+V7qN8p1xfqxKAC8WSsLnNqmsmVQ==	2021-10-26 15:24:09.312082	t	sdasdasd	dasdasda	Cliente	\N	2021-10-12 00:00:00	\N	\N	3
24eec0c6-fcc5-44d6-8d44-f26c499ba432	dfdfdfdf	dfdfdfd	AQAAAAEAACcQAAAAEIpevrENkIDUUCmDCw/mmCKcOkHSg29cI92oZgNjjnyNCLmNmlWlV8HFTW+ubD4Xrw==	2021-10-26 15:25:57.292338	t	fdfdfdfdfd	dfdfdfd	Cliente	\N	2021-10-29 00:00:00	\N	\N	3
897fbbd9-ef83-46fb-ad4c-3878948e5d92	cdcdvfbgnh	3423545345	AQAAAAEAACcQAAAAEDmhvi75HXCghdjZo22MyE2+i4NLLZW7V/uTHSiX08Cm+MkeM2UG371JJ4wDGyPxFw==	2021-10-26 20:09:43.4742	t	teste	12121231231	Recepcionista	\N	2021-10-23 21:29:03.064	\N	\N	4
600c2437-6ab4-49fe-9bad-db110a16771c	dentista chefe	12323	AQAAAAEAACcQAAAAELoJzXx0CCFx9yxCmERrObFSoahJCRc1XmpxIz080xmY7hV36tBGezBtNck9huG3Og==	2021-10-26 21:33:01.717224	t	dentistachefe@mail.com	12312312312	Dentista	123124123123	2021-10-13 00:00:00	\N	\N	2
f55bf633-ad3b-47db-8a54-bdfe4f4227b6	234253324e	1231413453423	AQAAAAEAACcQAAAAEADhHTjZkX8cep+3TMGUDUM4yk8I+9S+2eu4WFKadW8X6iis4RqJ4Dw4Ob/fZUr3pQ==	2021-10-27 20:27:12.100531	t	sadsdasdasdasdasda	12121231231	Recepcionista	\N	2021-10-23 21:29:03.064	\N	\N	4
baf6a601-e8a8-4ef0-9c24-054fffb6e905	Admin	111.111.111-12	AQAAAAEAACcQAAAAEADhHTjZkX8cep+3TMGUDUM4yk8I+9S+2eu4WFKadW8X6iis4RqJ4Dw4Ob/fZUr3pQ==	2021-10-27 20:31:28.800328	t	Admin@admin.com	12121231231	Usuario	\N	2021-10-27 20:31:28.801638	\N	\N	4
2408f2f6-c9ee-49c0-9774-90646e1d5bcb	Fabricio	1234123145	AQAAAAEAACcQAAAAENQAd4C9GiXAHV+ti8lQasxHKPP2x2HrvN9AXP0d11KO9U3JvzX7fX3YIouqnDPRbg==	2021-11-24 18:54:15.070157	t	fabricio@mail.com	1234123414	Cliente	\N	1995-08-24 00:00:00	\N	\N	3
c1982392-f41d-41ae-9a9d-0dee0da11c07	fernando	123.123.123-32	AQAAAAEAACcQAAAAEDAqESq6bpg7UGfDdrBVx8RcQoL8fjk3uAAWV3GuBU9nu+dLK6ohAgCyWsV7RFBBkg==	2021-12-13 17:04:04.112358	t	fernando@mail.com	21 92313-1234	Cliente	\N	2021-12-30 00:00:00	\N	\N	3
96d2da40-d0f9-4e9c-96b0-a0385a3c810a	matheus	143.113.123-32	AQAAAAEAACcQAAAAEJRatDUrKFjDa9DW1MAO8kQDVb3HWGTFKQxI5mXpHFwAvvtR8YTYpwqXiAG4EUq6Lg==	2021-12-13 17:07:17.268562	t	matheus@mail.com	21 90324-2434	Cliente	\N	2021-12-23 00:00:00	\N	\N	3
b49866bc-09f0-4930-a13b-9c3a36799640	Marcio	123-123-432.12	AQAAAAEAACcQAAAAEEApjFBNP0vGHzpsn3vbn3D79clJV6eZPrLOnVm/59THFHJox//+wmagwobU+ecqHw==	2021-12-13 17:58:00.030278	t	Marcio@mail.com	21 98473-8324	Dentista	12343	2021-12-23 00:00:00	\N	\N	2
\.


--
-- TOC entry 3387 (class 0 OID 16396)
-- Dependencies: 209
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20211016203917_initialcreate	5.0.11
20211026010246_adicionandofeatures	5.0.11
20211027233129_iniciandocomdata	5.0.11
\.


--
-- TOC entry 3215 (class 2606 OID 33092)
-- Name: Armazems PK_Armazems; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Armazems"
    ADD CONSTRAINT "PK_Armazems" PRIMARY KEY ("Id");


--
-- TOC entry 3219 (class 2606 OID 33097)
-- Name: Consultas PK_Consultas; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Consultas"
    ADD CONSTRAINT "PK_Consultas" PRIMARY KEY ("Id");


--
-- TOC entry 3233 (class 2606 OID 33145)
-- Name: Documentos PK_Documentos; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Documentos"
    ADD CONSTRAINT "PK_Documentos" PRIMARY KEY ("Id");


--
-- TOC entry 3221 (class 2606 OID 33114)
-- Name: Endereco PK_Endereco; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Endereco"
    ADD CONSTRAINT "PK_Endereco" PRIMARY KEY ("Id");


--
-- TOC entry 3236 (class 2606 OID 33157)
-- Name: PerguntaBooleana PK_PerguntaBooleana; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PerguntaBooleana"
    ADD CONSTRAINT "PK_PerguntaBooleana" PRIMARY KEY ("Id");


--
-- TOC entry 3239 (class 2606 OID 33169)
-- Name: Perguntastring PK_Perguntastring; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Perguntastring"
    ADD CONSTRAINT "PK_Perguntastring" PRIMARY KEY ("Id");


--
-- TOC entry 3230 (class 2606 OID 33133)
-- Name: Produtos PK_Produtos; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Produtos"
    ADD CONSTRAINT "PK_Produtos" PRIMARY KEY ("Id");


--
-- TOC entry 3223 (class 2606 OID 33119)
-- Name: Prontuarios PK_Prontuarios; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Prontuarios"
    ADD CONSTRAINT "PK_Prontuarios" PRIMARY KEY ("Id");


--
-- TOC entry 3225 (class 2606 OID 33126)
-- Name: TipoUsuario PK_TipoUsuario; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TipoUsuario"
    ADD CONSTRAINT "PK_TipoUsuario" PRIMARY KEY ("Id");


--
-- TOC entry 3213 (class 2606 OID 16407)
-- Name: Usuarios PK_Usuarios; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id");


--
-- TOC entry 3206 (class 2606 OID 16400)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3216 (class 1259 OID 33182)
-- Name: IX_Consultas_ClienteId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Consultas_ClienteId" ON public."Consultas" USING btree ("ClienteId");


--
-- TOC entry 3217 (class 1259 OID 33183)
-- Name: IX_Consultas_DentistaId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Consultas_DentistaId" ON public."Consultas" USING btree ("DentistaId");


--
-- TOC entry 3231 (class 1259 OID 33184)
-- Name: IX_Documentos_ProntuarioId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Documentos_ProntuarioId" ON public."Documentos" USING btree ("ProntuarioId");


--
-- TOC entry 3234 (class 1259 OID 33185)
-- Name: IX_PerguntaBooleana_ProntuarioId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_PerguntaBooleana_ProntuarioId" ON public."PerguntaBooleana" USING btree ("ProntuarioId");


--
-- TOC entry 3237 (class 1259 OID 33186)
-- Name: IX_Perguntastring_ProntuarioId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Perguntastring_ProntuarioId" ON public."Perguntastring" USING btree ("ProntuarioId");


--
-- TOC entry 3226 (class 1259 OID 33187)
-- Name: IX_Produtos_ArmazemId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Produtos_ArmazemId" ON public."Produtos" USING btree ("ArmazemId");


--
-- TOC entry 3227 (class 1259 OID 33188)
-- Name: IX_Produtos_Id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Produtos_Id" ON public."Produtos" USING btree ("Id");


--
-- TOC entry 3228 (class 1259 OID 33189)
-- Name: IX_Produtos_Nome; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Produtos_Nome" ON public."Produtos" USING btree ("Nome");


--
-- TOC entry 3207 (class 1259 OID 33175)
-- Name: IX_Usuarios_Cpf; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Usuarios_Cpf" ON public."Usuarios" USING btree ("Cpf");


--
-- TOC entry 3208 (class 1259 OID 33176)
-- Name: IX_Usuarios_Cro; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Usuarios_Cro" ON public."Usuarios" USING btree ("Cro");


--
-- TOC entry 3209 (class 1259 OID 33177)
-- Name: IX_Usuarios_Email; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Usuarios_Email" ON public."Usuarios" USING btree ("Email");


--
-- TOC entry 3210 (class 1259 OID 33178)
-- Name: IX_Usuarios_EnderecoId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Usuarios_EnderecoId" ON public."Usuarios" USING btree ("EnderecoId");


--
-- TOC entry 3211 (class 1259 OID 33181)
-- Name: IX_Usuarios_TipoId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Usuarios_TipoId" ON public."Usuarios" USING btree ("TipoId");


--
-- TOC entry 3242 (class 2606 OID 33098)
-- Name: Consultas FK_Consultas_Usuarios_ClienteId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Consultas"
    ADD CONSTRAINT "FK_Consultas_Usuarios_ClienteId" FOREIGN KEY ("ClienteId") REFERENCES public."Usuarios"("Id") ON DELETE CASCADE;


--
-- TOC entry 3243 (class 2606 OID 33103)
-- Name: Consultas FK_Consultas_Usuarios_DentistaId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Consultas"
    ADD CONSTRAINT "FK_Consultas_Usuarios_DentistaId" FOREIGN KEY ("DentistaId") REFERENCES public."Usuarios"("Id") ON DELETE CASCADE;


--
-- TOC entry 3245 (class 2606 OID 33146)
-- Name: Documentos FK_Documentos_Prontuarios_ProntuarioId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Documentos"
    ADD CONSTRAINT "FK_Documentos_Prontuarios_ProntuarioId" FOREIGN KEY ("ProntuarioId") REFERENCES public."Prontuarios"("Id") ON DELETE RESTRICT;


--
-- TOC entry 3246 (class 2606 OID 33158)
-- Name: PerguntaBooleana FK_PerguntaBooleana_Prontuarios_ProntuarioId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PerguntaBooleana"
    ADD CONSTRAINT "FK_PerguntaBooleana_Prontuarios_ProntuarioId" FOREIGN KEY ("ProntuarioId") REFERENCES public."Prontuarios"("Id") ON DELETE RESTRICT;


--
-- TOC entry 3247 (class 2606 OID 33170)
-- Name: Perguntastring FK_Perguntastring_Prontuarios_ProntuarioId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Perguntastring"
    ADD CONSTRAINT "FK_Perguntastring_Prontuarios_ProntuarioId" FOREIGN KEY ("ProntuarioId") REFERENCES public."Prontuarios"("Id") ON DELETE RESTRICT;


--
-- TOC entry 3244 (class 2606 OID 33134)
-- Name: Produtos FK_Produtos_Armazems_ArmazemId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Produtos"
    ADD CONSTRAINT "FK_Produtos_Armazems_ArmazemId" FOREIGN KEY ("ArmazemId") REFERENCES public."Armazems"("Id") ON DELETE CASCADE;


--
-- TOC entry 3240 (class 2606 OID 33190)
-- Name: Usuarios FK_Usuarios_Endereco_EnderecoId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT "FK_Usuarios_Endereco_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES public."Endereco"("Id") ON DELETE RESTRICT;


--
-- TOC entry 3241 (class 2606 OID 33200)
-- Name: Usuarios FK_Usuarios_TipoUsuario_TipoId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT "FK_Usuarios_TipoUsuario_TipoId" FOREIGN KEY ("TipoId") REFERENCES public."TipoUsuario"("Id") ON DELETE RESTRICT;


-- Completed on 2021-12-13 18:12:53

--
-- PostgreSQL database dump complete
--

