# Visiotech
Prueba tecnica

Este proyecto es una API desarrollada en .NET que se ejecuta en Docker junto con PostgreSQL y PgAdmin para la gestión de la base de datos.

## Prerrequisitos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes:

- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET SDK](https://dotnet.microsoft.com/download)

## Instrucciones de Ejecución

Sigue los siguientes pasos para ejecutar el proyecto:

### Clonar el Repositorio

Clona el repositorio en tu máquina local utilizando el siguiente comando:

```
bash
git clone https://github.com/yaloves/visiotech.git
cd tu-repositorio
```

### Configurar variables de Entorno

En el archivo .env aparecerá la cadena de conexión a la base de datos.

### Paso 3: Ejecutar contenedores

Usa docker-compose para construir y ejecutar los contenedores

```
bash
docker-compose up --build
```

### API

La API estará disponible en 
```
http://localhost:8080/api
```

### PgAdmin
La acceso a PgAdmin estará disponible en 
```
http://localhost:5050 
```
Ver credenciales en .env
