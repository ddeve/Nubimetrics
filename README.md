##Nubimetrics Challenge
1. **Crear una aplicaci�n (usando framework .Net 4.7 o .Net Core 2.2 en adelante) del tipo REST Web Api que exponga 2 endpoints:**
	- Un endpoint "pa�ses" que sea llamado con los par�metros del pa�s ej:
    http://localhost:8080/MyRestfulApp/Paises/PAIS, donde PAIS podr�a ser "AR", "BR", "CO".
    Para los par�metros BR y CO, hacer que el endpoint de una respuesta que sea error 401 unauthorized de http.
    Para el par�metro AR el endpoint deber� consumir la informaci�n del pa�s desde el servicio externo: https://api.mercadolibre.com/classified_locations/countries/AR

	- Implementar otro endpoint �busqueda� que sea llamado con un par�metro de tipo string ej: http://localhost:8080/MyRestfulApp/busqueda/xxx (donde xxx es el texto a buscar ej: iphone)
	El endpoint deber� consumir la informaci�n desde el siguiente servicio externo: https://api.mercadolibre.com/sites/MLA/search?q=xxx
	Este endpoint deber� devolver el objeto como lo devuelve el servicio externo, pero en el array �results� solo incluir los fields: �id, site_id, title, price, seller.id, permalink�.
	
	- Crear un endpoint "usuarios" que devuelva todos los usuarios de una tabla "User" con los campos, id, nombre, apellido, email, password. Para ello crear la base de datos, la tabla y popularla con un script.
	Crear los endpoints necesarios en la misma api rest para el ABM de usuarios.

2. **Crear otro proyecto (usando framework .Net 4.7 o .Net Core 2.2 en adelante) que al ser ejecutado consuma los datos de los siguientes endpoints:**

	- https://api.mercadolibre.com/currencies/
	- https://api.mercadolibre.com/currency_conversions/search?from=XXX&to=USD

	La idea es que se almacene en disco un json con la estructura que devuelve el endpoint�currencies� pero que adicionalmente incluya una nueva property �todolar� con el resultado del segundo endpoint.
	El endpoint �currency_conversions� toma como par�metro en �from� el id de moneda correspondiente a un pa�s (que devuelve el primer endpoint �currencies�).
	Adicionalmente la misma aplicaci�n tiene que almacenar en disco un archivo csv con cada uno de los resultados obtenidos de �currency_conversions�, es decir debe almacenar s�lo los resultados obtenidos de la property �ratio� (Ej: 0.0147275,0.013651,0.727565).
	
	
**Subir los proyectos a un mismo repositorio de github.**

####Bonus points
-  Crear unit tests.
-  C�digo limpio y ordenado as� como separaci�n de responsabilidades.
-  Uso de patrones de dise�o y explicaci�n del uso de los mismos.

####Notas
- No usar el sdk para .NET de Mercadolibre (https://github.com/mercadolibre/net-sdk ).
- Proveer el c�digo fuente, el script para generar la base de datos y popularla con datos de prueba. Asimismo se deber�n proveer las instrucciones para poder ejecutar la aplicaci�n y los servicios.

##Implementaci�n de la soluci�n

Los ejercicios fueron resueltos usando .Net Core 3.1 y SQL Server 2014 dentro de la solucion ***NubimetricsChallenge***

Las �nicas librerias utilizadas son:

   - Microsoft.EntityFrameworkCore.SqlServer Version="5.0.13"
   - Newtonsoft.Json" Version="13.0.1"
    
------------

- Ejercicio 1 : Implementado en el proyecto ***NubimetricsChallenge***

    - Endpoint **paises** en Controlador **PaisesController** : GET https://localhost:44315/api/paises/AR
    - Endpoint **busqueda** en Controlador **BusquedaController** : GET https://localhost:44315/api/busqueda/iphone
    - Endpoint **usuarios** en Controlador **UsersController**:
       - Usuarios : GET https://localhost:44315/api/users
       - Usuario por Id : GET https://localhost:44315/api/users/1
       - Insertar Usuario: POST https://localhost:44315/api/users
       - Update Usuario : PUT https://localhost:44315/api/users/3
       - Delete Usuario : DELETE https://localhost:44315/api/users/3

- Ejercicio 2: Implementado en el proyecto ***NubimetricsChallenge2***

    - Implementado en Controlador **CurrenciesController** : GET https://localhost:44320/api/currencies Genera como salida los archivos **Currencies.json** y **CurrencyConvertions.csv**
    
##Instalaci�n

   - Clonar el repositorio o descargar todo el contenido a una carpeta local.
   - Ejecutar el script *Creacion de DB restApi Inserts inciales.sql* en un Servidor SQL Server Version 12 o superior.
   El mismo crear� la base de datos de nombre **RestAPi**  el usuario SQL de Login **restApi** y password ***restApi***  y la tabla **Users** e insertara 3 usuarios.

##Configuraci�n

   - Es necesario en el proyecto ***NubimetricsChallenge*** ajustar el archivo **appsettings.json**
   se debe cambiar el data source del "ConnectionStrings": { "Conexion": "data source=localhost; initial catalog=RestApi; user id=restApi; password=restApi; MultipleActiveResultSets=true " }, reemplazando **localhost** por el servidor SQL que corresponda.

##Ejecuci�n

   Se realizaron las pruebas utilizando Visual Studio 2019, ejecutando cada proyecto dentro del IIS Express integrado.

##Testing

   - Se incluye un proyecto de Postman para realizar las pruebas de todos los endpoints. 
   **Nubimetrics.postman_collection.json**
    
##Linkedin
https://www.linkedin.com/in/daniel-deve/