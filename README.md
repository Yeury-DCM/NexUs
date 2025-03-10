# 🌐 Red Social ASP.NET Core MVC

## 📝 Descripción
Aplicación web de red social desarrollada con ASP.NET Core MVC que permite a los usuarios crear publicaciones, interactuar con amigos, comentar y gestionar sus perfiles.

## ✨ Características

### 🔐 Sistema de Autenticación
- **Login**: Sistema de acceso con redirección automática al Home si ya está logueado
- **Registro**: Creación de cuenta con validaciones
- **Activación de cuenta**: Sistema de activación por correo electrónico
- **Recuperación de contraseña**: Restablecimiento mediante correo electrónico

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
![Register Screen](/screenshots/register.png)
*Formulario de registro con validaciones en tiempo real*

### Página Principal (Home)
![Home Feed](/screenshots/home.png)
*Vista del timeline con publicaciones propias y sistema de comentarios*

### Creación de Publicación
![Create Post](/screenshots/create-post.png)
*Interfaz para crear nuevas publicaciones con soporte multimedia*

### Gestión de Amigos
![Friends Management](/screenshots/friends.png)
*Pantalla de gestión de amigos y visualización de publicaciones*

### Perfil de Usuario
![User Profile](/screenshots/profile.png)
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

La solución implementa la arquitectura ONION con las siguientes capas:

```
SocialNetwork/
├── SocialNetwork.Domain/            # Entidades y lógica de negocio
├── SocialNetwork.Application/       # Servicios de aplicación e interfaces
├── SocialNetwork.Infrastructure/    # Implementaciones de infraestructura
│   ├── Persistence/                 # Acceso a datos y migraciones
│   └── Services/                    # Servicios externos (correo, etc.)
├── SocialNetwork.Shared/            # Componentes compartidos
└── SocialNetwork.WebApp/            # Capa de presentación MVC
    ├── Controllers/                 # Controladores MVC
    ├── ViewModels/                  # Modelos de vista
    └── Views/                       # Vistas Razor
```

## 🚀 Configuración Inicial

### ⚠️ Requisitos Previos
- .NET SDK 6.0/7.0/8.0 o superior
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

## 📱 Uso de la Aplicación

1. **Crear una cuenta**: Regístrese a través del formulario de registro y active su cuenta mediante el enlace enviado por correo. ✅
2. **Iniciar sesión**: Acceda con sus credenciales de usuario. 🔑
3. **Personalizar perfil**: Actualice su información personal en la sección "Mi Perfil". 👤
4. **Agregar amigos**: Busque y añada amigos mediante su nombre de usuario. 👥
5. **Crear publicaciones**: Comparta texto, imágenes o videos desde la pantalla principal. 📝
6. **Interactuar**: Comente publicaciones propias y de amigos, y responda a comentarios específicos. 💬

## 🖥️ Vistas Principales

### Home
La página principal muestra un timeline con todas las publicaciones del usuario ordenadas cronológicamente. Desde aquí, los usuarios pueden:
- Crear nuevas publicaciones con texto, imágenes o videos
- Ver, editar y eliminar sus publicaciones existentes
- Leer y responder a comentarios
- Crear hilos de conversación con respuestas anidadas

### Amigos
Esta sección permite a los usuarios gestionar sus conexiones sociales:
- Ver un listado de todos sus amigos con foto de perfil
- Agregar nuevos amigos mediante búsqueda por nombre de usuario
- Eliminar amigos existentes
- Visualizar las publicaciones de todos sus amigos en orden cronológico
- Interactuar con las publicaciones de sus amigos mediante comentarios

### Mi Perfil
El área personal del usuario donde puede:
- Ver y actualizar su información básica (nombre, apellido, teléfono, correo)
- Cambiar su foto de perfil
- Modificar su contraseña de forma segura
- Revisar sus datos de contacto

### Creación de Publicación
Interfaz intuitiva que permite a los usuarios compartir contenido:
- Editor de texto para escribir el contenido de la publicación
- Opción para adjuntar imágenes desde el dispositivo
- Posibilidad de incluir videos de YouTube mediante enlace
- Vista previa del contenido antes de publicar

## 🤝 Contribución

1. Fork el repositorio
2. Cree una rama para su característica (`git checkout -b feature/nueva-funcionalidad`)
3. Realice sus cambios y haga commit (`git commit -m 'Añadir nueva funcionalidad'`)
4. Haga push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abra un Pull Request

## 📄 Licencia

Este proyecto está licenciado bajo [MIT License](LICENSE).
