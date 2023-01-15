BackEnd - API (servicios web tipo rest)

Se diseñó una API restful en .NET 6.0

Se creó una solución una arquitectua de capas así:

Common: Esta capa contrendria divesos proyectos net que desempeñen taras trasnversales a la aplicación. En este caso se implemento un registro de log de errores en un archivo txt (log.txt) que se puede ver en la carpeta service.
Model: Esta capa se encarga de dos tareas 
1.	El manejo de la logica del negocio en el proyecto llamado CORE 
2.	El acceso a la base de datos utilizando Entity Framework en el proyecto llamado Domain. 
Services: Esta capa contiene el proyecto llamado Service que contiene los endpoints de la API. Para la prueba solo se creo un controlador para el manejo de la tabla Personas.
Se implementó inyección de dependencias con el fin de hacer la solucion escalable en caso de que se quiera cambiar de base de datos para que el impacto en un refactorizacion sea mínimo. En general se aplicaron principios SOLID.
	
Instalación
1.	Establecer Service como el proyacto de inicio de la Solucion 
2.	Adecuar la cadena de conexión a la base de datos en el fichero appsettings.json del proyecto Service
 
 
Pruebas
En el servicio se implementó Swagger para facilitar las pruebas de los servicios
 
Sin embargo, se puede usar Postman para probar los mismos
1.	Consultar el listado de personas
GET: http://localhost:5108/api/personas
2.	Crear una persona
POST: http://localhost:5108/api/personas

3.	Actualizar lo datos de una persona
PUT: http://localhost:5108/api/personas

4.	Eliminar una persona
DELETE: http://localhost:5108/api/personas/{id}
Id: es el códido de la persona (campo PersonaID de la tabla Personas)
5.	Cagar fotografia
POST: http://localhost:5108/api/personas/loadImage/{id}
Id: es el códido de la persona (campo PersonaID de la tabla Personas)
6.	Descargar una fotografia
POST: http://localhost:5108/api/personas/getImage/{id}

Id: es el códido de la persona (campo PersonaID de la tabla Personas)

Base de datos
Se implemento en SQL Server 15 y se nombró: PruebaEvertec
Consta de una tabla llamada Personas

