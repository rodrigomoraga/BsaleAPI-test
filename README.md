# E-Commerce API
Esta API se conecta a la base de datos de prueba de Bsale, esta permite obtener los productos y categorías almacenadas en la base de datos. La demostración de la API se puede ver en el siguiente link: 
https://test-api-bsale.herokuapp.com/


# Endpoints
## Para productos:
<ul>
  <li>GET <strong>/api/Product </strong>Obtener todos los productos</li>
  <li>POST <strong>/api/Product </strong>Crear un nuevo producto</li>
  <li>PUT <strong>/api/Product </strong>Actualizar un producto</li>
  <li>GET <strong>/api/Product/{id} </strong>Obtener un producto</li>
  <li>DELETE <strong>/api/Product/{id} </strong>Eliminar un producto</li>
  <li>GET <strong>/api/Product/Category/{id} </strong>Obtener todos los productos de una categoría</li>
  <li>POST <strong>/api/Product/Search/{busqueda} </strong>Obtener todos los productos que contenga la palabra buscada</li>
</ul>

## Para categorías:
<ul>
  <li>GET <strong>/api/Category </strong>Obtener todas las categorías</li>
  <li>POST <strong>/api/Category </strong>Crear una nueva categoría</li>
  <li>PUT <strong>/api/Category </strong>Actualizar una categoría</li>
  <li>GET <strong>/api/Category/{id} </strong>Obtener una categoría</li>
  <li>DELETE <strong>/api/Category/{id} </strong>Eliminar una categoría</li>
</ul>

# Instalación

Para el correcto funcionamiento de la API es necesario instalar los siguientes paquetes mediante NuGet

<code>PM> Install-Package MySql.Data</code>
<br>
<code>PM> Install-Package Dapper</code>

# Configuración
En caso de querer utilizar otra base de datos es necesario cambiar la cadena de conexión en <code>appsettings.json</code> 
