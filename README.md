# 🌐 NexUs (Red Social)

## 📝 Descripción
Aplicación web de red social desarrollada implementando una **Arquitectura Onion** y utilizando ASP.NET Core MVC que permite a los usuarios crear publicaciones, interactuar con amigos, comentar y gestionar sus perfiles.

## ✨ Características

### 🔐 Sistema de Autenticación
- **Login**: Sistema de acceso con redirección automática al Home si ya está logueado
- **Registro**: Creación de cuenta con validaciones
- **Activación de cuenta**: Sistema de activación por **correo electrónico**
- **Recuperación de contraseña**: Restablecimiento mediante **correo electrónico**

### 📰 Publicaciones
- Creación, edición y eliminación de publicaciones
- Soporte para contenido multimedia (imágenes y videos de YouTube) 🖼️ 🎥
- Sistema de comentarios y respuestas anidadas (replies) 💬
- Visualización cronológica de publicaciones propias ⏱️

### 👥 Gestión de Amigos
- Agregar nuevos amigos mediante nombre de usuario ➕
- Visualizar listado de amigos actuales 📋
- Eliminar amigos ❌
- Ver publicaciones de amigos en orden cronológico 📱

### 👤 Perfil de Usuario
- Edición de información personal ✏️
- Actualización de foto de perfil 📸
- Cambio de contraseña seguro 🔒

### 🛡️ Seguridad
- Protección de rutas y recursos
- Validación de sesiones activas
- Redirección automática a login para usuarios no autenticados

## 📸 Capturas de Pantalla

### Inicio de Sesión
![Login Screen](/screenshots/login.png)
*Pantalla de inicio de sesión con opciones para registro y recuperación de contraseña*

### Registro de Usuario
![registro](https://github.com/user-attachments/assets/7984f2d7-48e4-4f68-86bf-e1ffb6b18245)

*Formulario de registro con validaciones en tiempo real*

### Página Principal (Home)
![home](https://github.com/user-attachments/assets/11803a24-8136-4ee8-ba2a-609341faf005)

*Vista del timeline con publicaciones propias y sistema de comentarios*

### Creación de Publicación
![crear post](https://github.com/user-attachments/assets/2dd44642-6fa2-4216-84d9-084963355ded)

*Interfaz para crear nuevas publicaciones con soporte multimedia*

### Gestión de Amigos
![amigos](https://github.com/user-attachments/assets/92042adc-e6d6-49dd-bf0b-566e36f437ce)

*Pantalla de gestión de amigos y visualización de publicaciones*

### Perfil de Usuario
![actualizar perfil](https://github.com/user-attachments/assets/977027a5-b57a-4dc6-ac74-8674c1323d0f)

*Edición de información personal y foto de perfil*

## 🛠️ Tecnologías Utilizadas

- **ASP.NET Core MVC 6/7/8** 🔄
- **Entity Framework Core** con enfoque Code First 📊
- **Arquitectura ONION** 🧅
- **Bootstrap** para interfaz de usuario 🎨
- **Servicios y repositorios genéricos** ⚙️
- **AutoMapper** para mapeo de entidades 🔁
- **Validaciones** a través de ViewModels ✅
- **Servicio de correo electrónico** integrado 📧

## 📂 Estructura del Proyecto

La solución implementa una arquitectura **Onion** con el siguiente esquema:

```
NexUs/
├── Core/
│   ├── NexUs.Core.Application/
│   │
│   └── NexUs.Core.Domain/
│ 
├── Infrastructure/
│   ├── NexUs.Infrastructure.Identity/
│   │  
│   ├── NexUs.Infrastructure.Persistence/
│   │
│   └── NexUs.Infrastructure.Shared/
│      
└── Presentation/
    └── NexUs.Web/
    
```

Este proyecto sigue una estructura de arquitectura limpia con separación de responsabilidades:

- **Core**: Contiene la lógica de negocio y dominio de la aplicación
  - **Application**: Servicios, DTOs, interfaces y lógica de aplicación
  - **Domain**: Entidades de dominio 

- **Infrastructure**: Implementación de interfaces y acceso a recursos externos
  - **Identity**: Gestión de autenticación y autorización
  - **Persistence**: Acceso a datos y repositorios
  - **Shared**: Servicios compartidos entre capas, como el envío de correo.

- **Presentation**: Capa de presentación y UI
  - **Web**: Aplicación ASP.NET MVC con controladores, vistas y modelos

Cada proyecto tiene su propio `ServiceRegistration.cs` para la configuración de inyección de dependencias, facilitando la integración en la aplicación principal.
## 🚀 Configuración Inicial

### ⚠️ Requisitos Previos
- .NET SDK 7.0/8.0 o superior
- SQL Server o SQL Server Express
- Visual Studio 2022 / VS Code con extensiones .NET

### ⚙️ Instalación y Configuración

1. Clone el repositorio
   ```bash
   git clone https://github.com/username/social-network.git
   cd social-network
   ```

2. Restaure las dependencias
   ```bash
   dotnet restore
   ```

3. Configure la cadena de conexión en `appsettings.json`
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SocialNetworkDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. Aplique las migraciones
   ```bash
   dotnet ef database update
   ```

5. Ejecute la aplicación
   ```bash
   dotnet run --project SocialNetwork.WebApp
   ```



