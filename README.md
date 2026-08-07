[README.md](https://github.com/user-attachments/files/30845977/README.md)
# Sistema de Agenda y Citas — Glow & Style Salón de Belleza

Sistema de escritorio para la gestión integral de un salón de belleza: clientes, estilistas, servicios, citas y pagos. Desarrollado como proyecto final para la asignatura de Programación Orientada a Objetos.

## Descripción

El sistema permite administrar el día a día de un salón: agendar citas evitando choques de horario, controlar el horario laboral de cada estilista, calcular precios según el tipo y subtipo de servicio, registrar pagos, generar reportes diarios (Excel/PDF) y enviar recordatorios automáticos por correo a los clientes.

## Tecnologías

- **Lenguaje:** C#
- **Framework:** .NET 8.0 — Windows Forms
- **Base de datos:** SQL Server
- **Conexión a datos:** ADO.NET (Microsoft.Data.SqlClient)
- **Generación de reportes:** iTextSharp (PDF), ClosedXML/EPPlus (Excel)

## Arquitectura

El proyecto sigue una arquitectura en 3 capas:

```
SistemaAgenda.Datos/       → Entidades, DAL e interfaces (acceso a la base de datos)
SistemaAgenda.Negocios/    → BLL (reglas de negocio y validaciones)
Sistema_de_AgendayCitas/   → Formularios (interfaz de usuario)
```

### Características técnicas
- Arquitectura en capas (Datos / Negocios / UI)
- Interfaces para cada módulo (ICitasDAL, IClientesDAL, IEstilistaDAL, IHorarioEstilistaDAL, IPagosDAL, IServiciosDAL, IUsuariosDAL)
- Programación asíncrona (async/await) en toda la capa de acceso a datos
- Clase abstracta y métodos virtuales/abstractos (`Servicio.cs`, para el cálculo de precios por tipo/subtipo de servicio)
- Manejo global de excepciones
- Login con validación contra base de datos

## Módulos del sistema

| Módulo | Entrada | Consulta |
|---|---|---|
| Clientes | ✅ | ✅ |
| Estilistas | ✅ | ✅ |
| Servicios | ✅ | ✅ |
| Citas | ✅ | ✅ |
| Pagos | ✅ | ✅ |
| Usuarios | ✅ | ✅ |
| Reportes del día (Excel/PDF) | — | ✅ |
| Notificaciones de recordatorio | — | ✅ |

## Base de datos

El script completo de la base de datos (`DB_Salon.sql`) y el diagrama entidad-relación se encuentran en la carpeta [`BaseDeDatos/`](./BaseDeDatos).

## Cómo ejecutar el proyecto

1. Clona el repositorio:
   ```
   git clone https://github.com/LMER09/SistemaAgenda.git
   ```
2. Restaura la base de datos ejecutando `BaseDeDatos/DB_Salon.sql` en SQL Server Management Studio.
3. Ajusta la cadena de conexión en `ConexionDB.cs` con los datos de tu instancia local de SQL Server.
4. Abre `SistemaAgenda.slnx` en Visual Studio.
5. Compila y ejecuta el proyecto de inicio `Sistema_de_AgendayCitas`.

## Integrantes

- Novaly Pujols
- Luzmairy Espiritusanto
- Juan Manuel Contreras
- Mercy Báez
- Sebastian Vargas

## Universidad

Universidad Central del Este (UCE) — Ingeniería en Software
