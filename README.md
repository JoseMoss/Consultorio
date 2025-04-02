Sistema Odontológico es una aplicación web desarrollada en ASP.NET Core MVC con Entity Framework Core, diseñada para gestionar los tratamientos de ortodoncia en un consultorio dental. Este sistema permite a los odontólogos y administradores realizar un seguimiento eficiente de los pacientes, sus pagos, y tratamientos adicionales, optimizando la administración del consultorio.

Características principales:
Alta de pacientes: Registro de pacientes con información clave como nombre, dirección y teléfono.
Gestión de pagos: Seguimiento de pagos iniciales y mensualidades, incluyendo una tabla detallada con mes, abono, saldo pendiente, tratamientos adicionales y costos asociados.
Búsqueda de pacientes: Funcionalidad para buscar pacientes por apellido, facilitando la localización rápida de registros.
Tratamientos adicionales: Registro de tratamientos adicionales (como extracciones) con costo, que se suman al saldo total del paciente.
Interfaz amigable: Diseño basado en MVC con vistas responsivas y tablas interactivas para una mejor experiencia de usuario.
Tecnologías utilizadas:
ASP.NET Core MVC: Framework para la creación de aplicaciones web robustas.
Entity Framework Core: ORM para la gestión de datos en una base de datos SQL (SQL Server LocalDB por defecto).
C#: Lenguaje principal para el backend.
HTML/CSS/Bootstrap: Para las vistas y diseño de la interfaz de usuario.
SQL Server LocalDB: Base de datos local para desarrollo (configurable para otros proveedores).
Instalación y configuración:
Clona este repositorio: git clone <URL_DEL_REPOSITORIO>
Asegúrate de tener .NET 8.0 SDK instalado.
Instala las dependencias con: dotnet restore
Configura la cadena de conexión en appsettings.json para SQL Server LocalDB o tu proveedor de base de datos preferido.
Ejecuta las migraciones para crear la base de datos: dotnet ef migrations add InitialCreate y dotnet ef database update.
Ejecuta la aplicación: dotnet run o usa Visual Studio para compilar y ejecutar.
Contribuciones:
¡Contribuciones son bienvenidas! Por favor, crea un issue para discutir cambios o envía un pull request con tus mejoras.



