# 🌮 Sistema de Gestión para Restaurante (Full-Stack)

![Status](https://img.shields.io/badge/Estado-En_Desarrollo-yellow)
![React](https://img.shields.io/badge/Frontend-React_18-blue)
![Tailwind](https://img.shields.io/badge/Estilos-Tailwind_CSS_v4-38B2AC)
![.NET Core](https://img.shields.io/badge/Backend-.NET_Core_API-purple)
![SQL Server](https://img.shields.io/badge/Base_de_Datos-SQL_Server-red)

Un sistema integral "End-to-End" para la gestión segura de menús de restaurante. Este proyecto demuestra la separación de responsabilidades a través de una arquitectura moderna basada en el consumo de una API RESTful desde una Single Page Application (SPA).

## 🚀 Características Principales

* **🔒 Autenticación y Autorización:** Sistema de Login protegido mediante **JSON Web Tokens (JWT)**. Las rutas de la API están restringidas únicamente a usuarios con tokens válidos.
* **🎨 Interfaz Gráfica Premium:** Frontend completamente responsivo y estilizado con **Tailwind CSS v4**, ofreciendo una experiencia de usuario (UX) moderna y profesional.
* **📊 Dashboard de Datos:** Visualización dinámica del menú de productos consumiendo datos en tiempo real desde la base de datos, con formatos de moneda y renderizado condicional.
* **🗄️ Base de Datos Relacional:** Diseño escalable usando **SQL Server** y manipulado a través de **Entity Framework Core** (Code-First / Migraciones).

## 📸 Vistas del Proyecto

* **Pantalla de Login:** ![<img width="1287" height="836" alt="Captura de pantalla 2026-05-15 152659" src="https://github.com/user-attachments/assets/64b7ff37-f965-43ba-90db-aee3c4a41759" />
]
  

* **Dashboard de Menú:** ![<img width="1901" height="893" alt="Captura de pantalla 2026-05-15 152738" src="https://github.com/user-attachments/assets/ab8eed2d-6904-4aa6-ae4e-6bcdb5f6227d" />
]

## 🛠️ Stack Tecnológico

### Backend (API REST)
* **Framework:** C# / ASP.NET Core
* **ORM:** Entity Framework Core
* **Seguridad:** Autenticación Stateless (JWT) y Hashing de contraseñas.

### Frontend (SPA)
* **Librería Core:** React.js (Hooks: `useState`, `useEffect`)
* **Tooling:** Vite
* **Estilos:** Tailwind CSS v4 / PostCSS
* **Peticiones HTTP:** Fetch API asíncrona (`async/await`)

## ⚙️ Cómo ejecutar este proyecto localmente

### Requisitos
* Node.js y npm instalados.
* .NET SDK 8.0+
* Servidor SQL Server local o Express.<img width="1287" height="836" alt="Captura de pantalla 2026-05-15 152659" src="https://github.com/user-attachments/assets/688b04a5-0125-4bf9-b7b5-a690e0c89002" />


### Pasos
1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/SnakeH7/RestauranteAPI.git](https://github.com/SnakeH7/RestauranteAPI.git)
