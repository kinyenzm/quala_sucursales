# Sucursales Quala

Este proyecto es una aplicación CRUD (Crear, Leer, Actualizar y Borrar) para el seguimiento de las sucursales de la empresa Quala. La aplicación está desarrollada con una API en .NET 6 y una interfaz web en Angular 15 con Angular Material. Los datos se almacenan en una base de datos SQL Server alojada en Azure.

#### Tecnologías usadas

- .NET 6
- EntityFrameworkCore
- AutoMapper
- Angular 15
- Angular Material
- SQL Server [Azure]

### Instalación

#### BackEnd

1. Navega a la carpeta `BackEnd`.
2. Ejecuta el comando `dotnet restore` para restaurar las dependencias del proyecto.
3. Ejecuta el comando `dotnet run` para iniciar la aplicación.

#### FrontEnd

1. Navega a la carpeta `FrontEnd`.
2. Ejecuta el comando `npm i` para instalar las dependencias del proyecto.
3. Ejecuta el comando `ng serve -o` para iniciar la aplicación.

#### Usos

- Crear nuevas sucursales: Agrega información sobre una nueva sucursal y guárdala en la base de datos.
- Leer información sobre las sucursales existentes: Consulta información detallada sobre las sucursales registradas en la base de datos.
- Actualizar información sobre las sucursales existentes: Modifica la información sobre una sucursal existente y guarda los cambios en la base de datos.
- Borrar sucursales existentes: Elimina una sucursal existente de la base de datos.

Para usar la aplicación, sigue los pasos descritos en la sección de Instalación para iniciar tanto el BackEnd como el FrontEnd. Una vez que ambas aplicaciones estén ejecutándose, puedes acceder a la interfaz web desde tu navegador para empezar a usar el sistema.

#### Licencia

Este proyecto está licenciado bajo la licencia MIT. Consulte el archivo [LICENSE](https://github.com/mit/licenses/blob/master/MIT-LICENSE.txt "LICENSE") para obtener más información.
