USE [master]
GO

-- 1. CREAR BASE DE DATOS (Si no existe)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'DB_Salon')
BEGIN
    CREATE DATABASE [DB_Salon]
END
GO

USE [DB_Salon]
GO

-- 2. CREAR TABLAS PRINCIPALES (Sin dependencias)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](120) NOT NULL,
	[Telefono] [nvarchar](25) NOT NULL,
	[Correo] [nvarchar](200) NOT NULL,
	[Cedula] [nvarchar](20) NULL,
	CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [UQ_Clientes_Correo] UNIQUE NONCLUSTERED ([Correo] ASC)
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estilista]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Estilista](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](120) NOT NULL,
	[Telefono] [nvarchar](25) NOT NULL,
	[Correo] [nvarchar](200) NOT NULL,
	[Especialidad] [nvarchar](200) NOT NULL,
	[Cedula] [nvarchar](20) NULL,
	CONSTRAINT [PK_Estilista] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [UQ_Estilista_Correo] UNIQUE NONCLUSTERED ([Correo] ASC)
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Servicios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Servicios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_DeServicio] [nvarchar](300) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[DuracionMinutos] [int] NOT NULL,
	[Subtipo_DeServicio] [nvarchar](50) NULL,
	CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED ([id] ASC)
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Contrasena] [nvarchar](255) NOT NULL,
	CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [UQ_Usuarios_Usuario] UNIQUE NONCLUSTERED ([Usuario] ASC)
)
END
GO

-- 3. CREAR TABLAS DEPENDIENTES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HorarioEstilista]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HorarioEstilista](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Estilista] [int] NOT NULL,
	[DiaSemana] [tinyint] NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFin] [time](7) NOT NULL,
	CONSTRAINT [PK_HorarioEstilista] PRIMARY KEY CLUSTERED ([id] ASC)
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Citas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Citas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Clientes] [int] NOT NULL,
	[id_Servicios] [int] NOT NULL,
	[id_Estilista] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Estado] [nvarchar](30) NOT NULL,
	[Deposito] [decimal](10, 2) NOT NULL DEFAULT ((250)),
	CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED ([id] ASC)
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pagos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pagos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Citas] [int] NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[Metodo_DePago] [nvarchar](100) NOT NULL,
	[FechaPago] [datetime] NULL DEFAULT (getdate()),
	CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED ([id] ASC)
)
END
GO

-- 4. ÍNDICES
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Citas_Fecha' AND object_id = OBJECT_ID(N'[dbo].[Citas]'))
CREATE NONCLUSTERED INDEX [IX_Citas_Fecha] ON [dbo].[Citas] ([Fecha] ASC)
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'UQ_Clientes_Cedula' AND object_id = OBJECT_ID(N'[dbo].[Clientes]'))
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Clientes_Cedula] ON [dbo].[Clientes] ([Cedula] ASC) WHERE ([Cedula] IS NOT NULL)
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'UQ_Estilista_Cedula' AND object_id = OBJECT_ID(N'[dbo].[Estilista]'))
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Estilista_Cedula] ON [dbo].[Estilista] ([Cedula] ASC) WHERE ([Cedula] IS NOT NULL)
GO

-- 5. RELACIONES (CLAVES FORÁNEAS)
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Citas_Clientes]'))
ALTER TABLE [dbo].[Citas] WITH CHECK ADD CONSTRAINT [FK_Citas_Clientes] FOREIGN KEY([id_Clientes]) REFERENCES [dbo].[Clientes] ([id])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Citas_Estilista]'))
ALTER TABLE [dbo].[Citas] WITH CHECK ADD CONSTRAINT [FK_Citas_Estilista] FOREIGN KEY([id_Estilista]) REFERENCES [dbo].[Estilista] ([id])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Citas_Servicios]'))
ALTER TABLE [dbo].[Citas] WITH CHECK ADD CONSTRAINT [FK_Citas_Servicios] FOREIGN KEY([id_Servicios]) REFERENCES [dbo].[Servicios] ([id])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HorarioEstilista_Estilista]'))
ALTER TABLE [dbo].[HorarioEstilista] WITH CHECK ADD CONSTRAINT [FK_HorarioEstilista_Estilista] FOREIGN KEY([id_Estilista]) REFERENCES [dbo].[Estilista] ([id])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pagos_Citas]'))
ALTER TABLE [dbo].[Pagos] WITH CHECK ADD CONSTRAINT [FK_Pagos_Citas] FOREIGN KEY([id_Citas]) REFERENCES [dbo].[Citas] ([id]) ON DELETE CASCADE
GO

-- 6. RESTRICCIONES DE VALIDACIÓN (CHECK CONSTRAINTS)
ALTER TABLE [dbo].[Citas] WITH CHECK ADD CONSTRAINT [CK_Citas_Deposito] CHECK (([Deposito]>=(0)))
GO
ALTER TABLE [dbo].[Citas] WITH CHECK ADD CONSTRAINT [CK_Citas_Estado] CHECK (([Estado]='Reprogramada' OR [Estado]='Completada' OR [Estado]='Cancelada' OR [Estado]='Confirmada' OR [Estado]='Pendiente'))
GO
ALTER TABLE [dbo].[HorarioEstilista] WITH CHECK ADD CONSTRAINT [CK_HorarioEstilista_Dia] CHECK (([DiaSemana]>=(0) AND [DiaSemana]<=(6)))
GO
ALTER TABLE [dbo].[HorarioEstilista] WITH CHECK ADD CONSTRAINT [CK_HorarioEstilista_Horas] CHECK (([HoraInicio]<[HoraFin]))
GO
ALTER TABLE [dbo].[Pagos] WITH CHECK ADD CONSTRAINT [CK_Pagos_Metodo] CHECK (([Metodo_DePago]='Transferencia' OR [Metodo_DePago]='Tarjeta' OR [Metodo_DePago]='Efectivo'))
GO
ALTER TABLE [dbo].[Pagos] WITH CHECK ADD CONSTRAINT [CK_Pagos_Monto] CHECK (([Monto]>(0)))
GO
ALTER TABLE [dbo].[Servicios] WITH CHECK ADD CONSTRAINT [CK_Servicios_Duracion] CHECK (([DuracionMinutos]>(0)))
GO
ALTER TABLE [dbo].[Servicios] WITH CHECK ADD CONSTRAINT [CK_Servicios_Precio] CHECK (([Precio]>=(0)))
GO
ALTER TABLE [dbo].[Servicios] WITH CHECK ADD CONSTRAINT [CK_Servicios_Tipo] CHECK (([Tipo_DeServicio]='Spa' OR [Tipo_DeServicio]='Uñas' OR [Tipo_DeServicio]='Cabello'))
GO
ALTER TABLE [dbo].[Servicios] WITH CHECK ADD CONSTRAINT [CK_Servicios_Subtipo] CHECK (([Tipo_DeServicio]='Cabello' AND ([Subtipo_DeServicio]='Completo' OR [Subtipo_DeServicio]='Tinte' OR [Subtipo_DeServicio]='Corte') OR [Tipo_DeServicio]='Uñas' AND ([Subtipo_DeServicio]='Completo' OR [Subtipo_DeServicio]='Pedicura' OR [Subtipo_DeServicio]='Manicura') OR [Tipo_DeServicio]='Spa' AND ([Subtipo_DeServicio]='Profesional' OR [Subtipo_DeServicio]='Premium' OR [Subtipo_DeServicio]='Sencillo')))
GO
USE DB_Salon
GO

INSERT INTO Usuarios (Usuario, Contrasena)
VALUES ('admin', '1234')
GO