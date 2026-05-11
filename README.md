# 🏕️ Camping Pro

Sistema de administración de inventario y préstamos para una tienda de artículos de camping. Permite gestionar el catálogo de productos, registrar préstamos a clientes y llevar un control centralizado a través de un dashboard interactivo.

---

## 📋 Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Funcionalidades Principales](#funcionalidades-principales)
- [Requisitos Previos](#requisitos-previos)
- [Instalación y Configuración](#instalación-y-configuración)
- [Base de Datos](#base-de-datos)
- [Equipo](#equipo)

---

## 📖 Descripción General

**Camping Pro** es una aplicación web desarrollada como proyecto académico que permite a una tienda de camping administrar de forma eficiente su inventario de equipos y gestionar los préstamos realizados a sus clientes. El sistema cuenta con un panel de control (dashboard) que ofrece una vista general del estado del negocio en tiempo real.

---

## 🛠️ Tecnologías Utilizadas

### Frontend
| Tecnología | Uso |
|------------|-----|
| **Angular** | Framework principal del frontend |
| **TypeScript** | Lenguaje base del proyecto Angular |
| **HTML5** | Estructura de las vistas |
| **CSS3** | Estilos y diseño visual |

### Backend
| Tecnología | Uso |
|------------|-----|
| **C# (.NET)** | Lógica del servidor y API REST |
| **SQL Server** | Motor de base de datos relacional |

---

## 📁 Estructura del Proyecto

```
camping pro/
│
├── src/
│   ├── app/
│   │   ├── dashboard/          # Módulo del panel principal
│   │   ├── inventario/         # Módulo de gestión de inventario
│   │   ├── prestamos/          # Módulo de préstamos
│   │   ├── clientes/           # Módulo de gestión de clientes
│   │   ├── app.module.ts       # Módulo raíz de Angular
│   │   ├── app.component.ts    # Componente raíz
│   │   └── app-routing.module.ts # Configuración de rutas
│   │
│   ├── assets/                 # Imágenes y recursos estáticos
│   ├── environments/           # Variables de entorno
│   └── index.html              # Punto de entrada HTML
│
├── backend/                    # Proyecto C# / .NET
│   ├── Controllers/            # Controladores de la API
│   ├── Models/                 # Modelos de datos
│   ├── Services/               # Lógica de negocio
│   └── appsettings.json        # Configuración de la BD
│
├── angular.json
├── package.json
└── README.md
```

> **Nota:** La estructura puede variar ligeramente según la organización del repositorio en cada rama.

---

## ✅ Funcionalidades Principales

### 🗂️ Inventario
- Registrar, editar y eliminar artículos de camping
- Consultar disponibilidad de productos
- Control de stock en tiempo real

### 🔄 Préstamos
- Registrar nuevos préstamos a clientes
- Seguimiento del estado de cada préstamo (activo / devuelto)
- Historial de préstamos por cliente

### 👥 Clientes
- Registro de nuevos clientes
- Consulta y edición de información de clientes
- Historial de actividad por cliente

### 📊 Dashboard
- Vista general del inventario disponible
- Préstamos activos y pendientes de devolución
- Resumen de clientes registrados

---

## ⚙️ Requisitos Previos

Asegúrate de tener instalado lo siguiente antes de ejecutar el proyecto:

- [Node.js](https://nodejs.org/) v18 o superior
- [Angular CLI](https://angular.io/cli) v15 o superior
- [.NET SDK](https://dotnet.microsoft.com/) v6 o superior
- [SQL Server](https://www.microsoft.com/es-es/sql-server) (o SQL Server Express)
- [Git](https://git-scm.com/)

---

## 🚀 Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/Starlynxv/Task-programing-2.git
cd "Task-programing-2"
git checkout Campingpro
cd "camping pro"
```

### 2. Instalar dependencias del frontend

```bash
npm install
```

### 3. Ejecutar el frontend (Angular)

```bash
ng serve
```

La aplicación estará disponible en: `http://localhost:4200`

### 4. Configurar y ejecutar el backend (C#)

```bash
cd backend
dotnet restore
dotnet run
```

> Asegúrate de configurar la cadena de conexión a SQL Server en `appsettings.json` antes de ejecutar el backend.

---

## 🗄️ Base de Datos

El proyecto utiliza **SQL Server** como motor de base de datos.

### Configuración de la cadena de conexión

En el archivo `appsettings.json` del backend, actualiza la cadena de conexión con tus credenciales:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=CampingProDB;User Id=TU_USUARIO;Password=TU_PASSWORD;"
  }
}
```

### Tablas principales

| Tabla | Descripción |
|-------|-------------|
| `Clientes` | Información de los clientes registrados |
| `Inventario` | Artículos de camping disponibles en la tienda |
| `Prestamos` | Registro de préstamos activos e historial |
| `DetallePrestamo` | Artículos incluidos en cada préstamo |

---

## 👨‍💻 Equipo

Proyecto desarrollado como parte de una entrega académica.

| Nombre | Rol |
|--------|-----|
| Starlynxv | Desarrollador / Repositorio |

---

## 📄 Licencia

Este proyecto es de uso académico. Todos los derechos reservados a sus autores.
